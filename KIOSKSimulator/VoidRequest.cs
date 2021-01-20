using System;
using System.Collections.Generic;
using System.Text;

namespace KIOSKSimulator
{
    public sealed class VoidRequest : KIOSKRequestBase
	{
		public VoidRequest() : base()
		{

		}
		public override string RequestType
		{
			get { return KIOSKConstants.VoidRequestActionCode; }
		}

        public string MandatoryTransactionField => KIOSKTags.TransactionID;

        public string MandatoryReferenceField => KIOSKTags.ReferenceNumber;

        public string MandatoryVoidField => KIOSKTags.VoidType;

        public string TransactionID { get; set; }

        public string ReferenceNumber { get; set; }

        public string VoidType { get; set; }

        public string Id { get; set; }

        public bool Validate(List<Tlv> tLVRequestlist)
        {
            foreach (Tlv tlvField in tLVRequestlist)
            {
                TransactionID = ((tlvField.Tag == MandatoryTransactionField) && !string.IsNullOrEmpty(tlvField.Data)) ? tlvField.Data : string.Empty;
                ReferenceNumber = ((tlvField.Tag == MandatoryReferenceField) && !string.IsNullOrEmpty(tlvField.Data)) ? tlvField.Data : string.Empty;
                VoidType = ((tlvField.Tag == MandatoryVoidField) && !string.IsNullOrEmpty(tlvField.Data)) ? tlvField.Data : string.Empty;
                return true;
            }
            return false;
        }
    }
}