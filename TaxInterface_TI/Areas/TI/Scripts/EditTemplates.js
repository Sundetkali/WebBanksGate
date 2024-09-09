Nat.DIC.EditTemplates = function (vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_EditTemplates');
    Nat.ADM.BaseGridSettings.call(this);

    this.options = kendo.observable(options);
    this.element = $('#'+ (options.gridName || 'grid'));
    var me = this;

    this.Initialize = function () {
        this.grid = this.element.data('kendoGrid');
        this.grid.bind('dataBound', $.proxy(this.onDataBound, this));
        this.bindProgress();
        this.bindSelectionChange(true);

        this.approveButton = this.getGridButton("approve", this.onApproveClick);
        this.unapproveButton = this.getGridButton("unapprove", this.onUnApproveClick);
        this.downloadButton = this.getGridButton("downloadOriginal", this.downloadClick);
        this.viewButton = this.getGridButton("viewTemplate", this.onViewClick);
        
        this.InitializeGridSettings();
        this.InitializeUploadFile();
        this.InitializePDF();
        this.read();
    };

    this.InitializePDF = function () {
        if (!window.pdfjsLib || !kendo.pdfviewer.pdfjs.isLoaded())
            $.when(
                    $.getScript("/Scripts/kendo/pdf.js"),
                    $.getScript("/Scripts/kendo/pdf.worker.js")
                )
                .done(function () {
                    window.pdfjsLib.GlobalWorkerOptions.workerSrc = '/Scripts/kendo/pdf.worker.js';
                });
    };

    this.onSelectionChange = function () {
        var canApprove = false;
        var cancelApprove = false;
        var canUpload = false;
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
            this.options.FilterByIds = items[0].id;
            canUpload = true;
        }
        
        if (items.length === 0 || items.length > 1) {
            this.options.FilterByIds = undefined;
            canUpload = false;
        }
        this.uploadDocument.toggle(canUpload);
        this.approveButton.toggle(canApprove);
        this.unapproveButton.toggle(cancelApprove);
    };

    this.onDataBound = function (e) {
        OnGridDefault_DataBound(e);
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

    this.downloadClick = function (e) {
        var selectedIds = this.getSelectedIds();
        if (selectedIds && selectedIds.length === 1) {
            window.open('/DIC/DIC_EditTemplates/GetFileDownload?id=' + selectedIds[0], '_blank');
        }
        if (selectedIds.length > 1) {
            kendo.alert(me.options.messages.selectOneTemplate);
        }
        if (selectedIds.length === 0){
            return kendo.alert(me.options.messages.selectTemplate);
        }
        return false;
    }

    this.InitializeUploadFile = function () {
        if (this.options.readOnly)
            return;
        var saveUrl = '/DIC/DIC_EditTemplates/UploadTemplate';
        //if (!this.uploadDocument && this.options.CanUpload) {
        var upload = $('<input name="files" id="files" type="file" />');
        upload.insertAfter(this.grid.element.find('.k-grid-toolbar .k-grid-viewTemplate'));
        this.uploadDocument = upload.kendoUpload({
            async: {
                multiple: false,
                chunkSize: 512000,
                saveUrl: saveUrl,
                removeUrl: '/DIC/DIC_EditTemplates/Remove',
                autoUpload: true
            },
            validation: {
                allowedExtensions: [
                    ".pdf", ".tiff", ".tif", ".doc", ".docx"
                ]
            },
            dropZone: false,
            showFileList: false,
            upload: function (e) {
                if (me.options.FilterByIds === undefined) {
                    kendo.alert(me.options.messages.selectTemplate);
                } else {
                    e.data = { uploadUid: e.files[0].uid };
                    e.data.chunkSize = 512000;
                    e.data.ids = me.options.FilterByIds;
                }
            },
            select: function (e) {
                if (e.files[0] && e.files[0].validationErrors && e.files[0].validationErrors[0]) {
                    //kendo.alert(me.uploadDocument.options.localization[e.files[0].validationErrors[0]]);
                    setTimeout(function () { me.uploadDocument.clearAllFiles(); }, 50);
                }
            },
            //change: this.uploadClick(),
            localization: { select: this.options.messages.selectFile },
            error: errorHandler
        }).data('kendoUpload');
        this.uploadDocument.bind('success',
            function (e) {
                if (e.operation === 'upload')
                    me.read();
            });
        
        if (!this.options.FilterByIds) {
            this.uploadDocument.toggle(false);
        }
        this.grid.element.addClass('edit-grid-with-upload');
        this.grid.resize();
        //} else if (this.uploadDocument) {
        //    this.uploadDocument.options.saveUrl = saveUrl;
        //}
    };

    this.getPreviewDiv = function (dataItem) {
        var divContent = null;
        var url = '/DIC/DIC_EditTemplates/GetFilePreview?id=' + dataItem;
        divContent = $('<div class="dic-pdf-preview"><div/></div>');
        var pdf = divContent.find('div').kendoPDFViewer({
            toolbar: {
                items: [
                    "spacer", "toggleSelection", "pager", "spacer", "zoom", "search", "download", "print"
                ]
            },
            width: "100%",
            height: "100%"
        }).data('kendoPDFViewer');

        $.ajax({
            url: "/DIC/DIC_EditTemplates/GetFilePreview",
            data: { id: dataItem }
        }).done(function (data) {
            setTimeout(function () {
                pdf.fromFile(url);
            },
                1000);
        }).fail(function (jqXHR, textStatus) {
            kendo.alert(me.options.messages.cantFindTemplate);
        });

        if (!divContent) {
            return url;
        }

        return divContent;
    };

    this.onViewClick = function (e) {
        var selectedIds = this.getSelectedDataItems();
        if (selectedIds && selectedIds.length === 1) {
            var divContent = this.getPreviewDiv(selectedIds[0].id);
            var url = '';

            if (divContent && divContent.substr && divContent.substr(0, 1) === '/') {
                url = divContent;
                divContent = null;
            }

            if (divContent) {
                divContent.css('display', '');
                var w = $(window);
                var width = w.width() * 0.8;
                var height = w.height() * 0.9;
                
                if (this.viewDialog)
                    this.viewDialog.close();

                this.viewDialog = divContent
                    .kendoWindow({
                        width: width,
                        height: height,
                        modal: true, 
                        title: selectedIds[0].TemplateName, 
                        resizable: true,
                        draggable: true,
                        animation: { open: 'fadeIn' },
                        close: function () {
                            me.viewDialog.destroy();
                            me.viewDialog = null;
                        }
                    }).data('kendoWindow');
                this.viewDialog.open();
                this.viewDialog.center();
            } else
                window.open(url, '_blank');
        }
        if (selectedIds.length > 1) {
            kendo.alert(me.options.messages.selectOneTemplate);
        }
        if (selectedIds.length === 0) {
            return kendo.alert(me.options.messages.selectTemplate);
        }
        return false;
    };
};