var userId = parseInt(localStorage.getItem('Id'));


$.ajax({
    type: 'POST',
    url: "https://localhost:44315/Cart/Cart/List",
    data: JSON.stringify({ 'Id': userId }),
    contentType: "application/json; charset=utf-8",
    dataType: "json",
    success: function (data) {
        //for (let z = 0; z <= data.Value.length; z++) {
        //    console.log(data.Value[z].Id);
            
        //    console.log(cart);
                    
        //}
        for (let z = 0; z <= data.Value.length; z++) {
            $(document).on('click', '#del'+z, function (data) {                
                var dta = {
                    Id: $("#h"+z).html()
                };
                apiCart.del({ Id: dta.Id }, function (r) {
                    if (r.Error)
                        return;
                    window.location.reload();
                });
            });
        }
        
    }
});