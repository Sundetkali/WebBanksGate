namespace Dictionaries.Areas.DIC.DataAdapters
{
    using BanksGateDataModel.Models;
    using Dictionaries.Areas.DIC.ViewModels;
    using Nat.Web.Core.Controls.DataAdapters;

    using System.Web;

    public partial class MT100_TBLDataAdapter
        : EntityDataAdapter<DataContext, MT100_TBL, MT100_TBLViewModel, MT100_TBLMinimalViewModel>
    {        public MT100_TBLDataAdapter(DataContext dataContext, HttpContextBase httpContext)
            : base(dataContext, httpContext)
        {
        }
    }
}