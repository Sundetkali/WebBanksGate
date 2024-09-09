Nat.DIC.ClientsInContracts = function(vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_Clients'); 
    Nat.ADM.BaseGridSettings.call(this);

    var me = this;
    this.options = kendo.observable(options);
    this.element = $('#'+ (options.gridName || 'grid'));

    this.Initialize = function() {
        this.grid = this.element.data('kendoGrid');
        this.grid.bind('dataBound', $.proxy(this.onDataBound, this));
        this.bindProgress(null, $.proxy(this.requestEnd, this));
        this.bindGetData();
        this.bindSelectionChange();
        
        this.getGridButton('reset-filter', this.onResetFilter);

        this.grid.dataSource.bind('change', $.proxy(this.onChange, this));

        this.search = $('#' + this.options.gridName + 'SearchInput');
        this.saveButton = $('#saveClientsData').on('click', $.proxy(this.onSaveClick, this));
        this.cancelButton = $('#cancelClientsData').on('click', $.proxy(this.onCancelClick, this));
        this.options.set('model', {});
        this.InitializeForm();
        this.InitializeGridSettings();
    };

    this.InitializeForm = function() {
        this.form = $('#clientsDataForm');
        if (this.form.length) {
            this.editable = kendo.observable({ options: this.options, element: this.form });
            this.form.find('.m-NatEditable').data('NatEditable', this.editable);
            Nat.F.SetDataBindByName(this.form, 'model');
            kendo.bind(this.form, this.options);
            this.options.bind('change', $.proxy(this.onChangeFields, this));
            Nat.F.AddRequiredMark(this.form);
            this.formValidator = this.form.kendoValidator({
                errorTemplate:
                    '<div class="k-tooltip k-tooltip-error k-validator-tooltip"><span class="k-tooltip-icon k-icon k-i-warning"></span><span class="k-tooltip-content">#= message #</span><span class="k-callout k-callout-n"></span></div>'
            }).data('kendoValidator');
            this.regionDataSource = $('#InContract_refRegionCode').data('kendoDropDownList').dataSource;
        } else {
            this.form = null;
        }
    };

    this.onGetData = function() {
        return {
            Filter_SearchValue: this.search.val()
        };
    };

    this.requestEnd = function(e) {
        if (e.type === 'read' && e.response && e.response.Data.length === 1) {
            setTimeout(function() {
                    var rows = me.grid.table.find('tr[data-uid]');
                    if (rows.length === 1)
                        me.grid.select(rows[0]);
                },
                250);
        }
    };
    
    this.onDataBound = function (e) {
        this.grid.tbody.find('tr').each(function() {
            var tr = $(this);
            var dataItem = me.grid.dataItem(tr);
            tr.toggleClass('dic-client-closed', dataItem && dataItem.Status === 1);
        });
    };

    this.onSelectionChange = function(e) {
        var model = this.getSelected();
        var me = this;
        if (this.options.model !== model) {
            if (this.form) {
                this.formValidator.hideMessages();

                if (model &&
                    model.InContract_refRegionCode &&
                    !this.regionDataSource.get(model.InContract_refRegionCode)) {
                    this.regionDataSource.add({
                        id: model.InContract_refRegionCode,
                        Name: model.refRegionCode_Name
                    });
                }

                if (this.options.model && this.options.model.dirty) {
                    setTimeout(function() {
                            me.grid.dataSource.cancelChanges();
                        },
                        100);
                }
            }

            this.options.set('model', model);

            if (vm.clientsAccountsInContracts)
                vm.clientsAccountsInContracts.readDelay({}, 100);
            if (vm.contracts)
                vm.contracts.readDelay({}, 100);
        }

        $('#' + this.options.clientsInfoId).toggle(!!this.options.model);
        if (vm.contracts) vm.contracts.grid.resize();
        
        if (vm.contractAdminMessages) {
            vm.contractAdminMessages.setFilter({
                FilterByClientId: this.options.model ? this.options.model.id : null
            });
            vm.contractAdminMessages.grid.resize();
        }

        if (vm.contractsForDocuments) {
            vm.contractsForDocuments.setFilter({
                FilterByClientId: this.options.model ? this.options.model.id : null
            });
            vm.contractsForDocuments.grid.resize();
        }
        
        if (this.options.nextSelection && vm[this.options.nextSelection]) {
            vm[this.options.nextSelection].setClient(model);
        }
    };

    this.onChangeFields = function(e) {

    };
    
    this.onChange = function(e) {
        if (e.action === 'sync') {
            if (this.grid.editable && this.grid.editable.options.model.TraceJobId)
                this.traceJobStatus(this.grid.editable.options.model.TraceJobId, '', null, false);
        }
    };

    this.onSaveClick = function() {
        if (this.formValidator.validate())
            this.grid.dataSource.sync();
        return false;
    };

    this.onCancelClick = function() {
        this.grid.dataSource.cancelChanges();
        this.formValidator.hideMessages();
        return false;
    };
    
    this.onResetFilter = function (e) {
        e.preventDefault();
        this.search.val('');
        this.grid.dataSource.filter([]);
    };
};