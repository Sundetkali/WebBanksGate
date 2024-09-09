var HomeMenuSelect = function(e) {
    if (e.item.id && e.item.id.substring(0, 8) === "homeMenu" && !$(e.item).hasClass('menu-right')) {
        var ids = JSON.parse($.cookie("homeMenu") || "[]");
        var idsP = JSON.parse($.cookie("homeMenuP") || "[]");
        var addId = parseInt(e.item.id.substring(8));
        var index = ids.indexOf(addId);
        var indexP = idsP.indexOf(addId);
        if (index !== -1) ids.splice(index, 1);
        if (indexP === -1)
            ids.push(addId);

        $.cookie("homeMenu",
            JSON.stringify(ids.length > 30 ? ids.slice(30 - ids.length) : ids),
            { path: "/", expires: 30 });

        $.cookie("homeMenuP",
            JSON.stringify(idsP),
            { path: "/", expires: 30 });
    }
    var href = $(e.item).find('a').attr('href');
    if (!$(e.item).attr('confirmed') && href && href.substr(0, 11) !== 'javascript:') {
        var data = $('.k-grid,.k-treeview');
        for (var j = 0; j < data.length; j++) {
            var item = $(data[j]);
            var g = item.data('kendoGrid') || item.data('kendoTreeView');
            if (g && item.attr('id') !== 'menuTreeView' && g.dataSource && g.dataSource.hasChanges()) {
                e.preventDefault();
                var message = window.CoreLocalization.ConfirmOpenWhenHasChanges;
                kendo.confirm(message).done(function() {
                    $(e.item).attr('confirmed', true);
                    var link = $(e.item).find('a')[0];
                    if (link) link.click();
                });
                break;
            }
        }
    }
};

var HomeMenuPinInLast = function(e) {
    e.preventDefault();

    var me = $(this);
    var link = me.closest('li');
    if (link.length < 0 || link[0].id.substring(0, 8) !== "homeMenu")
        return;

    var linkId = parseInt(link[0].id.substring(8));
    var ids = JSON.parse($.cookie("homeMenu") || "[]");
    var idsP = JSON.parse($.cookie("homeMenuP") || "[]");

    var index = ids.indexOf(linkId);
    var indexP = idsP.indexOf(linkId);

    if (index !== -1) ids.splice(index, 1);
    if (indexP !== -1) idsP.splice(indexP, 1);

    if (me.hasClass('k-i-unpin')) {
        me.removeClass('k-i-unpin').addClass('k-i-pin');
        idsP.splice(0, 0, linkId);
    } else {
        me.removeClass('k-i-pin').addClass('k-i-unpin');
        ids.push(linkId);
    }

    $.cookie("homeMenu",
        JSON.stringify(ids.length > 30 ? ids.slice(30 - ids.length) : ids),
        { path: "/", expires: 30 });

    $.cookie("homeMenuP",
        JSON.stringify(idsP),
        { path: "/", expires: 30 });
};

if (!window.Nat) Nat = {};
Nat.HomeMenu = function() {
    var localStorage = null;
    // Does this browser support localStorage?
    try {
        localStorage = window.localStorage;
    } catch (e) {}

    // Does this browser support sessionStorage?
    try {
        if (!localStorage) localStorage = window.sessionStorage;
    } catch (e) {
        localStorage = {};
    }

    this.TaskCountColor = '';
    this.TaskCount = localStorage["Menu.TaskCount"] ? parseInt(localStorage["Menu.TaskCount"]) : null;
    this.OverdueTaskCount = localStorage["Menu.OverdueTaskCount"] ? parseInt(localStorage["Menu.OverdueTaskCount"]) : null;
    this.OverdueTaskCountColor = this.OverdueTaskCount ? '#ff8468' : '';
    this.NotificationCount = localStorage["Menu.NotificationCount"] ? parseInt(localStorage["Menu.NotificationCount"]) : null;

    this.element = $('#Menu');

    this.Initialize = function() {
        var me = this;

        this.menu = this.element.data('kendoMenu');
        this.planTaskElement = $('#homeMenuPlanTask');
        this.notificationElement = $('#homeMenuADMNotification');
        
        if (this.planTaskElement.length) {
            this.TaskTitleFormat = this.planTaskElement.find('[title-format]').attr('title-format').replace('\n', '<br/>');
            kendo.bind(this.planTaskElement, this);
            this.planTaskTooltip = this.planTaskElement.kendoTooltip({
                position: 'bottom'
            }).data('kendoTooltip');

            setTimeout(function() {
                me.updateTaskCount();
            });
        }

        if (this.notificationElement.length) {
            this.NotificationTitleFormat = this.notificationElement.find('[title-format]').attr('title-format');
            this.notificationElement.on('click',
                function() {
                    if (location.pathname === '/NotifAdm/ADM_EmailNotification')
                        return true;

                    var win = $(window);
                    var w = $('<div/>').kendoWindow({
                        content: '/NotifAdm/ADM_EmailNotification?emptyLayout=true&deferred=true',
                        width: win.width() * 0.9,
                        height: win.height() * 0.9,
                        modal: true,
                        title: window.isKz ? 'Хабарландырулар' : 'Уведомления',
                        close: function() {
                            w.destroy();
                        }
                    }).data('kendoWindow');
                    w.open();
                    w.center();
                    return false;
                });
            kendo.bind(this.notificationElement, this);
            this.notificationTooltip = this.notificationElement.kendoTooltip({
                position: 'bottom'
            }).data('kendoTooltip');

            setTimeout(function() {
                me.updateNotificationCount();
            });
        }

    };

    this.getTaskTitle = function() {
        return kendo.format(this.TaskTitleFormat, this.TaskCount, this.OverdueTaskCount);
    };

    this.getNotificationTitle = function() {
        return kendo.format(this.NotificationTitleFormat, this.NotificationCount);
    };

    this.updateTaskCount = function() {
        if (window.disableTaskCount)
            return;
        var me = this;
        var endDate = kendo.date.today();
        endDate.setHours(23);
        endDate.setMinutes(59);
        $.ajax({
            url: '/PLN/Task/GetTaskCount',
            type: "POST",
            xhrFields: {
                withCredentials: true
            },
            data: {
                filterTaskStatusCode: 'InWork',
                filter_TaskTreeAccess: false,
                filterDateMode: 1,
                filterStartDate: kendo.format('{0:dd.MM.yyyy HH:mm}', kendo.date.today()),
                filterEndDate: kendo.format('{0:dd.MM.yyyy HH:mm}', endDate)
            }
        }).done(function(result) {
            if (result.error) {
                //kendo.alert(result.error);
            } else {
                var showTooltip = me.TaskCount !== null && me.TaskCount !== result.TaskCount;
                me.set('TaskCountChanged', me.TaskCount !== null && result.TaskCount !== me.TaskCount);
                if (me.TaskCountChanged)
                    me.set('TaskCountColor', me.TaskCount > result.TaskCount ? "lime" : "orange");
                else
                    me.set('TaskCountColor', "");
                me.set('TaskCount', result.TaskCount);
                me.planTaskElement.attr('title', me.getTaskTitle());
                localStorage["Menu.TaskCount"] = result.TaskCount;

                if (me.planTaskTooltip.content) me.planTaskTooltip.content.html(me.getTaskTitle());
                if (showTooltip) {
                    me.planTaskTooltip.show();
                    setTimeout(function() { me.planTaskTooltip.hide(); }, 4000);
                }
            }

            setTimeout(function() {
                    me.updateTaskCount();
                },
                30 * 1000);
        }).fail(function(e) {
            e.logErrorToConsole = true;
            errorHandler(e);

            setTimeout(function() {
                    me.updateTaskCount();
                },
                2 * 60 * 1000);
        });
        $.ajax({
            url: '/PLN/Task/GetTaskCount',
            type: "POST",
            xhrFields: {
                withCredentials: true
            },
            data: {
                filterTaskStatusCode: 'Overdue',
                filter_TaskTreeAccess: false
            }
        }).done(function(result) {
            if (result.error) {
                //kendo.alert(result.error);
            } else {
                var showTooltip = me.OverdueTaskCount !== null && me.OverdueTaskCount !== result.TaskCount;
                me.set('OverdueTaskCount', result.TaskCount);
                me.set('OverdueTaskCountColor', result.TaskCount ? '#ff8468' : '');
                me.planTaskElement.attr('title', me.getTaskTitle());
                localStorage["Menu.OverdueTaskCount"] = result.TaskCount;

                if (me.planTaskTooltip.content) me.planTaskTooltip.content.html(me.getTaskTitle());
                if (showTooltip) {
                    me.planTaskTooltip.show();
                    setTimeout(function() { me.planTaskTooltip.hide(); }, 4000);
                }
            }
        }).fail(function(e) {
            e.logErrorToConsole = true;
            errorHandler(e);
        });
    };

    this.updateNotificationCount = function() {
        if (window.disableTaskCount)
            return;

        clearTimeout(this._updateNotificationCountTimer);
        var me = this;
        var endDate = kendo.date.today();
        endDate.setHours(23);
        endDate.setMinutes(59);
        $.ajax({
            url: '/NotifAdm/ADM_EmailNotification/GetNotificationCount',
            type: "POST",
            xhrFields: {
                withCredentials: true
            },
            data: {}
        }).done(function(result) {
            if (result.error) {
                return;
            }
 
            var showTooltip = me.NotificationCount !== null && me.NotificationCount < result.NotificationCount;
            me.set('NotificationCount', result.NotificationCount);
            me.notificationElement.attr('title', me.getNotificationTitle());
            localStorage["Menu.NotificationCount"] = result.NotificationCount;

            if (me.notificationTooltip.content)
                me.notificationTooltip.content.text(me.getNotificationTitle());
            else {
                me.notificationTooltip.one('show',
                    function() { me.notificationTooltip.content.html(me.getNotificationTitle()); });
            }

            if (showTooltip) {
                me.notificationTooltip.show();
                setTimeout(function() { me.notificationTooltip.hide(); }, 4000);
            }

            clearTimeout(me._updateNotificationCountTimer);
            this._updateNotificationCountTimer = setTimeout(function() {
                    me.updateNotificationCount();
                },
                30 * 1000);
        }).fail(function(e) {
            e.logErrorToConsole = true;
            errorHandler(e);

            clearTimeout(me._updateNotificationCountTimer);
            this._updateNotificationCountTimer = setTimeout(function() {
                    me.updateNotificationCount();
                },
                2 * 60 * 1000);
        });
    };

    this.LogoutDelegationUser = function() {
        $.cookie("duser", '', { path: "/", expires: 1 });
        window.location.reload(false);
    };

    this.LoginDelegationUser = function(id) {
        $.cookie("duser", id, { path: "/", expires: 1 });
        window.location.reload(false);
    };
};

var homeMenu = kendo.observable(new Nat.HomeMenu());
kendo.syncReady(function() {
    homeMenu.Initialize();
});