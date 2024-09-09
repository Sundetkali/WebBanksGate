namespace Dictionaries.Areas.DIC.DataAdapters
{
    using BanksGateDataModel.Models;
    using Dictionaries.Areas.DIC.ViewModels;
    using Nat.Web.Core.Controls.DataAdapters;

    using System.Web;

    public partial class MT102_TBLDataAdapter
        : EntityDataAdapter<DataContext, MT102_TBL, MT102_TBLViewModel, MT102_TBLMinimalViewModel>
    {        public MT102_TBLDataAdapter(DataContext dataContext, HttpContextBase httpContext)
            : base(dataContext, httpContext)
        {
        }
    }
}