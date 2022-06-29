var apiProduct = new app.api.product.Product();

$("form")
    .submit(function (e) {
        var x = $("#file-Add").val().substr(12);
        var data = {
            ProductName: $("#txtProductName").val(),
            ProductPrice: $("#txtProductPrice").val(),
            ProductImage: "/images/" + x,
        };
        console.log(e);
        $.ajax({
            type: 'POST',
            url: "https://localhost:44315/Product/Bileklik/Add",
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                window.alert("yüklendi");
            },
        });
    });


















