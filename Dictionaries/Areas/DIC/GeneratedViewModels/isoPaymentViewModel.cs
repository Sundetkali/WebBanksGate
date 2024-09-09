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
    ///     isoPayment. Представление таблицы isoPayment (isoPayment).
    ///     <remarks>
    ///         Платеж.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Платеж")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICisoPayment", Title = "Платеж")][EventLogGroupAttribute(ParentCode = "DICisoPayment")]
    public partial class isoPaymentViewModel : IViewModelUpdate<DataContext, isoPaymentViewModel, isoPayment>, IViewModelCreate<DataContext, isoPaymentViewModel, isoPayment>, IViewModelDestroy<DataContext, isoPaymentViewModel, isoPayment>, IViewModelLogMessage<DataContext>
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         payId.
        ///     </remarks>
        /// </summary>
        [ScaffoldColumn(false)]
        [UIHint("Int64")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        public Int64 id { get; set; }

        /// <summary>
        ///     REFid.
        ///     <remarks>
        ///         REFmsgId.
        ///     </remarks>
        /// </summary>
        [UIHint("GridForeignKeyLoading")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.REFid__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.REFid__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [ForeignKeyRequired(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        [ForeignKey(AllowFullLoad = false, 
                    StaticData = false,
                    AreaName = "DIC", 
                    ControllerName = "isoMsg", 
                    ActionName = "GetData", 
                    DataTextField = "id", 
                    DataValueField = "id",
                    ModelDataTextField = "",
                    ColumnName = "REFid",
                    AllModelDataTextField = new string[]{  })]
        [Title("isoMsg__Title", "Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources, Dictionaries, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
        [ForeignKeyValidSelection(
            DataContextType = typeof(BanksGateDataModel.Models.DataContext), 
            GenericType = typeof(BanksGateDataModel.Models.isoMsg), 
            ViewModelType = typeof(Dictionaries.Areas.DIC.ViewModels.isoMsgMinimalViewModel), 
            MethodName = nameof(REFid_AccessFilter),
            ErrorMessageResourceType = typeof(ValidationResources), 
            ErrorMessageResourceName = nameof(ValidationResources.InvalidFieldSelection))]
        public Int64 REFid { get; set; }
        
        partial void REFid_AccessFilter(AccessDataContext<Dictionaries.Areas.DIC.ViewModels.isoPaymentViewModel> context);

        /// <summary>
        ///     state.
        ///     <remarks>
        ///         Статус сообщение платежа.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.state__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.state__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        public Int32? state { get; set; }

        /// <summary>
        ///     isBreaked.
        ///     <remarks>
        ///         isBreaked.
        ///     </remarks>
        /// </summary>
        [UIHint("Boolean")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.isBreaked__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.isBreaked__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [DisplayExtended(ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources), BooleanTextTrue = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.isBreaked__TrueText), BooleanTextFalse = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.isBreaked__FalseText))]
        public Boolean? isBreaked { get; set; }

        /// <summary>
        ///     grpMsgId.
        ///     <remarks>
        ///         grpMsgId.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpMsgId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpMsgId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(35, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String grpMsgId { get; set; }

        /// <summary>
        ///     txnId.
        ///     <remarks>
        ///         txnId.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.txnId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.txnId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(35, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String txnId { get; set; }

        /// <summary>
        ///     endToEndId.
        ///     <remarks>
        ///         endToEndId.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.endToEndId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.endToEndId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(35, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String endToEndId { get; set; }

        /// <summary>
        ///     uetrId.
        ///     <remarks>
        ///         uetrId.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.uetrId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.uetrId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(36, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String uetrId { get; set; }

        /// <summary>
        ///     grpCreDtTm.
        ///     <remarks>
        ///         Время создания платежа.
        ///     </remarks>
        /// </summary>
        [UIHint("DateTime")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpCreDtTm__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpCreDtTm__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        [DataType(DataType.DateTime)]
        public DateTime? grpCreDtTm { get; set; }

        /// <summary>
        ///     grpBtchBookg.
        ///     <remarks>
        ///         BatchBook.
        ///     </remarks>
        /// </summary>
        [UIHint("Byte")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpBtchBookg__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpBtchBookg__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        public Byte? grpBtchBookg { get; set; }

        /// <summary>
        ///     grpNbOfTxs.
        ///     <remarks>
        ///         Вложенных платежей.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpNbOfTxs__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpNbOfTxs__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        public Int32? grpNbOfTxs { get; set; }

        /// <summary>
        ///     grpTtlIntrBkSttlmAmt.
        ///     <remarks>
        ///         Сумма.
        ///     </remarks>
        /// </summary>
        [UIHint("Decimal")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpTtlIntrBkSttlmAmt__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpTtlIntrBkSttlmAmt__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        [RangeDecimal("-99999999999999999.99", "99999999999999999.99",
            ErrorMessageResourceType = typeof(ValidationResources), 
            ErrorMessageResourceName = nameof(ValidationResources.RangeAttribute_ValidationError))]
        public Decimal? grpTtlIntrBkSttlmAmt { get; set; }

        /// <summary>
        ///     ccy.
        ///     <remarks>
        ///         Ссу.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.ccy__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.ccy__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String ccy { get; set; }

        /// <summary>
        ///     grpDate.
        ///     <remarks>
        ///         Операционная дата платежа.
        ///     </remarks>
        /// </summary>
        [UIHint("Date")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpDate__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpDate__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? grpDate { get; set; }

        /// <summary>
        ///     grpSender.
        ///     <remarks>
        ///         grpSender.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpSender__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpSender__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(8, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String grpSender { get; set; }

        /// <summary>
        ///     grpAddressee.
        ///     <remarks>
        ///         grpAddressee.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpAddressee__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.grpAddressee__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(8, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String grpAddressee { get; set; }

        /// <summary>
        ///     chrgBr.
        ///     <remarks>
        ///         Комиссия.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.chrgBr__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.chrgBr__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(4, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String chrgBr { get; set; }

        /// <summary>
        ///     dbtrNm.
        ///     <remarks>
        ///         Наименование отправителя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrNm__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrNm__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(140, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String dbtrNm { get; set; }

        /// <summary>
        ///     dbtrSeco.
        ///     <remarks>
        ///         Сектор экономики отправителя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrSeco__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrSeco__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String dbtrSeco { get; set; }

        /// <summary>
        ///     dbtrIrs.
        ///     <remarks>
        ///         Резиденство отправителя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrIrs__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrIrs__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String dbtrIrs { get; set; }

        /// <summary>
        ///     dbtrAccountant.
        ///     <remarks>
        ///         Главный бухгалтер отправителя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrAccountant__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrAccountant__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(140, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String dbtrAccountant { get; set; }

        /// <summary>
        ///     dbtrHead.
        ///     <remarks>
        ///         Руководитель отправителя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrHead__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrHead__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(140, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String dbtrHead { get; set; }

        /// <summary>
        ///     dbtrIdn.
        ///     <remarks>
        ///         ИИН, БИН отправителя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrIdn__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrIdn__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(12, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String dbtrIdn { get; set; }

        /// <summary>
        ///     dbtrCtryOfRes.
        ///     <remarks>
        ///         Страна резиденства отправителя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrCtryOfRes__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrCtryOfRes__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(2, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String dbtrCtryOfRes { get; set; }

        /// <summary>
        ///     dbtrAcct.
        ///     <remarks>
        ///         Счет отправителя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrAcct__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrAcct__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(20, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String dbtrAcct { get; set; }

        /// <summary>
        ///     dbtrAgt.
        ///     <remarks>
        ///         Бик отправителя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrAgt__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtrAgt__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(8, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String dbtrAgt { get; set; }

        /// <summary>
        ///     dbtr.
        ///     <remarks>
        ///         отправитель.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtr__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.dbtr__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(8, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String dbtr { get; set; }

        /// <summary>
        ///     cdtr.
        ///     <remarks>
        ///         получатель.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtr__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtr__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(8, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String cdtr { get; set; }

        /// <summary>
        ///     cdtrNm.
        ///     <remarks>
        ///         Наименование получателя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrNm__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrNm__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(140, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String cdtrNm { get; set; }

        /// <summary>
        ///     cdtrSeco.
        ///     <remarks>
        ///         Сектор экономики получателя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrSeco__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrSeco__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String cdtrSeco { get; set; }

        /// <summary>
        ///     cdtrIrs.
        ///     <remarks>
        ///         Резиденство получателя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrIrs__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrIrs__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String cdtrIrs { get; set; }

        /// <summary>
        ///     cdtrAccountant.
        ///     <remarks>
        ///         Главный бухгалтер получателя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrAccountant__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrAccountant__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(140, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String cdtrAccountant { get; set; }

        /// <summary>
        ///     cdtrHead.
        ///     <remarks>
        ///         Руководитель получателя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrHead__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrHead__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(140, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String cdtrHead { get; set; }

        /// <summary>
        ///     cdtrIdn.
        ///     <remarks>
        ///         ИИН, БИН получателя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrIdn__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrIdn__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(12, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String cdtrIdn { get; set; }

        /// <summary>
        ///     cdtrCtryOfRes.
        ///     <remarks>
        ///         Страна резиденства получателя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrCtryOfRes__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrCtryOfRes__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(2, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String cdtrCtryOfRes { get; set; }

        /// <summary>
        ///     cdtrAcct.
        ///     <remarks>
        ///         Счет получателя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrAcct__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrAcct__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(20, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String cdtrAcct { get; set; }

        /// <summary>
        ///     cdtrAgt.
        ///     <remarks>
        ///         Бик получателя.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrAgt__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrAgt__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(8, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String cdtrAgt { get; set; }

        /// <summary>
        ///     cdtrAgtAcct.
        ///     <remarks>
        ///         cdtrAgtAcct.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrAgtAcct__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrAgtAcct__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(20, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String cdtrAgtAcct { get; set; }

        /// <summary>
        ///     cdtrAgtAcctTp.
        ///     <remarks>
        ///         cdtrAgtAcctTp.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrAgtAcctTp__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrAgtAcctTp__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(20, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String cdtrAgtAcctTp { get; set; }

        /// <summary>
        ///     cdtrKnp.
        ///     <remarks>
        ///         КНП.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrKnp__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrKnp__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String cdtrKnp { get; set; }

        /// <summary>
        ///     cdtrNb.
        ///     <remarks>
        ///         Номер документа.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrNb__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrNb__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(35, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String cdtrNb { get; set; }

        /// <summary>
        ///     cdtrRltdDt.
        ///     <remarks>
        ///         Дата документа.
        ///     </remarks>
        /// </summary>
        [UIHint("Date")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrRltdDt__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.cdtrRltdDt__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? cdtrRltdDt { get; set; }

        /// <summary>
        ///     instrPrty.
        ///     <remarks>
        ///         instrPrty.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.instrPrty__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.instrPrty__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(4, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String instrPrty { get; set; }

        /// <summary>
        ///     instrLc.
        ///     <remarks>
        ///         instrLc.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.instrLc__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.instrLc__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(2, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String instrLc { get; set; }

        /// <summary>
        ///     orgBookAcc.
        ///     <remarks>
        ///         orgBookAcc.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.orgBookAcc__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.orgBookAcc__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String orgBookAcc { get; set; }

        /// <summary>
        ///     body.
        ///     <remarks>
        ///         body.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.body__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.body__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        public String body { get; set; }

        /// <summary>
        ///     isVolpay.
        ///     <remarks>
        ///         isVolpay.
        ///     </remarks>
        /// </summary>
        [UIHint("Boolean")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.isVolpay__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.isVolpay__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [DisplayExtended(ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources), BooleanTextTrue = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.isVolpay__TrueText), BooleanTextFalse = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.isVolpay__FalseText))]
        public Boolean? isVolpay { get; set; }

        /// <summary>
        ///     sts.
        ///     <remarks>
        ///         sts.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.sts__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.sts__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(4, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String sts { get; set; }

        /// <summary>
        ///     stsRelation.
        ///     <remarks>
        ///         stsRelation.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.stsRelation__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.stsRelation__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(35, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String stsRelation { get; set; }

        /// <summary>
        ///     amntEq.
        ///     <remarks>
        ///         amntEq.
        ///     </remarks>
        /// </summary>
        [UIHint("Decimal")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.amntEq__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.amntEq__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        [RangeDecimal("-99999999999999999.99", "99999999999999999.99",
            ErrorMessageResourceType = typeof(ValidationResources), 
            ErrorMessageResourceName = nameof(ValidationResources.RangeAttribute_ValidationError))]
        public Decimal? amntEq { get; set; }

        /// <summary>
        ///     accCls.
        ///     <remarks>
        ///         accCls.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.accCls__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.accCls__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(7, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String accCls { get; set; }

        /// <summary>
        ///     bclass.
        ///     <remarks>
        ///         КБК.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.bclass__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.bclass__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(6, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String bclass { get; set; }

        /// <summary>
        ///     asgn.
        ///     <remarks>
        ///         asgn.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.asgn__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.asgn__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        [StringLength(1024, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String asgn { get; set; }


        internal Dictionary<string, string> AccessFilterQueryParameters { get; set; }

        public static Expression<Func<isoPayment, isoPaymentViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<isoPayment, isoPaymentViewModel>> viewModel =
                r => new isoPaymentViewModel
                        {
                            id = r.id,
                            REFid = r.REFid,
                            state = r.state,
                            isBreaked = r.isBreaked,
                            grpMsgId = r.grpMsgId,
                            txnId = r.txnId,
                            endToEndId = r.endToEndId,
                            uetrId = r.uetrId,
                            grpCreDtTm = r.grpCreDtTm,
                            grpBtchBookg = r.grpBtchBookg,
                            grpNbOfTxs = r.grpNbOfTxs,
                            grpTtlIntrBkSttlmAmt = r.grpTtlIntrBkSttlmAmt,
                            ccy = r.ccy,
                            grpDate = r.grpDate,
                            grpSender = r.grpSender,
                            grpAddressee = r.grpAddressee,
                            chrgBr = r.chrgBr,
                            dbtrNm = r.dbtrNm,
                            dbtrSeco = r.dbtrSeco,
                            dbtrIrs = r.dbtrIrs,
                            dbtrAccountant = r.dbtrAccountant,
                            dbtrHead = r.dbtrHead,
                            dbtrIdn = r.dbtrIdn,
                            dbtrCtryOfRes = r.dbtrCtryOfRes,
                            dbtrAcct = r.dbtrAcct,
                            dbtrAgt = r.dbtrAgt,
                            dbtr = r.dbtr,
                            cdtr = r.cdtr,
                            cdtrNm = r.cdtrNm,
                            cdtrSeco = r.cdtrSeco,
                            cdtrIrs = r.cdtrIrs,
                            cdtrAccountant = r.cdtrAccountant,
                            cdtrHead = r.cdtrHead,
                            cdtrIdn = r.cdtrIdn,
                            cdtrCtryOfRes = r.cdtrCtryOfRes,
                            cdtrAcct = r.cdtrAcct,
                            cdtrAgt = r.cdtrAgt,
                            cdtrAgtAcct = r.cdtrAgtAcct,
                            cdtrAgtAcctTp = r.cdtrAgtAcctTp,
                            cdtrKnp = r.cdtrKnp,
                            cdtrNb = r.cdtrNb,
                            cdtrRltdDt = r.cdtrRltdDt,
                            instrPrty = r.instrPrty,
                            instrLc = r.instrLc,
                            orgBookAcc = r.orgBookAcc,
                            body = r.body,
                            isVolpay = r.isVolpay,
                            sts = r.sts,
                            stsRelation = r.stsRelation,
                            amntEq = r.amntEq,
                            accCls = r.accCls,
                            bclass = r.bclass,
                            asgn = r.asgn
                        };
        
            var builder = viewModel.ToBuilder(dbContext, httpContext)
                ;
            builder.AddAccessResult(r => r.CanDestroy, AccessFilterType.Delete, httpContext);
            builder.AddAccessResult(r => r.CanUpdate, AccessFilterType.Edit, httpContext);
            return builder.ToExpression();
        }
        
        partial void OnCreateOrUpdate(isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller);
        partial void OnCreateOrUpdate(isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(isoPaymentViewModel newViewModel, isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(isoPaymentViewModel newViewModel, isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreate(isoPayment item, DataContext dbContext, Controller controller);
        partial void OnCreate(isoPayment item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool cancel);
        partial void OnCreated(isoPayment item, DataContext dbContext, Controller controller);
        partial void OnCreated(isoPayment item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreated(isoPaymentViewModel newViewModel, isoPayment item, DataContext dbContext, Controller controller);
        partial void OnCreated(isoPaymentViewModel newViewModel, isoPayment item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedLog(isoPaymentViewModel newViewModel, isoPayment item, DataContext dbContext, Controller controller, ref string typeCode);
        partial void OnAllowCreate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public isoPaymentViewModel Create(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<isoPayment, DataContext, Controller> onCreate = null)
        {
            var allowCreate = true;
            OnAllowCreate(ref allowCreate, dbContext, controller, eventLogManager);
            if (!allowCreate) return this;
            
            var item = new isoPayment();
            item.id = this.id;
            item.REFid = this.REFid;
            item.state = this.state;
            item.isBreaked = this.isBreaked;
            item.grpMsgId = this.grpMsgId;
            item.txnId = this.txnId;
            item.endToEndId = this.endToEndId;
            item.uetrId = this.uetrId;
            item.grpCreDtTm = this.grpCreDtTm;
            item.grpBtchBookg = this.grpBtchBookg;
            item.grpNbOfTxs = this.grpNbOfTxs;
            item.grpTtlIntrBkSttlmAmt = this.grpTtlIntrBkSttlmAmt;
            item.ccy = this.ccy;
            item.grpDate = this.grpDate;
            item.grpSender = this.grpSender;
            item.grpAddressee = this.grpAddressee;
            item.chrgBr = this.chrgBr;
            item.dbtrNm = this.dbtrNm;
            item.dbtrSeco = this.dbtrSeco;
            item.dbtrIrs = this.dbtrIrs;
            item.dbtrAccountant = this.dbtrAccountant;
            item.dbtrHead = this.dbtrHead;
            item.dbtrIdn = this.dbtrIdn;
            item.dbtrCtryOfRes = this.dbtrCtryOfRes;
            item.dbtrAcct = this.dbtrAcct;
            item.dbtrAgt = this.dbtrAgt;
            item.dbtr = this.dbtr;
            item.cdtr = this.cdtr;
            item.cdtrNm = this.cdtrNm;
            item.cdtrSeco = this.cdtrSeco;
            item.cdtrIrs = this.cdtrIrs;
            item.cdtrAccountant = this.cdtrAccountant;
            item.cdtrHead = this.cdtrHead;
            item.cdtrIdn = this.cdtrIdn;
            item.cdtrCtryOfRes = this.cdtrCtryOfRes;
            item.cdtrAcct = this.cdtrAcct;
            item.cdtrAgt = this.cdtrAgt;
            item.cdtrAgtAcct = this.cdtrAgtAcct;
            item.cdtrAgtAcctTp = this.cdtrAgtAcctTp;
            item.cdtrKnp = this.cdtrKnp;
            item.cdtrNb = this.cdtrNb;
            item.cdtrRltdDt = this.cdtrRltdDt;
            item.instrPrty = this.instrPrty;
            item.instrLc = this.instrLc;
            item.orgBookAcc = this.orgBookAcc;
            item.body = this.body;
            item.isVolpay = this.isVolpay;
            item.sts = this.sts;
            item.stsRelation = this.stsRelation;
            item.amntEq = this.amntEq;
            item.accCls = this.accCls;
            item.bclass = this.bclass;
            item.asgn = this.asgn;
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
            if (!dbContext.SaveChanges<isoPayment>(controller, eventLogManager))
                return this;
        
            OnCreatedOrUpdated(null, item, dbContext, controller);
            OnCreatedOrUpdated(null, item, dbContext, controller, eventLogManager);
            OnCreated(item, dbContext, controller);
            OnCreated(item, dbContext, controller, eventLogManager);
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var newViewModel = dbContext.Set<isoPayment>().AsQueryable().Select(ViewModel(httpContext, dbContext)).FirstOrDefault(r => r.id == item.id);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller, eventLogManager);
            OnCreated(newViewModel, item, dbContext, controller);
            OnCreated(newViewModel, item, dbContext, controller, eventLogManager);
            var typeCode = "Create";
            OnCreatedLog(newViewModel, item, dbContext, controller, ref typeCode);
            eventLogManager?.LogChanges<DataContext, isoPaymentViewModel>(controller, null, newViewModel, typeCode: typeCode);
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanUpdate { get; set; }
        
        partial void OnUpdateGetOldViewModel(ref isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller);
        partial void OnUpdate(isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller);
        partial void OnUpdate(isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateBeforeSave(isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller);
        partial void OnUpdateBegin(isoPaymentViewModel oldViewModel, ref isoPayment item, DataContext dbContext, Controller controller);
        partial void OnUpdated(isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller);
        partial void OnUpdated(isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdated(isoPaymentViewModel newViewModel, isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller);
        partial void OnUpdated(isoPaymentViewModel newViewModel, isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateNoChanges(ref bool cancelExecution, isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller);
        partial void OnAllowUpdate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public isoPaymentViewModel Update(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<isoPaymentViewModel, isoPayment, DataContext, Controller> onUpdate = null, bool validateAccess = true)
        {
            var allowUpdate = true;
            OnAllowUpdate(ref allowUpdate, dbContext, controller, eventLogManager);
            if (!allowUpdate) return this;
            
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<isoPayment>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(isoPaymentViewModel), queryParameters: AccessFilterQueryParameters).FirstOrDefault(r => this.id == r.id);
            isoPaymentViewModel oldViewModel = null;
            bool hasChanges;
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<isoPayment>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.EditAndRead, controller?.ModelState, modelView: typeof(isoPaymentViewModel), queryParameters: AccessFilterQueryParameters))
                    return this;
        
                OnUpdateGetOldViewModel(ref oldViewModel, item, dbContext, controller);
                if (oldViewModel == null)
                    oldViewModel = dbContext.Set<isoPayment>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(isoPaymentViewModel), queryParameters: AccessFilterQueryParameters).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                OnUpdateBegin(oldViewModel, ref item, dbContext, controller);
                item.id = this.id;
                item.REFid = this.REFid;
                item.state = this.state;
                item.isBreaked = this.isBreaked;
                item.grpMsgId = this.grpMsgId;
                item.txnId = this.txnId;
                item.endToEndId = this.endToEndId;
                item.uetrId = this.uetrId;
                item.grpCreDtTm = this.grpCreDtTm;
                item.grpBtchBookg = this.grpBtchBookg;
                item.grpNbOfTxs = this.grpNbOfTxs;
                item.grpTtlIntrBkSttlmAmt = this.grpTtlIntrBkSttlmAmt;
                item.ccy = this.ccy;
                item.grpDate = this.grpDate;
                item.grpSender = this.grpSender;
                item.grpAddressee = this.grpAddressee;
                item.chrgBr = this.chrgBr;
                item.dbtrNm = this.dbtrNm;
                item.dbtrSeco = this.dbtrSeco;
                item.dbtrIrs = this.dbtrIrs;
                item.dbtrAccountant = this.dbtrAccountant;
                item.dbtrHead = this.dbtrHead;
                item.dbtrIdn = this.dbtrIdn;
                item.dbtrCtryOfRes = this.dbtrCtryOfRes;
                item.dbtrAcct = this.dbtrAcct;
                item.dbtrAgt = this.dbtrAgt;
                item.dbtr = this.dbtr;
                item.cdtr = this.cdtr;
                item.cdtrNm = this.cdtrNm;
                item.cdtrSeco = this.cdtrSeco;
                item.cdtrIrs = this.cdtrIrs;
                item.cdtrAccountant = this.cdtrAccountant;
                item.cdtrHead = this.cdtrHead;
                item.cdtrIdn = this.cdtrIdn;
                item.cdtrCtryOfRes = this.cdtrCtryOfRes;
                item.cdtrAcct = this.cdtrAcct;
                item.cdtrAgt = this.cdtrAgt;
                item.cdtrAgtAcct = this.cdtrAgtAcct;
                item.cdtrAgtAcctTp = this.cdtrAgtAcctTp;
                item.cdtrKnp = this.cdtrKnp;
                item.cdtrNb = this.cdtrNb;
                item.cdtrRltdDt = this.cdtrRltdDt;
                item.instrPrty = this.instrPrty;
                item.instrLc = this.instrLc;
                item.orgBookAcc = this.orgBookAcc;
                item.body = this.body;
                item.isVolpay = this.isVolpay;
                item.sts = this.sts;
                item.stsRelation = this.stsRelation;
                item.amntEq = this.amntEq;
                item.accCls = this.accCls;
                item.bclass = this.bclass;
                item.asgn = this.asgn;
        
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
                if (!dbContext.SaveChanges<isoPayment>(controller, eventLogManager))
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
            var newViewModel = dbContext.Set<isoPayment>().AsQueryable().Select(ViewModel(httpContext, dbContext)).Where(r => r.id == this.id).OrderByDescending(r => r.id).FirstOrDefault();
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            if (hasChanges)
                eventLogManager?.LogChanges<DataContext, isoPaymentViewModel>(controller, oldViewModel, newViewModel, typeCode: "Update");
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanDestroy { get; set; }
        
        partial void OnDestroy(isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller, ref bool remove);
        partial void OnDestroy(isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool remove);
        partial void OnDestroyed(isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller);
        partial void OnDestroyed(isoPaymentViewModel oldViewModel, isoPayment item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        void IViewModelDestroy<DataContext, isoPaymentViewModel, isoPayment>.Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, isoPaymentViewModel, isoPayment> onDestroy)
        {
            Destroy(dbContext, controller, eventLogManager, onDestroy);
        }
        
        public void Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, isoPaymentViewModel, isoPayment> onDestroy = null, bool validateAccess = true)
        {
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<isoPayment>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(isoPaymentViewModel), queryParameters: AccessFilterQueryParameters).FirstOrDefault(r => this.id == r.id);
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<isoPayment>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.DeleteAndRead, controller?.ModelState, validationKey: "CancelDelete", modelView: typeof(isoPaymentViewModel), queryParameters: AccessFilterQueryParameters))
                    return;
        
                var oldViewModel = dbContext.Set<isoPayment>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(isoPaymentViewModel), queryParameters: AccessFilterQueryParameters).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                var remove = true;
                OnDestroy(oldViewModel, item, dbContext, controller, ref remove);
                OnDestroy(oldViewModel, item, dbContext, controller, eventLogManager, ref remove);
                remove = onDestroy?.Invoke(item, dbContext, controller, eventLogManager, remove) ?? remove;
        
                if (remove && (controller == null || controller.ModelState.IsValid))
                {
                    dbContext.Remove(item);
                    if (dbContext.SaveChanges<isoPayment>(controller, eventLogManager, validationKey: "CancelDelete"))
                    {
                        eventLogManager?.LogChanges<DataContext, isoPaymentViewModel>(controller, oldViewModel, null, typeCode: "Destroy");
                        OnDestroyed(oldViewModel, item, dbContext, controller);
                        OnDestroyed(oldViewModel, item, dbContext, controller, eventLogManager);
                    }
                }
            }
        }
        
        
        
        public string GetLogMessage()
        {
            return state.ToString()+ ", " +grpMsgId+ ", " +txnId+ ", " +endToEndId+ ", " +uetrId+ ", " +(grpCreDtTm == null ? "" : string.Format("{0:dd.MM.yyyy HH:mm}", grpCreDtTm))+ ", " +grpBtchBookg.ToString()+ ", " +grpNbOfTxs.ToString()+ ", " +grpTtlIntrBkSttlmAmt.ToString()+ ", " +ccy+ ", " +(grpDate == null ? "" : string.Format("{0:dd.MM.yyyy}", grpDate))+ ", " +grpSender+ ", " +grpAddressee+ ", " +chrgBr+ ", " +dbtrNm+ ", " +dbtrSeco+ ", " +dbtrIrs+ ", " +dbtrAccountant+ ", " +dbtrHead+ ", " +dbtrIdn+ ", " +dbtrCtryOfRes+ ", " +dbtrAcct+ ", " +dbtrAgt+ ", " +dbtr+ ", " +cdtr+ ", " +cdtrNm+ ", " +cdtrSeco+ ", " +cdtrIrs+ ", " +cdtrAccountant+ ", " +cdtrHead+ ", " +cdtrIdn+ ", " +cdtrCtryOfRes+ ", " +cdtrAcct+ ", " +cdtrAgt+ ", " +cdtrAgtAcct+ ", " +cdtrAgtAcctTp+ ", " +cdtrKnp+ ", " +cdtrNb+ ", " +(cdtrRltdDt == null ? "" : string.Format("{0:dd.MM.yyyy}", cdtrRltdDt))+ ", " +instrPrty+ ", " +instrLc+ ", " +orgBookAcc+ ", " +body+ ", " +sts+ ", " +stsRelation+ ", " +amntEq.ToString()+ ", " +accCls+ ", " +bclass+ ", " +asgn;
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
    ///     isoPaymentMinimal. Представление таблицы isoPayment (isoPayment).
    ///     <remarks>
    ///         Платеж.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Платеж")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICisoPayment", Title = "Платеж")][EventLogGroupAttribute(ParentCode = "DICisoPayment")]
    public partial class isoPaymentMinimalViewModel
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         payId.
        ///     </remarks>
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        [Editable(false)]
        [ScaffoldColumn(false)]
        [UIHint("Int64")]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoPaymentResources))]
        public Int64 id { get; set; }


        internal Dictionary<string, string> AccessFilterQueryParameters { get; set; }

        public static Expression<Func<isoPayment, isoPaymentMinimalViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<isoPayment, isoPaymentMinimalViewModel>> viewModel =
                r => new isoPaymentMinimalViewModel
                        {
                            id = r.id
                        };
        
            return viewModel;
        }
    }
}