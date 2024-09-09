namespace BanksGateDataModel.Models
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.ComponentModel.DataAnnotations;
    using global::System.ComponentModel.DataAnnotations.Schema;
    using global::System.Xml.Linq;
    using global::System.Data.Entity;
    using Nat.Web.Core.System.ModelAnnotations;

    /// <summary>
    /// .
    /// </summary>
    public partial class TaxPayments
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         Идентификатор.
        ///     </remarks>
        /// </summary>
        [Key]
        public Int64 id { get; set; }

        /// <summary>
        ///     Name.
        ///     <remarks>
        ///         Наименование.
        ///     </remarks>
        /// </summary>
        public String Name { get; set; }
    }

    public partial class DataContext
    {
        /// <summary>
        /// .
        /// </summary>
        public DbSet<TaxPayments> TaxPayments { get; set; }
    }
}