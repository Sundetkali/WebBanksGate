namespace Dictionaries.Areas.DIC.ViewModels
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.ComponentModel.DataAnnotations;
    using global::System.Globalization;
    using global::System.Linq;
    using global::System.Linq.Expressions;
    using global::System.Xml.Linq;
    using Newtonsoft.Json;

    using Dictionaries.Areas.DIC.GeneratedResources;
    using BanksGateDataModel.Models;
    using Nat.Web.Core.Resources;
    using Nat.Web.Core.System.Annotations;
    using Nat.Web.Core.System.Data;
    using Nat.Web.Core.System.Data.Extensions;
    using Nat.Web.Core.System.EventLog;
    using Nat.Web.Core.System.Extensions;
    using Nat.Web.Core.System.Linq;
    using Nat.Web.Core.System.ViewModelAnnotations;
    using Nat.Web.Core.System.ViewModels;
    using Nat.Web.Core.System.Extensions.EF;
    using global::System.Web;
    using global::System.Web.Mvc;
    using HttpContext = global::System.Web.HttpContextBase;
    /// <summary>
    ///     MT_Messages_TBL. Представление таблицы MT_Messages_TBL (MT_Messages_TBL).
    ///     <remarks>
    ///         Сообщение TBL.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Сообщение TBL")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICMT_Messages_TBL", Title = "Сообщение TBL")][EventLogGroupAttribute(ParentCode = "DICMT_Messages_TBL")]
    public partial class MT_Messages_TBLViewModel : IViewModelUpdate<DataContext, MT_Messages_TBLViewModel, MT_Messages_TBL>, IViewModelCreate<DataContext, MT_Messages_TBLViewModel, MT_Messages_TBL>, IViewModelDestroy<DataContext, MT_Messages_TBLViewModel, MT_Messages_TBL>, IViewModelLogMessage<DataContext>
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         ID_MESSAGE.
        ///     </remarks>
        /// </summary>
        [ScaffoldColumn(false)]
        [UIHint("Decimal")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        [RangeDecimal("-999999999999999999", "999999999999999999",
            ErrorMessageResourceType = typeof(ValidationResources), 
            ErrorMessageResourceName = nameof(ValidationResources.RangeAttribute_ValidationError))]
        public Decimal id { get; set; }

        /// <summary>
        ///     MESSAGE_BODY.
        ///     <remarks>
        ///         MESSAGE_BODY.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_BODY__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_BODY__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        public String MESSAGE_BODY { get; set; }

        /// <summary>
        ///     MESSAGE_DATE.
        ///     <remarks>
        ///         MESSAGE_DATE.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_DATE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_DATE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(6, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String MESSAGE_DATE { get; set; }

        /// <summary>
        ///     MESSAGE_SESSION.
        ///     <remarks>
        ///         MESSAGE_SESSION.
        ///     </remarks>
        /// </summary>
        [UIHint("Int16")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_SESSION__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_SESSION__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        public Int16? MESSAGE_SESSION { get; set; }

        /// <summary>
        ///     MESSAGE_REFERENS.
        ///     <remarks>
        ///         MESSAGE_REFERENS.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_REFERENS__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_REFERENS__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        public Int32? MESSAGE_REFERENS { get; set; }

        /// <summary>
        ///     MESSAGE_NAMESUB.
        ///     <remarks>
        ///         MESSAGE_NAMESUB.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_NAMESUB__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_NAMESUB__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(8, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String MESSAGE_NAMESUB { get; set; }

        /// <summary>
        ///     MESSAGE_FLAGIO.
        ///     <remarks>
        ///         MESSAGE_FLAGIO.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_FLAGIO__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_FLAGIO__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(2, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String MESSAGE_FLAGIO { get; set; }

        /// <summary>
        ///     MESSAGE_STATE.
        ///     <remarks>
        ///         MESSAGE_STATE.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_STATE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_STATE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(4, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String MESSAGE_STATE { get; set; }

        /// <summary>
        ///     MESSAGE_TYPE.
        ///     <remarks>
        ///         MESSAGE_TYPE.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_TYPE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_TYPE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String MESSAGE_TYPE { get; set; }

        /// <summary>
        ///     MESSAGE_TIMEIN.
        ///     <remarks>
        ///         MESSAGE_TIMEIN.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_TIMEIN__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_TIMEIN__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(17, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String MESSAGE_TIMEIN { get; set; }

        /// <summary>
        ///     MESSAGE_TIMEOUT.
        ///     <remarks>
        ///         MESSAGE_TIMEOUT.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_TIMEOUT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_TIMEOUT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(17, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String MESSAGE_TIMEOUT { get; set; }

        /// <summary>
        ///     MESSAGE_INTERNAL_REFERENSE.
        ///     <remarks>
        ///         MESSAGE_INTERNAL_REFERENSE.
        ///     </remarks>
        /// </summary>
        [UIHint("Number")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_INTERNAL_REFERENSE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_INTERNAL_REFERENSE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        public Double? MESSAGE_INTERNAL_REFERENSE { get; set; }

        /// <summary>
        ///     MESSAGE_ERROR.
        ///     <remarks>
        ///         MESSAGE_ERROR.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_ERROR__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_ERROR__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String MESSAGE_ERROR { get; set; }

        /// <summary>
        ///     MESSAGE_OWNER.
        ///     <remarks>
        ///         MESSAGE_OWNER.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_OWNER__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_OWNER__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(16, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String MESSAGE_OWNER { get; set; }

        /// <summary>
        ///     MESSAGE_PACKET.
        ///     <remarks>
        ///         MESSAGE_PACKET.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_PACKET__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.MESSAGE_PACKET__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(36, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String MESSAGE_PACKET { get; set; }

        /// <summary>
        ///     M_DOC_USER.
        ///     <remarks>
        ///         M_DOC_USER.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.M_DOC_USER__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.M_DOC_USER__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(128, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String M_DOC_USER { get; set; }

        /// <summary>
        ///     M_DOC_NUM.
        ///     <remarks>
        ///         M_DOC_NUM.
        ///     </remarks>
        /// </summary>
        [UIHint("Number")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.M_DOC_NUM__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.M_DOC_NUM__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        public Double? M_DOC_NUM { get; set; }

        /// <summary>
        ///     M_DOC_DATE.
        ///     <remarks>
        ///         M_DOC_DATE.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.M_DOC_DATE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.M_DOC_DATE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(6, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String M_DOC_DATE { get; set; }

        /// <summary>
        ///     USER_OPER_DATE.
        ///     <remarks>
        ///         USER_OPER_DATE.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.USER_OPER_DATE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.USER_OPER_DATE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(32, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String USER_OPER_DATE { get; set; }

        /// <summary>
        ///     m_message_operdate.
        ///     <remarks>
        ///         m_message_operdate.
        ///     </remarks>
        /// </summary>
        [UIHint("DateTime")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_operdate__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_operdate__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        public DateTime? m_message_operdate { get; set; }

        /// <summary>
        ///     m_message_createdate.
        ///     <remarks>
        ///         m_message_createdate.
        ///     </remarks>
        /// </summary>
        [UIHint("DateTime")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_createdate__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_createdate__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        [DataType(DataType.DateTime)]
        public DateTime? m_message_createdate { get; set; }

        /// <summary>
        ///     m_message_authdate.
        ///     <remarks>
        ///         m_message_authdate.
        ///     </remarks>
        /// </summary>
        [UIHint("DateTime")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_authdate__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_authdate__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        [DataType(DataType.DateTime)]
        public DateTime? m_message_authdate { get; set; }

        /// <summary>
        ///     m_message_referense.
        ///     <remarks>
        ///         m_message_referense.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_referense__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_referense__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(16, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String m_message_referense { get; set; }

        /// <summary>
        ///     m_message_type.
        ///     <remarks>
        ///         m_message_type.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_type__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_type__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        public Int32? m_message_type { get; set; }

        /// <summary>
        ///     m_message_subtype.
        ///     <remarks>
        ///         m_message_subtype.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_subtype__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_subtype__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        public Int32? m_message_subtype { get; set; }

        /// <summary>
        ///     m_message_owner.
        ///     <remarks>
        ///         m_message_owner.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_owner__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_owner__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(32, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String m_message_owner { get; set; }

        /// <summary>
        ///     m_message_auth.
        ///     <remarks>
        ///         m_message_auth.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_auth__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_auth__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(32, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String m_message_auth { get; set; }

        /// <summary>
        ///     message_systemcomment.
        ///     <remarks>
        ///         message_systemcomment.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.message_systemcomment__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.message_systemcomment__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(128, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String message_systemcomment { get; set; }

        /// <summary>
        ///     m_message_rcx.
        ///     <remarks>
        ///         m_message_rcx.
        ///     </remarks>
        /// </summary>
        [UIHint("Boolean")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_rcx__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_rcx__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [DisplayExtended(ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources), BooleanTextTrue = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_rcx__TrueText), BooleanTextFalse = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.m_message_rcx__FalseText))]
        public Boolean? m_message_rcx { get; set; }

        /// <summary>
        ///     messageDocumentReferense.
        ///     <remarks>
        ///         messageDocumentReferense.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.messageDocumentReferense__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.messageDocumentReferense__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(16, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String messageDocumentReferense { get; set; }

        /// <summary>
        ///     psstScreening.
        ///     <remarks>
        ///         psstScreening.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.psstScreening__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.psstScreening__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        public Int32? psstScreening { get; set; }

        /// <summary>
        ///     operDate.
        ///     <remarks>
        ///         operDate.
        ///     </remarks>
        /// </summary>
        [UIHint("DateTime")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.operDate__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.operDate__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        public DateTime? operDate { get; set; }

        /// <summary>
        ///     rcxREF.
        ///     <remarks>
        ///         rcxREF.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.rcxREF__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.rcxREF__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(128, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String rcxREF { get; set; }

        /// <summary>
        ///     restApiId.
        ///     <remarks>
        ///         restApiId.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.restApiId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.restApiId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        public Int32? restApiId { get; set; }

        /// <summary>
        ///     psstId.
        ///     <remarks>
        ///         psstId.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.psstId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.psstId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(32, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String psstId { get; set; }

        /// <summary>
        ///     externalSystemId.
        ///     <remarks>
        ///         externalSystemId.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.externalSystemId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.externalSystemId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(32, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String externalSystemId { get; set; }

        /// <summary>
        ///     externalState.
        ///     <remarks>
        ///         externalState.
        ///     </remarks>
        /// </summary>
        [UIHint("Byte")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.externalState__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.externalState__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        public Byte? externalState { get; set; }

        /// <summary>
        ///     rcxUNIQUEREF.
        ///     <remarks>
        ///         rcxUNIQUEREF.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.rcxUNIQUEREF__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.rcxUNIQUEREF__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(32, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String rcxUNIQUEREF { get; set; }

        /// <summary>
        ///     reconciliationExported.
        ///     <remarks>
        ///         reconciliationExported.
        ///     </remarks>
        /// </summary>
        [UIHint("Boolean")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.reconciliationExported__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.reconciliationExported__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [DisplayExtended(ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources), BooleanTextTrue = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.reconciliationExported__TrueText), BooleanTextFalse = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.reconciliationExported__FalseText))]
        public Boolean? reconciliationExported { get; set; }

        /// <summary>
        ///     maker.
        ///     <remarks>
        ///         maker.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.maker__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.maker__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(32, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String maker { get; set; }

        /// <summary>
        ///     checker.
        ///     <remarks>
        ///         checker.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.checker__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.checker__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(32, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String checker { get; set; }

        /// <summary>
        ///     isRtrn.
        ///     <remarks>
        ///         isRtrn.
        ///     </remarks>
        /// </summary>
        [UIHint("Decimal")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.isRtrn__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.isRtrn__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [RangeDecimal("-999999999999999999", "999999999999999999",
            ErrorMessageResourceType = typeof(ValidationResources), 
            ErrorMessageResourceName = nameof(ValidationResources.RangeAttribute_ValidationError))]
        public Decimal? isRtrn { get; set; }

        /// <summary>
        ///     rtrnOrgId.
        ///     <remarks>
        ///         rtrnOrgId.
        ///     </remarks>
        /// </summary>
        [UIHint("Decimal")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.rtrnOrgId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.rtrnOrgId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [RangeDecimal("-999999999999999999", "999999999999999999",
            ErrorMessageResourceType = typeof(ValidationResources), 
            ErrorMessageResourceName = nameof(ValidationResources.RangeAttribute_ValidationError))]
        public Decimal? rtrnOrgId { get; set; }

        /// <summary>
        ///     rtrnOrgSts.
        ///     <remarks>
        ///         rtrnOrgSts.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.rtrnOrgSts__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.rtrnOrgSts__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [StringLength(4, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String rtrnOrgSts { get; set; }


        internal Dictionary<string, string> AccessFilterQueryParameters { get; set; }

        public static Expression<Func<MT_Messages_TBL, MT_Messages_TBLViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<MT_Messages_TBL, MT_Messages_TBLViewModel>> viewModel =
                r => new MT_Messages_TBLViewModel
                        {
                            id = r.id,
                            MESSAGE_BODY = r.MESSAGE_BODY,
                            MESSAGE_DATE = r.MESSAGE_DATE,
                            MESSAGE_SESSION = r.MESSAGE_SESSION,
                            MESSAGE_REFERENS = r.MESSAGE_REFERENS,
                            MESSAGE_NAMESUB = r.MESSAGE_NAMESUB,
                            MESSAGE_FLAGIO = r.MESSAGE_FLAGIO,
                            MESSAGE_STATE = r.MESSAGE_STATE,
                            MESSAGE_TYPE = r.MESSAGE_TYPE,
                            MESSAGE_TIMEIN = r.MESSAGE_TIMEIN,
                            MESSAGE_TIMEOUT = r.MESSAGE_TIMEOUT,
                            MESSAGE_INTERNAL_REFERENSE = r.MESSAGE_INTERNAL_REFERENSE,
                            MESSAGE_ERROR = r.MESSAGE_ERROR,
                            MESSAGE_OWNER = r.MESSAGE_OWNER,
                            MESSAGE_PACKET = r.MESSAGE_PACKET,
                            M_DOC_USER = r.M_DOC_USER,
                            M_DOC_NUM = r.M_DOC_NUM,
                            M_DOC_DATE = r.M_DOC_DATE,
                            USER_OPER_DATE = r.USER_OPER_DATE,
                            m_message_operdate = r.m_message_operdate,
                            m_message_createdate = r.m_message_createdate,
                            m_message_authdate = r.m_message_authdate,
                            m_message_referense = r.m_message_referense,
                            m_message_type = r.m_message_type,
                            m_message_subtype = r.m_message_subtype,
                            m_message_owner = r.m_message_owner,
                            m_message_auth = r.m_message_auth,
                            message_systemcomment = r.message_systemcomment,
                            m_message_rcx = r.m_message_rcx,
                            messageDocumentReferense = r.messageDocumentReferense,
                            psstScreening = r.psstScreening,
                            operDate = r.operDate,
                            rcxREF = r.rcxREF,
                            restApiId = r.restApiId,
                            psstId = r.psstId,
                            externalSystemId = r.externalSystemId,
                            externalState = r.externalState,
                            rcxUNIQUEREF = r.rcxUNIQUEREF,
                            reconciliationExported = r.reconciliationExported,
                            maker = r.maker,
                            checker = r.checker,
                            isRtrn = r.isRtrn,
                            rtrnOrgId = r.rtrnOrgId,
                            rtrnOrgSts = r.rtrnOrgSts
                        };
        
            var builder = viewModel.ToBuilder(dbContext, httpContext);
            builder.AddAccessResult(r => r.CanDestroy, AccessFilterType.Delete, httpContext);
            builder.AddAccessResult(r => r.CanUpdate, AccessFilterType.Edit, httpContext);
            return builder.ToExpression();
        }
        
        partial void OnCreateOrUpdate(MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreateOrUpdate(MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(MT_Messages_TBLViewModel newViewModel, MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(MT_Messages_TBLViewModel newViewModel, MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreate(MT_Messages_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreate(MT_Messages_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool cancel);
        partial void OnCreated(MT_Messages_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreated(MT_Messages_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreated(MT_Messages_TBLViewModel newViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreated(MT_Messages_TBLViewModel newViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedLog(MT_Messages_TBLViewModel newViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller, ref string typeCode);
        partial void OnAllowCreate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public MT_Messages_TBLViewModel Create(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<MT_Messages_TBL, DataContext, Controller> onCreate = null)
        {
            var allowCreate = true;
            OnAllowCreate(ref allowCreate, dbContext, controller, eventLogManager);
            if (!allowCreate) return this;
            
            var item = new MT_Messages_TBL();
            item.id = this.id;
            item.MESSAGE_BODY = this.MESSAGE_BODY;
            item.MESSAGE_DATE = this.MESSAGE_DATE;
            item.MESSAGE_SESSION = this.MESSAGE_SESSION;
            item.MESSAGE_REFERENS = this.MESSAGE_REFERENS;
            item.MESSAGE_NAMESUB = this.MESSAGE_NAMESUB;
            item.MESSAGE_FLAGIO = this.MESSAGE_FLAGIO;
            item.MESSAGE_STATE = this.MESSAGE_STATE;
            item.MESSAGE_TYPE = this.MESSAGE_TYPE;
            item.MESSAGE_TIMEIN = this.MESSAGE_TIMEIN;
            item.MESSAGE_TIMEOUT = this.MESSAGE_TIMEOUT;
            item.MESSAGE_INTERNAL_REFERENSE = this.MESSAGE_INTERNAL_REFERENSE;
            item.MESSAGE_ERROR = this.MESSAGE_ERROR;
            item.MESSAGE_OWNER = this.MESSAGE_OWNER;
            item.MESSAGE_PACKET = this.MESSAGE_PACKET;
            item.M_DOC_USER = this.M_DOC_USER;
            item.M_DOC_NUM = this.M_DOC_NUM;
            item.M_DOC_DATE = this.M_DOC_DATE;
            item.USER_OPER_DATE = this.USER_OPER_DATE;
            item.m_message_operdate = this.m_message_operdate;
            item.m_message_createdate = this.m_message_createdate;
            item.m_message_authdate = this.m_message_authdate;
            item.m_message_referense = this.m_message_referense;
            item.m_message_type = this.m_message_type;
            item.m_message_subtype = this.m_message_subtype;
            item.m_message_owner = this.m_message_owner;
            item.m_message_auth = this.m_message_auth;
            item.message_systemcomment = this.message_systemcomment;
            item.m_message_rcx = this.m_message_rcx;
            item.messageDocumentReferense = this.messageDocumentReferense;
            item.psstScreening = this.psstScreening;
            item.operDate = this.operDate;
            item.rcxREF = this.rcxREF;
            item.restApiId = this.restApiId;
            item.psstId = this.psstId;
            item.externalSystemId = this.externalSystemId;
            item.externalState = this.externalState;
            item.rcxUNIQUEREF = this.rcxUNIQUEREF;
            item.reconciliationExported = this.reconciliationExported;
            item.maker = this.maker;
            item.checker = this.checker;
            item.isRtrn = this.isRtrn;
            item.rtrnOrgId = this.rtrnOrgId;
            item.rtrnOrgSts = this.rtrnOrgSts;
            OnCreateOrUpdate(null, item, dbContext, controller);
            OnCreateOrUpdate(null, item, dbContext, controller, eventLogManager);
            var cancel = false;
            OnCreate(item, dbContext, controller);
            OnCreate(item, dbContext, controller, eventLogManager, ref cancel);
            if (cancel)
                return this;
            onCreate?.Invoke(item, dbContext, controller);
            if (controller != null && !controller.ModelState.IsValid)
                return this;
            dbContext.Add(item);
            if (!dbContext.SaveChanges<MT_Messages_TBL>(controller, eventLogManager))
                return this;
        
            OnCreatedOrUpdated(null, item, dbContext, controller);
            OnCreatedOrUpdated(null, item, dbContext, controller, eventLogManager);
            OnCreated(item, dbContext, controller);
            OnCreated(item, dbContext, controller, eventLogManager);
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var newViewModel = dbContext.Set<MT_Messages_TBL>().AsQueryable().Select(ViewModel(httpContext, dbContext)).FirstOrDefault(r => r.id == item.id);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller, eventLogManager);
            OnCreated(newViewModel, item, dbContext, controller);
            OnCreated(newViewModel, item, dbContext, controller, eventLogManager);
            var typeCode = "Create";
            OnCreatedLog(newViewModel, item, dbContext, controller, ref typeCode);
            eventLogManager?.LogChanges<DataContext, MT_Messages_TBLViewModel>(controller, null, newViewModel, typeCode: typeCode);
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanUpdate { get; set; }
        
        partial void OnUpdateGetOldViewModel(ref MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdate(MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdate(MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateBeforeSave(MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdateBegin(MT_Messages_TBLViewModel oldViewModel, ref MT_Messages_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdated(MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdated(MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdated(MT_Messages_TBLViewModel newViewModel, MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdated(MT_Messages_TBLViewModel newViewModel, MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateNoChanges(ref bool cancelExecution, MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller);
        partial void OnAllowUpdate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public MT_Messages_TBLViewModel Update(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<MT_Messages_TBLViewModel, MT_Messages_TBL, DataContext, Controller> onUpdate = null, bool validateAccess = true)
        {
            var allowUpdate = true;
            OnAllowUpdate(ref allowUpdate, dbContext, controller, eventLogManager);
            if (!allowUpdate) return this;
            
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<MT_Messages_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT_Messages_TBLViewModel), queryParameters: AccessFilterQueryParameters).FirstOrDefault(r => this.id == r.id);
            MT_Messages_TBLViewModel oldViewModel = null;
            bool hasChanges;
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<MT_Messages_TBL>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.EditAndRead, controller?.ModelState, modelView: typeof(MT_Messages_TBLViewModel), queryParameters: AccessFilterQueryParameters))
                    return this;
        
                OnUpdateGetOldViewModel(ref oldViewModel, item, dbContext, controller);
                if (oldViewModel == null)
                    oldViewModel = dbContext.Set<MT_Messages_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT_Messages_TBLViewModel), queryParameters: AccessFilterQueryParameters).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                OnUpdateBegin(oldViewModel, ref item, dbContext, controller);
                item.id = this.id;
                item.MESSAGE_BODY = this.MESSAGE_BODY;
                item.MESSAGE_DATE = this.MESSAGE_DATE;
                item.MESSAGE_SESSION = this.MESSAGE_SESSION;
                item.MESSAGE_REFERENS = this.MESSAGE_REFERENS;
                item.MESSAGE_NAMESUB = this.MESSAGE_NAMESUB;
                item.MESSAGE_FLAGIO = this.MESSAGE_FLAGIO;
                item.MESSAGE_STATE = this.MESSAGE_STATE;
                item.MESSAGE_TYPE = this.MESSAGE_TYPE;
                item.MESSAGE_TIMEIN = this.MESSAGE_TIMEIN;
                item.MESSAGE_TIMEOUT = this.MESSAGE_TIMEOUT;
                item.MESSAGE_INTERNAL_REFERENSE = this.MESSAGE_INTERNAL_REFERENSE;
                item.MESSAGE_ERROR = this.MESSAGE_ERROR;
                item.MESSAGE_OWNER = this.MESSAGE_OWNER;
                item.MESSAGE_PACKET = this.MESSAGE_PACKET;
                item.M_DOC_USER = this.M_DOC_USER;
                item.M_DOC_NUM = this.M_DOC_NUM;
                item.M_DOC_DATE = this.M_DOC_DATE;
                item.USER_OPER_DATE = this.USER_OPER_DATE;
                item.m_message_operdate = this.m_message_operdate;
                item.m_message_createdate = this.m_message_createdate;
                item.m_message_authdate = this.m_message_authdate;
                item.m_message_referense = this.m_message_referense;
                item.m_message_type = this.m_message_type;
                item.m_message_subtype = this.m_message_subtype;
                item.m_message_owner = this.m_message_owner;
                item.m_message_auth = this.m_message_auth;
                item.message_systemcomment = this.message_systemcomment;
                item.m_message_rcx = this.m_message_rcx;
                item.messageDocumentReferense = this.messageDocumentReferense;
                item.psstScreening = this.psstScreening;
                item.operDate = this.operDate;
                item.rcxREF = this.rcxREF;
                item.restApiId = this.restApiId;
                item.psstId = this.psstId;
                item.externalSystemId = this.externalSystemId;
                item.externalState = this.externalState;
                item.rcxUNIQUEREF = this.rcxUNIQUEREF;
                item.reconciliationExported = this.reconciliationExported;
                item.maker = this.maker;
                item.checker = this.checker;
                item.isRtrn = this.isRtrn;
                item.rtrnOrgId = this.rtrnOrgId;
                item.rtrnOrgSts = this.rtrnOrgSts;
        
                OnCreateOrUpdate(oldViewModel, item, dbContext, controller);
                OnCreateOrUpdate(oldViewModel, item, dbContext, controller, eventLogManager);
                OnUpdate(oldViewModel, item, dbContext, controller);
                OnUpdate(oldViewModel, item, dbContext, controller, eventLogManager);
                onUpdate?.Invoke(oldViewModel, item, dbContext, controller);
                if (controller != null && !controller.ModelState.IsValid)
                    return this;
                hasChanges = dbContext.HasChanges(item);
                bool cancelExecution = false;
                if (!hasChanges)
                {
                    OnUpdateNoChanges(ref cancelExecution, oldViewModel, item, dbContext, controller);
                    if (cancelExecution)
                        return this;
                }
        
                OnUpdateBeforeSave(oldViewModel, item, dbContext, controller);
                if (!dbContext.SaveChanges<MT_Messages_TBL>(controller, eventLogManager))
                    return this;
            }
            else
            {
                controller?.ModelState.AddModelError(String.Empty, ValidationResources.RecordNotFound);
                return this;
            }
        
            OnCreatedOrUpdated(oldViewModel, item, dbContext, controller);
            OnCreatedOrUpdated(oldViewModel, item, dbContext, controller, eventLogManager);
            OnUpdated(oldViewModel, item, dbContext, controller);
            OnUpdated(oldViewModel, item, dbContext, controller, eventLogManager);
            var newViewModel = dbContext.Set<MT_Messages_TBL>().AsQueryable().Select(ViewModel(httpContext, dbContext)).Where(r => r.id == this.id).OrderByDescending(r => r.id).FirstOrDefault();
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            if (hasChanges)
                eventLogManager?.LogChanges<DataContext, MT_Messages_TBLViewModel>(controller, oldViewModel, newViewModel, typeCode: "Update");
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanDestroy { get; set; }
        
        partial void OnDestroy(MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller, ref bool remove);
        partial void OnDestroy(MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool remove);
        partial void OnDestroyed(MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller);
        partial void OnDestroyed(MT_Messages_TBLViewModel oldViewModel, MT_Messages_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        void IViewModelDestroy<DataContext, MT_Messages_TBLViewModel, MT_Messages_TBL>.Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, MT_Messages_TBLViewModel, MT_Messages_TBL> onDestroy)
        {
            Destroy(dbContext, controller, eventLogManager, onDestroy);
        }
        
        public void Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, MT_Messages_TBLViewModel, MT_Messages_TBL> onDestroy = null, bool validateAccess = true)
        {
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<MT_Messages_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT_Messages_TBLViewModel), queryParameters: AccessFilterQueryParameters).FirstOrDefault(r => this.id == r.id);
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<MT_Messages_TBL>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.DeleteAndRead, controller?.ModelState, validationKey: "CancelDelete", modelView: typeof(MT_Messages_TBLViewModel), queryParameters: AccessFilterQueryParameters))
                    return;
        
                var oldViewModel = dbContext.Set<MT_Messages_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT_Messages_TBLViewModel), queryParameters: AccessFilterQueryParameters).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                var remove = true;
                OnDestroy(oldViewModel, item, dbContext, controller, ref remove);
                OnDestroy(oldViewModel, item, dbContext, controller, eventLogManager, ref remove);
                remove = onDestroy?.Invoke(item, dbContext, controller, eventLogManager, remove) ?? remove;
        
                if (remove && (controller == null || controller.ModelState.IsValid))
                {
                    dbContext.Remove(item);
                    if (dbContext.SaveChanges<MT_Messages_TBL>(controller, eventLogManager, validationKey: "CancelDelete"))
                    {
                        eventLogManager?.LogChanges<DataContext, MT_Messages_TBLViewModel>(controller, oldViewModel, null, typeCode: "Destroy");
                        OnDestroyed(oldViewModel, item, dbContext, controller);
                        OnDestroyed(oldViewModel, item, dbContext, controller, eventLogManager);
                    }
                }
            }
        }
        
        
        
        public string GetLogMessage()
        {
            return MESSAGE_BODY+ ", " +MESSAGE_DATE+ ", " +MESSAGE_SESSION.ToString()+ ", " +MESSAGE_REFERENS.ToString()+ ", " +MESSAGE_NAMESUB+ ", " +MESSAGE_FLAGIO+ ", " +MESSAGE_STATE+ ", " +MESSAGE_TYPE+ ", " +MESSAGE_TIMEIN+ ", " +MESSAGE_TIMEOUT+ ", " +MESSAGE_INTERNAL_REFERENSE.ToString()+ ", " +MESSAGE_ERROR+ ", " +MESSAGE_OWNER+ ", " +MESSAGE_PACKET+ ", " +M_DOC_USER+ ", " +M_DOC_NUM.ToString()+ ", " +M_DOC_DATE+ ", " +USER_OPER_DATE+ ", " +m_message_operdate.ToString()+ ", " +(m_message_createdate == null ? "" : string.Format("{0:dd.MM.yyyy HH:mm}", m_message_createdate))+ ", " +(m_message_authdate == null ? "" : string.Format("{0:dd.MM.yyyy HH:mm}", m_message_authdate))+ ", " +m_message_referense+ ", " +m_message_type.ToString()+ ", " +m_message_subtype.ToString()+ ", " +m_message_owner+ ", " +m_message_auth+ ", " +message_systemcomment+ ", " +messageDocumentReferense+ ", " +psstScreening.ToString()+ ", " +operDate.ToString()+ ", " +rcxREF+ ", " +restApiId.ToString()+ ", " +psstId+ ", " +externalSystemId+ ", " +externalState.ToString()+ ", " +rcxUNIQUEREF+ ", " +maker+ ", " +checker+ ", " +isRtrn.ToString()+ ", " +rtrnOrgId.ToString()+ ", " +rtrnOrgSts;
        }
    }
}

namespace Dictionaries.Areas.DIC.ViewModels
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.ComponentModel.DataAnnotations;
    using global::System.Globalization;
    using global::System.Linq;
    using global::System.Linq.Expressions;
    using global::System.Xml.Linq;
    using Newtonsoft.Json;

    using Dictionaries.Areas.DIC.GeneratedResources;
    using BanksGateDataModel.Models;
    using Nat.Web.Core.Resources;
    using Nat.Web.Core.System.Annotations;
    using Nat.Web.Core.System.Data;
    using Nat.Web.Core.System.Data.Extensions;
    using Nat.Web.Core.System.EventLog;
    using Nat.Web.Core.System.Extensions;
    using Nat.Web.Core.System.Linq;
    using Nat.Web.Core.System.ViewModelAnnotations;
    using Nat.Web.Core.System.ViewModels;
    using Nat.Web.Core.System.Extensions.EF;
    using global::System.Web;
    using global::System.Web.Mvc;
    using HttpContext = global::System.Web.HttpContextBase;
    /// <summary>
    ///     MT_Messages_TBLMinimal. Представление таблицы MT_Messages_TBL (MT_Messages_TBL).
    ///     <remarks>
    ///         Сообщение TBL.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Сообщение TBL")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICMT_Messages_TBL", Title = "Сообщение TBL")][EventLogGroupAttribute(ParentCode = "DICMT_Messages_TBL")]
    public partial class MT_Messages_TBLMinimalViewModel
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         ID_MESSAGE.
        ///     </remarks>
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        [Editable(false)]
        [ScaffoldColumn(false)]
        [UIHint("Decimal")]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT_Messages_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public Decimal id { get; set; }


        internal Dictionary<string, string> AccessFilterQueryParameters { get; set; }

        public static Expression<Func<MT_Messages_TBL, MT_Messages_TBLMinimalViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<MT_Messages_TBL, MT_Messages_TBLMinimalViewModel>> viewModel =
                r => new MT_Messages_TBLMinimalViewModel
                        {
                            id = r.id
                        };
        
            return viewModel;
        }
    }
}