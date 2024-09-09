namespace BanksGateDataModel.Codes
{
    public enum PaymentSendAMLTypeEnum
    {
        /// <summary>
        ///     По умолчанию
        /// </summary>
        Default = 0,

        /// <summary>
        ///     Отправлено в АМЛ.
        /// </summary>
        SentToAml = 1,

        /// <summary>
        ///     Не отправлен в АМЛ.
        /// </summary>
        NotSentToAml = 2,
    }
}