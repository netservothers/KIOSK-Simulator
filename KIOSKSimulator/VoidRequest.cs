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
			get { return POSConstants.MessageType_Void; }
		}

        public override string MandatoryField => POSConstants.FieldType_InvoiceNumber;

        public override string OptionalField => POSConstants.FieldType_AcquirerSelection;

        public string InvoiceNumber { get; set; }

		public string Id { get; set; }

        public byte Validate(string RequestMessage)
        {
            if (RequestMessage.Substring(21, 2).ToString() == MandatoryField)
            {
                InvoiceNumber = RequestMessage.Substring(25, 6).ToString();
                return POSConstants.ControlByte_Ack;
            }

            return POSConstants.ControlByte_Nack;

        }
    }
}