using System;
using System.Linq.Expressions;
using Nat.Web.Core.System.Data;

namespace CurrencyControlDataModel.Models
{
    public partial class MCC_PaymentDocumentData
    {
        [AccessFilter(AccessFilterType.SelectAndAnySelect)]
        public static Expression<Func<MCC_PaymentDocumentData, bool>> FilterByPaymentId(
            [AccessFilterParameter(nameof(FilterByPaymentId))]
            long? value)
        {
            if (value == null || value == 0)
                return r => false;

            return r => r.MCC_PaymentDocument_id.refPayment == value;
        }
    }
}