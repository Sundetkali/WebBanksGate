Nat.Classes.BasicMakerChecker = function (vm, options) {
    Nat.Classes.SimpleGridController.call(this, options.controller);
    if (Nat.ADM && Nat.ADM.BaseGridSettings)
        Nat.ADM.BaseGridSettings.call(this);

    this.options = kendo.observable(options);
    this.element = $('#' + (options.gridName || 'grid'));

    this.Initialize = function() {
        this.grid = this.element.data('kendoGrid');
        this.bindProgress();
        this.InitializeMakerCheckerLogic();
        if (this.InitializeGridSettings) 
            this.InitializeGridSettings();

        if (this.options.autoBind)
            this.read();
    };

    this.InitializeMakerCheckerLogic = function () {
        this.grid.bind('edit', $.proxy(this.onBasicMakerCheckerEdit, this));
        this.bindSelectionChange(true, this.onSelectionChangeMakerCheckerLogic);
        this.approveButton = this.getGridButton("approve", this.onApproveMakerCheckerLogicClick);
        this.unapproveButton = this.getGridButton("cancel-approve", this.onCancelApproveMakerCheckerLogicClick);
    };
    
    this.onBasicMakerCheckerEdit = function(e) {
        if (e.model && e.model.isNew()) {
            e.model.set('DateCreated', new Date());
            e.model.set('DateModified', new Date());
            e.model.set('refMaker_Fio', window.currentUserName || '');
            e.model.set('refMaker', window.currentUserID || '');
        }
        this.ReadonlyField([
                'DateCreated', 'DateModified', 'refMaker', 'refChecker', 'CheckSign', 'OnAdding', 'OnDeleting'
            ],
            true);
    };

    this.onSelectionChangeMakerCheckerLogic = function () {
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

    this.onApproveMakerCheckerLogicClick = function (e) {
        var me = this;
        var selectedIds = this.getSelectedIds();
        if (selectedIds && selectedIds.length > 0)
            kendo.confirm(window.CoreLocalization.ConfirmApproveButton)
                .done(function () {
                    me.post('ApproveRow', { ids: selectedIds });
                });
        return false;
    };

    this.onCancelApproveMakerCheckerLogicClick = function (e) {
        var me = this;
        var selectedIds = this.getSelectedIds();
        if (selectedIds && selectedIds.length > 0)
            kendo.confirm(window.CoreLocalization.ConfirmCancelApproveButton)
                .done(function () {
                    me.post('CancelApproveRow', { ids: selectedIds });
                });
        return false;
    };
};