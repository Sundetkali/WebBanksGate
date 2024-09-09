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
    /// Сообщение - МТ950.
    /// </summary>
    public partial class MT950_TBL
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         ID_EXTRACT.
        ///     </remarks>
        /// </summary>
        [Key]
        public Decimal id { get; set; }

        /// <summary>
        ///     REFERENSE.
        ///     <remarks>
        ///         REFERENSE.
        ///     </remarks>
        /// </summary>
        public String REFERENSE { get; set; }

        /// <summary>
        ///     BIC.
        ///     <remarks>
        ///         BIC.
        ///     </remarks>
        /// </summary>
        public String BIC { get; set; }

        /// <summary>
        ///     ACCOUNT.
        ///     <remarks>
        ///         ACCOUNT.
        ///     </remarks>
        /// </summary>
        public String ACCOUNT { get; set; }

        /// <summary>
        ///     FNUM.
        ///     <remarks>
        ///         FNUM.
        ///     </remarks>
        /// </summary>
        public String FNUM { get; set; }

        /// <summary>
        ///     FCOUNT.
        ///     <remarks>
        ///         FCOUNT.
        ///     </remarks>
        /// </summary>
        public String FCOUNT { get; set; }

        /// <summary>
        ///     FSTART.
        ///     <remarks>
        ///         FSTART.
        ///     </remarks>
        /// </summary>
        public Decimal? FSTART { get; set; }

        /// <summary>
        ///     OPER_A.
        ///     <remarks>
        ///         OPER_A.
        ///     </remarks>
        /// </summary>
        public String OPER_A { get; set; }

        /// <summary>
        ///     DATE_A.
        ///     <remarks>
        ///         DATE_A.
        ///     </remarks>
        /// </summary>
        public String DATE_A { get; set; }

        /// <summary>
        ///     CODE_A.
        ///     <remarks>
        ///         CODE_A.
        ///     </remarks>
        /// </summary>
        public String CODE_A { get; set; }

        /// <summary>
        ///     AMOUNT_A.
        ///     <remarks>
        ///         AMOUNT_A.
        ///     </remarks>
        /// </summary>
        public String AMOUNT_A { get; set; }

        /// <summary>
        ///     FEND.
        ///     <remarks>
        ///         FEND.
        ///     </remarks>
        /// </summary>
        public Decimal? FEND { get; set; }

        /// <summary>
        ///     OPER_C.
        ///     <remarks>
        ///         OPER_C.
        ///     </remarks>
        /// </summary>
        public String OPER_C { get; set; }

        /// <summary>
        ///     DATE_C.
        ///     <remarks>
        ///         DATE_C.
        ///     </remarks>
        /// </summary>
        public String DATE_C { get; set; }

        /// <summary>
        ///     CODE_C.
        ///     <remarks>
        ///         CODE_C.
        ///     </remarks>
        /// </summary>
        public String CODE_C { get; set; }

        /// <summary>
        ///     AMOUNT_C.
        ///     <remarks>
        ///         AMOUNT_C.
        ///     </remarks>
        /// </summary>
        public String AMOUNT_C { get; set; }

        /// <summary>
        ///     FCODENAME.
        ///     <remarks>
        ///         FCODENAME.
        ///     </remarks>
        /// </summary>
        public String FCODENAME { get; set; }

        /// <summary>
        ///     ID_MESSAGE.
        ///     <remarks>
        ///         ID_MESSAGE.
        ///     </remarks>
        /// </summary>
        public Int32 ID_MESSAGE { get; set; }

        /// <summary>
        ///     FTYPE.
        ///     <remarks>
        ///         FTYPE.
        ///     </remarks>
        /// </summary>
        public Int32? FTYPE { get; set; }

        /// <summary>
        ///     FSYSTEM.
        ///     <remarks>
        ///         FSYSTEM.
        ///     </remarks>
        /// </summary>
        public Int32? FSYSTEM { get; set; }
    }

    public partial class DataContext
    {
        /// <summary>
        /// Сообщение - МТ950.
        /// </summary>
        public DbSet<MT950_TBL> MT950_TBL { get; set; }
    }
}