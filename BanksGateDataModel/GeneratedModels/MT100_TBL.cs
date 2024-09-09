namespace BanksGateDataModel.Models
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.ComponentModel.DataAnnotations;
    using global::System.ComponentModel.DataAnnotations.Schema;
    using global::System.Xml.Linq;
    using global::System.Data.Entity;
    using Nat.Web.Core.System.ModelAnnotations;

    /// <summary>
    /// Сообщение - МТ100.
    /// </summary>
    public partial class MT100_TBL
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         Иденитфикатор документа.
        ///     </remarks>
        /// </summary>
        [Key]
        public Int64 id { get; set; }

        /// <summary>
        ///     ID_MESSAGE.
        ///     <remarks>
        ///         Идентификатор собщение.
        ///     </remarks>
        /// </summary>
        public Decimal? ID_MESSAGE { get; set; }

        /// <summary>
        ///     DOC_REFERENCE.
        ///     <remarks>
        ///         Ссылка на документ.
        ///     </remarks>
        /// </summary>
        public String DOC_REFERENCE { get; set; }

        /// <summary>
        ///     DOC_PAYADD.
        ///     <remarks>
        ///         DOC_PAYADD.
        ///     </remarks>
        /// </summary>
        public String DOC_PAYADD { get; set; }

        /// <summary>
        ///     DOC_PAYCODE.
        ///     <remarks>
        ///         DOC_PAYCODE.
        ///     </remarks>
        /// </summary>
        public String DOC_PAYCODE { get; set; }

        /// <summary>
        ///     DOC_OPERATION.
        ///     <remarks>
        ///         Операция документа.
        ///     </remarks>
        /// </summary>
        public String DOC_OPERATION { get; set; }

        /// <summary>
        ///     DOC_INITIATORACCOUNT.
        ///     <remarks>
        ///         DOC_INITIATORACCOUNT.
        ///     </remarks>
        /// </summary>
        public String DOC_INITIATORACCOUNT { get; set; }

        /// <summary>
        ///     DOC_INITIATORRNN.
        ///     <remarks>
        ///         DOC_INITIATORRNN.
        ///     </remarks>
        /// </summary>
        public String DOC_INITIATORRNN { get; set; }

        /// <summary>
        ///     DOC_INITIATORCHIEF.
        ///     <remarks>
        ///         DOC_INITIATORCHIEF.
        ///     </remarks>
        /// </summary>
        public String DOC_INITIATORCHIEF { get; set; }

        /// <summary>
        ///     DOC_INITIATORMAINBK.
        ///     <remarks>
        ///         DOC_INITIATORMAINBK.
        ///     </remarks>
        /// </summary>
        public String DOC_INITIATORMAINBK { get; set; }

        /// <summary>
        ///     DOC_INITIATORNAME.
        ///     <remarks>
        ///         DOC_INITIATORNAME.
        ///     </remarks>
        /// </summary>
        public String DOC_INITIATORNAME { get; set; }

        /// <summary>
        ///     DOC_INITIATORIRS.
        ///     <remarks>
        ///         DOC_INITIATORIRS.
        ///     </remarks>
        /// </summary>
        public String DOC_INITIATORIRS { get; set; }

        /// <summary>
        ///     DOC_INITIATORSECO.
        ///     <remarks>
        ///         DOC_INITIATORSECO.
        ///     </remarks>
        /// </summary>
        public String DOC_INITIATORSECO { get; set; }

        /// <summary>
        ///     DOC_INITIATORBNK.
        ///     <remarks>
        ///         DOC_INITIATORBNK.
        ///     </remarks>
        /// </summary>
        public String DOC_INITIATORBNK { get; set; }

        /// <summary>
        ///     DOC_INITIATORCORRBBNK.
        ///     <remarks>
        ///         DOC_INITIATORCORRBBNK.
        ///     </remarks>
        /// </summary>
        public String DOC_INITIATORCORRBBNK { get; set; }

        /// <summary>
        ///     DOC_INITIATORCORRACCOUNT.
        ///     <remarks>
        ///         DOC_INITIATORCORRACCOUNT.
        ///     </remarks>
        /// </summary>
        public String DOC_INITIATORCORRACCOUNT { get; set; }

        /// <summary>
        ///     DOC_BENEFCORRRBNK.
        ///     <remarks>
        ///         DOC_BENEFCORRRBNK.
        ///     </remarks>
        /// </summary>
        public String DOC_BENEFCORRRBNK { get; set; }

        /// <summary>
        ///     DOC_BENEFCORRACCOUNT.
        ///     <remarks>
        ///         DOC_BENEFCORRACCOUNT.
        ///     </remarks>
        /// </summary>
        public String DOC_BENEFCORRACCOUNT { get; set; }

        /// <summary>
        ///     DOC_BENEFBNK.
        ///     <remarks>
        ///         DOC_BENEFBNK.
        ///     </remarks>
        /// </summary>
        public String DOC_BENEFBNK { get; set; }

        /// <summary>
        ///     DOC_BENEFACCOUNT.
        ///     <remarks>
        ///         DOC_BENEFACCOUNT.
        ///     </remarks>
        /// </summary>
        public String DOC_BENEFACCOUNT { get; set; }

        /// <summary>
        ///     DOC_BENEFRNN.
        ///     <remarks>
        ///         DOC_BENEFRNN.
        ///     </remarks>
        /// </summary>
        public String DOC_BENEFRNN { get; set; }

        /// <summary>
        ///     DOC_BENEFNAME.
        ///     <remarks>
        ///         DOC_BENEFNAME.
        ///     </remarks>
        /// </summary>
        public String DOC_BENEFNAME { get; set; }

        /// <summary>
        ///     DOC_BENEFIRS.
        ///     <remarks>
        ///         DOC_BENEFIRS.
        ///     </remarks>
        /// </summary>
        public String DOC_BENEFIRS { get; set; }

        /// <summary>
        ///     DOC_BENEFSECO.
        ///     <remarks>
        ///         DOC_BENEFSECO.
        ///     </remarks>
        /// </summary>
        public String DOC_BENEFSECO { get; set; }

        /// <summary>
        ///     DOC_NUM.
        ///     <remarks>
        ///         Номер документа.
        ///     </remarks>
        /// </summary>
        public String DOC_NUM { get; set; }

        /// <summary>
        ///     DOC_DATE.
        ///     <remarks>
        ///         Дата документа.
        ///     </remarks>
        /// </summary>
        public String DOC_DATE { get; set; }

        /// <summary>
        ///     DOC_SEND.
        ///     <remarks>
        ///         Отправить документ.
        ///     </remarks>
        /// </summary>
        public String DOC_SEND { get; set; }

        /// <summary>
        ///     DOC_VO.
        ///     <remarks>
        ///         DOC_VO.
        ///     </remarks>
        /// </summary>
        public String DOC_VO { get; set; }

        /// <summary>
        ///     DOC_PSO.
        ///     <remarks>
        ///         DOC_PSO.
        ///     </remarks>
        /// </summary>
        public String DOC_PSO { get; set; }

        /// <summary>
        ///     DOC_KNP.
        ///     <remarks>
        ///         DOC_KNP.
        ///     </remarks>
        /// </summary>
        public String DOC_KNP { get; set; }

        /// <summary>
        ///     DOC_BCLASS.
        ///     <remarks>
        ///         DOC_BCLASS.
        ///     </remarks>
        /// </summary>
        public String DOC_BCLASS { get; set; }

        /// <summary>
        ///     DOC_PRT.
        ///     <remarks>
        ///         DOC_PRT.
        ///     </remarks>
        /// </summary>
        public String DOC_PRT { get; set; }

        /// <summary>
        ///     DOC_SIM.
        ///     <remarks>
        ///         DOC_SIM.
        ///     </remarks>
        /// </summary>
        public String DOC_SIM { get; set; }

        /// <summary>
        ///     DOC_ASSIGN.
        ///     <remarks>
        ///         DOC_ASSIGN.
        ///     </remarks>
        /// </summary>
        public String DOC_ASSIGN { get; set; }

        /// <summary>
        ///     DOC_ADD.
        ///     <remarks>
        ///         Добавить документ.
        ///     </remarks>
        /// </summary>
        public String DOC_ADD { get; set; }

        /// <summary>
        ///     DOC_PAYAMOUNT.
        ///     <remarks>
        ///         DOC_PAYAMOUNT.
        ///     </remarks>
        /// </summary>
        public String DOC_PAYAMOUNT { get; set; }

        /// <summary>
        ///     DOC_RELATIONREFERENSE.
        ///     <remarks>
        ///         DOC_RELATIONREFERENSE.
        ///     </remarks>
        /// </summary>
        public String DOC_RELATIONREFERENSE { get; set; }

        /// <summary>
        ///     DOC_PRINTED.
        ///     <remarks>
        ///         DOC_PRINTED.
        ///     </remarks>
        /// </summary>
        public Int32? DOC_PRINTED { get; set; }

        /// <summary>
        ///     lfvalue.
        ///     <remarks>
        ///         lfvalue.
        ///     </remarks>
        /// </summary>
        public String lfvalue { get; set; }

        /// <summary>
        ///     PSTATE.
        ///     <remarks>
        ///         PSTATE.
        ///     </remarks>
        ///     True - Да
        ///     False - Нет
        /// </summary>
        public Boolean? PSTATE { get; set; }

        /// <summary>
        ///     DOC_INITIATORIDN.
        ///     <remarks>
        ///         DOC_INITIATORIDN.
        ///     </remarks>
        /// </summary>
        public String DOC_INITIATORIDN { get; set; }

        /// <summary>
        ///     DOC_BENEFIDN.
        ///     <remarks>
        ///         DOC_BENEFIDN.
        ///     </remarks>
        /// </summary>
        public String DOC_BENEFIDN { get; set; }

        /// <summary>
        ///     COMMON_DOC_TYPE.
        ///     <remarks>
        ///         COMMON_DOC_TYPE.
        ///     </remarks>
        /// </summary>
        public Int32? COMMON_DOC_TYPE { get; set; }

        /// <summary>
        ///     isENTERPRISEWAGE.
        ///     <remarks>
        ///         isENTERPRISEWAGE.
        ///     </remarks>
        /// </summary>
        public Int32? isENTERPRISEWAGE { get; set; }

        /// <summary>
        ///     paymentType.
        ///     <remarks>
        ///         paymentType.
        ///     </remarks>
        /// </summary>
        public Int32 paymentType { get; set; }

        /// <summary>
        ///     crossCurrencyCode.
        ///     <remarks>
        ///         crossCurrencyCode.
        ///     </remarks>
        /// </summary>
        public String crossCurrencyCode { get; set; }

        /// <summary>
        ///     crossCurrencyAmount.
        ///     <remarks>
        ///         crossCurrencyAmount.
        ///     </remarks>
        /// </summary>
        public Decimal? crossCurrencyAmount { get; set; }

        /// <summary>
        ///     crossExchange.
        ///     <remarks>
        ///         crossExchange.
        ///     </remarks>
        /// </summary>
        public Decimal? crossExchange { get; set; }

        /// <summary>
        ///     crossSenderCountry.
        ///     <remarks>
        ///         crossSenderCountry.
        ///     </remarks>
        /// </summary>
        public String crossSenderCountry { get; set; }

        /// <summary>
        ///     crossPayeeCountry.
        ///     <remarks>
        ///         crossPayeeCountry.
        ///     </remarks>
        /// </summary>
        public String crossPayeeCountry { get; set; }

        /// <summary>
        ///     crossChargeCost.
        ///     <remarks>
        ///         crossChargeCost.
        ///     </remarks>
        /// </summary>
        public String crossChargeCost { get; set; }

        /// <summary>
        ///     doc_type.
        ///     <remarks>
        ///         doc_type.
        ///     </remarks>
        /// </summary>
        public Int32? doc_type { get; set; }

        /// <summary>
        ///     operDate.
        ///     <remarks>
        ///         operDate.
        ///     </remarks>
        /// </summary>
        public DateTime? operDate { get; set; }

        /// <summary>
        ///     psstView.
        ///     <remarks>
        ///         psstView.
        ///     </remarks>
        /// </summary>
        public Int32? psstView { get; set; }

        /// <summary>
        ///     senderPhone.
        ///     <remarks>
        ///         senderPhone.
        ///     </remarks>
        /// </summary>
        public String senderPhone { get; set; }

        /// <summary>
        ///     addresseePhone.
        ///     <remarks>
        ///         addresseePhone.
        ///     </remarks>
        /// </summary>
        public String addresseePhone { get; set; }

        /// <summary>
        ///     payPriority.
        ///     <remarks>
        ///         payPriority.
        ///     </remarks>
        ///     True - Да
        ///     False - Нет
        /// </summary>
        public Boolean? payPriority { get; set; }

        /// <summary>
        ///     isUseLimit.
        ///     <remarks>
        ///         isUseLimit.
        ///     </remarks>
        ///     True - Да
        ///     False - Нет
        /// </summary>
        public Boolean? isUseLimit { get; set; }

        /// <summary>
        ///     REFlimitId.
        ///     <remarks>
        ///         REFlimitId.
        ///     </remarks>
        /// </summary>
        public Int64? REFlimitId { get; set; }
    }

    public partial class DataContext
    {
        /// <summary>
        /// Сообщение - МТ100.
        /// </summary>
        public DbSet<MT100_TBL> MT100_TBL { get; set; }
    }
}