namespace TaxInterface_TI.Areas.TI.ViewModels
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.ComponentModel.DataAnnotations;
    using global::System.Globalization;
    using global::System.Linq;
    using global::System.Linq.Expressions;
    using global::System.Xml.Linq;
    using Newtonsoft.Json;

    using TaxInterface_TI.Areas.TI.GeneratedResources;
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
    ///     TaxPayments. Представление таблицы TaxPayments (TaxPayments).
    /// </summary>
    [System.ComponentModel.DisplayName("")]
    [EventLogGroupAttribute(Code = "TI", Title = "Tax interface module")][EventLogGroupAttribute(ParentCode = "TI", Code = "TITaxPayments", Title = "")][EventLogGroupAttribute(ParentCode = "TITaxPayments")]
    public partial class TaxPaymentsViewModel : IViewModelUpdate<DataContext, TaxPaymentsViewModel, TaxPayments>, IViewModelCreate<DataContext, TaxPaymentsViewModel, TaxPayments>, IViewModelDestroy<DataContext, TaxPaymentsViewModel, TaxPayments>, IViewModelLogMessage<DataContext>
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
            Name = nameof(TaxInterface_TI.Areas.TI.GeneratedResources.TaxPaymentsResources.id__Title),
            Description = nameof(TaxInterface_TI.Areas.TI.GeneratedResources.TaxPaymentsResources.id__Comment),
            ResourceType = typeof(TaxInterface_TI.Areas.TI.GeneratedResources.TaxPaymentsResources))]
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        public Int64 id { get; set; }

        /// <summary>
        ///     Name.
        ///     <remarks>
        ///         Наименование.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(TaxInterface_TI.Areas.TI.GeneratedResources.TaxPaymentsResources.Name__Title),
            Description = nameof(TaxInterface_TI.Areas.TI.GeneratedResources.TaxPaymentsResources.Name__Comment),
            ResourceType = typeof(TaxInterface_TI.Areas.TI.GeneratedResources.TaxPaymentsResources))]
        [StringLength(200, ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.StringLengthAttribute_ValidationError))]
        public String Name { get; set; }


        public static Expression<Func<TaxPayments, TaxPaymentsViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<TaxPayments, TaxPaymentsViewModel>> viewModel =
                r => new TaxPaymentsViewModel
                        {
                            id = r.id,
                            Name = r.Name
                        };
        
            var builder = viewModel.ToBuilder(dbContext, httpContext);
            builder.AddAccessResult(r => r.CanDestroy, AccessFilterType.Delete, httpContext);
            builder.AddAccessResult(r => r.CanUpdate, AccessFilterType.Edit, httpContext);
            return builder.ToExpression();
        }
        
        partial void OnCreateOrUpdate(TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller);
        partial void OnCreateOrUpdate(TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(TaxPaymentsViewModel newViewModel, TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(TaxPaymentsViewModel newViewModel, TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreate(TaxPayments item, DataContext dbContext, Controller controller);
        partial void OnCreate(TaxPayments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool cancel);
        partial void OnCreated(TaxPayments item, DataContext dbContext, Controller controller);
        partial void OnCreated(TaxPayments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreated(TaxPaymentsViewModel newViewModel, TaxPayments item, DataContext dbContext, Controller controller);
        partial void OnCreated(TaxPaymentsViewModel newViewModel, TaxPayments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedLog(TaxPaymentsViewModel newViewModel, TaxPayments item, DataContext dbContext, Controller controller, ref string typeCode);
        partial void OnAllowCreate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public TaxPaymentsViewModel Create(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<TaxPayments, DataContext, Controller> onCreate = null)
        {
            var allowCreate = true;
            OnAllowCreate(ref allowCreate, dbContext, controller, eventLogManager);
            if (!allowCreate) return this;
            
            var item = new TaxPayments();
            item.id = this.id;
            item.Name = this.Name;
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
            if (!dbContext.SaveChanges<TaxPayments>(controller, eventLogManager))
                return this;
        
            OnCreatedOrUpdated(null, item, dbContext, controller);
            OnCreatedOrUpdated(null, item, dbContext, controller, eventLogManager);
            OnCreated(item, dbContext, controller);
            OnCreated(item, dbContext, controller, eventLogManager);
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var newViewModel = dbContext.Set<TaxPayments>().AsQueryable().Select(ViewModel(httpContext, dbContext)).FirstOrDefault(r => r.id == item.id);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller, eventLogManager);
            OnCreated(newViewModel, item, dbContext, controller);
            OnCreated(newViewModel, item, dbContext, controller, eventLogManager);
            var typeCode = "Create";
            OnCreatedLog(newViewModel, item, dbContext, controller, ref typeCode);
            eventLogManager?.LogChanges<DataContext, TaxPaymentsViewModel>(controller, null, newViewModel, typeCode: typeCode);
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanUpdate { get; set; }
        
        partial void OnUpdateGetOldViewModel(ref TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller);
        partial void OnUpdate(TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller);
        partial void OnUpdate(TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateBeforeSave(TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller);
        partial void OnUpdateBegin(TaxPaymentsViewModel oldViewModel, ref TaxPayments item, DataContext dbContext, Controller controller);
        partial void OnUpdated(TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller);
        partial void OnUpdated(TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdated(TaxPaymentsViewModel newViewModel, TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller);
        partial void OnUpdated(TaxPaymentsViewModel newViewModel, TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateNoChanges(ref bool cancelExecution, TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller);
        partial void OnAllowUpdate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public TaxPaymentsViewModel Update(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<TaxPaymentsViewModel, TaxPayments, DataContext, Controller> onUpdate = null, bool validateAccess = true)
        {
            var allowUpdate = true;
            OnAllowUpdate(ref allowUpdate, dbContext, controller, eventLogManager);
            if (!allowUpdate) return this;
            
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<TaxPayments>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(TaxPaymentsViewModel)).FirstOrDefault(r => this.id == r.id);
            TaxPaymentsViewModel oldViewModel = null;
            bool hasChanges;
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<TaxPayments>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.EditAndRead, controller?.ModelState, modelView: typeof(TaxPaymentsViewModel)))
                    return this;
        
                OnUpdateGetOldViewModel(ref oldViewModel, item, dbContext, controller);
                if (oldViewModel == null)
                    oldViewModel = dbContext.Set<TaxPayments>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(TaxPaymentsViewModel)).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                OnUpdateBegin(oldViewModel, ref item, dbContext, controller);
                item.id = this.id;
                item.Name = this.Name;
        
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
                if (!dbContext.SaveChanges<TaxPayments>(controller, eventLogManager))
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
            var newViewModel = dbContext.Set<TaxPayments>().AsQueryable().Select(ViewModel(httpContext, dbContext)).Where(r => r.id == this.id).OrderByDescending(r => r.id).FirstOrDefault();
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            if (hasChanges)
                eventLogManager?.LogChanges<DataContext, TaxPaymentsViewModel>(controller, oldViewModel, newViewModel, typeCode: "Update");
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanDestroy { get; set; }
        
        partial void OnDestroy(TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller, ref bool remove);
        partial void OnDestroy(TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool remove);
        partial void OnDestroyed(TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller);
        partial void OnDestroyed(TaxPaymentsViewModel oldViewModel, TaxPayments item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        void IViewModelDestroy<DataContext, TaxPaymentsViewModel, TaxPayments>.Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, TaxPaymentsViewModel, TaxPayments> onDestroy)
        {
            Destroy(dbContext, controller, eventLogManager, onDestroy);
        }
        
        public void Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, TaxPaymentsViewModel, TaxPayments> onDestroy = null, bool validateAccess = true)
        {
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<TaxPayments>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(TaxPaymentsViewModel)).FirstOrDefault(r => this.id == r.id);
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<TaxPayments>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.DeleteAndRead, controller?.ModelState, validationKey: "CancelDelete:" + this.id, modelView: typeof(TaxPaymentsViewModel)))
                    return;
        
                var oldViewModel = dbContext.Set<TaxPayments>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(TaxPaymentsViewModel)).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                var remove = true;
                OnDestroy(oldViewModel, item, dbContext, controller, ref remove);
                OnDestroy(oldViewModel, item, dbContext, controller, eventLogManager, ref remove);
                remove = onDestroy?.Invoke(item, dbContext, controller, eventLogManager, remove) ?? remove;
        
                if (remove && (controller == null || controller.ModelState.IsValid))
                {
                    dbContext.Remove(item);
                    if (dbContext.SaveChanges<TaxPayments>(controller, eventLogManager, validationKey: "CancelDelete:" + this.id))
                    {
                        eventLogManager?.LogChanges<DataContext, TaxPaymentsViewModel>(controller, oldViewModel, null, typeCode: "Destroy");
                        OnDestroyed(oldViewModel, item, dbContext, controller);
                        OnDestroyed(oldViewModel, item, dbContext, controller, eventLogManager);
                    }
                }
            }
        }
        
        
        
        public string GetLogMessage()
        {
            return Name;
        }
    }
}