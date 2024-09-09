using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using Hangfire;
using Hangfire.Storage;
using Nat.Web.Core.System.CMS;
using Nat.Web.Core.System.EventLog;
using Nat.Web.Core.System.Extensions;
using Nat.Web.Core.System.ViewModels;
using Newtonsoft.Json;
using WebSite.Properties;
using WebSite.ViewModels;

namespace WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMenuService _menu;

        protected IEventLogManager Log { get; }


        public HomeController()
        {
            //IMenuService menu, IEventLogManager log
            // _menu = menu;
            // Log = log;
        }

        protected override void Initialize(RequestContext requestContext)
        {
            requestContext.SetThreadCulture();
            base.Initialize(requestContext);
        }

        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            return View();
        }

        [Authorize]
        public ActionResult AccessDenied(bool? emptyLayout)
        {
            ViewBag.EmptyLayout = emptyLayout ?? false;
            return View();
        }

        [AllowAnonymous]
        public ActionResult Error(string method, string message)
        {
            Response.StatusCode = string.IsNullOrEmpty(method) || !method.ToUpper().Equals("GET") ? 500 : 200;
            ViewBag.Message = message ?? string.Empty;
            if (!string.IsNullOrEmpty(message) && Response.StatusCode == 500)
            {
                Response.StatusDescription = message;
            }

            return View();
        }

        [ChildActionOnly]
        public ActionResult Menu(long? childredForId, int? maxChildrenLevel)
        {
            return View("Menu",
                new MainMenuViewModel
                {
                    MenuService = _menu,
                    ChildredForId = null,
                    MaxChildrenLevel = maxChildrenLevel ?? 2,
                });
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetJobState(string jobId)
        {
            JobData jobData;
            string alertMessage;
            string progressMessage;
            using (var connection = JobStorage.Current.GetConnection())
            {
                jobData = connection.GetJobData(jobId);
                alertMessage = connection.GetJobParameter(jobId, "AlertMessage");
                progressMessage = connection.GetJobParameter(jobId, "ProgressMessage");
            }

            if (jobData == null)
                return Json(new { success = false });

            if (!string.IsNullOrEmpty(alertMessage))
                alertMessage = JsonConvert.DeserializeObject<string>(alertMessage);

            if (!string.IsNullOrEmpty(progressMessage))
                progressMessage = JsonConvert.DeserializeObject<string>(progressMessage);

            var jobName = "№" + jobId;
            if (jobData.Job != null && jobData.Job.Method != null)
            {
                var attr = jobData.Job.Method.GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault();
                if (attr != null) jobName = string.Format(attr.DisplayName, jobData.Job.Args.ToArray());
            }

            var jobStateName = JobStateResources.ResourceManager.GetString(jobData.State) ?? jobData.State;
            return Json(new
            {
                success = true,
                JobId = jobId,
                AlertMessage = alertMessage,
                ProgressMessage = progressMessage,
                JobState = jobData.State,
                JobStateName = jobStateName,
                Message = string.Format(JobStateResources.SStateMessageLink, jobId, jobStateName, jobName),
            });
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetJobParameters(string jobId, string[] parameters)
        {
            using (var connection = JobStorage.Current.GetConnection())
            {
                var data = parameters.ToDictionary(name => name, name => connection.GetJobParameter(jobId, name));
                return Json(new { success = true, jobId, data });
            }
        }

        [Authorize]
        [HttpPost]
        public ActionResult GetRecurringJobState(string jobId)
        {
            RecurringJobDto jobData;
            string alertMessage = null;
            using (var connection = JobStorage.Current.GetConnection())
            {
                jobData = connection.GetRecurringJobs().FirstOrDefault(r => r.Id == jobId);

                if (jobData == null)
                    return Json(new { success = false });

                if (!string.IsNullOrEmpty(jobData.LastJobId))
                    alertMessage = connection.GetJobParameter(jobData.LastJobId, "AlertMessage");
            }

            if (!string.IsNullOrEmpty(alertMessage))
                alertMessage = JsonConvert.DeserializeObject<string>(alertMessage);

            var jobName = "№" + jobData.LastJobId;
            if (jobData.Job.Method != null)
            {
                var attr = jobData.Job.Method.GetCustomAttributes<DisplayNameAttribute>().FirstOrDefault();
                if (attr != null) jobName = string.Format(attr.DisplayName, jobData.Job.Args.ToArray());
            }

            var jobStateName = JobStateResources.ResourceManager.GetString(jobData.LastJobState ?? "Non") ?? jobData.LastJobState;
            return Json(new
            {
                success = true,
                JobId = jobId,
                AlertMessage = alertMessage,
                jobData.LastJobId,
                jobData.LastExecution,
                jobData.NextExecution,
                jobData.Error,
                JobState = jobData.LastJobState,
                JobStateName = jobStateName,
                Message = string.Format(JobStateResources.SStateMessageLink, jobData.LastJobId, jobStateName, jobName),
            });
        }

        //public ActionResult ExportExcel(string source)
        //{
        //    Log.Log(this, () => "Стандартная выгрузка журнала в эксель", false, "Export", "Information", source);

        //    return Json(new { success = true });
        //}

        [HttpPost]
        public ActionResult ExportExcel(string source, string contentType, string base64, string fileName)
        {
            Log.Log(this, () => "Стандартная выгрузка журнала в эксель", false, "Export", "Information", source);

            var fileContents = Convert.FromBase64String(base64);

            return File(fileContents, contentType, fileName);
        }


    }
}