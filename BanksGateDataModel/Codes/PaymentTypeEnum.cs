namespace BanksGateDataModel.Codes
{
    public enum PaymentTypeEnum
    {
        /// <summary>
        ///     Основной.
        /// </summary>
        Main = 1,

        /// <summary>
        ///     Возвратный.
        /// </summary>
        Return = 2,

        /// <summary>
        ///     Иной.
        /// </summary>
        Other = 3,

        /// <summary>
        ///     Дополнительный.
        /// </summary>
        Additional = 4,

        /// <summary>
        ///     Погашение кредита.
        /// </summary>
        CreditReturn = 104,

        /// <summary>
        ///     Выдача кредита.
        /// </summary>
        CreditGet = 105,

        /// <summary>
        ///     Вознаграждение.
        /// </summary>
        CreditPercent = 106,

        /// <summary>
        ///     Возврат погашения кредита.
        /// </summary>
        ReturnOfCreditReturn = 114,

        /// <summary>
        ///     Возврат выдачи кредита.
        /// </summary>
        ReturnOfCreditGet = 115,

        /// <summary>
        ///     Возврат вознаграждения.
        /// </summary>
        ReturnOfCreditPercent = 116,
    }
}