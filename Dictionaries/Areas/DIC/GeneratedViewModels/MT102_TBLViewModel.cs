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
    ///     MT102_TBL. Представление таблицы MT102_TBL (MT102_TBL).
    ///     <remarks>
    ///         Сообщение - МТ102.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Сообщение - МТ102")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICMT102_TBL", Title = "Сообщение - МТ102")][EventLogGroupAttribute(ParentCode = "DICMT102_TBL")]
    public partial class MT102_TBLViewModel : IViewModelUpdate<DataContext, MT102_TBLViewModel, MT102_TBL>, IViewModelCreate<DataContext, MT102_TBLViewModel, MT102_TBL>, IViewModelDestroy<DataContext, MT102_TBLViewModel, MT102_TBL>, IViewModelLogMessage<DataContext>
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         Идентификатор.
        ///     </remarks>
        /// </summary>
        [ScaffoldColumn(false)]
        [UIHint("Decimal")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        [RangeDecimal("-999999999999999999", "999999999999999999",
            ErrorMessageResourceType = typeof(ValidationResources), 
            ErrorMessageResourceName = nameof(ValidationResources.RangeAttribute_ValidationError))]
        public Decimal id { get; set; }

        /// <summary>
        ///     ID_DOC.
        ///     <remarks>
        ///         Идентификатор документа.
        ///     </remarks>
        /// </summary>
        [UIHint("Decimal")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.ID_DOC__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.ID_DOC__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [RangeDecimal("-999999999999999999", "999999999999999999",
            ErrorMessageResourceType = typeof(ValidationResources), 
            ErrorMessageResourceName = nameof(ValidationResources.RangeAttribute_ValidationError))]
        public Decimal? ID_DOC { get; set; }

        /// <summary>
        ///     RELATIONREFERENSE.
        ///     <remarks>
        ///         RELATIONREFERENSE.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.RELATIONREFERENSE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.RELATIONREFERENSE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(16, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String RELATIONREFERENSE { get; set; }

        /// <summary>
        ///     CURRENCYCODE.
        ///     <remarks>
        ///         CURRENCYCODE.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.CURRENCYCODE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.CURRENCYCODE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String CURRENCYCODE { get; set; }

        /// <summary>
        ///     CURRENCYAMOUNT.
        ///     <remarks>
        ///         CURRENCYAMOUNT.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.CURRENCYAMOUNT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.CURRENCYAMOUNT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(18, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String CURRENCYAMOUNT { get; set; }

        /// <summary>
        ///     CURRENCYOPERATION.
        ///     <remarks>
        ///         CURRENCYOPERATION.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.CURRENCYOPERATION__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.CURRENCYOPERATION__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String CURRENCYOPERATION { get; set; }

        /// <summary>
        ///     SENDERACCOUNT.
        ///     <remarks>
        ///         SENDERACCOUNT.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERACCOUNT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERACCOUNT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(34, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String SENDERACCOUNT { get; set; }

        /// <summary>
        ///     SENDERNAME.
        ///     <remarks>
        ///         SENDERNAME.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERNAME__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERNAME__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(60, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String SENDERNAME { get; set; }

        /// <summary>
        ///     SENDERCHIEF.
        ///     <remarks>
        ///         SENDERCHIEF.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERCHIEF__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERCHIEF__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(60, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String SENDERCHIEF { get; set; }

        /// <summary>
        ///     SENDERMAINBK.
        ///     <remarks>
        ///         SENDERMAINBK.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERMAINBK__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERMAINBK__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(60, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String SENDERMAINBK { get; set; }

        /// <summary>
        ///     SENDERRNN.
        ///     <remarks>
        ///         SENDERRNN.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERRNN__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERRNN__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(12, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String SENDERRNN { get; set; }

        /// <summary>
        ///     SENDERIRS.
        ///     <remarks>
        ///         SENDERIRS.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERIRS__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERIRS__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String SENDERIRS { get; set; }

        /// <summary>
        ///     SENDERSECO.
        ///     <remarks>
        ///         SENDERSECO.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERSECO__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERSECO__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String SENDERSECO { get; set; }

        /// <summary>
        ///     SENDERBNK.
        ///     <remarks>
        ///         SENDERBNK.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERBNK__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.SENDERBNK__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(11, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String SENDERBNK { get; set; }

        /// <summary>
        ///     BENEFBNK.
        ///     <remarks>
        ///         BENEFBNK.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.BENEFBNK__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.BENEFBNK__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(11, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String BENEFBNK { get; set; }

        /// <summary>
        ///     BENEFACCOUNT.
        ///     <remarks>
        ///         BENEFACCOUNT.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.BENEFACCOUNT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.BENEFACCOUNT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(34, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String BENEFACCOUNT { get; set; }

        /// <summary>
        ///     BENEFNAME.
        ///     <remarks>
        ///         BENEFNAME.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.BENEFNAME__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.BENEFNAME__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(60, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String BENEFNAME { get; set; }

        /// <summary>
        ///     BENEFRNN.
        ///     <remarks>
        ///         BENEFRNN.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.BENEFRNN__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.BENEFRNN__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(12, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String BENEFRNN { get; set; }

        /// <summary>
        ///     BENEFIRS.
        ///     <remarks>
        ///         BENEFIRS.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.BENEFIRS__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.BENEFIRS__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String BENEFIRS { get; set; }

        /// <summary>
        ///     BENEFSECO.
        ///     <remarks>
        ///         BENEFSECO.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.BENEFSECO__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.BENEFSECO__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String BENEFSECO { get; set; }

        /// <summary>
        ///     DOC_NUM.
        ///     <remarks>
        ///         DOC_NUM.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_NUM__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_NUM__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(9, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_NUM { get; set; }

        /// <summary>
        ///     DOC_DATE.
        ///     <remarks>
        ///         DOC_DATE.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_DATE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_DATE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(6, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_DATE { get; set; }

        /// <summary>
        ///     DOC_SEND.
        ///     <remarks>
        ///         DOC_SEND.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_SEND__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_SEND__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(2, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_SEND { get; set; }

        /// <summary>
        ///     DOC_VO.
        ///     <remarks>
        ///         DOC_VO.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_VO__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_VO__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(2, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_VO { get; set; }

        /// <summary>
        ///     DOC_PSO.
        ///     <remarks>
        ///         DOC_PSO.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_PSO__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_PSO__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(2, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_PSO { get; set; }

        /// <summary>
        ///     DOC_KNP.
        ///     <remarks>
        ///         DOC_KNP.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_KNP__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_KNP__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_KNP { get; set; }

        /// <summary>
        ///     DOC_BCLASS.
        ///     <remarks>
        ///         DOC_BCLASS.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_BCLASS__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_BCLASS__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(6, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_BCLASS { get; set; }

        /// <summary>
        ///     DOC_PRT.
        ///     <remarks>
        ///         DOC_PRT.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_PRT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_PRT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(2, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_PRT { get; set; }

        /// <summary>
        ///     DOC_SIM.
        ///     <remarks>
        ///         DOC_SIM.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_SIM__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_SIM__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_SIM { get; set; }

        /// <summary>
        ///     DOC_ASSIGN.
        ///     <remarks>
        ///         DOC_ASSIGN.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_ASSIGN__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_ASSIGN__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(512, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_ASSIGN { get; set; }

        /// <summary>
        ///     DOC_OPERATION.
        ///     <remarks>
        ///         DOC_OPERATION.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_OPERATION__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_OPERATION__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_OPERATION { get; set; }

        /// <summary>
        ///     DOC_SIC.
        ///     <remarks>
        ///         DOC_SIC.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_SIC__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_SIC__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(18, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_SIC { get; set; }

        /// <summary>
        ///     DOC_FM.
        ///     <remarks>
        ///         DOC_FM.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_FM__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_FM__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(61, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_FM { get; set; }

        /// <summary>
        ///     DOC_NM.
        ///     <remarks>
        ///         DOC_NM.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_NM__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_NM__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(61, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_NM { get; set; }

        /// <summary>
        ///     DOC_FT.
        ///     <remarks>
        ///         DOC_FT.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_FT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_FT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(61, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_FT { get; set; }

        /// <summary>
        ///     DOC_DT.
        ///     <remarks>
        ///         DOC_DT.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_DT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_DT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(8, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_DT { get; set; }

        /// <summary>
        ///     DOC_LA.
        ///     <remarks>
        ///         DOC_LA.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_LA__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_LA__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(20, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_LA { get; set; }

        /// <summary>
        ///     DOC_RNN.
        ///     <remarks>
        ///         DOC_RNN.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_RNN__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.DOC_RNN__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(12, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_RNN { get; set; }

        /// <summary>
        ///     seqlfvalue.
        ///     <remarks>
        ///         seqlfvalue.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.seqlfvalue__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.seqlfvalue__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(128, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String seqlfvalue { get; set; }

        /// <summary>
        ///     crossCurrencyCode.
        ///     <remarks>
        ///         crossCurrencyCode.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.crossCurrencyCode__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.crossCurrencyCode__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String crossCurrencyCode { get; set; }

        /// <summary>
        ///     crossCurrencyAmount.
        ///     <remarks>
        ///         crossCurrencyAmount.
        ///     </remarks>
        /// </summary>
        [UIHint("Currency")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.crossCurrencyAmount__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.crossCurrencyAmount__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        public Decimal? crossCurrencyAmount { get; set; }

        /// <summary>
        ///     crossExchange.
        ///     <remarks>
        ///         crossExchange.
        ///     </remarks>
        /// </summary>
        [UIHint("Decimal")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.crossExchange__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.crossExchange__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [RangeDecimal("-999999999999999999", "999999999999999999",
            ErrorMessageResourceType = typeof(ValidationResources), 
            ErrorMessageResourceName = nameof(ValidationResources.RangeAttribute_ValidationError))]
        public Decimal? crossExchange { get; set; }

        /// <summary>
        ///     crossSenderCountry.
        ///     <remarks>
        ///         crossSenderCountry.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.crossSenderCountry__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.crossSenderCountry__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String crossSenderCountry { get; set; }

        /// <summary>
        ///     crossPayeeCountry.
        ///     <remarks>
        ///         crossPayeeCountry.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.crossPayeeCountry__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.crossPayeeCountry__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String crossPayeeCountry { get; set; }

        /// <summary>
        ///     crossChargeCost.
        ///     <remarks>
        ///         crossChargeCost.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.crossChargeCost__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.crossChargeCost__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String crossChargeCost { get; set; }


        internal Dictionary<string, string> AccessFilterQueryParameters { get; set; }

        public static Expression<Func<MT102_TBL, MT102_TBLViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<MT102_TBL, MT102_TBLViewModel>> viewModel =
                r => new MT102_TBLViewModel
                        {
                            id = r.id,
                            ID_DOC = r.ID_DOC,
                            RELATIONREFERENSE = r.RELATIONREFERENSE,
                            CURRENCYCODE = r.CURRENCYCODE,
                            CURRENCYAMOUNT = r.CURRENCYAMOUNT,
                            CURRENCYOPERATION = r.CURRENCYOPERATION,
                            SENDERACCOUNT = r.SENDERACCOUNT,
                            SENDERNAME = r.SENDERNAME,
                            SENDERCHIEF = r.SENDERCHIEF,
                            SENDERMAINBK = r.SENDERMAINBK,
                            SENDERRNN = r.SENDERRNN,
                            SENDERIRS = r.SENDERIRS,
                            SENDERSECO = r.SENDERSECO,
                            SENDERBNK = r.SENDERBNK,
                            BENEFBNK = r.BENEFBNK,
                            BENEFACCOUNT = r.BENEFACCOUNT,
                            BENEFNAME = r.BENEFNAME,
                            BENEFRNN = r.BENEFRNN,
                            BENEFIRS = r.BENEFIRS,
                            BENEFSECO = r.BENEFSECO,
                            DOC_NUM = r.DOC_NUM,
                            DOC_DATE = r.DOC_DATE,
                            DOC_SEND = r.DOC_SEND,
                            DOC_VO = r.DOC_VO,
                            DOC_PSO = r.DOC_PSO,
                            DOC_KNP = r.DOC_KNP,
                            DOC_BCLASS = r.DOC_BCLASS,
                            DOC_PRT = r.DOC_PRT,
                            DOC_SIM = r.DOC_SIM,
                            DOC_ASSIGN = r.DOC_ASSIGN,
                            DOC_OPERATION = r.DOC_OPERATION,
                            DOC_SIC = r.DOC_SIC,
                            DOC_FM = r.DOC_FM,
                            DOC_NM = r.DOC_NM,
                            DOC_FT = r.DOC_FT,
                            DOC_DT = r.DOC_DT,
                            DOC_LA = r.DOC_LA,
                            DOC_RNN = r.DOC_RNN,
                            seqlfvalue = r.seqlfvalue,
                            crossCurrencyCode = r.crossCurrencyCode,
                            crossCurrencyAmount = r.crossCurrencyAmount,
                            crossExchange = r.crossExchange,
                            crossSenderCountry = r.crossSenderCountry,
                            crossPayeeCountry = r.crossPayeeCountry,
                            crossChargeCost = r.crossChargeCost
                        };
        
            var builder = viewModel.ToBuilder(dbContext, httpContext);
            builder.AddAccessResult(r => r.CanDestroy, AccessFilterType.Delete, httpContext);
            builder.AddAccessResult(r => r.CanUpdate, AccessFilterType.Edit, httpContext);
            return builder.ToExpression();
        }
        
        partial void OnCreateOrUpdate(MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreateOrUpdate(MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(MT102_TBLViewModel newViewModel, MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(MT102_TBLViewModel newViewModel, MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreate(MT102_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreate(MT102_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool cancel);
        partial void OnCreated(MT102_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreated(MT102_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreated(MT102_TBLViewModel newViewModel, MT102_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreated(MT102_TBLViewModel newViewModel, MT102_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedLog(MT102_TBLViewModel newViewModel, MT102_TBL item, DataContext dbContext, Controller controller, ref string typeCode);
        partial void OnAllowCreate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public MT102_TBLViewModel Create(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<MT102_TBL, DataContext, Controller> onCreate = null)
        {
            var allowCreate = true;
            OnAllowCreate(ref allowCreate, dbContext, controller, eventLogManager);
            if (!allowCreate) return this;
            
            var item = new MT102_TBL();
            item.id = this.id;
            item.ID_DOC = this.ID_DOC;
            item.RELATIONREFERENSE = this.RELATIONREFERENSE;
            item.CURRENCYCODE = this.CURRENCYCODE;
            item.CURRENCYAMOUNT = this.CURRENCYAMOUNT;
            item.CURRENCYOPERATION = this.CURRENCYOPERATION;
            item.SENDERACCOUNT = this.SENDERACCOUNT;
            item.SENDERNAME = this.SENDERNAME;
            item.SENDERCHIEF = this.SENDERCHIEF;
            item.SENDERMAINBK = this.SENDERMAINBK;
            item.SENDERRNN = this.SENDERRNN;
            item.SENDERIRS = this.SENDERIRS;
            item.SENDERSECO = this.SENDERSECO;
            item.SENDERBNK = this.SENDERBNK;
            item.BENEFBNK = this.BENEFBNK;
            item.BENEFACCOUNT = this.BENEFACCOUNT;
            item.BENEFNAME = this.BENEFNAME;
            item.BENEFRNN = this.BENEFRNN;
            item.BENEFIRS = this.BENEFIRS;
            item.BENEFSECO = this.BENEFSECO;
            item.DOC_NUM = this.DOC_NUM;
            item.DOC_DATE = this.DOC_DATE;
            item.DOC_SEND = this.DOC_SEND;
            item.DOC_VO = this.DOC_VO;
            item.DOC_PSO = this.DOC_PSO;
            item.DOC_KNP = this.DOC_KNP;
            item.DOC_BCLASS = this.DOC_BCLASS;
            item.DOC_PRT = this.DOC_PRT;
            item.DOC_SIM = this.DOC_SIM;
            item.DOC_ASSIGN = this.DOC_ASSIGN;
            item.DOC_OPERATION = this.DOC_OPERATION;
            item.DOC_SIC = this.DOC_SIC;
            item.DOC_FM = this.DOC_FM;
            item.DOC_NM = this.DOC_NM;
            item.DOC_FT = this.DOC_FT;
            item.DOC_DT = this.DOC_DT;
            item.DOC_LA = this.DOC_LA;
            item.DOC_RNN = this.DOC_RNN;
            item.seqlfvalue = this.seqlfvalue;
            item.crossCurrencyCode = this.crossCurrencyCode;
            item.crossCurrencyAmount = this.crossCurrencyAmount;
            item.crossExchange = this.crossExchange;
            item.crossSenderCountry = this.crossSenderCountry;
            item.crossPayeeCountry = this.crossPayeeCountry;
            item.crossChargeCost = this.crossChargeCost;
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
            if (!dbContext.SaveChanges<MT102_TBL>(controller, eventLogManager))
                return this;
        
            OnCreatedOrUpdated(null, item, dbContext, controller);
            OnCreatedOrUpdated(null, item, dbContext, controller, eventLogManager);
            OnCreated(item, dbContext, controller);
            OnCreated(item, dbContext, controller, eventLogManager);
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var newViewModel = dbContext.Set<MT102_TBL>().AsQueryable().Select(ViewModel(httpContext, dbContext)).FirstOrDefault(r => r.id == item.id);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller, eventLogManager);
            OnCreated(newViewModel, item, dbContext, controller);
            OnCreated(newViewModel, item, dbContext, controller, eventLogManager);
            var typeCode = "Create";
            OnCreatedLog(newViewModel, item, dbContext, controller, ref typeCode);
            eventLogManager?.LogChanges<DataContext, MT102_TBLViewModel>(controller, null, newViewModel, typeCode: typeCode);
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanUpdate { get; set; }
        
        partial void OnUpdateGetOldViewModel(ref MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdate(MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdate(MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateBeforeSave(MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdateBegin(MT102_TBLViewModel oldViewModel, ref MT102_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdated(MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdated(MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdated(MT102_TBLViewModel newViewModel, MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdated(MT102_TBLViewModel newViewModel, MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateNoChanges(ref bool cancelExecution, MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller);
        partial void OnAllowUpdate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public MT102_TBLViewModel Update(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<MT102_TBLViewModel, MT102_TBL, DataContext, Controller> onUpdate = null, bool validateAccess = true)
        {
            var allowUpdate = true;
            OnAllowUpdate(ref allowUpdate, dbContext, controller, eventLogManager);
            if (!allowUpdate) return this;
            
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<MT102_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT102_TBLViewModel), queryParameters: AccessFilterQueryParameters).FirstOrDefault(r => this.id == r.id);
            MT102_TBLViewModel oldViewModel = null;
            bool hasChanges;
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<MT102_TBL>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.EditAndRead, controller?.ModelState, modelView: typeof(MT102_TBLViewModel), queryParameters: AccessFilterQueryParameters))
                    return this;
        
                OnUpdateGetOldViewModel(ref oldViewModel, item, dbContext, controller);
                if (oldViewModel == null)
                    oldViewModel = dbContext.Set<MT102_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT102_TBLViewModel), queryParameters: AccessFilterQueryParameters).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                OnUpdateBegin(oldViewModel, ref item, dbContext, controller);
                item.id = this.id;
                item.ID_DOC = this.ID_DOC;
                item.RELATIONREFERENSE = this.RELATIONREFERENSE;
                item.CURRENCYCODE = this.CURRENCYCODE;
                item.CURRENCYAMOUNT = this.CURRENCYAMOUNT;
                item.CURRENCYOPERATION = this.CURRENCYOPERATION;
                item.SENDERACCOUNT = this.SENDERACCOUNT;
                item.SENDERNAME = this.SENDERNAME;
                item.SENDERCHIEF = this.SENDERCHIEF;
                item.SENDERMAINBK = this.SENDERMAINBK;
                item.SENDERRNN = this.SENDERRNN;
                item.SENDERIRS = this.SENDERIRS;
                item.SENDERSECO = this.SENDERSECO;
                item.SENDERBNK = this.SENDERBNK;
                item.BENEFBNK = this.BENEFBNK;
                item.BENEFACCOUNT = this.BENEFACCOUNT;
                item.BENEFNAME = this.BENEFNAME;
                item.BENEFRNN = this.BENEFRNN;
                item.BENEFIRS = this.BENEFIRS;
                item.BENEFSECO = this.BENEFSECO;
                item.DOC_NUM = this.DOC_NUM;
                item.DOC_DATE = this.DOC_DATE;
                item.DOC_SEND = this.DOC_SEND;
                item.DOC_VO = this.DOC_VO;
                item.DOC_PSO = this.DOC_PSO;
                item.DOC_KNP = this.DOC_KNP;
                item.DOC_BCLASS = this.DOC_BCLASS;
                item.DOC_PRT = this.DOC_PRT;
                item.DOC_SIM = this.DOC_SIM;
                item.DOC_ASSIGN = this.DOC_ASSIGN;
                item.DOC_OPERATION = this.DOC_OPERATION;
                item.DOC_SIC = this.DOC_SIC;
                item.DOC_FM = this.DOC_FM;
                item.DOC_NM = this.DOC_NM;
                item.DOC_FT = this.DOC_FT;
                item.DOC_DT = this.DOC_DT;
                item.DOC_LA = this.DOC_LA;
                item.DOC_RNN = this.DOC_RNN;
                item.seqlfvalue = this.seqlfvalue;
                item.crossCurrencyCode = this.crossCurrencyCode;
                item.crossCurrencyAmount = this.crossCurrencyAmount;
                item.crossExchange = this.crossExchange;
                item.crossSenderCountry = this.crossSenderCountry;
                item.crossPayeeCountry = this.crossPayeeCountry;
                item.crossChargeCost = this.crossChargeCost;
        
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
                if (!dbContext.SaveChanges<MT102_TBL>(controller, eventLogManager))
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
            var newViewModel = dbContext.Set<MT102_TBL>().AsQueryable().Select(ViewModel(httpContext, dbContext)).Where(r => r.id == this.id).OrderByDescending(r => r.id).FirstOrDefault();
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            if (hasChanges)
                eventLogManager?.LogChanges<DataContext, MT102_TBLViewModel>(controller, oldViewModel, newViewModel, typeCode: "Update");
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanDestroy { get; set; }
        
        partial void OnDestroy(MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller, ref bool remove);
        partial void OnDestroy(MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool remove);
        partial void OnDestroyed(MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller);
        partial void OnDestroyed(MT102_TBLViewModel oldViewModel, MT102_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        void IViewModelDestroy<DataContext, MT102_TBLViewModel, MT102_TBL>.Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, MT102_TBLViewModel, MT102_TBL> onDestroy)
        {
            Destroy(dbContext, controller, eventLogManager, onDestroy);
        }
        
        public void Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, MT102_TBLViewModel, MT102_TBL> onDestroy = null, bool validateAccess = true)
        {
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<MT102_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT102_TBLViewModel), queryParameters: AccessFilterQueryParameters).FirstOrDefault(r => this.id == r.id);
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<MT102_TBL>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.DeleteAndRead, controller?.ModelState, validationKey: "CancelDelete", modelView: typeof(MT102_TBLViewModel), queryParameters: AccessFilterQueryParameters))
                    return;
        
                var oldViewModel = dbContext.Set<MT102_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT102_TBLViewModel), queryParameters: AccessFilterQueryParameters).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                var remove = true;
                OnDestroy(oldViewModel, item, dbContext, controller, ref remove);
                OnDestroy(oldViewModel, item, dbContext, controller, eventLogManager, ref remove);
                remove = onDestroy?.Invoke(item, dbContext, controller, eventLogManager, remove) ?? remove;
        
                if (remove && (controller == null || controller.ModelState.IsValid))
                {
                    dbContext.Remove(item);
                    if (dbContext.SaveChanges<MT102_TBL>(controller, eventLogManager, validationKey: "CancelDelete"))
                    {
                        eventLogManager?.LogChanges<DataContext, MT102_TBLViewModel>(controller, oldViewModel, null, typeCode: "Destroy");
                        OnDestroyed(oldViewModel, item, dbContext, controller);
                        OnDestroyed(oldViewModel, item, dbContext, controller, eventLogManager);
                    }
                }
            }
        }
        
        
        
        public string GetLogMessage()
        {
            return ID_DOC.ToString()+ ", " +RELATIONREFERENSE+ ", " +CURRENCYCODE+ ", " +CURRENCYAMOUNT+ ", " +CURRENCYOPERATION+ ", " +SENDERACCOUNT+ ", " +SENDERNAME+ ", " +SENDERCHIEF+ ", " +SENDERMAINBK+ ", " +SENDERRNN+ ", " +SENDERIRS+ ", " +SENDERSECO+ ", " +SENDERBNK+ ", " +BENEFBNK+ ", " +BENEFACCOUNT+ ", " +BENEFNAME+ ", " +BENEFRNN+ ", " +BENEFIRS+ ", " +BENEFSECO+ ", " +DOC_NUM+ ", " +DOC_DATE+ ", " +DOC_SEND+ ", " +DOC_VO+ ", " +DOC_PSO+ ", " +DOC_KNP+ ", " +DOC_BCLASS+ ", " +DOC_PRT+ ", " +DOC_SIM+ ", " +DOC_ASSIGN+ ", " +DOC_OPERATION+ ", " +DOC_SIC+ ", " +DOC_FM+ ", " +DOC_NM+ ", " +DOC_FT+ ", " +DOC_DT+ ", " +DOC_LA+ ", " +DOC_RNN+ ", " +seqlfvalue+ ", " +crossCurrencyCode+ ", " +crossCurrencyAmount.ToString()+ ", " +crossExchange.ToString()+ ", " +crossSenderCountry+ ", " +crossPayeeCountry+ ", " +crossChargeCost;
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
    ///     MT102_TBLMinimal. Представление таблицы MT102_TBL (MT102_TBL).
    ///     <remarks>
    ///         Сообщение - МТ102.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Сообщение - МТ102")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICMT102_TBL", Title = "Сообщение - МТ102")][EventLogGroupAttribute(ParentCode = "DICMT102_TBL")]
    public partial class MT102_TBLMinimalViewModel
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         Идентификатор.
        ///     </remarks>
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        [Editable(false)]
        [ScaffoldColumn(false)]
        [UIHint("Decimal")]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT102_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public Decimal id { get; set; }


        internal Dictionary<string, string> AccessFilterQueryParameters { get; set; }

        public static Expression<Func<MT102_TBL, MT102_TBLMinimalViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<MT102_TBL, MT102_TBLMinimalViewModel>> viewModel =
                r => new MT102_TBLMinimalViewModel
                        {
                            id = r.id
                        };
        
            return viewModel;
        }
    }
}