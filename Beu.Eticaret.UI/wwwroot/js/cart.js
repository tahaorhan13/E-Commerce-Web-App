var userId = parseInt(localStorage.getItem('Id'));


$.ajax({
    type: 'POST',
    url: "https://localhost:44315/Cart/Cart/List",
    data: JSON.stringify({ 'Id': userId }),
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (data) {
        for (let z = 0; z <= data.Value.length; z++) {
            $(document).on('click', '#increment' + z, function (data) {
                var dta = $("#quantity" + z).html();
                var span = $("#price" + z).html();
                var total = $("#total").html();
                dta = parseInt(dta) + 1;
                total = parseInt(total) + (parseInt(span));
                document.getElementById("quantity" + z).innerHTML = dta;
                document.getElementById("total").innerHTML = total;

            });
            $(document).on('click', '#decrement' + z, function (data) {
                var dta = $("#quantity" + z).html();
                var span = $("#price" + z).html();
                var total = $("#total").html();
                dta = parseInt(dta) - 1;
                if (dta == 0) {
                    var dta = {
                        Id: $("#h" + z).html()
                    };
                    apiCart.del({ Id: dta.Id }, function (r) {
                        if (r.Error)
                            return;
                        window.location.reload();
                    });
                }
                total = parseInt(total) - (parseInt(span));
                document.getElementById("quantity" + z).innerHTML = dta;
                document.getElementById("total").innerHTML = total;
            });
        }

    }
});