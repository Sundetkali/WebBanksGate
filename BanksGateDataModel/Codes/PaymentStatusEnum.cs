namespace BanksGateDataModel.Codes
{
    public enum PaymentStatusEnum
    {
        None = 0,

        /// <summary>
        /// загружен в базу
        /// </summary>
        LoadInDataBase = 1,

        /// <summary>
        /// привязан к клиенту
        /// </summary>
        LinkedWithClient = 2,

        /// <summary>
        /// запрошена дополнительная информация у клиента
        /// </summary>
        RequestInformation = 3,

        /// <summary>
        /// возврат
        /// </summary>
        Rollback = 5,

        /// <summary>
        /// принят
        /// </summary>
        Accepted = 6,

        /// <summary>
        /// комплаенс
        /// </summary>
        Compliance = 7,

        /// <summary>
        /// отклонен
        /// </summary>
        Canceled = 8,

        /// <summary>
        /// утвержден
        /// </summary>
        Approved = 9,

        /// <summary>
        /// получен финальный статус - утвержден
        /// </summary>
        ApprovedFinal = 10,

        /// <summary>
        /// получен финальный статус - отклонен
        /// </summary>
        CanceledFinal = 12,
        
        /// <summary>
        /// до выяснения
        /// </summary>
        Sundry = 4,

        /// <summary>
        /// отправлен на транзитный счет
        /// </summary>
        Transit = 13,

        /// <summary>
        /// архивный
        /// </summary>
        Archive = 11,

        /// <summary>
        /// отправленный на утверждение
        /// </summary>
        OnApprove = 14,

        /// <summary>
        /// отправленный на доработку
        /// </summary>
        OnDevelop = 15,

        /// <summary>
        /// отправленный на отклонение
        /// </summary>
        OnCancel = 16,
        
        /// <summary>
        /// получен финальный статус - удалено
        /// </summary>
        DeletedFinal = 17,

        /// <summary>
        /// получен финальный статус - возвращено
        /// </summary>
        RollbackFinal = 18,

        /// <summary>
        /// отправлен на транзитный счет (Investigation)
        /// </summary>
        TransitInvestigation = 19,
        
        /// <summary>
        /// заблокирован
        /// </summary>
        Blocked = 20,

        /// <summary>
        /// на разблокировании
        /// </summary>
        OnUnblocking = 21,

        /// <summary>
        /// не утвержден
        /// </summary>
        ManualNew = 22,

        /// <summary>
        /// утвержден
        /// </summary>
        ManualApproved = 23,

        /// <summary>
        /// на доработке
        /// </summary>
        ManualOnDevelop = 24,
        
        /// <summary>
        /// на доработке - получен финальный статус - утвержден
        /// </summary>
        ApprovedFinalManualOnDevelop = 25,
        
        /// <summary>
        /// отправленный на доработку (на транзитном счете)
        /// </summary>
        TransitOnDevelop = 26,

        /// <summary>
        /// запрошена дополнительная информация у клиента (на транзитном счете)
        /// </summary>
        TransitRequestInformation = 27,

        /// <summary>
        /// требуется подтвердить отправку на транзитный счет
        /// </summary>
        SendToTransit = 28,

        /// <summary>
        /// отправленный на утверждение (на транзитном счете)
        /// </summary>
        TransitOnApprove = 29,

        /// <summary>
        /// требуется подтвердить отправку на транзитный счет (запрошена дополнительная информация у клиента)
        /// </summary>
        SendToTransitRequestInformation = 30,
        
        /// <summary>
        /// требуется подтвердить отправку на транзитный счет (Investigation)
        /// </summary>
        SendToTransitInvestigation = 31,

        /// <summary>
        /// Удален
        /// </summary>
        Deleted = 32,

        /// <summary>
        /// Обнуление платежа, требуется подтверждение
        /// </summary>
        SetZeroPaymentOnApprove = 33,

        /// <summary>
        /// Обнуление платежа, утверждено
        /// </summary>
        SetZeroPaymentApproved = 34,

        /// <summary>
        /// Обнуление платежа, отклонено
        /// </summary>
        SetZeroPaymentCanceled = 35,

        /// <summary>
        /// отправленный на утверждение (ручные)
        /// </summary>
        ManualOnApprove = 36,

        /// <summary>
        /// отклонен - CF вернул отмену
        /// </summary>
        CancelNotAcceptedByCF = 37,

        /// <summary>
        /// отправлен на транзитный счет - CF вернул отмену
        /// </summary>
        TransitNotAcceptedByCF = 38,

        /// <summary>
        /// запрос на удаление
        /// </summary>
        PaymentRejection = 39,
        
        /// <summary>
        /// корректировка типа платежа, требуется подтверждение
        /// </summary>
        FixPaymentTypeOnApprove = 40,

        /// <summary>
        /// корректировка типа платежа подтверждено
        /// </summary>
        FixPaymentTypeApproved = 41,

        /// <summary>
        /// корректировка типа платежа отклонено
        /// </summary>
        FixPaymentTypeCanceled = 42,

        /// <summary>
        /// отправленный на утверждение - документы на скрининге
        /// </summary>
        OnApproveDocumentScreening = 43,

        /// <summary>
        /// Заблокирован по требованиям АФР
        /// </summary>
        BlockedRequirementsOfAFR = 44,

        /// <summary>
        /// Получен ответ АМЛ, на утверждении
        /// </summary>
        OnUnblockingRequirementsOfAFRHasAMLAnswer = 45,

        /// <summary>
        /// Получен ответ АМЛ, платеж разблокирован
        /// </summary>
        UnblockedRequirementsOfAFRHasAMLAnswer = 46,

        /// <summary>
        /// привязан к клиенту (отправка сообщений о входящих)
        /// </summary>
        PreviewIncoming = 47,

        /// <summary>
        /// Отправлено автоматическое уведомление в АМЛ
        /// Без блокировки.
        /// </summary>
        NoBlockSendMessageRequirementsOfAFR = 48,

        /// <summary>
        /// Проверка КНП 343 адвайзингом
        /// </summary>
        OnApproveAdvising = 49,

        /// <summary>
        /// обнуление покупки, требуется подтверждение
        /// </summary>
        SetZeroFXOnApprove = 50,

        /// <summary>
        /// обнуление покупки, подтверждено
        /// </summary>
        SetZeroFXApproved = 51,

        /// <summary>
        /// утверждено - документы на скрининге
        /// </summary>
        ApprovedDocumentScreening = 52,

        /// <summary>
        /// требуется подтвердить отправку на транзитный счет - документы на скрининге
        /// </summary>
        SendToTransitDocumentScreening = 53,

        /// <summary>
        /// требуется подтвердить отправку на транзитный счет - документы на скрининге (утверждено)
        /// </summary>
        SendToTransitApprovedDocumentScreening = 54,
        
        /// <summary>
        /// Заблокирован по требованиям Goods Pre-Check
        /// Заблокирован, отправлено сообщение на SOHO L1
        /// </summary>
        BlockedRequirementsOfGoodsPreCheck = 55,

        /// <summary>
        /// Получен ответ из SOHO L1, снятие блокировки на утверждении
        /// </summary>
        OnUnblockingRequirementsOfGoodsPreCheckHasAnswer = 56,

        /// <summary>
        /// Получен ответ из SOHO L1, платеж разблокирован
        /// </summary>
        UnblockedRequirementsOfGoodsPreCheckHasAnswer = 57,

        /// <summary>
        /// на обработке системой (на проверке авто-платежей)
        /// </summary>
        OnContractAutoPayment = 58,

        /// <summary>
        /// заблокирован, данный платеж попадает под критерий новых правил с 01.01.2024г
        /// </summary>
        BlockedPaymentFallsCriteriaNewRules = 59,

        /// <summary>
        /// Получен ответ АМЛ, на разблокировании
        /// </summary>
        OnBlockingPaymentFallsCriteriaNewRulesOnUnlocking = 60,
    }
}