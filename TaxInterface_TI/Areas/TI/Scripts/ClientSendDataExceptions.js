Nat.DIC.ClientSendDataExceptions = function (vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_ClientSendDataExceptions');
    Nat.ADM.BaseGridSettings.call(this);

    this.options = kendo.observable(options);
    this.element = $('#'+ (options.gridName || 'grid'));
    var me = this;

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
        return {
            FilterBy_refClient: this.options.FilterBy_refClient
        };
    };

    this.onDataBound = function (e) {
        OnGridDefault_DataBound(e);
    };

    this.onEdit = function (e) {
        if (!e.model.isNew()) {
            this.ReadonlyField('refClient', true);
        }
        this.refClient = $('#refClient').data('kendoDropDownList');
        this.refClient.bind('change', $.proxy(this.OnClientChange, this));

        this.onChangeForModel({ field: '*' }, e.model);
    };

    this.onChange = function (e) {
        var editable = this.grid.editable || this.editable;
        if (e.action === 'itemchange' && editable) {
            var model = editable.options.model;
            if (model) this.onChangeForModel(e, model);
        }
    };

    this.onChangeForModel = function (e, model) {
        if (e.field === '*' || e.field === 'SendDataType') {
            this.ReadonlyField('refAddressee', model.SendDataType !== 0);
            if (model.SendDataType !== 0) {
                var multiselect = $('#refAddressee').data('kendoMultiSelect');
                multiselect.dataSource.data([]);
                multiselect.dataSource.one('change', function () { setTimeout(function () { multiselect.trigger('change') }) });
                multiselect.dataSource.read();
            }
        }
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

    this.onApproveClick = function (e) {
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

    this.OnClientChange = function (e) {
        var multiselect = $('#refAddressee').data('kendoMultiSelect');
        multiselect.dataSource.one('change', function() { setTimeout(function() { multiselect.trigger('change') }) });
        multiselect.dataSource.read();
    }
};