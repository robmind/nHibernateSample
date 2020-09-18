function openCloseButton(a) {
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

        },
        error: function () {
            alert("hata")
        }
    });
}