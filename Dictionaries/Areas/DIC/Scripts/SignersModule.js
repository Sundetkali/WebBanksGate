Nat.DIC.SignersModule = function (vm, options) {
    Nat.ADM.BaseGridSettings.call(this);
    Nat.Classes.BaseToggleMethods.call(this);
    Nat.Classes.BasePostMethod.call(this, 'DIC/DIC_SignersModule');
    Nat.DIC.EmailMessagesDialog.call(this);

    this.options = kendo.observable(options);

    this.InitializeSend = function () {
        if (this.options.email) {
            if (this.options.email) {
                this.InitEmailMessagesDialog(this.options.email);
            }
        }
    };

    this.Initialize = function () {
        this.InitializeSplitter();
        this.InitializeButtonsSend = $('#optionEmailButtons').on('click', $.proxy(this.onSendEmailClick, this));
        this.InitializeSend();
        this.filterByAuthorityDateFrom = $('#FilterByAuthorityDateFrom').data('kendoDatePicker');
        this.filterByAuthorityDateTo = $('#FilterByAuthorityDateTo').data('kendoDatePicker');
        this.UnloadList = $('#UnloadList').data('kendoDropDownList');
        $('#sendRequestSignature').on('click', $.proxy(this.OnSendRequestSignatureClick, this));
        this.templateCitistore = $('#refSignatoriesTemplates').data('kendoDropDownList');
        
    };

    this.InitializeSplitter = function () {
        var id = '#' + options.splitterId;
        $(id).kendoSplitter({
            panes: [
                { collapsible: true, size: '12%', scrollable: false },
                { collapsible: true, size: '100%', scrollable: false }
            ],
            orientation: "vertical"
        });
    };

    this.OnSendRequestSignatureClick = function () {
        var data = this.UnloadList.dataItem();
        if (data.id === "") {
            kendo.alert(this.options.messages.UnloadListError);
            return;
        }
        this.uploadListId = data.id;
        var dates = kendo.format('{0:dd.MM.yyyy};{1:dd.MM.yyyy}',
            this.filterByAuthorityDateFrom.value() || '',
            this.filterByAuthorityDateTo.value() || '');
        
        vm[this.options.signatoriesLoadGridName].setSignatureDates(dates, data);
        vm[this.options.signatoriesLoadGridName].setSignatureChange(data);
    }

    this.checkSigners = function() {
        var list = vm[this.options.signatoriesLoadGridName].selectedSigners();
        return list;
    }
};