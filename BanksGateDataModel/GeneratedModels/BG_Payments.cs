namespace BanksGateDataModel.Models
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.ComponentModel.DataAnnotations;
    using global::System.ComponentModel.DataAnnotations.Schema;
    using global::System.Xml.Linq;
    using global::System.Data.Entity;

    /// <summary>
    /// Платежи БГ.
    /// </summary>
    public partial class BG_Payments
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
        ///     Amount.
        ///     <remarks>
        ///         Сумма платежа.
        ///     </remarks>
        /// </summary>
        public Int32? Amount { get; set; }

        /// <summary>
        ///     Sender.
        ///     <remarks>
        ///         Отправитель.
        ///     </remarks>
        /// </summary>
        public String Sender { get; set; }

        /// <summary>
        ///     Note.
        ///     <remarks>
        ///         Примечание.
        ///     </remarks>
        /// </summary>
        public String Note { get; set; }
    }

    public partial class DataContext
    {
        /// <summary>
        /// Платежи БГ.
        /// </summary>
        public DbSet<BG_Payments> BG_Payments { get; set; }
    }
}