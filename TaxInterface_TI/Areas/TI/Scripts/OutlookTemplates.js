Nat.DIC.OutlookTemplates = function(vm, options) {
    Nat.Classes.SimpleGridController.call(this, 'DIC/DIC_OutlookTemplates'); 
    Nat.ADM.BaseGridSettings.call(this);

    this.options = kendo.observable(options);
    this.element = $('#'+ (options.gridName || 'grid'));

    this.Initialize = function() {
        this.grid = this.element.data('kendoGrid');
        this.bindProgress();

        this.grid.bind('edit', $.proxy(this.onEdit, this));
        this.grid.dataSource.bind('change', $.proxy(this.onChange, this));
        this.gridEditScrollTemplate();

        this.InitializeGridSettings();
    };

    this.onEdit = function(e) {
        this.resizeWindow({
            width: parseInt($(window).width() * 0.7),
            height: parseInt($(window).height() * 0.8)
        });

        this.onModelChange({ field: '*', model: e.model });
    };

    this.onChange = function(e) {
        if (e.action === 'itemchange') {
            this.onModelChange({ field: e.field, model: e.items[0] });
        }
    };

    this.onModelChange = function(e) {
        if (e.field === '*' || e.field === 'OneTemplate') {
            this.ToggleField('TemplateEn', !e.model.OneTemplate);
            this.ToggleField('TemplateKz', !e.model.OneTemplate);
        }
    };
};