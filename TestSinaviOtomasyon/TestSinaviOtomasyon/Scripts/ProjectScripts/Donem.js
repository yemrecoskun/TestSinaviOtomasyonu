//dönem siler
function donemsil(id) {
    if (confirm("Silmek İstediğinize Eminmisiniz")) {
        $.ajax({
            url: '/Home/DonemSil/' + id,
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


$("#formdonem").hide();

//dönem ekleme ekranini çağırır
function donemeklemeekrani() {
    $("#formdonem").show();
    $("#h3duzenle").hide();
    $("#h3ekle").show();
    $("#eklebtn").show();
    $("#guncellebtn").hide();
    //form reset
    $("#donem_adi").val("");
}

//dönem ekler
function donemekle() {
    var donem_adi = $("input#donem_adi").val();
    var donem_durum = $("input[name='donem_durum']:checked").val();
    $.ajax({
        url: '/Home/DonemEkle',
        type: 'POST',
        data: { donem_adi: donem_adi, donem_durum: donem_durum },
        success: function () {
            $("#formdonem").hide();
            location.reload();
        }
    });
}

//dönem güncelleme ekranini çağırır
function donemguncelleme(id) {
    $("#formdonem").show();
    $("#h3duzenle").show();
    $("#h3ekle").hide();
    $("#eklebtn").hide();
    $("#guncellebtn").show();
    $.ajax({
        url: '/Home/DuzenlenecekDonemBilgileri/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            $("#donem_adi").val(data.donem_adi);
        }
    })
}

//dönemi duzenler
function donemduzenle() {
    var donem_adi = $("input#donem_adi").val();
    var donem_durum = $("input[name='donem_durum']:checked").val();
    $.ajax({
        url: '/Home/DonemDuzenle',
        type: 'POST',
        data: { donem_adi: donem_adi, donem_durum: donem_durum },
        success: function () {
            $("#formdonem").hide();
            location.reload();
        }
    })
}