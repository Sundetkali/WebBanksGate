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
    /// Сообщение - МТ102.
    /// </summary>
    public partial class MT102_TBL
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         Идентификатор.
        ///     </remarks>
        /// </summary>
        [Key]
        public Decimal id { get; set; }

        /// <summary>
        ///     ID_DOC.
        ///     <remarks>
        ///         Идентификатор документа.
        ///     </remarks>
        /// </summary>
        public Decimal? ID_DOC { get; set; }

        /// <summary>
        ///     RELATIONREFERENSE.
        ///     <remarks>
        ///         RELATIONREFERENSE.
        ///     </remarks>
        /// </summary>
        public String RELATIONREFERENSE { get; set; }

        /// <summary>
        ///     CURRENCYCODE.
        ///     <remarks>
        ///         CURRENCYCODE.
        ///     </remarks>
        /// </summary>
        public String CURRENCYCODE { get; set; }

        /// <summary>
        ///     CURRENCYAMOUNT.
        ///     <remarks>
        ///         CURRENCYAMOUNT.
        ///     </remarks>
        /// </summary>
        public String CURRENCYAMOUNT { get; set; }

        /// <summary>
        ///     CURRENCYOPERATION.
        ///     <remarks>
        ///         CURRENCYOPERATION.
        ///     </remarks>
        /// </summary>
        public String CURRENCYOPERATION { get; set; }

        /// <summary>
        ///     SENDERACCOUNT.
        ///     <remarks>
        ///         SENDERACCOUNT.
        ///     </remarks>
        /// </summary>
        public String SENDERACCOUNT { get; set; }

        /// <summary>
        ///     SENDERNAME.
        ///     <remarks>
        ///         SENDERNAME.
        ///     </remarks>
        /// </summary>
        public String SENDERNAME { get; set; }

        /// <summary>
        ///     SENDERCHIEF.
        ///     <remarks>
        ///         SENDERCHIEF.
        ///     </remarks>
        /// </summary>
        public String SENDERCHIEF { get; set; }

        /// <summary>
        ///     SENDERMAINBK.
        ///     <remarks>
        ///         SENDERMAINBK.
        ///     </remarks>
        /// </summary>
        public String SENDERMAINBK { get; set; }

        /// <summary>
        ///     SENDERRNN.
        ///     <remarks>
        ///         SENDERRNN.
        ///     </remarks>
        /// </summary>
        public String SENDERRNN { get; set; }

        /// <summary>
        ///     SENDERIRS.
        ///     <remarks>
        ///         SENDERIRS.
        ///     </remarks>
        /// </summary>
        public String SENDERIRS { get; set; }

        /// <summary>
        ///     SENDERSECO.
        ///     <remarks>
        ///         SENDERSECO.
        ///     </remarks>
        /// </summary>
        public String SENDERSECO { get; set; }

        /// <summary>
        ///     SENDERBNK.
        ///     <remarks>
        ///         SENDERBNK.
        ///     </remarks>
        /// </summary>
        public String SENDERBNK { get; set; }

        /// <summary>
        ///     BENEFBNK.
        ///     <remarks>
        ///         BENEFBNK.
        ///     </remarks>
        /// </summary>
        public String BENEFBNK { get; set; }

        /// <summary>
        ///     BENEFACCOUNT.
        ///     <remarks>
        ///         BENEFACCOUNT.
        ///     </remarks>
        /// </summary>
        public String BENEFACCOUNT { get; set; }

        /// <summary>
        ///     BENEFNAME.
        ///     <remarks>
        ///         BENEFNAME.
        ///     </remarks>
        /// </summary>
        public String BENEFNAME { get; set; }

        /// <summary>
        ///     BENEFRNN.
        ///     <remarks>
        ///         BENEFRNN.
        ///     </remarks>
        /// </summary>
        public String BENEFRNN { get; set; }

        /// <summary>
        ///     BENEFIRS.
        ///     <remarks>
        ///         BENEFIRS.
        ///     </remarks>
        /// </summary>
        public String BENEFIRS { get; set; }

        /// <summary>
        ///     BENEFSECO.
        ///     <remarks>
        ///         BENEFSECO.
        ///     </remarks>
        /// </summary>
        public String BENEFSECO { get; set; }

        /// <summary>
        ///     DOC_NUM.
        ///     <remarks>
        ///         DOC_NUM.
        ///     </remarks>
        /// </summary>
        public String DOC_NUM { get; set; }

        /// <summary>
        ///     DOC_DATE.
        ///     <remarks>
        ///         DOC_DATE.
        ///     </remarks>
        /// </summary>
        public String DOC_DATE { get; set; }

        /// <summary>
        ///     DOC_SEND.
        ///     <remarks>
        ///         DOC_SEND.
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
        ///     DOC_OPERATION.
        ///     <remarks>
        ///         DOC_OPERATION.
        ///     </remarks>
        /// </summary>
        public String DOC_OPERATION { get; set; }

        /// <summary>
        ///     DOC_SIC.
        ///     <remarks>
        ///         DOC_SIC.
        ///     </remarks>
        /// </summary>
        public String DOC_SIC { get; set; }

        /// <summary>
        ///     DOC_FM.
        ///     <remarks>
        ///         DOC_FM.
        ///     </remarks>
        /// </summary>
        public String DOC_FM { get; set; }

        /// <summary>
        ///     DOC_NM.
        ///     <remarks>
        ///         DOC_NM.
        ///     </remarks>
        /// </summary>
        public String DOC_NM { get; set; }

        /// <summary>
        ///     DOC_FT.
        ///     <remarks>
        ///         DOC_FT.
        ///     </remarks>
        /// </summary>
        public String DOC_FT { get; set; }

        /// <summary>
        ///     DOC_DT.
        ///     <remarks>
        ///         DOC_DT.
        ///     </remarks>
        /// </summary>
        public String DOC_DT { get; set; }

        /// <summary>
        ///     DOC_LA.
        ///     <remarks>
        ///         DOC_LA.
        ///     </remarks>
        /// </summary>
        public String DOC_LA { get; set; }

        /// <summary>
        ///     DOC_RNN.
        ///     <remarks>
        ///         DOC_RNN.
        ///     </remarks>
        /// </summary>
        public String DOC_RNN { get; set; }

        /// <summary>
        ///     seqlfvalue.
        ///     <remarks>
        ///         seqlfvalue.
        ///     </remarks>
        /// </summary>
        public String seqlfvalue { get; set; }

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
    }

    public partial class DataContext
    {
        /// <summary>
        /// Сообщение - МТ102.
        /// </summary>
        public DbSet<MT102_TBL> MT102_TBL { get; set; }
    }
}