Nat.DIC.ClientsAccountsInContracts = function(vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_ClientBankAccounts'); 
    Nat.ADM.BaseGridSettings.call(this);

    this.options = kendo.observable(options);
    this.element = $('#'+ (options.gridName || 'grid'));

    this.Initialize = function() {
        this.grid = this.element.data('kendoGrid');
        this.bindProgress();
        this.bindGetData();

        this.InitializeGridSettings();

        if (vm.clients) this.read();
    };
    
    this.onGetData = function() {
        var model = null;
        if (vm.clientsInContracts)
            model = vm.clientsInContracts.options.model;
        else if (vm.clients)
            model = vm.clients.getSelected();

        return {
            FilterBy_refClient: model ? model.id : null
        };
    };
};