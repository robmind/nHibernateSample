
$(document).ready(function () {
    $("#btn-giris").click(function () {
        var veri = $("form").serializeArray()
        var bosmu = false;
        $.each(veri, function (i, field) {
            if (field.value == "") {
                showErrorMessage("Fill in the blank fields")
                bosmu = true;
                setTimeout(function () {
                    $("#login-mesaj").slideUp("fast")
                }, 3000)
            }
        })
        if (!bosmu) {
            $("#overlay").fadeIn(300);
            $.ajax({
                type: 'POST',
                data: veri,
                url: '/Home/Login',
                success: function (result) {
                    if (result == "Admin") {
                        location.href = "/Admin/Index"
                    }
                    else if (result == "User") {
                        location.href = "/User/Index"
                    }
                    else {
                        showErrorMessage("User or Password is incorrect")
                        setTimeout(function () {
                            $("#login-mesaj").slideUp("fast")
                        }, 3000)
                    }
                    $("#overlay").fadeOut(300);
                }
            })
        }
    });
});
