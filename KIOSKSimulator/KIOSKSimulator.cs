using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Greensoft.TlvLib;
using BerTlv;

namespace KIOSKSimulator
{
    /// <summary>
    /// TLV data.
    /// </summary>
    public class Tlv
    {
        public Tlv(string tag, int length,string data)
        {
            Tag = tag;
            Length = length;
            Data = data;
        }
        /// <summary>
        /// The raw TLV data.
        /// </summary>
        public string Data { get; private set; }

        /// <summary>
        /// The TLV tag.
        /// </summary>
        public string Tag { get; private set; }

        /// <summary>
        /// The length of the TLV value.
        /// </summary>
        public int Length { get; private set; }
    }

    public class KIOSKSimulator
    {
        #region Variable Declaration
        
        PurchaseRequest purchaseRequest = new PurchaseRequest();
        VoidRequest voidRequest = new VoidRequest();

        private int actualLength;
        internal readonly MemoryStream MemoryStream = new MemoryStream();

        List<Tlv> TLVRequestlist = new List<Tlv>();

        #endregion

        public KIOSKSimulator()
        {

        }

        #region Public Methods 

        public string ProcessReadRequest(string input)
        {
            string returnString = string.Empty;
            try
            {
                List<Tlv> TLVRequestlist = ParseTLV(input).AsEnumerable().ToList();

                foreach (Tlv tlvField in TLVRequestlist)
                {
                    if (tlvField.Tag == KIOSKTags.ActionCode) //21
                    {
                        if (tlvField.Data == purchaseRequest.RequestType) //check for "A0" 
                            { returnString = purchaseRequest.Validate(TLVRequestlist) ? ProcessPurchaseResponse() : string.Empty; return returnString; }
                        else if (tlvField.Data == voidRequest.RequestType) // check for "A2"
                            { returnString = voidRequest.Validate(TLVRequestlist) ?  ProcessVoidResponse() : string.Empty; return returnString;}
                    }
                }
                
            }
            catch(Exception e)
            {
                Console.WriteLine("Log:Failure Log Message:" + e.Message);
            }
            return returnString;
        }

        private string ProcessPurchaseResponse()
        {
            PurchaseResponse purchaseRespose = new PurchaseResponse();
            return string.Empty;
        }

        private string ProcessVoidResponse()
        {
            VoidResponse purchaseRespose = new VoidResponse();
            purchaseRespose.GetResponseCode();

            actualLength = actualLength + purchaseRespose.RequestType.Length;
            TlvEncoding.WriteTlv(
                this.MemoryStream,
                uint.Parse(purchaseRespose.MandatoryActionField, NumberStyles.HexNumber),
                Encoding.Default.GetBytes(purchaseRespose.RequestType));

            actualLength = actualLength + purchaseRespose.ResponseCodeValue.ToString().Length;
            TlvEncoding.WriteTlv(
                this.MemoryStream,
                uint.Parse(purchaseRespose.MandatoryResponseField, NumberStyles.HexNumber),
                Encoding.Default.GetBytes(purchaseRespose.ResponseCodeValue.ToString()));

            actualLength = actualLength +
                          voidRequest.ReferenceNumber.Replace("_", string.Empty).Length;
            TlvEncoding.WriteTlv(
                this.MemoryStream,
                uint.Parse(purchaseRespose.MandatoryReferenceField, NumberStyles.HexNumber),
                Encoding.Default.GetBytes(voidRequest.ReferenceNumber));

            this.MemoryStream.Position = 0;
            var buf = new byte[this.MemoryStream.Length];
            this.MemoryStream.Read(buf, 0, buf.Length);

            var messageToPort =
                BuildHexMessage(
                    BitConverter.ToString(buf).Replace("-", string.Empty),
                    this.actualLength);

            return messageToPort;
        }


        private ICollection<Tlv> ParseTLV(string input)
        {
            List<Tlv> TLVRequestlist = new List<Tlv>();
            string RequestMessageInString = input.Replace(KIOSKConstants.KioskMessageHeader, "");
            RequestMessageInString = RequestMessageInString.Remove(0, 2);

            try
            {
                int i = 0;
                while (i < RequestMessageInString.Length / 2)
                {
                    int checkLengthString = 0;
                    string checkTagString = RequestMessageInString.Substring(i * 2, ((i + 1) * 2) - (i * 2));
                    if (KIOSKTags.Taglist.Contains(checkTagString))
                    {
                        i++;
                        checkLengthString = Convert.ToInt32(RequestMessageInString.Substring(i * 2, ((i + 1) * 2) - (i * 2)), 16);
                        string[] str = new string[checkLengthString];
                        for (int j = 0; j < checkLengthString; j++)
                        {
                            i++;
                            byte[] ba = StringToByteArray(RequestMessageInString.Substring(i * 2, ((i + 1) * 2) - (i * 2)));
                            str[j] = Encoding.Default.GetString(ba);
                        }
                        TLVRequestlist.Add(new Tlv(checkTagString, checkLengthString, string.Join("", str)));
                    }
                    i++;
                }
            }
            catch
            {
                throw;
            }
            return TLVRequestlist;
        }

        private static byte[] StringToByteArray(String hex)
        {
            int NumberChars = hex.Length;
            byte[] bytes = new byte[NumberChars / 2];
            for (int i = 0; i < NumberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        /// <summary>
        /// To Build hex message which is an input to the COM port.
        /// </summary>
        /// <param name="hexString"> Hex string</param>
        /// <param name="actualLength"> Actual Message Length</param>
        /// <returns> Hex string. </returns>
        public string BuildHexMessage(string hexString, int actualLength)
        {
            string message = string.Empty;

            string messageHeader = KIOSKConstants.KioskMessageHeader;

            string messageLength = actualLength.ToString();

            message = messageHeader + messageLength + hexString;

            message = message + this.LRCCalculation(message);

            return message;
        }

        /// <summary>
        /// To calculate LRC of the input data.
        /// /// </summary>
        /// <param name="data"> input data.</param>
        /// <returns> lrc. </returns>
        private string LRCCalculation(string data)
        {
            int checksum = 0;

            if (!string.IsNullOrEmpty(data))
            {
                foreach (char c in this.GetStringFromHex(data))
                {
                    checksum ^= Convert.ToByte(c);
                }
            }

            return checksum.ToString(KIOSKConstants.HexaDecimalFormat);
        }

        /// <summary>
        /// Supporting Function used in LRC function.
        /// </summary>
        /// <param name="hexString"> hexadecimal String.</param>
        /// <returns>result string.</returns>
        private string GetStringFromHex(string hexString)
        {
            string result = string.Empty;
            string s2 = hexString.Replace(" ", string.Empty);
            for (int i = 0; i < s2.Length; i += 2)
            {
                result += Convert.ToChar(int.Parse(s2.Substring(i, 2), System.Globalization.NumberStyles.HexNumber));
            }

            return result;
        }
    }
    #endregion


}
}
