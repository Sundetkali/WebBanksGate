namespace Dictionaries.Areas.DIC.DataAdapters
{
    using BanksGateDataModel.Models;
    using Dictionaries.Areas.DIC.ViewModels;
    using Nat.Web.Core.Controls.DataAdapters;

    using System.Web;

    public partial class BG_PaymentsDataAdapter
        : EntityDataAdapter<DataContext, BG_Payments, BG_PaymentsViewModel>
    {        public BG_PaymentsDataAdapter(DataContext dataContext, HttpContextBase httpContext)
            : base(dataContext, httpContext)
        {
        }
    }
}