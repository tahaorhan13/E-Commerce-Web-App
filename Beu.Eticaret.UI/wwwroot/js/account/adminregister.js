var apiUser = new app.api.account.User();

$("#btn-register")
    .on('click', function (e) {
        var data = {
            Name: $("#txtName").val(),
            Surname: $("#txtSurname").val(),
            Email: $("#txtEmail").val(),
            Password: $("#txtPassword").val(),
            AccessLevel: $("#sltAccessLevel").val(),
        };
        apiUser.add({ Name: data.Name, Surname: data.Surname, Email: data.Email, Password: data.Password, AccessLevel: data.AccessLevel }, function (r) {
            if (r.Error)
                return;
            window.location.reload();
        });
    });