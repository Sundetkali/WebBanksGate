(function($, kendo) {
    var patternMatcher = function(value, pattern) {
            if (typeof pattern === 'string') {
                pattern = new RegExp('^(?:' + pattern + ')$');
            }
            return pattern.test(value);
        },
        matcher = function(input, selector, pattern) {
            var value = input.val();
            if (input.filter(selector).length && value !== '') {
                return patternMatcher(value, pattern);
            }
            return true;
        },
        emailCheckDotRegExp = "[a-zA-Z0-9.!#$%&'*+\\/=?^_`{|}~-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z0-9]+";
    $.extend(true,
        kendo.ui.validator,
        {
            rules: {
                remote: function(input) {
                    if (input.val() == "" || !input.attr("data-val-remote-url")) {
                        return true;
                    }

                    if (input.attr("data-val-remote-recieved")) {
                        input.attr("data-val-remote-recieved", "");
                        return !(input.attr("data-val-remote"));
                    }
                    
                    var validator = this;
                    var row = validator.element.data('kendoEditable').options.model;
                    var url = input.attr("data-val-remote-url");
                    var postData = {};
                    var addFields = input.attr("data-val-remote-additionalfields").replace(/\*./g, "").split(",");
                    $.each(addFields,
                        function(index, val) {
                            if (index === 0)
                                postData[val] = validator.element.find("input[name='" + val + "']").val();
                            else
                                postData[val] = row[val];
                        });

                    var currentInput = input;
                    input.attr("data-val-remote-requested", true);
                    $.ajax({
                        url: url,
                        type: "POST",
                        data: JSON.stringify(postData),
                        dataType: "json",
                        traditional: true,
                        contentType: "application/json; charset=utf-8",
                        success: function(data) {
                            if (data == true) {
                                input.attr("data-val-remote", "");
                            } else {
                                input.attr("data-val-remote", data);
                            }
                            input.attr("data-val-remote-recieved", true);
                            validator.validateInput(currentInput);

                        },
                        error: function() {
                            input.attr("data-val-remote-recieved", true);
                            validator.validateInput(currentInput);
                        }
                    });
                    return true;
                },
                datecompare: function(input) {
                    if (input.is("[data-val-datecompare]") && input.val()) {                                    
                        var date = kendo.parseDate(input.val()),
                            otherDate = kendo.parseDate(JSON.parse(input.attr("data-val-datecompare-comparevalue") || null) || $("[name='" + input.attr("data-val-datecompare-compareproperty") + "']").val());
                        if (!otherDate)
                            return true;

                        switch (input.attr("data-val-datecompare")) {
                        case "greaterthan":
                            return otherDate.getTime() < date.getTime();
                        case "greaterthanequalto":
                            return otherDate.getTime() <= date.getTime();
                        case "lessthan":
                            return otherDate.getTime() > date.getTime();
                        case "lessthanequalto":
                            return otherDate.getTime() >= date.getTime();
                        case "equal":
                            return otherDate.getTime() === date.getTime();
                        case "notequal":
                            return otherDate.getTime() !== date.getTime();
                        }

                        return false;
                    }

                    return true;
                },
                compare: function(input) {
                    if (input.is("[data-val-compare]") && input.val()) {
                        var value = parseFloat(input.val().replace(',', '.'));
                        var otherValue = input.attr("data-val-compare-comparevalue") 
                            ? parseFloat(input.attr("data-val-compare-comparevalue").replace(',', '.')) 
                            : (parseFloat($("[name='" + input.attr("data-val-compare-compareproperty") + "']").val() || '').replace(',', '.'));
                        
                        if (isNaN(otherValue))
                            return true;

                        switch (input.attr("data-val-compare")) {
                        case "greaterthan":
                            return otherValue < value;
                        case "greaterthanequalto":
                            return otherValue <= value;
                        case "lessthan":
                            return otherValue > value;
                        case "lessthanequalto":
                            return otherValue >= value;
                        case "equal":
                            return otherValue === value;
                        case "notequal":
                            return otherValue !== value;
                        }

                        return false;
                    }

                    return true;
                },
                requiredisvisible: function(input) {
                    if (input.is("[data-val-requiredisvisible]")) {
                        var val;
                        if (input.attr('data-role') === 'numerictextbox') {
                            if (input.closest('.k-widget').is(':visible')) {
                                val = input.val();
                                return !(val === null || val === '' || val === undefined || val.length === 0);
                            }
                        }
                        else if (input.hasClass('k-input') || input.hasClass('k-textbox')) {
                            if (input.is(':visible')) {
                                val = input.val();
                                return !(val === null || val === '' || val === undefined || val.length === 0);
                            }
                        }
                        else if (input.closest('.k-widget').is(':visible')) {
                            val = input.val();
                            return !(val === null || val === '' || val === undefined || val.length === 0);
                        }
                    }

                    return true;
                },
                natLookupWindow: function (input) {
                    var value = true;
                    if (input.is("[data-val-lookupWindow]"))
                        return false;
                    return value;
                },
                mvcdate: function(input) {
                    if (input.is("[data-val-date]"))
                        return input.val() === '' || kendo.parseDate(input.val(), input.attr(kendo.attr('format'))) !== null;
                    return true;
                },
                emailcheckdot: function(input) {
                    return matcher(input, '[type=email],[' + kendo.attr('type') + '=email]', emailCheckDotRegExp);
                }
            },
            messages: {
                remote: function(input) {
                    return input.attr("data-val-remote");
                },
                datecompare: function(input) {
                    return input.attr('data-val-datecompare-msg');
                },
                compare: function(input) {
                    return input.attr('data-val-compare-msg');
                },
                natLookupWindow: function(input) {
                    return ' ';
                },
                requiredisvisible: function(input) {
                    return input.attr('data-val-requiredisvisible');
                },
                emailcheckdot: function(input) {
                    return input.data('email-msg') || kendo.format(kendo.ui.Validator.prototype.options.messages.email, input.attr('name'));
                }
            }
        });

    kendo.ui.Calendar.prototype.selectWithoutCtrlKey = function() {
        var me = this;

        this.element.on("mousedown",
            "td",
            function(e) {

                // get item if the user clicked on an item template
                var clickedItem = $(e.target).closest("td[role='gridcell']");

                // if click to month or year
                if (!clickedItem.children("a").attr('title'))
                    return;

                // prevent click event for item elements
                clickedItem.one("click",
                    function(e) {
                        e.stopPropagation();
                        e.preventDefault();
                    });

                if (clickedItem.length > 0) {
                    var clickedDate = kendo.calendar.toDateObject(clickedItem.children("a"));
                    var selectedDates = me.selectDates();

                    if (clickedItem.hasClass("k-state-selected")) {
                        // if date is already selected - remove it from collection
                        selectedDates = $.grep(selectedDates,
                            function(item, index) {
                                return clickedDate.getTime() !== item.getTime();
                            });
                    } else {
                        selectedDates.push(clickedDate);
                    }


                    me.selectDates(selectedDates);
                    me.trigger('change');
                }
            });
    };

    kendo.data.binders.recurring = kendo.data.Binder.extend({
        refresh: function() {
            var model = this.bindings["recurring"].get();
            var widget = $(this.element).data('natRecurring');
            widget.model(model);
        },
        destroy: function () {
            var widget = $(this.element).data('natRecurring');
            widget.destroy();
        }
    });
    kendo.data.binders.href = kendo.data.Binder.extend({
        refresh: function() {
            var me = this,
                value = me.bindings["href"].get(); //get the value from the View-Model

            var format = $(me.element).attr('data-href');
            //update the HTML input element
            if (format)
                $(me.element).attr('href', kendo.format(format, value));
            else
                $(me.element).attr('href', value);
        }
    });
    kendo.data.binders.widget.selectDates = kendo.data.Binder.extend({
        init: function(widget, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, widget.element[0], bindings, options);

            var that = this;
            //listen for the change event of the element
            widget.bind('change',function() {
                that.change(); //call the change function
            });
        },
        refresh: function() {
            var value = this.bindings["selectDates"].get();
            var calendar = $(this.element).data('kendoCalendar');
            calendar.selectDates(value || []);
        },
        change: function() {
            var calendar = $(this.element).data('kendoCalendar');
            var value = calendar.selectDates();
            this.bindings["selectDates"].set(value); //update the View-Model
        }
    });

    kendo.data.binders.ucFilterValue = kendo.data.Binder.extend({
        init: function (element, bindings, options) {
            //call the base constructor
            kendo.data.Binder.fn.init.call(this, element, bindings, options);

            var that = this;
            //listen for the change event of the element
            $(that.element).on("change", function () {
                that.change(); //call the change function
            });
        },
        refresh: function() {
            var value = this.bindings["ucFilterValue"].get();
            var e = $(this.element);
            var filters = e.data('natucFilters');
            if (e.attr('data-ucTable'))
                filters.tableName(value || []);
            else
                filters.value(value || []);
        },
        change: function() {
            var e = $(this.element);
            var filters = e.data('natucFilters');
            var value = e.attr('data-ucTable') ? filters.tableName() : filters.value();
            this.bindings["ucFilterValue"].set(value); //update the View-Model
        }
    });

    kendo.data.binders.gridContent = kendo.data.Binder.extend({
        refresh: function() {
            var model = this.bindings["gridContent"].get();
            var div = $(this.element);
            var html = eval(div.attr('gridContent'));
            div.html(html);
            /*
            var value = this.bindings["selectDates"].get();
            var calendar = $(this.element).data('kendoCalendar');
            calendar.selectDates(value || []);
            */
        },
        change: function() {
            debugger;
            /*var calendar = $(this.element).data('kendoCalendar');
            var value = calendar.selectDates();
            this.bindings["selectDates"].set(value); //update the View-Model
            */
        },
        destroy: function () {
        }
    }); 

    // needed for array data-bind
    var currentSaveRow = kendo.ui.TreeList.prototype.saveRow;
    kendo.ui.TreeList.prototype.saveRow = function() {
        currentSaveRow.call(this);
        var validator = $(event.target).closest('.k-popup-edit-form').data('kendoValidator');
        if (validator && validator.errors().length)
            return;

        var isUpdate = $(event.target).attr('data-command') === 'update' &&
            $(event.target).parent().parent().hasClass('k-edit-form-container') &&
            !this.dataSource.transport.options;
        
        // for treeList in modal window, manualy close editor on update button click (else new record deleted)
        if (isUpdate) {
            var model;
            var editor = this.editor;
            if (editor) {
                model = editor.model;
                this._destroyEditor();
                model._edit = false;
            }
        }
    };
    var currentCommandClick = kendo.ui.TreeList.prototype._commandClick;
    // needed for array data-bind
    //var tempNewID = -1;
    kendo.ui.TreeList.prototype._commandClick = function(e) {
        var command = $(e.target).attr('data-command');
        // for new record disable add child
        if (command === "createchild") {
            var treeList = $(e.target).closest('.k-treelist').data('kendoTreeList');
            var row = $(e.target).closest('tr');
            var dataItem = treeList.dataItem(row);
            if (dataItem.isNew()) {
                e.preventDefault();
                e.stopPropagation();
                /*if (dataItem.id === 0)
                    dataItem.set('id', tempNewID--);*/
                return;
            }
        }

        if (command === "refresh") {
            var treeList = $(e.target).closest('.k-treelist').data('kendoTreeList');
            treeList.dataSource.read();
            return;
        }

        if (command === "destroy") {
            var me = this;
            var div = $("<div />");
            this.element.append(div);
            div.kendoDialog({
                title: this.options.messages.destroyConfirm.title,
                modal: true,
                closable: true,
                content: this.options.messages.destroyConfirm.confirmation,
                actions: [
                    {
                        text: this.options.messages.destroyConfirm.confirmDelete,
                        primary: true,
                        action: function() { currentCommandClick.call(me, e); }
                    },
                    { text: this.options.messages.destroyConfirm.cancelDelete }
                ],
                close: function() {
                    div.data('kendoDialog').destroy();
                    div.remove();
                }
            });
            div.focus();
            div.on('keydown',
                function(divE) {
                    if (divE.keyCode === 13) {
                        currentCommandClick.call(me, e);
                        div.data('kendoDialog').close();
                    }
                });

            e.preventDefault();
            e.stopPropagation();
            return;
        }

        var isUpdate = command === "update";
        currentCommandClick.call(this, e);
        /*var v = true;
        debugger;
        //e.preventDefault();
        if (v)*/
        // for treeList in modal window, stop close modal window
        e.stopPropagation();
        // for treeList in modal window, manualy close editor on update button click (else new record deleted)
        if (isUpdate) {
            var model;
            var editor = this.editor;
            if (editor) {
                model = editor.model;
                this._destroyEditor();
                model._edit = false;
            }
        }
    };

    var treeListButton = kendo.ui.TreeList.prototype._button;
    kendo.ui.TreeList.prototype._button = function(command, name, icon) {
        var b = treeListButton.call(this, command, name, icon);
        if (command.title && command.title !== ' ')
            b.attr.title = command.title;
        return b;
    };

    var ddl_focusoutHandler = kendo.ui.DropDownList.prototype._focusoutHandler;
    kendo.ui.DropDownList.prototype._focusoutHandler = function (e) {
        if (e.relatedTarget && $(e.relatedTarget).closest('.m-linkSelectForCombobox').length) {
            var editable = this.element.closest('.k-editable');
            if (editable.length) {
                var grid = editable.data('kendoGrid') || editable.data('kendoTreeList');
                if (grid && grid.options.editable && grid.options.editable.mode && grid.options.editable.mode.toLowerCase() === 'incell') {
                    this._prevent = true;
                    this.element.attr("data-val-lookupWindow", "true");
                }
            }
        }
        ddl_focusoutHandler.call(this, e);
    };

    var lvRemove = kendo.ui.ListView.prototype.remove;
    kendo.ui.ListView.prototype.remove = function (item) {
        var me = this;
        kendo.confirm(kendo.ui.Grid.prototype.options.messages.editable.confirmation)
            .done(function () {
                lvRemove.call(me, item);
            });
    };
    kendo.ui.ListView.prototype._progress = function(toggle) {
        kendo.ui.progress(this.element, toggle);
    };
    kendo.mobile.ui.Scroller.fn.options.avoidScrolling = function (e) {
        return $(e.event.target).is(".k-marker");
    };

    var highlightSaveChanges = function () {
        var me = this;
        var updateState = function(e) {
            if (!me.element || !me.dataSource)
                return;
            if (me.dataSource.hasChanges())
                me.element.find('.k-grid-toolbar .k-grid-save-changes').addClass('k-state-selected');
            else
                me.element.find('.k-grid-toolbar .k-grid-save-changes').removeClass('k-state-selected');
        };
        this.dataSource.bind('change', updateState);
        this.dataSource.bind('read', updateState);
        this.dataSource.bind('sync', updateState);
    };

    kendo.ui.Grid.prototype.highlightSaveChanges = highlightSaveChanges;
    //init: function (element, options, events) {
    var tempInitGridFn = kendo.ui.Grid.prototype._dataSource;
    kendo.ui.Grid.prototype._dataSource = function () {
        tempInitGridFn.call(this);
        if (this.element.find('.k-grid-toolbar .k-grid-save-changes').length)
            this.highlightSaveChanges();
    };

    var gridSaveAsExcel = kendo.ui.Grid.prototype.saveAsExcel;
    kendo.ui.Grid.prototype.saveAsExcel = function() {
        let self = this;
        let callExport = function() {
            kendo.ui.progress(self.element, true);
            self.one('excelExport', function() { kendo.ui.progress(self.element, false); });
            gridSaveAsExcel.call(self);
        };
        if (window.CoreLocalization.ConfirmBigExcelExport && this.options.excel.allPages) {
            var total = this.dataSource.total();
            if (total > 2500)
                kendo.confirm(window.CoreLocalization.ConfirmBigExcelExport).done(callExport);
            else
                callExport();
        } else {
            callExport();
        }
    };

    kendo.ui.TreeList.prototype.highlightSaveChanges = highlightSaveChanges;
    //init: function (element, options, events) {
    var tempInitTreeListFn = kendo.ui.TreeList.prototype._pageable;
    kendo.ui.TreeList.prototype._pageable = function () {
        tempInitTreeListFn.call(this);
        if (this.element.find('.k-grid-toolbar .k-grid-save-changes').length)
            this.highlightSaveChanges();
    };

    var selectDependencyGanttTimelineFn = kendo.ui.GanttTimeline.prototype.selectDependency;
    kendo.ui.GanttTimeline.prototype.selectDependency = function(e) {
        var res = selectDependencyGanttTimelineFn.call(this, e);
        if (e) this.trigger('changeDependency', e);
        return res;
    };
    var clearSelectionGanttTimelineFn = kendo.ui.GanttTimeline.prototype.clearSelection;
    kendo.ui.GanttTimeline.prototype.clearSelection = function() {
        var hasSelection = this.selectDependency().length;
        clearSelectionGanttTimelineFn.call(this);
        if (hasSelection)
            this.trigger('changeDependency', {});
    };
    $.prototype.kendoMSplitButton = function(data) {
        if (this.length === 0)
            return this;

        var buttons = [];
        var buttonClasses = {};
        var buttonsFn = [];
        var preventDefault = function() {};
        if (data.buttons)
            data.buttons.forEach(function(item, i) {
                item.preventDefault = preventDefault;
                buttons.push({
                    text: item.text,
                    id: item.id,
                    spriteCssClass: 'k-icon ' + item.iconCss,
                    cssClass: 'm-button-' + i
                });
                if (item.id) buttonClasses[item.id] = 'm-button-' + i;
                buttonsFn.push(item.click);
            });
        var button = {
            _buttonsFn: buttonsFn,
            _buttons: buttons,
            _buttonClasses: buttonClasses,
            options: data,
            element: this,
            click: function(e) {
                if (this.options.click)
                    this.options.click.call(this, e);
            },
            open: function(e) {
                if (this.options.open)
                    this.options.open.call(this, e);
            },
            select: function(e) {
                e.preventDefault();

                for (var i = 0; i < e.item.classList.length; i++) {
                    if (e.item.classList[i] === 'm-button-main') {
                        this.click({ mainButton: true, preventDefault: preventDefault });
                    }
                    else if (e.item.classList[i].substr(0, 9) === 'm-button-') {
                        var index = parseInt(e.item.classList[i].substr(9));
                        var fn = this._buttonsFn[index];
                        if (fn) fn.call(this, this.options.buttons[index]);
                        this.click(this.options.buttons[index]);
                    }
                }
            }, 
            button: function(id) {
                if (this._buttonClasses[id])
                    return this.element.find('.' + this._buttonClasses[id]);

                return $('');
            }, 
            one: function(eventName, fn) {
                this.menu.one(eventName, fn);
            }, 
            bind: function(eventName, fn) {
                this.menu.bind(eventName, fn);
            }, 
            unbind: function(eventName, fn) {
                this.menu.unbind(eventName, fn);
            },
            destroy: function(e) {
                this.options = null;
                this.click = null;
                this.open = null;
                this.select = null;
                this.menu = null;
                this.element = null;
                this.buttons = null;
            }
        };
        var menu = {
            itemCssClass: 'k-button k-button-icontext',
            dataSource: [
                {
                    text: data.text,
                    cssClass: 'm-button-main',
                    spriteCssClass: 'k-icon ' + data.iconCss,
                    items: buttons.length ? buttons : undefined
                }
            ],
            select: $.proxy(button.select, button),
            open: $.proxy(button.open, button)
        };
        this.addClass('k-button').addClass('k-button-icontext').kendoMenu(menu);
        button.menu = this.data('kendoMenu');
        this.data('kendoMSplitButton', button);
        return this;
    };

    kendo.ui.PDFViewer.prototype.rotateFeature = function() {
        var me = this;
        var degree = 0;
        var button = $('<a href="#" class="k-flat k-button k-button-icon"><span class="k-icon k-i-rotate"></span></a>')
            .on('click',
                function() {
                    degree += 90;
                    if (degree === 360)
                        degree = 0;

                    for (var i = 0; i < me.pages.length; i++) {
                        me.pages[i].element.css('transform', 'rotate(' + degree + 'deg)');
                    }
                    return false;
                });
        button.insertBefore(this.toolbar.element.find('div[data-command="ZoomCommand"]'));
    };

    if (!kendo.ui.ButtonGroup.prototype.value) {
        kendo.ui.ButtonGroup.prototype.value = function(value) {
            if (value == undefined)
                return this.element.find('.k-state-active').attr('value');
            this.element.find('.k-button[value="' + value + '"]').click();
            return null;
        };
    }

    kendo.alertMaxSized = function(message) {
        kendo.alert('<div style="max-width: 900px;max-height:600px;white-space:pre-wrap;">' + message.replace(/\r\n/gi, '<br/>') + '</div>');
    }
})(jQuery, kendo);
