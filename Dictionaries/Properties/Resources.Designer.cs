﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dictionaries.Properties {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Dictionaries.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Дополнительная информация по клиенту.
        /// </summary>
        public static string AdditionalClientInfo {
            get {
                return ResourceManager.GetString("AdditionalClientInfo", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Утвердить.
        /// </summary>
        public static string Approve {
            get {
                return ResourceManager.GetString("Approve", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Невозможно утвердить, сменился статус записи, обновите данные на странице.
        /// </summary>
        public static string ApproveCantError {
            get {
                return ResourceManager.GetString("ApproveCantError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Вы действительно хотите утвердить?.
        /// </summary>
        public static string ApproveMessage {
            get {
                return ResourceManager.GetString("ApproveMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Счета клиентов.
        /// </summary>
        public static string BankAccounts {
            get {
                return ResourceManager.GetString("BankAccounts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на BaseId.
        /// </summary>
        public static string Base {
            get {
                return ResourceManager.GetString("Base", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на БИН/ИИН должен быть уникальным, запись с таким БИН/ИИН уже существует.
        /// </summary>
        public static string BINMustBeUnique {
            get {
                return ResourceManager.GetString("BINMustBeUnique", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Внимание! &lt;br/&gt;
        ///Получена информация о новом клиенте: «{0}» с BaseId «{1}». Необходимо указать для данного клиента отношение к филиалу или представительству (отметить в справочнике).
        /// </summary>
        public static string BodyLetterForNewClients {
            get {
                return ResourceManager.GetString("BodyLetterForNewClients", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Утвердить.
        /// </summary>
        public static string CalendarDate_Approve {
            get {
                return ResourceManager.GetString("CalendarDate_Approve", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Вы действительно хотите утвердить?.
        /// </summary>
        public static string CalendarDate_ApproveConfirm {
            get {
                return ResourceManager.GetString("CalendarDate_ApproveConfirm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на В календарь на дату {0} было внесено изменение пользователем: {1}. 
        ///Для того, чтобы изменение вступило в силу, перейдите в справочник &quot;Календарь&quot; и подтвердите изменение..
        /// </summary>
        public static string CalendarDate_NotifBody {
            get {
                return ResourceManager.GetString("CalendarDate_NotifBody", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Добавление или изменение даты календаря.
        /// </summary>
        public static string CalendarDate_NotifSubject {
            get {
                return ResourceManager.GetString("CalendarDate_NotifSubject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Вы действительно хотите отклонить?.
        /// </summary>
        public static string CalendarDate_RejectConfirm {
            get {
                return ResourceManager.GetString("CalendarDate_RejectConfirm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отклонить.
        /// </summary>
        public static string CalendarDateReject {
            get {
                return ResourceManager.GetString("CalendarDateReject", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отмена.
        /// </summary>
        public static string Cancel {
            get {
                return ResourceManager.GetString("Cancel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Неудалось конвертировать с xls в xlsx, загрузите файл в формате xlsx..
        /// </summary>
        public static string CantConvertToXlsxUploadXslx {
            get {
                return ResourceManager.GetString("CantConvertToXlsxUploadXslx", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Не удалось найти шаблон.
        /// </summary>
        public static string CantFindTemplate {
            get {
                return ResourceManager.GetString("CantFindTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Выбор основания для отправки сообщения в АМЛ.
        /// </summary>
        public static string ChooseAmlMessageCode {
            get {
                return ResourceManager.GetString("ChooseAmlMessageCode", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Журнал событий.
        /// </summary>
        public static string ClientFormLog {
            get {
                return ResourceManager.GetString("ClientFormLog", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Можно загружать только файлы типов xls и xlsx.
        /// </summary>
        public static string ClientList_XLS_FilesOnly {
            get {
                return ResourceManager.GetString("ClientList_XLS_FilesOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Клиент.
        /// </summary>
        public static string ClientName {
            get {
                return ResourceManager.GetString("ClientName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Контакты клиента.
        /// </summary>
        public static string ClientsContact {
            get {
                return ResourceManager.GetString("ClientsContact", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Данные клиента.
        /// </summary>
        public static string ClientsData {
            get {
                return ResourceManager.GetString("ClientsData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Поиск производится по БИН, BaseID, УН ВД, наименование клиента.
        /// </summary>
        public static string ClientSearchByBaseIdBinName {
            get {
                return ResourceManager.GetString("ClientSearchByBaseIdBinName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Поиск производится по БИН, BaseID, наименование клиента.
        /// </summary>
        public static string ClientSearchByClientForm {
            get {
                return ResourceManager.GetString("ClientSearchByClientForm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Расследование.
        /// </summary>
        public static string ClientsInPayment_Investigation {
            get {
                return ResourceManager.GetString("ClientsInPayment_Investigation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Прикрепить.
        /// </summary>
        public static string ClientsInPayment_Link {
            get {
                return ResourceManager.GetString("ClientsInPayment_Link", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на MPP по клиенту.
        /// </summary>
        public static string ClientsMpp {
            get {
                return ResourceManager.GetString("ClientsMpp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Актуальный срок действия объема продажи валюты не обнаружен. Пожалуйста, укажите срок в справочнике.
        /// </summary>
        public static string CurrencyVolumeNotFound {
            get {
                return ResourceManager.GetString("CurrencyVolumeNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отправка невозможна: выбраны записи, относящиеся к более чем 1 клиенту!.
        /// </summary>
        public static string DiffRefsAlert {
            get {
                return ResourceManager.GetString("DiffRefsAlert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Скачать шаблон.
        /// </summary>
        public static string DownloadTemplate {
            get {
                return ResourceManager.GetString("DownloadTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Редактировать.
        /// </summary>
        public static string Edit {
            get {
                return ResourceManager.GetString("Edit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Редактировать менеджеров.
        /// </summary>
        public static string EditManager {
            get {
                return ResourceManager.GetString("EditManager", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отправить сообщение на эл.почту.
        /// </summary>
        public static string Email {
            get {
                return ResourceManager.GetString("Email", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на &lt;p&gt;Выбрано клиентов: {0}. &lt;br/&gt;Доставлено адресатам: {1}&lt;br/&gt;Не доставлено: {2}&lt;/p&gt;.
        /// </summary>
        public static string EmailMessageSendedAlert {
            get {
                return ResourceManager.GetString("EmailMessageSendedAlert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отсутствует email адрес клиента.
        /// </summary>
        public static string EmailNotFound {
            get {
                return ResourceManager.GetString("EmailNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отправка сообщения возможна только по одному клиенту.
        /// </summary>
        public static string EmailOnlyOneClient {
            get {
                return ResourceManager.GetString("EmailOnlyOneClient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Не отправлено, обратитесь к администратору.
        /// </summary>
        public static string ErrorSended {
            get {
                return ResourceManager.GetString("ErrorSended", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на При обработке запроса произошла ошибка, детали ошибки доступны администратору в журнале событий..
        /// </summary>
        public static string ErrorText {
            get {
                return ResourceManager.GetString("ErrorText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Показать клиентов с доп. проверкой.
        /// </summary>
        public static string FilterByGoodsPreCheckFalse {
            get {
                return ResourceManager.GetString("FilterByGoodsPreCheckFalse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Дополнительная проверка.
        /// </summary>
        public static string FilterByGoodsPreCheckTrue {
            get {
                return ResourceManager.GetString("FilterByGoodsPreCheckTrue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Показать субъекты квазигос.сектора.
        /// </summary>
        public static string FilterByQuasiPublicSectorFalse {
            get {
                return ResourceManager.GetString("FilterByQuasiPublicSectorFalse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Субъекты квазигос.сектора.
        /// </summary>
        public static string FilterByQuasiPublicSectorTrue {
            get {
                return ResourceManager.GetString("FilterByQuasiPublicSectorTrue", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на с.
        /// </summary>
        public static string From {
            get {
                return ResourceManager.GetString("From", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Добавить запись не возможно, так как введенное наименование клиента и тип документа уже существуют!.
        /// </summary>
        public static string refClientDocumentTypeMustBeUnique {
            get {
                return ResourceManager.GetString("refClientDocumentTypeMustBeUnique", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Невозможно отклонить, сменился статус записи, обновите данные на странице.
        /// </summary>
        public static string RejectCantError {
            get {
                return ResourceManager.GetString("RejectCantError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Поле &apos;{0}&apos; обязательно для заполнения.
        /// </summary>
        public static string RequiredFieldValidationError {
            get {
                return ResourceManager.GetString("RequiredFieldValidationError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Сбросить фильтр.
        /// </summary>
        public static string ResetFilter {
            get {
                return ResourceManager.GetString("ResetFilter", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на РНН должен быть уникальным, запись с таким РНН уже существует.
        /// </summary>
        public static string RNNMustBeUnique {
            get {
                return ResourceManager.GetString("RNNMustBeUnique", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Список админ сообщений из CF.
        /// </summary>
        public static string SClientsInContact_AdminMessages {
            get {
                return ResourceManager.GetString("SClientsInContact_AdminMessages", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Список счетов клиента.
        /// </summary>
        public static string SClientsInContact_ClientBankAccounts {
            get {
                return ResourceManager.GetString("SClientsInContact_ClientBankAccounts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Данные клиента.
        /// </summary>
        public static string SClientsInContact_ClientData {
            get {
                return ResourceManager.GetString("SClientsInContact_ClientData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Необходимо выбрать шаблон.
        /// </summary>
        public static string SelectEditTemplate {
            get {
                return ResourceManager.GetString("SelectEditTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Необходимо выбрать один шаблон.
        /// </summary>
        public static string SelectOneEditTemplate {
            get {
                return ResourceManager.GetString("SelectOneEditTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Необходимо выбрать шаблон оповещения.
        /// </summary>
        public static string SelectOutlookTemplate {
            get {
                return ResourceManager.GetString("SelectOutlookTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Необходимо выбрать подписантов.
        /// </summary>
        public static string SelectSigners {
            get {
                return ResourceManager.GetString("SelectSigners", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отправлено.
        /// </summary>
        public static string Sended {
            get {
                return ResourceManager.GetString("Sended", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отправить сообщение клиенту.
        /// </summary>
        public static string SendEmailMessageButton {
            get {
                return ResourceManager.GetString("SendEmailMessageButton", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отправить.
        /// </summary>
        public static string SendMessageButton {
            get {
                return ResourceManager.GetString("SendMessageButton", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отправить уведомление.
        /// </summary>
        public static string SendNotification {
            get {
                return ResourceManager.GetString("SendNotification", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Вы действительно хотите отправить {0} записей, {1} клиент(-а/-ов)?.
        /// </summary>
        public static string SendSelectedSigners {
            get {
                return ResourceManager.GetString("SendSelectedSigners", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отправить уведомление.
        /// </summary>
        public static string SendStatementToClient {
            get {
                return ResourceManager.GetString("SendStatementToClient", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Подписанты.
        /// </summary>
        public static string Signatories {
            get {
                return ResourceManager.GetString("Signatories", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отчет по уведомлениям.
        /// </summary>
        public static string SignersModuleAlert {
            get {
                return ResourceManager.GetString("SignersModuleAlert", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Статус.
        /// </summary>
        public static string Status {
            get {
                return ResourceManager.GetString("Status", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Получена информация о новом клиенте.
        /// </summary>
        public static string TitleLetterForNewClients {
            get {
                return ResourceManager.GetString("TitleLetterForNewClients", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на по.
        /// </summary>
        public static string To {
            get {
                return ResourceManager.GetString("To", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Сформировать.
        /// </summary>
        public static string ToForm {
            get {
                return ResourceManager.GetString("ToForm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Отклонить.
        /// </summary>
        public static string UnApprove {
            get {
                return ResourceManager.GetString("UnApprove", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Вы действительно хотите отклонить?.
        /// </summary>
        public static string UnapproveMessage {
            get {
                return ResourceManager.GetString("UnapproveMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Выгружаемый список.
        /// </summary>
        public static string UnloadList {
            get {
                return ResourceManager.GetString("UnloadList", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Необходимо выбрать выгружаемый список.
        /// </summary>
        public static string UnloadListError {
            get {
                return ResourceManager.GetString("UnloadListError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Можно загружать только файлы типов xls и xlsx.
        /// </summary>
        public static string UNNB_XLS_FilesOnly {
            get {
                return ResourceManager.GetString("UNNB_XLS_FilesOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Загрузить &quot;Счета клиентов&quot;.
        /// </summary>
        public static string UploadClientBankAccounts {
            get {
                return ResourceManager.GetString("UploadClientBankAccounts", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Загрузить &quot;Клиенты&quot;.
        /// </summary>
        public static string UploadClientsExcel {
            get {
                return ResourceManager.GetString("UploadClientsExcel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Загрузить &quot;MPP по клиенту&quot;.
        /// </summary>
        public static string UploadClientsMppList {
            get {
                return ResourceManager.GetString("UploadClientsMppList", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Загрузить &quot;Контактные лица клиента&quot;.
        /// </summary>
        public static string UploadContactList {
            get {
                return ResourceManager.GetString("UploadContactList", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Импорт Excel.
        /// </summary>
        public static string UploadExcel {
            get {
                return ResourceManager.GetString("UploadExcel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Загрузка файла ОКЭД.
        /// </summary>
        public static string UploadOKED {
            get {
                return ResourceManager.GetString("UploadOKED", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Загрузить &quot;ОКЭД клиента&quot;.
        /// </summary>
        public static string UploadOKEDExcel {
            get {
                return ResourceManager.GetString("UploadOKEDExcel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Загрузить &quot;Подписанты&quot;.
        /// </summary>
        public static string UploadSignatories {
            get {
                return ResourceManager.GetString("UploadSignatories", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Загрузить новый шаблон.
        /// </summary>
        public static string UploadTemplate {
            get {
                return ResourceManager.GetString("UploadTemplate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Загрузить &quot;Сведения о действующих учетных номерах НБ РК&quot;.
        /// </summary>
        public static string UploadUNNB {
            get {
                return ResourceManager.GetString("UploadUNNB", resourceCulture);
            }
        }
    }
}
