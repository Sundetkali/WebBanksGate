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
    /// Сообщение TBL.
    /// </summary>
    public partial class MT_Messages_TBL
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         ID_MESSAGE.
        ///     </remarks>
        /// </summary>
        [Key]
        public Decimal id { get; set; }

        /// <summary>
        ///     MESSAGE_BODY.
        ///     <remarks>
        ///         MESSAGE_BODY.
        ///     </remarks>
        /// </summary>
        public String MESSAGE_BODY { get; set; }

        /// <summary>
        ///     MESSAGE_DATE.
        ///     <remarks>
        ///         MESSAGE_DATE.
        ///     </remarks>
        /// </summary>
        public String MESSAGE_DATE { get; set; }

        /// <summary>
        ///     MESSAGE_SESSION.
        ///     <remarks>
        ///         MESSAGE_SESSION.
        ///     </remarks>
        /// </summary>
        public Int16? MESSAGE_SESSION { get; set; }

        /// <summary>
        ///     MESSAGE_REFERENS.
        ///     <remarks>
        ///         MESSAGE_REFERENS.
        ///     </remarks>
        /// </summary>
        public Int32? MESSAGE_REFERENS { get; set; }

        /// <summary>
        ///     MESSAGE_NAMESUB.
        ///     <remarks>
        ///         MESSAGE_NAMESUB.
        ///     </remarks>
        /// </summary>
        public String MESSAGE_NAMESUB { get; set; }

        /// <summary>
        ///     MESSAGE_FLAGIO.
        ///     <remarks>
        ///         MESSAGE_FLAGIO.
        ///     </remarks>
        /// </summary>
        public String MESSAGE_FLAGIO { get; set; }

        /// <summary>
        ///     MESSAGE_STATE.
        ///     <remarks>
        ///         MESSAGE_STATE.
        ///     </remarks>
        /// </summary>
        public String MESSAGE_STATE { get; set; }

        /// <summary>
        ///     MESSAGE_TYPE.
        ///     <remarks>
        ///         MESSAGE_TYPE.
        ///     </remarks>
        /// </summary>
        public String MESSAGE_TYPE { get; set; }

        /// <summary>
        ///     MESSAGE_TIMEIN.
        ///     <remarks>
        ///         MESSAGE_TIMEIN.
        ///     </remarks>
        /// </summary>
        public String MESSAGE_TIMEIN { get; set; }

        /// <summary>
        ///     MESSAGE_TIMEOUT.
        ///     <remarks>
        ///         MESSAGE_TIMEOUT.
        ///     </remarks>
        /// </summary>
        public String MESSAGE_TIMEOUT { get; set; }

        /// <summary>
        ///     MESSAGE_INTERNAL_REFERENSE.
        ///     <remarks>
        ///         MESSAGE_INTERNAL_REFERENSE.
        ///     </remarks>
        /// </summary>
        public Double? MESSAGE_INTERNAL_REFERENSE { get; set; }

        /// <summary>
        ///     MESSAGE_ERROR.
        ///     <remarks>
        ///         MESSAGE_ERROR.
        ///     </remarks>
        /// </summary>
        public String MESSAGE_ERROR { get; set; }

        /// <summary>
        ///     MESSAGE_OWNER.
        ///     <remarks>
        ///         MESSAGE_OWNER.
        ///     </remarks>
        /// </summary>
        public String MESSAGE_OWNER { get; set; }

        /// <summary>
        ///     MESSAGE_PACKET.
        ///     <remarks>
        ///         MESSAGE_PACKET.
        ///     </remarks>
        /// </summary>
        public String MESSAGE_PACKET { get; set; }

        /// <summary>
        ///     M_DOC_USER.
        ///     <remarks>
        ///         M_DOC_USER.
        ///     </remarks>
        /// </summary>
        public String M_DOC_USER { get; set; }

        /// <summary>
        ///     M_DOC_NUM.
        ///     <remarks>
        ///         M_DOC_NUM.
        ///     </remarks>
        /// </summary>
        public Double? M_DOC_NUM { get; set; }

        /// <summary>
        ///     M_DOC_DATE.
        ///     <remarks>
        ///         M_DOC_DATE.
        ///     </remarks>
        /// </summary>
        public String M_DOC_DATE { get; set; }

        /// <summary>
        ///     USER_OPER_DATE.
        ///     <remarks>
        ///         USER_OPER_DATE.
        ///     </remarks>
        /// </summary>
        public String USER_OPER_DATE { get; set; }

        /// <summary>
        ///     m_message_operdate.
        ///     <remarks>
        ///         m_message_operdate.
        ///     </remarks>
        /// </summary>
        public DateTime? m_message_operdate { get; set; }

        /// <summary>
        ///     m_message_createdate.
        ///     <remarks>
        ///         m_message_createdate.
        ///     </remarks>
        /// </summary>
        public DateTime? m_message_createdate { get; set; }

        /// <summary>
        ///     m_message_authdate.
        ///     <remarks>
        ///         m_message_authdate.
        ///     </remarks>
        /// </summary>
        public DateTime? m_message_authdate { get; set; }

        /// <summary>
        ///     m_message_referense.
        ///     <remarks>
        ///         m_message_referense.
        ///     </remarks>
        /// </summary>
        public String m_message_referense { get; set; }

        /// <summary>
        ///     m_message_type.
        ///     <remarks>
        ///         m_message_type.
        ///     </remarks>
        /// </summary>
        public Int32? m_message_type { get; set; }

        /// <summary>
        ///     m_message_subtype.
        ///     <remarks>
        ///         m_message_subtype.
        ///     </remarks>
        /// </summary>
        public Int32? m_message_subtype { get; set; }

        /// <summary>
        ///     m_message_owner.
        ///     <remarks>
        ///         m_message_owner.
        ///     </remarks>
        /// </summary>
        public String m_message_owner { get; set; }

        /// <summary>
        ///     m_message_auth.
        ///     <remarks>
        ///         m_message_auth.
        ///     </remarks>
        /// </summary>
        public String m_message_auth { get; set; }

        /// <summary>
        ///     message_systemcomment.
        ///     <remarks>
        ///         message_systemcomment.
        ///     </remarks>
        /// </summary>
        public String message_systemcomment { get; set; }

        /// <summary>
        ///     m_message_rcx.
        ///     <remarks>
        ///         m_message_rcx.
        ///     </remarks>
        ///     True - Да
        ///     False - Нет
        /// </summary>
        public Boolean? m_message_rcx { get; set; }

        /// <summary>
        ///     messageDocumentReferense.
        ///     <remarks>
        ///         messageDocumentReferense.
        ///     </remarks>
        /// </summary>
        public String messageDocumentReferense { get; set; }

        /// <summary>
        ///     psstScreening.
        ///     <remarks>
        ///         psstScreening.
        ///     </remarks>
        /// </summary>
        public Int32? psstScreening { get; set; }

        /// <summary>
        ///     operDate.
        ///     <remarks>
        ///         operDate.
        ///     </remarks>
        /// </summary>
        public DateTime? operDate { get; set; }

        /// <summary>
        ///     rcxREF.
        ///     <remarks>
        ///         rcxREF.
        ///     </remarks>
        /// </summary>
        public String rcxREF { get; set; }

        /// <summary>
        ///     restApiId.
        ///     <remarks>
        ///         restApiId.
        ///     </remarks>
        /// </summary>
        public Int32? restApiId { get; set; }

        /// <summary>
        ///     psstId.
        ///     <remarks>
        ///         psstId.
        ///     </remarks>
        /// </summary>
        public String psstId { get; set; }

        /// <summary>
        ///     externalSystemId.
        ///     <remarks>
        ///         externalSystemId.
        ///     </remarks>
        /// </summary>
        public String externalSystemId { get; set; }

        /// <summary>
        ///     externalState.
        ///     <remarks>
        ///         externalState.
        ///     </remarks>
        /// </summary>
        public Byte? externalState { get; set; }

        /// <summary>
        ///     rcxUNIQUEREF.
        ///     <remarks>
        ///         rcxUNIQUEREF.
        ///     </remarks>
        /// </summary>
        public String rcxUNIQUEREF { get; set; }

        /// <summary>
        ///     reconciliationExported.
        ///     <remarks>
        ///         reconciliationExported.
        ///     </remarks>
        ///     True - Да
        ///     False - Нет
        /// </summary>
        public Boolean? reconciliationExported { get; set; }

        /// <summary>
        ///     maker.
        ///     <remarks>
        ///         maker.
        ///     </remarks>
        /// </summary>
        public String maker { get; set; }

        /// <summary>
        ///     checker.
        ///     <remarks>
        ///         checker.
        ///     </remarks>
        /// </summary>
        public String checker { get; set; }

        /// <summary>
        ///     isRtrn.
        ///     <remarks>
        ///         isRtrn.
        ///     </remarks>
        /// </summary>
        public Decimal? isRtrn { get; set; }

        /// <summary>
        ///     rtrnOrgId.
        ///     <remarks>
        ///         rtrnOrgId.
        ///     </remarks>
        /// </summary>
        public Decimal? rtrnOrgId { get; set; }

        /// <summary>
        ///     rtrnOrgSts.
        ///     <remarks>
        ///         rtrnOrgSts.
        ///     </remarks>
        /// </summary>
        public String rtrnOrgSts { get; set; }
    }

    public partial class DataContext
    {
        /// <summary>
        /// Сообщение TBL.
        /// </summary>
        public DbSet<MT_Messages_TBL> MT_Messages_TBL { get; set; }
    }
}