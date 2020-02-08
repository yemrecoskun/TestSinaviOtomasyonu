//dersatama siler
function dersatamasil(id) {
    if (confirm("Silmek İstediğinize Eminmisiniz")) {
        $.ajax({
            url: '/Home/DersAtamaSil/' + id,
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


$("#formdersatama").hide();

//dersatama ekleme ekranini çağırır
function dersatamaeklemeekrani() {
    $("#formdersatama").show();
    $("#h3duzenle").hide();
    $("#h3ekle").show();
    $("#eklebtn").show();
    $("#guncellebtn").hide();
    //form reset
    $("#kullanici_id").val("Seçiniz");
    $("#bolum_adi").val("Seçiniz");
    $("#donem_adi").val("Seçiniz");
    $("#ders_adi").val("Seçiniz");
}

//dersatama ekler
function dersatamaekle() {
    var kullanici_id = $("select#kullanici_id").val();
    var bolum_adi = $("select#bolum_adi").val();
    var donem_adi = $("select#donem_adi").val();
    var ders_adi = $("select#ders_adi").val();
    $.ajax({
        url: '/Home/DersAtamaEkle',
        type: 'POST',
        data: { kullanici_id: kullanici_id, bolum_adi: bolum_adi, donem_adi: donem_adi , ders_adi: ders_adi },
        success: function () {
            $("#formdersatama").hide();
            location.reload();
        }
    });
}

//dersatama güncelleme ekranini çağırır
function dersatamaguncelleme(id) {
    $("#formdersatama").show();
    $("#h3duzenle").show();
    $("#h3ekle").hide();
    $("#eklebtn").hide();
    $("#guncellebtn").show();
    $.ajax({
        url: '/Home/DuzenlenecekDersAtamaBilgileri/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {

            $("#kullanici_id").val(data.kullanici_id);
            $("#bolum_adi").val(data.bolum_adi);
            $("#donem_adi").val(data.donem_adi);
            $("#ders_adi").val(data.ders_adi);
        }
    })
}

//ders atamayı duzenler
function dersatamaduzenle() {
    var kullanici_id = $("select#kullanici_id").val();
    var bolum_adi = $("select#bolum_adi").val();
    var donem_adi = $("select#donem_adi").val();
    var ders_adi = $("select#ders_adi").val();
    $.ajax({
        url: '/Home/DersAtamaDuzenle',
        type: 'POST',
        data: { kullanici_id: kullanici_id, bolum_adi: bolum_adi, donem_adi: donem_adi, ders_adi: ders_adi },
        success: function () {
            $("#formdersatama").hide();
            location.reload();
        }
    })
}