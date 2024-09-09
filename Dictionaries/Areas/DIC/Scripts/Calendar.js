Nat.DIC.Calendar = function (vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_Calendar');
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

    this.onRequestEnd = function () {
        this._readyData = null;

        var me = this;
        
        setTimeout(function () {

            var savedValue = null;
            if (me.multiViewCalendar) {
                savedValue = me.multiViewCalendar.value();
                me.multiViewCalendar.destroy();
            }

            $("#multiViewCalendarJS").kendoMultiViewCalendar({
                showViewHeader: true,
                views: 12,
                value: new Date(new Date().getFullYear(), 0, 1),
                month: {
                    content: $("#cell-template").html()
                }
            });

            me.multiViewCalendar = $("#multiViewCalendarJS").data("kendoMultiViewCalendar");
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
            FilterByYear: this.options.currentYear
        };
    };
    
    this.onEdit = function (e) {
        e.model.set('DateCreated', new Date());
        e.model.set('DateModified', new Date());

        if (e.model.isNew()) {
            Nat.F.SetValue(e.model,
                'HolidayDate',
                { HolidayDate: this.multiViewCalendar.value() },
                kendo.parseDate,
                '{0:dd.MM.yyyy}');
            e.model.set('isHoliday', e.model.HolidayDate.getDay() === 0 || e.model.HolidayDate.getDay() === 6);
        }

        var editable = this.grid.editable;
        
        if (e.model.CanReject) {

            $('<a class="k-button k-button-icontext" style="float:left" href="#"></a>')
                .html('<span class="fas fa-thumbs-down"></span> ' + this.options.messages.RejectCalendarDate)
                .on('click', $.proxy(this.rejectCalendarDate, this))
                .insertBefore(editable.element.find('.k-edit-buttons .k-button').first());
        }

        if (e.model.CanApprove) {
            $('<a class="k-button k-button-icontext" style="float:left" href="#"></a>')
                .html('<span class="fas fa-thumbs-up"></span> ' + this.options.messages.ApproveCalendarDate)
                .on('click', $.proxy(this.approveCalendarDate, this))
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
        //var currentDate = this.multiViewCalendar.value().getTime();
        //var inDictionary = this.grid.dataSource.data().filter(x => x.HolidayDate.getTime() === currentDate);
        var currentDate = this.multiViewCalendar.value().toLocaleDateString(); // Приводим к UTC
        var inDictionary = this.grid.dataSource.data().filter(x => x.HolidayDate.toLocaleDateString() === currentDate);

        if (inDictionary.length > 0) {
            this.grid.editRow(this.gridFindTr(inDictionary[0]));
        }
        else {
            this.grid.addRow();
        }
    }

    this.approveCalendarDate = function () {
        var me = this;
        var currentDate = this.multiViewCalendar.value();

        kendo.confirm(this.options.messages.ConfirmApproveCalendarDate)
            .done(function () {
                me.post('ApproveCalendarDate', { currentDate: kendo.format('{0:dd.MM.yyyy}', currentDate) });
            });

        return false;
    }

    this.rejectCalendarDate = function () {
        var me = this;
        var currentDate = this.multiViewCalendar.value();

        kendo.confirm(this.options.messages.ConfirmRejectCalendarDate)
            .done(function () {
                me.post('RejectCalendarDate', { currentDate: kendo.format('{0:dd.MM.yyyy}', currentDate) });
            });

        return false;
    }
};


Nat.DIC.MonthTemplate = function (data) {
    var value = VM.DIC_Calendar._readyData;
    if (!value) {
        value = {};

        var gridData = VM.DIC_Calendar.grid.dataSource.data();
        for (var i = 0, len = gridData.length; i < len; i++) {
            value[kendo.format('{0:yyyy.MM.dd}', gridData[i].HolidayDate)] = gridData[i];
        }
        VM.DIC_Calendar._readyData = value;
    }

    value = value[kendo.format('{0:yyyy.MM.dd}', data.date)];
    if (!value) {
        //покраска суббот воскресений по умолчанию
        var className = data.date.getDay() === 0 || data.date.getDay() === 6 ? "calendar-holiday" : "";
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


