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

    // [Authorize]
    public partial class BG_PaymentsController : Controller
    {
        private DataAdapters.BG_PaymentsDataAdapter innerDataAdapter;

        public BG_PaymentsController(DataContext dbContext, IEventLogManager log)
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

        public DataAdapters.BG_PaymentsDataAdapter InnerDataAdapter => innerDataAdapter ?? (innerDataAdapter = new DataAdapters.BG_PaymentsDataAdapter(DataContext, HttpContext));

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
        partial void GetDataIndexPartial(ref IQueryable<BG_PaymentsViewModel> data, DataSourceRequest request);
        static partial void IndexGridModelInitialize(HttpContext httpContext, GridViewModel model);
        
        [NonAction]
        public static GridViewModel IndexGridViewModel(HttpContext httpContext, GridViewModelRoute route)
        {
            var model =
                new GridViewModel//<BG_PaymentsViewModel>
                    {
                        Route = route,
                        Batch = false,
                        ReadDataParametersHandler = route.ReadDataParametersHandler,
                        Read = new ActionViewModel
                            {
                                Controller = "BG_Payments",
                                Action = nameof(GetData),
                            },
                        Update = new ActionViewModel
                            {
                                Controller = "BG_Payments",
                                Action = nameof(Update),
                            },
                        Create = new ActionViewModel
                            {
                                Controller = "BG_Payments",
                                Action = nameof(Create),
                            },
                        Destroy = new ActionViewModel
                            {
                                Controller = "BG_Payments",
                                Action = nameof(Destroy),
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
        
        
        [EventActionLog(SourceCodeType = typeof(BG_PaymentsViewModel))]
        public ActionResult Index(GridViewModelRoute route)
        {
            InitViewDataForIndex();
            var model = IndexGridViewModel(HttpContext, route);
            ActionResult view = View(model);
            IndexPartial(ref view, model);
            return view;
        }
        
        [EventActionLog(SourceCodeType = typeof(BG_PaymentsViewModel), TypeCode = "View")]
        public ActionResult GetData([DataSourceRequest] DataSourceRequest request)
        {
            GetDataIndexPartial(request);
            var data = InnerDataAdapter.ReadViewModel1().OrderByDescending(r => r.id).AsQueryable();
            GetDataIndexPartial(ref data, request);
            request.ChangeSortByViewModel<BG_PaymentsViewModel>();
            var jsonData = data.ToDataSourceResult(request);
            GetEventLogManager().LogGetData(this);
            return Json(jsonData);
        }
        
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(BG_PaymentsViewModel), TypeCode = "Update")]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, BG_PaymentsViewModel model)
        {
            return Json(this.Update<DataContext, BG_PaymentsViewModel, BG_Payments>(DataContext, request, GetEventLogManager(), model));
        }
        
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(BG_PaymentsViewModel), TypeCode = "Create")]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, BG_PaymentsViewModel model)
        {
            return Json(this.Create<DataContext, BG_PaymentsViewModel, BG_Payments>(DataContext, request, GetEventLogManager(), model));
        }
        
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(BG_PaymentsViewModel), TypeCode = "Destroy")]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, BG_PaymentsViewModel model)
        {
            return Json(this.Destroy<DataContext, BG_PaymentsViewModel, BG_Payments>(DataContext, request, GetEventLogManager(), model));
        }
    }
}