var OnSelectionChange = function(value) {
    $.cookie("langid", value, { path: "/", expires: 365 });
    window.location.reload(true);
};

var errorHandler = function (e) {
    if (e.xhr && e.xhr.status === 401 && e.xhr.getResponseHeader('x-responded-json')) {
        // Пропустить будет обработано другим событием
        return;
    }
    if (e.xhr && e.xhr.status === 503 && window.checkServiceProcedure) {
        window.checkServiceProcedure();
        return;
    }

    var accountLoginPage = '/account/login';
    if (e.responseURL &&
        e.responseURL.toLowerCase().indexOf(accountLoginPage) > -1 &&
        location.pathname.substr(0, accountLoginPage.length).toLowerCase() !== accountLoginPage) {
        SessionExpiredAlert(e.responseURL);
        return;
    }

    if (this.lastRequestType === "destroy") {
        this.cancelChanges();
    }
    else if (this.lastRequestGridName && (this.lastRequestType === "update" || this.lastRequestType === "create")) {
        var c = $('#' + this.lastRequestGridName);
        var grid = c.data('kendoGrid') || c.data('kendoTreeList');
        if (grid) {
            grid.one('dataBinding',
                function(eo) {
                    eo.preventDefault();
                });
        }
    }

    if (e.XMLHttpRequest) {
        if (e.logErrorToConsole) 
            e.XMLHttpRequest.logErrorToConsole = true;
        errorHandler(e.XMLHttpRequest);
        return;
    }

    var errors = e.errorThrown ? e.errorThrown + ' ' : '';
    if (e.statusText)
        errors += e.statusText;
    else if (e.xhr && e.xhr.statusText && e.xhr.statusText !== e.errorThrown)
        errors += e.xhr.statusText;

    if (errors === 'custom error ' || errors === 'custom error' || !errors) {
        errors = '';
        for (var i in e.errors)
            if (e.errors.hasOwnProperty(i))
                for (var j in e.errors[i].errors)
                    if (e.errors[i].errors.hasOwnProperty(j))
                        errors += e.errors[i].errors[j] + "<br/>";
    }
    else if (e.responseText && e.errorThrown && errors !== 'custom error')
        errors += e.responseText;
    else if (e.xhr && e.xhr.responseText && e.errorThrown && errors !== 'custom error')
        errors += e.xhr.responseText;
    else if (e.responseText) {
        if (errors === 'OK')
            errors = e.responseText;
        else
            errors += ' ' + e.responseText;
    }

    if (e.logErrorToConsole) {
        if (window.console && window.console.error)
            window.console.error(errors && errors !== 'error' ? errors : 'Күтпеген қате пайда болды. Возникла не предвиденная ошибка.');
        return;
    }

    var divDialog = $('<div/>');
    $(document.body).append(divDialog);

    var actions = [];
    if (document.queryCommandSupported('copy') && window.CopyToClipboard)
        actions.push({
            text: window.CoreLocalization.CopyError,
            primary: true,
            action: function() {
                CopyToClipboard(divDialog[0]);
            }
        });
    actions.push({ text: 'OK' });
    divDialog.kendoDialog({
        modal: true,
        closable: false,
        content: errors && errors !== 'error' ? errors : 'Күтпеген қате пайда болды<br/>Возникла не предвиденная ошибка',
        minWidth: '450px',
        maxWidth: '900px',
        maxHeight: '500px',
        close: function() {
            divDialog.data('kendoDialog').destroy();
        },
        actions: actions
    });
};

var CopyToClipboard = function (node) {
    var range;
    if (document.selection) { 
        range = document.body.createTextRange();
        range.moveToElementText(node);
        range.select().createTextRange();
        document.execCommand("copy"); 
    } else if (window.getSelection) {
        window.getSelection().removeAllRanges(); 
        range = document.createRange();
        range.selectNode(node);
        range.setStartBefore(node.firstChild);
        range.setEndAfter(node.lastChild);
        window.getSelection().addRange(range);
        document.execCommand("copy");
    }
};

function onRequestStartHandler(e, lastRequestGridName) {
    this.lastRequestType = e.type;
    this.lastRequestGridName = lastRequestGridName;
};

var gridShowHistoryButtonClick = function(sender, kGrid) {
    $(sender).toggleClass('k-state-selected');
    var grid = kGrid ? kGrid.element : $(sender).closest('.k-grid');
    grid.attr('showHistory', $(sender).hasClass('k-state-selected'));
    if (!kGrid)
        kGrid = grid.data('kendoGrid') || grid.data('kendoTreeList');
    kGrid.dataSource.read();
    return false;
};

var gridNoHistoryAllowSaveButtonClick = function(sender, kGrid) {
    $(sender).toggleClass('k-state-selected');
    var grid = kGrid ? kGrid.element : $(sender).closest('.k-grid');
    grid.attr('allowSaveNoHistory', $(sender).hasClass('k-state-selected'));
    if (!kGrid)
        kGrid = grid.data('kendoGrid') || grid.data('kendoTreeList');
    var ds = kGrid.dataSource;
    var op = ds.transport.options;
    if (!op.update.data) 
        op.update.data = {};
    op.update.data.allowSaveNoHistory = grid.attr('allowSaveNoHistory');
    return false;
};

var gridOpenWindowForChildGridClick = function(sender, referenceField, gridName) {
    if (!gridName) gridName = referenceField;
    var grid = sender.tagName ? $(sender).closest('.k-grid') : sender.element;
    var kgrid = sender.tagName ? grid.data('kendoGrid') : sender;
    var w = $('#window_' + grid[0].id + '_' + gridName).data('kendoWindow');
    var childgrid = $('#childgrid_' + grid[0].id + '_' + gridName).data('kendoGrid');

    var dataItem = kgrid.dataItem(kgrid.select());
    if (!dataItem || dataItem.isNew()) return;

    var rowName = getDefaultRowName(dataItem);
    childgrid.dataSource.filter({
        field: referenceField,
        operator: "eq",
        value: dataItem.id,
        name: rowName
    });

    $(childgrid.columns).each(function(i) {
        if (this.field === referenceField)
            childgrid.hideColumn(i);
    });

    if (!w.myResizeOnOpen || $(window).width() < w.wrapper.width() || $(window).height() < w.wrapper.height()) {
        w.wrapper.width($(window).width() * 0.9);
        w.wrapper.height($(window).height() * 0.8);
        w.myResizeOnOpen = true;
    }

    if (!w.options.titleTemplate && w.options.title)
        w.options.titleTemplate = w.options.title;

    if (rowName && w.options.titleTemplate)
        w.title(w.options.titleTemplate + ': ' + rowName);

    w.center();
    w.open();
};

var readShowHistoryData = function() {
    return {
        showHistory: $('#grid').attr('showHistory') || false
    };
}

var readShowHistoryDataFor = function(id) {
    return {
        showHistory: $('#' + id).attr('showHistory') || false
    };
}

var expandContentDivs = function(tabStrip, divs) {
    var visibleDiv = divs.filter(":visible");
    var verticalSpace = tabStrip.innerHeight()
        - tabStrip.children(".k-tabstrip-items").outerHeight()
        - parseFloat(visibleDiv.css("padding-top"))
        - parseFloat(visibleDiv.css("padding-bottom"))
        - parseFloat(visibleDiv.css("border-top-width"))
        - parseFloat(visibleDiv.css("border-bottom-width"))
        - parseFloat(visibleDiv.css("margin-bottom"));

    divs.height(Math.floor(verticalSpace));
    // all of the above padding/margin/border calculations can be replaced by a single hard-coded number for improved performance
    var grid = visibleDiv.find('>.k-grid').data('kendoGrid');
    if (grid) grid.resize();
};

var OnGridDefault_DataBound = function (e) {
    GridHideButtons(e.sender);
};

var GridHideButtons = function (grid) {
    if (!grid.table)
        return;

    grid.trigger('beforeHideButtons');

    var wordwrapCells = grid.table.find('td .m-tree-wordwrap');
    wordwrapCells.each(function() {
        var icons = $(this).parent().find('> .k-icon');
        $(this).css('width', 'calc(100% - ' + (icons.length * icons.width()) + 'px)');
    });

    var data = grid.table.find("tbody tr .k-command-cell");
    if (grid.lockedTable) $.merge(data, grid.lockedTable.find("tbody tr .k-command-cell"));
    var hideViewForExistsEdit = grid.element.attr('hideViewForExistsEdit') ? true : false;
    data.each(function() {
        Nat.F.HideButtons(this, grid, { hideViewForExistsEdit: hideViewForExistsEdit });
    });

    grid.trigger('hideButtons');
};

var OnGridDefault_BeforeEdit = function (e) {
    if (e.sender.readOnly || e.sender.editable && e.sender.editable.options.readOnly)
        e.preventDefault();
    else if (e.model.CanUpdate !== undefined &&
        !e.model.CanUpdate &&
        window.event &&
        !$(window.event.target).hasClass('k-grid-view') && 
        !this._editInReadonly)
        e.preventDefault();
};

var defaultCodeGenArea = "DIC";

var OnGridDefault_Edit = function (e) {
    var isDirty = e.model.dirty;
    var editable = e.sender.editable || e.sender.editor.editable;
    var isNew = e.model.isNew && e.model.isNew();
    if (isNew && !isDirty && e.sender.element[0].id.indexOf('childgrid_') === 0) {
        var filters = e.sender.dataSource.filter();
        if (filters && filters.filters) {
            $(filters.filters).each(function() {
                if (this.operator === 'eq') {
                    if (e.model[this.field + '_name'] !== undefined && this.name)
                        e.model[this.field + '_name'] = this.name;

                    editable.element.find('#' + this.field).val(this.value);
                    e.model.set(this.field, this.value);
                }
            });
        }
    }

    var cellIndex = e.sender.cellIndex ? e.sender.cellIndex(e.container) : -1;
    var codeColumn = 'code';
    var genNewCode = function() {
        var codeGenArea = e.sender.options.CodeGenArea || defaultCodeGenArea;
        var tableName = e.sender.dataSource.transport.options.read.url.split('/')[2];
        if (!tableName || (tableName.substring(0, 4) !== codeGenArea + '_' && tableName.substring(0, 4) !== 'DMN_')) 
            return;

        var exceptCodes = [];
        e.sender.dataSource.data().forEach(function(r) { if (r.isNew && r.isNew()) exceptCodes.push(r[codeColumn]); });

        var hasParent = e.model.refParent !== undefined;
        $.ajax('/' + codeGenArea +'/Code',
            {
                type: "POST",
                cache: false,
                data: {
                    exceptCodes: JSON.stringify(exceptCodes),
                    tableName: tableName,
                    hasParent: hasParent,
                    refParent: e.model.refParent || ''
                },
                success: function(result) {
                    if (result && result.code) {
                        if (e.sender.options.editable.mode === 'incell') {
                            if (e.sender.cellIndex(editable.element) === e.sender.cellIndex(e.container))
                                e.sender.editCell(e.container.next());
                            setTimeout(function() { e.model.set(codeColumn, result.code); }, 100);
                        } else {
                            setTimeout(function() {
                                    editable.element.find('#' + codeColumn).val(result.code);
                                    e.model.set(codeColumn, result.code);
                                },
                                100);
                        }
                    }
                }
            });
    };

    if (isNew && !isDirty && cellIndex > -1 && e.sender.columns.length > cellIndex && e.sender.columns[cellIndex].field && e.sender.columns[cellIndex].field.toLowerCase() === 'code') {
        codeColumn = e.sender.columns[cellIndex].field;
        genNewCode();
    }
    else if (isNew && !isDirty && (e.model.code !== undefined || e.model.Code !== undefined) && e.sender.options.editable && e.sender.options.editable.mode === 'popup') {
        if (e.model.code === undefined && e.model.Code !== undefined)
            codeColumn = 'Code';

        genNewCode();
        if (e.model.refParent !== undefined)
            e.model.bind('change', function(ce) {
                if (ce.field === 'refParent') genNewCode();
            });
    }

    if (cellIndex > -1 && e.sender.columns.length > cellIndex && e.model[codeColumn] !== undefined && e.sender.columns && e.sender.columns[cellIndex].field === 'refParent') {
        setTimeout(function() {
                e.model.one('change', genNewCode);
            },
            200);
    }

    var windowMessage = null;
    if (isNew)
        windowMessage = e.sender.options.messages ? e.sender.options.messages.commands.create || 'Добавить' : 'Добавить';
    else if (editable.element.closest('.k-window').find('> > .k-window-title').text() === "Edit")
        windowMessage = e.sender.options.messages ? e.sender.options.messages.commands.edit || 'Изменить' : 'Изменить';
    Nat.F.SetTitleForGridEditableWindow(editable, windowMessage);

    Nat.F.AddRequiredMark(editable.element);

    if (!isDirty && !e.sender.element.attr('notDisableUpdate') && e.sender.options.editable && e.sender.options.editable.mode === 'popup') {
        var button = editable.element.find('.k-button[data-command="update"]');
        if (button.is(':enabled')) {
            button.attr('disabled', true);
            var func = function(ce) {
                if (!e.sender.isInitializationEditModel) {
                    button.attr('disabled', false);
                    e.model.unbind('change', func);
                }
            };
            e.model.bind('change', func);
        }
    }

    Nat.F.AddOpenLogButton(e.sender);

    /*
     if (!e.model.CanUpdate)
        e.sender.closeCell();
    */
    var w = editable.element.data('kendoWindow');
    if (w) {
        w.bind('close',
            function() {
                setTimeout(function () {
                        if (e.sender.options.refreshOnClose)
                            e.sender.refresh();
                        else
                            e.sender.trigger('dataBound');
                    },
                    10);
            });
    }
};


var gridPopupReadonlyMode = function(e) {
    e.preventDefault();
    this._editInReadonly = true;
    this.editRow($(e.target).closest('tr'));
    gridPopupReadonlyModeEval.call(this);
    this._editInReadonly = false;
};

var gridPopupReadonlyModeEval = function() {
    var grid = this;
    var editable = this.editable || (this.editor ? this.editor.editable : null);
    if (!editable)
        return;

    editable.options.readOnly = true;
    Nat.F.SetReadOnlyFields(editable.element);
    Nat.F.SetTitleForGridEditableWindow(editable, grid.options.messages.commands.read);
    editable.element.find('.k-grid-update').remove();
    grid.trigger('popupInReadonly');
};

var FilterUIGridForeignKeyLoading = function (element, actionName, controllerName, dataValueField, dataTextField, optionLabel) {
    var selection = {};
    var dropDown = element.kendoDropDownList({
        filter: "contains",
        dataTextField: dataTextField,
        dataValueField: dataValueField,
        optionLabel: optionLabel,
        height: 380,
        autoWidth: true,
        dataSource: {
            type: "aspnetmvc-ajax",
            serverFiltering: true,
            pageSize: 25,
            page: 0,
            serverPaging: true,
            error: errorHandler,
            transport: {
                read: {
                    url: "/" + controllerName + "/" + actionName
                }
            },
            schema: {
                data: "Data",
                total: "Total",
                errors: "Errors"
            },
            change: function(e) {
                if (selection.dataItem && !e.sender.get(selection.dataItem.id))
                    e.sender.insert(selection.dataItem, 0);
            }
        },
        select: function(e) {
            selection.dataItem = e.dataItem;
        },
        open: function() {
            setTimeout(function() { dropDown.listView.element.css('white-space', 'normal'); });
        }
    }).data('kendoDropDownList');
    dropDown.listView.element.css('max-width', '550px'); //.css('white-space', 'normal');
};

var FilterUIGridForeignKeyData = function (element, data, dataValueField, dataTextField, optionLabel) {
    element.kendoDropDownList({
        filter: "contains",
        dataTextField: dataTextField,
        dataValueField: dataValueField,
        optionLabel: optionLabel,
        dataSource: {
            data: data
        }
    });
};

function increment(a) {
    return ++a;
}

function isLower(i, length) {
    return i < length;
}

var AddTooltipAllowSaveNoHistory = function(element, show) {
    var count = parseInt($.cookie('tooltipAllowSaveNoHistory') || "0");
    var tooltip = element.find('.k-grid-AllowSaveNoHistory')
        .kendoTooltip({
            width: 450,
            position: "bottom",
            autoHide: count > 50,
            hide: function() {
                if ($(event.target).hasClass('k-i-close')) {
                    var value = parseInt($.cookie('tooltipAllowSaveNoHistory') || "0");
                    value += 1;
                    $.cookie("tooltipAllowSaveNoHistory", value, { path: "/", expires: 30 });
                }
            }
        }).data("kendoTooltip");
    if (tooltip && show && count <= 15) tooltip.show();
};

var DicUpdateReferencesButtonClick = function(link, tableType, area) {
    var grid = $(link).closest('.k-grid').data('kendoGrid');
    var dataItem = grid.dataItem(grid.select());
    if (!dataItem) {
        kendo.alert($(link).attr('SSelectRecord'));
        return;
    }

    $.ajax('/DIC/UpdateReferences/DataExists',
        {
            cache: false,
            data: {
                id: dataItem.id,
                tableType: tableType
            },
            success: function(result) {
                if (!result.exists) {
                    kendo.alert($(link).attr('NotExistsDataMessage'));
                    return;
                }

                var w = $("<div class='k-popup-edit-form' />").appendTo(document.body).kendoWindow({
                    draggable: true,
                    title: $(link).attr('title'),
                    scrollable: false,
                    modal: true,
                    visible: false,
                    actions: ["Close"],
                    close: function() {
                        this.destroy();
                    }
                }).data('kendoWindow');
                w.content(
                    "<div class='k-edit-form-container'>" +
                    "<div class='editor-label'><label for='OldDicValue' /></div>" +
                    "<div class='editor-field'><input id='OldDicValue' name='OldDicValue' style='width:100%' disabled /></div>" +
                    "<div class='editor-label'><label class='requiredField' for='NewDicValue' /></div>" +
                    "<div class='editor-field'><input id='NewDicValue' name='NewDicValue' style='width:100%' /></div>" +
                    "<div class='k-edit-buttons k-state-default'><a class='k-button k-button-icontext k-primary' href='#' role='button' /><a class='k-button k-button-icontext' href='#' role='button' /></div>" +
                    "</div>");
                $(w.element).find('label[for="OldDicValue"]').text($(link).attr('SOldValue'));
                $(w.element).find('#OldDicValue').val(dataItem.nameKz + '/' + dataItem.nameRu);
                $(w.element).find('label[for="NewDicValue"]').text($(link).attr('SJoinDescription'));
                var selectedDataItem = null;
                var combobox = $(w.element).find('#NewDicValue')
                    .attr('data-val-required', $(link).attr('SRequiredMsg'))
                    .attr('data-idcheck-msg', $(link).attr('SSelectedSame'))
                    .kendoComboBox({
                        placeholder: $(link).attr('SJoinWith'),
                        filter: tableType === 'DIC_AUTHORITY' ? "contains" : "containsany",
                        minLength: 1,
                        dataTextField: "name",
                        dataValueField: "id",
                        autoBind: false,
                        dataSource: {
                            type: "aspnetmvc-ajax",
                            serverFiltering: true,
                            serverPaging: true,
                            pageSize: 25,
                            transport: {
                                read: {
                                    url: "/" + area + "/" + tableType + "/GetDataSelection"
                                }
                            },
                            schema: {
                                data: 'Data',
                                total: 'Total'
                            },
                            requestEnd: function(e) {
                                if (selectedDataItem) {
                                    for (var i = 0; i < e.response.Data.length; i++) {
                                        if (e.response.Data[i].id === selectedDataItem.id)
                                            return;
                                    }

                                    e.response.Data.push(selectedDataItem.toJSON());
                                }
                            }
                        },
                        select: function(e) {
                            selectedDataItem = e.dataItem;
                        }
                    }).data('kendoComboBox');
                $(w.element).find('.m-linkSelectForCombobox').on('click',
                    function(e) {
                        if (combobox.text()) {
                            combobox.search('');
                            setTimeout(function() { combobox.close(); });
                            setTimeout(function() { combobox.close(); }, 200);
                        }
                        Nat.F.ImportBySelectionDialog(e,
                            {
                                url: "/" + area + "/" + tableType + "/Selection",
                                title: $(link).attr('title'),
                                multiSelect: false,
                                done: function(res) {
                                    var selected = res.selection[0];
                                    selectedDataItem = combobox.dataSource.get(selected.id) ||
                                        combobox.dataSource.add({ id: selected.id, name: selected.name });
                                    combobox.value(selectedDataItem.id);
                                }
                            });
                    });
                $(w.element).find('.k-edit-buttons .k-button').first()
                    .html('<span class="k-icon k-i-check" />' + $(link).attr('SJoin')).click(function() {
                        var valid = $(w.element).data("kendoValidator").validate();
                        if (!valid) return;
                        DicUpdateReferencesUpdateData(dataItem.id, $(w.element).find('#NewDicValue').val(), tableType, $(link).attr('SAddJob'));
                        w.close();
                    });
                $(w.element).find('.k-edit-buttons .k-button').last()
                    .html('<span class="k-icon k-i-cancel" />' + $(link).attr('SCancel')).click(
                        function() {
                            w.close();
                        });
                $(w.element).kendoValidator({
                    rules: {
                        idcheck: function(input) {
                            if(input.is("[data-idcheck-msg]"))
                                return dataItem.id != $(w.element).find('#NewDicValue').val();
                            return true;
                        }
                    }
                });
                w.center().open();
            },
            error: errorHandler
        });
};

var DicUpdateReferencesUpdateData = function(idFrom, idTo, tableType, message) {

    $.ajax('/DIC/UpdateReferences/UpdateData',
        {
            type: 'POST',
            cache: false,
            data: {
                idFrom: idFrom,
                idTo: idTo,
                tableType: tableType
            },
            success: function(result) {
                kendo.alert(kendo.format(message, result.jobID));
            },
            error: errorHandler
        });
};

var myDebuggerFunc = function(e) {
    debugger;
};

var PersistExpandSession = function(treeList, name, expandOnLoad, defaultExpand) {
    
    var sessionStorage = null;
    // Does this browser support sessionStorage?
    try {
        sessionStorage = window.sessionStorage;
    } catch (e) {
        sessionStorage = {};
    }

    var expanded = JSON.parse(sessionStorage[name] || '{}');
    if (defaultExpand && defaultExpand.length) {
        defaultExpand.forEach(function(val) {
            expanded[val] = true;
        });
        sessionStorage[name] = JSON.stringify(expanded);
    }
    treeList.bind('collapse', function(e) {
        if (expanded[e.model.id])
            expanded[e.model.id] = undefined;
        sessionStorage[name] = JSON.stringify(expanded);
    });
    treeList.bind('expand', function(e) {
        expanded[e.model.id] = true;
        sessionStorage[name] = JSON.stringify(expanded);
    });
    treeList.dataSource.bind('requestEnd',
        function(e) {
            if (e.type === 'read') {
                if (!expandOnLoad || !e.response)
                    // при использовании подгрузки данных, нужно вызывать expand у дерева, т.к. требуется загрузка данных
                    setTimeout(function() {
                        treeList.dataSource.data().forEach(function(row) {
                            if (expanded[row.id]) 
                                treeList.expand(row);
                        });
                    });
                else
                    // если загружаются сразу все данные, то можно указать состояние развернутости изначально (тогда без мигания)
                    e.response.Data.forEach(function(row) {
                        if (expanded[row.id]) 
                            row.expanded = true;
                    });
            }
        });
};

var buttonImageTextToImage = function(button, setSize) {
    if (!button.length)
        return;
    if (setSize) {
        button.height(18);
        button.width(18);
    }
    button.find('.k-icon').css('margin-right', '0');
    button.find('.fas').css('padding-right', '0');
    button.attr('title', button.text());
    button.html(button.html().replace(button.text(), ''));
};

var getDefaultRowName = function(dataItem, grid) {
    if (grid && grid.element.attr('selectionNameColumn'))
        return dataItem[grid.element.attr('selectionNameColumn')] || '-';
    
    if (grid && grid.element.attr('selectionNameTmpl'))
        return kendo.template(grid.element.attr('selectionNameTmpl'))(dataItem) || '-';

    return dataItem.name ||
        dataItem.Name ||
        (window.isKz
            ? dataItem.nameKz || dataItem.NameKz || dataItem.shortNameKz || dataItem.ShortNameKz
            : dataItem.nameRu || dataItem.NameRu || dataItem.shortNameRu || dataItem.ShortNameRu) ||
        dataItem.shortName ||
        dataItem.ShortName ||
        dataItem.ccode ||
        dataItem.code ||
        dataItem.Code ||
        '-';
};

var getDefaultRowCode = function(dataItem) {
    return dataItem.ccode ||
        dataItem.code ||
        dataItem.Code ||
        '-';
};

var exportGridWithTemplatesContent = function (e, options){
    var sheet = e.workbook.sheets[0];
    var columnTemplates = [];
    var dataItem;
    // Create element to generate templates in.
    var elem = document.createElement('div');
    var cellIndex = -1;
    
    var processColumns = function(columns) {
        // Create a collection of the column templates, together with the current column index
        for (var i = 0; i < columns.length; i++) {
            var column = columns[i];
            if (column.hidden || column.command || column.selectable)
                continue;

            if (column.columns) {
                processColumns(column.columns);
                continue;
            }

            cellIndex++;

            // Check exists options and field, skip without settings
            if (options && !options[column.field])
                continue;

            if (!options || options[column.field] === true) {
                // Use column template
                if (column.template)
                    columnTemplates.push({
                        cellIndex: cellIndex, 
                        template: kendo.template(column.template),
                        type: column.format === "{0:N2}" || column.format === "{0:n2}" ? 'template-number' : null,
                        format: column.format === "{0:N2}" || column.format === "{0:n2}" ? '### ### ### ### ##0.00' : null,
                        field: column.field
                    });
                // Use column format
                else if (column.format) {
                    var getTemplate = function(format, field) {
                        return function(data) {
                            return !data[field] ? '' : kendo.format(format, data[field]);
                        };
                    };
                    columnTemplates.push({
                        cellIndex: cellIndex,
                        template: getTemplate(column.format, column.field),
                        type: column.format === "{0:N2}" || column.format === "{0:n2}" ? 'number' : null,
                        format: column.format === "{0:N2}" || column.format === "{0:n2}" ? '### ### ### ### ##0.00' : null,
                        field: column.field
                    });
                }
            }
            // Use custom function from options
            else
                columnTemplates.push({ cellIndex: cellIndex, template: options[column.field] });
        }
    }

    processColumns(e.sender.columns);

    var rowIndex = 1;
    var groupHeaderCellCounts = 0;

    var applyTemplate = function(row, dataItem, indentIndex) {
        // Traverse the column templates and apply them for each row at the stored column position.
        for (var columnIndex = 0; columnIndex < columnTemplates.length; columnIndex++) {
            var columnTemplate = columnTemplates[columnIndex];
            
            // Generate the template content for the current cell.
            elem.innerHTML = columnTemplate.template(dataItem);
            if (row.cells[columnTemplate.cellIndex + indentIndex] != undefined)
            // Output the text content of the templated cell into the exported cell.
            {
                if (columnTemplate.type === 'number') {
                    row.cells[columnTemplate.cellIndex + indentIndex].value = dataItem[columnTemplate.field];
                    row.cells[columnTemplate.cellIndex + indentIndex].format = columnTemplate.format.replace(/ /g, ',');
                    row.cells[columnTemplate.cellIndex + indentIndex].hAlign = "right";
                } else if (columnTemplate.type === 'template-number') {
                    // два разделителя #A0 и #20
                    let value = parseFloat((elem.textContent || elem.innerText || "").replace(/ | /g, '').replace(',', '.'));
                    row.cells[columnTemplate.cellIndex + indentIndex].value = isNaN(value) ? elem.textContent || elem.innerText || "" : value;
                    row.cells[columnTemplate.cellIndex + indentIndex].format = columnTemplate.format.replace(/ /g, ',');
                    row.cells[columnTemplate.cellIndex + indentIndex].hAlign = "right";
                } else {
                    row.cells[columnTemplate.cellIndex + indentIndex].value = elem.textContent || elem.innerText || "";
                    row.cells[columnTemplate.cellIndex + indentIndex].wrap = true;
                }
            }
        }
    };

    var processRows = function(data) {
        // Traverse all exported rows.
        var dataIndex = 0;
        while (rowIndex < sheet.rows.length) {
            var row = sheet.rows[rowIndex];
            rowIndex++;

            // If exists groups, then add indent
            var indentIndex = groupHeaderCellCounts;
            // For TreeList skip hierarchy cells
            if (kendo.ui.TreeList.prototype.isPrototypeOf(e.sender)) {
                for (var j = 0; j < row.cells.length; j++) {
                    if (!row.cells[j].colSpan)
                        indentIndex ++;
                    else
                        break;
                }
            }

            if (row.type === 'data') {
                // Get the data item corresponding to the current row.
                dataItem = data[dataIndex];
                if (!dataItem) {
                    rowIndex--;
                    break;
                }
                dataIndex++;
            } else if (row.type === 'group-header') {
                // If exists groups, then add indent
                groupHeaderCellCounts = row.cells.length;
                dataItem = data[dataIndex];
                
                if (!dataItem) {
                    rowIndex--;
                    break;
                }

                processRows(dataItem.items);
                dataIndex++;
                continue;
            } else {
                continue;
            }

            applyTemplate(row, dataItem, indentIndex);
        }
    };

    processRows(e.data);
};

var GetDataForSelectionWithFnName = function(e, id, fnName) {
    var readParams = window[fnName]
        ? window[fnName].call(this, e)
        : (fnName[fnName.length - 1] === ')' ? eval(fnName) : eval(fnName + '(e)'));
    readParams.showHistory = $('#' + (id || 'grid')).attr('showHistory') || false;
    return readParams;
};

var GetDataForSelectionWithRSH = function(e, id) {
    var readParams = GetDataForSelection();
    readParams.showHistory = $('#' + (id || 'grid')).attr('showHistory') || false;
    return readParams;
};

var GetDataForSelection = function () {

    var params = location.search.substring(1).split('&');
    var readParams = {};
    params.forEach(function (param) {
        var s = param.split('=');
        readParams[s[0]] = decodeURIComponent(s[1]);
    });
    
    return readParams;
};

function OnGridDefault_ColumnHide(e) {
    e.sender.resize(true);
}
function OnGridDefault_ColumnShow(e) {
    e.sender.resize(true);
}

function SessionExpiredAlert(location) {
    if (window._SessionExpiredAlertShow) 
        return;

    window._SessionExpiredAlertShow = true;
    kendo.alert('Session expired/Сессия истекла')
        .bind('close',
            function() {
                window._SessionExpiredAlertShow = false;
                if (location) {
                    $.ajax(location + '&DeferredNoLayout=true').done(function(result) {
                        var d = $('<div/>');
                        $(document.body).append(d);
                        d.html(result);
                    });
                }
            });
};

function HasntPermissionsAlert() {
    kendo.alert('Not enough rights, contact your administrator/Не достаточно прав, обратитесь к администратору');
};

(function () {
    $(document).ajaxComplete(function (e, xhr, options) {
        if (xhr.status === 200 || xhr.status === 401) {
            var respondedJson = JSON.parse(xhr.getResponseHeader('x-responded-json') || '{}');
            if (respondedJson.status === 401 && respondedJson.headers && respondedJson.headers.location) {
                if (respondedJson.headers.authorized)
                    HasntPermissionsAlert();
                else
                    SessionExpiredAlert(respondedJson.headers.location);
            }
            else if (respondedJson.status === 401 && respondedJson.headers && respondedJson.headers.goHome) {
                window.location = '/';
            }
            
            if (document.cookie && document.cookie.indexOf('SMSESSION=LOGGEDOFF') > -1) {
                window.location = '/';
            }
        }
    });
})();

// Extend Number object with methods to convert between degrees & radians
Number.prototype.toRadians = function () { return this * Math.PI / 180; };
Number.prototype.toDegrees = function () { return this * 180 / Math.PI; };