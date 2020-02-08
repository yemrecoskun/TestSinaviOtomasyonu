//bölüm siler
function bolumsil(id) {
    if (confirm("Silmek İstediğinize Eminmisiniz")) {
        $.ajax({
            url: '/Home/BolumSil/' + id,
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


$("#formbolum").hide();

//bölüm ekleme ekranini çağırır
function bolumeklemeekrani() {
    $("#formbolum").show();
    $("#h3duzenle").hide();
    $("#h3ekle").show();
    $("#eklebtn").show();
    $("#guncellebtn").hide();
    //form reset
    $("#fakulte_adi").val("Seçiniz");
    $("#bolum_ad").val("");
}

//bölüm ekler
function bolumekle() {
    var fakulte_adi = $("select#fakulte_adi").val();
    var bolum_ad = $("#bolum_ad").val();
    $.ajax({
        url: '/Home/BolumEkle',
        type: 'POST',
        data: { fakulte_adi: fakulte_adi, bolum_ad: bolum_ad },
        success: function () {
            $("#forumbolum").hide();
            location.reload();
        }
    });
}

//bölüm güncelleme ekranini çağırır
function bolumguncelleme(id) {
    $("#formbolum").show();
    $("#h3duzenle").show();
    $("#h3ekle").hide();
    $("#eklebtn").hide();
    $("#guncellebtn").show();
    $.ajax({
        url: '/Home/DuzenlenecekBolumBilgileri/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            $("#fakulte_adi").val(data.fakulte_adi);
            $("#bolum_ad").val(data.bolum_ad);
        }
    })
}

//bölümü duzenler
function bolumduzenle() {
    var fakulte_adi = $("select#fakulte_adi").val();
    var bolum_ad = $("input#bolum_ad").val();
    $.ajax({
        url: '/Home/BolumDuzenle',
        type: 'POST',
        data: { bolum_ad: bolum_ad, fakulte_adi: fakulte_adi },
        success: function () {
            $("#formbolum").hide();
            location.reload();
        }
    })
}

//kazanim_turu_id gönderip getirme

function kazanim_turu_id(id) {
    $("ol").find("li").remove();
    $.ajax({
        url: '/Home/BolumKazanimTuruId/' + id,
        type: 'POST',
        success: function (data) {
            $.each(data, function (index) {
                if (data[index] != "") {
                    var item = ""+data[index];
                    $("ol").append("<li>" + item + "</li>")
                }
            });
        }
    });
}