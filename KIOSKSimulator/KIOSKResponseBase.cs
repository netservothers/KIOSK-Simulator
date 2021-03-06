using System;
using System.Collections.Generic;
using System.Text;

namespace KIOSKSimulator
{
	public abstract class KIOSKResponseBase
	{
		private readonly IList<string> _Fields;

		protected KIOSKResponseBase(IList<string> fieldValues)
		{
			_Fields = fieldValues;
		}

        protected KIOSKResponseBase()
        {
          
        }

        public abstract string RequestType { get; }

		protected IList<string> Fields { get { return _Fields; } }

		protected string FieldValueOrNull(int fieldIndex)
		{
			if (_Fields.Count > fieldIndex) return _Fields[fieldIndex];

			return null;
		}

        public enum ResponseCode
        {
            Transactioncancelled = 000,
            Brokenpipe = 001,
            InvalidFormat = 002,
            InvalidDataLength =003,
            TransactionSuccess = 100,
            InvalidDeveloperID  =900,
            MPOSNotactivated  = 901,
            LoginRequired  =902
        }
	}
}
