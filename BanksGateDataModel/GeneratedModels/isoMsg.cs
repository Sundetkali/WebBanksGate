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
    /// Сообщение.
    /// </summary>
    public partial class isoMsg
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         msgId.
        ///     </remarks>
        /// </summary>
        [Key]
        public Int64 id { get; set; }

        /// <summary>
        ///     REFusrId.
        ///     <remarks>
        ///         Владелец.
        ///     </remarks>
        /// </summary>
        public Int64? REFusrId { get; set; }

        /// <summary>
        ///     parentMsgId.
        ///     <remarks>
        ///         parentMsgId.
        ///     </remarks>
        /// </summary>
        public Int64? parentMsgId { get; set; }

        /// <summary>
        ///     bizId.
        ///     <remarks>
        ///         bizMSGId.
        ///     </remarks>
        /// </summary>
        public String bizId { get; set; }

        /// <summary>
        ///     grpMsgId.
        ///     <remarks>
        ///         grpMsgId.
        ///     </remarks>
        /// </summary>
        public String grpMsgId { get; set; }

        /// <summary>
        ///     msgPurpose.
        ///     <remarks>
        ///         Тип платежа.
        ///     </remarks>
        /// </summary>
        public Byte? msgPurpose { get; set; }

        /// <summary>
        ///     msgDir.
        ///     <remarks>
        ///         Направление.
        ///     </remarks>
        /// </summary>
        public Byte? msgDir { get; set; }

        /// <summary>
        ///     msgType.
        ///     <remarks>
        ///         Тип МХ.
        ///     </remarks>
        /// </summary>
        public Int32? msgType { get; set; }

        /// <summary>
        ///     msgTypeVer.
        ///     <remarks>
        ///         msgTypeVer.
        ///     </remarks>
        /// </summary>
        public String msgTypeVer { get; set; }

        /// <summary>
        ///     msgError.
        ///     <remarks>
        ///         msgError.
        ///     </remarks>
        /// </summary>
        public String msgError { get; set; }

        /// <summary>
        ///     state.
        ///     <remarks>
        ///         state.
        ///     </remarks>
        /// </summary>
        public Int32? state { get; set; }

        /// <summary>
        ///     sysDate.
        ///     <remarks>
        ///         Системная дата импорта.
        ///     </remarks>
        /// </summary>
        public DateTime? sysDate { get; set; }

        /// <summary>
        ///     sysTm.
        ///     <remarks>
        ///         Системное время импорта.
        ///     </remarks>
        /// </summary>
        public DateTime? sysTm { get; set; }

        /// <summary>
        ///     sender.
        ///     <remarks>
        ///         sender.
        ///     </remarks>
        /// </summary>
        public String sender { get; set; }

        /// <summary>
        ///     addressee.
        ///     <remarks>
        ///         addressee.
        ///     </remarks>
        /// </summary>
        public String addressee { get; set; }

        /// <summary>
        ///     rootTag.
        ///     <remarks>
        ///         rootTag.
        ///     </remarks>
        /// </summary>
        public String rootTag { get; set; }

        /// <summary>
        ///     stmp.
        ///     <remarks>
        ///         stmp.
        ///     </remarks>
        /// </summary>
        public String stmp { get; set; }

        /// <summary>
        ///     stmpApp.
        ///     <remarks>
        ///         Источник.
        ///     </remarks>
        /// </summary>
        public Byte? stmpApp { get; set; }

        /// <summary>
        ///     sprtry.
        ///     <remarks>
        ///         sprtry.
        ///     </remarks>
        /// </summary>
        public String sprtry { get; set; }

        /// <summary>
        ///     aprtry.
        ///     <remarks>
        ///         aprtry.
        ///     </remarks>
        /// </summary>
        public String aprtry { get; set; }

        /// <summary>
        ///     mprty.
        ///     <remarks>
        ///         mprty.
        ///     </remarks>
        /// </summary>
        public Byte? mprty { get; set; }

        /// <summary>
        ///     mdate.
        ///     <remarks>
        ///         mdate.
        ///     </remarks>
        /// </summary>
        public DateTime? mdate { get; set; }

        /// <summary>
        ///     swtMsg.
        ///     <remarks>
        ///         swtMsg.
        ///     </remarks>
        /// </summary>
        public Int32? swtMsg { get; set; }

        /// <summary>
        ///     isVolpay.
        ///     <remarks>
        ///         isVolpay.
        ///     </remarks>
        ///     True - Да
        ///     False - Нет
        /// </summary>
        public Boolean? isVolpay { get; set; }

        /// <summary>
        ///     msgAmount.
        ///     <remarks>
        ///         msgAmount.
        ///     </remarks>
        /// </summary>
        public Decimal? msgAmount { get; set; }

        /// <summary>
        ///     msgTerminal.
        ///     <remarks>
        ///         Платежная система.
        ///     </remarks>
        /// </summary>
        public String msgTerminal { get; set; }

        /// <summary>
        ///     rsPrt.
        ///     <remarks>
        ///         rsPrt.
        ///     </remarks>
        /// </summary>
        public Byte? rsPrt { get; set; }

        /// <summary>
        ///     oprDate.
        ///     <remarks>
        ///         oprDate.
        ///     </remarks>
        /// </summary>
        public DateTime? oprDate { get; set; }

        /// <summary>
        ///     msgComment.
        ///     <remarks>
        ///         msgComment.
        ///     </remarks>
        /// </summary>
        public String msgComment { get; set; }
    }

    public partial class DataContext
    {
        /// <summary>
        /// Сообщение.
        /// </summary>
        public DbSet<isoMsg> isoMsg { get; set; }
    }
}