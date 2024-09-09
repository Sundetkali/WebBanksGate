using BanksGateDataModel.Models;
using TaxInterface_TI.Areas.TI.ViewModels;

namespace TaxInterface_TI.Areas.TI.DataAdapters
{
    using BanksGateDataModel.Models;
    using Nat.Web.Core.Controls.DataAdapters;

    using System.Web;

    public partial class TaxPaymentsDataAdapter
        : EntityDataAdapter<DataContext, TaxPayments, TaxPaymentsViewModel>
    {        public TaxPaymentsDataAdapter(DataContext dataContext, HttpContextBase httpContext)
            : base(dataContext, httpContext)
        {
        }
    }
}