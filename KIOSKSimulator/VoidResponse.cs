using System;
using System.Collections.Generic;
using System.Text;

namespace KIOSKSimulator
{
    public sealed class VoidResponse : KIOSKResponseBase
	{
        public VoidResponse() : base()
        {

        }

        public override string RequestType { get { return KIOSKConstants.VoidResponseActionCode; } }

        public string MandatoryActionField => KIOSKTags.ActionCode;

        public string MandatoryReferenceField => KIOSKTags.ReferenceNumber;

        public string MandatoryResponseField => KIOSKTags.ResponseCode;

        public ResponseCode ResponseCodeValue { get; set; }

        public void GetResponseCode()
        {
            ResponseCodeValue =  ResponseCode.TransactionSuccess;
        }
    }
}