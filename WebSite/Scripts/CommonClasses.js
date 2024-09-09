if (!window.Nat) window.Nat = {};

Nat.Classes = {
    BasePostMethod: function(controller) {
        
        this.controller = controller;

        this.progress = function(value, skipGrid) {
            if (!this.element)
                return;

            if (this.dataSourceProgress !== value) {
                if (this.progressElement) {
                    kendo.ui.progress(this.progressElement, value);
                }
                else if (!this.grid || !this.grid.element) {
                    kendo.ui.progress(this.element, value);
                } else {
                    if (!skipGrid || !value)
                        kendo.ui.progress(this.grid.element, value);

                    if (this.grid.editor)
                        kendo.ui.progress(this.grid.editor.window.element, value);
                    else if (this.grid.editable && this.grid.editable.element)
                        kendo.ui.progress(this.grid.editable.element, value);
                }
            }

            this.dataSourceProgress = value;
        };

        this.post = function(action, data, done, reload) {
            if (reload === undefined)
                reload = true;

            var me = this;
            this.progress(true);

            return $.ajax({
                url: action[0] === '/' ? action : "/" + this.controller + "/" + action,
                type: "POST",
                xhrFields: {
                    withCredentials: true
                },
                data: data
            }).done(function(result) {
                if (result.error)
                    kendo.alert('<div style="max-width: 900px;max-height:600px;white-space:pre-wrap;">' + result.error + '</div>');
                if (reload) {
                    var delay = parseInt(reload);
                    if (isNaN(delay) && me.read)
                        me.read(true);
                    else if (me.readDelay) {
                        me.progress(false);
                        me.readDelay({}, delay);
                    } else
                        me.progress(false);
                } else
                    me.progress(false);
                if (done) done(result);
                
                if (result.showMessage)
                    kendo.alert(result.showMessage);
            }).fail(function(e) {
                me.progress(false);
                errorHandler(e);
            });
        };

        this.asyncPost = function(action, data, done, reload) {
            var me = this;

            return $.ajax({
                url: action[0] === '/' ? action : "/" + this.controller + "/" + action,
                type: "POST",
                xhrFields: {
                    withCredentials: true
                },
                data: data
            }).done(function(result) {
                if (result.error)
                    kendo.alert('<div style="max-width: 900px;max-height:600px;white-space:pre-wrap;">' + result.error + '</div>');
                if (reload) {
                    var delay = parseInt(reload);
                    if (isNaN(delay) && me.read)
                        me.read(true);
                    else if (me.readDelay) {
                        me.readDelay({}, delay);
                    }
                }
                if (done) done(result);

                if (result.showMessage)
                    kendo.alert(result.showMessage);
            }).fail(function(e) {
                errorHandler(e);
            });
        };

        this.createJobAndTrace = function(action, data, done, reloadOnSuccess, timeInterval) {
            var me = this;
            this.post(action,
                data,
                function(result) {
                    if (result.success && result.jobId)
                        me.traceJobStatus(result.jobId, '', done, reloadOnSuccess, timeInterval, null);
                },
                false);
        };

        this.removeProgressNotification = function(message) {
            if (!message)
                return;

            // удаляем предыдушее сообщение о прогрессе
            this.notification.getNotifications().find('.k-notification-content').each(function() {
                if ($(this).text() === message) {
                    $(this).closest('.k-animation-container').remove();
                }
            });
        };

        this.traceJobStatus = function (jobId, status, done, reloadOnSuccess, timeInterval, lastJobId, progressMessage) {
            //debugger;
            var me = this;
            var isRecurringJob = isNaN(jobId);
            var url = isRecurringJob ? '/Home/GetRecurringJobState' : '/Home/GetJobState';
            
            this.asyncPost(url,
                { jobId: jobId },
                function (result) {
                    if (!result.success) {
                        if (done) done(result);
                        return;
                    }

                    var notifyType = 'info';
                    switch (result.JobState) {
                    case "Succeeded":
                        notifyType = 'success';
                        break;
                    case "Deleted":
                    case "Failed":
                        notifyType = 'error';
                        break;
                    }

                    //Обновление статуса в SDM_TasksList
                    var urlupdatestatus = '/SRE/ClientReports/UpdateStatusSDM_TasksList'
                    me.asyncPost(urlupdatestatus,
                        {
                            jobId: jobId,
                            status: result.JobState
                        },
                        function (resultupdatestatus) {

                        });

                    if (result.JobState !== status || isRecurringJob && result.LastJobId !== lastJobId && lastJobId) {
                        if (!me.notification) {
                            var span = $('<span></span>');
                            me.element.append(span);
                            me.notification = span.kendoNotification({
                                autoHideAfter: 3000,
                                position: {
                                    left: null,
                                    bottom: 30,
                                    right: 30
                                }
                            }).data("kendoNotification");
                        }

                        if (result.AlertMessage)
                            kendo.alert(result.AlertMessage).bind('close',
                                function() {
                                    me.notification.show(result.Message, notifyType);
                                });
                        else
                            me.notification.show(result.Message, notifyType);
                        if (done) {
                            result.notifyType = notifyType;
                            done(result);
                        }
                    }

                    if (isRecurringJob && result.JobState === 'Succeeded' && result.LastJobId !== lastJobId && lastJobId) {
                        me.removeProgressNotification(progressMessage);
                        if ((reloadOnSuccess || reloadOnSuccess === undefined) &&
                            me.read &&
                            (!me.grid ||
                                !me.grid.editable &&
                                !me.grid.editor))
                            me.read(true);
                    }

                    if (result.JobState === 'Succeeded' && !isRecurringJob) {
                        me.removeProgressNotification(progressMessage);
                        if ((reloadOnSuccess || reloadOnSuccess === undefined) &&
                            me.read &&
                            (!me.grid ||
                                !me.grid.editable &&
                                !me.grid.editor))
                            me.read(true);
                    }
                    else if (result.JobState !== 'Deleted' && result.JobState !== 'Failed') {

                        if (result.ProgressMessage && progressMessage !== result.ProgressMessage) {
                            me.removeProgressNotification(progressMessage);
                            progressMessage = result.ProgressMessage;
                            me.notification.options.autoHideAfter = 120000;
                            me.notification.show(result.ProgressMessage, notifyType);
                            me.notification.options.autoHideAfter = 3000;
                        }

                        setTimeout(function() {
                                me.traceJobStatus(jobId, result.JobState, done, reloadOnSuccess, timeInterval, result.LastJobId, progressMessage);
                            },
                            timeInterval || (isRecurringJob ? 15000 : 500));
                    }
                });
        };

        this.bindProgress = function(options) {
            options.dataSource.bind('requestStart',
                function() {
                    if (!options.startProgress) {
                        kendo.ui.progress(options.element, true);
                        options.startProgress = true;
                    }
                });
            options.dataSource.bind('requestEnd',
                function() {
                    if (options.startProgress) {
                        kendo.ui.progress(options.element, false);
                        options.startProgress = false;
                    }
                });
        };

        this.bindOnEndRequestAlertMessage = function (options) {
            if (!options) options = {};
            let callback = options.callback;
            if (!callback)
                callback = function (dataItem) {
                    kendo.alert('<div style="max-width: 900px;max-height:600px;">' + (options.encode || true ? kendo.htmlEncode(dataItem.AlertMessage) : dataItem.AlertMessage) + '</div>');
                };
            this.grid.dataSource.bind('requestEnd', function (e) {
                if (e.response && e.response.Data && e.response.Data.length) {
                    for (let i = 0; i < e.response.Data.length; i++) {
                        if (e.response.Data[i].AlertMessage) {
                            callback(e.response.Data[i]);
                        }
                    }
                }
            });
        };

        /*
         * /
         * @param {any} options
         * title: заголово диалога
         * OKButton: текст кнопки OK
         * CancelButton: текст кнопки Отмена
         * content: содержимое диалога
         * width: ширина окна
         * open: метод на открытие диалога
         * done: метод по обработке результата диалога
         * validate: метод валидации
         * close: метод на закрытие диалога
         */
        this.confirmDialog = function (options) {
            var dialog = $('<div />').kendoDialog({
                title: options.title || '',
                modal: true,
                width: options.width || '600px',
                content: options.content,
                actions: [
                    {
                        text: options.OKButton || 'OK',
                        primary: true,
                        action: function(e) {
                            var validator = dialog.element.data('kendoValidator');
                            if (!validator.validate())
                                return false;
                            
                            if (options.validate && !options.validate(validator))
                                return false;

                            options.done();
                            return true;
                        }
                    },
                    {
                        text: options.CancelButton
                    }
                ],
                close: function() {
                    if (options.close) options.close();
                    dialog.destroy();
                }
            }).data('kendoDialog');
            dialog.element.kendoValidator({ errorTemplate: kendo.ui.Editable.prototype.options.errorTemplate });
            
            if (options.open) options.open();
            dialog.open();
            dialog.center();
            return dialog;
        };

        this.addTmpl = function (name, id, obj) {
            if (!this._tmpl) this._tmpl = {};
            var f = $('#' + (id || (name + 'Template')));
            if (f.length)
                this._tmpl[name] = kendo.template(f.html(), obj || {});
        };
    },

    BaseToggleMethods: function () {
        this.ToggleActiveAndRead = function(button, e, delayTime) {
            button.toggleClass('k-state-selected');
            this.readDelay(e, delayTime);
        };

        this.ToggleField = function (id, visible) {
            if (Array.isArray(id)) {
                var me = this;
                id.forEach(function(item) { me.ToggleField(item, visible); });
                return;
            }

            var element;
            if (this.grid && this.grid.editable)
                element = this.grid.editable.element;
            else if (this.editable && this.editable.element)
                element = this.editable.element;
            else
                element = this.element;
            if (visible) {
                element.find('#' + id).closest('.editor-field,.k-edit-field').show();
                element.find('label[for="' + id + '"]').closest('.editor-label,.k-edit-label').show();
            }
            else {
                element.find('#' + id).closest('.editor-field,.k-edit-field').hide();
                element.find('label[for="' + id + '"]').closest('.editor-label,.k-edit-label').hide();
            }
        };

        this.ReadonlyField = function(id, readonly) {

            var searchId;
            if (Array.isArray(id)) {
                searchId = '';
                id.forEach(function(item) {
                    searchId += (searchId ? ',' : '') + '#' + item;
                });
            }
            else
                searchId = '#' + id;

            var element;
            if (this.grid && this.grid.editable)
                element = this.grid.editable.element;
            else if (this.editable && this.editable.element)
                element = this.editable.element;
            else
                element = this.element;
            element = element.find(searchId).closest('.editor-field,.k-edit-field,.m-edit-field-div');
            Nat.F.SetReadOnlyFields(element, readonly);
        };
    },

    SimpleGridController: function(controller) {

        Nat.Classes.BasePostMethod.call(this, controller);
        Nat.Classes.BaseToggleMethods.call(this);

        this.readDelayTime = 1000;

        this.read = function(keepPage) {
            if (!keepPage && this.grid.dataSource.options.page && this.grid.options.pageable && this.grid.dataSource.options.serverPaging)
                this.grid.dataSource.page(1);
            else
                this.grid.dataSource.read();
        };
        
        this.readDelay = function(e, delayTime) {
        
            var me = this;
            if (!me._readDelayInitialized) {
                me._readDelayInitialized = true;
                this.grid.dataSource.bind('requestStart',
                    function(dse) {
                        if (dse.type === 'read' && me._readDelay)
                            clearTimeout(me._readDelay);
                    });
            }

            if (this._readDelay)
                clearTimeout(this._readDelay);
            this._readDelay = setTimeout(function() {
                    if (me.grid.editable)
                        return;
                    me.read();
                },
                e && e.keyCode === 13 ? 1 : delayTime || this.readDelayTime || 1000);
        };

        this.bindWindowResize = function() {
            var me = this;
            $(window).resize(function() { me.grid.resize(); });
        };

        this.bindGetData = function(rewriteData) {
            var me = this;
            var originalData = rewriteData ? null : this.grid.dataSource.transport.options.read.data;
            this.grid.dataSource.transport.options.read.data = function (e) {
                var data = me.onGetData(e);
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

            // для Excel требуется в options, т.к. там создается новый DataSource с options из этого
            this.grid.dataSource.options.transport.read.data = this.grid.dataSource.transport.options.read.data;
        };

        // привязка события клика к кнопкам грида на строках
        this.bindGridRowCommandButton = function(command, fn, eventName) {
            this.grid.wrapper.on(eventName || 'click',
                'tbody>tr:not(.k-detail-row,.k-grouping-row):visible .k-grid-' + command,
                function(e) {
                    e.preventDefault();
                    fn(e);
                });
        }

        // Открытие вкладки с не валидными полями
        this.bindOpenNotValidTab = function () {
            this.grid.bind('edit', $.proxy(this.OpenNotValidTab, this));
        };

        // Открытие окна на удаление
        this.changeDeleteWithPreview = function() {
            this.grid.removeRow = function(row) {

                this.editRow($(row));
                gridPopupReadonlyModeEval.call(this);
                var deleteButton = $('<a class="k-button k-button-icontext k-grid-delete k-primary" href="#"><span class="k-icon k-i-close"></span>' +
                    this.options.messages.commands.destroy +
                    '</a>');
                var me = this;
                deleteButton.on('click', function() {
                    me._removeRow(row);
                    return false;
                });
                this.editable.element.find('.k-grid-cancel').before(deleteButton);
                setTimeout(function() { deleteButton.focus(); }, 500);
            };
        };

        this.bindSelectionChange = function(bindOnCancel, customFn) {
            if (this._bindSelectionChange) {
                if (customFn) 
                    this._bindSelectionChange.push(customFn);
                return;
            }
            
            this._bindSelectionChange = [];
            if (customFn) 
                this._bindSelectionChange.push(customFn);

            var grid = this.grid;
            var me = this;
            var selectedUid;
            var selectedLength = 0;
            let fnCallAllChangeFn = function (e, selected) {
                if (me.onSelectionChange) me.onSelectionChange(e, selected);
                for (let i = 0; i < me._bindSelectionChange.length; i++) {
                    me._bindSelectionChange[i].call(me, e, selected);
                }
            };
            this._callChange = function(e) {
                if (!me.grid || !me.grid.element)
                    return;
                
                var selectedRows = grid.select();
                if (!selectedRows.length || selectedRows.hasClass('k-no-data')) {
                    if (selectedLength > 0)
                    {
                        selectedUid = null;
                        selectedLength = 0;
                        fnCallAllChangeFn(e, null);
                        return;
                    }
                }

                var selected = grid.dataItem(selectedRows);
                if (selectedLength !== selectedRows.length) {
                    selectedUid = selected.uid;
                    fnCallAllChangeFn(e, selectedRows.length === 1 ? selected : me.getSelectedDataItems());
                }
                else if (!selected && selectedUid) {
                    selectedUid = null;
                    fnCallAllChangeFn(e, null);
                }
                else if (selected && (selected.uid !== selectedUid)) {
                    selectedUid = selected.uid;
                    fnCallAllChangeFn(e, selectedRows.length === 1 ? selected : me.getSelectedDataItems());
                }

                selectedLength = selectedRows.length;
            }

            grid.bind('change', me._callChange);
            grid.bind('clear', me._callChange);

            if (bindOnCancel) {
                var timeFn = function(e) { setTimeout(function() { me._callChange(e); }, 100); };
                grid.bind('cancel', timeFn);
                var createModel = null;
                grid.dataSource.bind('change',
                    function(e) {
                        if (!e.action || e.action === 'sync') {
                            if (createModel) {
                                var tr = me.gridFindTr(grid.dataSource.get(createModel.id));
                                grid.select(tr);
                            }
                            me._callChange(e);
                        }
                    });
                grid.dataSource.bind('requestEnd',
                    function(e) {
                        if (e.type === 'create' && e.response.Data[0])
                            createModel = e.response.Data[0];
                        else
                            createModel = null;
                        if (e.type === 'update')
                            selectedUid = null;
                    });
            }
        };

        this.onGridSelectDeselect = function(callback) {
            var me = this;
            var selectedValue;
            this.grid.bind('change', function() {
                var dataItem = me.getSelected();
                if (selectedValue && dataItem && dataItem.id === selectedValue.id) {
                    me.grid.clearSelection();
                    dataItem = null;
                }

                if (callback) callback(selectedValue, dataItem);
                selectedValue = dataItem;
            });
        };

        this.bindProgress = function(requestStart, requestEnd, options) {
            var me = this;
            var ds = options && options.ds ? options.ds : this.grid.dataSource;
            ds.bind('requestStart',
                function(e) {
                    me.progress(true, !(me.grid instanceof kendo.ui.TreeList || me.grid instanceof kendo.ui.Gantt));
                    if (requestStart) requestStart.call(me, e);
                });
            ds.bind('requestEnd',
                function(e) {
                    if (requestEnd) requestEnd.call(me, e);
                    if (options && options.endTimeout)
                        setTimeout(function() {
                                me.progress(false);
                            },
                            options.endTimeout);
                    else
                        me.progress(false);
                    if (e.type === 'read' && me._callChange) 
                        setTimeout(function() { me._callChange(e); }, 100);
                });
        };

        // Выбирать запись, при навигации по строкам
        this.bindNavigatableSelection = function(gridName) {
            var me = this;
            gridName = gridName || this.options.gridName || 'grid';
            this.grid.table.on("keydown",
                function(e) {
                    if (e.keyCode !== 38 && e.keyCode !== 40)
                        return;

                    setTimeout(function() {
                        var tr = $('#' + gridName + "_active_cell").closest("tr");
                        if (!tr.hasClass('k-header'))
                            me.grid.select(tr);
                    });
                });
        };

        this.bindModelChange = function(onEdit) {
            if (!this.InitializeOnModelChange)
                return;

            var me = this;
            var fields = {};
            this.InitializeOnModelChange(function(field, fn) {
                if (Array.isArray(field)) {
                    field.forEach(function(f) {
                        if (!fields[f])
                            fields[f] = [];
                        fields[f].push(fn);
                    });
                } else {
                    if (!fields[field])
                        fields[field] = [];
                    fields[field].push(fn);
                }
            });

            this.grid.dataSource.bind('change',
                function(e) {
                    if (e.action === 'itemchange' && e.field) {
                        var model = e.items[0];
                        if (fields[e.field]) {
                            var value = model[e.field];
                            fields[e.field].forEach(function(fn) {
                                fn.call(me, model, value);
                            });
                        }
                        if (fields[''])
                            fields[''].forEach(function(fn) {
                                fn.call(me, model, null);
                            });
                    }
                });
            this.grid.bind('edit',
                function(e) {
                    if (onEdit) onEdit.call(me, e);
                    if (fields['*'])
                        fields['*'].forEach(function(fn) {
                            fn.call(me, e.model, null);
                        });
                });
        };

        this.changeDataSourceToArray = function(model, field, options) {
            var me = this;
            if (!this.newId) this.newId = -1;
            if (!options) options = {};

            var grid = options.grid || this.grid;
            grid.setDataSource(
                new kendo.data.DataSource({
                    autoSync: grid.options.editable && grid.options.editable.mode === 'incell',
                    transport: {
                        read: function(e) {
                            e.success(model.get(field));
                        },
                        create: function(e) {
                            e.data.id = me.newId--;
                            if (options.create) options.create(e);
                            e.success(e.data);
                        },
                        update: function(e) {
                            if (options.update) options.update(e);
                            e.success(e.data);
                            if (options.dirty)
                                options.dirty();
                            else
                                model.set('dirty', true);
                        },
                        destroy: function(e) {
                            if (options.destroy) options.destroy(e);
                            e.success(e.data);
                        }
                    },
                    schema: {
                        model: grid.dataSource.options.schema.model
                    },
                    sort: options.sort
                }));
            if (options.autoBind === undefined ? true : options.autoBind)
                grid.dataSource.read();
            grid.options.refreshOnClose = true;
        };

        this.changeTreeDataSourceToArray = function(model, field, options) {
            var me = this;
            if (!this.newId) this.newId = -1;
            if (!options) options = {};

            this.grid.setDataSource(
                new kendo.data.TreeListDataSource({
                    transport: {
                        read: function(e) {
                            e.success(model.get(field));
                        },
                        create: function(e) {
                            e.data.id = me.newId--;
                            if (options.create) options.create(e);
                            e.success(e.data);
                        },
                        update: function(e) {
                            if (options.update) options.update(e);
                            e.success(e.data);
                            if (options.dirty)
                                options.dirty();
                            else
                                model.set('dirty', true);
                        },
                        destroy: function(e) {
                            if (options.destroy) options.destroy(e);
                            e.success(e.data);
                        }
                    },
                    schema: {
                        model: this.grid.dataSource.options.schema.model
                    },
                    sort: options.sort
                }));
            if (options.autoBind === undefined ? true : options.autoBind)
                this.grid.dataSource.read();
        };
        
        this.getSelected = function(grid) {
            if (!grid) grid = this.grid;
            var selected = grid.select();
            if (!selected.length || selected.hasClass('k-no-data'))
                return null;
            return grid.dataItem(selected);
        };
        
        this.getSelectedDataItems = function(grid) {
            if (!grid) grid = this.grid;
            var selected = grid.select();
            var items = [];
            for (var i = 0; i < selected.length; i++) {
                if ($(selected[i]).hasClass('k-no-data'))
                    continue;
                var dataItem = grid.dataItem(selected[i]);
                if (dataItem) items.push(dataItem);
            }

            return items;
        };

        this.getSelectedIds = function(grid, field) {
            if (!grid) grid = this.grid;
            if (!field) field = 'id';
            var selected = grid.select();
            var ids = [];
            for (var i = 0; i < selected.length; i++) {
                if ($(selected[i]).hasClass('k-no-data'))
                    continue;
                var dataItem = grid.dataItem(selected[i]);
                if (dataItem) ids.push(dataItem[field]);
            }

            return ids;
        };

        this.getGridButton = function(name, clickFn) {
            let button = this.grid.element.find('.k-grid-' + name);
            if (clickFn)
                button.on('click', $.proxy(clickFn, this));
            return button;
        };

        this.gridButtonToImage = function(name, isActive, setSize) {
            var button = this.getGridButton(name);
            if (isActive)
                button.addClass('k-state-selected');
            buttonImageTextToImage(button, setSize || true);
            return button;
        };

        this.progress = function(value, skipGrid) {
            if (!this.grid || !this.grid.element)
                return;

            if (this.dataSourceProgress !== value) {
                if (this.progressElement) {
                    kendo.ui.progress(this.progressElement, value);
                }
                else if (!skipGrid || !value)
                    kendo.ui.progress(this.grid.element, value);

                if (this.grid.editor && this.grid.editor.window)
                    kendo.ui.progress(this.grid.editor.window.element, value);
                else if (this.grid.editable && this.grid.editable.element)
                    kendo.ui.progress(this.grid.editable.element, value);
            }

            this.dataSourceProgress = value;
        };

        this.gridSelectId = function(id) {
            var dataItem = this.grid.dataSource.get(id);
            if (!dataItem) return false;
            return this.gridSelectDataItem(dataItem);
        };

        this.gridFindTr = function(dataItem, grid) {
            if (!dataItem || !dataItem.uid)
                return null;
            return (grid || this.grid).table.find('tr[data-uid="' + dataItem.uid + '"]');
        };

        this.gridSelectDataItem = function(dataItem) {
            if (!dataItem || !dataItem.uid)
                return false;

            var tr = this.grid.table.find('tr[data-uid="' + dataItem.uid + '"]');
            if (!tr.length) return false;
            
            this.grid.select(tr);
            return true;
        };

        this.gridEditScrollTemplate = function(options) {
            var grid = (options ? options.grid : null) || this.grid;
            grid.options.editable.template = '<div class="m-edit-form-container-scroll">' + grid.options.editable.template + '</div>';
        };

        this.InitReorderRecords = function (options) {
            var me = this;
            this.grid.element.addClass('m-grid-move');
            this.grid.table.kendoSortable({
                filter: ">tbody >tr",
                autoScroll: true,
                hint: function(element) { //customize the hint
                    var table = $('<table style="width: 600px;" class="k-grid-move k-widget"></table>'),
                        hint;

                    table.append(element.clone()); //append the dragged element
                    table.css("opacity", 0.8);

                    return table; //return the hint element
                },
                cursor: "move",
                placeholder: function (element) {
                    var colCount = 0;
                    for (var i = 0; i < me.grid.columns.length; i++) {
                        if (!me.grid.columns[i].hidden)
                            colCount ++;
                    }

                    return $('<tr class="placeholder"><td colspan="' + colCount + '" /></tr>');
                    //return element.clone().removeClass("k-state-selected");
                },
                change: function(e) {
                    var skip = me.grid.dataSource.skip() || 0,
                        oldIndex = e.oldIndex + skip,
                        newIndex = e.newIndex + skip,
                        data = me.grid.dataSource.view(),
                        dataItem = me.grid.dataSource.getByUid(e.item.data("uid"));

                    if (!options) {
                        me.grid.dataSource.remove(dataItem);
                        me.grid.dataSource.insert(newIndex, dataItem);
                    } else {
                        if (!options.weightField)
                            options.weightField = "Weight";
                        var newItem = data[newIndex];
                        var newWeight = newItem ? newItem[options.weightField] : 0;
                        var oldWeight = dataItem[options.weightField];
                        if (!newWeight)
                            newWeight = data[data.length - 1][options.weightField] + 1;
                        for (var i = 0; i < data.length; i++) {
                            if (data[i] !== dataItem) {
                                var value = data[i][options.weightField];
                                if (oldWeight < newWeight && value >= oldWeight && value <= newWeight)
                                    data[i].set(options.weightField, value - 1);
                                else if (oldWeight > newWeight && value <= oldWeight && value >= newWeight)
                                    data[i].set(options.weightField, value + 1);
                            }
                        }
                        dataItem.set(options.weightField, newWeight);

                        if (options.change)
                            options.change();
                    }
                }
            });
        };

        this.InitTreeReorderRecords = function (options) {

            if (options.colIndex === undefined)
                options.colIndex = 1;
            var me = this;
            this.grid._dragging.options.reorderable = true;
            var addChildDragEnd = this.grid._dragging.options.dragend;
            this.grid._dragging.options.dropHintContainer = function(item) {
                return item.children('td:visible:eq(' + options.colIndex + ')');
            };
            this.grid._dragging.options.dropPositionFrom = function(dropHint) {
                return dropHint.prevAll('.k-i-none,.k-i-collapse,.k-i-expand').length > 0 ? 'after' : 'before';
            };
            this.grid._dragging.options.dragend = function (e) {
                if (!options.validate(e)) return;

                if (e.position === 'over') {
                    addChildDragEnd.call(this, e);
                    options.setDirty();
                    return;
                }
                else if (e.position === 'before' || e.position === 'after') {

                    var data = me.grid.dataSource.data(),
                        dataItem = me.grid.dataItem(e.source),
                        destDataItem = me.grid.dataItem(e.destination),
                        newWeight = destDataItem[options.weightField],
                        oldWeight = dataItem[options.weightField],
                        i;

                    dataItem.set('refParent', destDataItem.refParent);
                    if (oldWeight > newWeight) {
                        if (e.position === 'after')
                            newWeight++;

                        for (i = 0; i < data.length; i++) {
                            if (data[i][options.weightField] >= newWeight && data[i][options.weightField] <= oldWeight)
                                data[i].set(options.weightField, data[i][options.weightField] + 1);
                        }

                        dataItem.set(options.weightField, newWeight);
                    }
                    else if (oldWeight < newWeight) {
                        if (e.position === 'before')
                            newWeight--;

                        for (i = 0; i < data.length; i++) {
                            if (data[i][options.weightField] >= oldWeight && data[i][options.weightField] <= newWeight)
                                data[i].set(options.weightField, data[i][options.weightField] - 1);
                        }

                        dataItem.set(options.weightField, newWeight);
                    }
                    options.setDirty();
                    
                    return;
                }
            };

            var w = this.grid.element.closest('.k-window-content').data('kendoWindow');
            if (w) {
                w.bind('close',
                    function(e) {
                        if (window.event && event.keyCode === 27 && me.grid._dragging && me.grid._dragging.dropHint && me.grid._dragging.dropHint.is(':visible')) {
                            e.preventDefault();
                        }
                    });
            }
        };

        this.InitTreeInsertAtEnd = function() {
            var insertAt = this.grid._insertAt;
            this.grid._insertAt = function(model, index, showNewModelInView) {
                index = this.dataSource.data().length;
                insertAt.call(this, model, index, showNewModelInView);
            };
        };

        // Открытие вкладки с не валидными полями
        this.OpenNotValidTab = function () {
            if (!this._onOpenNotValidTabProxy) this._onOpenNotValidTabProxy = $.proxy(this.onSaveClickOpenNotValidTab, this);
            var validator = this.grid.editable.element.data('kendoValidator');
            if (validator)
                validator.bind('validate', this._onOpenNotValidTabProxy);
            else {
                var me = this;
                this.grid.editable.element.find('a.k-button.k-grid-update').on('click',
                    function() {
                        setTimeout(
                            function() {
                                me.onSaveClickOpenNotValidTab();
                            },
                            200);
                    });
            }
        };

        // Открытие вкладки с не валидными полями
        this.onSaveClickOpenNotValidTab = function() {
            var me = this;

            if (!me.grid.editable || !me.grid.editable.element)
                return;

            // найдены видимые валидаторы на текущем Tab
            if (me.grid.editable.element.find('.k-tooltip-validation:visible,.k-validator-tooltip:visible').length)
                return;

            var validators = me.grid.editable.element.find('div.k-content[role="tabpanel"]:hidden')
                .find('.k-tooltip-validation,.k-validator-tooltip');
            for (var i = 0; i < validators.length; i++) {
                var r = $(validators[i]);
                if (r.css('display') === 'none')
                    continue;

                var tab = r.closest('div.k-content[role="tabpanel"]');
                var tabStrip = tab.closest('.k-tabstrip').data('kendoTabStrip');
                tabStrip.activateTab(tabStrip.tabGroup.find('li[aria-controls="' + tab.attr('id') + '"]'));
                return;
            }
        };

        // use only for local array dataSource and popup mode
        this.InitPopupNextPrevButton = function () {
            var me = this;
            var trIndex = -1;

            var fnBound = function () {
                setTimeout(function () {
                        if (me.grid.editable)
                            return;
                        
                        var length = me.grid.dataSource.view().length;
                        if (trIndex >= length)
                            trIndex = 0;
                        else if (trIndex < 0)
                            trIndex = length - 1;
                        var tr = me.grid.tbody.find('tr:eq(' + trIndex + ')');
                        me.grid.select(tr);
                        me.grid.editRow(tr);
                        me.grid.unbind('dataBound', fnBound);
                    },
                    500);
            };

            var fnNextPrevFunction = function(trIChange) {
                if (!me.grid.editable)
                    return;

                trIndex = me.grid.dataSource.view().indexOf(me.grid.editable.options.model);
                if (trIndex <= -1)
                    return;
                trIndex += trIChange;

                me.grid.unbind('dataBound', fnBound);
                me.grid.bind('dataBound', fnBound);
                me.grid.saveRow();
            };
            var fnNext = function() {
                fnNextPrevFunction(1);
                return false;
            };
            var fnPrev = function() {
                fnNextPrevFunction(-1);
                return false;
            };

            this.grid.bind('edit',
                function(e) {
                    me.grid.unbind('dataBound', fnBound);

                    var buttons = me.grid.editable.element.find('.k-edit-form-container .k-edit-buttons');
                    var next = $('<a href="#" class="k-button k-button-icon" style="float:left;" role="button">&nbsp;&nbsp;<span class="fas fa-chevron-right"></span></a>');
                    var prev = $('<a href="#" class="k-button k-button-icon" style="float:left;" role="button">&nbsp;&nbsp;<span class="fas fa-chevron-left"></span></a>');
                    buttons.append(prev.on('click', fnPrev));
                    buttons.append(next.on('click', fnNext));
                });
        };

        this.dataSourceMapModelAsStringify = function() {
            var ds = this.grid.dataSource;
            var parameterMap = ds.transport.parameterMap;
            ds.transport.parameterMap = function(options, operation) {
                if (operation !== 'read') {
                    if (ds.options.batch)
                        options = { models: JSON.stringify(options.models) };
                    else
                        options = { model: JSON.stringify(options) };
                }

                return parameterMap(options, operation);
            };
        };

        this.dataSourceMapDates = function(fields) {
            Nat.F.dataSourceMapDates(this.grid.dataSource, fields);
        };

        this.readonly = function(value, options) {
            var grid = options && options.grid || this.grid;
            grid.readOnly = value;

            if (value) {
                grid.element.addClass('m-readonly-toolbar');
                grid.element.removeClass('k-grid-hideToolbar');
                if (!grid.element.find('.k-grid-toolbar > *:visible').length)
                    grid.element.addClass('k-grid-hideToolbar');
            } else {
                grid.element.removeClass('k-grid-hideToolbar');
                grid.element.removeClass('m-readonly-toolbar');
            }
        };

        this.resizeWindow = function(e) {
            var editable = this.grid.editable || this.editable;
            if (!editable) return;

            var kWindow = editable.element.closest('.k-window');
            if (e.height) {
                kWindow.find('.k-popup-edit-form').css('max-height', 'none');
                kWindow.find('.m-edit-form-container-scroll').css('max-height', e.height).height(null);
            }
            else if (e.outerHeight) {
                var height = e.outerHeight -
                    kWindow.find('>.k-window-titlebar').height() -
                    editable.element.find('.k-edit-buttons').height();
                kWindow.find('.k-popup-edit-form').css('max-height', 'none');
                kWindow.find('.m-edit-form-container-scroll').css('max-height', 'none').height(height);
            }

            if (e.width) {
                kWindow.find('.k-edit-form-container').width(e.width);
            }
            var w = editable.element.data('kendoWindow');
            if (w) {
                if (e.position) {
                    if (e.position.left)
                        w.wrapper.css('left', e.position.left);
                    if (e.position.top)
                        w.wrapper.css('top', e.position.top);
                }
                else
                    w.center();
            }
        };

        this.persistExpandSession = function(name, expandOnLoad, defaultExpand) {
            PersistExpandSession(this.grid, name, expandOnLoad, defaultExpand);
        };

        this.bindSaveColumnsState = function(stateKey) {
            var me = this;
            var delayId;
            var fn = function() {
                if (me._loadingColumnsState)
                    return;

                clearTimeout(delayId);
                delayId = setTimeout(function() {
                    me.SaveColumnsState(stateKey);
                }, 1000);
            };
            Nat.F.BindGridSettingsChanges(this.grid, fn);

            this.LoadColumnsState(stateKey);
        };

        this.SaveColumnsState = function(stateKey) {
            var localStorage;
            // Does this browser support localStorage?
            try {
                localStorage = window.localStorage;
            } catch (e) {
                return;
            }

            var data = Nat.F.GetGridSettings(this.grid);
            localStorage[stateKey] = JSON.stringify({ version: 1, data: data });
        };

        this.LoadColumnsState = function(stateKey) {
            var localStorage;
            // Does this browser support localStorage?
            try {
                localStorage = window.localStorage;
            } catch (e) {
                localStorage = {};
            }
            var strData = localStorage[stateKey];
            if (!strData) return;
            var data = JSON.parse(strData);
            if (data.version !== 1 || !data.data) return;

            this._loadingColumnsState = true;
            Nat.F.SetGridSettings(this.grid, data.data);
            this._loadingColumnsState = false;
        };

        // метод для быстрой привязки фильтров в панели (аргумент options.name), у которых id = <имя грида> + '_' + options.name
        // фильтр применяется к this.options, по-умолчанию используется имя фильтра как options.name, если отличается, то задать options.filterName
        // аргумент options.selectFirst для автоматического выбора первой записи из списка
        // аргумент options.defaultValue для задания значения фильтра по-умолчанию, для постраничных списков также нужно задать options.defaultName
        // аргумент options.change на событие компонента о смене значения
        this.QuickToolbarSearch = function(options) {
            var me = this;
            var widget = $('#' + (this.options.gridName || 'grid') + '_' + options.name).data(options.widget || 'kendoDropDownList');
            if (!widget)
                return null;

            var eventName = 'change';
            if (options.changeEvent)
                eventName = options.changeEvent;
            else if (options.widget === 'kendoButtonGroup')
                eventName = 'select';

            widget.bind(eventName,
                function() {
                    me.options.set(options.filterName || options.name, widget.value());
                    if (options.change) options.change(widget);
                    me.readDelay({}, 100);
                });

            var value = options.defaultValue || widget.element.attr('defaultValue') || widget.value();
            var name = options.defaultName || widget.element.attr('defaultName');
            
            if (value != null) {
                if (widget.dataSource && !isNaN(value))
                    value = parseInt(value);
                me.options.set(options.filterName || options.name, value);
            }

            if (widget.dataSource) {
                widget.dataSource.one('requestEnd',
                    function(e) {
                        if (value && name && !e.response.Data.filter(function(f) { return f.id === value }).length) {
                            var dataItem = {};
                            dataItem[widget.options.dataTextField] = name;
                            dataItem[widget.options.dataValueField] = value;
                            e.response.Data.push(dataItem);
                        }

                        if (options.selectFirst) {
                            setTimeout(function() {
                                    var first = widget.dataSource.data()[0];
                                    if (first) {
                                        widget.value(first.id);
                                        widget.trigger('change');
                                    }
                                },
                                25);
                        } else if (value) {
                            setTimeout(function() {
                                    widget.value(value);
                                    widget.trigger('change');
                                },
                                25);
                        }
                    });

                if (!widget.options.autoBind) {
                    widget.dataSource.read();
                }
            }

            return widget;
        };

        this.findColumnIndex = function(name) {
            for (var i = 0; i < this.grid.columns.length; i++) {
                if (this.grid.columns[i].field === name)
                    return i;
            }

            return -1;
        };

        this.setValue = function(name, value, parse, format) {
            if (this.grid.editable)
                this.setModelValue(this.grid.editable.options.model, name, value, parse, format);
            else if (this.grid.editor && this.grid.editor.editable)
                this.setModelValue(this.grid.editor.editable.options.model, name, value, parse, format);
            else if (this.editable)
                this.setModelValue(this.editable.options.model, name, value, parse, format);
        };

        this.setModelValue = function(model, name, value, parse, format) {
            var o = {};
            o[name] = value;
            Nat.F.SetValue(model, name, o, parse, format);
        };

        this.editableInsertButton = function (e) {
            if (e.actions && e.actions.length) {
                for (let i = 0; i < e.actions.length; i++) {
                    let action = e.actions[i];
                    if (!action.insertBefore) action.insertBefore = e.insertBefore;
                    if (!action.insertAfter) action.insertAfter = e.insertAfter;
                    if (!action.floatLeft) action.floatLeft = e.floatLeft;
                    if (!action.click) action.click = e.click;
                    this.editableInsertButton(action);
                }
                return;
            }
            let button = $('<a class="k-button k-button-icontext" href="#"></a>');
            if (e.floatLeft) button.css('float', 'left');
            if (e.floatRight) button.css('float', 'right');
            if (e.iconCss) button.append($('<span></span>').addClass(e.iconCss)).append('&nbsp;');
            if (e.buttonCss) button.addClass(e.buttonCss);
            button.append(e.text);
            button.on('click', $.proxy(e.click, this))
        
            var editable = e.editable || this.grid.editable || this.editable;
            if (e.insertBefore === 'first')
                button.insertBefore(editable.element.find('.k-edit-buttons .k-button').first());
            else if (e.insertBefore)
                button.insertBefore(e.insertBefore);
            else if (e.insertAfter)
                button.insertAfter(e.insertAfter);
            else
                editable.element.append(button);
        };
    },
    
    SelectionDialog: function (options, editable) {

        this.options = options;
        this.editable = editable;
        //this.selectedNames = {};

        this.Initialize = function() {
            var me = this;
            var w = $(window);
            this.element = $('<div class="m-selectionDialog" />');
            this.gridName = 'selectionGrid' + new Date().getTime();
            if (me.editable)
                this.lastSelected = me.editable.options.model.toJSON();
            window[this.gridName + 'GetData'] = $.proxy(this.OnGetData, this);
            this.element.kendoWindow({
                width: options.width || parseInt(w.width() * 0.8),
                height: options.height || parseInt(w.height() * 0.8),
                closable: false,
                modal: true,
                resizable: true,
                draggable: true,
                maximizable: true,
                title: this.options.title,
                actions: ["Maximize", "Close"],
                close: function () { me.destroy(); }
            });
            this.element.data('m-selectionDialog', this);
            this.dialog = this.element.data('kendoWindow');
            this.dialog.content(
                '<div class="m-window-content"></div><div class="m-window-footer"><div class="k-edit-buttons" role="toolbar"></div></div>');

            this.element.find('.k-edit-buttons').append(
                $(
                    '<button type="button" class="k-button k-button-icontext k-primary"><span class="k-icon k-i-check"></span> ' +
                    (window.isKz ? 'Таңдау' : 'Выбрать') +
                    '</button>')
                .click($.proxy(this.onOKClick, this)));
            this.element.find('.k-edit-buttons').append(
                $('<button type="button" class="k-button k-button-icontext"><span class="k-icon k-i-cancel"></span> ' +
                    (window.isKz ? 'Күшін жою' : 'Отмена') +
                    '</button>')
                .click($.proxy(this.onCancelClick, this)));
        };

        this.Open = function() {

            var me = this;
            this.dialog.center();
            this.dialog.open();

            kendo.ui.progress(this.element, true);
            var url = this.options.url;
            if (!url) {
                var action = this.options.gridActionName || this.options.actionName.substr(7);
                url = '/' + this.options.areaName + '/' + this.options.controllerName + '/' + action + '/';
            }
            var data = {
                EmptyLayout: true,
                Deferred: false,
                GridName: this.gridName,
                ReadDataParametersHandler: this.gridName + 'GetData',
                IsWindowSelection: true
            };
            if (this.options.multiSelect)
                data.GridCheckboxSelection = true;

            $.ajax(url,
                    {
                        data: data,
                        dataType: 'html',
                        xhrFields: {
                            withCredentials: true
                        }
                    })
                .done(function(result) {
                    me.element.find('.m-window-content').html(result);
                    kendo.ui.progress(me.element, false);
                    me.InitializeGrid();
                }).fail(function(e) {
                    kendo.ui.progress(me.element, false);
                    errorHandler(e);
                });
        };

        this.InitializeGrid = function () {
            this.grid = $('#' + this.gridName).data('kendoGrid') 
            
            if(!this.grid) {
                this.grid = $('#' + this.gridName).data('kendoTreeList');
                
                this.isTreeList = !!this.grid;
            }
            
            if (this.grid) {
                this.grid.bind('change', $.proxy(this.OnGridSelect, this));
                this.grid.element.on("dblclick", "tr.k-state-selected", $.proxy(this.onOKClick, this));
                if (!this.options.multiSelect)
                    this.grid.dataSource.bind('requestEnd', $.proxy(this.OnRequestEnd, this));
                this.grid.bind('dataBound', $.proxy(this.onDataBound, this));
            }
        };
        this.getSelectedDataItemsFromTreeList = function(){
            var me = this;
            
            me.selectedItems = null;
            
            me.grid.select().each(function(i, item){
                var model = me.grid.dataItem(item);

                if(!me.selectedItems)
                    me.selectedItems = {};
                
                me.selectedItems[model.get(options.valueField)] = model.toJSON();
            });
        }
        
        this.OnGridSelect = function () {
            var me = this;
            
            if (this.options.multiSelect && this.grid.selectedKeyNames) {
                if (!this.selectedItems)
                    this.selectedItems = {};

                var selectedKeyNames = this.grid.selectedKeyNames();
                // add checked values
                selectedKeyNames.forEach(function (id) {
                    if (!me.selectedItems[id])
                        me.selectedItems[id] = me.grid.dataSource.get(id).toJSON();
                });

                // remove unchecked values
                for (var prop in this.selectedItems) {
                    if (!this.selectedItems.hasOwnProperty(prop))
                        continue;

                    if (selectedKeyNames.indexOf(prop) === -1)
                        this.selectedItems[prop] = null;
                }

                return;
            } else if (this.options.multiSelect){
                this.getSelectedDataItemsFromTreeList();
                
                return;
            }

            var dataItem = this.grid.dataItem(this.grid.select());
            if (dataItem) {
                this.lastSelected = dataItem.toJSON();
                //this.selectedNames[dataItem[options.valueField]] = dataItem[options.textField];
            }
        };

        this.OnGetData = function() {
            var data = this.options.getDataParams || {};
            if (typeof data === "function") data = data();

            var jsonModel = this.editable ? this.editable.options.model.toJSON() : {};

            if (this.options.gridName) {
                var grid = $('#' + this.options.gridName).data('kendoGrid') ||
                    $('#' + this.options.gridName).data('kendoTreeList') ||
                    $('#' + this.options.gridName).data('kendoListView');
                if (grid && grid.dataSource.options.MapFields) {
                    grid.dataSource.options.MapFields(jsonModel);
                }
            }

            data.selectionModelMember = this.options.member;
            data.selectionModelType = this.options.type;
            data.selectionModelJson = JSON.stringify(jsonModel);
            data.Filter_SearchValue = $('#' + this.gridName + '_SearchInput').val();

            return data;
        };

        this.OnRequestEnd = function (e) {
            var me = this;
            var value = me.editable ? me.editable.options.model[me.options.member] : null;
            if (!value || me.grid.selectedKeyNames && me.grid.selectedKeyNames().length) {
                setTimeout(function() {
                        if (!me.grid.element) return;
                        var dataItem = me.grid.dataItem(me.grid.select());
                        if (dataItem) {
                            me.lastSelected = dataItem;
                        }
                    },
                    100);
                return;
            }

            if (me.grid._selectedIds) {
                me.grid._selectedIds[value] = true;
            } else {
                setTimeout(function() {
                        if (!me.grid.element) return;
                        var dataItem = me.grid.dataSource.get(value);
                        if (dataItem) {
                            var tr = me.grid.element.find('tr[data-uid="' + dataItem.uid + '"]');
                            if (tr)
                                me.grid.select(tr);
                        }
                    },
                    100);
            }
        };

        this.onCancelClick = function () {
            this.dialog.close();
            this.destroy();
        };

        this.getElement = function () {
            if (!this.options.clientId)
                return null;

            return this.editable
                ? this.editable.element.find(Nat.F.GetEscapedId(this.options.clientId))
                : $(Nat.F.GetEscapedId(this.options.clientId));
        };

        this.getEditor = function() {
            var element = this.getElement();
            if (!element) return null;
            return element.data('kendoDropDownList') || element.data('kendoMultiSelect');
        };

        this.getSelectedDataItem = function(one) {
            if(this.options.multiSelect && this.isTreeList){
                this.getSelectedDataItemsFromTreeList();
            } 
            
            if (this.options.multiSelect && this.selectedItems) {
                var items = [];
                for (var prop in this.selectedItems) {
                    if (!this.selectedItems.hasOwnProperty(prop) || !this.selectedItems[prop])
                        continue;

                    if (one) return this.selectedItems[prop];
                    items.push(this.selectedItems[prop]);
                }

                if (one) return null;
                return items;
            }

            var selectedDataItem = this.lastSelected;
            var selected = this.grid.select();
            if (selected.length)
                selectedDataItem = this.grid.dataItem(selected);

            if (one) return selectedDataItem;
            if (selectedDataItem)
                return [selectedDataItem];
            return [];
        };

        this.onOKClick = function () {
            var selectedDataItem = this.getSelectedDataItem(true);
            var id = selectedDataItem ? selectedDataItem[this.options.valueField] : null;
            if (!id) {
                kendo.alert(window.isKz ? 'Мәнді таңдау қажет' : 'Необходимо выбрать значение');
                return;
            }

            if (this.options.select) {

                this.dialog.close();
                this.destroy();

                if (this.options.multiSelect)
                    this.options.select(this.getSelectedDataItem(false));
                else
                    this.options.select([selectedDataItem.toJSON ? selectedDataItem.toJSON() : selectedDataItem]);
                return;
            }
            
            var model = this.editable ? this.editable.options.model : null;
            var editor = this.getEditor();
            if (editor && editor instanceof kendo.ui.MultiSelect) {
                var ids = this.getSelectedDataItem(false);
                var me = this;
                var idIndex = 0;
                var addFn = function() {
                    if (ids.length <= idIndex)
                        return;
                    var selectedId = ids[idIndex][me.options.valueField];
                    idIndex++;
                    if (selectedId && editor.value().indexOf(selectedId) === -1)
                        me.multiSelectAddValue(editor, selectedId, addFn);
                    else
                        addFn();
                };
                addFn();
            }
            else if (editor) {
                var dataItem = editor.dataSource.get(id);
                if (!dataItem) {
                    var newItem = {};
                    newItem[this.options.valueField] = id;
                    newItem[this.options.textField] = selectedDataItem[this.options.textField];

                    if (this.options.otherFields && this.options.otherFields.length) {
                        this.options.otherFields.forEach(function(item) {
                            newItem[item.dsField] = selectedDataItem[item.dsField];
                        });
                    }

                    editor.dataSource.insert(newItem, 0);
                }

                var indexInDataSource = editor.dataSource.indexOf(editor.dataSource.get(id));
                editor.select(indexInDataSource + (editor.options.optionLabel ? 1 : 0));
                editor.element.attr("data-val-lookupWindow", null);
                editor.trigger('change');

                if (model) {
                    if (!model.set ||
                        !model.fields ||
                        model.fields[this.options.modelTextField] && model.fields[this.options.modelTextField].editable === false)
                        model[this.options.modelTextField] = selectedDataItem[this.options.textField];
                    else
                        model.set(this.options.modelTextField, selectedDataItem[this.options.textField]);

                    if (this.options.otherFields && this.options.otherFields.length) {
                        this.options.otherFields.forEach(function(item) {
                            if (!model.fields ||
                                !model.set ||
                                model.fields[item.modelField] && model.fields[item.modelField].editable === false)
                                model[item.modelField] = selectedDataItem[item.dsField];
                            else
                                model.set(item.modelField, selectedDataItem[item.dsField]);
                        });
                    }

                    //model[this.options.member] = id;
                    model.set(this.options.member, id);
                }
            }

            this.dialog.close();
            this.destroy();
        };

        this.multiSelectAddValue = function(editor, id, callNext) {
            var me = this;
            var dataFn = editor.dataSource.transport.options.read.data;
            editor.dataSource.transport.options.read.data = function(e) {
                var data = {};
                if (typeof dataFn === "function")
                    data = dataFn.call(editor.dataSource.transport.options.read, e);
                else if (dataFn)
                    data = dataFn;
                data.showHistory = true;
                e.filter = {
                    field: me.options.valueField,
                    value: id,
                    operator: 'eq'
                };
                return data;
            };

            //editor.search(selectedDataItem[this.options.textField]);
            editor.search('');
            editor.dataSource.one('requestEnd',
                function() {
                    editor.dataSource.transport.options.read.data = dataFn;
                    setTimeout(function() {
                            var dataItem = editor.dataSource.get(id);
                            var index = editor.dataSource.indexOf(dataItem);
                            if (index > -1) {
                                var item = editor.listView.element.find('*[data-offset-index=' + index + ']');
                                editor._select(item);
                                editor._change();
                                editor._close();
                            }
                            callNext();
                        },
                        100);
                });
        };

        this.onDataBound = function(e) {
            var editor = this.getEditor();
            if (editor) {
                var value = editor.value();
                if (value) {
                    var ds = this.grid.dataSource;
                    var body = this.grid.tbody;
                    var disableFn = function(id) {
                        var dataItem = ds.get(id);
                        if (dataItem)
                            body.find('tr[data-uid="' + dataItem.uid + '"]').addClass('k-state-disabled k-state-highlight');
                    };

                    if (Array.isArray(value))
                        value.forEach(disableFn);
                    else
                        disableFn(value);
                }
            }
        };

        this.destroy = function () {
            var element = this.getElement();
            if (element) element.attr("data-val-lookupWindow", null).closest('.k-widget').focus();
            var editor = this.getEditor();
            if (editor) editor.trigger('change');

            this.dialog.destroy();
            window[this.gridName + 'GetData'] = undefined;
        };
    },

    UCFilter: function (id, tableId) {

        this.element = $('#' + id);
        this.tableElement = $('#' + tableId);

        this.element.data('natucFilters', this);
        this.tableElement.data('natucFilters', this);

        this.wrapper = this.element.closest('.m-ucFilters');
        this.filterButton = this.wrapper.find('a[data-role="setFilter"]');
        this.clearFilterButton = this.wrapper.find('a[data-role="clearFilter"]');
        this.options = kendo.observable({
            clearVisible: false
        });

        this.init = function() {
            this.element.on('change', $.proxy(this.onValueChange, this));
            this.tableElement.on('change', $.proxy(this.onTableChange, this));
            this.filterButton.on('click', $.proxy(this.onFilterClick, this));
            this.clearFilterButton.on('click', $.proxy(this.onClearFilterClick, this));
        };

        this.value = function(value) {
            if (value !== undefined) {

                this.element.val(value === null ? "" : value);
                this.onValueChange();

                return null;
            }
            else
                return this.element.val();
        };

        this.readonly = function(value) {
            this.options.set('readonly', value);
            this.onValueChange();
        };

        this.tableName = function(value) {
            if (value !== undefined) {

                this.tableElement.val(value === null ? "" : value);
                this.onTableChange();

                return null;
            }
            else
                return this.tableElement.val();
        };

        this.onValueChange = function () {
            if (this.element.val() && this.tableElement.val() && !this.options.readonly)
                this.clearFilterButton.show();
            else
                this.clearFilterButton.hide();
        };

        this.onTableChange = function () {
            if (this.tableElement.val()) {
                this.filterButton.show();
                if (this.element.val() && !this.options.readonly)
                    this.clearFilterButton.show();
                else
                    this.clearFilterButton.hide();
            }
            else {
                this.filterButton.hide();
                this.clearFilterButton.hide();
            }
        };
        
        this.onFilterClick = function (e) {
            var tableName = this.tableElement.val();
            var url = '/EmptyPage.aspx/data/' +
                tableName +
                'Filter/Filter?__deniedShortFilters=on&__loadFilterFromParam=on&__customFCN=' +
                tableName +
                'Filter';
            if (tableName.substr(0, 4) === 'PLN_') {
                url = "/DMN/DMN_MonitoringIndicators/Filter?type=Planning.Areas.PLN.ViewModels." + tableName + "ViewModel";
            }
            
            var dialog = $('<div id="ucFiltersWindow" style="margin: 0 0 0 10px;" />');
            document.body.appendChild(dialog[0]);
            var width = $(document).width() * 0.9;
            var d;
            var me = this;
            dialog.kendoWindow({
                width: width + "px",
                height: "600px",
                title: '',
                actions: ["Maximize", "Close"],
                closable: true,
                modal: true,
                iframe: true,
                content: url,
                close: function () {
                    d.destroy();
                },
                open: function (e) {
                    var frame = e.sender.element.find('iframe')[0];
                    frame.contentWindow.dialogArguments = {
                        filterValue: me.element.val() || "[]",
                        filterValueForPostBack: true,
                        closeSelfWindow: false,
                        UpdateFilterValue: function (value) {
                            if (!me.options.readonly) {
                                me.element.val(value);
                                me.element.trigger('change');
                                //me.options.set('Filters', value);
                            }
                        },
                        closeModalDialog: function() {
                            d.close();
                        }
                    };
                    if (frame.contentWindow.InitialLoadFilterFromParam)
                        frame.contentWindow.InitialLoadFilterFromParam();
                    frame.onload = function() {
                        e.sender.title(frame.contentDocument.title);
                    };
                }
            });
            d = dialog.data('kendoWindow');
            d.center();
            d.open();
            
            return false;
        };

        this.onClearFilterClick = function (e) {
            this.element.val('');
            this.element.trigger('change');
            return false;
        };
    },

    HighlightChangedFields: function (element, model, type) {
        
        this.element = element;
        this.element.data('kendoHighlightChangedFields', this);
        this.element.addClass('m-highlight-changed-' + type);
        this.model = model;

        this._init = function() {
            this._onModelChange = $.proxy(this.onModelChange, this);
            this.model.bind('change', this._onModelChange);
            this.onModelChange({ field: '*' });
        };

        this.onModelChange = function(e) {
            if (e.field === '*') {
                var dirtyFields = this.model.dirtyFields;
                for (var f in dirtyFields) {
                    if (dirtyFields.hasOwnProperty(f) && dirtyFields[f]) {
                        this.setChangedField(f, true);
                    }
                }
            }
            else
                this.setChangedField(e.field, true);
        };

        this.setChangedField = function(field, value) {
            var input = this.element.find('#' + field);
            var ddl = input.data('kendoDropDownList');
            if (ddl && ddl.span)
                input = ddl.span.parent();

            if (value)
                input.addClass('m-highlight-changed-field');
            else
                input.removeClass('m-highlight-changed-field');
        };

        this.clear = function() {
            this.element.find('.m-highlight-changed-field').removeClass('m-highlight-changed-field');
        };

        this.destroy = function() {
            if (this.element && this.model) {
                this.clear();
                this.element.removeClass('m-highlight-changed-' + type);
                this.model.unbind('change', this._onModelChange);
                this.element = null;
                this.model = null;
            }
        };

        this._init();
    },

    QRCodeScan: function(element) {
        Nat.Classes.BasePostMethod.call(this, 'QRScan');
        this.element = element;
        this.element.attr('data-role', 'natQRCodeScan');
        this.element.data('kendoNatQRCodeScan', this);
        this.player = element.find('video')[0];
        this.canvas = element.find('canvas')[0];
        this.context = this.canvas.getContext('2d');

        this.Initialize = function() {
            this.element.find('.k-button').on('click', $.proxy(this.getSnapshotAndScan, this));
            this._showFlashCamera = $.proxy(this.showFlashCamera, this);

            if (!navigator.mediaDevices ||
                !navigator.mediaDevices.getUserMedia && !navigator.mediaDevices.webkitGetUserMedia) {

                if (this.player) {
                    $(this.player).remove();
                    this.player = null;
                }
                
                var cam;
                var flashvars = this.getFlashParams();
                // https://github.com/jhuckaby/webcamjs/blob/master/webcam.swf
                if (navigator.userAgent.indexOf('MSIE ') > -1) {
                    cam = '<object id="XwebcamXobjectX" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="640" height="480">' +
                        '<param name="movie" value="/Content/Media/webcam.swf" />';
                } else {
                    cam = '<object id="XwebcamXobjectX" type="application/x-shockwave-flash" data="/Content/Media/webcam.swf" width="640" height="480">';
                }
                cam += '<param name="flashvars" value="' + flashvars + '" />' +
                    '<param name="allowScriptAccess" value="always" />' +
                    '</object>';
                $('<div id="webcam"></div>').insertBefore(this.element.find('.k-button'));


                var me = this;
                window.Webcam = {
                    flashNotify: function(type, msg) {
                        switch (type) {
                        case 'flashLoadComplete':
                            me.flashLoaded = true;
                            break;

                        case 'cameraLive':
                            me.flashCameraLive = true;
                            break;

                        case 'error':
                            if (msg === 'No camera was detected.') {
                                me.alertNotFoundCamera();
                            }
                            else
                                kendo.alert(msg);
                            break;

                        default:
                            // catch-all event, just in case
                            // console.log("webcam flash_notify: " + type + ": " + msg);
                            break;
                        }
                    }
                };

                setTimeout(function() {
                        $('#webcam').html(cam);
                        me.webcam = me.element.find('object')[0];
                    },
                    10);
            }
            else
                this.start();
        };

        this.getFlashParams = function() {
            var params = {
                width: 640,
                height: 480,
                dest_width: 640, // size of captured image
                dest_height: 480, // these default to width/height
                image_format: 'jpeg', // image format (may be jpeg or png)
                jpeg_quality: 90, // jpeg image quality from 0 (worst) to 100 (best)
                flip_horiz: false, // flip image horiz (mirror mode)
                fps: 30 // camera frames per second
            };

            // construct flashvars string
            var flashvars = '';
            for (var key in params) {
                if (flashvars) flashvars += '&';
                flashvars += key + '=' + escape(params[key]);
            }
            return flashvars;
        };

        this.getSnapshotImageData = function() {
            if (this.player && this.player.srcObject) {
                this.context.drawImage(this.player, 0, 0, this.canvas.width, this.canvas.height);
                return this.canvas.toDataURL("image/png");
            }
            else if (this.webcam && this.webcam._snap && this.flashCameraLive) {
                return 'data:image/png;base64,' + this.webcam._snap();
            } else {
                if (this.webcam && !this.flashLoaded)
                    kendo.alert(this.messages.FlashNotLoaded);
                kendo.alert(this.messages.CameraIsNotReady);
            }

            return null;
        };

        this.getSnapshotAndScan = function() {
            var imgData = this.getSnapshotImageData();

            if (imgData) {
                var me = this;
                this.delayImageData = [];
                var pushSnapShot = function() {
                    me.delayImageData.push(me.getSnapshotImageData());
                };
                if (this.flashCameraLive) {
                    setTimeout(pushSnapShot, 100);
                } else {
                    setTimeout(pushSnapShot, 20);
                    setTimeout(pushSnapShot, 40);
                    setTimeout(pushSnapShot, 80);
                    setTimeout(pushSnapShot, 120);
                    setTimeout(pushSnapShot, 180);
                }
                this.post('GetQRCodeFromCanvas', { data: imgData }, $.proxy(this.onScanQRCode, this));
                setTimeout(function() {
                        // скрытие камеры для flash-а, т.к. видео может быть повех всех окон
                        me.hideFlashCamera();
                    },
                    200);
            }

            return false;
        };

        this.onScanQRCode = function(result) {
            if (!result) return;
            var me = this;
            if (!result.success && this.delayImageData.length) {
                this.post('GetQRCodeFromCanvas', { data: this.delayImageData.pop() }, $.proxy(this.onScanQRCode, this));
            }
            else if (result.success) {
                if (!result.searchID) {
                    kendo.alert(kendo.format(this.messages.QRFound, result.text)).one('close', me._showFlashCamera);
                } else {
                    kendo.confirm(kendo.format(this.messages.SearchThis, result.text)).then(function() {
                        me.setSearchID(result.searchID);
                        //me.showFlashCamera();
                        VM.qrCodeScanWindow.close();
                    },
                    function() {
                        me.showFlashCamera();
                    });
                }

                this.delayImageData = [];
            } else {
                kendo.alert(this.messages.TryAgain).one('close', me._showFlashCamera);
            }
        };

        this.hideFlashCamera = function() {
            if (this.webcam) $(this.webcam).css('visibility', 'hidden');
        };

        this.showFlashCamera = function() {
            if (this.webcam) $(this.webcam).css('visibility', '');
        };

        this.setSearchID = function(value) {
            if (this.searchInputID)
                $('#' + this.searchInputID).val(value).trigger('keypress');
        };

        this.alertNotFoundCamera = function() {
            kendo.alert(this.messages.CameraNotFound);
            this.element.find('.k-button').hide();
            setTimeout(function() {
                    VM.qrCodeScanWindow.close();
                },
                1000);
        };

        this.start = function() {
            var me = this;

            // Attach the video stream to the video element and autoplay.
            if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia)
                navigator.mediaDevices.getUserMedia({ video: true })
                    .then(function (stream) {
                        me.player.srcObject = stream;
                    }, function(e) {
                        me.alertNotFoundCamera();
                    });
            else if (navigator.mediaDevices && navigator.mediaDevices.webkitGetUserMedia)
                navigator.mediaDevices.webkitGetUserMedia({ video: true })
                    .then(function(stream) {
                        me.player.srcObject = stream;
                    }, function(e) {
                        me.alertNotFoundCamera();
                    });
        };

        this.stop = function() {
            if (this.player && this.player.srcObject) {
                this.player.srcObject.getVideoTracks().forEach(function (track) {
                    track.stop();
                });
            }
            else if (this.webcam && this.webcam._releaseCamera) {
                this.webcam._releaseCamera();
            }
        };

        this.destroy = function(e) {
            this.stop();
        };
    }
};