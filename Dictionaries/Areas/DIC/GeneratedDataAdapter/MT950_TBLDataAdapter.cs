namespace Dictionaries.Areas.DIC.DataAdapters
{
    using BanksGateDataModel.Models;
    using Dictionaries.Areas.DIC.ViewModels;
    using Nat.Web.Core.Controls.DataAdapters;

    using System.Web;

    public partial class MT950_TBLDataAdapter
        : EntityDataAdapter<DataContext, MT950_TBL, MT950_TBLViewModel, MT950_TBLMinimalViewModel>
    {        public MT950_TBLDataAdapter(DataContext dataContext, HttpContextBase httpContext)
            : base(dataContext, httpContext)
        {
        }
    }
}