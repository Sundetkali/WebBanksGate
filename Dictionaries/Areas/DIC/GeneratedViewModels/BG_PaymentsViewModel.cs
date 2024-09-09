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
    ///     BG_Payments. Представление таблицы BG_Payments (BG_Payments).
    ///     <remarks>
    ///         Платежи БГ.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Платежи БГ")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICBG_Payments", Title = "Платежи БГ")][EventLogGroupAttribute(ParentCode = "DICBG_Payments")]
    public partial class BG_PaymentsViewModel : IViewModelUpdate<DataContext, BG_PaymentsViewModel, BG_Payments>, IViewModelCreate<DataContext, BG_PaymentsViewModel, BG_Payments>, IViewModelDestroy<DataContext, BG_PaymentsViewModel, BG_Payments>, IViewModelLogMessage<DataContext>
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         Идентификатор.
        ///     </remarks>
        /// </summary>
        [ScaffoldColumn(false)]
        [UIHint("Int64")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.BG_PaymentsResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.BG_PaymentsResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.BG_PaymentsResources))]
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        public Int64 id { get; set; }

        /// <summary>
        ///     Amount.
        ///     <remarks>
        ///         Сумма платежа.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.BG_PaymentsResources.Amount__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.BG_PaymentsResources.Amount__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.BG_PaymentsResources))]
        public Int32? Amount { get; set; }

        /// <summary>
        ///     Sender.
        ///     <remarks>
        ///         Отправитель.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.BG_PaymentsResources.Sender__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.BG_PaymentsResources.Sender__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.BG_PaymentsResources))]
        [StringLength(200, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String Sender { get; set; }

        /// <summary>
        ///     Note.
        ///     <remarks>
        ///         Примечание.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.BG_PaymentsResources.Note__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.BG_PaymentsResources.Note__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.BG_PaymentsResources))]
        [StringLength(2000, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String Note { get; set; }


        public static Expression<Func<BG_Payments, BG_PaymentsViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<BG_Payments, BG_PaymentsViewModel>> viewModel =
                r => new BG_PaymentsViewModel
                        {
                            id = r.id,
                            Amount = r.Amount,
                            Sender = r.Sender,
                            Note = r.Note
                        };
        
            var builder = viewModel.ToBuilder(dbContext, httpContext);
            builder.AddAccessResult(r => r.CanDestroy, AccessFilterType.Delete, httpContext);
            builder.AddAccessResult(r => r.CanUpdate, AccessFilterType.Edit, httpContext);
            return builder.ToExpression();
        }
        
        partial void OnCreateOrUpdate(BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller);
        partial void OnCreateOrUpdate(BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(BG_PaymentsViewModel newViewModel, BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(BG_PaymentsViewModel newViewModel, BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreate(BG_Payments item, DataContext dbContext, Controller controller);
        partial void OnCreate(BG_Payments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool cancel);
        partial void OnCreated(BG_Payments item, DataContext dbContext, Controller controller);
        partial void OnCreated(BG_Payments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreated(BG_PaymentsViewModel newViewModel, BG_Payments item, DataContext dbContext, Controller controller);
        partial void OnCreated(BG_PaymentsViewModel newViewModel, BG_Payments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedLog(BG_PaymentsViewModel newViewModel, BG_Payments item, DataContext dbContext, Controller controller, ref string typeCode);
        partial void OnAllowCreate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public BG_PaymentsViewModel Create(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<BG_Payments, DataContext, Controller> onCreate = null)
        {
            var allowCreate = true;
            OnAllowCreate(ref allowCreate, dbContext, controller, eventLogManager);
            if (!allowCreate) return this;
            
            var item = new BG_Payments();
            item.id = this.id;
            item.Amount = this.Amount;
            item.Sender = this.Sender;
            item.Note = this.Note;
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
            if (!dbContext.SaveChanges<BG_Payments>(controller, eventLogManager))
                return this;
        
            OnCreatedOrUpdated(null, item, dbContext, controller);
            OnCreatedOrUpdated(null, item, dbContext, controller, eventLogManager);
            OnCreated(item, dbContext, controller);
            OnCreated(item, dbContext, controller, eventLogManager);
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var newViewModel = dbContext.Set<BG_Payments>().AsQueryable().Select(ViewModel(httpContext, dbContext)).FirstOrDefault(r => r.id == item.id);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller, eventLogManager);
            OnCreated(newViewModel, item, dbContext, controller);
            OnCreated(newViewModel, item, dbContext, controller, eventLogManager);
            var typeCode = "Create";
            OnCreatedLog(newViewModel, item, dbContext, controller, ref typeCode);
            eventLogManager?.LogChanges<DataContext, BG_PaymentsViewModel>(controller, null, newViewModel, typeCode: typeCode);
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanUpdate { get; set; }
        
        partial void OnUpdateGetOldViewModel(ref BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller);
        partial void OnUpdate(BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller);
        partial void OnUpdate(BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateBeforeSave(BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller);
        partial void OnUpdateBegin(BG_PaymentsViewModel oldViewModel, ref BG_Payments item, DataContext dbContext, Controller controller);
        partial void OnUpdated(BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller);
        partial void OnUpdated(BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdated(BG_PaymentsViewModel newViewModel, BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller);
        partial void OnUpdated(BG_PaymentsViewModel newViewModel, BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateNoChanges(ref bool cancelExecution, BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller);
        partial void OnAllowUpdate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public BG_PaymentsViewModel Update(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<BG_PaymentsViewModel, BG_Payments, DataContext, Controller> onUpdate = null, bool validateAccess = true)
        {
            var allowUpdate = true;
            OnAllowUpdate(ref allowUpdate, dbContext, controller, eventLogManager);
            if (!allowUpdate) return this;
            
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<BG_Payments>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(BG_PaymentsViewModel)).FirstOrDefault(r => this.id == r.id);
            BG_PaymentsViewModel oldViewModel = null;
            bool hasChanges;
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<BG_Payments>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.EditAndRead, controller?.ModelState, modelView: typeof(BG_PaymentsViewModel)))
                    return this;
        
                OnUpdateGetOldViewModel(ref oldViewModel, item, dbContext, controller);
                if (oldViewModel == null)
                    oldViewModel = dbContext.Set<BG_Payments>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(BG_PaymentsViewModel)).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                OnUpdateBegin(oldViewModel, ref item, dbContext, controller);
                item.id = this.id;
                item.Amount = this.Amount;
                item.Sender = this.Sender;
                item.Note = this.Note;
        
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
                if (!dbContext.SaveChanges<BG_Payments>(controller, eventLogManager))
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
            var newViewModel = dbContext.Set<BG_Payments>().AsQueryable().Select(ViewModel(httpContext, dbContext)).Where(r => r.id == this.id).OrderByDescending(r => r.id).FirstOrDefault();
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            if (hasChanges)
                eventLogManager?.LogChanges<DataContext, BG_PaymentsViewModel>(controller, oldViewModel, newViewModel, typeCode: "Update");
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanDestroy { get; set; }
        
        partial void OnDestroy(BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller, ref bool remove);
        partial void OnDestroy(BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool remove);
        partial void OnDestroyed(BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller);
        partial void OnDestroyed(BG_PaymentsViewModel oldViewModel, BG_Payments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        void IViewModelDestroy<DataContext, BG_PaymentsViewModel, BG_Payments>.Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, BG_PaymentsViewModel, BG_Payments> onDestroy)
        {
            Destroy(dbContext, controller, eventLogManager, onDestroy);
        }
        
        public void Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, BG_PaymentsViewModel, BG_Payments> onDestroy = null, bool validateAccess = true)
        {
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<BG_Payments>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(BG_PaymentsViewModel)).FirstOrDefault(r => this.id == r.id);
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<BG_Payments>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.DeleteAndRead, controller?.ModelState, validationKey: "CancelDelete:" + this.id, modelView: typeof(BG_PaymentsViewModel)))
                    return;
        
                var oldViewModel = dbContext.Set<BG_Payments>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(BG_PaymentsViewModel)).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                var remove = true;
                OnDestroy(oldViewModel, item, dbContext, controller, ref remove);
                OnDestroy(oldViewModel, item, dbContext, controller, eventLogManager, ref remove);
                remove = onDestroy?.Invoke(item, dbContext, controller, eventLogManager, remove) ?? remove;
        
                if (remove && (controller == null || controller.ModelState.IsValid))
                {
                    dbContext.Remove(item);
                    if (dbContext.SaveChanges<BG_Payments>(controller, eventLogManager, validationKey: "CancelDelete:" + this.id))
                    {
                        eventLogManager?.LogChanges<DataContext, BG_PaymentsViewModel>(controller, oldViewModel, null, typeCode: "Destroy");
                        OnDestroyed(oldViewModel, item, dbContext, controller);
                        OnDestroyed(oldViewModel, item, dbContext, controller, eventLogManager);
                    }
                }
            }
        }
        
        
        
        public string GetLogMessage()
        {
            return Amount.ToString()+ ", " +Sender+ ", " +Note;
        }
    }
}