Nat.DIC.Clients = function(vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_Clients'); 
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

        this.getGridButton('reset-filter', this.onResetFilter);
        this.search = $('#clientsSearchInput');
        this.filterByQuasiPublicSector = this.QuickToolbarSearch({ name: 'FilterByQuasiPublicSector', widget: 'kendoSwitch' });
        this.filterByGoodsPreCheck = this.QuickToolbarSearch({ name: 'FilterByGoodsPreCheck', widget: 'kendoSwitch' });

        this.grid.bind('edit', $.proxy(this.onEdit, this));
        this.grid.dataSource.bind('change', $.proxy(this.onChange, this));

        this.accountsButton = this.getGridButton('accounts');
        this.contactsButton = this.getGridButton('contacts');
        this.approveButton = this.getGridButton("approve", this.onApproveClick);
        this.unapproveButton = this.getGridButton("unapprove", this.onUnApproveClick);
        this.editManagerButton = this.getGridButton("editManager", this.onEditManagerClick);
        this.InitializeUploadFile();
        this.InitializeGridSettings();
        this.gridEditScrollTemplate();

        if (!this.options.refClient)
            this.read();

        if (!this._tmpl) this._tmpl = {};
        this._tmpl.managerWindow = kendo.template($('#ManagerUpdateWindowTemplate').html(), {});
    };
    
    this.InitializeUploadFile = function() {
        if (this.options.readOnly)
            return;

        if (!this.uploadDocumentOked && this.options.CanUploadOKED) {
            var upload = $('<input name="okedDataFiles" id="okedDataFiles" type="file" />');
            upload.insertAfter(this.grid.element.find('.k-grid-toolbar .k-grid-contacts'));
            this.uploadDocumentOked = upload.kendoUpload({
                async: {
                    multiple: true,
                    chunkSize: 512000,
                    saveUrl: '/DIC/DIC_ClientsUpload/EconomicTradeType?chunkSize=512000',
                    removeUrl: '/DIC/DIC_ClientsUpload/Remove',
                    autoUpload: true
                },
                dropZone: false,
                showFileList: false,
                localization: { select: this.options.messages.UploadOKEDExcel },
                success: function(e) {
                    if (e.operation === 'upload')
                        me.read();
                },
                error: function(e) {
                    me.uploadDocumentOked.clearAllFiles();
                    errorHandler(e);
                }
            }).data('kendoUpload');
        }
        
        if (!this.uploadDocument && this.options.CanUploadClients) {
            var upload = $('<input name="contactFiles" id="contactFiles" type="file" />');
            upload.insertAfter(this.grid.element.find('.k-grid-toolbar .k-grid-contacts'));
            this.uploadDocument = upload.kendoUpload({
                async: {
                    multiple: true,
                    chunkSize: 512000,
                    saveUrl: '/DIC/DIC_ClientsUploadFiles/Contacts?chunkSize=512000',
                    removeUrl: '/DIC/DIC_ClientsUploadFiles/Remove',
                    autoUpload: true
                },
                dropZone: false,
                showFileList: false,
                localization: { select: this.options.messages.UploadExcel },
                success: function(e) {
                    if (e.operation === 'upload')
                        me.read();
                },
                error: function(e) {
                    me.uploadDocument.clearAllFiles();
                    errorHandler(e);
                }
            }).data('kendoUpload');
        }
    };

    this.onGetData = function () {
        return {
            FilterByWithOnApprove: this.options.FilterByWithOnApprove,
            Filter_SearchValue: this.search.val(),
            FilterBy_refClient: this.options.FilterBy_refClient,
            FilterByQuasiPublicSector: this.filterByQuasiPublicSector.value(),
            FilterByGoodsPreCheck: this.filterByGoodsPreCheck.value()
        };
    };

    this.onDataBound = function (e) {
        OnGridDefault_DataBound(e);
        this.grid.tbody.find('tr').each(function() {
            var tr = $(this);
            var dataItem = me.grid.dataItem(tr);
            tr.toggleClass('dic-client-closed', dataItem && dataItem.Status === 1);
        });
    };

    this.onSelectionChange = function(e) {
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
                this.editManagerButton.toggle(true);
            }
        } else {
            this.editManagerButton.toggle(false);
        }

        if (items.length === 1) {
            var data = items[0];
            this.accountsButton.toggle(!!data);
            this.contactsButton.toggle(!!data);
        } else {
            this.accountsButton.toggle(false);
            this.contactsButton.toggle(false);
        }
        
        this.approveButton.toggle(canApprove);
        this.unapproveButton.toggle(cancelApprove);
    };

    this.onEdit = function(e) {
        if (e.model.IsLegalEntity === null)
            Nat.F.SetValue(e.model, 'IsLegalEntity', { IsLegalEntity: e.model.refEconomicSector_Code !== '9' });
        
        if (e.model.IsClient === null)
            Nat.F.SetValue(e.model, 'IsClient', { IsClient: true });

        if (e.model.Resident === null)
            Nat.F.SetValue(e.model, 'Resident', { Resident: true });

        if (e.model.isNew() && vm.clients) {
            var model = this.getSelected();
            if (model) e.model.set('refClient', model.id);
        }
    };
    
    this.onChange = function(e) {
        if (e.action === 'sync') {
            if (this.grid.editable && this.grid.editable.options.model.TraceJobId)
                this.traceJobStatus(this.grid.editable.options.model.TraceJobId, '', null, false);
        }
    };

    this.onAccountsClick = function() {
        var model = this.getSelected();
        if (!model)
            return;

        var d = $('<div/>').kendoWindow({
            modal: true,
            resizable: true,
            draggable: true,
            width: 800,
            height: $(window).height() * 0.8,
            title: this.accountsButton.text() + ' - ' + model.BaseId + ' ' + this.getName(model),
            content: '/DIC/DIC_ClientBankAccounts?emptyLayout=true&gridName=clientAccountsInDialog',
            close: function() {
                d.destroy();
            }
        }).data('kendoWindow');
        d.open();
        d.center();
    };

    this.onContactsClick = function () {
        var model = this.getSelected();
        if (!model) 
            return;

        var d = $('<div/>').kendoWindow({
            modal: true,
            resizable: true,
            draggable: true,
            width: $(window).width() * 0.8,
            height: $(window).height() * 0.9,
            title: this.contactsButton.text() + ' - ' + model.BaseId + ' ' + this.getName(model),
            content: '/DIC/DIC_ClientContacts?emptyLayout=true&gridName=clientContactsInDialoag',
            close: function() {
                d.destroy();
            }
        }).data('kendoWindow');
        d.open();
        d.center();
    };

    this.onEditManagerClick = function (e) {
        var me = this;
        var selectedIds = this.getSelectedIds();
        if (selectedIds && selectedIds.length > 0)
            var model = kendo.observable({
                ids: selectedIds,
                CustomVisible: false
            });
        
        var title = this.options.messages.EditManagers;
        var dialog = $('<div />').kendoDialog({
            title: title,
            modal: true,
            content: this._tmpl.managerWindow({}),
            actions: [
                {
                    text: this.options.messages.EditButton,
                    primary: true,
                    action: function (e) {
                        var validator = dialog.element.data('kendoValidator');
                        if (!validator.validate())
                            return false;

                        me.post('UpdateManager', model.toJSON(), me._closeTab);
                        return true;
                    }
                },
                {
                    text: this.options.messages.CancelButton
                }
            ],
            close: function () {
                dialog.destroy();
            }
        }).data('kendoDialog');
        Nat.F.SetDataBindByName(dialog.element, '');
        Nat.F.AddRequiredMark(dialog.element);
        var wEditable = kendo.observable({ options: { model: model }, element: dialog.element });
        dialog.element.find('.m-NatEditable').data('NatEditable', wEditable);
        dialog.element.kendoValidator();
        kendo.bind(dialog.element, model);
        dialog.open();
        dialog.center();

        return false;
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

    this.getName = function(model) {
        if (window.currentCulture === 'kk')
            return model.NameKz;
        if (window.currentCulture === 'en')
            return model.NameEn;
        return model.NameRu;
    };

    this.onResetFilter = function (e) {
        e.preventDefault();
        this.search.val('');
        this.grid.dataSource.filter([]);
    };

    this.setClients = function (model) {
        if (!model) {
            this.options.FilterBy_refClient = 0;
            this.grid.dataSource.data([]);
        } else {
            this.options.FilterBy_refClient = model.id;
            this.grid.dataSource.data([model]);     
        }
    }

    this.ClientEdit = function () {
        var model = this.grid.dataSource.data()[0];
        if (!model) return false;
        var tr = me.gridFindTr(model);
        me.grid.editRow(tr);
    };
};