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
    ///     MT950_TBL. Представление таблицы MT950_TBL (MT950_TBL).
    ///     <remarks>
    ///         Сообщение - МТ950.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Сообщение - МТ950")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICMT950_TBL", Title = "Сообщение - МТ950")][EventLogGroupAttribute(ParentCode = "DICMT950_TBL")]
    public partial class MT950_TBLViewModel : IViewModelUpdate<DataContext, MT950_TBLViewModel, MT950_TBL>, IViewModelCreate<DataContext, MT950_TBLViewModel, MT950_TBL>, IViewModelDestroy<DataContext, MT950_TBLViewModel, MT950_TBL>, IViewModelLogMessage<DataContext>
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         ID_EXTRACT.
        ///     </remarks>
        /// </summary>
        [ScaffoldColumn(false)]
        [UIHint("Decimal")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        [RangeDecimal("-999999999999999999", "999999999999999999",
            ErrorMessageResourceType = typeof(ValidationResources), 
            ErrorMessageResourceName = nameof(ValidationResources.RangeAttribute_ValidationError))]
        public Decimal id { get; set; }

        /// <summary>
        ///     REFERENSE.
        ///     <remarks>
        ///         REFERENSE.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.REFERENSE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.REFERENSE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [StringLength(16, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String REFERENSE { get; set; }

        /// <summary>
        ///     BIC.
        ///     <remarks>
        ///         BIC.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.BIC__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.BIC__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [StringLength(11, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String BIC { get; set; }

        /// <summary>
        ///     ACCOUNT.
        ///     <remarks>
        ///         ACCOUNT.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.ACCOUNT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.ACCOUNT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [StringLength(20, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String ACCOUNT { get; set; }

        /// <summary>
        ///     FNUM.
        ///     <remarks>
        ///         FNUM.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.FNUM__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.FNUM__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [StringLength(5, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String FNUM { get; set; }

        /// <summary>
        ///     FCOUNT.
        ///     <remarks>
        ///         FCOUNT.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.FCOUNT__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.FCOUNT__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [StringLength(5, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String FCOUNT { get; set; }

        /// <summary>
        ///     FSTART.
        ///     <remarks>
        ///         FSTART.
        ///     </remarks>
        /// </summary>
        [UIHint("Decimal")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.FSTART__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.FSTART__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [RangeDecimal("-9999999999", "9999999999",
            ErrorMessageResourceType = typeof(ValidationResources), 
            ErrorMessageResourceName = nameof(ValidationResources.RangeAttribute_ValidationError))]
        public Decimal? FSTART { get; set; }

        /// <summary>
        ///     OPER_A.
        ///     <remarks>
        ///         OPER_A.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.OPER_A__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.OPER_A__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String OPER_A { get; set; }

        /// <summary>
        ///     DATE_A.
        ///     <remarks>
        ///         DATE_A.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.DATE_A__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.DATE_A__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [StringLength(6, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DATE_A { get; set; }

        /// <summary>
        ///     CODE_A.
        ///     <remarks>
        ///         CODE_A.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.CODE_A__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.CODE_A__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String CODE_A { get; set; }

        /// <summary>
        ///     AMOUNT_A.
        ///     <remarks>
        ///         AMOUNT_A.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.AMOUNT_A__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.AMOUNT_A__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [StringLength(18, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String AMOUNT_A { get; set; }

        /// <summary>
        ///     FEND.
        ///     <remarks>
        ///         FEND.
        ///     </remarks>
        /// </summary>
        [UIHint("Decimal")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.FEND__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.FEND__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        [RangeDecimal("-9999999999", "9999999999",
            ErrorMessageResourceType = typeof(ValidationResources), 
            ErrorMessageResourceName = nameof(ValidationResources.RangeAttribute_ValidationError))]
        public Decimal? FEND { get; set; }

        /// <summary>
        ///     OPER_C.
        ///     <remarks>
        ///         OPER_C.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.OPER_C__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.OPER_C__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [StringLength(10, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String OPER_C { get; set; }

        /// <summary>
        ///     DATE_C.
        ///     <remarks>
        ///         DATE_C.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.DATE_C__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.DATE_C__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [StringLength(6, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String DATE_C { get; set; }

        /// <summary>
        ///     CODE_C.
        ///     <remarks>
        ///         CODE_C.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.CODE_C__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.CODE_C__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [StringLength(3, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String CODE_C { get; set; }

        /// <summary>
        ///     AMOUNT_C.
        ///     <remarks>
        ///         AMOUNT_C.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.AMOUNT_C__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.AMOUNT_C__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [StringLength(18, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String AMOUNT_C { get; set; }

        /// <summary>
        ///     FCODENAME.
        ///     <remarks>
        ///         FCODENAME.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.FCODENAME__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.FCODENAME__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [StringLength(7, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String FCODENAME { get; set; }

        /// <summary>
        ///     ID_MESSAGE.
        ///     <remarks>
        ///         ID_MESSAGE.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.ID_MESSAGE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.ID_MESSAGE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        public Int32 ID_MESSAGE { get; set; }

        /// <summary>
        ///     FTYPE.
        ///     <remarks>
        ///         FTYPE.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.FTYPE__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.FTYPE__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        public Int32? FTYPE { get; set; }

        /// <summary>
        ///     FSYSTEM.
        ///     <remarks>
        ///         FSYSTEM.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.FSYSTEM__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.FSYSTEM__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        public Int32? FSYSTEM { get; set; }


        internal Dictionary<string, string> AccessFilterQueryParameters { get; set; }

        public static Expression<Func<MT950_TBL, MT950_TBLViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<MT950_TBL, MT950_TBLViewModel>> viewModel =
                r => new MT950_TBLViewModel
                        {
                            id = r.id,
                            REFERENSE = r.REFERENSE,
                            BIC = r.BIC,
                            ACCOUNT = r.ACCOUNT,
                            FNUM = r.FNUM,
                            FCOUNT = r.FCOUNT,
                            FSTART = r.FSTART,
                            OPER_A = r.OPER_A,
                            DATE_A = r.DATE_A,
                            CODE_A = r.CODE_A,
                            AMOUNT_A = r.AMOUNT_A,
                            FEND = r.FEND,
                            OPER_C = r.OPER_C,
                            DATE_C = r.DATE_C,
                            CODE_C = r.CODE_C,
                            AMOUNT_C = r.AMOUNT_C,
                            FCODENAME = r.FCODENAME,
                            ID_MESSAGE = r.ID_MESSAGE,
                            FTYPE = r.FTYPE,
                            FSYSTEM = r.FSYSTEM
                        };
        
            var builder = viewModel.ToBuilder(dbContext, httpContext);
            builder.AddAccessResult(r => r.CanDestroy, AccessFilterType.Delete, httpContext);
            builder.AddAccessResult(r => r.CanUpdate, AccessFilterType.Edit, httpContext);
            return builder.ToExpression();
        }
        
        partial void OnCreateOrUpdate(MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreateOrUpdate(MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(MT950_TBLViewModel newViewModel, MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(MT950_TBLViewModel newViewModel, MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreate(MT950_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreate(MT950_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool cancel);
        partial void OnCreated(MT950_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreated(MT950_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreated(MT950_TBLViewModel newViewModel, MT950_TBL item, DataContext dbContext, Controller controller);
        partial void OnCreated(MT950_TBLViewModel newViewModel, MT950_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedLog(MT950_TBLViewModel newViewModel, MT950_TBL item, DataContext dbContext, Controller controller, ref string typeCode);
        partial void OnAllowCreate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public MT950_TBLViewModel Create(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<MT950_TBL, DataContext, Controller> onCreate = null)
        {
            var allowCreate = true;
            OnAllowCreate(ref allowCreate, dbContext, controller, eventLogManager);
            if (!allowCreate) return this;
            
            var item = new MT950_TBL();
            item.id = this.id;
            item.REFERENSE = this.REFERENSE;
            item.BIC = this.BIC;
            item.ACCOUNT = this.ACCOUNT;
            item.FNUM = this.FNUM;
            item.FCOUNT = this.FCOUNT;
            item.FSTART = this.FSTART;
            item.OPER_A = this.OPER_A;
            item.DATE_A = this.DATE_A;
            item.CODE_A = this.CODE_A;
            item.AMOUNT_A = this.AMOUNT_A;
            item.FEND = this.FEND;
            item.OPER_C = this.OPER_C;
            item.DATE_C = this.DATE_C;
            item.CODE_C = this.CODE_C;
            item.AMOUNT_C = this.AMOUNT_C;
            item.FCODENAME = this.FCODENAME;
            item.ID_MESSAGE = this.ID_MESSAGE;
            item.FTYPE = this.FTYPE;
            item.FSYSTEM = this.FSYSTEM;
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
            if (!dbContext.SaveChanges<MT950_TBL>(controller, eventLogManager))
                return this;
        
            OnCreatedOrUpdated(null, item, dbContext, controller);
            OnCreatedOrUpdated(null, item, dbContext, controller, eventLogManager);
            OnCreated(item, dbContext, controller);
            OnCreated(item, dbContext, controller, eventLogManager);
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var newViewModel = dbContext.Set<MT950_TBL>().AsQueryable().Select(ViewModel(httpContext, dbContext)).FirstOrDefault(r => r.id == item.id);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller, eventLogManager);
            OnCreated(newViewModel, item, dbContext, controller);
            OnCreated(newViewModel, item, dbContext, controller, eventLogManager);
            var typeCode = "Create";
            OnCreatedLog(newViewModel, item, dbContext, controller, ref typeCode);
            eventLogManager?.LogChanges<DataContext, MT950_TBLViewModel>(controller, null, newViewModel, typeCode: typeCode);
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanUpdate { get; set; }
        
        partial void OnUpdateGetOldViewModel(ref MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdate(MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdate(MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateBeforeSave(MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdateBegin(MT950_TBLViewModel oldViewModel, ref MT950_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdated(MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdated(MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdated(MT950_TBLViewModel newViewModel, MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller);
        partial void OnUpdated(MT950_TBLViewModel newViewModel, MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateNoChanges(ref bool cancelExecution, MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller);
        partial void OnAllowUpdate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public MT950_TBLViewModel Update(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<MT950_TBLViewModel, MT950_TBL, DataContext, Controller> onUpdate = null, bool validateAccess = true)
        {
            var allowUpdate = true;
            OnAllowUpdate(ref allowUpdate, dbContext, controller, eventLogManager);
            if (!allowUpdate) return this;
            
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<MT950_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT950_TBLViewModel), queryParameters: AccessFilterQueryParameters).FirstOrDefault(r => this.id == r.id);
            MT950_TBLViewModel oldViewModel = null;
            bool hasChanges;
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<MT950_TBL>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.EditAndRead, controller?.ModelState, modelView: typeof(MT950_TBLViewModel), queryParameters: AccessFilterQueryParameters))
                    return this;
        
                OnUpdateGetOldViewModel(ref oldViewModel, item, dbContext, controller);
                if (oldViewModel == null)
                    oldViewModel = dbContext.Set<MT950_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT950_TBLViewModel), queryParameters: AccessFilterQueryParameters).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                OnUpdateBegin(oldViewModel, ref item, dbContext, controller);
                item.id = this.id;
                item.REFERENSE = this.REFERENSE;
                item.BIC = this.BIC;
                item.ACCOUNT = this.ACCOUNT;
                item.FNUM = this.FNUM;
                item.FCOUNT = this.FCOUNT;
                item.FSTART = this.FSTART;
                item.OPER_A = this.OPER_A;
                item.DATE_A = this.DATE_A;
                item.CODE_A = this.CODE_A;
                item.AMOUNT_A = this.AMOUNT_A;
                item.FEND = this.FEND;
                item.OPER_C = this.OPER_C;
                item.DATE_C = this.DATE_C;
                item.CODE_C = this.CODE_C;
                item.AMOUNT_C = this.AMOUNT_C;
                item.FCODENAME = this.FCODENAME;
                item.ID_MESSAGE = this.ID_MESSAGE;
                item.FTYPE = this.FTYPE;
                item.FSYSTEM = this.FSYSTEM;
        
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
                if (!dbContext.SaveChanges<MT950_TBL>(controller, eventLogManager))
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
            var newViewModel = dbContext.Set<MT950_TBL>().AsQueryable().Select(ViewModel(httpContext, dbContext)).Where(r => r.id == this.id).OrderByDescending(r => r.id).FirstOrDefault();
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            if (hasChanges)
                eventLogManager?.LogChanges<DataContext, MT950_TBLViewModel>(controller, oldViewModel, newViewModel, typeCode: "Update");
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanDestroy { get; set; }
        
        partial void OnDestroy(MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller, ref bool remove);
        partial void OnDestroy(MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool remove);
        partial void OnDestroyed(MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller);
        partial void OnDestroyed(MT950_TBLViewModel oldViewModel, MT950_TBL item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        void IViewModelDestroy<DataContext, MT950_TBLViewModel, MT950_TBL>.Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, MT950_TBLViewModel, MT950_TBL> onDestroy)
        {
            Destroy(dbContext, controller, eventLogManager, onDestroy);
        }
        
        public void Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, MT950_TBLViewModel, MT950_TBL> onDestroy = null, bool validateAccess = true)
        {
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<MT950_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT950_TBLViewModel), queryParameters: AccessFilterQueryParameters).FirstOrDefault(r => this.id == r.id);
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<MT950_TBL>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.DeleteAndRead, controller?.ModelState, validationKey: "CancelDelete", modelView: typeof(MT950_TBLViewModel), queryParameters: AccessFilterQueryParameters))
                    return;
        
                var oldViewModel = dbContext.Set<MT950_TBL>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(MT950_TBLViewModel), queryParameters: AccessFilterQueryParameters).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                var remove = true;
                OnDestroy(oldViewModel, item, dbContext, controller, ref remove);
                OnDestroy(oldViewModel, item, dbContext, controller, eventLogManager, ref remove);
                remove = onDestroy?.Invoke(item, dbContext, controller, eventLogManager, remove) ?? remove;
        
                if (remove && (controller == null || controller.ModelState.IsValid))
                {
                    dbContext.Remove(item);
                    if (dbContext.SaveChanges<MT950_TBL>(controller, eventLogManager, validationKey: "CancelDelete"))
                    {
                        eventLogManager?.LogChanges<DataContext, MT950_TBLViewModel>(controller, oldViewModel, null, typeCode: "Destroy");
                        OnDestroyed(oldViewModel, item, dbContext, controller);
                        OnDestroyed(oldViewModel, item, dbContext, controller, eventLogManager);
                    }
                }
            }
        }
        
        
        
        public string GetLogMessage()
        {
            return REFERENSE+ ", " +BIC+ ", " +ACCOUNT+ ", " +FNUM+ ", " +FCOUNT+ ", " +FSTART.ToString()+ ", " +OPER_A+ ", " +DATE_A+ ", " +CODE_A+ ", " +AMOUNT_A+ ", " +FEND.ToString()+ ", " +OPER_C+ ", " +DATE_C+ ", " +CODE_C+ ", " +AMOUNT_C+ ", " +FCODENAME+ ", " +ID_MESSAGE.ToString()+ ", " +FTYPE.ToString()+ ", " +FSYSTEM.ToString();
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
    ///     MT950_TBLMinimal. Представление таблицы MT950_TBL (MT950_TBL).
    ///     <remarks>
    ///         Сообщение - МТ950.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Сообщение - МТ950")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICMT950_TBL", Title = "Сообщение - МТ950")][EventLogGroupAttribute(ParentCode = "DICMT950_TBL")]
    public partial class MT950_TBLMinimalViewModel
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         ID_EXTRACT.
        ///     </remarks>
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        [Editable(false)]
        [ScaffoldColumn(false)]
        [UIHint("Decimal")]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.MT950_TBLResources))]
        [DisplayFormat(DataFormatString = "{0:n0}")]
        public Decimal id { get; set; }


        internal Dictionary<string, string> AccessFilterQueryParameters { get; set; }

        public static Expression<Func<MT950_TBL, MT950_TBLMinimalViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<MT950_TBL, MT950_TBLMinimalViewModel>> viewModel =
                r => new MT950_TBLMinimalViewModel
                        {
                            id = r.id
                        };
        
            return viewModel;
        }
    }
}