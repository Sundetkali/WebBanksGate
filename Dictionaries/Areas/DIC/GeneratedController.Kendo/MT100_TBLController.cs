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
    public partial class MT100_TBLController : Controller
    {
        private DataAdapters.MT100_TBLDataAdapter innerDataAdapter;

        public MT100_TBLController(DataContext dbContext, IEventLogManager log)
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

        public DataAdapters.MT100_TBLDataAdapter InnerDataAdapter => innerDataAdapter ?? (innerDataAdapter = new DataAdapters.MT100_TBLDataAdapter(DataContext, HttpContext));

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
        partial void GetDataIndexPartial(ref IQueryable<MT100_TBLViewModel> data, DataSourceRequest request);
        static partial void IndexGridModelInitialize(HttpContext httpContext, GridViewModel model);
        
        [NonAction]
        public static GridViewModel IndexGridViewModel(HttpContext httpContext, GridViewModelRoute route)
        {
            var model =
                new GridViewModel//<MT100_TBLViewModel>
                    {
                        Route = route,
                        Batch = false,
                        ReadDataParametersHandler = route.ReadDataParametersHandler,
                        Read = new ActionViewModel
                            {
                                Controller = "MT100_TBL",
                                Action = nameof(GetData),
                                Roles = "MT100_TBL_Edit, MT100_TBL_Read, MT100_TBL_Delete, MT100_TBL_Create,",
                            },
                        Update = new ActionViewModel
                            {
                                Controller = "MT100_TBL",
                                Action = nameof(Update),
                                Roles = "MT100_TBL_Edit,",
                            },
                        Create = new ActionViewModel
                            {
                                Controller = "MT100_TBL",
                                Action = nameof(Create),
                                Roles = "MT100_TBL_Create,",
                            },
                        Destroy = new ActionViewModel
                            {
                                Controller = "MT100_TBL",
                                Action = nameof(Destroy),
                                Roles = "MT100_TBL_Delete,",
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
        
        
        [Authorize(Roles = "MT100_TBL_Edit, MT100_TBL_Read, MT100_TBL_Delete, MT100_TBL_Create,")]
        [EventActionLog(SourceCodeType = typeof(MT100_TBLViewModel))]
        public ActionResult Index(GridViewModelRoute route)
        {
            InitViewDataForIndex();
            var model = IndexGridViewModel(HttpContext, route);
            ActionResult view = View(model);
            IndexPartial(ref view, model);
            return view;
        }
        
        [Authorize(Roles = "MT100_TBL_Edit, MT100_TBL_Read, MT100_TBL_Delete, MT100_TBL_Create,")]
        [EventActionLog(SourceCodeType = typeof(MT100_TBLViewModel), TypeCode = "View")]
        public ActionResult GetData([DataSourceRequest] DataSourceRequest request)
        {
            GetDataIndexPartial(request);
            var data = InnerDataAdapter.ReadViewModel1().OrderByDescending(r => r.id).AsQueryable();
            GetDataIndexPartial(ref data, request);
            request.ChangeSortByViewModel<MT100_TBLViewModel>();
            var jsonData = data.ToDataSourceResult(request);
            GetEventLogManager().LogGetData(this);
            return Json(jsonData);
        }
        
        [Authorize(Roles = "MT100_TBL_Edit,")]
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(MT100_TBLViewModel), TypeCode = "Update")]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, MT100_TBLViewModel model)
        {
            return Json(this.Update<DataContext, MT100_TBLViewModel, MT100_TBL>(DataContext, request, GetEventLogManager(), model));
        }
        
        [Authorize(Roles = "MT100_TBL_Create,")]
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(MT100_TBLViewModel), TypeCode = "Create")]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, MT100_TBLViewModel model)
        {
            return Json(this.Create<DataContext, MT100_TBLViewModel, MT100_TBL>(DataContext, request, GetEventLogManager(), model));
        }
        
        [Authorize(Roles = "MT100_TBL_Delete,")]
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(MT100_TBLViewModel), TypeCode = "Destroy")]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, MT100_TBLViewModel model)
        {
            return Json(this.Destroy<DataContext, MT100_TBLViewModel, MT100_TBL>(DataContext, request, GetEventLogManager(), model));
        }
        
    }
}