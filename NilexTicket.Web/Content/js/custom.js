function showInputErrorMessage(text) {
    var errCount = text.split("|").length - 1;
    if (text != '') {
        if (errCount === 1) {
            var arr = text.split('|')[0];
            $.each(errList, function (index, value) {
                if (arr == index) {
                    showErrorMessage(value);
                    return false;
                }
            });

        } else if (errCount > 1) {
            showErrorMessage("You have entered more than one information incomplete or incorrectly,  please check and try again.");
        }
    }
}

function showSuccessMessage(text, ic) {
    var span = document.createElement("span");
    span.innerHTML = text;

    if (ic == "0") {
        swal({
            title: "Success",
            content: span,
            icon: "success",
            button: "OK",
        }).then(function () {
            window.location = "/";
        })
    } else {

        swal({
            title: "Success",
            content: span,
            icon: "success",
            button: "OK",
        })
    } 
}

function showErrorMessage(text) {
    var span = document.createElement("span");
    span.innerHTML = text;

    swal({
        title: "Error!",
        content: span,
        icon: "error",
        button: "OK",
    });
}