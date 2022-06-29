var apiAuth = new app.api.account.Auth();

$("#btn-login")
    .on("click", function (e) {

        var data = {
            Email: $("#txtEmail").val(),
            Password: $("#txtPassword").val()
        };
        apiAuth.login({ Email: data.Email, Password: data.Password }, function (r) {
            if (r.Error)
                return;
            localStorage.setItem("Access-Token", r.Value.AccessToken);
            localStorage.setItem("Refresh-Token", r.Value.RefreshToken);
            localStorage.setItem("Email", data.Email);
            localStorage.setItem("Id", r.Value.Id);
            localStorage.setItem("AccessLevel", r.Value.AccessLevel);

            var accessLevel = parseInt(localStorage.getItem('AccessLevel'));
            if (accessLevel == 1) {
                window.location.href = "/Home/FileUpload";
            }
            else {
                window.location.href = "/Home/Product";
            }
            

        });

    });
//$("#btn-reg").on("click", function (r) {
//    window.location.href = "Account/Register";
//});
//$("#btn-reset").on("click", function (r) {
//    window.location.href = "Account/EmailControl";
//});
