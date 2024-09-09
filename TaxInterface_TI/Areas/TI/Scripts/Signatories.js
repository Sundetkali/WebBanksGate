Nat.DIC.Signatories = function (vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_Signatories');
    Nat.ADM.BaseGridSettings.call(this);
    Nat.DIC.EmailMessagesDialog.call(this);

    this.options = kendo.observable(options);
    this.element = $('#' + (options.gridName || 'grid'));

    this.InitializeSend = function () {
        if (this.options.email) {
            this.InitEmailMessagesDialog(this.options.email);
        }
    };

    var me = this;

    this.initSubj = function (subj, items) {
        var text = subj || '';
        var name = '';
        var numberStars = '';
        if (items.length > 0 && items[0].refClient_Name) {
            name = items[0].refClient_Name;
        }
        if (items.length > 0 && items[0].NumberStars) {
            numberStars = '| ' + items[0].NumberStars;
        }

        return text + ' ' + name + ' ' + numberStars;
    }
    this.initTemplate = function (templates, list) {
        if (!(templates.length > 0 && list.length > 0)) return;
        var gridName = me.options.signatoriesLoadGridName;
        if (gridName !== 'DIC_Signatories') return;
        newValues = [];
        list.forEach(item => {
            newValues.push(item.NewValues);
        })

        const CODE_INSERT = 'Signatories_INSERT';
        const CODE_UPDATE = 'Signatories_UPDATE';
        const CODE_DELETE = 'Signatories_DELETE';

        // Если в списке будет хоть один null
        if (newValues.includes(null)) {
            // В Подписантах вставляем шаблон Добавления
            for (var i = 0; i < templates.length; i++) {
                if (templates[i].Code == CODE_INSERT) { // INSERT
                    return templates[i];
                }
            }
        }
        else {
            var numberStarsChanges = [];
            var newValuesParseArr = [];

            newValues.forEach(el => {
                newValuesParse = JSON.parse(el);
                newValuesParseArr.push(newValuesParse);
                var firstNewValues = newValuesParse[0];
                var secondNewValues = newValuesParse[1];
                if (firstNewValues.NumberStars !== secondNewValues.NumberStars) {
                    numberStarsChanges.push(false);
                } else {
                    numberStarsChanges.push(true);
                }
            });

            // Если NumberStars разные
            if (numberStarsChanges.includes(false)) {
                // Если будет одна запись
                if (list.length < 2) {
                    // В Подписантах вставляем шаблон Редактирования
                    for (var i = 0; i < templates.length; i++) {
                        if (templates[i].Code == CODE_UPDATE) { // UPDATE
                            return templates[i];
                        }
                    }
                }
                // если две и больше записи
                else {
                    for (var i = 0; i < templates.length; i++) {
                        if (templates[i].Code == CODE_INSERT) { // INSERT
                            return templates[i];
                        }
                    }
                }
            }
            // Если numberStars равные
            else {
                var newValuesChanges = []
                // Убираем, изменяем свойства обьектов newValues
                newValuesParseArr.forEach(el => {

                    el.forEach(item => {
                        if (item.AuthorityStartDate) {
                            item.AuthorityStartDate = item.AuthorityStartDate.split('+')[0];
                        }
                        if (item.DateCreated) {
                            delete item.DateCreated;
                        }
                        if (item.DateModified) {
                            delete item.DateModified;
                        }
                    })

                    newValuesChanges.push(JSON.stringify(el[0]) === JSON.stringify(el[1]))
                })
                // Если равны два обьекта newValues
                if (newValuesChanges.includes(true)) {
                    // Если будет одна запись
                    if (list.length < 2) {
                        for (var i = 0; i < templates.length; i++) {
                            if (templates[i].Code == CODE_DELETE) { // DELETE
                                return templates[i];
                            }
                        }
                    }
                    // если две и больше записи
                    else {
                        for (var i = 0; i < templates.length; i++) {
                            if (templates[i].Code == CODE_INSERT) { // INSERT
                                return templates[i];
                            }
                        }
                    }
                }
                else {
                    // Если будет одна запись
                    if (list.length < 2) {
                        for (var i = 0; i < templates.length; i++) {
                            if (list[0].OnDeleting) {
                                if (templates[i].Code == CODE_DELETE) { // DELETE
                                    return templates[i];
                                }
                            }
                            else {
                                if (templates[i].Code == CODE_UPDATE) { // UPDATE
                                    return templates[i];
                                }
                            }
                        }
                    }
                    // если две и больше записи
                    else {
                        for (var i = 0; i < templates.length; i++) {
                            if (templates[i].Code == CODE_INSERT) { // INSERT
                                return templates[i];
                            }
                        }
                    }
                }

                return;
            }
        }
    }

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
        this.InitializeSend();
        this.templateCitistore = this.options.templateCitistore;
        if (!this.options.refClient)
            this.read();
    };

    this.InitializeUploadFile = function () {
        if (this.options.readOnly || !this.options.CanUploadSignatories)
            return;

        var upload = $('<input name="signatoriesListFiles" id="signatoriesListFiles" type="file" />');
        upload.insertAfter(this.grid.element.find('.k-grid-toolbar .k-grid-unapprove'));
        this.uploadDocument = upload.kendoUpload({
            async: {
                multiple: true,
                chunkSize: 512000,
                saveUrl: '/DIC/DIC_SignatoriesUpload/SignatoriesList?chunkSize=512000',
                removeUrl: '/DIC/DIC_SignatoriesUpload/Remove',
                autoUpload: true
            },
            dropZone: false,
            showFileList: false,
            localization: { select: this.options.messages.UploadSignatories },
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
        return {
            FilterBy_refClient: this.options.FilterBy_refClient,
            FilterByAuthorityDate: this.options.FilterByAuthorityDate || '',
            FilterBySigners: this.options.FilterBySigners,
            FilterByActiveStatus: this.options.FilterByActiveStatus
        };
    };

    this.onEdit = function (e) {
        if (!e.model.isNew()) {
            this.ReadonlyField('refClient', true);
        }
        
        if (e.model.isNew() && vm.ClientsForm) {
            var clientForm = vm.ClientsForm ? vm.ClientsForm.options.model : null;
            if (clientForm) {
                this.ReadonlyField('refClient', true);
                e.model.set('refClient', clientForm.Client.id);
                e.model.set('refClient_BaseId', clientForm.Client.BaseId);
                e.model.set('refClient_Name', clientForm.Client.Name);
            }
        }
        this.onChangeForModel({field:'*'}, e.model);
    };

    this.onDataBound = function (e) {
        OnGridDefault_DataBound(e);
    };

    this.onChange = function (e) {
        var editable = this.grid.editable || this.editable;
        if (e.action === 'itemchange' && editable) {
            var model = editable.options.model;
            if (model.DocumentType_Code === '08') {
                $('#DocumentTypeOther').attr('data-val-requiredisvisible', this.options.messages.DocumentTypeOtherTitle_requiredText);
                editable.element.find('label[for="DocumentTypeOther"]').addClass('requiredField');
            } else {
                $('#DocumentTypeOther').attr('data-val-requiredisvisible', null);
                editable.element.find('label[for="DocumentTypeOther"]').removeClass('requiredField');
            }
            
            if (model.AuthorityEndDateWork === false) {
                $('#AuthorityEndDate').attr('data-val-requiredisvisible', this.options.messages.AuthorityEndDate_requiredText);
                editable.element.find('label[for="AuthorityEndDate"]').addClass('requiredField');
            } else {
                $('#AuthorityEndDate').attr('data-val-requiredisvisible', null);
                model.set('AuthorityEndDate', "");
                editable.element.find('label[for="AuthorityEndDate"]').removeClass('requiredField');
            }
            
            if (model) this.onChangeForModel(e, model);
        }
    };


    this.onChangeForModel = function (e, model) {
        if (e.field === '*' || e.field === 'AuthorityEndDateWork') {
            this.ReadonlyField('AuthorityEndDate', model.AuthorityEndDateWork);
            if (model.isNew()) {
                model.set('AuthorityEndDate', '');
            }
        }
        if (e.field === '*' || e.field === 'DocumentType_Code') {
            this.ReadonlyField('DocumentTypeOther', model.DocumentType_Code !== '08');
            if (model.DocumentType_Code !== '08') {
                model.set('DocumentTypeOther', '');
            }
        };
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
        var selectedClents = this.getSelectedIds(null, "refClient_BaseId");
        var hasDiffRefs = selectedClents.find(item => item !== selectedClents[0])
        if (selectedClents && selectedClents.length > 0) {
            if (hasDiffRefs) {
                kendo.alert(this.options.messages.diffRefsAlert)
            } else {
                kendo.confirm(this.options.messages.approveMessage)
                    .done(function () {
                        me.post('ApproveRow',
                             { ids: selectedIds },
                            function (result) {
                                 if (result.success)
                                     me.onSendEmailClick(me);
                             }
 
                         );
                    });
            }
        }
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

    this.setClientSignatories = function (model) {
        if (!model) {
            this.options.FilterBy_refClient = 0;
            this.grid.dataSource.data([]);
        } else {
            this.options.FilterBy_refClient = model.id;
            this.read();
        }
    }

    this.setSignatureChange = function (model) {
        if (!model) {
            this.options.FilterBySigners = 0;
            this.grid.dataSource.data([]);
        } else {
            this.options.FilterBySigners = model.id;
            this.read();
        }
    }

    this.setSignatureDates = function (model, data) {
        
        var arrData = [];
        arrData.push(model, data.id);
        this.options.FilterByAuthorityDate = arrData;
    }

    this.selectedSigners = function () {
        var items = this.getSelectedDataItems();
        if (!items.length)
            return false;
        return items;
    }
    this.checkSigners = function () {
        var list = vm[this.options.signatoriesLoadGridName].selectedSigners();
        return list;
    }
    this.selectedSigners = function () {
        var items = this.getSelectedDataItems();
        if (!items.length)
            return false;
        return items;
    }
};