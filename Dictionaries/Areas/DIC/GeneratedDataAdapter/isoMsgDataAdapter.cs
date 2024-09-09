namespace Dictionaries.Areas.DIC.DataAdapters
{
    using BanksGateDataModel.Models;
    using Dictionaries.Areas.DIC.ViewModels;
    using Nat.Web.Core.Controls.DataAdapters;

    using System.Web;

    public partial class isoMsgDataAdapter
        : EntityDataAdapter<DataContext, isoMsg, isoMsgViewModel, isoMsgMinimalViewModel>
    {        public isoMsgDataAdapter(DataContext dataContext, HttpContextBase httpContext)
            : base(dataContext, httpContext)
        {
        }
    }
}