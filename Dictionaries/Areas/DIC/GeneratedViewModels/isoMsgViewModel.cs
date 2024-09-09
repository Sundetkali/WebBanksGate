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
    ///     isoMsg. Представление таблицы isoMsg (isoMsg).
    ///     <remarks>
    ///         Сообщение.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Сообщение")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICisoMsg", Title = "Сообщение")][EventLogGroupAttribute(ParentCode = "DICisoMsg")]
    public partial class isoMsgViewModel : IViewModelUpdate<DataContext, isoMsgViewModel, isoMsg>, IViewModelCreate<DataContext, isoMsgViewModel, isoMsg>, IViewModelDestroy<DataContext, isoMsgViewModel, isoMsg>, IViewModelLogMessage<DataContext>
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         msgId.
        ///     </remarks>
        /// </summary>
        [ScaffoldColumn(false)]
        [UIHint("Int64")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        public Int64 id { get; set; }

        /// <summary>
        ///     REFusrId.
        ///     <remarks>
        ///         Владелец.
        ///     </remarks>
        /// </summary>
        [UIHint("Int64")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.REFusrId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.REFusrId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        public Int64? REFusrId { get; set; }

        /// <summary>
        ///     parentMsgId.
        ///     <remarks>
        ///         parentMsgId.
        ///     </remarks>
        /// </summary>
        [UIHint("Int64")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.parentMsgId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.parentMsgId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        public Int64? parentMsgId { get; set; }

        /// <summary>
        ///     bizId.
        ///     <remarks>
        ///         bizMSGId.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.bizId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.bizId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [StringLength(35, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String bizId { get; set; }

        /// <summary>
        ///     grpMsgId.
        ///     <remarks>
        ///         grpMsgId.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.grpMsgId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.grpMsgId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [StringLength(35, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String grpMsgId { get; set; }

        /// <summary>
        ///     msgPurpose.
        ///     <remarks>
        ///         Тип платежа.
        ///     </remarks>
        /// </summary>
        [UIHint("Byte")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgPurpose__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgPurpose__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        public Byte? msgPurpose { get; set; }

        /// <summary>
        ///     msgDir.
        ///     <remarks>
        ///         Направление.
        ///     </remarks>
        /// </summary>
        [UIHint("Byte")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgDir__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgDir__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        public Byte? msgDir { get; set; }

        /// <summary>
        ///     msgType.
        ///     <remarks>
        ///         Тип МХ.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgType__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgType__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        public Int32? msgType { get; set; }

        /// <summary>
        ///     msgTypeVer.
        ///     <remarks>
        ///         msgTypeVer.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgTypeVer__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgTypeVer__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [StringLength(16, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String msgTypeVer { get; set; }

        /// <summary>
        ///     msgError.
        ///     <remarks>
        ///         msgError.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgError__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgError__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String msgError { get; set; }

        /// <summary>
        ///     state.
        ///     <remarks>
        ///         state.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.state__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.state__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        public Int32? state { get; set; }

        /// <summary>
        ///     sysDate.
        ///     <remarks>
        ///         Системная дата импорта.
        ///     </remarks>
        /// </summary>
        [UIHint("Date")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.sysDate__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.sysDate__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? sysDate { get; set; }

        /// <summary>
        ///     sysTm.
        ///     <remarks>
        ///         Системное время импорта.
        ///     </remarks>
        /// </summary>
        [UIHint("DateTime")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.sysTm__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.sysTm__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        [DataType(DataType.DateTime)]
        public DateTime? sysTm { get; set; }

        /// <summary>
        ///     sender.
        ///     <remarks>
        ///         sender.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.sender__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.sender__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [StringLength(8, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String sender { get; set; }

        /// <summary>
        ///     addressee.
        ///     <remarks>
        ///         addressee.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.addressee__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.addressee__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [StringLength(8, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String addressee { get; set; }

        /// <summary>
        ///     rootTag.
        ///     <remarks>
        ///         rootTag.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.rootTag__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.rootTag__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [StringLength(64, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String rootTag { get; set; }

        /// <summary>
        ///     stmp.
        ///     <remarks>
        ///         stmp.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.stmp__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.stmp__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String stmp { get; set; }

        /// <summary>
        ///     stmpApp.
        ///     <remarks>
        ///         Источник.
        ///     </remarks>
        /// </summary>
        [UIHint("Byte")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.stmpApp__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.stmpApp__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        public Byte? stmpApp { get; set; }

        /// <summary>
        ///     sprtry.
        ///     <remarks>
        ///         sprtry.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.sprtry__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.sprtry__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [StringLength(5, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String sprtry { get; set; }

        /// <summary>
        ///     aprtry.
        ///     <remarks>
        ///         aprtry.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.aprtry__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.aprtry__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [StringLength(5, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String aprtry { get; set; }

        /// <summary>
        ///     mprty.
        ///     <remarks>
        ///         mprty.
        ///     </remarks>
        /// </summary>
        [UIHint("Byte")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.mprty__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.mprty__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        public Byte? mprty { get; set; }

        /// <summary>
        ///     mdate.
        ///     <remarks>
        ///         mdate.
        ///     </remarks>
        /// </summary>
        [UIHint("DateTime")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.mdate__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.mdate__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm}")]
        [DataType(DataType.DateTime)]
        public DateTime? mdate { get; set; }

        /// <summary>
        ///     swtMsg.
        ///     <remarks>
        ///         swtMsg.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.swtMsg__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.swtMsg__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        public Int32? swtMsg { get; set; }

        /// <summary>
        ///     isVolpay.
        ///     <remarks>
        ///         isVolpay.
        ///     </remarks>
        /// </summary>
        [UIHint("Boolean")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.isVolpay__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.isVolpay__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [DisplayExtended(ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources), BooleanTextTrue = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.isVolpay__TrueText), BooleanTextFalse = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.isVolpay__FalseText))]
        public Boolean? isVolpay { get; set; }

        /// <summary>
        ///     msgAmount.
        ///     <remarks>
        ///         msgAmount.
        ///     </remarks>
        /// </summary>
        [UIHint("Decimal")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgAmount__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgAmount__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [DisplayFormat(DataFormatString = "{0:n2}")]
        [RangeDecimal("-99999999999999999.99", "99999999999999999.99",
            ErrorMessageResourceType = typeof(ValidationResources), 
            ErrorMessageResourceName = nameof(ValidationResources.RangeAttribute_ValidationError))]
        public Decimal? msgAmount { get; set; }

        /// <summary>
        ///     msgTerminal.
        ///     <remarks>
        ///         Платежная система.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgTerminal__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgTerminal__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [StringLength(8, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String msgTerminal { get; set; }

        /// <summary>
        ///     rsPrt.
        ///     <remarks>
        ///         rsPrt.
        ///     </remarks>
        /// </summary>
        [UIHint("Byte")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.rsPrt__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.rsPrt__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        public Byte? rsPrt { get; set; }

        /// <summary>
        ///     oprDate.
        ///     <remarks>
        ///         oprDate.
        ///     </remarks>
        /// </summary>
        [UIHint("Date")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.oprDate__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.oprDate__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime? oprDate { get; set; }

        /// <summary>
        ///     msgComment.
        ///     <remarks>
        ///         msgComment.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgComment__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.msgComment__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        [StringLength(256, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String msgComment { get; set; }


        internal Dictionary<string, string> AccessFilterQueryParameters { get; set; }

        public static Expression<Func<isoMsg, isoMsgViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<isoMsg, isoMsgViewModel>> viewModel =
                r => new isoMsgViewModel
                        {
                            id = r.id,
                            REFusrId = r.REFusrId,
                            parentMsgId = r.parentMsgId,
                            bizId = r.bizId,
                            grpMsgId = r.grpMsgId,
                            msgPurpose = r.msgPurpose,
                            msgDir = r.msgDir,
                            msgType = r.msgType,
                            msgTypeVer = r.msgTypeVer,
                            msgError = r.msgError,
                            state = r.state,
                            sysDate = r.sysDate,
                            sysTm = r.sysTm,
                            sender = r.sender,
                            addressee = r.addressee,
                            rootTag = r.rootTag,
                            stmp = r.stmp,
                            stmpApp = r.stmpApp,
                            sprtry = r.sprtry,
                            aprtry = r.aprtry,
                            mprty = r.mprty,
                            mdate = r.mdate,
                            swtMsg = r.swtMsg,
                            isVolpay = r.isVolpay,
                            msgAmount = r.msgAmount,
                            msgTerminal = r.msgTerminal,
                            rsPrt = r.rsPrt,
                            oprDate = r.oprDate,
                            msgComment = r.msgComment
                        };
        
            var builder = viewModel.ToBuilder(dbContext, httpContext);
            builder.AddAccessResult(r => r.CanDestroy, AccessFilterType.Delete, httpContext);
            builder.AddAccessResult(r => r.CanUpdate, AccessFilterType.Edit, httpContext);
            return builder.ToExpression();
        }
        
        partial void OnCreateOrUpdate(isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller);
        partial void OnCreateOrUpdate(isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(isoMsgViewModel newViewModel, isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(isoMsgViewModel newViewModel, isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreate(isoMsg item, DataContext dbContext, Controller controller);
        partial void OnCreate(isoMsg item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool cancel);
        partial void OnCreated(isoMsg item, DataContext dbContext, Controller controller);
        partial void OnCreated(isoMsg item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreated(isoMsgViewModel newViewModel, isoMsg item, DataContext dbContext, Controller controller);
        partial void OnCreated(isoMsgViewModel newViewModel, isoMsg item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedLog(isoMsgViewModel newViewModel, isoMsg item, DataContext dbContext, Controller controller, ref string typeCode);
        partial void OnAllowCreate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public isoMsgViewModel Create(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<isoMsg, DataContext, Controller> onCreate = null)
        {
            var allowCreate = true;
            OnAllowCreate(ref allowCreate, dbContext, controller, eventLogManager);
            if (!allowCreate) return this;
            
            var item = new isoMsg();
            item.id = this.id;
            item.REFusrId = this.REFusrId;
            item.parentMsgId = this.parentMsgId;
            item.bizId = this.bizId;
            item.grpMsgId = this.grpMsgId;
            item.msgPurpose = this.msgPurpose;
            item.msgDir = this.msgDir;
            item.msgType = this.msgType;
            item.msgTypeVer = this.msgTypeVer;
            item.msgError = this.msgError;
            item.state = this.state;
            item.sysDate = this.sysDate;
            item.sysTm = this.sysTm;
            item.sender = this.sender;
            item.addressee = this.addressee;
            item.rootTag = this.rootTag;
            item.stmp = this.stmp;
            item.stmpApp = this.stmpApp;
            item.sprtry = this.sprtry;
            item.aprtry = this.aprtry;
            item.mprty = this.mprty;
            item.mdate = this.mdate;
            item.swtMsg = this.swtMsg;
            item.isVolpay = this.isVolpay;
            item.msgAmount = this.msgAmount;
            item.msgTerminal = this.msgTerminal;
            item.rsPrt = this.rsPrt;
            item.oprDate = this.oprDate;
            item.msgComment = this.msgComment;
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
            if (!dbContext.SaveChanges<isoMsg>(controller, eventLogManager))
                return this;
        
            OnCreatedOrUpdated(null, item, dbContext, controller);
            OnCreatedOrUpdated(null, item, dbContext, controller, eventLogManager);
            OnCreated(item, dbContext, controller);
            OnCreated(item, dbContext, controller, eventLogManager);
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var newViewModel = dbContext.Set<isoMsg>().AsQueryable().Select(ViewModel(httpContext, dbContext)).FirstOrDefault(r => r.id == item.id);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller, eventLogManager);
            OnCreated(newViewModel, item, dbContext, controller);
            OnCreated(newViewModel, item, dbContext, controller, eventLogManager);
            var typeCode = "Create";
            OnCreatedLog(newViewModel, item, dbContext, controller, ref typeCode);
            eventLogManager?.LogChanges<DataContext, isoMsgViewModel>(controller, null, newViewModel, typeCode: typeCode);
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanUpdate { get; set; }
        
        partial void OnUpdateGetOldViewModel(ref isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller);
        partial void OnUpdate(isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller);
        partial void OnUpdate(isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateBeforeSave(isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller);
        partial void OnUpdateBegin(isoMsgViewModel oldViewModel, ref isoMsg item, DataContext dbContext, Controller controller);
        partial void OnUpdated(isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller);
        partial void OnUpdated(isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdated(isoMsgViewModel newViewModel, isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller);
        partial void OnUpdated(isoMsgViewModel newViewModel, isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateNoChanges(ref bool cancelExecution, isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller);
        partial void OnAllowUpdate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public isoMsgViewModel Update(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<isoMsgViewModel, isoMsg, DataContext, Controller> onUpdate = null, bool validateAccess = true)
        {
            var allowUpdate = true;
            OnAllowUpdate(ref allowUpdate, dbContext, controller, eventLogManager);
            if (!allowUpdate) return this;
            
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<isoMsg>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(isoMsgViewModel), queryParameters: AccessFilterQueryParameters).FirstOrDefault(r => this.id == r.id);
            isoMsgViewModel oldViewModel = null;
            bool hasChanges;
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<isoMsg>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.EditAndRead, controller?.ModelState, modelView: typeof(isoMsgViewModel), queryParameters: AccessFilterQueryParameters))
                    return this;
        
                OnUpdateGetOldViewModel(ref oldViewModel, item, dbContext, controller);
                if (oldViewModel == null)
                    oldViewModel = dbContext.Set<isoMsg>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(isoMsgViewModel), queryParameters: AccessFilterQueryParameters).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                OnUpdateBegin(oldViewModel, ref item, dbContext, controller);
                item.id = this.id;
                item.REFusrId = this.REFusrId;
                item.parentMsgId = this.parentMsgId;
                item.bizId = this.bizId;
                item.grpMsgId = this.grpMsgId;
                item.msgPurpose = this.msgPurpose;
                item.msgDir = this.msgDir;
                item.msgType = this.msgType;
                item.msgTypeVer = this.msgTypeVer;
                item.msgError = this.msgError;
                item.state = this.state;
                item.sysDate = this.sysDate;
                item.sysTm = this.sysTm;
                item.sender = this.sender;
                item.addressee = this.addressee;
                item.rootTag = this.rootTag;
                item.stmp = this.stmp;
                item.stmpApp = this.stmpApp;
                item.sprtry = this.sprtry;
                item.aprtry = this.aprtry;
                item.mprty = this.mprty;
                item.mdate = this.mdate;
                item.swtMsg = this.swtMsg;
                item.isVolpay = this.isVolpay;
                item.msgAmount = this.msgAmount;
                item.msgTerminal = this.msgTerminal;
                item.rsPrt = this.rsPrt;
                item.oprDate = this.oprDate;
                item.msgComment = this.msgComment;
        
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
                if (!dbContext.SaveChanges<isoMsg>(controller, eventLogManager))
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
            var newViewModel = dbContext.Set<isoMsg>().AsQueryable().Select(ViewModel(httpContext, dbContext)).Where(r => r.id == this.id).OrderByDescending(r => r.id).FirstOrDefault();
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            if (hasChanges)
                eventLogManager?.LogChanges<DataContext, isoMsgViewModel>(controller, oldViewModel, newViewModel, typeCode: "Update");
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanDestroy { get; set; }
        
        partial void OnDestroy(isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller, ref bool remove);
        partial void OnDestroy(isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool remove);
        partial void OnDestroyed(isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller);
        partial void OnDestroyed(isoMsgViewModel oldViewModel, isoMsg item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        void IViewModelDestroy<DataContext, isoMsgViewModel, isoMsg>.Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, isoMsgViewModel, isoMsg> onDestroy)
        {
            Destroy(dbContext, controller, eventLogManager, onDestroy);
        }
        
        public void Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, isoMsgViewModel, isoMsg> onDestroy = null, bool validateAccess = true)
        {
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<isoMsg>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(isoMsgViewModel), queryParameters: AccessFilterQueryParameters).FirstOrDefault(r => this.id == r.id);
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<isoMsg>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.DeleteAndRead, controller?.ModelState, validationKey: "CancelDelete", modelView: typeof(isoMsgViewModel), queryParameters: AccessFilterQueryParameters))
                    return;
        
                var oldViewModel = dbContext.Set<isoMsg>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(isoMsgViewModel), queryParameters: AccessFilterQueryParameters).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                var remove = true;
                OnDestroy(oldViewModel, item, dbContext, controller, ref remove);
                OnDestroy(oldViewModel, item, dbContext, controller, eventLogManager, ref remove);
                remove = onDestroy?.Invoke(item, dbContext, controller, eventLogManager, remove) ?? remove;
        
                if (remove && (controller == null || controller.ModelState.IsValid))
                {
                    dbContext.Remove(item);
                    if (dbContext.SaveChanges<isoMsg>(controller, eventLogManager, validationKey: "CancelDelete"))
                    {
                        eventLogManager?.LogChanges<DataContext, isoMsgViewModel>(controller, oldViewModel, null, typeCode: "Destroy");
                        OnDestroyed(oldViewModel, item, dbContext, controller);
                        OnDestroyed(oldViewModel, item, dbContext, controller, eventLogManager);
                    }
                }
            }
        }
        
        
        
        public string GetLogMessage()
        {
            return REFusrId.ToString()+ ", " +parentMsgId.ToString()+ ", " +bizId+ ", " +grpMsgId+ ", " +msgPurpose.ToString()+ ", " +msgDir.ToString()+ ", " +msgType.ToString()+ ", " +msgTypeVer+ ", " +msgError+ ", " +state.ToString()+ ", " +(sysDate == null ? "" : string.Format("{0:dd.MM.yyyy}", sysDate))+ ", " +(sysTm == null ? "" : string.Format("{0:dd.MM.yyyy HH:mm}", sysTm))+ ", " +sender+ ", " +addressee+ ", " +rootTag+ ", " +stmp+ ", " +stmpApp.ToString()+ ", " +sprtry+ ", " +aprtry+ ", " +mprty.ToString()+ ", " +(mdate == null ? "" : string.Format("{0:dd.MM.yyyy HH:mm}", mdate))+ ", " +swtMsg.ToString()+ ", " +msgAmount.ToString()+ ", " +msgTerminal+ ", " +rsPrt.ToString()+ ", " +(oprDate == null ? "" : string.Format("{0:dd.MM.yyyy}", oprDate))+ ", " +msgComment;
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
    ///     isoMsgMinimal. Представление таблицы isoMsg (isoMsg).
    ///     <remarks>
    ///         Сообщение.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Сообщение")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICisoMsg", Title = "Сообщение")][EventLogGroupAttribute(ParentCode = "DICisoMsg")]
    public partial class isoMsgMinimalViewModel
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         msgId.
        ///     </remarks>
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        [Editable(false)]
        [ScaffoldColumn(false)]
        [UIHint("Int64")]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.isoMsgResources))]
        public Int64 id { get; set; }


        internal Dictionary<string, string> AccessFilterQueryParameters { get; set; }

        public static Expression<Func<isoMsg, isoMsgMinimalViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<isoMsg, isoMsgMinimalViewModel>> viewModel =
                r => new isoMsgMinimalViewModel
                        {
                            id = r.id
                        };
        
            return viewModel;
        }
    }
}