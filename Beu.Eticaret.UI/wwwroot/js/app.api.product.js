app.api.product = {};

app.api.product.Product = function () {
    this.__proto__ = new app.api.Core(app.module.cr, "Product");
    this.add = function (p, d, f, a) { this.send('Add', p, d, f, a); };
};