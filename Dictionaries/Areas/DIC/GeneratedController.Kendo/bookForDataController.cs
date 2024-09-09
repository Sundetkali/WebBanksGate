namespace Dictionaries.Areas.DIC.Controllers
{
    using global::Kendo.Mvc.Extensions;
    using global::Kendo.Mvc.UI;

    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Linq.Expressions;
    using Microsoft.Ajax.Utilities;

    using BanksGateDataModel.Models;
    using Dictionaries.Areas.DIC.ViewModels;
    using Nat.Web.Core.Kendo.Extensions;
    using Nat.Web.Core.Kendo.ViewModels;
    using Nat.Web.Core.System.ControllerAnnotations;
    using Nat.Web.Core.System.Data.Extensions;
    using Nat.Web.Core.System.EventLog;
    using Nat.Web.Core.System.Extensions;
    using Nat.Web.Core.System.Mvc;
    using Nat.Web.Core.System.Security;
    using Nat.Web.Core.System.ViewModels;

    using HttpContext = global::System.Web.HttpContextBase;
    using global::System.Web.Mvc;

    [Authorize]
    public partial class bookForDataController : Controller
    {
        private DataAdapters.bookForDataDataAdapter innerDataAdapter;

        public bookForDataController(DataContext dbContext, IEventLogManager log)
        {
            DataContext = dbContext;
            Log = log;
        }
        
        protected DataContext DataContext { get; }
        protected IEventLogManager Log { get; }

        private IEventLogManager GetEventLogManager()
        {
            return Log;
        }

        public DataAdapters.bookForDataDataAdapter InnerDataAdapter => innerDataAdapter ?? (innerDataAdapter = new DataAdapters.bookForDataDataAdapter(DataContext, HttpContext));

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DataContext.Database.CurrentTransaction?.Dispose();
                DataContext.Database.Connection.Dispose();
                DataContext.Dispose();
            }

            base.Dispose(disposing);
        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            requestContext.SetThreadCulture();
            base.Initialize(requestContext);
        }

        partial void IndexPartial(ref ActionResult view, GridViewModel model);
        partial void GetDataIndexPartial(DataSourceRequest request);
        partial void GetDataIndexPartial(ref IQueryable<bookForDataViewModel> data, DataSourceRequest request);
        static partial void IndexGridModelInitialize(HttpContext httpContext, GridViewModel model);
        
        [NonAction]
        public static GridViewModel IndexGridViewModel(HttpContext httpContext, GridViewModelRoute route)
        {
            var model =
                new GridViewModel//<bookForDataViewModel>
                    {
                        Route = route,
                        Batch = false,
                        ReadDataParametersHandler = route.ReadDataParametersHandler,
                        Read = new ActionViewModel
                            {
                                Controller = "bookForData",
                                Action = nameof(GetData),
                                Roles = "bookForData_Edit, bookForData_Read, bookForData_Delete, bookForData_Create,",
                            },
                        Update = new ActionViewModel
                            {
                                Controller = "bookForData",
                                Action = nameof(Update),
                                Roles = "bookForData_Edit,",
                            },
                        Create = new ActionViewModel
                            {
                                Controller = "bookForData",
                                Action = nameof(Create),
                                Roles = "bookForData_Create,",
                            },
                        Destroy = new ActionViewModel
                            {
                                Controller = "bookForData",
                                Action = nameof(Destroy),
                                Roles = "bookForData_Delete,",
                            },
                    };
            IndexGridModelInitialize(httpContext, model);
            return model;
        }
        
        partial void OnInitViewDataForIndex();
        
        private void InitViewDataForIndex()
        {
           OnInitViewDataForIndex();
        }
        
        
        [Authorize(Roles = "bookForData_Edit, bookForData_Read, bookForData_Delete, bookForData_Create,")]
        [EventActionLog(SourceCodeType = typeof(bookForDataViewModel))]
        public ActionResult Index(GridViewModelRoute route)
        {
            InitViewDataForIndex();
            var model = IndexGridViewModel(HttpContext, route);
            ActionResult view = View(model);
            IndexPartial(ref view, model);
            return view;
        }
        
        [Authorize(Roles = "bookForData_Edit, bookForData_Read, bookForData_Delete, bookForData_Create,")]
        [EventActionLog(SourceCodeType = typeof(bookForDataViewModel), TypeCode = "View")]
        public ActionResult GetData([DataSourceRequest] DataSourceRequest request)
        {
            GetDataIndexPartial(request);
            var data = InnerDataAdapter.ReadViewModel1().OrderByDescending(r => r.id).AsQueryable();
            GetDataIndexPartial(ref data, request);
            request.ChangeSortByViewModel<bookForDataViewModel>();
            var jsonData = data.ToDataSourceResult(request);
            GetEventLogManager().LogGetData(this);
            return Json(jsonData);
        }
        
        [Authorize(Roles = "bookForData_Edit,")]
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(bookForDataViewModel), TypeCode = "Update")]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, bookForDataViewModel model)
        {
            return Json(this.Update<DataContext, bookForDataViewModel, bookForData>(DataContext, request, GetEventLogManager(), model));
        }
        
        [Authorize(Roles = "bookForData_Create,")]
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(bookForDataViewModel), TypeCode = "Create")]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, bookForDataViewModel model)
        {
            return Json(this.Create<DataContext, bookForDataViewModel, bookForData>(DataContext, request, GetEventLogManager(), model));
        }
        
        [Authorize(Roles = "bookForData_Delete,")]
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(bookForDataViewModel), TypeCode = "Destroy")]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, bookForDataViewModel model)
        {
            return Json(this.Destroy<DataContext, bookForDataViewModel, bookForData>(DataContext, request, GetEventLogManager(), model));
        }
        
    }
}