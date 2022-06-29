app.api.cart = {};

app.api.cart.Cart = function () {
    this.__proto__ = new app.api.Core(app.module.cr, "Cart");
    this.add = function (p, d, f, a) { this.send('Add', p, d, f, a); };
    this.list = function (p, d, f, a) { this.send('List', p, d, f, a); };
    this.del = function (p, d, f, a) { this.send('Delete', p, d, f, a); };
};