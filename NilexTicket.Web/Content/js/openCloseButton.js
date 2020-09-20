function openCloseButton(a) {
    $("#overlay").fadeIn(300);
    $.ajax({
        url: '/User/TicketStatusu?id=' + a,
        method: 'POST',
        success: function (sonuc) {
            if (sonuc) {
                $("#btnStatus-" + a).removeClass("btn-success")
                $("#btnStatus-" + a).addClass("btn-primary")
                $("#btnStatus-" + a).text("Open")
            }
            else {
                $("#btnStatus-" + a).removeClass("btn-primary")
                $("#btnStatus-" + a).addClass("btn-success")
                $("#btnStatus-" + a).text("Close")
            }
            $("#overlay").fadeOut(300);
        },
        error: function () {
            showErrorMessage("Error")
            $("#overlay").fadeOut(300);
        }
    });
}