$("#msg").hide();

function admin () {
    var data = $("#loginform").serialize();
    $.ajax({
        type: "post",
        url: "/Home/AdminLogin",
        data: data ,
        success: function (datax) {
            if (datax == "") {

            }
            if (datax == "basarili") {
                window.location.href = "/Home/AnaSayfa";
            }
            else if(datax="basarisiz")
            {
                $("#msg").show();
            }
            
        }
    });
}
function ogretimuyesi() {
    var data = $("#loginform").serialize();
    $.ajax({
        type: "post",
        url: "/Home/OgretimUyesiLogin",
        data: data,
        success: function (datax) {
            if (datax == "") {

            }
            if (datax == "basarili") {
                window.location.href = "/Home/OgretimUyesiSayfa";
            }
            else if (datax == "basarisiz") {
                $("#msg").show();
            }
        }
    });
}