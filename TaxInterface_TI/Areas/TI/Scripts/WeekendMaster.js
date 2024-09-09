/**
 * Универсальный календать выходных дней
 * @param vm Окружение
 * @param options Парвметры
 * @param options.gridName Наименование табоицы
 * @param {Array} options.defaultWeekends Массив индексов выходных дней. Понедельник начитается с 0
 * @param {number} options.weekendMasterTypeCode Код текущего тип календаря
 * @constructor
 */
Nat.DIC.WeekendMaster = function (vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_WeekendMaster');
    Nat.ADM.BaseGridSettings.call(this);

    this.options = kendo.observable(options);
    this.element = $('#' + (options.gridName || 'grid'));

    this.Initialize = function () {
        this.grid = this.element.data('kendoGrid');
        this.dataSourceMapDates(['HolidayDate']);
        this.bindProgress(null, this.onRequestEnd);
        this.grid.bind('edit', $.proxy(this.onEdit, this));
        this.read();
    };
    
    this.isHoliday = function(date){
        return options.defaultWeekends.indexOf(date.getDay())  !== -1;
    }

    this.onRequestEnd = function () {
        this._readyData = null;

        var me = this;

        setTimeout(function () {

            var savedValue = null;
            if (me.multiViewCalendar) {
                savedValue = me.multiViewCalendar.value();
                me.multiViewCalendar.destroy();
            }

            me.multiViewCalendar = $("#"+options.gridName+"_multiViewCalendarJS").kendoMultiViewCalendar({
                showViewHeader: true,
                views: 12,
                value: new Date(new Date().getFullYear(), 0, 1),
                month: {
                    content: $("#"+options.gridName+"-cell-template").html()
                }
            }).data('kendoMultiViewCalendar');
            me.multiViewCalendar.value(savedValue);

            me.multiViewCalendar.bind("change", $.proxy(me.calendarChanged, me));

            me.options.currentYear = (new Date()).getFullYear();

            me.multiViewCalendar.navigateToFuture = function() {
                me.options.currentYear++;
                me.options.navigate = true;
                me.multiViewCalendar.value(new Date(me.options.currentYear, 0, 1));
                me.multiViewCalendar.value(null);
                me.options.navigate = false;
                $.proxy(this.read, this);
            };

            me.multiViewCalendar.navigateToPast = function() {
                me.options.currentYear--;
                me.options.navigate = true;
                me.multiViewCalendar.value(new Date(me.options.currentYear, 0, 1));
                me.multiViewCalendar.value(null);
                me.options.navigate = false;
                $.proxy(this.read, this);
            };

            if (!me.readButton) {
                me.readButton = $('<a class="k-button k-button-image"><span class="k-icon k-i-refresh"></span></a>')
                    .on('click', $.proxy(me.onReadClick, me));
                me.readButton.insertBefore(me.multiViewCalendar.element.find('.k-calendar-header .k-title'));
            }
        });
    }

    this.onGetData = function (e) {
        return {
            FilterByTypeCode: this.options.weekendMasterTypeCode,
            FilterByYear: this.options.currentYear
        };
    };

    this.onEdit = function (e) {
        let me = this;
        e.model.set('DateCreated', new Date());
        e.model.set('DateModified', new Date());

        if (e.model.isNew()) {
            Nat.F.SetValue(e.model,
                'HolidayDate',
                { HolidayDate: this.multiViewCalendar.value() },
                kendo.parseDate,
                '{0:dd.MM.yyyy}');
            e.model.set('isHoliday', this.isHoliday(e.model.HolidayDate));
        }

        var editable = this.grid.editable;

        if (e.model.CanReject) {

            $('<a class="k-button k-button-icontext" style="float:left" href="#"></a>')
                .html('<span class="fas fa-thumbs-down"></span> ' + this.options.messages.RejectCalendarDate)
                .on('click', function(ev) {
                    return me.rejectCalendarDate(ev, e.model)
                })
                .insertBefore(editable.element.find('.k-edit-buttons .k-button').first());
        }

        if (e.model.CanApprove) {
            $('<a class="k-button k-button-icontext" style="float:left" href="#"></a>')
                .html('<span class="fas fa-thumbs-up"></span> ' + this.options.messages.ApproveCalendarDate)
                .on('click', function(ev) {
                    return me.approveCalendarDate(ev, e.model)
                })
                .insertBefore(editable.element.find('.k-edit-buttons .k-button').first());
        }
    };

    this.onReadClick = function(e) {
        e.preventDefault();
        this.read();
    };

    this.calendarChanged = function () {

        if (this.options.navigate) {
            return;
        }
        var currentDate = this.multiViewCalendar.value().getTime();
        var inDictionary = this.grid.dataSource.data().filter(x => x.HolidayDate.getTime() === currentDate);

        if (inDictionary.length > 0) {
            this.grid.editRow(this.gridFindTr(inDictionary[0]));
        }
        else {
            this.grid.addRow();
        }
    }

    this.approveCalendarDate = function (e, model) {
        var me = this;

        kendo.confirm(this.options.messages.ConfirmApproveCalendarDate)
            .done(function () {
                me.post('ApproveCalendarDate', { id: model.id });
            });

        return false;
    }

    this.rejectCalendarDate = function (e, model) {
        var me = this;

        kendo.confirm(this.options.messages.ConfirmRejectCalendarDate)
            .done(function () {
                me.post('RejectCalendarDate', { id: model.id });
            });

        return false;
    }

    this.MonthTemplate = function (data) {
        var value = this._readyData;
        if (!value) {
            value = {};

            var gridData = this.grid.dataSource.data();
            for (var i = 0, len = gridData.length; i < len; i++) {
                value[kendo.format('{0:yyyy.MM.dd}', gridData[i].HolidayDate)] = gridData[i];
            }
            this._readyData = value;
        }

        value = value[kendo.format('{0:yyyy.MM.dd}', data.date)];
        if (!value) {
            //покраска суббот воскресений по умолчанию
            var className = this.isHoliday(data.date) ? "calendar-holiday" : "";
            return '<div class=' + className + '>' + data.value + '</div>';
        }

        //отклоненные выходные дни
        if (value.CheckSign === false && value.isHoliday === true)
            return '<div class="calendar-rejected-holiday">' + data.value + '</div>';

        //отклоненные дни
        if (value.CheckSign === false)
            return '<div class="calendar-rejected">' + data.value + '</div>';

        //выходные дни, требующие утверждения/отклонения
        if (value.CheckSign === null && value.isHoliday === true)
            return '<div class="calendar-forApproveReject-holiday">' + data.value + '</div>';

        //рабочии дни, требующие утверждения/отклонения
        if (value.CheckSign === null)
            return '<div class="calendar-forApproveReject">' + data.value + '</div>';

        //явно заданные выходные дни
        if (value.CheckSign === true && value.isHoliday === true)
            return '<div class="calendar-holiday">' + data.value + '</div>';

        return '<div class="">' + data.value + '</div>';
    };
};





