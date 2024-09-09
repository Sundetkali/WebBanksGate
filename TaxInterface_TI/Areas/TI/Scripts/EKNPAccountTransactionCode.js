Nat.DIC.EKNPAccountTransactionCode = function (vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_EKNPAccountTransactionCode');
    Nat.ADM.BaseGridSettings.call(this);

    this.options = kendo.observable(options);
    this.element = $('#'+ (options.gridName || 'grid'));

    this.Initialize = function () {
        this.grid = this.element.data('kendoGrid');
        this.grid.bind('dataBound', $.proxy(this.onDataBound, this));
        this.bindProgress();
        this.bindGetData();
        this.bindSelectionChange(true);

        this.grid.bind('edit', $.proxy(this.onEdit, this));
        this.grid.dataSource.bind('change', $.proxy(this.onChange, this));

        this.approveButton = this.getGridButton("approve", this.onApproveClick);
        this.unapproveButton = this.getGridButton("unapprove", this.onUnApproveClick);
        this.InitializeGridSettings();

        this.read();
    };

    this.onGetData = function () {
        var model = null;
        if (vm.EKNPAccountTransactionCode)
            model = vm.EKNPAccountTransactionCode.options.model;
        return {
            FilterBy_refClient: model ? model.id : undefined
        };
    };

    this.onDataBound = function (e) {
        OnGridDefault_DataBound(e);
    };

    this.onEdit = function(e) {
        if (e.model.isNew() && vm.clients) {
            var model = vm.EKNPAccountTransactionCode.getSelected();
            if (model) e.model.set('refClient', model.id);
        }
    };

    this.onApproveClick = function (e) {
        var me = this;
        var selectedIds = this.getSelectedIds();
        if (selectedIds && selectedIds.length > 0)
            kendo.confirm(this.options.messages.approveMessage)
                .done(function () {
                    me.post('ApproveRow', { ids: selectedIds });
                });
        return false;
    };

    this.onUnApproveClick = function (e) {
        var me = this;
        var selectedIds = this.getSelectedIds();
        if (selectedIds && selectedIds.length > 0)
            kendo.confirm(this.options.messages.UnapproveMessage)
                .done(function () {
                    me.post('UnApproveRow', { ids: selectedIds });
                });
        return false;
    };

    this.onSelectionChange = function () {
        var canApprove = false;
        var cancelApprove = false;
        var items = this.getSelectedDataItems();
        if (items.length > 0) {
            for (var i = 0; i < items.length; i++) {
                var item = items[i];
                if (item.CanApprove && canApprove === false) {
                    canApprove = true;
                }

                if (item.CancelApprove && cancelApprove === false) {
                    cancelApprove = true;
                }
            }
        }
        this.approveButton.toggle(canApprove);
        this.unapproveButton.toggle(cancelApprove);
    };
};