namespace Dictionaries.Areas.DIC.DataAdapters
{
    using BanksGateDataModel.Models;
    using Dictionaries.Areas.DIC.ViewModels;
    using Nat.Web.Core.Controls.DataAdapters;

    using System.Web;

    public partial class isoPaymentDataAdapter
        : EntityDataAdapter<DataContext, isoPayment, isoPaymentViewModel, isoPaymentMinimalViewModel>
    {        public isoPaymentDataAdapter(DataContext dataContext, HttpContextBase httpContext)
            : base(dataContext, httpContext)
        {
        }
    }
}