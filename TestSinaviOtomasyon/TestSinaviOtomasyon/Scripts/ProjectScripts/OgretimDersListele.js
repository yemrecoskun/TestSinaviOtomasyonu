function sinav_vize(dersatama_id) {
    var sinav_turu = "vize";
    $.ajax({
        url: '/Home/SinavCagir/',
        type: 'POST',
        data: { dersatama_id: dersatama_id, sinav_turu: sinav_turu },
        dataType: 'json',
        success: function (data) {
            if (data == "Dosya Bulunamadı")
                alert("Sınav Henüz Okunmamış");
        }
    });
}
function sinav_final(dersatama_id) {
    var sinav_turu = "final";
    $.ajax({
        url: '/Home/SinavCagir/',
        type: 'POST',
        data: { dersatama_id: dersatama_id, sinav_turu: sinav_turu },
        dataType: 'json',
        success: function (data) {
            if (data == "Dosya Bulunamadı")
                alert("Sınav Henüz Okunmamış");
        }
    });
}
function sinav_butunleme(dersatama_id) {
    var sinav_turu = "butunleme";
    $.ajax({
        url: '/Home/SinavCagir/',
        type: 'POST',
        data: { dersatama_id: dersatama_id, sinav_turu: sinav_turu },
        dataType: 'json',
        success: function (data) {
            if (data == "Dosya Bulunamadı")
                alert("Sınav Henüz Okunmamış");
        }
    });
}