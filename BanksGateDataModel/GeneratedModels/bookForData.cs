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
    /// Книга для сбора данных.
    /// </summary>
    public partial class bookForData
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         recId.
        ///     </remarks>
        /// </summary>
        [Key]
        public Int64 id { get; set; }

        /// <summary>
        ///     REFmsgQueId.
        ///     <remarks>
        ///         REFmsgQueId.
        ///     </remarks>
        /// </summary>
        public Int64? REFmsgQueId { get; set; }

        /// <summary>
        ///     REFid.
        ///     <remarks>
        ///         REFmsgId.
        ///     </remarks>
        /// </summary>
        public Int64? REFid { get; set; }

        /// <summary>
        ///     stmpBody.
        ///     <remarks>
        ///         stmpBody.
        ///     </remarks>
        /// </summary>
        public String stmpBody { get; set; }

        /// <summary>
        ///     stmpDataType.
        ///     <remarks>
        ///         stmpDataType.
        ///     </remarks>
        /// </summary>
        public Int32? stmpDataType { get; set; }

        /// <summary>
        ///     REFrxcId.
        ///     <remarks>
        ///         REFrxcId.
        ///     </remarks>
        /// </summary>
        public Int64? REFrxcId { get; set; }

        [ForeignKey("REFid")]
        public virtual BanksGateDataModel.Models.isoMsg isoMsg_REFid { get; set; }
    }

    public partial class DataContext
    {
        /// <summary>
        /// Книга для сбора данных.
        /// </summary>
        public DbSet<bookForData> bookForData { get; set; }
    }
}