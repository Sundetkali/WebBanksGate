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
    public partial class MT102_TBLController : Controller
    {
        private DataAdapters.MT102_TBLDataAdapter innerDataAdapter;

        public MT102_TBLController(DataContext dbContext, IEventLogManager log)
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

        public DataAdapters.MT102_TBLDataAdapter InnerDataAdapter => innerDataAdapter ?? (innerDataAdapter = new DataAdapters.MT102_TBLDataAdapter(DataContext, HttpContext));

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
        partial void GetDataIndexPartial(ref IQueryable<MT102_TBLViewModel> data, DataSourceRequest request);
        static partial void IndexGridModelInitialize(HttpContext httpContext, GridViewModel model);
        
        [NonAction]
        public static GridViewModel IndexGridViewModel(HttpContext httpContext, GridViewModelRoute route)
        {
            var model =
                new GridViewModel//<MT102_TBLViewModel>
                    {
                        Route = route,
                        Batch = false,
                        ReadDataParametersHandler = route.ReadDataParametersHandler,
                        Read = new ActionViewModel
                            {
                                Controller = "MT102_TBL",
                                Action = nameof(GetData),
                                Roles = "MT102_TBL_Edit, MT102_TBL_Read, MT102_TBL_Delete, MT102_TBL_Create,",
                            },
                        Update = new ActionViewModel
                            {
                                Controller = "MT102_TBL",
                                Action = nameof(Update),
                                Roles = "MT102_TBL_Edit,",
                            },
                        Create = new ActionViewModel
                            {
                                Controller = "MT102_TBL",
                                Action = nameof(Create),
                                Roles = "MT102_TBL_Create,",
                            },
                        Destroy = new ActionViewModel
                            {
                                Controller = "MT102_TBL",
                                Action = nameof(Destroy),
                                Roles = "MT102_TBL_Delete,",
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
        
        
        [Authorize(Roles = "MT102_TBL_Edit, MT102_TBL_Read, MT102_TBL_Delete, MT102_TBL_Create,")]
        [EventActionLog(SourceCodeType = typeof(MT102_TBLViewModel))]
        public ActionResult Index(GridViewModelRoute route)
        {
            InitViewDataForIndex();
            var model = IndexGridViewModel(HttpContext, route);
            ActionResult view = View(model);
            IndexPartial(ref view, model);
            return view;
        }
        
        [Authorize(Roles = "MT102_TBL_Edit, MT102_TBL_Read, MT102_TBL_Delete, MT102_TBL_Create,")]
        [EventActionLog(SourceCodeType = typeof(MT102_TBLViewModel), TypeCode = "View")]
        public ActionResult GetData([DataSourceRequest] DataSourceRequest request)
        {
            GetDataIndexPartial(request);
            var data = InnerDataAdapter.ReadViewModel1().OrderByDescending(r => r.id).AsQueryable();
            GetDataIndexPartial(ref data, request);
            request.ChangeSortByViewModel<MT102_TBLViewModel>();
            var jsonData = data.ToDataSourceResult(request);
            GetEventLogManager().LogGetData(this);
            return Json(jsonData);
        }
        
        [Authorize(Roles = "MT102_TBL_Edit,")]
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(MT102_TBLViewModel), TypeCode = "Update")]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, MT102_TBLViewModel model)
        {
            return Json(this.Update<DataContext, MT102_TBLViewModel, MT102_TBL>(DataContext, request, GetEventLogManager(), model));
        }
        
        [Authorize(Roles = "MT102_TBL_Create,")]
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(MT102_TBLViewModel), TypeCode = "Create")]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, MT102_TBLViewModel model)
        {
            return Json(this.Create<DataContext, MT102_TBLViewModel, MT102_TBL>(DataContext, request, GetEventLogManager(), model));
        }
        
        [Authorize(Roles = "MT102_TBL_Delete,")]
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(MT102_TBLViewModel), TypeCode = "Destroy")]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, MT102_TBLViewModel model)
        {
            return Json(this.Destroy<DataContext, MT102_TBLViewModel, MT102_TBL>(DataContext, request, GetEventLogManager(), model));
        }
        
    }
}