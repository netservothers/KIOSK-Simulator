using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KIOSKSimulator
{
    public class KIOSKSimulator
    {
        #region Variable Declaration 
        PurchaseRequest pOSPurchaseRequest = new PurchaseRequest();
        VoidRequest voidRequest = new VoidRequest();

        public byte ControlByteAck;

        #endregion

        public KIOSKSimulator()
        {

        }

        #region Public Methods 

        public byte ProcessReadRequest(string input)
        {
            string RequestMessageInString = HextoString(input).ToString();

            if (RequestMessageInString.Substring(15, 2).ToString() == pOSPurchaseRequest.RequestType)
            {
                ControlByteAck = pOSPurchaseRequest.Validate(RequestMessageInString);

            }
            else if (RequestMessageInString.Substring(15, 2).ToString() == voidRequest.RequestType)
            {
                ControlByteAck = voidRequest.Validate(RequestMessageInString);

            }
            return ControlByteAck;

        }

        #endregion

        #region Private Methods
        private static string HextoString(string hexString)
        {

            var sb = new StringBuilder();
            for (var i = 0; i < hexString.Length; i += 2)
            {
                var hexChar = hexString.Substring(i, 2);
                sb.Append((char)Convert.ToByte(hexChar, 16));
            }
            return sb.ToString();
        }

        #endregion

    }
}
