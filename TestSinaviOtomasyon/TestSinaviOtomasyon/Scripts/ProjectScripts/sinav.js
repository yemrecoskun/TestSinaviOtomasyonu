//function sinavioku() {
//    var dersatama_id = $("select#dersatama_id").val();
//    var sinav_turu = $("select#sinav_turu").val();
//    //var cevapanahari1 = new XMLHttpRequest();
//    //var cevapanahtari;
//    //cevapanahari1.open("GET", $("#cevapanahtari").val().replace(/C:\\fakepath\\/i, ''), true);
//    //cevapanahari1.onreadystatechange = function () {
//    //    if (cevapanahari1.readyState === 4) {
//    //        cevapanahtari = cevapanahari1.responseText;
//    //    }
//    //}
//    //var frm = document.getElementById("cevapanahtari");
//    //var contents = frm.contentWindow.document.body.childNodes[0].innerHTML;
//    //while (contents.indexOf("\r") >= 0) contents = contents.replace("\r", "");
//    //var lines = contents.split("\n");
//    //alert("Dosya yolu " + frm.src + " içinde  " + lines.length + " satır değer var");
//    //for (var i = 0; i < lines.length; i++) {
//    //    var myLine = lines[i];
//    //    alert("satır " + (i + 1) + " : '" + myLine + "'");
//    //}
//    var cevapanahtari = $("#sinavsonuclari").val();
//    var sinavsonuclari = $("#sinavsonuclari").val();
//    $.ajax({
//        url: '/Home/SinavOku',
//        type: 'POST',
//        data: { dersatama_id: dersatama_id, sinav_turu: sinav_turu, cevapanahtari: cevapanahtari, sinavsonuclari: sinavsonuclari },
//        success: function (data) {
//            if (data == "okundu") {
//                alert("Sınav Zaten Okunmuş");
//            }
//        }
//    });
//}