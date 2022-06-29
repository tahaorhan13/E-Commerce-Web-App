app.api.account = {};
app.api.account.User = function () {
    this.__proto__ = new app.api.Core(app.module.acc, "User");

    this.get = function (p, d, f, a) {
        this.send(p, d, f, a);
    };
    this.getuser = function (p, d, f, a) {
        this.send('GetUser',p, d, f, a);
    };
    this.add = function (p, d, f, a) {
        this.send('Add', p, d, f, a);
    };
    this.update = function (p, d, f, a) {
        this.send('Update', p, d, f, a);
    };
    this.resetPassword = function (p, d, f, a) {
        this.send('ResetPassword', p, d, f, a);
    };
    this.changePassword = function (p, d, f, a) {
        this.send('ChangePassword', p, d, f, a);
    };
    this.delete = function (p, d, f, a) {
        this.send('Delete', p, d, f, a);
    };
    this.list = function (p, d, f, a) {
        this.send('List', p, d, f, a);
    };
};
app.api.account.Auth = function () {
    this.__proto__ = new app.api.Core(app.module.acc, "Auth");
    this.login = function (p, d, f, a) {
        this.send('Login', p, d, f, a);
    };
    this.createtokenbyrefreshtoken = function (p, d, f, a) {
        this.send('CreateTokenByRefreshToken', p, d, f, a);
    };
    this.revokerefreshtoken = function (p, d, f, a) {
        this.send('RevokeRefreshToken', p, d, f, a);
    };
};