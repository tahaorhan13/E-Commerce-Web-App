app.api.system = {};
app.api.system.Role = function () {
    this.__proto__ = new app.api.Core(app.module.sys, "Role");

    this.get = function (p, d, f, a) {
        this.send(p, d, f, a);
    };
    this.add = function (p, d, f, a) {
        this.send('Add', p, d, f, a);
    };
    this.update = function (p, d, f, a) {
        this.send('Update', p, d, f, a);
    };
    this.resetPassword = function (p, d, f, a) {
        this.send('Save', p, d, f, a);
    };
    this.delete = function (p, d, f, a) {
        this.send('Delete', p, d, f, a);
    };
};

app.api.system.Menu = function () {
    console.log("girdi");
    this.__proto__ = new app.api.Core(app.module.sys, "Menu");
    this.list = function (p, d, f, a) { this.send('List', p, d, f, a); };
    this.transferRecordParameterValues = function (e) {
        var p = {
            'Id': null,
            'RoutingUrl': null,
            'Name': null,
            'AccessLevel': null,
        };
        app.utility.transferValues(e.data, p);
        return p;
    };
};