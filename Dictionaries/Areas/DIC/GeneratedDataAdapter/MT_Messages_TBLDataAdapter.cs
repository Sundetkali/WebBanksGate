namespace Dictionaries.Areas.DIC.DataAdapters
{
    using BanksGateDataModel.Models;
    using Dictionaries.Areas.DIC.ViewModels;
    using Nat.Web.Core.Controls.DataAdapters;

    using System.Web;

    public partial class MT_Messages_TBLDataAdapter
        : EntityDataAdapter<DataContext, MT_Messages_TBL, MT_Messages_TBLViewModel, MT_Messages_TBLMinimalViewModel>
    {        public MT_Messages_TBLDataAdapter(DataContext dataContext, HttpContextBase httpContext)
            : base(dataContext, httpContext)
        {
        }
    }
}