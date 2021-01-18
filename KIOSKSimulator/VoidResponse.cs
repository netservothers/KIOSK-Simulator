using System;
using System.Collections.Generic;
using System.Text;

namespace KIOSKSimulator
{
    public sealed class VoidResponse : KIOSKResponseBase
	{
		public VoidResponse(IList<string> fieldValues) : base(fieldValues) { }

		public override string RequestType { get { return POSConstants.MessageType_Void; } }
	}
}