if (!window.Nat) window.Nat = {};
if (!window.Nat.F) window.Nat.F = {};

Nat.F.JoinStringArrayByTemplate = function(array, template) {
    if (!array || !array.length)
        return null;

    var res = '';
    var fn = kendo.template(template);
    for (var i = 0; i < array.length; i++) {
        res += fn(array[i]);
    }

    return res;
};

Nat.F.JoinStringArrayByTemplateId = function(array, templateId) {
    if (!array || !array.length)
        return null;

    var template = $('#' + templateId).html();
    return Nat.F.JoinStringArrayByTemplate(array, template);
};

Nat.F.JoinStringArrayToDivs = function(array, field) {
    if (!array || !array.length)
        return null;

    var res = '';
    for (var i = 0; i < array.length; i++) {
        res += '<div>' + kendo.htmlEncode(field ? array[i][field] : array[i]) + '</div>';
    }

    return res;
};

Nat.F.JoinStringArrayToDivsGroupedCount = function (array, field) {
    if (!array || !array.length)
        return null;

    var result = {};
    for (var i = 0; i < array.length; i++) {
        var a = field ? array[i][field] : array[i];
        if (result[a] != undefined)
            ++result[a];
        else
            result[a] = 1;
    }
    var resHtml = '';

    for (var key in result)
        resHtml += '<div>' + kendo.htmlEncode(key) + '('+ result[key] + ')</div>';

    return resHtml;
};

Nat.F.JoinStringArrayInTags = function(array, field, tag) {
    if (!array || !array.length)
        return null;

    var res = '';
    for (var i = 0; i < array.length; i++) {
        res += '<' + tag + '>' + kendo.htmlEncode(field ? array[i][field] : array[i]) + '</' + tag + '>';
    }

    return res;
};

Nat.F.JoinStringArray = function (array, separator, field) {
    if (!array || !array.length)
        return null;

    var res = '';
    for (var i = 0; i < array.length; i++) {
        if (i > 0)
            res += separator;
        res += kendo.htmlEncode(field ? array[i][field] : array[i]);
    }

    return res;
};

Nat.F.JoinStringArrayToDivsForExcel = function(array) {
    if (!array || !array.length)
        return null;

    var res = '';
    for (var i = 0; i < array.length; i++) {
        if (res !== '')
            res += ", \r\n";
        res += array[i];
    }

    return res;
};

Nat.F.FormatStringToHtml = function(value) {
    if (!value)
        return '';

    return kendo.htmlEncode(value).replace(/\n/g, '</br>');
}

Nat.F.GetShortFio = function(value) {
    if (!value) return '';

    var fio = value.split(' ');
    return fio[0] + ' ' + (fio[1] ? fio[1].substring(0, 1) + '. ' : '')  + (fio[2] ? fio[2].substring(0, 1) + '. ' : '');
};

Nat.F.OnGetDataDropDownList = function (e, options, obj) {
    if (window.__isFilter) {
        e.__isFilter = window.__isFilter;
    }

    var editable = Nat.F.DetectEditable(options);
    if (options.serverFiltering) {

        if (window.VM && window.VM.bindModel && window.VM.bindModel.value && window.VM.bindModel.keyField) {
            e.filter = { field: window.VM.bindModel.keyField, value: window.VM.bindModel.value, operator: 'eq' };
        }

        if (editable) {
            let editor = $(Nat.F.GetEscapedId(options.clientId)).data('kendoDropDownList');
            if (editor && !editor.dataSource.natBindChangeEvent) {
                /*editable.options.bind('change',
                    function (e) {
                        if (e.field !== "model." + options.member)
                            return;*/
                editor.dataSource.natBindChangeEvent = true;
                editor.dataSource.bind('change',
                    function() {
                        var model = editable.options.model;
                        let member = options.clientId;
                        if (editable.clientIdPrefix)
                            member = member.replace(editable.clientIdPrefix, '');
                        let valueId = model.get(member);
                        let dotIndex = member.lastIndexOf('.');
                        let prefix = dotIndex === -1 ? '' : member.substr(0, dotIndex + 1);
                        var dataItem = editor.dataSource.get(valueId);
                        if (!dataItem && valueId) {
                            dataItem = {};
                            dataItem[options.valueField] = valueId;
                            if (options.valueField !== 'id') dataItem['id'] = valueId;
                            dataItem[options.textField] = model.get(prefix + options.modelTextField);
                            if (options.otherFields && options.otherFields.length) {
                                options.otherFields.forEach(function(item) {
                                    dataItem[item.dsField] = model.get(prefix + item.modelField);
                                });
                            }

                            if (!editor.dataSource.get(dataItem[options.valueField])) {
                                editor.dataSource.insert(dataItem, 0);
                            }
                            var indexInDataSource =
                                editor.dataSource.indexOf(editor.dataSource.get(dataItem.id));
                            editor.select(indexInDataSource + (editor.options.optionLabel ? 1 : 0));
                        }
                    });
            }
        } else if (options.gridName) {
            var grid = $('#' + options.gridName).data('kendoGrid') || $('#' + options.gridName).data('kendoTreeList') || $('#' + options.gridName).data('kendoListView');
            if (grid) {
                grid.one('edit',
                    function(e) {
                        var innerEditable = grid.editable || grid.editor.editable;
                        var editor = innerEditable.element.find(Nat.F.GetEscapedId(options.clientId))
                            .data('kendoDropDownList');
                        if (editor && !editor.dataSource.natBindChangeEvent) {
                            var addRow = function() {

                                let valueId = e.model.get(options.clientId);
                                let dotIndex = options.clientId.lastIndexOf('.');
                                let prefix = dotIndex === -1 ? '' : options.clientId.substr(0, dotIndex + 1);
                                var dataItem = editor.dataSource.get(valueId);
                                if (!dataItem && valueId) {
                                    dataItem = {};
                                    dataItem[options.valueField] = valueId;
                                    if (options.valueField !== 'id') dataItem['id'] = valueId;
                                    dataItem[options.textField] = e.model.get(prefix + options.modelTextField);
                                    if (options.otherFields && options.otherFields.length) {
                                        options.otherFields.forEach(function(item) {
                                            dataItem[item.dsField] = e.model.get(prefix + item.modelField);
                                        });
                                    }

                                    if (!editor.dataSource.get(dataItem[options.valueField]))
                                        editor.dataSource.insert(dataItem, 0);
                                    var indexInDataSource =
                                        editor.dataSource.indexOf(editor.dataSource.get(dataItem.id));
                                    editor.select(indexInDataSource + (editor.options.optionLabel ? 1 : 0));
                                }
                            };
                            if (!editable) addRow(); //editor.dataSource.read();
                            editor.dataSource.natBindChangeEvent = true;
                            editor.dataSource.bind('change', addRow);
                        }
                    });
            } else {
                let editor = $(Nat.F.GetEscapedId(options.clientId)).data('kendoDropDownList');
                if (editor) {
                    editor.dataSource.one('change',
                        function() {
                            var initValue = editor.value();
                            if (initValue && !editor.dataSource.get(initValue)) {
                                if (!editable &&
                                    initValue === "0" &&
                                    (editable = Nat.F.DetectEditable(options)) &&
                                    editable.options.model.get(options.member)) {
                                    initValue = editable.options.model.get(options.member);
                                    editor.value(initValue);
                                } else
                                    debugger;
                            }
                        });
                }
            }
        }
    }

    var jsonModel = editable ? editable.options.model.toJSON() : {};

    if (editable && options.gridName) {
        var grid = $('#' + options.gridName).data('kendoGrid') ||
            $('#' + options.gridName).data('kendoTreeList') ||
            $('#' + options.gridName).data('kendoListView');
        if (grid && grid.dataSource.options.MapFields) {
            grid.dataSource.options.MapFields(jsonModel);
        }
    }
    return {
        selectionModelMember: options.member,
        selectionModelType: options.type,
        selectionModelJson: JSON.stringify(jsonModel)
    };
};

Nat.F.DetectEditable = function (options) {
    var c = $(Nat.F.GetEscapedId(options.clientId));
    var editable;
    if (c.length === 1) {
        editable = c.parent().parent().data('kendoEditable')
            || c.closest('.m-NatEditable').data('NatEditable')
            || c.closest('.k-popup-edit-form').data('kendoEditable')
            || c.closest('.k-popup-edit-form').data('NatEditable');
        if (editable) return editable;
    }

    c = $('#' + options.gridName);
    if (c.length === 0) c = $('#grid');
    if (c.length === 0) c = $('#treeList');

    if (c.length === 1) {
        var grid = c.data('kendoGrid');
        if (grid) return grid.editable;

        var treeList = c.data('kendoTreeList');
        if (treeList && treeList.editor)
            return treeList.editor.editable;

        var listView = c.data('kendoListView');
        if (listView) return listView.editable;
    }

    return null;
};

Nat.F.OnSelectDropDownList = function(e, options) {
    var textValue = !e.dataItem
        ? (window.isKz ? 'Белгіленбеген' : 'Не указано')
        : e.dataItem[options.textField];
    var editable = Nat.F.DetectEditable(options);
    if (editable) {
        var model = editable.options.model;
        var goModel = model;
        var dotIndex = options.clientId ? options.clientId.lastIndexOf('.') : -1;
        var prefix = dotIndex > -1 ? options.clientId.substring(0, dotIndex + 1) : '';
        if (dotIndex > -1 && goModel.get) {
            goModel = goModel.get(options.clientId.substring(0, dotIndex));
        }

        if (!model.set ||
            goModel.fields &&
            goModel.fields[options.modelTextField] &&
            goModel.fields[options.modelTextField].editable === false)
            goModel[options.modelTextField] = textValue;
        else if (prefix && prefix.indexOf('[') > 0) {
            model.set(options.clientId, e.dataItem ? e.dataItem[options.valueField] : null);
            model.set(prefix + options.modelTextField, textValue);
        }
        else
            model.set(prefix + options.modelTextField, textValue);

        if (options.otherFields && options.otherFields.length) {
            options.otherFields.forEach(function(item) {
                if (!model.set || //dotIndex > -1 ||
                    goModel.fields &&
                    goModel.fields[item.modelField] &&
                    goModel.fields[item.modelField].editable === false)
                    goModel[item.modelField] = e.dataItem ? e.dataItem[item.dsField] : null;
                else
                    model.set(prefix + item.modelField, e.dataItem ? e.dataItem[item.dsField] : null);
            });
        }
    }
};

Nat.F.OnOpenSelectDialogClick = function (e, options) {
    var editable = Nat.F.DetectEditable(options);
    if (e.id && !$(Nat.F.GetEscapedId(options.clientId)).length) {
        var clientId = $(e).attr('clientId');
        if (clientId) options.clientId = clientId;
    }
    var element = options.editable
        ? options.editable.element.find(Nat.F.GetEscapedId(options.clientId))
        : $(Nat.F.GetEscapedId(options.clientId));
    element.attr("data-val-lookupWindow", "true");

    var dialog = new Nat.Classes.SelectionDialog(options, editable);
    dialog.Initialize();
    dialog.Open();
};

Nat.F.AddRequiredMark = function(form) {
    form.find('[data-val-required][name],[data-val-requiredisvisible][name]').each(function () {
        var t = $(this);
        var l;
        if (this.type === 'radio') {
            l = form.find('label[for="' + t.attr('name') + '"]');
        }
        else {
            l = form.find('label[for="' + (t.attr('id') || t.attr('name')) + '"]');
        }
        if (!t.hasClass('k-checkbox'))
            l.addClass('requiredField');
    });
};

Nat.F.SetReadOnlyFields = function(form, readonly) {
    if (readonly == null) readonly = true;

    form.find('.k-checkbox-label,input.k-checkbox').attr("disabled", readonly);
    if (readonly)
        form.find('.m-linkSelectForCombobox').hide();
    else
        form.find('.m-linkSelectForCombobox').show();

    form.find('[name]').each(function () {
        var data = $(this).data();
        var setReadonly = false;
        for (var prop in data) {
            var prefix = prop.substring(0, 5);
            if (data.hasOwnProperty(prop) && (prefix === 'kendo' || prefix === 'natuc')) {
                if (data[prop].readonly) {
                    data[prop].readonly(readonly);
                    setReadonly = true;
                }
                if (prop === "kendoDropDownList" && data[prop].span) {
                    if (readonly)
                        data[prop].span.addClass("m-field-readOnly");
                    else
                        data[prop].span.removeClass("m-field-readOnly");
                }
                if (prop === "kendoMultiSelect" && data[prop].wrapper) {
                    if (readonly)
                        data[prop].wrapper.addClass("m-field-readOnly");
                    else
                        data[prop].wrapper.removeClass("m-field-readOnly");
                }
                if (prop === 'kendoNumericTextBox' && data[prop].wrapper) {
                    if (readonly)
                        data[prop].wrapper.find('.k-formatted-value').addClass("m-field-readOnly");
                    else
                        data[prop].wrapper.find('.k-formatted-value').removeClass("m-field-readOnly");
                }
                if (prop === 'kendoEditor') {
                    if (data[prop].wrapper)
                        data[prop].wrapper.find('.k-editor-toolbar').toggle(!readonly);
                    if (data[prop].body) {
                        if (readonly)
                            $(data[prop].body).removeAttr("contenteditable");
                        else
                            $(data[prop].body).attr("contenteditable", true);
                    }
                }
                if (prop === 'kendoUpload' && data[prop].element) {
                    //data[prop].enable(!readonly);
                    data[prop].wrapper.toggle(!readonly);
                }
                break;
            }
        }

        if (!setReadonly)
            $(this).attr("readonly", readonly);
        if (readonly)
            $(this).addClass("m-field-readOnly");
        else
            $(this).removeClass("m-field-readOnly");
    });
};

Nat.F.MainFuncInit = function(vm, options, area, className, field) {
    var initField = "Initialized_" + field;
    if (Nat[area][initField] && vm[field] && vm[field].grid && vm[field].grid.element)
        return;

    Nat[area][initField] = true;
    if (vm[field] && vm[field].destroy)
        vm[field].destroy();

    if (className.indexOf('.') > -1)
        vm[field] = eval('new ' + className + '(vm, options)');
    else
        vm[field] = new Nat[area][className](vm, options);
    vm[field].Initialize();
    if (vm[field].element)
        $('.k-grid-cancel-changes[accesskey="s"]').attr('accesskey', 'z');
    if (!vm[field].destroy && vm[field].element) {
        vm[field].destroy = function (e) {
            if (vm[field]) {
                if (vm[field].grid && vm[field].grid.dataSource && vm[field].grid.dataSource.options && vm[field].grid.dataSource.options.transport && vm[field].grid.dataSource.options.transport.read)
                    vm[field].grid.dataSource.options.transport.read.data = null;
                if (vm[field].grid && vm[field].grid.dataSource && vm[field].grid.dataSource.transport && vm[field].grid.dataSource.transport.options && vm[field].grid.dataSource.transport.options.read)
                    vm[field].grid.dataSource.transport.options.read.data = null;
                vm[field].element = null;
                vm[field].options = null;
            }
            vm[field] = null;
        };
        vm[field].element.data('kendoMainInit', vm[field]);
    }
};

Nat.F.SetTitleForGridEditableWindow = function (editable, windowMessage) {

    var model = editable.options.model;
    if (editable.options.target &&
        editable.options.target.options.editable &&
        editable.options.target.options.editable.mode &&
        editable.options.target.options.editable.mode.toLowerCase() !== 'popup')
        return;

    var windowTitle = editable.element.closest('.k-window').find('> > .k-window-title');
    var modelName = null;
    if (window.isKz)
        modelName = model.nameKz || model.NameKz || model.name || model.Name;
    else
        modelName = model.nameRu || model.NameRu || model.name || model.Name;

    if (modelName && !windowMessage)
        windowMessage = windowTitle.text();

    if (windowMessage) {
        if (model.id)
            windowMessage = windowMessage + ' (' + model.id + ')';
        if (modelName) windowMessage = windowMessage + ': ' + modelName;
        windowTitle.text(windowMessage);
    }
};

Nat.F.GetNameForGroupHeaderForeignKey = function (data, modelField) {
    if (data.items && data.items.length > 0) {
        if (data.items[0][modelField])
            return data.items[0][modelField];
        return Nat.F.GetNameForGroupHeaderForeignKey(data.items[0], modelField);
    }

    return '';
};

Nat.F.InitTemplateById = function(id, data) {
    var html = $('#' + id).html();
    return kendo.template(html, data || {});
};

Nat.F.UploadSuccess = function (e) {
    var editable = this.element.closest('.k-popup-edit-form').data('kendoEditable');
    var model = editable.options.model;
    model.set(this.name, e.response.fileName);
    model.set(this.name + 'Uid', 'WebSite.Upload.' + e.response.fileUid);
};

Nat.F.UploadRemove = function (e) {
    e.data = { uploadUid: e.files[0].uid };
};

Nat.F.SetValue = function(model, name, row, parse, format) {
    if (Array.isArray(name)) {
        name.forEach(function(item) {
            Nat.F.SetValue(model, item, row, parse, format);
        });
        return;
    }
    var value = row[name];
    if (parse) value = parse(value);
    var element = $('#' + name);
    if (element.length) {
        if (element.is(':checkbox')) {
            var nameSpecialCharRegExp =
                /("|\%|'|\[|\]|\$|\.|\,|\:|\;|\+|\*|\&|\!|\#|\(|\)|<|>|\=|\?|\@|\^|\{|\}|\~|\/|\||")/g;
            var attrName = element.attr('name').replace(nameSpecialCharRegExp, '\\$1');
            var hiddenSelector = 'input:hidden[name=\'' + attrName + '\']';
            var checkbox = element.closest('.k-switch').length ? element.closest('.k-switch') : element;
            var hidden = checkbox.next(hiddenSelector);
            if (!hidden.length)
                hidden = checkbox.next('label.k-checkbox-label').next(hiddenSelector);
            if (hidden.length) {
                hidden.val(value);
            } else
                input.prop('checked', value);
        } else
            element.val(value != null ? (format ? kendo.format(format, value) : value) : null);
        model.set(name, value);
        model[name] = value;
        let ddl = element.data('kendoDropDownList');
        if (ddl && !ddl.dataSource._requestInProgress && !ddl.dataSource.get(value)) {
            ddl.dataSource.read();
        }
    } else if (value && typeof value === 'object' && value.constructor === Array) {
        model.set(name, value);
    } else {
        model.set(name, value);
        model[name] = value;
    }
};

Nat.F.AddRowWithDefaultOnReady = function (gridName, options) {
    
    kendo.syncReady(function () {
        var grid = $(gridName).data('kendoGrid') || $(gridName).data('kendoTreeList');
        var add = function () {
            grid.addRow();
            var model = grid.editor ? grid.editor.editable.options.model : grid.editable.options.model;

            for (var p in options) {
                if (!options.hasOwnProperty(p))
                    continue;

                if (options[p] && options[p] !== "0001-01-01T00:00:00")
                    Nat.F.SetValue(model, p, options);
            }
        };

        if (!grid.options.autoBind)
            add();
        else {
            grid.dataSource.one('requestEnd',
                function() {
                    setTimeout(add, 200);
                });
        }
    });
};

Nat.F.HideButtons = function(cmdTd, grid, options) {
    var cmdCell = $(cmdTd);
    var currentDataItem = grid.dataItem(cmdCell.closest("tr"));
    if (!currentDataItem)
        return;

    if (!grid.readOnly && cmdCell.attr('allowDestroy') !== 'false' &&
    (currentDataItem.CanDestroy ||
        ((!currentDataItem.isNew || currentDataItem.isNew()) && currentDataItem.CanDestroy === undefined)))
        cmdCell.find('.k-grid-delete').show();
    else
        cmdCell.find('.k-grid-delete').hide();

    if (!grid.readOnly && cmdCell.attr('allowUpdate') !== 'false' &&
    (currentDataItem.CanUpdate ||
        ((!currentDataItem.isNew || currentDataItem.isNew()) && currentDataItem.CanUpdate === undefined)))
        cmdCell.find('.k-grid-edit').show();
    else
        cmdCell.find('.k-grid-edit').hide();

    if (grid.readOnly || currentDataItem.CanAddChild === false || cmdCell.attr('allowCreate') === 'false')
        cmdCell.find('.k-grid-add').hide();
    else
        cmdCell.find('.k-grid-add').show();

    if (currentDataItem.CanDownload === false)
        cmdCell.find('.k-grid-download').hide();
    else
        cmdCell.find('.k-grid-download').show();

    if (currentDataItem.Favorite !== undefined) {
        if (currentDataItem.Favorite) {
            cmdCell.find('.k-grid-favorite-add').hide();
            cmdCell.find('.k-grid-favorite-remove').show();
        } else {
            cmdCell.find('.k-grid-favorite-add').show();
            cmdCell.find('.k-grid-favorite-remove').hide();
        }
    }

    if (options) {
        if (options.hideViewForExistsEdit) {
            if (currentDataItem.CanUpdate && !grid.readOnly)
                cmdCell.find('.k-grid-view').hide();
            else
                cmdCell.find('.k-grid-view').show();
        }
    }
};

Nat.F.AddOpenLogButton = function(grid) {
    if (!grid.element.attr('addOpenLogButton'))
        return;

    var funcStr = grid.element.attr('addOpenLogButtonGetOptions');
    var editable = grid.editable || grid.editor.editable;
    if (!editable || !funcStr || (editable.options.model.isNew && editable.options.model.isNew()))
        return;

    if (!grid.options.editable || !grid.options.editable.mode || grid.options.editable.mode.toLowerCase() !== 'popup')
        return;

    var buttons = editable.element.find('.k-edit-form-container .k-edit-buttons');
    var text = Nat.LOG.Resources.title();
    var logButton = $('<a href="#" class="k-button k-button-icontext" style="float:left;" role="button"><span class="fas fa-history"></span> ' + text + '</a>');
    var openLog = function() {
        var options = eval(funcStr);
        Nat.LOG.OpenLogManager(options);
        return false;
    };

    buttons.append(logButton.on('click', openLog));
};

Nat.F.SetResources = function(name, data) {
    if (!Nat.Resources)
        Nat.Resources = {};
    if (!Nat.Resources[name])
        Nat.Resources[name] = {};
    var res = Nat.Resources[name];
    for (var p in data) {
        if (data.hasOwnProperty(p)) {
            res[p] = data[p];
        }
    }
};

Nat.F.SetDataBindByName = function(form, modelField) {
    if (modelField)
        modelField = modelField + ".";
    else
        modelField = '';

    form.find('input[name],select[name],textarea[name],div[custom-bind-input]').each(function() {
        var row = $(this);
        var customName = row.attr('custom-bind-input');
        if (customName)
            row.attr('data-bind', row.attr('data-bind').replace(customName, modelField + customName));
        else if (row.attr('type') === 'checkbox' || row.attr('type') === 'radio')
            row.attr('data-bind', "checked: " + modelField + row.attr('name'));
        else if (row.attr('type') !== 'file')
            row.attr('data-bind', "value: " + modelField + row.attr('name'));
    });
};

Nat.F.DataSourceAddDataHandler = function(grid, rewriteData, getDataHandler) {
    var originalData = rewriteData ? null : grid.dataSource.transport.options.read.data;
    grid.dataSource.transport.options.read.data = function (e) {
        var data = getDataHandler(e);
        if (originalData) {
            var originalDataVal;
            if (originalData instanceof Function) {
                originalDataVal = originalData.call(this, e);
            } else
                originalDataVal = originalData;

            if (!data)
                data = originalDataVal;
            else {
                for (var prop in originalDataVal) {
                    if (!originalDataVal.hasOwnProperty(prop))
                        continue;

                    if (originalDataVal[prop] !== null && data[prop] === undefined) {
                        data[prop] = originalDataVal[prop];
                    }
                }
            }
        }

        return data;
    };
};

Nat.F.dataSourceMapDates = function(ds, fields) {
    var parameterMap = ds.transport.parameterMap;

    var mapField = function(row, field, callback) {
        if (!row) return;

        var dotIndex = field.indexOf('.');
        var arrayIndex = field.indexOf('|');
        if (dotIndex === -1 && arrayIndex === -1) {
            callback(row, field);
        } else if (dotIndex > -1 && dotIndex < arrayIndex || arrayIndex === -1) {
            mapField(row[field.substring(0, dotIndex)], field.substring(dotIndex + 1), callback);
        } else {
            var array = row[field.substring(0, arrayIndex)];
            field = field.substring(arrayIndex + 1);
            if (!array) return;
            for (var i = 0; i < array.length; i++) {
                mapField(array[i], field, callback);
            }
        }
    };
    var mapFields = function(row, callback) {
        for (var i = 0; i < fields.length; i++) {
            mapField(row, fields[i], callback);
        }
    };
    var map = function(r, field) {
        if (r[field]) r[field] = kendo.toString(r[field], 'dd.MM.yyyy');
    };
    ds.options.FieldsForMapDates = fields;
    ds.options.MapFields = function(row) { mapFields(row, map); };
    ds.transport.parameterMap = function(options, operation) {
        if (operation !== 'read') {
            if (ds.options.batch) {
                for (var rIndex = 0; rIndex < options.length; rIndex++) {
                    mapFields(options[rIndex], map);
                }
            } else {
                mapFields(options, map);
            }
        }

        return parameterMap(options, operation);
    };

    ds.bind('requestEnd',
        function(e) {
            if (!e.response || !e.response.Data)
                return;
            var map = function(r, field) {
                if (!r[field])
                    return;

                r[field] = r[field].replace(/\d+/,
                    function(n) { return parseInt(n) + (new Date(parseInt(n)).getTimezoneOffset() + 360) * 60000; });
            };

            var groupDataMap = function(isGroup, data) {
                if (!isGroup) {
                    for (var rIndex = 0; rIndex < data.length; rIndex++) {
                        mapFields(data[rIndex], map);
                    }
                } else {
                    for (var gIndex = 0; gIndex < data.length; gIndex++) {
                        var groupRow = data[gIndex];
                        var mapFieldIndex = fields.indexOf(groupRow.Member);
                        if (mapFieldIndex > -1) {
                            mapField(groupRow, 'Key', map);
                        }
                        groupDataMap(groupRow.HasSubgroups, groupRow.Items);
                    }
                }
            };

            if (ds.group().length && e.type === 'read')
                groupDataMap(true, e.response.Data);
            else
                groupDataMap(false, e.response.Data);
        });
};

Nat.F.OpenQRScan = function(e) {
    if (VM.qrCodeScan && VM.qrCodeScanWindow) {
        VM.qrCodeScan.searchInputID = e.input;
        VM.qrCodeScanWindow.title(e.title);
        VM.qrCodeScanWindow.open();
    } else {
        if (VM.qrCodeScanWindow)
            VM.qrCodeScanWindow.destroy();

        var w = $('<div />');
        $(document.body).append(w);
        w.kendoWindow({
            title: e.title,
            width: 668,
            height: 544,
            resizable: false,
            modal: true,
            content: '/QRScan?searchInputID=' + e.input,
            close: function() {
                if (VM.qrCodeScanWindow) {
                    VM.qrCodeScanWindow.destroy();
                    VM.qrCodeScanWindow = null;
                }
            }
        });
        VM.qrCodeScanWindow = w.data('kendoWindow');
        VM.qrCodeScanWindow.center().open();
    }
};

Nat.F.GetSelectedIds = function(list) {
    var selected = list.select();
    var ids = [];
    for (var i = 0; i < selected.length; i++) {
        if ($(selected[i]).hasClass('k-no-data'))
            continue;
        var dataItem = list.dataItem(selected[i]);
        if (dataItem) ids.push(dataItem.id);
    }

    return ids;
};

Nat.F.OpenConfigSearch = function(e) {
    e.event.preventDefault();
    let link = $(e.link);
    var o = link.data('kendoSearchConfig');
    if (o) {
        if (o.popup) o.popup.toggle();
        return;
    }
    o = {};
    link.data('kendoSearchConfig', o);
    o.popup = $('<div></div>').insertAfter(link).kendoPopup({ anchor: link }).data('kendoPopup');
    var list = $('<select></select>');
    o.popup.element.append(list);
    o.list = list.kendoListBox({
        selectable: "multiple",
        dataTextField: e.configSearch.dataTextField || 'name',
        dataValueField: e.configSearch.dataValueField || 'id',
        dataSource: { data: e.configSearch.data },
        change: function() {
            if (e.configSearch.change)
                e.configSearch.change(Nat.F.GetSelectedIds(o.list));
            if (e.configSearch.vm) {
                var vm = VM[e.configSearch.vm];
                vm[e.configSearch.changeFnVM || 'onConfigSearchChange'](Nat.F.GetSelectedIds(o.list));
            }
        }
    }).data('kendoListBox');
    o.list.wrapper.addClass('m-searchConfigToolbarListBox');
    if (e.configSearch.value) {
        var items = null;
        if (!Array.isArray(e.configSearch.value)) {
            let dataItem = o.list.dataSource.get(e.configSearch.value);
            if (dataItem)
                items = o.list.wrapper.find("[data-uid='" + dataItem.uid + "']");
        } else {
            items = [];
            for (var i = 0; i < e.configSearch.value.length; i++) {
                let dataItem = o.list.dataSource.get(e.configSearch.value[i]);
                if (dataItem)
                    items.push(o.list.wrapper.find("[data-uid='" + dataItem.uid + "']")[0]);
            }
        }

        if (items) o.list.select(items);
    }
    o.popup.open();
};

Nat.F.AutoResizeTabStripInSplitter = function(tabStrip) {
    var tabStripElement = tabStrip.element || tabStrip;
    var parent = tabStripElement.parent();
    if (parent.hasClass('k-tabstrip-wrapper')) {
        var parentId = tabStripElement.attr('id') + "-parent";
        parent.attr("id", parentId).addClass('tabStrip-h-100P');
    }
    tabStripElement.addClass('tabStrip-h-100P');

    var treeSplitterElement = tabStripElement.closest('.k-splitter');
    var resizeContent = function () {
        treeSplitterElement.data('kendoSplitter').resize();
        expandContentDivs(tabStripElement, tabStripElement.children(".k-content"));
    };

    treeSplitterElement.data('kendoSplitter').bind('resize', resizeContent);
    resizeContent();
};

Nat.F.AutoResizeTabStrip = function(tabStrip) {
    var tabStripElement = tabStrip.element || tabStrip;
    var parent = tabStripElement.parent();
    if (parent.hasClass('k-tabstrip-wrapper')) {
        var parentId = tabStripElement.attr('id') + "-parent";
        parent.attr("id", parentId).addClass('tabStrip-h-100P');
    }
    tabStripElement.addClass('tabStrip-h-100P');

    var resizeContent = function () {
        expandContentDivs(tabStripElement, tabStripElement.children(".k-content"));
    };

    resizeContent();
};

Nat.F.ImportBySelectionDialog = function(e, data) {
    var grid = $(e.target).closest('.k-grid');
    grid = grid.data('kendoGrid') || grid.data('kendoTreeList');
    var select = function(selection) {
        var postData = data.postData ? (typeof data.postData === "function" ? data.postData() : data.postData) : {};
        postData.selection = selection;
        if (data.postUrl) {
            kendo.ui.progress(grid.element, true);
            $.ajax({
                url: data.postUrl,
                type: "POST",
                xhrFields: {
                    withCredentials: true
                },
                data: postData
            }).done(function(result) {
                if (result.error)
                    kendo.alert(result.error);
                kendo.ui.progress(grid.element, false);
                grid.dataSource.read();
                if (data.done) data.done(result);
            }).fail(function(e) {
                kendo.ui.progress(grid.element, false);
                errorHandler(e);
            });
        }
        else
            data.done(postData);
    };
    var dialog = new Nat.Classes.SelectionDialog(
        {
            multiSelect: data.multiSelect === undefined ? true : data.multiSelect,
            url: data.url,
            getDataParams: data.getDataParams,
            title: data.title || '',
            valueField: data.valueField || 'id',
            member: data.member,
            type: data.selectionModelType,
            select: select,
            width: data.width,
            height: data.height
        },
        kendo.observable({ options: { model: data.model || {} } }));
    dialog.Initialize();
    dialog.Open();
};

Nat.F.SelectionSearchHandler_data = {};

Nat.F.SelectionSearchHandler = function(gridName) {
    var read = function() {
        var grid = $('#' + (gridName || 'grid')).data('kendoGrid') || $('#' + (gridName || 'treeList')).data('kendoTreeList');
        if (!grid && gridName) {
            var $grid = $('#' + gridName);
            grid = $grid.data('kendoTreeView') || $grid.data('kendoListView') || $grid.data('kendoGantt');
        }
        grid.dataSource.page(1);
    };

    return {
        readDelay: function(e, delayTime) {
            clearTimeout(Nat.F.SelectionSearchHandler_data[gridName]);
            Nat.F.SelectionSearchHandler_data[gridName] = setTimeout(read,
                e && e.keyCode === 13 ? 1 : delayTime || this.readDelayTime || 1000);
        }
    };
};

Nat.F.OnBatchGridChangePage = function(e, options) {
    if (e.sender.dataSource.hasChanges()) {
        e.preventDefault();
        var save = function() {
            e.sender.dataSource.one('sync',
                function() {
                    if (!e.sender.dataSource.hasChanges())
                        e.sender.dataSource.page(e.page);
                });
            e.sender.dataSource.sync();
        };
        var d = $('<div/>');
        d.kendoDialog({
            width: "500px",
            title: options.title,
            closable: false,
            modal: true,
            draggable: true,
            content: options.confirm,
            actions: [
                { text: options.save, primary: true, action: save },
                { text: options.ok, action: function() { e.sender.dataSource.page(e.page); } },
                { text: options.cancel }
            ],
            close: function() {
                d.data('kendoDialog').destroy();
            }
        });
        var dialog = d.data('kendoDialog');
        dialog.open();
        dialog.center();
    }
};

Nat.F._escapeIdReg = /(\.)/g;
Nat.F.GetEscapedId = function(fieldName, onlyId) {
    return (onlyId ? '' : '#') + fieldName.replace(Nat.F._escapeIdReg, '_');
};

Nat.F._parseHttpLinksReg1 =/&quot;(https?:\/\/.+?)&quot;/gi;
Nat.F._parseHttpLinksReg2 =/(https?:\/\/.+?)( |,|$)/gi;
Nat.F._parseShareLinksReg1 =/&quot;(\\\\.+?)&quot;/g;
Nat.F._parseShareLinksReg2 =/(\\\\.+?\.\w+)( |,|$)/g;
Nat.F._parseShareLinksReg3 =/(\\\\.+?\\)( |,|$)/g;
Nat.F._parseShareLinksReg4 =/(\\\\.+?)( |,|$)/g;

// для обработки строк с ссылками в html
Nat.F.ParseToHtmlWithLinks = function(value) {
    if (!value)
        return value;

    var replaceFn = function(match, p1, p2, offset, input) {
        // пропускаем обработанные ссылки
        if (offset > 0 && (input[offset - 1] === '"' || input[offset - 1] === '>'))
            return match;

        return '<a href="' + p1 + '" target="_blank">' + p1 + '</a>' + p2;
    };

    value = kendo.htmlEncode(value)
        .replace(Nat.F._parseHttpLinksReg1, '<a href="$1" target="_blank">$1</a>')
        .replace(Nat.F._parseHttpLinksReg2, replaceFn)
        .replace(Nat.F._parseShareLinksReg1, '<a href="$1" target="_blank">$1</a>')
        .replace(Nat.F._parseShareLinksReg2, replaceFn)
        .replace(Nat.F._parseShareLinksReg3, replaceFn)
        .replace(Nat.F._parseShareLinksReg4, replaceFn);
    return value;
};

Nat.F.GetHtmlEditorMarginTemplate = function(id, text) {
    var select = $('<select style="width:190px" data-role="selectbox"></select>');
    select.attr('id', id);
    select.append($('<option value="0px"></option>').text(kendo.format(text, 0)));
    select.append($('<option value="6px"></option>').text(kendo.format(text, 6)));
    select.append($('<option value="12px"></option>').text(kendo.format(text, 12)));
    select.append($('<option value="18px"></option>').text(kendo.format(text, 18)));
    select.append($('<option value="24px"></option>').text(kendo.format(text, 24)));
    select.append($('<option value="30px"></option>').text(kendo.format(text, 30)));
    select.append($('<option value="36px"></option>').text(kendo.format(text, 36)));
    return select[0].outerHTML;
};

Nat.F.GetGridSettings = function(grid) {
    var data = [];
    grid.columns.forEach(function(item) {
        data.push(Nat.F.GetGridSettingsForCol(item));
    });
    return data;
};

Nat.F.GetGridSettingsForCol = function(column) {
    return {
        index: column["data-index"],
        hidden: column.hidden,
        locked: column.locked,
        width: column.width,
        field: column.field,
        command: column.command ? true : undefined,
        selectable: column.selectable ? true : undefined,
        columns: column.columns ? Nat.F.GetGridSettings(column) : undefined
    };
};

Nat.F.SetGridSettings = function(grid, data) {
    var existColumns = {};
    var childColumns = {};
    var commandColumn;
    var selectableColumn;
    var firstField = function(items) {
        if (items[0].field)
            return items[0].field;
        else if (items[0].columns)
            return firstField(items[0].columns);
        
        debugger;
        return null;
    };
    var initChildColumns = function(columns, item) {
        columns.forEach(function(column) {
            if (column.field) {
                childColumns[column.field] = column;
                existColumns[column.field] = item;
            }
            else if (column.columns)
                initChildColumns(column.columns, item);
            else
                debugger;
        });
    };

    grid.columns.forEach(function(item) {
        if (item.field)
            existColumns[item.field] = item;
        else if (item.command)
            commandColumn = item;
        else if (item.selectable)
            selectableColumn = item;
        else if (item.columns) {
            initChildColumns(item.columns, item);
        }
        else
            debugger;
    });

    var index = 0;
    // true если требуется вызвать перерисовку колонок (вызов функций изменения колонок выполняет эту задачу)
    var customResize = false;

    var processChildColumn = function(item, childIndex) {
        if (!item.field) {
            if (item.columns)
                item.columns.forEach(processChildColumn);
            return;
        }

        var column = childColumns[item.field];
        grid.reorderColumn(childIndex, column);

        if (item.hidden && !column.hidden) {
            grid.hideColumn(column);
            customResize = false;
        } else if (!item.hidden && column.hidden) {
            grid.showColumn(column);
            customResize = false;
        }

        if (grid.resizeColumn && item.width !== column.width) {
            grid.resizeColumn(column, item.width);
        } else if (!grid.resizeColumn && item.width !== column.width) {
            column.width = item.width;
            customResize = true;
        }
    };

    var commandColumnExists = false;
    var selectableColumnExists = false;
    for (var j = 0; j < data.length; j++) {
        if (data[j].command) commandColumnExists = true;
        if (data[j].selectable) selectableColumnExists = true;
    }

    if (!commandColumnExists && commandColumn)
        data.splice(0, 0, Nat.F.GetGridSettingsForCol(commandColumn));
    if (!selectableColumnExists && selectableColumn)
        data.splice(0, 0, Nat.F.GetGridSettingsForCol(selectableColumn));

    data.forEach(function(item) {
        var found = false;
        if (item.field && existColumns[item.field]) {
            grid.reorderColumn(index, existColumns[item.field]);
            found = true;
        } else if (item.command && commandColumn) {
            grid.reorderColumn(index, commandColumn);
            commandColumn = null;
            found = true;
        } else if (item.selectable && selectableColumn) {
            grid.reorderColumn(index, selectableColumn);
            selectableColumn = null;
            found = true;
        }
        else if (item.columns) {
            var field = firstField(item.columns);
            if (field) {
                grid.reorderColumn(index, existColumns[field]);
                found = true;
            }
        }

        if (!found) return;
        if (!grid.columns[index].hidden)
            customResize = false;

        if (item.hidden && !grid.columns[index].hidden) {
            grid.hideColumn(index);
            customResize = false;
        } else if (!item.hidden && grid.columns[index].hidden) {
            grid.showColumn(index);
            customResize = false;
        }

        if (item.locked && !grid.columns[index].locked) {
            grid.lockColumn(index);
            customResize = false;
        } else if (!item.locked && grid.columns[index].locked) {
            grid.unlockColumn(index);
            customResize = false;
        }

        if (grid.resizeColumn && item.width !== grid.columns[index].width) {
            grid.resizeColumn(grid.columns[index], item.width);
        } else if (!grid.resizeColumn && item.width !== grid.columns[index].width) {
            grid.columns[index].width = item.width;
            customResize = true;
        }

        if (item.columns)
            item.columns.forEach(processChildColumn);

        index++;
    });

    if (customResize) {
        for (var i = 0; i < grid.columns.length; i++) {
            if (!grid.columns[i].hidden) {
                grid.hideColumn(i);
                grid.showColumn(i);
            }
        }
    }
};

Nat.F.BindGridSettingsChanges = function(grid, fn) {
    grid.bind('columnLock', fn);
    grid.bind('columnUnlock', fn);
    grid.bind('columnHide', fn);
    grid.bind('columnShow', fn);
    grid.bind('columnResize', fn);
    grid.bind('columnReorder', fn);
};

Nat.F.UnbindGridSettingsChanges = function(grid, fn) {
    grid.unbind('columnLock', fn);
    grid.unbind('columnUnlock', fn);
    grid.unbind('columnHide', fn);
    grid.unbind('columnShow', fn);
    grid.unbind('columnResize', fn);
    grid.unbind('columnReorder', fn);
};

Nat.F._prepareHtmlToTemplateRegex = /#[0-9a-f]{6}|#[0-9a-f]{3}/gi;
Nat.F.PrepareHtmlToTemplate = function(template, options) {
    return template.replace(Nat.F._prepareHtmlToTemplateRegex,
        function(match) {
            var field = 'C' + match.substr(1);
            options[field] = match;
            return '#: data.colors.' + field + ' #';
        });
};

Nat.F.MaskViewSecurityText = function(value) {
    if (!value) 
        return '';
    return kendo.htmlEncode(value);/*
    var content = $('<div style="display: none" />').html(value);
    var button = $('<a href="#" onclick="return Nat.F.ShowMVST(event)" class="k-link"><span class="fas fa-eye"></span> ********</a>').attr('title', 'Показать содержимое');
    return $('<div />').append(button).append(content).html();*/
};

Nat.F.ShowMVST = function(e) {
    var td = $(e.target).closest('td');
    var div = td.find('>div');
    var button = td.find('>a');
    button.hide();
    div.show();
    setTimeout(function() {
            div.hide();
            button.show();
        },
        5000);

    return false;
};

Nat.F.FilterUIBoolTemplate = function(input) {
    if (window.currentCulture === "kk")
        return input.kendoDropDownList({
        dataSource: {
            data: [
                { text: "Шындық", value: true },
                { text: "Жалған", value: false },
                { text: "Бос көрсеткіш", value: 'null' }
            ]
        },
        dataTextField: "text",
        dataValueField: "value",
        valuePrimitive: true,
        optionLabel: "Барлығы"
        });
    if (window.currentCulture === "en")
        return input.kendoDropDownList({
            dataSource: {
                data: [
                    { text: "True", value: true },
                    { text: "False", value: false },
                    { text: "Null", value: 'null' }
                ]
            },
            dataTextField: "text",
            dataValueField: "value",
            valuePrimitive: true,
            optionLabel: "All"
        });
    return input.kendoDropDownList({
            dataSource: {
                data: [
                    { text: "Да", value: true },
                    { text: "Нет", value: false },
                    { text: "Пусто", value: 'null' }
                ]
            },
            dataTextField: "text",
            dataValueField: "value",
            valuePrimitive: true,
            optionLabel: "Показать все"
        });
};

Nat.F.InputConfirm = function(title, text, options) {
    var t = $('<p class="requiredField"></p>').text(text + ":");
    var input = $('<input class="k-textbox" style="width:100%" />');
    input.attr('id', "nat-f-input-confirm")
        .attr('name', "nat-f-input-confirm")
        .attr('maxLength', options && options.maxLength ? options.maxLength : 200)
        .attr('data-val-required', window.CoreLocalization.RequiredField || 'Field is required');
    var div = $('<div style="padding-bottom:40px"></div>').append(t).append(input);
    var uploadDocument;

    if (options && options.uploadFile) {
        var upload = $('<input type="file" />').attr('name', options.uploadFile).attr('id', options.uploadFile);
        upload.insertAfter(input);
        uploadDocument = upload.kendoUpload({
            async: {
                multiple: true,
                chunkSize: 512000,
                saveUrl: options.uploadUrl,
                removeUrl: options.removeUrl,
                autoUpload: true
            },
            validation: {
                allowedExtensions: [
                    ".jpg", ".jpeg", ".png", ".pdf", ".tiff", ".tif", "jfif", ".xls", ".doc", ".xlsx", ".docx", ".zip",
                    ".msg"
                ]
            },
            upload: function(e) {
                e.data = {
                    uploadUid: e.files[0].uid
                };
                e.data.chunkSize = 512000;
            },
            select: function(e) {
                if (e.files[0] && e.files[0].validationErrors && e.files[0].validationErrors[0]) {
                    kendo.alert(uploadDocument.options.localization[e.files[0].validationErrors[0]]);
                }
            },
            localization: { select: options.selectFile || undefined },
            error: errorHandler
        }).data('kendoUpload');
    }

    return new Promise((resolve, reject) => {
        var success = false;
        var dialog = div.kendoDialog({
            title: title,
            modal: true,
            width: '600px',
            actions: [
                {
                    text: options && options.okButton ? options.okButton : title,
                    primary: true,
                    action: function(e) {
                        var validator = dialog.element.data('kendoValidator');
                        if (!validator.validate())
                            return false;

                        var data = input.val();
                        if (uploadDocument) {
                            var filesData = [];
                            var files = uploadDocument.getFiles();
                            if (options.filesReqired && !files.length) {
                                if (typeof options.filesReqired === 'string')
                                    kendo.alert(options.filesReqired);
                                else
                                    kendo.alert(window.CoreLocalization.FilesRequired);
                                return false;
                            }

                            for (var i = 0; i < files.length; i++) {
                                filesData.push({UploadUid: files[i].uid, FileName: files[i].name});
                            }

                            success = true;
                            resolve({note: data, files: filesData});
                            return true;
                        }
                        
                        success = true;
                        resolve(data);
                        return true;
                    }
                },
                {
                    text: window.CoreLocalization.CancelButton || 'Cancel'
                }
            ],
            close: function() {
                dialog.destroy();
                if (!success && reject) {
                    reject('cancel');
                }
            }
        }).data('kendoDialog');
        dialog.element.kendoValidator({ errorTemplate: kendo.ui.Editable.prototype.options.errorTemplate });
        dialog.open();
        dialog.center();
    });
};

Nat.F.TemplateConfirm = function (title, kendoTemplate, options) {

    if (!options.model) 
        options.model = {};
    if (!options.model.uid)
        options.model = kendo.observable(options.model);

    var div = $('<div style="padding-bottom:40px"></div>');

    var editable = kendo.observable({ options: { model: options.model }, element: div });

    div.addClass('m-NatEditable');
    div.data('NatEditable', editable);

    var t;

    if (typeof v === 'function')
        t = kendoTemplate(options.data || {});
    else
        t = kendo.template(kendoTemplate)(options.data || {});

    div = div.append(t);

    if (options.bindByName)
        Nat.F.SetDataBindByName(div, typeof options.bindByName === 'string' ? options.bindByName : '');
    kendo.bind(div, options.model);
    Nat.F.AddRequiredMark(div);

    var uploadDocument;

    if (options.uploadFile) {
        var upload = $('<input type="file" />').attr('name', options.uploadFile).attr('id', options.uploadFile);
        div.append(upload);
        uploadDocument = upload.kendoUpload({
            async: {
                multiple: true,
                chunkSize: 512000,
                saveUrl: options.uploadUrl,
                removeUrl: options.removeUrl,
                autoUpload: true
            },
            validation: {
                allowedExtensions: [
                    ".jpg", ".jpeg", ".png", ".pdf", ".tiff", ".tif", "jfif", ".xls", ".doc", ".xlsx", ".docx", ".zip",
                    ".msg"
                ]
            },
            upload: function(e) {
                e.data = {
                    uploadUid: e.files[0].uid
                };
                e.data.chunkSize = 512000;
            },
            select: function(e) {
                if (e.files[0] && e.files[0].validationErrors && e.files[0].validationErrors[0]) {
                    kendo.alert(uploadDocument.options.localization[e.files[0].validationErrors[0]]);
                }
            },
            localization: { select: options.selectFile || undefined },
            error: errorHandler
        }).data('kendoUpload');
    }

    return new Promise((resolve, reject) => {
        var success = false;
        var dialog = div.kendoDialog({
            title: title,
            modal: true,
            width: '600px',
            actions: [
                {
                    text: options && options.okButton ? options.okButton : title,
                    primary: true,
                    action: function(e) {
                        var validator = dialog.element.data('kendoValidator');
                        if (!validator.validate())
                            return false;

                        if (uploadDocument) {
                            var filesData = [];
                            var files = uploadDocument.getFiles();
                            if (options.filesReqired && !files.length) {
                                if (typeof options.filesReqired === 'string')
                                    kendo.alert(options.filesReqired);
                                else
                                    kendo.alert(window.CoreLocalization.FilesRequired);
                                return false;
                            }

                            for (var i = 0; i < files.length; i++) {
                                filesData.push({UploadUid: files[i].uid, FileName: files[i].name});
                            }

                            success = true;
                            options.model.set('files', filesData);
                            resolve(options.model);
                            return true;
                        }
                        
                        success = true;
                        resolve(options.model);
                        return true;
                    }
                },
                {
                    text: options && options.cancelButton ? options.cancelButton : (window.CoreLocalization.CancelButton || 'Cancel')
                }
            ],
            close: function() {
                dialog.destroy();
                if (!success && reject) {
                    reject('cancel');
                }
            }
        }).data('kendoDialog');
        dialog.element.kendoValidator({ errorTemplate: kendo.ui.Editable.prototype.options.errorTemplate });
        dialog.open();
        dialog.center();
        options.model.bind('change',
            function(e) {
                if (e.field) {
                    var validator = dialog.element.data('kendoValidator');
                    validator.validateInput($('#' + e.field));
                }
            });
    });
};

Nat.F.AddMermoyLeakClosure1 = function () {
    /*
        how to use, in some init class method:

        this._leakValue = Nat.F.AddMermoyLeakClosure1();
    */

    function outer(){
        var largeArray = []; // unused array
        return function innerAddMermoyLeakClosure1(num){
            largeArray.push(num);
        }
    }
    let appendNumbers = outer(); // get the inner function
    // call the inner function repeatedly
    for (let i=0; i< 100000000; i++){
        appendNumbers(i);
    }

    return appendNumbers;
};

Nat.F.SimpleLikeHtmlTagReplace = function(template, enocode) {
    return (enocode || enocode == null ? kendo.htmlEncode(template) : template)
        .replace(/{(\/)?(b|i|u|mark|br)}/g, '<$1$2>');
};

Nat.F.DateAlert = function (e) {
    let datealertMoreDays = parseInt(this.element.attr('datealert-more-days') || 0);
    let datealertLessDays = parseInt(this.element.attr('datealert-less-days') || 29);
    let message;
    let value = this.value();
    let name = this.element.attr('name');
    if (!name) return;
    // проверка для дата конца, истечения
    if (name.indexOf('End') > -1 || name.indexOf('Expire') > -1) {
        if (value < kendo.date.today())
            message = kendo.format(window.CoreLocalization.CheckEnteredDate, value);
    }
    // проверка всех дат
    else {
        if (value > kendo.date.addDays(kendo.date.today(), datealertMoreDays))
            message = kendo.format(window.CoreLocalization.CheckEnteredDate, value);
        if (value < kendo.date.addDays(kendo.date.today(), -datealertLessDays))
            message = kendo.format(window.CoreLocalization.CheckEnteredDate, value);
    }
    if (message) {
        let tooltip = this.wrapper.kendoTooltip({
            content: message,
            //hideAfter: 5000,
            autoHide: true,
            animation: {
                open: {
                    effects: "fade:in"
                },
                close: {
                    effects: "fade:out"
                }
            },
            hide: function () {
                tooltip.destroy();
            }
        }).data('kendoTooltip');
        tooltip.show();
        setTimeout(function () {tooltip.hide() }, 5000);
    }
};