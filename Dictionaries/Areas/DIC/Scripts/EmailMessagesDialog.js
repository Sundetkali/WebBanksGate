Nat.DIC.EmailMessagesDialog = function (vm, options) {

    var me = this;

    this.InitEmailMessagesDialog = function (options) {
        if (!options) return;

        this.EmailMessagesOptions = options;
        var script = $('#' + options.templateId);
        if (!script.length)
            return;

        if (!this._tmpl) this._tmpl = {};
        this._tmpl.EmailMessages = {};
        this._tmpl.EmailMessages.Window = kendo.template(script.html(), {});

    };

    var setTemplate = function (fieldId, templateFn, locale, items) {
        // подговтока данных
        var data = me.EmailMessagesOptions.data;
        data.UserName = (data['User' + locale] || {}).Name || me.EmailMessagesOptions.CurrentUserName;
        data.UserPosition = (data['User' + locale] || {}).Position || me.EmailMessagesOptions.CurrentUserPosition;
        data.Signers = items;
        data.SignersEng = items;
        data.SignersKaz = items;
        data.UserSignSrc = me.EmailMessagesOptions.SignImgSrc;
        data.UserStampSrc = me.EmailMessagesOptions.StampImgSrc;

        var value = $('<div></div>').html(templateFn(data));

        // корректировка результатов формирования - объединение таблиц в одну
        var tables = {};
        value.find('table[id]').each(function () {
            var t = $(this);
            var id = t.attr('id'),
                index = id.indexOf('-');
            if (index === -1)
                tables[id] = t.find('>tbody');
            else {
                var parentTable = tables[id.substr(0, index)];
                if (parentTable) {
                    parentTable.append(t.find('> tbody > tr'));
                    t.remove();
                }
            }
        });

        // корректировка результатов формирования - удаление подготовленых закрывающих параграфы тегов
        value.find('span[role="placeholder"]').each(function () {
            $(this).closest('p').remove();
        });

        // присвоение в форму ввода
        if (fieldId === 'template')
            $('#' + fieldId).data('kendoEditor').value($(value).html());
        if (fieldId === "MultiSelect")
            me.EmailMessagesOptions.data.templateMultiSelect = value[0].innerHTML;
        if (me.EmailMessagesOptions.validator)
            me.EmailMessagesOptions.validator.hideMessages();
        return me.EmailMessagesOptions.data.templateMultiSelect;
    };

    var getTemplate = function (e, field, items) {
        if (e.Template.OneTemplate)
            field = 'TemplateRu';

        var template;
        var templateEng;
        var templateKaz;
        var allTemplates = [];
        
        for (var i = 0; i < field.length; i++) {
            var item = field[i];
            if (item == "TemplateRu") {
                template = e.Template[item];
            }
            if (item == "TemplateEn") {
                templateEng = e.Template[item];
            }
            if (item == "TemplateKz") {
                templateKaz = e.Template[item];
            }
        }

        var gridName = me.options.signatoriesLoadGridName;

        var sectionName = '';
        if (gridName === "DIC_ClientsMPP") {
            sectionName = 'ClientsMPP';
        }
        if (gridName === "DIC_Signatories") {
            sectionName = 'Signatories';
        }

        
        var subj = [];
        if (template != undefined || template != null) {
            template = template.replace(/{Все\((Signers)\)}/gi, '<span role="placeholder"></span></p># for (var i$1 = 0; i$1 < data.$1.length; i$1++) { #<p><span role="placeholder"></span>');
            template = template.replace(/{\/Все\((Signers)\)}/gi, '<span role="placeholder"></span></p># } /* i$1 */ #<p><span role="placeholder"></span>');
            if (gridName === "DIC_ClientsMPP" || gridName === "DIC_Signatories") {
                var text = me.initSubj(me.EmailMessagesOptions.mail.Template.NameRu, items)
                template = template.replace('[ApprovalDate(' + sectionName + ')]', (gridName === "DIC_ClientsMPP") ? '#: kendo.format("{0:dd.MM.yyyy}", new Date()) #' : '#: kendo.format("{0:dd.MM.yyyy HH:mm}", new Date()) #');
                subj.push(text);
            } else {
                subj.push(me.EmailMessagesOptions.mail.Template.Name);
            }
        }

        if (templateEng != undefined || templateEng != null) {
            templateEng = templateEng.replace(/{Все\((SignersEng)\)}/gi, '<span role="placeholder"></span></p># for (var i$1 = 0; i$1 < data.$1.length; i$1++) { #<p><span role="placeholder"></span>');
            templateEng = templateEng.replace(/{\/Все\((SignersEng)\)}/gi, '<span role="placeholder"></span></p># } /* i$1 */ #<p><span role="placeholder"></span>');
            if (gridName === "DIC_ClientsMPP" || gridName === "DIC_Signatories") {
                var text = me.initSubj(me.EmailMessagesOptions.mail.Template.NameEn, items)
                templateEng = templateEng.replace('[ApprovalDate(' + sectionName + ')]', (gridName === "DIC_ClientsMPP") ? '#: kendo.format("{0:dd.MM.yyyy}", new Date()) #' : '#: kendo.format("{0:dd.MM.yyyy HH:mm}", new Date()) #');
                subj.push(text);
            } else {
                subj.push(me.EmailMessagesOptions.mail.Template.NameEn);
            }
        }

        if (templateKaz != undefined || templateKaz != null) {
            templateKaz = templateKaz.replace(/{Все\((SignersKaz)\)}/gi, '<span role="placeholder"></span></p># for (var i$1 = 0; i$1 < data.$1.length; i$1++) { #<p><span role="placeholder"></span>');
            templateKaz = templateKaz.replace(/{\/Все\((SignersKaz)\)}/gi, '<span role="placeholder"></span></p># } /* i$1 */ #<p><span role="placeholder"></span>');
            if (gridName === "DIC_ClientsMPP" || gridName === "DIC_Signatories") {
                var text = me.initSubj(me.EmailMessagesOptions.mail.Template.NameKz, items)
                templateKaz = templateKaz.replace('[ApprovalDate(' + sectionName + ')]', (gridName === "DIC_ClientsMPP") ? '#: kendo.format("{0:dd.MM.yyyy}", new Date()) #' : '#: kendo.format("{0:dd.MM.yyyy HH:mm}", new Date()) #');
                subj.push(text);
            } else {
                subj.push(me.EmailMessagesOptions.mail.Template.NameKz);
            }
        }
        if (gridName === "DIC_ClientsMPP" || gridName === "DIC_Signatories") {
            // В МРР по клиентам и Подписантах в теме письма изменил приоритет (англ, рус, каз)
            subj.unshift(...subj.splice(1, 1)); 
            // Если в трех версиях темы одинаковы, то оставляем только одну тему
            subj = Array.from(new Set(subj));
        }
        $('#MessageSubject').val(Array.prototype.join.call(subj, " / ")); 

        var dateFields = [
            { placeHolder: 'Company', field: 'refClient_BaseId', defValue: '' },
            { placeHolder: 'Customer Name', field: 'refClient_Name', defValue: '' },
            { placeHolder: 'Person', field: 'FullName', defValue: '' },
            { placeHolder: 'Document', field: 'DocumentType_Name', defValue: '' },
            { placeHolder: 'Date from', field: 'AuthorityStartDate', defValue: '', isDate: true },
            { placeHolder: 'Date to', field: 'AuthorityEndDate', defValue: '', isDate: true }
        ];
        for (let i = 0; i < dateFields.length; i++) {
            let fieldInfo = dateFields[i];
            //Russian
            if (template != undefined || template != null) {
                let exp = new RegExp('\\[' + fieldInfo.placeHolder + '\\((Signers)\\)\\]');
                if (fieldInfo.isDate)
                    template = template.replace(exp, '#: kendo.format("{0:dd-MM-yyyy}", kendo.parseDate(data.$1[i$1].' + fieldInfo.field + ')) || "' + fieldInfo.defValue + '" #');
                else
                    template = template.replace(exp, '#: data.$1[i$1].' + fieldInfo.field + ' || "' + fieldInfo.defValue + '" #');
                exp = new RegExp('\\[' + fieldInfo.placeHolder + '\\((Signers),0\\)\\]');
                if (fieldInfo.isDate)
                    template = template.replace(exp, '#: kendo.format("{0:dd-MM-yyyy}", kendo.parseDate(data.$1[0].' + fieldInfo.field + ')) || "' + fieldInfo.defValue + '" #');
                else    
                    template = template.replace(exp, '#: data.$1[0].' + fieldInfo.field + ' || "' + fieldInfo.defValue + '" #');
            }
            
            //English
            if (templateEng != undefined || templateEng != null) {
                let expEng = new RegExp('\\[' + fieldInfo.placeHolder + '\\((SignersEng)\\)\\]');
                if (fieldInfo.isDate)
                    templateEng = templateEng.replace(expEng, '#: kendo.format("{0:dd-MM-yyyy}", kendo.parseDate(data.$1[i$1].' + fieldInfo.field + ')) || "' + fieldInfo.defValue + '" #');
                else
                    templateEng = templateEng.replace(expEng, '#: data.$1[i$1].' + fieldInfo.field + ' || "' + fieldInfo.defValue + '" #');
                expEng = new RegExp('\\[' + fieldInfo.placeHolder + '\\((SignersEng),0\\)\\]');
                if (fieldInfo.isDate)
                    templateEng = templateEng.replace(expEng, '#: kendo.format("{0:dd-MM-yyyy}", kendo.parseDate(data.$1[0].' + fieldInfo.field + ')) || "' + fieldInfo.defValue + '" #');
                else
                    templateEng = templateEng.replace(expEng, '#: data.$1[0].' + fieldInfo.field + ' || "' + fieldInfo.defValue + '" #');
            }

            //Kazakh
            if (templateKaz != undefined || templateKaz != null) {
                let expKaz = new RegExp('\\[' + fieldInfo.placeHolder + '\\((SignersKaz)\\)\\]');
                if (fieldInfo.isDate)
                    templateKaz = templateKaz.replace(expKaz, '#: kendo.format("{0:dd-MM-yyyy}", kendo.parseDate(data.$1[i$1].' + fieldInfo.field + ')) || "' + fieldInfo.defValue + '" #');
                else
                    templateKaz = templateKaz.replace(expKaz, '#: data.$1[i$1].' + fieldInfo.field + ' || "' + fieldInfo.defValue + '" #');

                expKaz = new RegExp('\\[' + fieldInfo.placeHolder + '\\((SignersKaz),0\\)\\]');
                if (fieldInfo.isDate)
                    templateKaz = templateKaz.replace(expKaz, '#: kendo.format("{0:dd-MM-yyyy}", kendo.parseDate(data.$1[0].' + fieldInfo.field + ')) || "' + fieldInfo.defValue + '" #');
                else
                    templateKaz = templateKaz.replace(expKaz, '#: data.$1[0].' + fieldInfo.field + ' || "' + fieldInfo.defValue + '" #');
            }
        }

        if (gridName === "DIC_ClientsMPP" || gridName === "DIC_Signatories") {
            // В МРР по клиентам и Подписантах в тексте письма изменил приоритет (англ, рус, каз)
            field.sort((x, y) => x == 'TemplateEn' ? -1 : y);
        }
        //Сохраняем тот же порядок языков который пришел из бэка
        for (var i = 0; i < field.length; i++) {
            var item = field[i];
                if (item == "TemplateRu") {
                    if (template != undefined || template != null)
                        allTemplates.push(template);
                }
                if (item == "TemplateEn") {
                    if (templateEng != undefined || templateEng != null)
                        allTemplates.push(templateEng);
                }
                if (item == "TemplateKz") {
                    if (templateKaz != undefined || templateKaz != null)
                        allTemplates.push(templateKaz);
                }
        }

        const delimiter = (gridName === "DIC_ClientsMPP") ? "" : "<hr/> ";

        var joinTemplates = Array.prototype.join.call(allTemplates, delimiter)

        return kendo.template(joinTemplates);
    };

    var dialogProgress = function (value) {
        if (!me.EmailMessagesOptions.dialog)
            return;

        kendo.ui.progress(me.EmailMessagesOptions.dialog.element, value);
        var buttons = me.EmailMessagesOptions.dialog.wrapper.find('.k-dialog-buttongroup');
        if (value)
            buttons.addClass('k-state-disabled');
        else
            buttons.removeClass('k-state-disabled');
    };

    var sendEmail = function (e) {
        if (me.EmailMessagesOptions.validator)
            if (!me.EmailMessagesOptions.validator.validate())
                return false;

        var data = {
            MessageBody: []
        };

        data.MessageBody.push({
            refClient: me.EmailMessagesOptions.data.refClient,
            Email: $('#Email').val(),
            template: $('#template').val(),
            MessageSubject: $('#MessageSubject').val()
        });

        me.post('SendEmail',
            data,
            function (result) {
                dialogProgress(false);

                if (result.jobId)
                    me.traceJobStatus(result.jobId, '', null, false);

                if (result.success && me.EmailMessagesOptions.dialog) {
                    me.EmailMessagesOptions.dialog.close();
                }
            });
        dialogProgress(true);

        return false;
    };

    // Создание кнопок для диалогового окна (для языковых шаблонов, кнопки отправки и отмены)
    var getActions = function () {
        var actions = [];

        actions.push({
            text: me.EmailMessagesOptions.SendEmailButton,
            primary: true,
            action: sendEmail
        });
        actions.push(
            {
                text: me.EmailMessagesOptions.CancelButton
            });

        return actions;
    };

    var initForm = function (items, templateLng) {
        setTemplate('template', getTemplate(me.EmailMessagesOptions.mail, templateLng, items), 'Ru', items);
        dialogProgress(false);
    };

    this.onSendEmailClick = function (eButton) {
        var me = this;
        if (eButton.mainButton)
            return;

        this.EmailMessagesOptions.mail = eButton;

        var items = this.checkSigners();
        if (!items.length) {
            kendo.alert(me.options.messages.SelectSigners);
            return;
        }

        var template = [];
        var hash = {};
        for (var i = 0; i < items.length; i++) {
            var item = items[i];
            if (!(item.refClient in hash))
                hash[item.refClient] = {}
            hash[item.refClient].refClient = item.refClient;
            if (!('arr' in hash[item.refClient])) {
                hash[item.refClient].arr = [];
            }
            hash[item.refClient].arr.push({
                id: item.id,
                FullName: item.FullName,
                refClient: item.refClient,
                refClient_BaseId: item.refClient_BaseId,
                refClient_Name: item.refClient_Name,
                DocumentType_Name: item.DocumentType_Name,
                AuthorityStartDate: kendo.format('{0:dd.MM.yyyy}', item.AuthorityStartDate),
                AuthorityEndDate: kendo.format('{0:dd.MM.yyyy}', this.uploadListId === 2 ? kendo.date.addDays(item.AuthorityEndDate, 1) : item.AuthorityEndDate),
                NumberStars: item.NumberStars,
                NewValues: item.NewValues,
                OnDeleting: item.OnDeleting
            });
        }

        var groupRefClient = [];
        for (key in hash) {
            if (hash.hasOwnProperty(key)) {
                groupRefClient.push(hash[key]);
            }
        }

        if (me.options.signatoriesLoadGridName === "DIC_ClientsMPP" || me.options.signatoriesLoadGridName === "DIC_Signatories") {
            if (this.templateCitistore  == undefined && this.templateCitistore  == null) {
                return;
            }
            var data = this.initTemplate(this.templateCitistore, groupRefClient[0].arr);
        } else {
            var data = this.templateCitistore.dataItem();
        }
        if (data == undefined) return;

        if (data.id === "") {
            kendo.alert(this.options.messages.RequiredSelectTemplate);
            return;
        }

        me.EmailMessagesOptions.mail.Template = data;

        this.EmailMessagesOptions.data = {
            refClient: groupRefClient.map(i => i.refClient),
            UserName: this.EmailMessagesOptions.CurrentUserName,
            UserPosition: this.EmailMessagesOptions.CurrentUserPosition,
            templateMultiSelect: template
        };

        if (items.length === 1 || groupRefClient.length === 1) {
            let getDataParams = {
                ids: groupRefClient[0].arr[0].id
            }

            this.asyncPost('GetDataForEmail',
                { refClient: this.EmailMessagesOptions.data.refClient },
                function (result) {
                    if (!result.success) {
                        if (me.EmailMessagesOptions.dialog)
                            me.EmailMessagesOptions.dialog.close();
                        return;
                    }
                    var templateLng = [];
                    if (result.Lng[0] == 0 || result.Lng[0] == null) { templateLng.push("TemplateRu") }
                    if (result.Lng[0] == 1) { templateLng.push("TemplateKz") }
                    if (result.Lng[0] == 2) { templateLng.push("TemplateEn") }
                    if (result.Lng[0] == 3) { templateLng.push("TemplateRu", "TemplateKz" ) }
                    if (result.Lng[0] == 4) { templateLng.push("TemplateRu", "TemplateEn" ) }
                    if (result.Lng[0] == 5) { templateLng.push("TemplateEn", "TemplateKz" ) }
                    if (result.Lng[0] == 6) { templateLng.push("TemplateRu", "TemplateEn", "TemplateKz") }
                    if (result.Lng[0] == 7) { templateLng.push("TemplateKz", "TemplateRu", "TemplateEn") }
                    initForm(groupRefClient[0].arr, templateLng);
                },
                false);

            this.asyncPost('GetEmail',
                { refClient: this.EmailMessagesOptions.data.refClient },
                function (emailResult) {
                    if (!emailResult.list)
                        return;
                    $('#Email').val(emailResult.list);
                    if (me.EmailMessagesOptions.validator)
                        me.EmailMessagesOptions.validator.hideMessages();
                },
                false);

            var dialog = $('<div />').kendoDialog({
                title: this.EmailMessagesOptions.SendEmailButton,
                modal: true,
                content: this._tmpl.EmailMessages.Window({}),
                actions: getActions(),
                close: function () {
                    dialog.destroy();
                }
            }).data('kendoDialog');

            var tabstrip = $("#tabstrip").kendoTabStrip().data("kendoTabStrip");
            var items = tabstrip.items();
            tabstrip.select()[0];

            this.EmailMessagesOptions.dialog = dialog;

            // инициализация формы
            this.EmailMessagesOptions.validator = dialog.element.kendoValidator({
                errorTemplate: kendo.ui.Editable.prototype.options.errorTemplate
            }).data('kendoValidator');
            Nat.F.AddRequiredMark(me.EmailMessagesOptions.dialog.element);

            // исправление проблемы с состоянием HtmlEditor после инициализации TabStrip
            dialog.element.find("[data-role='editor']").each(function () {
                $(this).getKendoEditor().refresh();
            });

            dialog.open();
            dialog.center();
            dialogProgress(true);
        } else {
            $("<div></div>").kendoDialog({
                closable: true, // hide X
                title: this.options.messages.ConfirmationText,
                content: kendo.format(this.options.messages.SendSelectedSigners, items.length, groupRefClient.length),
                actions: [{
                    text: "OK",
                    action: function (e) {
                        var dataSend = {
                            MessageBody: []
                        };
                        var promiseData = [];
                        for (var j = 0; j < groupRefClient.length; j++) {
                            var item = groupRefClient[j];
                            promiseData.push(me.asyncPost('GetDataForEmail',
                                { refClient: item.refClient, signerData: item.arr },
                                function (result) {
                                    var templateLng = [];
                                    if (!result.success)
                                        return;

                                    if (result.Lng[0] == 0 || result.Lng[0] == null) { templateLng.push("TemplateRu") }
                                    if (result.Lng[0] == 1) { templateLng.push("TemplateKz") }
                                    if (result.Lng[0] == 2) { templateLng.push("TemplateEn") }
                                    if (result.Lng[0] == 3) { templateLng.push("TemplateRu", "TemplateKz") }
                                    if (result.Lng[0] == 4) { templateLng.push("TemplateRu", "TemplateEn") }
                                    if (result.Lng[0] == 5) { templateLng.push("TemplateEn", "TemplateKz") }
                                    if (result.Lng[0] == 6) { templateLng.push("TemplateRu", "TemplateEn", "TemplateKz") }
                                    if (result.Lng[0] == 7) { templateLng.push("TemplateKz", "TemplateRu", "TemplateEn") }

                                    dataSend.MessageBody.push({
                                        refClient: result.refClient,
                                        template: setTemplate('MultiSelect', getTemplate(me.EmailMessagesOptions.mail, templateLng), 'Ru', result.signerData),
                                        MessageSubject: me.EmailMessagesOptions.mail.Template.Name
                                    });
                                },
                                false));
                        }

                        Promise.all(promiseData).then(() => {
                            // all requests finished successfully
                            me.post('SendEmail',
                                dataSend,
                                function (result) {
                                    dialogProgress(false);

                                    if (result.jobId)
                                        me.traceJobStatus(result.jobId, '', null, false);

                                    if (result.success) {
                                        $("<div></div>").kendoAlert({
                                            title: me.options.messages.AlertText,
                                            content: $("<div></div>").kendoGrid({
                                                dataSource: {
                                                    data: result.names,
                                                    schema: {
                                                        model: {
                                                            fields: {
                                                                Name: { type: "string" },
                                                                BaseId: { type: "string" },
                                                                Status: { type: "string" }
                                                            }
                                                        }
                                                    }
                                                },
                                                height: 550,
                                                width: 650,
                                                scrollable: true,
                                                sortable: true,
                                                filterable: true,
                                                pageable: false,
                                                columns: [
                                                    { field: "rowNumber", title: "№", template: "<span class='row-number'></span>", width: "50px" },
                                                    { field: "BaseId", title: me.options.messages.BaseText, width: "200px" },
                                                    { field: "Name", title: me.options.messages.ClientText, width: "200px" },
                                                    { field: "Status", title: me.options.messages.StatusText, width: "170px" }
                                                ],
                                                dataBound: function () {
                                                    var rows = this.items();
                                                    $(rows).each(function () {
                                                        var index = $(this).index() + 1;
                                                        var rowLabel = $(this).find(".row-number");
                                                        $(rowLabel).html(index);
                                                    });
                                                }
                                            })
                                        }).data("kendoAlert").open();
                                    }
                                });
                        }).catch(function (err) {
                            // all requests finished but one or more failed
                            throw err;
                        })

                        dialogProgress(true);

                        return true;
                    },
                    primary: true
                }, {
                    text: this.options.messages.CancelText
                }]
            }).data("kendoDialog").open().center();
        }
    };
}