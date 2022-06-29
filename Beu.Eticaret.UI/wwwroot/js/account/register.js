var apiUser = new app.api.account.User();

$("#btn-register")
    .on('click', function (e) {
        var data = {
            Name: $("#txtName").val(),
            Surname: $("#txtSurname").val(),
            Email: $("#txtEmail").val(),
            Password: $("#txtPassword").val(),
        };
        apiUser.add({ Name: data.Name, Surname: data.Surname, Email: data.Email, Password: data.Password }, function (r) {
            if (r.Error)
                return;
            window.location.href = "/Home/Login";
        });
    });

var modal = document.getElementById('myModal');

// Kipi açan düğmeyi al
var btn = document.getElementById("btn-register");

// Kipi kapatan <span> öğesini edinin
var span = document.getElementsByClassName("close")[0];

// Kullanıcı düğmeyi tıklattığında
btn.onclick = function () {
    modal.style.display = "block";
}

// Kullanıcı <span> (x) düğmesini tıkladığında, popup
span.onclick = function () {
    modal.style.display = "none";
}

// Kullanıcı modelden başka herhangi bir yeri tıklattıysa, onu kapatın.
window.onclick = function (event) {
    if (event.target == modal) {
        modal.style.display = "none";
    }
}