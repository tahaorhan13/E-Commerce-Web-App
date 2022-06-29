$.ajax({
    type: 'POST',
    url: "https://localhost:44315/Product/Product/List",
    data: JSON.stringify({ 'Id': productId }),
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (data) {
        for (let z = 0; z <= data.value.length; z++) {
            $(document).on('click', '#add'+z, function (data) {

                var id = this.id;
                console.log(id);
                console.log(z);
                var data = {
                    Name: $("#txtN" + z).html(),
                    Price: $("#txtP"+z).html(),
                    UserId: userId,
                    ProductImage: $("#src"+z).attr('src'),
                };
                console.log(data);
                apiCart.add({ Name: data.Name, Price: data.Price, UserId: data.UserId, ProductImage: data.ProductImage }, function (r) {
                    if (r.Error)
                        return;
                });
            });
        }

    }

});






















