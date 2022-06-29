var app = {};
app.globals = {
    dir: '',
    root: '../',
    api: 'https://localhost:44315',
    version: '1.0.0.0',
};
app.module = {
    acc: "Account",
    sys: "System",
    cr: "Cart",
};
app.utility = {
    transferValues: function (sourceObj, destinationObj) {
        for (key in destinationObj) {
            destinationObj[key] = sourceObj[key] !== undefined ? sourceObj[key] : null;
        }
    },
    generateUUID: function () {
        var d = new Date().getTime();
        var uuid = 'xxxxxxxxxxxx4xxxyxxxxxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
            var r = (d + Math.random() * 16) % 16 | 0;
            d = Math.floor(d / 16);
            return (c === 'x' ? r : (r & 0x3 | 0x8)).toString(16);
        });
        return uuid;
    }
};
