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
            $("#overlay").fadeIn(300);
            $.ajax({
                method: 'POST',
                url: '/Home/UserDegisti?kadi='+ kadi
            })
            $("#overlay").fadeOut(300);
        }
    }
    else {
        showErrorMessage(myresult.Mesaj)
        $("#mesage").removeClass("alert-info")
        $("#mesage").addClass("alert-danger")
        $("#mesage").fadeIn("fast")
        setTimeout(function () {
            $("#mesage").slideUp("slow")
        }, 3000)
    }
}
function fail() {
    showErrorMessage("Something went wrong")
}

var newUser = true;
var newEmail = true;

$(document).ready(function () {
    $("#Username").blur(function () {
        var kul = $(this).val()
        if (kul != "") {
            $("#overlay").fadeIn(300);
            $.ajax({
                type: 'POST',
                url: '/Home/UserCheckIt?Username=' + kul,
                success: function (result) {
                    if (result & kul != ilk_kul) {
                        $("#Username").css("border-color", "red")
                        newUser = false;
                    }
                    else {
                        $("#Username").css("border-color", "#00ff90")
                        newUser = true;
                    }
                }
            })
            $("#overlay").fadeOut(300);
        }
        else {
            $(this).css("border-color", "#ccc")
        }
    })
})

var ilk_mail = $("#Mail").val();

$(document).ready(function () {
    $("#Mail").blur(function () {
        var mail = $(this).val();
        if (mail != "") {
            $("#overlay").fadeIn(300);
            $.ajax({
                type: 'POST',
                url: '/Home/EmailCheckIt?gelenMail=' + mail,
                success: function (result) {
                    if (result & mail != ilk_mail) {
                        $("#Mail").css("border-color", "red")
                        newEmail = false;
                    }
                    else {
                        $("#Mail").css("border-color", "#00ff90")
                        newEmail = true;
                    }

                    $("#overlay").fadeOut(300);
                }
            })
        }
        else {
            $(this).css("border-color", "#ccc")
        }
    })

    $("#registerform").submit(function () {
        if (!newEmail | !newUser) {
            return false;
        }
    })
})