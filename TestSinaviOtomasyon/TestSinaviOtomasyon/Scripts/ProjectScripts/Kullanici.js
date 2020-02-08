//kullanici siler
function kullanicisil(id) {
    if (confirm("Silmek İstediğinize Eminmisiniz")) {
        $.ajax({
            url: '/Home/KullaniciSil/' + id,
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


$("#formkullanici").hide();

//kullanici ekleme ekranini çağırır
function kullanicieklemeekrani() {
    $("#formkullanici").show();
    $("#h3duzenle").hide();
    $("#h3ekle").show();
    $("#eklebtn").show();
    $("#guncellebtn").hide();
    //form reset
    $("#adi").val("");
    $("#soyadi").val("");
    $("#sicilnumarasi").val("");
    $("#sifre").val("");
}

//kullaniciyi ekler
function kullaniciekle() {
    var kullanici_ad = $("input#adi").val();
    var kullanici_soyadi = $("input#soyadi").val();
    var kullanici_sicilno = $("input#sicilnumarasi").val();
    var kullanici_sifre = $("input#sifre").val();
    $.ajax({
        url: '/Home/KullaniciEkle',
        type: 'POST',
        data: { kullanici_ad: kullanici_ad, kullanici_soyadi: kullanici_soyadi, kullanici_sicilno: kullanici_sicilno, kullanici_sifre: kullanici_sifre },
        success: function () {
            $("#formkullanici").hide();
            location.reload();
        }
    });
}

//kullanici güncelleme ekranini çağırır
function kullaniciguncelleme(id) {
    $("#formkullanici").show();
    $("#h3duzenle").show();
    $("#h3ekle").hide();
    $("#eklebtn").hide();
    $("#guncellebtn").show();
    $.ajax({
        url: '/Home/DuzenlenecekKullaniciBilgileri/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            $("#adi").val(data.kullanici_ad);
            $("#soyadi").val(data.kullanici_soyadi);
            $("#sicilnumarasi").val(data.kullanici_sicilno);
            $("#sifre").val(data.Sifre);
        }
    })
}

//kullaniciyi duzenler
function kullaniciduzenle() {
    var kullanici_ad = $("input#adi").val();
    var kullanici_soyadi = $("input#soyadi").val();
    var kullanici_sicilno = $("input#sicilnumarasi").val();
    var kullanici_sifre = $("input#sifre").val();
    $.ajax({
        url: '/Home/KullaniciDuzenle',
        type: 'POST',
        data: { kullanici_ad: kullanici_ad, kullanici_soyadi: kullanici_soyadi, kullanici_sicilno: kullanici_sicilno, kullanici_sifre: kullanici_sifre },
        success: function () {
            $("#formkullanici").hide();
            location.reload();
        }
    })
}