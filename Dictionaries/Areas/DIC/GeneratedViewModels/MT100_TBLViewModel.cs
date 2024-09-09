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
    ///     MT100_TBL. Представление таблицы MT100_TBL (MT100_TBL).
    ///     <remarks>
    ///         Сообщение - МТ100.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Сообщение - МТ100")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICMT100_TBL", Title = "Сообщение - МТ100")][EventLogGroupAttribute(ParentCode = "DICMT100_TBL")]
    public partial class MT100_TBLViewModel : IViewModelUpdate<DataContext, MT100_TBLViewModel, MT100_TBL>, IViewModelCreate<DataContext, MT100_TBLViewModel, MT100_TBL>, IViewModelDestroy<DataContext, MT100_TBLViewModel, MT100_TBL>, IViewModelLogMessage<DataContext>
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         Иденитфикатор документа.
        ///     </remarks>
        /// </summary>
        [ScaffoldColumn(false)]
        [UIHint("Int64")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        public Int64 id { get; set; }

        /// <summary>
        ///     ID_MESSAGE.
        ///     <remarks>
        ///         Идентификатор собщение.
        ///     </remarks>
        /// </summary>
        [UIHint("Decimal")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.ID_MESSAGE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.ID_MESSAGE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [RangeDecimal("-999999999999999999", "999999999999999999",
            ErrorMessageResourceType = typeof(ValidationResources), 
            ErrorMessageResourceName = nameof(ValidationResources.RangeAttribute_ValidationError))]
        public Decimal? ID_MESSAGE { get; set; }

        /// <summary>
        ///     DOC_REFERENCE.
        ///     <remarks>
        ///         Ссылка на документ.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_REFERENCE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_REFERENCE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(16, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_REFERENCE { get; set; }

        /// <summary>
        ///     DOC_PAYADD.
        ///     <remarks>
        ///         DOC_PAYADD.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_PAYADD__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_PAYADD__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(6, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_PAYADD { get; set; }

        /// <summary>
        ///     DOC_PAYCODE.
        ///     <remarks>
        ///         DOC_PAYCODE.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_PAYCODE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_PAYCODE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_PAYCODE { get; set; }

        /// <summary>
        ///     DOC_OPERATION.
        ///     <remarks>
        ///         Операция документа.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_OPERATION__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_OPERATION__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_OPERATION { get; set; }

        /// <summary>
        ///     DOC_INITIATORACCOUNT.
        ///     <remarks>
        ///         DOC_INITIATORACCOUNT.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORACCOUNT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORACCOUNT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(34, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_INITIATORACCOUNT { get; set; }

        /// <summary>
        ///     DOC_INITIATORRNN.
        ///     <remarks>
        ///         DOC_INITIATORRNN.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORRNN__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORRNN__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(12, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_INITIATORRNN { get; set; }

        /// <summary>
        ///     DOC_INITIATORCHIEF.
        ///     <remarks>
        ///         DOC_INITIATORCHIEF.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORCHIEF__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORCHIEF__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(60, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_INITIATORCHIEF { get; set; }

        /// <summary>
        ///     DOC_INITIATORMAINBK.
        ///     <remarks>
        ///         DOC_INITIATORMAINBK.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORMAINBK__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORMAINBK__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(60, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_INITIATORMAINBK { get; set; }

        /// <summary>
        ///     DOC_INITIATORNAME.
        ///     <remarks>
        ///         DOC_INITIATORNAME.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORNAME__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORNAME__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(60, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_INITIATORNAME { get; set; }

        /// <summary>
        ///     DOC_INITIATORIRS.
        ///     <remarks>
        ///         DOC_INITIATORIRS.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORIRS__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORIRS__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_INITIATORIRS { get; set; }

        /// <summary>
        ///     DOC_INITIATORSECO.
        ///     <remarks>
        ///         DOC_INITIATORSECO.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORSECO__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORSECO__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_INITIATORSECO { get; set; }

        /// <summary>
        ///     DOC_INITIATORBNK.
        ///     <remarks>
        ///         DOC_INITIATORBNK.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORBNK__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORBNK__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(34, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_INITIATORBNK { get; set; }

        /// <summary>
        ///     DOC_INITIATORCORRBBNK.
        ///     <remarks>
        ///         DOC_INITIATORCORRBBNK.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORCORRBBNK__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORCORRBBNK__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(34, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_INITIATORCORRBBNK { get; set; }

        /// <summary>
        ///     DOC_INITIATORCORRACCOUNT.
        ///     <remarks>
        ///         DOC_INITIATORCORRACCOUNT.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORCORRACCOUNT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORCORRACCOUNT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(34, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_INITIATORCORRACCOUNT { get; set; }

        /// <summary>
        ///     DOC_BENEFCORRRBNK.
        ///     <remarks>
        ///         DOC_BENEFCORRRBNK.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFCORRRBNK__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFCORRRBNK__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(34, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_BENEFCORRRBNK { get; set; }

        /// <summary>
        ///     DOC_BENEFCORRACCOUNT.
        ///     <remarks>
        ///         DOC_BENEFCORRACCOUNT.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFCORRACCOUNT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFCORRACCOUNT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(34, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_BENEFCORRACCOUNT { get; set; }

        /// <summary>
        ///     DOC_BENEFBNK.
        ///     <remarks>
        ///         DOC_BENEFBNK.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFBNK__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFBNK__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(34, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_BENEFBNK { get; set; }

        /// <summary>
        ///     DOC_BENEFACCOUNT.
        ///     <remarks>
        ///         DOC_BENEFACCOUNT.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFACCOUNT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFACCOUNT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(34, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_BENEFACCOUNT { get; set; }

        /// <summary>
        ///     DOC_BENEFRNN.
        ///     <remarks>
        ///         DOC_BENEFRNN.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFRNN__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFRNN__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(12, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_BENEFRNN { get; set; }

        /// <summary>
        ///     DOC_BENEFNAME.
        ///     <remarks>
        ///         DOC_BENEFNAME.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFNAME__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFNAME__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(60, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_BENEFNAME { get; set; }

        /// <summary>
        ///     DOC_BENEFIRS.
        ///     <remarks>
        ///         DOC_BENEFIRS.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFIRS__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFIRS__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_BENEFIRS { get; set; }

        /// <summary>
        ///     DOC_BENEFSECO.
        ///     <remarks>
        ///         DOC_BENEFSECO.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFSECO__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFSECO__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_BENEFSECO { get; set; }

        /// <summary>
        ///     DOC_NUM.
        ///     <remarks>
        ///         Номер документа.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_NUM__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_NUM__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(9, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_NUM { get; set; }

        /// <summary>
        ///     DOC_DATE.
        ///     <remarks>
        ///         Дата документа.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_DATE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_DATE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(6, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_DATE { get; set; }

        /// <summary>
        ///     DOC_SEND.
        ///     <remarks>
        ///         Отправить документ.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_SEND__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_SEND__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
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
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_VO__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_VO__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
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
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_PSO__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_PSO__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
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
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_KNP__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_KNP__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(2, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
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
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BCLASS__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BCLASS__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
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
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_PRT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_PRT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
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
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_SIM__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_SIM__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
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
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_ASSIGN__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_ASSIGN__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(512, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_ASSIGN { get; set; }

        /// <summary>
        ///     DOC_ADD.
        ///     <remarks>
        ///         Добавить документ.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_ADD__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_ADD__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(420, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_ADD { get; set; }

        /// <summary>
        ///     DOC_PAYAMOUNT.
        ///     <remarks>
        ///         DOC_PAYAMOUNT.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_PAYAMOUNT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_PAYAMOUNT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(18, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_PAYAMOUNT { get; set; }

        /// <summary>
        ///     DOC_RELATIONREFERENSE.
        ///     <remarks>
        ///         DOC_RELATIONREFERENSE.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_RELATIONREFERENSE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_RELATIONREFERENSE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(16, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_RELATIONREFERENSE { get; set; }

        /// <summary>
        ///     DOC_PRINTED.
        ///     <remarks>
        ///         DOC_PRINTED.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_PRINTED__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_PRINTED__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        public Int32? DOC_PRINTED { get; set; }

        /// <summary>
        ///     lfvalue.
        ///     <remarks>
        ///         lfvalue.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.lfvalue__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.lfvalue__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(128, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String lfvalue { get; set; }

        /// <summary>
        ///     PSTATE.
        ///     <remarks>
        ///         PSTATE.
        ///     </remarks>
        /// </summary>
        [UIHint("Boolean")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.PSTATE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.PSTATE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [DisplayExtended(ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources), BooleanTextTrue = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.PSTATE__TrueText), BooleanTextFalse = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.PSTATE__FalseText))]
        public Boolean? PSTATE { get; set; }

        /// <summary>
        ///     DOC_INITIATORIDN.
        ///     <remarks>
        ///         DOC_INITIATORIDN.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORIDN__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_INITIATORIDN__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(12, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_INITIATORIDN { get; set; }

        /// <summary>
        ///     DOC_BENEFIDN.
        ///     <remarks>
        ///         DOC_BENEFIDN.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFIDN__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.DOC_BENEFIDN__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(12, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DOC_BENEFIDN { get; set; }

        /// <summary>
        ///     COMMON_DOC_TYPE.
        ///     <remarks>
        ///         COMMON_DOC_TYPE.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.COMMON_DOC_TYPE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.COMMON_DOC_TYPE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        public Int32? COMMON_DOC_TYPE { get; set; }

        /// <summary>
        ///     isENTERPRISEWAGE.
        ///     <remarks>
        ///         isENTERPRISEWAGE.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.isENTERPRISEWAGE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.isENTERPRISEWAGE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        public Int32? isENTERPRISEWAGE { get; set; }

        /// <summary>
        ///     paymentType.
        ///     <remarks>
        ///         paymentType.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.paymentType__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.paymentType__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        public Int32 paymentType { get; set; }

        /// <summary>
        ///     crossCurrencyCode.
        ///     <remarks>
        ///         crossCurrencyCode.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.crossCurrencyCode__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.crossCurrencyCode__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
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
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.crossCurrencyAmount__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.crossCurrencyAmount__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
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
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.crossExchange__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.crossExchange__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
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
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.crossSenderCountry__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.crossSenderCountry__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
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
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.crossPayeeCountry__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.crossPayeeCountry__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
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
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.crossChargeCost__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.crossChargeCost__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String crossChargeCost { get; set; }

        /// <summary>
        ///     doc_type.
        ///     <remarks>
        ///         doc_type.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.doc_type__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.doc_type__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        public Int32? doc_type { get; set; }

        /// <summary>
        ///     operDate.
        ///     <remarks>
        ///         operDate.
        ///     </remarks>
        /// </summary>
        [UIHint("DateTime")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.operDate__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.operDate__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        public DateTime? operDate { get; set; }

        /// <summary>
        ///     psstView.
        ///     <remarks>
        ///         psstView.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.psstView__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.psstView__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        public Int32? psstView { get; set; }

        /// <summary>
        ///     senderPhone.
        ///     <remarks>
        ///         senderPhone.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.senderPhone__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.senderPhone__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String senderPhone { get; set; }

        /// <summary>
        ///     addresseePhone.
        ///     <remarks>
        ///         addresseePhone.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.addresseePhone__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.addresseePhone__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String addresseePhone { get; set; }

        /// <summary>
        ///     payPriority.
        ///     <remarks>
        ///         payPriority.
        ///     </remarks>
        /// </summary>
        [UIHint("Boolean")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.payPriority__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.payPriority__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [DisplayExtended(ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources), BooleanTextTrue = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.payPriority__TrueText), BooleanTextFalse = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.payPriority__FalseText))]
        public Boolean? payPriority { get; set; }

        /// <summary>
        ///     isUseLimit.
        ///     <remarks>
        ///         isUseLimit.
        ///     </remarks>
        /// </summary>
        [UIHint("Boolean")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.isUseLimit__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.isUseLimit__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        [DisplayExtended(ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources), BooleanTextTrue = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.isUseLimit__TrueText), BooleanTextFalse = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.isUseLimit__FalseText))]
        public Boolean? isUseLimit { get; set; }

        /// <summary>
        ///     REFlimitId.
        ///     <remarks>
        ///         REFlimitId.
        ///     </remarks>
        /// </summary>
        [UIHint("Int64")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.REFlimitId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.REFlimitId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        public Int64? REFlimitId { get; set; }


        internal Dictionary<string, string> AccessFilterQueryParameters { get; set; }

        public static Expression<Func<MT100_TBL, MT100_TBLViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<MT100_TBL, MT100_TBLViewModel>> viewModel =
                r => new MT100_TBLViewModel
                        {
                            id = r.id,
                            ID_MESSAGE = r.ID_MESSAGE,
                            DOC_REFERENCE = r.DOC_REFERENCE,
                            DOC_PAYADD = r.DOC_PAYADD,
                            DOC_PAYCODE = r.DOC_PAYCODE,
                            DOC_OPERATION = r.DOC_OPERATION,
                            DOC_INITIATORACCOUNT = r.DOC_INITIATORACCOUNT,
                            DOC_INITIATORRNN = r.DOC_INITIATORRNN,
                            DOC_INITIATORCHIEF = r.DOC_INITIATORCHIEF,
                            DOC_INITIATORMAINBK = r.DOC_INITIATORMAINBK,
                            DOC_INITIATORNAME = r.DOC_INITIATORNAME,
                            DOC_INITIATORIRS = r.DOC_INITIATORIRS,
                            DOC_INITIATORSECO = r.DOC_INITIATORSECO,
                            DOC_INITIATORBNK = r.DOC_INITIATORBNK,
                            DOC_INITIATORCORRBBNK = r.DOC_INITIATORCORRBBNK,
                            DOC_INITIATORCORRACCOUNT = r.DOC_INITIATORCORRACCOUNT,
                            DOC_BENEFCORRRBNK = r.DOC_BENEFCORRRBNK,
                            DOC_BENEFCORRACCOUNT = r.DOC_BENEFCORRACCOUNT,
                            DOC_BENEFBNK = r.DOC_BENEFBNK,
                            DOC_BENEFACCOUNT = r.DOC_BENEFACCOUNT,
                            DOC_BENEFRNN = r.DOC_BENEFRNN,
                            DOC_BENEFNAME = r.DOC_BENEFNAME,
                            DOC_BENEFIRS = r.DOC_BENEFIRS,
                            DOC_BENEFSECO = r.DOC_BENEFSECO,
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
                            DOC_ADD = r.DOC_ADD,
                            DOC_PAYAMOUNT = r.DOC_PAYAMOUNT,
                            DOC_RELATIONREFERENSE = r.DOC_RELATIONREFERENSE,
                            DOC_PRINTED = r.DOC_PRINTED,
                            lfvalue = r.lfvalue,
                            PSTATE = r.PSTATE,
                            DOC_INITIATORIDN = r.DOC_INITIATORIDN,
                            DOC_BENEFIDN = r.DOC_BENEFIDN,
                            COMMON_DOC_TYPE = r.COMMON_DOC_TYPE,
                            isENTERPRISEWAGE = r.isENTERPRISEWAGE,
                            paymentType = r.paymentType,
                            crossCurrencyCode = r.crossCurrencyCode,
                            crossCurrencyAmount = r.crossCurrencyAmount,
                            crossExchange = r.crossExchange,
                            crossSenderCountry = r.crossSenderCountry,
                            crossPayeeCountry = r.crossPayeeCountry,
                            crossChargeCost = r.crossChargeCost,
                            doc_type = r.doc_type,
                            operDate = r.operDate,
                            psstView = r.psstView,
                            senderPhone = r.senderPhone,
                            addresseePhone = r.addresseePhone,
                            payPriority = r.payPriority,
                            isUseLimit = r.isUseLimit,
                            REFlimitId = r.REFlimitId
                        };
        
            var builder = viewModel.ToBuilder(dbContext, httpContext);
            builder.AddAccessResult(r => r.CanDestroy, AccessFilterType.Delete, httpContext);
            builder.AddAccessResult(r => r.CanUpdate, AccessFilterType.Edit, httpContext);
            return builder.ToExpression();
        }
        
        partial void OnCreateOrUpdate(MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreateOrUpdate(MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(MT100_TBLViewModel newViewModel, MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(MT100_TBLViewModel newViewModel, MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreate(MT100_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreate(MT100_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool cancel);
        partial void OnCreated(MT100_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreated(MT100_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreated(MT100_TBLViewModel newViewModel, MT100_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreated(MT100_TBLViewModel newViewModel, MT100_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedLog(MT100_TBLViewModel newViewModel, MT100_TBL item, DataContext dbContext, Controller controller, ref string typeCode);
        partial void OnAllowCreate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public MT100_TBLViewModel Create(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<MT100_TBL, DataContext, Controller> onCreate = null)
        {
            var allowCreate = true;
            OnAllowCreate(ref allowCreate, dbContext, controller, eventLogManager);
            if (!allowCreate) return this;
            
            var item = new MT100_TBL();
            item.id = this.id;
            item.ID_MESSAGE = this.ID_MESSAGE;
            item.DOC_REFERENCE = this.DOC_REFERENCE;
            item.DOC_PAYADD = this.DOC_PAYADD;
            item.DOC_PAYCODE = this.DOC_PAYCODE;
            item.DOC_OPERATION = this.DOC_OPERATION;
            item.DOC_INITIATORACCOUNT = this.DOC_INITIATORACCOUNT;
            item.DOC_INITIATORRNN = this.DOC_INITIATORRNN;
            item.DOC_INITIATORCHIEF = this.DOC_INITIATORCHIEF;
            item.DOC_INITIATORMAINBK = this.DOC_INITIATORMAINBK;
            item.DOC_INITIATORNAME = this.DOC_INITIATORNAME;
            item.DOC_INITIATORIRS = this.DOC_INITIATORIRS;
            item.DOC_INITIATORSECO = this.DOC_INITIATORSECO;
            item.DOC_INITIATORBNK = this.DOC_INITIATORBNK;
            item.DOC_INITIATORCORRBBNK = this.DOC_INITIATORCORRBBNK;
            item.DOC_INITIATORCORRACCOUNT = this.DOC_INITIATORCORRACCOUNT;
            item.DOC_BENEFCORRRBNK = this.DOC_BENEFCORRRBNK;
            item.DOC_BENEFCORRACCOUNT = this.DOC_BENEFCORRACCOUNT;
            item.DOC_BENEFBNK = this.DOC_BENEFBNK;
            item.DOC_BENEFACCOUNT = this.DOC_BENEFACCOUNT;
            item.DOC_BENEFRNN = this.DOC_BENEFRNN;
            item.DOC_BENEFNAME = this.DOC_BENEFNAME;
            item.DOC_BENEFIRS = this.DOC_BENEFIRS;
            item.DOC_BENEFSECO = this.DOC_BENEFSECO;
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
            item.DOC_ADD = this.DOC_ADD;
            item.DOC_PAYAMOUNT = this.DOC_PAYAMOUNT;
            item.DOC_RELATIONREFERENSE = this.DOC_RELATIONREFERENSE;
            item.DOC_PRINTED = this.DOC_PRINTED;
            item.lfvalue = this.lfvalue;
            item.PSTATE = this.PSTATE;
            item.DOC_INITIATORIDN = this.DOC_INITIATORIDN;
            item.DOC_BENEFIDN = this.DOC_BENEFIDN;
            item.COMMON_DOC_TYPE = this.COMMON_DOC_TYPE;
            item.isENTERPRISEWAGE = this.isENTERPRISEWAGE;
            item.paymentType = this.paymentType;
            item.crossCurrencyCode = this.crossCurrencyCode;
            item.crossCurrencyAmount = this.crossCurrencyAmount;
            item.crossExchange = this.crossExchange;
            item.crossSenderCountry = this.crossSenderCountry;
            item.crossPayeeCountry = this.crossPayeeCountry;
            item.crossChargeCost = this.crossChargeCost;
            item.doc_type = this.doc_type;
            item.operDate = this.operDate;
            item.psstView = this.psstView;
            item.senderPhone = this.senderPhone;
            item.addresseePhone = this.addresseePhone;
            item.payPriority = this.payPriority;
            item.isUseLimit = this.isUseLimit;
            item.REFlimitId = this.REFlimitId;
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
            if (!dbContext.SaveChanges<MT100_TBL>(controller, eventLogManager))
                return this;
        
            OnCreatedOrUpdated(null, item, dbContext, controller);
            OnCreatedOrUpdated(null, item, dbContext, controller, eventLogManager);
            OnCreated(item, dbContext, controller);
            OnCreated(item, dbContext, controller, eventLogManager);
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var newViewModel = dbContext.Set<MT100_TBL>().AsQueryable().Select(ViewModel(httpContext, dbContext)).FirstOrDefault(r => r.id == item.id);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller, eventLogManager);
            OnCreated(newViewModel, item, dbContext, controller);
            OnCreated(newViewModel, item, dbContext, controller, eventLogManager);
            var typeCode = "Create";
            OnCreatedLog(newViewModel, item, dbContext, controller, ref typeCode);
            eventLogManager?.LogChanges<DataContext, MT100_TBLViewModel>(controller, null, newViewModel, typeCode: typeCode);
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanUpdate { get; set; }
        
        partial void OnUpdateGetOldViewModel(ref MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdate(MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdate(MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateBeforeSave(MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdateBegin(MT100_TBLViewModel oldViewModel, ref MT100_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdated(MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdated(MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdated(MT100_TBLViewModel newViewModel, MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdated(MT100_TBLViewModel newViewModel, MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateNoChanges(ref bool cancelExecution, MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller);
        partial void OnAllowUpdate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public MT100_TBLViewModel Update(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<MT100_TBLViewModel, MT100_TBL, DataContext, Controller> onUpdate = null, bool validateAccess = true)
        {
            var allowUpdate = true;
            OnAllowUpdate(ref allowUpdate, dbContext, controller, eventLogManager);
            if (!allowUpdate) return this;
            
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<MT100_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT100_TBLViewModel), queryParameters: AccessFilterQueryParameters).FirstOrDefault(r => this.id == r.id);
            MT100_TBLViewModel oldViewModel = null;
            bool hasChanges;
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<MT100_TBL>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.EditAndRead, controller?.ModelState, modelView: typeof(MT100_TBLViewModel), queryParameters: AccessFilterQueryParameters))
                    return this;
        
                OnUpdateGetOldViewModel(ref oldViewModel, item, dbContext, controller);
                if (oldViewModel == null)
                    oldViewModel = dbContext.Set<MT100_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT100_TBLViewModel), queryParameters: AccessFilterQueryParameters).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                OnUpdateBegin(oldViewModel, ref item, dbContext, controller);
                item.id = this.id;
                item.ID_MESSAGE = this.ID_MESSAGE;
                item.DOC_REFERENCE = this.DOC_REFERENCE;
                item.DOC_PAYADD = this.DOC_PAYADD;
                item.DOC_PAYCODE = this.DOC_PAYCODE;
                item.DOC_OPERATION = this.DOC_OPERATION;
                item.DOC_INITIATORACCOUNT = this.DOC_INITIATORACCOUNT;
                item.DOC_INITIATORRNN = this.DOC_INITIATORRNN;
                item.DOC_INITIATORCHIEF = this.DOC_INITIATORCHIEF;
                item.DOC_INITIATORMAINBK = this.DOC_INITIATORMAINBK;
                item.DOC_INITIATORNAME = this.DOC_INITIATORNAME;
                item.DOC_INITIATORIRS = this.DOC_INITIATORIRS;
                item.DOC_INITIATORSECO = this.DOC_INITIATORSECO;
                item.DOC_INITIATORBNK = this.DOC_INITIATORBNK;
                item.DOC_INITIATORCORRBBNK = this.DOC_INITIATORCORRBBNK;
                item.DOC_INITIATORCORRACCOUNT = this.DOC_INITIATORCORRACCOUNT;
                item.DOC_BENEFCORRRBNK = this.DOC_BENEFCORRRBNK;
                item.DOC_BENEFCORRACCOUNT = this.DOC_BENEFCORRACCOUNT;
                item.DOC_BENEFBNK = this.DOC_BENEFBNK;
                item.DOC_BENEFACCOUNT = this.DOC_BENEFACCOUNT;
                item.DOC_BENEFRNN = this.DOC_BENEFRNN;
                item.DOC_BENEFNAME = this.DOC_BENEFNAME;
                item.DOC_BENEFIRS = this.DOC_BENEFIRS;
                item.DOC_BENEFSECO = this.DOC_BENEFSECO;
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
                item.DOC_ADD = this.DOC_ADD;
                item.DOC_PAYAMOUNT = this.DOC_PAYAMOUNT;
                item.DOC_RELATIONREFERENSE = this.DOC_RELATIONREFERENSE;
                item.DOC_PRINTED = this.DOC_PRINTED;
                item.lfvalue = this.lfvalue;
                item.PSTATE = this.PSTATE;
                item.DOC_INITIATORIDN = this.DOC_INITIATORIDN;
                item.DOC_BENEFIDN = this.DOC_BENEFIDN;
                item.COMMON_DOC_TYPE = this.COMMON_DOC_TYPE;
                item.isENTERPRISEWAGE = this.isENTERPRISEWAGE;
                item.paymentType = this.paymentType;
                item.crossCurrencyCode = this.crossCurrencyCode;
                item.crossCurrencyAmount = this.crossCurrencyAmount;
                item.crossExchange = this.crossExchange;
                item.crossSenderCountry = this.crossSenderCountry;
                item.crossPayeeCountry = this.crossPayeeCountry;
                item.crossChargeCost = this.crossChargeCost;
                item.doc_type = this.doc_type;
                item.operDate = this.operDate;
                item.psstView = this.psstView;
                item.senderPhone = this.senderPhone;
                item.addresseePhone = this.addresseePhone;
                item.payPriority = this.payPriority;
                item.isUseLimit = this.isUseLimit;
                item.REFlimitId = this.REFlimitId;
        
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
                if (!dbContext.SaveChanges<MT100_TBL>(controller, eventLogManager))
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
            var newViewModel = dbContext.Set<MT100_TBL>().AsQueryable().Select(ViewModel(httpContext, dbContext)).Where(r => r.id == this.id).OrderByDescending(r => r.id).FirstOrDefault();
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            if (hasChanges)
                eventLogManager?.LogChanges<DataContext, MT100_TBLViewModel>(controller, oldViewModel, newViewModel, typeCode: "Update");
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanDestroy { get; set; }
        
        partial void OnDestroy(MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller, ref bool remove);
        partial void OnDestroy(MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool remove);
        partial void OnDestroyed(MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller);
        partial void OnDestroyed(MT100_TBLViewModel oldViewModel, MT100_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        void IViewModelDestroy<DataContext, MT100_TBLViewModel, MT100_TBL>.Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, MT100_TBLViewModel, MT100_TBL> onDestroy)
        {
            Destroy(dbContext, controller, eventLogManager, onDestroy);
        }
        
        public void Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, MT100_TBLViewModel, MT100_TBL> onDestroy = null, bool validateAccess = true)
        {
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<MT100_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT100_TBLViewModel), queryParameters: AccessFilterQueryParameters).FirstOrDefault(r => this.id == r.id);
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<MT100_TBL>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.DeleteAndRead, controller?.ModelState, validationKey: "CancelDelete", modelView: typeof(MT100_TBLViewModel), queryParameters: AccessFilterQueryParameters))
                    return;
        
                var oldViewModel = dbContext.Set<MT100_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT100_TBLViewModel), queryParameters: AccessFilterQueryParameters).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                var remove = true;
                OnDestroy(oldViewModel, item, dbContext, controller, ref remove);
                OnDestroy(oldViewModel, item, dbContext, controller, eventLogManager, ref remove);
                remove = onDestroy?.Invoke(item, dbContext, controller, eventLogManager, remove) ?? remove;
        
                if (remove && (controller == null || controller.ModelState.IsValid))
                {
                    dbContext.Remove(item);
                    if (dbContext.SaveChanges<MT100_TBL>(controller, eventLogManager, validationKey: "CancelDelete"))
                    {
                        eventLogManager?.LogChanges<DataContext, MT100_TBLViewModel>(controller, oldViewModel, null, typeCode: "Destroy");
                        OnDestroyed(oldViewModel, item, dbContext, controller);
                        OnDestroyed(oldViewModel, item, dbContext, controller, eventLogManager);
                    }
                }
            }
        }
        
        
        
        public string GetLogMessage()
        {
            return ID_MESSAGE.ToString()+ ", " +DOC_REFERENCE+ ", " +DOC_PAYADD+ ", " +DOC_PAYCODE+ ", " +DOC_OPERATION+ ", " +DOC_INITIATORACCOUNT+ ", " +DOC_INITIATORRNN+ ", " +DOC_INITIATORCHIEF+ ", " +DOC_INITIATORMAINBK+ ", " +DOC_INITIATORNAME+ ", " +DOC_INITIATORIRS+ ", " +DOC_INITIATORSECO+ ", " +DOC_INITIATORBNK+ ", " +DOC_INITIATORCORRBBNK+ ", " +DOC_INITIATORCORRACCOUNT+ ", " +DOC_BENEFCORRRBNK+ ", " +DOC_BENEFCORRACCOUNT+ ", " +DOC_BENEFBNK+ ", " +DOC_BENEFACCOUNT+ ", " +DOC_BENEFRNN+ ", " +DOC_BENEFNAME+ ", " +DOC_BENEFIRS+ ", " +DOC_BENEFSECO+ ", " +DOC_NUM+ ", " +DOC_DATE+ ", " +DOC_SEND+ ", " +DOC_VO+ ", " +DOC_PSO+ ", " +DOC_KNP+ ", " +DOC_BCLASS+ ", " +DOC_PRT+ ", " +DOC_SIM+ ", " +DOC_ASSIGN+ ", " +DOC_ADD+ ", " +DOC_PAYAMOUNT+ ", " +DOC_RELATIONREFERENSE+ ", " +DOC_PRINTED.ToString()+ ", " +lfvalue+ ", " +DOC_INITIATORIDN+ ", " +DOC_BENEFIDN+ ", " +COMMON_DOC_TYPE.ToString()+ ", " +isENTERPRISEWAGE.ToString()+ ", " +paymentType.ToString()+ ", " +crossCurrencyCode+ ", " +crossCurrencyAmount.ToString()+ ", " +crossExchange.ToString()+ ", " +crossSenderCountry+ ", " +crossPayeeCountry+ ", " +crossChargeCost+ ", " +doc_type.ToString()+ ", " +operDate.ToString()+ ", " +psstView.ToString()+ ", " +senderPhone+ ", " +addresseePhone+ ", " +REFlimitId.ToString();
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
    ///     MT100_TBLMinimal. Представление таблицы MT100_TBL (MT100_TBL).
    ///     <remarks>
    ///         Сообщение - МТ100.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Сообщение - МТ100")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICMT100_TBL", Title = "Сообщение - МТ100")][EventLogGroupAttribute(ParentCode = "DICMT100_TBL")]
    public partial class MT100_TBLMinimalViewModel
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         Иденитфикатор документа.
        ///     </remarks>
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        [Editable(false)]
        [ScaffoldColumn(false)]
        [UIHint("Int64")]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT100_TBLResources))]
        public Int64 id { get; set; }


        internal Dictionary<string, string> AccessFilterQueryParameters { get; set; }

        public static Expression<Func<MT100_TBL, MT100_TBLMinimalViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<MT100_TBL, MT100_TBLMinimalViewModel>> viewModel =
                r => new MT100_TBLMinimalViewModel
                        {
                            id = r.id
                        };
        
            return viewModel;
        }
    }
}