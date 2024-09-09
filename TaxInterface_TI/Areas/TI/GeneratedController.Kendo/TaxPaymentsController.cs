namespace TaxInterface_TI.Areas.TI.Controllers
{
    using global::Kendo.Mvc.Extensions;
    using global::Kendo.Mvc.UI;

    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Linq.Expressions;
    using Microsoft.Ajax.Utilities;

    using BanksGateDataModel.Models;
    using TaxInterface_TI.Areas.TI.ViewModels;
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
    public partial class TaxPaymentsController : Controller
    {
        private DataAdapters.TaxPaymentsDataAdapter innerDataAdapter;

        public TaxPaymentsController(DataContext dbContext, IEventLogManager log)
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

        public DataAdapters.TaxPaymentsDataAdapter InnerDataAdapter => innerDataAdapter ?? (innerDataAdapter = new DataAdapters.TaxPaymentsDataAdapter(DataContext, HttpContext));

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
        partial void GetDataIndexPartial(ref IQueryable<TaxPaymentsViewModel> data, DataSourceRequest request);
        static partial void IndexGridModelInitialize(HttpContext httpContext, GridViewModel model);
        
        [NonAction]
        public static GridViewModel IndexGridViewModel(HttpContext httpContext, GridViewModelRoute route)
        {
            var model =
                new GridViewModel//<TaxPaymentsViewModel>
                    {
                        Route = route,
                        Batch = false,
                        ReadDataParametersHandler = route.ReadDataParametersHandler,
                        Read = new ActionViewModel
                            {
                                Controller = "TaxPayments",
                                Action = nameof(GetData),
                            },
                        Update = new ActionViewModel
                            {
                                Controller = "TaxPayments",
                                Action = nameof(Update),
                            },
                        Create = new ActionViewModel
                            {
                                Controller = "TaxPayments",
                                Action = nameof(Create),
                            },
                        Destroy = new ActionViewModel
                            {
                                Controller = "TaxPayments",
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
        
        
        [EventActionLog(SourceCodeType = typeof(TaxPaymentsViewModel))]
        public ActionResult Index(GridViewModelRoute route)
        {
            InitViewDataForIndex();
            var model = IndexGridViewModel(HttpContext, route);
            ActionResult view = View(model);
            IndexPartial(ref view, model);
            return view;
        }
        
        [EventActionLog(SourceCodeType = typeof(TaxPaymentsViewModel), TypeCode = "View")]
        public ActionResult GetData([DataSourceRequest] DataSourceRequest request)
        {
            GetDataIndexPartial(request);
            var data = InnerDataAdapter.ReadViewModel1().OrderByDescending(r => r.id).AsQueryable();
            GetDataIndexPartial(ref data, request);
            request.ChangeSortByViewModel<TaxPaymentsViewModel>();
            var jsonData = data.ToDataSourceResult(request);
            GetEventLogManager().LogGetData(this);
            return Json(jsonData);
        }
        
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(TaxPaymentsViewModel), TypeCode = "Update")]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, TaxPaymentsViewModel model)
        {
            return Json(this.Update<DataContext, TaxPaymentsViewModel, TaxPayments>(DataContext, request, GetEventLogManager(), model));
        }
        
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(TaxPaymentsViewModel), TypeCode = "Create")]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, TaxPaymentsViewModel model)
        {
            return Json(this.Create<DataContext, TaxPaymentsViewModel, TaxPayments>(DataContext, request, GetEventLogManager(), model));
        }
        
        [AcceptVerbs("Post")]
        [EventActionLog(SourceCodeType = typeof(TaxPaymentsViewModel), TypeCode = "Destroy")]
        public ActionResult Destroy([DataSourceRequest] DataSourceRequest request, TaxPaymentsViewModel model)
        {
            return Json(this.Destroy<DataContext, TaxPaymentsViewModel, TaxPayments>(DataContext, request, GetEventLogManager(), model));
        }
    }
}