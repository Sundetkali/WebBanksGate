Nat.DIC.ClientsSelection = function(vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_Clients'); 
    Nat.ADM.BaseGridSettings.call(this);

    this.options = kendo.observable(options);
    this.element = $('#'+ (options.gridName || 'grid'));
    var me = this;

    this.Initialize = function() {
        this.grid = this.element.data('kendoGrid');
        this.grid.bind('dataBound', $.proxy(this.onDataBound, this));
        this.bindProgress();
        this.bindGetData();
        this.bindSelectionChange();

        this.InitializeGridSettings();
    };

    this.onGetData = function() {
        return {
            Filter_SearchValue: $('#' + this.options.gridName + '_SearchInput').val(),
            FilterByWithoutBreach: this.options.FilterByWithoutBreach
        }
    };
    
    this.onSelectionChange = function(e) {
        var selected = this.getSelected();
        
        if (this.options.nextSelection && vm[this.options.nextSelection]) {
            vm[this.options.nextSelection].setClient(selected);
        }
    };

    this.onDataBound = function (e) {
        this.grid.tbody.find('tr').each(function() {
            var tr = $(this);
            var dataItem = me.grid.dataItem(tr);
            tr.toggleClass('dic-client-closed', dataItem && dataItem.Status === 1);
        });
    };
};