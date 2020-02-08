//kazanim siler
function kazanimsil(id) {
    if (confirm("Silmek İstediğinize Eminmisiniz")) {
        $.ajax({
            url: '/Home/KazanimSil/' + id,
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


$("#formkazanim").hide();

//kazanim ekleme ekranini çağırır
function kazanimeklemeekrani() {
    $("#formkazanim").show();
    $("#h3duzenle").hide();
    $("#h3ekle").show();
    $("#eklebtn").show();
    $("#guncellebtn").hide();
    //form reset
    $("#kazanim_turu").val("Seçiniz");
    $("#kazanim_turu_id").val("");
    $("#kazanim_adi").val("");
}

//kazanim ekler
function kazanimekle() {
    var kazanim_turu = $("select#kazanim_turu").val();
    var kazanim_turu_id = $("input#kazanim_turu_id").val();
    var kazanim_adi = $("input#kazanim_adi").val();
    $.ajax({
        url: '/Home/KazanimEkle',
        type: 'POST',
        data: { kazanim_turu: kazanim_turu, kazanim_turu_id: kazanim_turu_id, kazanim_adi: kazanim_adi },
        success: function () {
            $("#formkazanim").hide();
            location.reload();
        }
    });
}

//kazanim güncelleme ekranini çağırır
function kazanimguncelleme(id) {
    $("#formkazanim").show();
    $("#h3duzenle").show();
    $("#h3ekle").hide();
    $("#eklebtn").hide();
    $("#guncellebtn").show();
    $.ajax({
        url: '/Home/DuzenlenecekKazanimBilgileri/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            $("#kazanim_turu").val(data.kazanim_turu);
            $("#kazanim_turu_id").val(data.kazanim_turu_id);
            $("#kazanim_adi").val(data.kazanim_adi);
        }
    })
}

//kazanimi duzenler
function kazanimduzenle() {
    var kazanim_turu = $("select#kazanim_turu").val();
    var kazanim_turu_id = $("input#kazanim_turu_id").val();
    var kazanim_adi = $("input#kazanim_adi").val();
    $.ajax({
        url: '/Home/KazanimDuzenle',
        type: 'POST',
        data: { kazanim_turu: kazanim_turu, kazanim_turu_id: kazanim_turu_id, kazanim_adi: kazanim_adi },
        success: function () {
            $("#formkazanim").hide();
            location.reload();
        }
    })
}