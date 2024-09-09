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
    /// Платеж.
    /// </summary>
    public partial class isoPayment
    {
        /// <summary>
        ///     id.
        ///     <remarks>
        ///         payId.
        ///     </remarks>
        /// </summary>
        [Key]
        public Int64 id { get; set; }

        /// <summary>
        ///     REFid.
        ///     <remarks>
        ///         REFmsgId.
        ///     </remarks>
        /// </summary>
        public Int64 REFid { get; set; }

        /// <summary>
        ///     state.
        ///     <remarks>
        ///         Статус сообщение платежа.
        ///     </remarks>
        /// </summary>
        public Int32? state { get; set; }

        /// <summary>
        ///     isBreaked.
        ///     <remarks>
        ///         isBreaked.
        ///     </remarks>
        ///     True - Да
        ///     False - Нет
        /// </summary>
        public Boolean? isBreaked { get; set; }

        /// <summary>
        ///     grpMsgId.
        ///     <remarks>
        ///         grpMsgId.
        ///     </remarks>
        /// </summary>
        public String grpMsgId { get; set; }

        /// <summary>
        ///     txnId.
        ///     <remarks>
        ///         txnId.
        ///     </remarks>
        /// </summary>
        public String txnId { get; set; }

        /// <summary>
        ///     endToEndId.
        ///     <remarks>
        ///         endToEndId.
        ///     </remarks>
        /// </summary>
        public String endToEndId { get; set; }

        /// <summary>
        ///     uetrId.
        ///     <remarks>
        ///         uetrId.
        ///     </remarks>
        /// </summary>
        public String uetrId { get; set; }

        /// <summary>
        ///     grpCreDtTm.
        ///     <remarks>
        ///         Время создания платежа.
        ///     </remarks>
        /// </summary>
        public DateTime? grpCreDtTm { get; set; }

        /// <summary>
        ///     grpBtchBookg.
        ///     <remarks>
        ///         BatchBook.
        ///     </remarks>
        /// </summary>
        public Byte? grpBtchBookg { get; set; }

        /// <summary>
        ///     grpNbOfTxs.
        ///     <remarks>
        ///         Вложенных платежей.
        ///     </remarks>
        /// </summary>
        public Int32? grpNbOfTxs { get; set; }

        /// <summary>
        ///     grpTtlIntrBkSttlmAmt.
        ///     <remarks>
        ///         Сумма.
        ///     </remarks>
        /// </summary>
        public Decimal? grpTtlIntrBkSttlmAmt { get; set; }

        /// <summary>
        ///     ccy.
        ///     <remarks>
        ///         Ссу.
        ///     </remarks>
        /// </summary>
        public String ccy { get; set; }

        /// <summary>
        ///     grpDate.
        ///     <remarks>
        ///         Операционная дата платежа.
        ///     </remarks>
        /// </summary>
        public DateTime? grpDate { get; set; }

        /// <summary>
        ///     grpSender.
        ///     <remarks>
        ///         grpSender.
        ///     </remarks>
        /// </summary>
        public String grpSender { get; set; }

        /// <summary>
        ///     grpAddressee.
        ///     <remarks>
        ///         grpAddressee.
        ///     </remarks>
        /// </summary>
        public String grpAddressee { get; set; }

        /// <summary>
        ///     chrgBr.
        ///     <remarks>
        ///         Комиссия.
        ///     </remarks>
        /// </summary>
        public String chrgBr { get; set; }

        /// <summary>
        ///     dbtrNm.
        ///     <remarks>
        ///         Наименование отправителя.
        ///     </remarks>
        /// </summary>
        public String dbtrNm { get; set; }

        /// <summary>
        ///     dbtrSeco.
        ///     <remarks>
        ///         Сектор экономики отправителя.
        ///     </remarks>
        /// </summary>
        public String dbtrSeco { get; set; }

        /// <summary>
        ///     dbtrIrs.
        ///     <remarks>
        ///         Резиденство отправителя.
        ///     </remarks>
        /// </summary>
        public String dbtrIrs { get; set; }

        /// <summary>
        ///     dbtrAccountant.
        ///     <remarks>
        ///         Главный бухгалтер отправителя.
        ///     </remarks>
        /// </summary>
        public String dbtrAccountant { get; set; }

        /// <summary>
        ///     dbtrHead.
        ///     <remarks>
        ///         Руководитель отправителя.
        ///     </remarks>
        /// </summary>
        public String dbtrHead { get; set; }

        /// <summary>
        ///     dbtrIdn.
        ///     <remarks>
        ///         ИИН, БИН отправителя.
        ///     </remarks>
        /// </summary>
        public String dbtrIdn { get; set; }

        /// <summary>
        ///     dbtrCtryOfRes.
        ///     <remarks>
        ///         Страна резиденства отправителя.
        ///     </remarks>
        /// </summary>
        public String dbtrCtryOfRes { get; set; }

        /// <summary>
        ///     dbtrAcct.
        ///     <remarks>
        ///         Счет отправителя.
        ///     </remarks>
        /// </summary>
        public String dbtrAcct { get; set; }

        /// <summary>
        ///     dbtrAgt.
        ///     <remarks>
        ///         Бик отправителя.
        ///     </remarks>
        /// </summary>
        public String dbtrAgt { get; set; }

        /// <summary>
        ///     dbtr.
        ///     <remarks>
        ///         отправитель.
        ///     </remarks>
        /// </summary>
        public String dbtr { get; set; }

        /// <summary>
        ///     cdtr.
        ///     <remarks>
        ///         получатель.
        ///     </remarks>
        /// </summary>
        public String cdtr { get; set; }

        /// <summary>
        ///     cdtrNm.
        ///     <remarks>
        ///         Наименование получателя.
        ///     </remarks>
        /// </summary>
        public String cdtrNm { get; set; }

        /// <summary>
        ///     cdtrSeco.
        ///     <remarks>
        ///         Сектор экономики получателя.
        ///     </remarks>
        /// </summary>
        public String cdtrSeco { get; set; }

        /// <summary>
        ///     cdtrIrs.
        ///     <remarks>
        ///         Резиденство получателя.
        ///     </remarks>
        /// </summary>
        public String cdtrIrs { get; set; }

        /// <summary>
        ///     cdtrAccountant.
        ///     <remarks>
        ///         Главный бухгалтер получателя.
        ///     </remarks>
        /// </summary>
        public String cdtrAccountant { get; set; }

        /// <summary>
        ///     cdtrHead.
        ///     <remarks>
        ///         Руководитель получателя.
        ///     </remarks>
        /// </summary>
        public String cdtrHead { get; set; }

        /// <summary>
        ///     cdtrIdn.
        ///     <remarks>
        ///         ИИН, БИН получателя.
        ///     </remarks>
        /// </summary>
        public String cdtrIdn { get; set; }

        /// <summary>
        ///     cdtrCtryOfRes.
        ///     <remarks>
        ///         Страна резиденства получателя.
        ///     </remarks>
        /// </summary>
        public String cdtrCtryOfRes { get; set; }

        /// <summary>
        ///     cdtrAcct.
        ///     <remarks>
        ///         Счет получателя.
        ///     </remarks>
        /// </summary>
        public String cdtrAcct { get; set; }

        /// <summary>
        ///     cdtrAgt.
        ///     <remarks>
        ///         Бик получателя.
        ///     </remarks>
        /// </summary>
        public String cdtrAgt { get; set; }

        /// <summary>
        ///     cdtrAgtAcct.
        ///     <remarks>
        ///         cdtrAgtAcct.
        ///     </remarks>
        /// </summary>
        public String cdtrAgtAcct { get; set; }

        /// <summary>
        ///     cdtrAgtAcctTp.
        ///     <remarks>
        ///         cdtrAgtAcctTp.
        ///     </remarks>
        /// </summary>
        public String cdtrAgtAcctTp { get; set; }

        /// <summary>
        ///     cdtrKnp.
        ///     <remarks>
        ///         КНП.
        ///     </remarks>
        /// </summary>
        public String cdtrKnp { get; set; }

        /// <summary>
        ///     cdtrNb.
        ///     <remarks>
        ///         Номер документа.
        ///     </remarks>
        /// </summary>
        public String cdtrNb { get; set; }

        /// <summary>
        ///     cdtrRltdDt.
        ///     <remarks>
        ///         Дата документа.
        ///     </remarks>
        /// </summary>
        public DateTime? cdtrRltdDt { get; set; }

        /// <summary>
        ///     instrPrty.
        ///     <remarks>
        ///         instrPrty.
        ///     </remarks>
        /// </summary>
        public String instrPrty { get; set; }

        /// <summary>
        ///     instrLc.
        ///     <remarks>
        ///         instrLc.
        ///     </remarks>
        /// </summary>
        public String instrLc { get; set; }

        /// <summary>
        ///     orgBookAcc.
        ///     <remarks>
        ///         orgBookAcc.
        ///     </remarks>
        /// </summary>
        public String orgBookAcc { get; set; }

        /// <summary>
        ///     body.
        ///     <remarks>
        ///         body.
        ///     </remarks>
        /// </summary>
        public String body { get; set; }

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
        ///     sts.
        ///     <remarks>
        ///         sts.
        ///     </remarks>
        /// </summary>
        public String sts { get; set; }

        /// <summary>
        ///     stsRelation.
        ///     <remarks>
        ///         stsRelation.
        ///     </remarks>
        /// </summary>
        public String stsRelation { get; set; }

        /// <summary>
        ///     amntEq.
        ///     <remarks>
        ///         amntEq.
        ///     </remarks>
        /// </summary>
        public Decimal? amntEq { get; set; }

        /// <summary>
        ///     accCls.
        ///     <remarks>
        ///         accCls.
        ///     </remarks>
        /// </summary>
        public String accCls { get; set; }

        /// <summary>
        ///     bclass.
        ///     <remarks>
        ///         КБК.
        ///     </remarks>
        /// </summary>
        public String bclass { get; set; }

        /// <summary>
        ///     asgn.
        ///     <remarks>
        ///         asgn.
        ///     </remarks>
        /// </summary>
        public String asgn { get; set; }

        [ForeignKey("REFid")]
        public virtual BanksGateDataModel.Models.isoMsg isoMsg_REFid { get; set; }
    }

    public partial class DataContext
    {
        /// <summary>
        /// Платеж.
        /// </summary>
        public DbSet<isoPayment> isoPayment { get; set; }
    }
}