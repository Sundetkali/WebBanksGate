namespace BanksGateDataModel.Codes
{
    public enum PaymentFeatureEnum
    {
        None = 0,

        /// <summary>
        /// Отнесен на транзитный счет
        /// </summary>
        Transit = 1,

        /// <summary>
        /// Возврат платежа
        /// </summary>
        Rollback = 2,

        /// <summary>
        /// Отнесен на счет до выяснения
        /// </summary>
        Explanation = 3
    }
}