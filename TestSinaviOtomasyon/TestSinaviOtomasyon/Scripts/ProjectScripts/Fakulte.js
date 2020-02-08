//fakülte siler
function fakultesil(id) {
    if (confirm("Silmek İstediğinize Eminmisiniz")) {
        $.ajax({
            url: '/Home/FakulteSil/' + id,
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


$("#formfakulte").hide();

//fakülte ekleme ekranini çağırır
function fakulteeklemeekrani() {
    $("#formfakulte").show();
    $("#h3duzenle").hide();
    $("#h3ekle").show();
    $("#eklebtn").show();
    $("#guncellebtn").hide();
    //form reset
    $("#fakulte_adi").val("");
}

//fakulte ekler
function fakulteekle() {
    var fakulte_ad = $("input#fakulte_adi").val();
    $.ajax({
        url: '/Home/FakulteEkle',
        type: 'POST',
        data: { fakulte_ad: fakulte_ad},
        success: function () {
            $("#formfakulte").hide();
            location.reload();
        }
    });
}

//fakülte güncelleme ekranini çağırır
function fakulteguncelleme(id) {
    $("#formfakulte").show();
    $("#h3duzenle").show();
    $("#h3ekle").hide();
    $("#eklebtn").hide();
    $("#guncellebtn").show();
    $.ajax({
        url: '/Home/DuzenlenecekFakulteBilgileri/' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            $("#fakulte_adi").val(data.fakulte_ad);
        }
    })
}

//fakülteyi duzenler
function fakulteduzenle() {
    var fakulte_ad = $("input#fakulte_adi").val();
    $.ajax({
        url: '/Home/FakulteDuzenle',
        type: 'POST',
        data: { fakulte_ad: fakulte_ad},
        success: function () {
            $("#formfakulte").hide();
            location.reload();
        }
    })
}