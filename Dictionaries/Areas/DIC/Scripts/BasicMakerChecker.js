Nat.DIC.BasicMakerChecker = function(vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/' + options.action);
    Nat.ADM.BaseGridSettings.call(this);

    this.options = kendo.observable(options);
    this.element = $('#' + (options.gridName || 'grid'));

    this.Initialize = function() {
        this.grid = this.element.data('kendoGrid');
        this.bindProgress();
        this.bindGetData();
        this.grid.bind('edit', $.proxy(this.onBasicMakerCheckerEdit, this));

        this.InitializeMakerCheckerLogic();
        this.resetFilterButton = this.getGridButton("reset-filter", this.onResetFilterClick);
        this.searchInput = $('#' + this.options.gridName + '_SearchInput');

        this.InitializeGridSettings();

        this.read();
    };

    this.InitializeMakerCheckerLogic = function () {
        this.bindSelectionChange(true);

        this.approveButton = this.getGridButton("approve", this.onApproveClick);
        this.unapproveButton = this.getGridButton("unapprove", this.onUnApproveClick);
    };

    this.onGetData = function () {
        return {
            Filter_BySearchValue: this.searchInput ? this.searchInput.val() : null
        };
    };
    
    this.onSelectionChange = function() {
        this.onSelectionChangeMakerCheckerLogic();
    };

    this.onResetFilterClick = function(e) {
        e.preventDefault();

        if (this.searchInput) 
            this.searchInput.val('');
        this.grid.dataSource.filter([]);
    }

    this.onBasicMakerCheckerEdit = function(e) {
        if (e.model && e.model.isNew()) {
            e.model.set('DateCreated', new Date());
            e.model.set('DateModified', new Date());
            e.model.set('refMaker_Fio', window.currentUserName || '');
        }
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