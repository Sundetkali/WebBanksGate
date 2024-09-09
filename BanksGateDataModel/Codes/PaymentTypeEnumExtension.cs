using System;
using System.Collections.Generic;
using System.Linq;

namespace BanksGateDataModel.Codes
{
    public static class PaymentTypeEnumExtension
    {
        public static string[] ToCodes(this IEnumerable<PaymentTypeEnum> statuses)
        {
            return statuses.Select(r => ((int) r).ToString("000")).ToArray();
        }

        public static string ToCode(this PaymentTypeEnum status)
        {
            return ((int) status).ToString("000");
        }

        public static PaymentTypeEnum ToPaymentTypes(this string paymentTypeCode)
        {
            return (PaymentTypeEnum) Convert.ToInt32(paymentTypeCode);
        }

        public static PaymentTypeEnum[] OnReturns()
        {
            return new[]
                   {
                       PaymentTypeEnum.CreditPercent,
                       PaymentTypeEnum.ReturnOfCreditPercent,
                       PaymentTypeEnum.Other
                   };
        }

        public static PaymentTypeEnum[] OnMainOther()
        {
            return new[]
                   {
                       PaymentTypeEnum.Main,
                       PaymentTypeEnum.Other
                   };
        }
    }
}