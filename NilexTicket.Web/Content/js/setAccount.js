var ilk_kul = $("#Username").val();

function success(myresult) {
    if (myresult.IsSuccess) {
        var kadi = $("#Username").val();
        $("#mesage").fadeIn("fast")
        setTimeout(function () {
            $("#mesage").slideUp("slow")
        }, 3000)
        if (ilk_kul != kadi & myresult.Mesaj != "Admin") {
            ilk_kul = kadi;
            $.ajax({
                method: 'POST',
                url: '/Home/UserDegisti?kadi='+ kadi
            })
        }
    }
    else {
        $("#mesage").text(myresult.Mesaj)
        $("#mesage").removeClass("alert-info")
        $("#mesage").addClass("alert-danger")
        $("#mesage").fadeIn("fast")
        setTimeout(function () {
            $("#mesage").slideUp("slow")
        }, 3000)
    }
}
function fail() {
    alert("Something went wrong")
}


var yeniUser = true;
var yeniEmail = true;
/*User kontrol*/

$(document).ready(function () {
    $("#Username").blur(function () {
        var kul = $(this).val()
        if (kul != "") {
            $.ajax({
                type: 'POST',
                url: '/Home/UserKontrolEt?Username=' + kul,
                success: function (result) {
                    if (result & kul != ilk_kul) {
                        $("#Username").css("border-color", "red")
                        yeniUser = false;
                    }
                    else {
                        $("#Username").css("border-color", "#00ff90")
                        yeniUser = true;
                    }
                }
            })
        }
        else {
            $(this).css("border-color", "#ccc")
        }
    })
})

/*Email kontrol*/
var ilk_mail = $("#Mail").val();

$(document).ready(function () {
    $("#Mail").blur(function () {
        var mail = $(this).val();
        if (mail != "") {
            $.ajax({
                type: 'POST',
                url: '/Home/EmailKontrolEt?gelenMail=' + mail,
                success: function (result) {
                    if (result & mail != ilk_mail) {
                        $("#Mail").css("border-color", "red")
                        yeniEmail = false;
                    }
                    else {
                        $("#Mail").css("border-color", "#00ff90")
                        yeniEmail = true;
                    }
                }
            })
        }
        else {
            $(this).css("border-color", "#ccc")
        }
    })

    $("#kayitform").submit(function () {
        if (!yeniEmail | !yeniUser) {
            return false;
        }
    })
})