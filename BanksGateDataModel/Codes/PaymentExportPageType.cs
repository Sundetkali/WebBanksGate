namespace BanksGateDataModel.Codes
{
    public enum PaymentExportPageType
    {
        /// <summary>
        ///     Все вкладки
        /// </summary>
        All,

        /// <summary>
        ///     В процессе/утвержден
        /// </summary>
        ApprovedAndInProcess,

        /// <summary>
        ///     Финальные данные
        /// </summary>
        Approved,

        /// <summary>
        ///     На отправке предварительных писем
        /// </summary>
        PreviewIncome,

        /// <summary>
        ///     Отправленные письма
        /// </summary>
        PreviewIncomeSentToClient,

        /// <summary>
        ///     Входящие за указанный период
        /// </summary>
        PreviewIncomeAll,

        /// <summary>
        ///     Платежи с проверкой goods pre-check
        /// </summary>
        GoodsPreCheck,
    }
}