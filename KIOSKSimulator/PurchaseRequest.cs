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
        public override string RequestType => KIOSKConstants.SaleRequestActionCode;

        public string MandatoryAmountField => KIOSKTags.Amount;

        public string MandatoryReferenceField => KIOSKTags.ReferenceNumber;

        public string MandatoryPaymentField => KIOSKTags.PaymentType;

        public decimal Amount { get; set; }

        public string ReferenceNumber { get; set; }

        public string PaymentType { get; set; }

        public string Id { get; set; }

        public bool Validate(List<Tlv> tLVRequestlist)
        {
            foreach (Tlv tlvField in tLVRequestlist)
            {
               Amount = ((tlvField.Tag == MandatoryAmountField) && !string.IsNullOrEmpty(tlvField.Data))?Convert.ToDecimal(tlvField.Data) : 0;
               ReferenceNumber = ((tlvField.Tag == MandatoryReferenceField) && !string.IsNullOrEmpty(tlvField.Data)) ? tlvField.Data : string.Empty;
               PaymentType = ((tlvField.Tag == MandatoryPaymentField) && !string.IsNullOrEmpty(tlvField.Data)) ? tlvField.Data : string.Empty;
                return true;
            }
            return false;
        }

    }
}