using System.Collections.Generic;

namespace KIOSKSimulator
{
    public sealed class PurchaseResponse : TransactionResponseBase
    {

		public PurchaseResponse(IList<string> fieldValues) : base(fieldValues) { }

		public override string RequestType => POSConstants.MessageType_Purchase;


    }
}