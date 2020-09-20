function AdminDelete(id) {

    swal({
        title: "Are you sure you want to deauthorize?",
        text: "",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $("#overlay").fadeIn(300);
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
                            showErrorMessage(sonuc.Mesaj)
                            $("#mesaj").fadeIn("fast")
                            setTimeout(function () {
                                $("#mesaj").slideUp("slow")
                            }, 3000)
                        }
                        $("#overlay").fadeOut(300);
                    },
                    error: function () {
                        showErrorMessage("An unknown error has occurred")
                        $("#mesaj").fadeIn("fast")
                        setTimeout(function () {
                            $("#mesaj").slideUp("slow")
                        }, 3000)
                        $("#overlay").fadeOut(300);
                    }
                })
            }
        });
}
function GivePermission() {
    var id = $("#kul").val();
    if (id == "") {
        $("#announcement").fadeIn("fast").html("You did not choose a user")
        setTimeout(function () {
            $("#announcement").slideUp("fast")
        },
            2000)
    } else {
        swal({
            title: "Are you sure?",
            text: "All tickets and comments of this user will be deleted.",
            icon: "warning",
            buttons: true,
            dangerMode: true,
        })
            .then((willDelete) => {
                if (willDelete) {
                    $("#overlay").fadeIn(300);
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
                                    "<input type='button' id='btn-" + id + "' class='btn btn-danger btn-xs' onclick='AdminDelete(" + id + ")' value='Remove'>" +
                                    "</td>" +
                                    "</tr>"
                                )
                                $("#tr-" + id).fadeIn();
                                $("#op-" + id).remove();
                            }
                            else {
                                showErrorMessage(result.Mesaj)
                                setTimeout(function () {
                                    $("#announcement").slideUp("slow")
                                }, 3000)
                            }
                            $("#overlay").fadeOut(300);
                        },
                        error: function () {
                            showErrorMessage("An unknown error has occurred")
                            setTimeout(function () {
                                $("#announcement").slideUp("slow")
                            }, 3000)
                            $("#overlay").fadeOut(300);
                        }
                    })
                }
            });
    }
}