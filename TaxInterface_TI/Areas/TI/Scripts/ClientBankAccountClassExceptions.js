Nat.DIC.ClientBankAccountClassExceptions = function (vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_ClientBankAccountClassExceptions'); 
    
    this.options = kendo.observable(options);
    this.element = $('#' + (options.gridName || 'grid'));
    var me = this;

    this.Initialize = function () {
        this.grid = this.element.data('kendoGrid');
        this.grid.bind('dataBound', $.proxy(this.onDataBound, this));
        this.bindProgress();
        this.bindGetData();
        this.bindSelectionChange(true);

        this.approveButton = this.getGridButton("approve", this.onApproveClick);
        this.unapproveButton = this.getGridButton("unapprove", this.onUnApproveClick);
    }

    this.onSelectionChange = function () {

        var selected = this.getSelected();
       
        this.approveButton.toggle(selected && selected.CanApprove ? true : false);
        this.unapproveButton.toggle(selected && selected.CancelApprove ? true : false);
    };

    this.onGetData = function (e) {
        
    };



    this.onApproveClick = function (e) {
        var me = this;
        var selectedId = this.getSelected().id;
        if (selectedId)
            kendo.confirm(this.options.messages.approveMessage)
                .done(function () {
                    me.post('ApproveRow', { id: selectedId });
                });
        return false;
    };

    this.onUnApproveClick = function (e) {
        var me = this;
        var selectedId = this.getSelected().id;
        if (selectedId)
            kendo.confirm(this.options.messages.UnapproveMessage)
                .done(function () {
                    me.post('UnApproveRow', { id: selectedId });
                });
        return false;
    };

}