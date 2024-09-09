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
    ///     bookForData. Представление таблицы bookForData (bookForData).
    ///     <remarks>
    ///         Книга для сбора данных.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Книга для сбора данных")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICbookForData", Title = "Книга для сбора данных")][EventLogGroupAttribute(ParentCode = "DICbookForData")]
    public partial class bookForDataViewModel : IViewModelUpdate<DataContext, bookForDataViewModel, bookForData>, IViewModelCreate<DataContext, bookForDataViewModel, bookForData>, IViewModelDestroy<DataContext, bookForDataViewModel, bookForData>, IViewModelLogMessage<DataContext>
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         recId.
        ///     </remarks>
        /// </summary>
        [ScaffoldColumn(false)]
        [UIHint("Int64")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources))]
        [Required(ErrorMessageResourceType = typeof(ValidationResources), ErrorMessageResourceName = nameof(ValidationResources.RequiredField))]
        public Int64 id { get; set; }

        /// <summary>
        ///     REFmsgQueId.
        ///     <remarks>
        ///         REFmsgQueId.
        ///     </remarks>
        /// </summary>
        [UIHint("Int64")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources.REFmsgQueId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources.REFmsgQueId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources))]
        public Int64? REFmsgQueId { get; set; }

        /// <summary>
        ///     REFid.
        ///     <remarks>
        ///         REFmsgId.
        ///     </remarks>
        /// </summary>
        [UIHint("GridForeignKeyLoading")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources.REFid__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources.REFid__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources))]
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
        public Int64? REFid { get; set; }
        
        partial void REFid_AccessFilter(AccessDataContext<Dictionaries.Areas.DIC.ViewModels.bookForDataViewModel> context);

        /// <summary>
        ///     stmpBody.
        ///     <remarks>
        ///         stmpBody.
        ///     </remarks>
        /// </summary>
        [UIHint("String")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources.stmpBody__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources.stmpBody__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources))]
        public String stmpBody { get; set; }

        /// <summary>
        ///     stmpDataType.
        ///     <remarks>
        ///         stmpDataType.
        ///     </remarks>
        /// </summary>
        [UIHint("Integer")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources.stmpDataType__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources.stmpDataType__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources))]
        public Int32? stmpDataType { get; set; }

        /// <summary>
        ///     REFrxcId.
        ///     <remarks>
        ///         REFrxcId.
        ///     </remarks>
        /// </summary>
        [UIHint("Int64")]
        [EventLog()]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources.REFrxcId__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources.REFrxcId__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources))]
        public Int64? REFrxcId { get; set; }


        internal Dictionary<string, string> AccessFilterQueryParameters { get; set; }

        public static Expression<Func<bookForData, bookForDataViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<bookForData, bookForDataViewModel>> viewModel =
                r => new bookForDataViewModel
                        {
                            id = r.id,
                            REFmsgQueId = r.REFmsgQueId,
                            REFid = r.REFid,
                            stmpBody = r.stmpBody,
                            stmpDataType = r.stmpDataType,
                            REFrxcId = r.REFrxcId
                        };
        
            var builder = viewModel.ToBuilder(dbContext, httpContext)
                ;
            builder.AddAccessResult(r => r.CanDestroy, AccessFilterType.Delete, httpContext);
            builder.AddAccessResult(r => r.CanUpdate, AccessFilterType.Edit, httpContext);
            return builder.ToExpression();
        }
        
        partial void OnCreateOrUpdate(bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller);
        partial void OnCreateOrUpdate(bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedOrUpdated(bookForDataViewModel newViewModel, bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller);
        partial void OnCreatedOrUpdated(bookForDataViewModel newViewModel, bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreate(bookForData item, DataContext dbContext, Controller controller);
        partial void OnCreate(bookForData item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool cancel);
        partial void OnCreated(bookForData item, DataContext dbContext, Controller controller);
        partial void OnCreated(bookForData item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreated(bookForDataViewModel newViewModel, bookForData item, DataContext dbContext, Controller controller);
        partial void OnCreated(bookForDataViewModel newViewModel, bookForData item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnCreatedLog(bookForDataViewModel newViewModel, bookForData item, DataContext dbContext, Controller controller, ref string typeCode);
        partial void OnAllowCreate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public bookForDataViewModel Create(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<bookForData, DataContext, Controller> onCreate = null)
        {
            var allowCreate = true;
            OnAllowCreate(ref allowCreate, dbContext, controller, eventLogManager);
            if (!allowCreate) return this;
            
            var item = new bookForData();
            item.id = this.id;
            item.REFmsgQueId = this.REFmsgQueId;
            item.REFid = this.REFid;
            item.stmpBody = this.stmpBody;
            item.stmpDataType = this.stmpDataType;
            item.REFrxcId = this.REFrxcId;
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
            if (!dbContext.SaveChanges<bookForData>(controller, eventLogManager))
                return this;
        
            OnCreatedOrUpdated(null, item, dbContext, controller);
            OnCreatedOrUpdated(null, item, dbContext, controller, eventLogManager);
            OnCreated(item, dbContext, controller);
            OnCreated(item, dbContext, controller, eventLogManager);
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var newViewModel = dbContext.Set<bookForData>().AsQueryable().Select(ViewModel(httpContext, dbContext)).FirstOrDefault(r => r.id == item.id);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, null, item, dbContext, controller, eventLogManager);
            OnCreated(newViewModel, item, dbContext, controller);
            OnCreated(newViewModel, item, dbContext, controller, eventLogManager);
            var typeCode = "Create";
            OnCreatedLog(newViewModel, item, dbContext, controller, ref typeCode);
            eventLogManager?.LogChanges<DataContext, bookForDataViewModel>(controller, null, newViewModel, typeCode: typeCode);
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanUpdate { get; set; }
        
        partial void OnUpdateGetOldViewModel(ref bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller);
        partial void OnUpdate(bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller);
        partial void OnUpdate(bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateBeforeSave(bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller);
        partial void OnUpdateBegin(bookForDataViewModel oldViewModel, ref bookForData item, DataContext dbContext, Controller controller);
        partial void OnUpdated(bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller);
        partial void OnUpdated(bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdated(bookForDataViewModel newViewModel, bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller);
        partial void OnUpdated(bookForDataViewModel newViewModel, bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        partial void OnUpdateNoChanges(ref bool cancelExecution, bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller);
        partial void OnAllowUpdate(ref bool allow, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        public bookForDataViewModel Update(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, Action<bookForDataViewModel, bookForData, DataContext, Controller> onUpdate = null, bool validateAccess = true)
        {
            var allowUpdate = true;
            OnAllowUpdate(ref allowUpdate, dbContext, controller, eventLogManager);
            if (!allowUpdate) return this;
            
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<bookForData>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(bookForDataViewModel), queryParameters: AccessFilterQueryParameters).FirstOrDefault(r => this.id == r.id);
            bookForDataViewModel oldViewModel = null;
            bool hasChanges;
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<bookForData>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.EditAndRead, controller?.ModelState, modelView: typeof(bookForDataViewModel), queryParameters: AccessFilterQueryParameters))
                    return this;
        
                OnUpdateGetOldViewModel(ref oldViewModel, item, dbContext, controller);
                if (oldViewModel == null)
                    oldViewModel = dbContext.Set<bookForData>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(bookForDataViewModel), queryParameters: AccessFilterQueryParameters).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                OnUpdateBegin(oldViewModel, ref item, dbContext, controller);
                item.id = this.id;
                item.REFmsgQueId = this.REFmsgQueId;
                item.REFid = this.REFid;
                item.stmpBody = this.stmpBody;
                item.stmpDataType = this.stmpDataType;
                item.REFrxcId = this.REFrxcId;
        
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
                if (!dbContext.SaveChanges<bookForData>(controller, eventLogManager))
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
            var newViewModel = dbContext.Set<bookForData>().AsQueryable().Select(ViewModel(httpContext, dbContext)).Where(r => r.id == this.id).OrderByDescending(r => r.id).FirstOrDefault();
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnCreatedOrUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller);
            OnUpdated(newViewModel, oldViewModel, item, dbContext, controller, eventLogManager);
            if (hasChanges)
                eventLogManager?.LogChanges<DataContext, bookForDataViewModel>(controller, oldViewModel, newViewModel, typeCode: "Update");
            return newViewModel;
        }
        
        [Editable(false)]
        [ScaffoldColumn(false)]
        public bool CanDestroy { get; set; }
        
        partial void OnDestroy(bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller, ref bool remove);
        partial void OnDestroy(bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager, ref bool remove);
        partial void OnDestroyed(bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller);
        partial void OnDestroyed(bookForDataViewModel oldViewModel, bookForData item, DataContext dbContext, Controller controller, IEventLogManager eventLogManager);
        
        void IViewModelDestroy<DataContext, bookForDataViewModel, bookForData>.Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, bookForDataViewModel, bookForData> onDestroy)
        {
            Destroy(dbContext, controller, eventLogManager, onDestroy);
        }
        
        public void Destroy(DataContext dbContext, Controller controller, IEventLogManager eventLogManager, OnDestroyDelegate<DataContext, bookForDataViewModel, bookForData> onDestroy = null, bool validateAccess = true)
        {
            var httpContext = System.Web.HttpContext.Current == null ? null : controller?.HttpContext ?? new HttpContextWrapper(System.Web.HttpContext.Current);
            var item = dbContext.Set<bookForData>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(bookForDataViewModel), queryParameters: AccessFilterQueryParameters).FirstOrDefault(r => this.id == r.id);
            if (item != null)
            {
                if (validateAccess && !dbContext.Set<bookForData>().AsQueryable().Where(r => this.id == r.id).IsValidAccess(httpContext, dbContext, AccessFilterType.DeleteAndRead, controller?.ModelState, validationKey: "CancelDelete", modelView: typeof(bookForDataViewModel), queryParameters: AccessFilterQueryParameters))
                    return;
        
                var oldViewModel = dbContext.Set<bookForData>().AsQueryable().AccessFilter(httpContext, dbContext, modelView: typeof(bookForDataViewModel), queryParameters: AccessFilterQueryParameters).Where(r => this.id == r.id).Select(ViewModel(httpContext, dbContext)).First();
                var remove = true;
                OnDestroy(oldViewModel, item, dbContext, controller, ref remove);
                OnDestroy(oldViewModel, item, dbContext, controller, eventLogManager, ref remove);
                remove = onDestroy?.Invoke(item, dbContext, controller, eventLogManager, remove) ?? remove;
        
                if (remove && (controller == null || controller.ModelState.IsValid))
                {
                    dbContext.Remove(item);
                    if (dbContext.SaveChanges<bookForData>(controller, eventLogManager, validationKey: "CancelDelete"))
                    {
                        eventLogManager?.LogChanges<DataContext, bookForDataViewModel>(controller, oldViewModel, null, typeCode: "Destroy");
                        OnDestroyed(oldViewModel, item, dbContext, controller);
                        OnDestroyed(oldViewModel, item, dbContext, controller, eventLogManager);
                    }
                }
            }
        }
        
        
        
        public string GetLogMessage()
        {
            return REFmsgQueId.ToString()+ ", " +stmpBody+ ", " +stmpDataType.ToString()+ ", " +REFrxcId.ToString();
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
    ///     bookForDataMinimal. Представление таблицы bookForData (bookForData).
    ///     <remarks>
    ///         Книга для сбора данных.
    ///     </remarks>
    /// </summary>
    [System.ComponentModel.DisplayName("Книга для сбора данных")]
    [EventLogGroupAttribute(Code = "DIC", Title = "Справочники")][EventLogGroupAttribute(ParentCode = "DIC", Code = "DICbookForData", Title = "Книга для сбора данных")][EventLogGroupAttribute(ParentCode = "DICbookForData")]
    public partial class bookForDataMinimalViewModel
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         recId.
        ///     </remarks>
        /// </summary>
        [JsonProperty(NullValueHandling=NullValueHandling.Ignore)]
        [Editable(false)]
        [ScaffoldColumn(false)]
        [UIHint("Int64")]
        [Display(
            Name = nameof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources.id__Title),
            Description = nameof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources.id__Comment),
            ResourceType = typeof(Dictionaries.Areas.DIC.GeneratedResources.bookForDataResources))]
        public Int64 id { get; set; }


        internal Dictionary<string, string> AccessFilterQueryParameters { get; set; }

        public static Expression<Func<bookForData, bookForDataMinimalViewModel>> ViewModel(HttpContext httpContext, DataContext dbContext)
        {
            var uiCulture = CultureInfo.CurrentUICulture.Name;
            var languageCode = CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;
            Expression<Func<bookForData, bookForDataMinimalViewModel>> viewModel =
                r => new bookForDataMinimalViewModel
                        {
                            id = r.id
                        };
        
            return viewModel;
        }
    }
}