var apiRole = new app.api.system.Role();

$("#btn-addRole")
    .on('click', function (e) {
        var data = {
            RoleName: $("#txtRoleName").val(),
            AccessLevel: $("#txtAccesLevel").val(),
        };
        apiRole.add({ RoleName: data.RoleName, AccesLevel: data.AccesLevel }, function (r) {
            if (r.Error)
                return;

        });
    });