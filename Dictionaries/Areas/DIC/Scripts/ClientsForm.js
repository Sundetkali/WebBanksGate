Nat.DIC.ClientsForm = function (vm, options) {
    Nat.ADM.BaseGridSettings.call(this);

    var me = this;
    this.options = kendo.observable(options);
   
    this.options.set('model',
        {
            Client: {}
        });

    this.modelClients = $('#Model-Clients');

    this.Initialize = function () {
        this.InitializeSplitter();
        this.InitializeClient();
        this.InitializeTabStrip();
        this.refClient = $('#ClientsFormRefClient').data('kendoDropDownList');
        this.refClient.bind('change', $.proxy(this.OnClientChange, this));
        $('#editClient').on('click', $.proxy(this.OnClientEditClick, this));

        if (vm.DIC_ClientsMPP) {
            vm.DIC_ClientsMPP.grid.hideColumn('refClient_BaseId');
            vm.DIC_ClientsMPP.grid.hideColumn('refClient');
        }
        if (vm.clientContacts) {
            vm.clientContacts.grid.hideColumn('refClient_BaseId');
            vm.clientContacts.grid.hideColumn('refClient');
        }
        if (vm.DIC_Signatories) {
            vm.DIC_Signatories.grid.hideColumn('refClient_BaseId');
            vm.DIC_Signatories.grid.hideColumn('refClient');
        }
        if (vm.clientBankAccounts) {
            vm.clientBankAccounts.grid.hideColumn('refClient_BaseId');
            vm.clientBankAccounts.grid.hideColumn('refClient');
        }
        if (vm.SDM_SentFilesToClient) {
            vm.SDM_SentFilesToClient.grid.hideColumn('refClient_BaseId');
            vm.SDM_SentFilesToClient.grid.hideColumn('refClient');
        }
    };

    this.InitializeSplitter = function () {
        if (this.options.splitterId)
            this.splitter = $('#' + this.options.splitterId).kendoSplitter({
                panes: [
                    { collapsible: false, resizable: false, size: '65px', scrollable: false },
                    { collapsible: true, size: '55%', scrollable: false },
                    { collapsible: false, size: '45%', scrollable: false }
                ],
                orientation: "vertical"
            }).data('kendoSplitter');
    };

    this.InitializeTabStrip = function () {
        this.tabStrip = $('#' + this.options.tabStripId).kendoTabStrip({
            animation: {
                open: { effects: "fadeIn" }
            },
            activate: function (e) {
            },
            select: function (e) {
            },
            contentLoad: function (e) {
            }
        }).data('kendoTabStrip');
        if (this.tabStrip != null && this.tabStrip.tabGroup.length > 0) {
            this.tabStrip.select(0); 
        }
        $('.k-state-active')
        Nat.F.AutoResizeTabStripInSplitter(this.tabStrip);
    };

    this.InitializeClient = function () {
        this.modelClients.addClass('m-NatEditable');
        this.modelClients.data('NatEditable', this.editable);
        Nat.F.SetDataBindByName(this.modelClients, 'model.Client');
        this.modelClients.find('input[name],select[name],textarea[name],div[custom-bind-input]').each(function () {
            var row = $(this);
            var name = row.attr('name') || row.attr('custom-bind-input');
            row.attr('name', null);
            var clearId = Nat.F.GetEscapedId(name, true);
            var newId = Nat.F.GetEscapedId(me.options.gridName + '_' + name, true);
            me.modelClients.find('label[for="' + clearId + '"]').attr('for', newId);
            $('#' + clearId).attr('id', newId);
        });
       
        kendo.bind(this.modelClients, this.options);
    }

    this.OnClientChange = function (e) {
        var data = this.refClient.dataItem();
        if (data.id === "")
            data = undefined;
        this.options.model.set("Client", data);
        if (vm.DIC_ClientsMPP) {
            vm[this.options.mppLoadGridName].setClient(data);
        }
        if (vm.clientContacts) {
            vm[this.options.clientContactLoadGridName].setClientContact(data);
        }
        if (vm.DIC_Signatories) {
            vm[this.options.signatoriesLoadGridName].setClientSignatories(data);
        }
        if (vm.clientBankAccounts) {
            vm[this.options.bankAccountsLoadGridName].setClientBankAccounts(data);
        }
        if (vm.SDM_SentFilesToClient) {
            vm[this.options.LogGridName].setlogClient(data);
        }
        if (vm.clients) {
            vm[this.options.clientsGridName].setClients(data);
        }
    };

    this.OnClientEditClick = function (e) {
        vm[this.options.clientsGridName].ClientEdit();
    }
};