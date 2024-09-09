Nat.DIC.ClientBankAccounts = function(vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_ClientBankAccounts');
    Nat.ADM.BaseGridSettings.call(this);

    this.options = kendo.observable(options);
    this.element = $('#' + (options.gridName || 'grid'));
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
        this.InitializeUploadFile();
        if (!this.options.refClient)
            this.read();
    };

    this.InitializeUploadFile = function () {
        if (this.options.readOnly || !this.options.CanUploadClientBankAccounts)
            return;

        var upload = $('<input name="bankAccountListFiles" id="bankAccountListFiles" type="file" />');
        upload.insertAfter(this.grid.element.find('.k-grid-toolbar .k-grid-unapprove'));
        this.uploadDocument = upload.kendoUpload({
            async: {
                multiple: true,
                chunkSize: 512000,
                saveUrl: '/DIC/DIC_ClientBankAccountsUpload/BankAccountList?chunkSize=512000',
                removeUrl: '/DIC/DIC_ClientBankAccountsUpload/Remove',
                autoUpload: true
            },
            dropZone: false,
            showFileList: false,
            localization: { select: this.options.messages.UploadClientBankAccounts },
            success: function (e) {
                if (e.operation === 'upload')
                    me.read();
            },
            error: function (e) {
                me.uploadDocument.clearAllFiles();
                errorHandler(e);
            }
        }).data('kendoUpload');
    };

    this.onGetData = function () {
        var model = null;
        if (vm.clientBankAccounts.options.gridName === 'clientAccountsInDialog')
            model = vm.clients ? vm.clients.getSelected() : null;
        return {
            FilterBy_refClient: model ? model.id : this.options.FilterBy_refClient
        };
    };

    this.onDataBound = function (e) {
        OnGridDefault_DataBound(e);
    };

    this.onEdit = function (e) {
        if (e.model.isNew() && vm.clients) {
            var model = vm.clientBankAccounts.getSelected();
            if (model) e.model.set('refClient', model.id);
        }
        this.ReadonlyField('refClient', true);

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
        if (e.field === '*' || e.field === 'Status') {
            this.ReadonlyField('OpenDate', model.Status === 'O');
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

    this.setClientBankAccounts = function (model) {
        if (!model) {
            this.options.FilterBy_refClient = 0;
            this.grid.dataSource.data([]);
        } else {
            this.options.FilterBy_refClient = model.id;
            this.read();
        }
    }
};