if(!window.Nat) Nat = {};
if(!window.VM) window.VM = {};
if(!Nat.DIC) Nat.DIC = {};

if (!Nat.DIC.Initialized) {
    Nat.DIC.Initialized = true;

    Nat.DIC.InitializeClients = function(options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "Clients", "clients");
    };

    Nat.DIC.InitializeClientsSelection = function(options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "ClientsSelection", options.gridName);
    };

    Nat.DIC.InitializeClientsInContracts = function(options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "ClientsInContracts", options.gridName);
    };
    
    Nat.DIC.InitializeClientsAccountsInContracts = function(options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "ClientsAccountsInContracts", "clientsAccountsInContracts");
    };

    Nat.DIC.InitializeClientContacts = function(options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "ClientContacts", options.gridName);
    };

    Nat.DIC.InitializeBankAccountTypes = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "BankAccountTypes", options.gridName);
    };

    Nat.DIC.InitializeClientBankAccounts = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "ClientBankAccounts", "clientBankAccounts");
    };

    Nat.DIC.InitializeSignatories = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "Signatories", options.gridName);
    };

    Nat.DIC.InitializeSignatoriesTemplates = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "SignatoriesTemplates", options.gridName);
    };

    Nat.DIC.InitializeCitistoreTemplates = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "CitistoreTemplates", options.gridName);
    };

    Nat.DIC.InitializeEditTemplates = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "EditTemplates", options.gridName);
    };

    Nat.DIC.InitializeClientSendDataExceptions = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "ClientSendDataExceptions", options.gridName);
    };

    Nat.DIC.InitializeComplianceBankAccounts = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "ComplianceBankAccounts", options.gridName);
    };

    Nat.DIC.InitializeComplianceEKNPTreasurys = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "ComplianceEKNPTreasurys", options.gridName);
    };

    Nat.DIC.InitializeEKNPAccountTransactionCode = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "EKNPAccountTransactionCode", options.gridName);
    };

    Nat.DIC.InitializeClientsMPP = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "ClientsMPP", options.gridName);
    };

    Nat.DIC.InitializeMailingGroup = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "MailingGroup", options.gridName);
    };

    Nat.DIC.InitializeClientsForm = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "ClientsForm", options.gridName);
    };

    Nat.DIC.InitializeSignersModule = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "SignersModule", options.gridName);
    };

    Nat.DIC.InitializeOutlookTemplates = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "OutlookTemplates", options.gridName);
    };

    Nat.DIC.InitializeUNNB = function(options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "UNNB", 'unnb');
    };

    Nat.DIC.InitializeCalendar = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "Calendar", options.gridName);
    };

    Nat.DIC.InitializeBasicMakerChecker = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "BasicMakerChecker", options.gridName);
    };

    Nat.DIC.InitializeEconomicTradeType = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "EconomicTradeType", options.gridName);
    };

    Nat.DIC.InitializeStatementsTranslate = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "StatementsTranslate", options.gridName);
    };

    Nat.DIC.InitializeClientBankAccountClassException = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "ClientBankAccountClassExceptions", options.gridName);
    };
    Nat.DIC.InitializeCountries = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "Countries", options.gridName);
    };
    Nat.DIC.InitializeWeekendMaster = function (options) {
        Nat.F.MainFuncInit(VM, options, 'DIC', "WeekendMaster", options.gridName);
    };
    
}