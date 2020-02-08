var soruadedi = 0;
function degerlendir()
{
    var kazanim_adi = $("select#kazanim_turu_id").val();
    var sorular = [];
    $.each($("input[name='sorular']:checked"), function () {
        soruadedi = soruadedi + 1;
        sorular.push($(this).val());
    });
    if (kazanim_adi == "Kazanım Seçiniz") {
        alert("Kazanım Seçiniz");
    }
    else
    {
    $.ajax({
        url: '/Home/KazanimDegerlendirme/' ,
        type: 'POST',
        data: { kazanim_adi: kazanim_adi, sorular: sorular },
        dataType: 'json',
        success: function (data) {
                $('option:selected').hide();
            $('#kazanim_turu_id').val("Kazanım Seçiniz");
            $.each(sorular, function (index) {
                $("#" + sorular[index]).css("color", "green");
            });
            $("input[name='sorular']:checked").prop('checked', false);
        }
        });
    }
}
function degerlendirmetekrarla() {
    location.reload();
}
function bitir1(data) {
    if (confirm("İşlemi Onaylıyor musunuz?")) {
        if (data <= soruadedi) {
        alert("Sınav Başarı ile Okunmuştur.");
        window.location.href = "/Home/OgretimUyesiSayfa";
    }
    else {
        alert("Hata! Sorunun kazanımı seçilmemiş.");
        location.reload();
        }
    }
}
function bitir(data) {
    if (confirm("İşlemi Onaylıyor musunuz?")) {

    if (data <= soruadedi) {
        alert("Sınav Başarı ile Okunmuştur.");
        window.location.href = "/Home/Sinav";
    }
    else {
        alert("Hata! Sorunun kazanımı seçilmemiş. Tekrar Deneyiniz.");
        location.reload();
        }

    }
}