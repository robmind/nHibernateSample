function AdminDelete(id) {
    if (id != null & confirm("Are you sure you want to deauthorize?")) {
        $.ajax({
            method: 'POST',
            url: '/Admin/AdminDelete?id=' + id,
            success: function (sonuc) {
                if (sonuc.IsSuccess) {
                    var kAdi = $("#kulAdi-" + id).text();
                    $("#tr-" + id).fadeOut();
                    $("#kul").append(
                        "<option id='op-" + id + "' value='" + id + "'>" + kAdi + "</option>"
                        )
                }
                else {
                    $("#mesaj").html(sonuc.Mesaj)
                    $("#mesaj").fadeIn("fast")
                    setTimeout(function () {
                        $("#mesaj").slideUp("slow")
                    }, 3000)
                }
            },
            error: function () {
                $("#mesaj").html("An unknown error has occurred")
                $("#mesaj").fadeIn("fast")
                setTimeout(function () {
                    $("#mesaj").slideUp("slow")
                }, 3000)
            }
        })
    }
}
function GivePermission() {
    var id = $("#kul").val();
    if (id == "") {
        $("#announcement").fadeIn("fast").html("You did not choose a user")
        setTimeout(function () {
            $("#announcement").slideUp("fast")
        }, 2000)
    }
    else if (confirm("All tickets and comments of this user will be deleted. Do you confirm?")) {
        $.ajax({
            method: 'POST',
            url: '/Admin/GivePermission?id=' + id,
            success: function (result) {
                if (result.IsSuccess) {
                    var kulAdi = $("#op-" + id).text();
                    $("tbody").append(
                        "<tr id='tr-" + id + "' hidden>" +
                                        "<td>" + id + "</td>" +
                                        "<td id='kulAdi-" + id + "' style='width:300px'>" + kulAdi + "</td>" +
                                        "<td>" +
    "<input type='button' id='btn-" + id + "' class='btn btn-danger btn-xs' onclick='AdminDelete(" + id + ")' value='Kaldır'>" +
                                        "</td>" +
                        "</tr>"
                    )
                    $("#tr-" + id).fadeIn();
                    $("#op-" + id).remove();
                }
                else {
                    $("#announcement").fadeIn("fast").html(result.Mesaj)
                    setTimeout(function () {
                        $("#announcement").slideUp("slow")
                    }, 3000)
                }
            },
            error: function () {
                $("#announcement").fadeIn("fast").html("An unknown error has occurred")
                setTimeout(function () {
                    $("#announcement").slideUp("slow")
                }, 3000)
            }
        })
    }
}