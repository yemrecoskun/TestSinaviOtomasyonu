//ders siler
function derssil(id) {
    if (confirm("Silmek İstediğinize Eminmisiniz")) {
        $.ajax({
            url: '/Home/DersSil/' + id,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                alert("Silindi");
                var a = "#" + data;
                $(a).remove();
            }
                
        });
    }
};


$("#formders").hide();

//ders ekleme ekranini çağırır
function derseklemeekrani() {
    $("#formders").show();
    $("#h3duzenle").hide();
    $("#h3ekle").show();
    $("#eklebtn").show();
    $("#guncellebtn").hide();
    //form reset
    $("#ders_adi").val("");
}

//ders ekler
function dersekle() {
    var ders_adi = $("input#ders_adi").val();
    $.ajax({
        url: '/Home/DersEkle',
        type: 'POST',
        data: { ders_adi: ders_adi },
        success: function () {
            $("#formders").hide();
            location.reload();
        }
    });
}

//ders güncelleme ekranini çağırır
function dersguncelleme(id) {
    $("#formders").show();
    $("#h3duzenle").show();
    $("#h3ekle").hide();
    $("#eklebtn").hide();
    $("#guncellebtn").show();
    $.ajax({
        url: '/Home/DuzenlenecekDersBilgileri/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            $("#ders_adi").val(data.ders_adi);
        }
    })
}

//dersi duzenler
function dersduzenle() {
    var ders_adi = $("input#ders_adi").val();
    $.ajax({
        url: '/Home/DersDuzenle',
        type: 'POST',
        data: { ders_adi: ders_adi },
        success: function () {
            $("#formders").hide();
            location.reload();
        }
    })
}

//kazanim_turu_id gönderip getirme

function kazanim_turu_id(id) {
    $("ol").find("li").remove();
    $.ajax({
        url: '/Home/DersKazanimTuruId/' + id,
        type: 'POST',
        success: function (data) {
            $.each(data, function (index) {
                if (data[index] != "") {
                    var item = "" + data[index];
                    $("ol").append("<li>" + item + "</li>")
                }
            });
        }
    });
}