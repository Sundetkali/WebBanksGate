﻿Nat.DIC.SignatoriesTemplates = function (vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_SignatoriesTemplates');
    Nat.ADM.BaseGridSettings.call(this);

    this.options = kendo.observable(options);
    this.element = $('#'+ (options.gridName || 'grid'));
    var me = this;

    this.Initialize = function () {
        this.grid = this.element.data('kendoGrid');
        this.bindProgress();
        this.bindSelectionChange(true);
        this.grid.bind('edit', $.proxy(this.onEdit, this));
        this.approveButton = this.getGridButton("approve", this.onApproveClick);
        this.unapproveButton = this.getGridButton("unapprove", this.onUnApproveClick);
        this.InitializeGridSettings();
    };

    this.onEdit = function (e) {
        $(".k-edit-form-container").parent().width(1200).data("kendoWindow").center();
        $(".k-edit-form-container").width(1170).height(680);
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
};