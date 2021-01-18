using System;
using System.Collections.Generic;
using System.Text;

namespace KIOSKSimulator
{
	public abstract class KIOSKRequestBase
	{
		protected POSRequestBase()
		{

		}
		public abstract string RequestType
		{
			get;
		}

        public abstract string MandatoryField
        {
            get;
        }

        public abstract string OptionalField
        {
            get;
        }

    }
}