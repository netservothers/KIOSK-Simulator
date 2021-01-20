using System;
using System.Collections.Generic;
using System.Text;

namespace KIOSKSimulator
{
    public abstract class TransactionResponseBase : KIOSKResponseBase
    {
        protected TransactionResponseBase() : base() { }

        protected TransactionResponseBase(IList<string> fieldValues) : base(fieldValues) { }

        public override string RequestType { get { return KIOSKTags.ActionCode; } }

        public decimal PurchaseAmount { get { return ToDecimalOrZero(Fields[3]); } }

        public decimal CashAmount { get { return ToDecimalOrZero(Fields[GetIndex(4)]); } }

        public string Response { get { return Fields[GetIndex(5)]; } }

        public string ApprovalCode { get { return Fields[GetIndex(5)]; } }

        public string Display { get { return Fields[GetIndex(6)]; } }

        public string BankReference { get { return Fields[GetIndex(7)]; } }

        public string Stan { get { return Fields[GetIndex(8)]; } }

        public string TruncatedPan { get { return Fields[GetIndex(9)]; } }

        public string Account { get { return Fields[GetIndex(10)]; } }

        public string MerchantReceipt { get { return FieldValueOrNull(GetIndex(11)); } }
   
        public string CustomerReceipt { get { return FieldValueOrNull(GetIndex(12)); } }

        private int GetIndex(int rawIndex)
        {
            return this.RequestType == KIOSKTags.ActionCode ? rawIndex : rawIndex - 1;
        }

        internal static decimal ToDecimalOrZero(string value)
        {
            if (Decimal.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var retVal))
                return retVal;

            return 0;
        }

    }
}
