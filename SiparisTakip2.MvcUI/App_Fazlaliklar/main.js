
var IslemSonucTurleri = {
    Basarili: "BAŞARILI",
    Basarisiz:"BAŞARISIZ", 
    Hata: "HATA",
    Uyari: "UYARI",
    Bilgi: "BİLGİ",
    SistemHatasi: "SİSTEMSEL HATA"

}

function alertOlayi( durum,aciklama, zaman = 0, url = "") {
    $(".myalert").removeAttr("hidden");
    if (durum == IslemSonucTurleri.Basarili) {
        $("#alertContent").removeAttr("class");
        $("#alertContent").addClass("alert alert-success");
        $("#alertBaslik").html("Başarılı");
        $("#alertAciklama").html(aciklama);
    } else if (durum == IslemSonucTurleri.Basarisiz) {
        $("#alertContent").removeAttr("class");
        $("#alertContent").addClass("alert alert-danger");
        $("#alertBaslik").html("Başarısız");
        $("#alertAciklama").html(aciklama);
    } else if (durum == IslemSonucTurleri.Hata) {
        $("#alertContent").removeAttr("class");
        $("#alertContent").addClass("alert alert-danger");
        $("#alertBaslik").html("Sistemsel Hata !");
        $("#alertAciklama").html(aciklama);
    }
    else if (durum == IslemSonucTurleri.Uyari) {
        $("#alertContent").removeAttr("class");
        $("#alertContent").addClass("alert alert-warning");
        $("#alertBaslik").html("Uyarı !");
        $("#alertAciklama").html(aciklama);
    }
    if (zaman!=0&&url!='') {
        setTimeout(function () {
            window.location.href = url;
        }, zaman);
    }
}


function KullaniciGiris() {


    var kullaniciAdi = $('#kullaniciAdi').val();
    var parola = $('#parola').val();
    if (kullaniciAdi == '') {
        //ModelBasveGoster(IslemSonucTurleri.Uyari, "Kullanıcı Adı boş geçilemez");
        alertOlayi(IslemSonucTurleri.Uyari, 'Kullanıcı Adı boş geçilemez.', 0, "");
        return false;
    }
    if (parola == '') {
        alertOlayi(IslemSonucTurleri.Uyari, 'Parola boş geçilemez.', 0, "");
        //ModelBasveGoster(IslemSonucTurleri.Uyari, 'Parola boş geçilemez.');

        return false;
    }
    $.ajax({
        type: 'POST',
        url: "/Kullanici/KullaniciGiris",
        data: { KullaniciKodu: kullaniciAdi, Parola: parola },
        dataType: 'json',
        success: function (value) {
            console.log(value);

            if (value.IslemKodu == 1) {
               
                alertOlayi(IslemSonucTurleri.Basarili, value.Aciklama, 2000, "/Home/Index");
              
            }
            else if (value.IslemKodu == 2) {
                alertOlayi(IslemSonucTurleri.Basarisiz, value.Aciklama, 0, "");
                //ModelBasveGoster(IslemSonucTurleri.Hata, value.Aciklama)
            }


        },

        error: function (ex) {
            ModelBasveGoster(IslemSonucTurleri.Hata, ex.aciklama);
        }
    });

}


//function ModelBasveGoster(baslik, aciklama) {
//    $("#ModelBaslik").text(baslik);
//    $("#ModelAciklama").text(aciklama);
//    ModelBilgileriGoster("ModelBilgilendirme");

//}

//function ModelBilgileriGoster(modalId) {
//    $("#" + modalId).show();
//}
//function ModelBilgileriGizle(modalId) {
//    $("#" + modalId).modal("hide");
//}

