Nat.DIC.UNNB = function(vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_NB_UNs'); 
    Nat.ADM.BaseGridSettings.call(this);

    this.options = kendo.observable(options);
    this.element = $('#'+ (options.gridName || 'grid'));
    var me = this;

    this.Initialize = function() {
        this.grid = this.element.data('kendoGrid');
        this.bindProgress();
        
        this.InitializeUploadFile();
        this.InitializeGridSettings();
    };
    
    this.InitializeUploadFile = function() {
        if (this.options.readOnly)
            return;

        if (!this.uploadDocument && this.options.CanUpload) {
            var upload = $('<input name="unnbFiles" id="unnbFiles" type="file" />');
            upload.insertBefore(this.grid.element.find('.k-grid-toolbar .k-grid-hold'));
            this.uploadDocument = upload.kendoUpload({
                async: {
                    multiple: true,
                    chunkSize: 512000,
                    saveUrl: '/DIC/DIC_NB_UNsUpload/File?chunkSize=512000',
                    removeUrl: '/DIC/DIC_NB_UNsUpload/Remove',
                    autoUpload: true
                },
                dropZone: false,
                showFileList: false,
                localization: { select: this.options.messages.UploadUNNB },
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
};