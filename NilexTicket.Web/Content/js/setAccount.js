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

var ilk_mail = $("#Mail").val();
