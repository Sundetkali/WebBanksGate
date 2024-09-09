Nat.DIC.Countries = function (vm, options) {

    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_Countries');
    Nat.ADM.BaseGridSettings.call(this);

    this.options = kendo.observable(options);
    this.element = $('#' + (options.gridName || 'grid'));

    this.Initialize = function () {

        this.grid = this.element.data('kendoGrid');
        this.bindProgress();

        this.grid.bind('edit', $.proxy(this.onEdit, this));
        this.gridEditScrollTemplate();

        this.InitializeGridSettings();
    };

    this.onEdit = function (e) {
        this.resizeWindow({
            width: parseInt($(window).width() * 0.7),
            height: parseInt($(window).height() * 0.8)
        });
    };


};