var apiUser = new app.api.account.User();
var userId = parseInt(localStorage.getItem('Id'));
$("#btn-update")
    .on("click", function (e) {

        var data = {
            Name: $("#txtName").val(),
            Surname: $("#txtSurname").val(),
            Email: $("#txtEmail").val(),
            Password: $("#txtPassword").val(),
        };
        apiUser.update({ 'Id': userId, Name: data.Name, Surname: data.Surname, Email: data.Email, Password: data.Password }, function (r) {
            if (r.Error)
                return;
            window.location.reload()
        });

    });