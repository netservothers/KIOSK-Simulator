using System;
using System.Collections.Generic;
using System.Text;

namespace KIOSKSimulator
{
    public sealed class PurchaseRequest : KIOSKRequestBase
    {
		public PurchaseRequest() : base()
		{

		}
        public override string RequestType => KIOSKConstants.MessageType_Purchase;

        public override string MandatoryField => KIOSKConstants.FieldType_Amount;

        public override string OptionalField => KIOSKConstants.FieldType_AcquirerSelection;

        public decimal Amount { get; set; }

		public string Id { get; set; }

		public byte Validate(string RequestMessage)
		{
            if (RequestMessage.Substring(21, 2).ToString() == MandatoryField)
            {
                Amount = Convert.ToDecimal(RequestMessage.Substring(25, 12).ToString());
                return KIOSKConstants.ControlByte_Ack;
            }
            return KIOSKConstants.ControlByte_Nack;
        }

	}
}