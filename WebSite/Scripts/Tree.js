if (!window.Nat) window.Nat = {};
if (!Nat.Main) Nat.Main = {};

Nat.Main.TreeLeftMenu = function () {

    var model = this;
    var me = this;
    
    this.Initizlize = function () {
        this.menu = $('#menuTreeView').data('kendoTreeView');
        this.tab = $('#treeTab').data('kendoTabStrip');

        model.tab.tabGroup.on("click", "[data-type='remove']", model.TabClose);
        $('#menuTreeQuickSearch').keyup(model.OnTreeQuickSearchChange);

        this.menu.dataSource.bind('requestStart', $.proxy(this.onRequestStart, this));
        this.menu.dataSource.bind('requestEnd', $.proxy(this.onRequestEnd, this));
        this.requestStarted = 0;
        this._CloseNotExistsTabs = $.proxy(this.CloseNotExistsTabs, this);

        this.read();
    };

    this.MenuSelect = function () {
        var dataItem = this.menu.dataItem(this.menu.current());
        if (!dataItem.Url) {
            if (dataItem.hasChildren)
                this.menu.expand(this.menu.current());
            return;
        }
        if (dataItem.OpenWindow) {
            var win = window.open(dataItem.Url, '_blank');
            win.focus();
            return;
        }

        this.OpenTab(dataItem);
    };

    this.OpenTabByUrl = function(url) {
        var data = this.menu.dataSource.data();
        var dataItem = this.SearchMenuByUrl(data, url);
        if (dataItem) {
            this.OpenTab(dataItem);
            return true;
        }

        return false;
    };

    this.SearchMenuByUrl = function(data, url) {
        for (var i = 0; i < data.length; i++) {
            var dataItem = data[i];
            if (dataItem.Url && dataItem.Url.indexOf(url) === 0) {
                return dataItem;
            }

            if (dataItem.hasChildren && dataItem.children && dataItem.children.data) {
                var res = this.SearchMenuByUrl(dataItem.children.data(), url);
                if (res) return res;
            }
        }

        return null;
    };

    this.OpenTab = function(tabOptions, data) {
        if (data && data.openId) {
            tabOptions.set('Url', tabOptions.Url + (tabOptions.Url.indexOf('?') > -1 ? '&openId=' : '?opendId=') + data.openId);
        }
        if (data && data.openIdSort) {
            tabOptions.set('Url', tabOptions.Url + (tabOptions.Url.indexOf('?') > -1 ? '&openIdSort=' : '?openIdSort=') + data.openIdSort);
        }

        var search = '[data-content-url="' + tabOptions.Url + '"]';
        if ($(search).length === 0) {
            if (this.progressTab)
                this.progressTab.remove();

            this.tab.append({
                 text: tabOptions.name, 
                 contentUrl: tabOptions.Url, 
                 encoded: tabOptions.HtmlEncode == null ? true : tabOptions.HtmlEncode,
                 selected: true
            });
            $(search).attr('title',
                tabOptions.HtmlEncode === false ? $('<span>' + tabOptions.name + '</span>').text() : tabOptions.name);
            resizeAll();
            if (tabOptions.id)
                $(search).parent().attr('dataItem-id', tabOptions.id);
            this.ConfigureCloseTab();

            if (!this.progressTab) {
                this.progressTab = $('<div style="height: 100%; position: relative;" role="nottabpanel" />');
                this.tab.element.append(this.progressTab);
                kendo.ui.progress(this.progressTab, true);
            } else {
                this.tab.element.append(this.progressTab);
            }
            
            this.tab.contentElements = this.tab.wrapper.children('div.k-content');
        }

        console.log('OpenTab: ' + tabOptions.Url);
        this.tab.select($(search).parent());
        this._selectTab = search;
        clearTimeout(this._selectTabTimeOut);
        this._selectTabTimeOut = setTimeout(function() {
                console.log('OpenTab in time out: ' + tabOptions.Url);
                me.tab.select($(search).parent());
            },
            1000);
    };

    this.TabSelect = function(e) {
        var id = $(e.item).attr('dataItem-id');
        if (!id) return;
        var dataItem = model.menu.dataSource.get(id);
        if (!dataItem) return;
        console.log('TabSelect: ' + dataItem.Url);
        model.menu.select(model.menu.findByUid(dataItem.uid));
    };

    this.TabClose = function(e) {
        e.preventDefault();
        e.stopPropagation();
        model.closeTabByItem($(e.target).closest(".k-item"));
    };

    this.closeTabByItem = function(tabItem) {
        var tabIndex = tabItem.index();
        if (tabIndex < 0)
            return;

        this.tab.remove(tabIndex);

        if (this.tab.items().length > 0 && tabItem.hasClass('k-state-active')) {
            this.tab.select(tabIndex > 0 ? tabIndex - 1 : tabIndex);
        } else if (this.tab.items().length === 0) {
            this.menu.select(-1);
            $('#treeSplitter').data('kendoSplitter').expand($('#treeLeftMenu'));
            if (this.progressTab)
                this.progressTab.remove();
        }

        var url = $(tabItem).find('[data-content-url]').attr('data-content-url');
        var windows = $('.k-window > [data-role="window"][openWindowUrl="' + url + '"]');
        windows.each(function() {
            $(this).data('kendoWindow').destroy();
        });
    };

    this.closeTabById = function(id) {
        this.closeTabByItem(this.tab.tabGroup.find('.k-item[dataItem-id="' + id + '"]'));
    };

    this.TabContentLoad = function(e) {
        var url = $(e.item).find('.k-link').data('content-url');
        console.log('TabContentLoad: ' + url);
        AddTooltipAllowSaveNoHistory($(e.contentElement), true);
    };
    
    this.ConfigureCloseTab = function() {
        var appended = false;
        model.tab.tabGroup.find('li[role="tab"]').each(function(index, item) {
            if ($(item).find('span[data-type="remove"]').length === 0) {
                $(item).append('<span data-type="remove" class="k-link"><span class="k-icon k-i-x"></span></span>');
                appended = true;
            }
        });

        if (appended) model.tab.resize();
    };
    
    this.OnTreeQuickSearchChange = function() {
        var filterText = $('#menuTreeQuickSearch').val();
        model.menu.dataSource.filter({ field: 'name', operator: 'contains', value: filterText });
    };

    this.OpenById = function(id, data) {
        var dataItem = this.menu.dataSource.get(id);
        if (!dataItem) {
            if (!data) data = {};
            if (!data.delayNumber) data.delayNumber = 1;
            else data.delayNumber++;

            if (data.delayNumber < 25) {
                var me = this;
                setTimeout(function() {
                        me.OpenById(id, data);
                    },
                    200);
            }

            return;
        }

        var expandParent = dataItem.refParent ? this.menu.dataSource.get(dataItem.refParent) : null;
        while (expandParent) {
            this.menu.expand(this.menu.findByUid(expandParent.uid));
            expandParent = expandParent.refParent ? this.menu.dataSource.get(expandParent.refParent) : null;
        }
        this.menu.select(this.menu.findByUid(dataItem.uid));
        this.OpenTab(dataItem, data);
    };

    this.onRequestStart = function(e) {
        if (!this.requestStarted) {
            kendo.ui.progress($('#treeLeftMenu'), true);
        }
        this.requestStarted++;
        clearTimeout(this._CloseNotExistsTabsId);
    };

    this.onRequestEnd = function(e) {
        this.requestStarted--;
        if (this.requestStarted === 0) {
            kendo.ui.progress($('#treeLeftMenu'), false);
            clearTimeout(this._CloseNotExistsTabsId);
            if (!e.sender.filter())
                this._CloseNotExistsTabsId = setTimeout($.proxy(this.CloseNotExistsTabs, this), 100);
        }
    };

    this.CloseNotExistsTabs = function() {
        var tabs = this.tab.items();
        var ds = this.menu.dataSource;
        var selectOtherTab = false;
        for (var i = tabs.length - 1; i >= 0; i--) {
            var tab = $(tabs[i]);
            var id = tab.attr('dataItem-id');
            var dataItem = ds.get(id);
            if (!dataItem) {
                if (tab.hasClass('k-state-active'))
                    selectOtherTab = true;

                this.closeTabByItem(this.tab.tabGroup.find('.k-item:eq(' + i + ')'));
            }
        }

        if (selectOtherTab) {
            this.tab.select(this.tab.items().length > 0 ? 0 : -1);
            /*if (!this.tab.items().length && this.progressTab)
                this.progressTab.remove();*/
        } else if (this._saveCurrentId) {
            var savedDataItem = this.menu.dataSource.get(this._saveCurrentId);
            if (savedDataItem)
                this.menu.select(this.menu.findByUid(savedDataItem.uid));
        }

        setTimeout(this.OnTreeQuickSearchChange, 100);
    };

    this.read = function() {
        this.menu.dataSource.filter([]);
        var dataItem = this.menu.dataItem(this.menu.select());
        if (dataItem)
            this._saveCurrentId = dataItem.CombineId;
        this.expdnedIds = this._getExpanded();
        this.menu.dataSource.read();
    };

    this.getExpanded = function() {
        return this.expdnedIds || [];
    };

    this._getExpanded = function() {
        var ids = [];
        var iterateFn = function(data) {
            data.forEach(function(item) {
                if (item.expanded)
                    ids.push(item.id);

                if (item.hasChildren && item.Data && item.Data.length) {
                    iterateFn(item.Data);
                }
            });
        };
        iterateFn(this.menu.dataSource.data());
        return ids;
    }
};

var tabStripElement = $("#treeTab");
var treeSplitterElement = $('#treeSplitter');

var resizeAll = function () {
    treeSplitterElement.data('kendoSplitter').resize();
    expandContentDivs(tabStripElement, tabStripElement.children(".k-content"));
};

kendo.syncReady(function () {

    if (!window.VM) window.VM = {};
    VM.treeLeftMenu = new Nat.Main.TreeLeftMenu();

    tabStripElement.parent().attr("id", "treeTab-parent").addClass('tabStrip-h-100P');
    tabStripElement.addClass('tabStrip-h-100P');

    treeSplitterElement.data('kendoSplitter').bind('resize', resizeAll);
    resizeAll();
    
    VM.treeLeftMenu.Initizlize();
});
