$(document).ready(function () {
    $("#overlay").fadeIn(300);
    $.ajax({
        url: '/User/ticketCheck',
        type: 'POST',
        success: function (sonuc) {
            if (sonuc != "Bos") {
                if (sonuc) {
                    $("#mesaj_div").fadeIn("slow");
                    setTimeout(function () {
                        $("#mesaj_div").slideUp("slow", "swing")
                    }, 4000)
                }
                else {
                    $("#clasDanger").toggleClass("alert-danger")
                    $("#mesaj").html("Something went wrong")
                    $("#mesaj_div").fadeIn("slow");
                    setTimeout(function () {
                        $("#mesaj_div").slideUp("slow", "swing")
                    }, 4000)
                }
            } 
        }
    });
     
    var unloadEvent = function (e) {
        $.ajax({
            type: 'POST',
            url: '/User/viewTemizle'
        });
    };
    $("#overlay").fadeOut(300);
    window.addEventListener("beforeunload", unloadEvent);
})