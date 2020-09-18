/*User kontrol*/
$(document).ready(function () {
    $("#Username").blur(function () {
        var kul = $(this).val()
        if (kul != "") {
            $.ajax({
                type: 'POST',
                url: '/Home/UserKontrolEt?Username=' + kul,
                success: function (sonuc) {
                    if (sonuc) {
                        $("#Username").css("border-color", "red")
                    }
                    else {
                        $("#Username").css("border-color", "#00ff90")
                    }
                },
                error: function () {

                }
            })
        }
        else {
            $(this).css("border-color", "#ccc")
        }
    })
})

/*Email kontrol*/
$(document).ready(function () {
    $("#Mail").blur(function () {
        var mail = $(this).val();
        if (mail != "") {
            $.ajax({
                type: 'POST',
                url: '/Home/EmailKontrolEt?gelenMail=' + mail,
                success: function (sonuc) {
                    if (sonuc) {
                        $("#Mail").css("border-color", "red")
                    }
                    else {
                        $("#Mail").css("border-color", "#00ff90")
                    }
                }
            })
        }
        else $("#Mail").css("border-color", "#ccc")
    })
})


$(document).ready(function () {
    $("#pass2").blur(function () {
        var ps1 = $("#Password").val();
        var ps2 = $("#pass2").val();
        if (ps1 != "" & ps2 != "") {
            if (ps1 != ps2) {
                $(this).css("border-color", "red")
                $("#Password").css("border-color", "red")
            }
            else {
                $(this).css("border-color", "#00ff90")
                $("#Password").css("border-color", "#00ff90")
            }
        }
        else {
            $(this).css("border-color", "#ccc")
            $("#Password").css("border-color", "#ccc")
        }

    })
})


$(document).ready(function () {
    $("#Password").blur(function () {
        var ps1 = $("#Password").val();
        var ps2 = $("#pass2").val();
        if (ps1 != "" & ps2 != "") {
            if (ps1 != ps2) {
                $("#pass2").css("border-color", "red")
                $("#Password").css("border-color", "red")
            }
            else {
                $("#pass2").css("border-color", "#00ff90")
                $("#Password").css("border-color", "#00ff90")
            }
        }
        else {
            $("#pass2").css("border-color", "#ccc")
            $("#Password").css("border-color", "#ccc")
        }

    })
})

function Kayit() {
    var isim = $("#FullName").val()
    if (isim == "") var i = true;
    else i = false;
    var User = $("#Username").css("border-color")
    if (User == "rgb(204, 204, 204)") var k = true;
    else k = false;
    var mail = $("#Mail").css("border-color")
    if (mail == "rgb(204, 204, 204)") var e = true;
    else e = false;
    var Password = $("#Password").css("border-color")
    if (Password == "rgb(204, 204, 204)") var s = true;
    else s = false;
    var gun = $("#day").val();
    var ay = $("#month").val();
    var yil = $("#year").val();
    //if (i == true | k == true | e == true | s == true | gun == "Seçiniz" | ay == "Seçiniz" | yil == "Seçiniz") {
    if (i | k | e | s | gun == "Seçiniz" | ay == "Seçiniz" | yil == "Seçiniz") {
        $("#eksik-mesaj").slideDown("fast");
        setTimeout(function () {
            $("#eksik-mesaj").slideUp("slow")
        }, 3000)
    }
    else {
        $("#Birthdate").val($("#day").val() + "." + $("#month").val() + "." + $("#year").val())
        var datacik = $("form").serializeArray();
        $.ajax({
            url: '/Home/Register',
            method: 'POST',
            data: datacik,
            success: function (sonuc) {
                if (sonuc) {
                    if (confirm("Registration successful Would you like to be redirected to the Login page?"))
                        location.href = "/Home/Login"
                }
                else
                    return confirm("Registration failed");

            },
            error: function () {
                return confirm("An unexpected error has occurred")
            }
        })
    }
}