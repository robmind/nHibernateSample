$(document).ready(function () {
    $("#Username").blur(function () {
        var kul = $(this).val()
        if (kul != "") {
            $.ajax({
                type: 'POST',
                url: '/Home/UserCheckIt?Username=' + kul,
                success: function (sonuc) {
                    if (sonuc) {
                        $("#Username").css("border-color", "red")
                        showErrorMessage("Exist username, please chose another username");
                    }
                    else {
                        $("#Username").css("border-color", "#00ff90")
                    }
                },
                error: function () {

                }
            })
        }
        else {
            $(this).css("border-color", "#ccc")
        }
    })

    $("#Mail").blur(function () {
        var mail = $(this).val();
        if (mail != "") {
            $.ajax({
                type: 'POST',
                url: '/Home/EmailCheckIt?gelenMail=' + mail,
                success: function (sonuc) {
                    if (sonuc) {
                        $("#Mail").css("border-color", "red");
                        showErrorMessage("Exist mail, please chose another mail");
                    }
                    else {
                        $("#Mail").css("border-color", "#00ff90")
                    }
                }
            })
        }
        else $("#Mail").css("border-color", "#ccc")
    })

    $("#Password").blur(function () {
        var ps1 = $("#Password").val();
        if (ps1 != "") {
            $("#Password").css("border-color", "#00ff90")
        }
        else {
            $("#Password").css("border-color", "red")
        }
    })
})

var errList = {
    "01": "Please enter your fullname.",
    "02": "FullName cannot be less than 2 letters. <br> Please check and try again.",
    "03": "Please enter your username.",
    "04": "Username cannot be less than 2 letters. <br> Please check and try again.",
    "05": "Please enter your e-mail address.",
    "06": "You have entered an invalid e-mail. <br> Please check and try again."
};

$(document).ready(function () {
    $("registerform").attr('autocomplete', 'off');
    jQuery.validator.addMethod("strictemail",
        function(value, element) {
            var valid =
                /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/i
                    .test(value);
            return valid;
        },
        "Please enter a valid email address."
    );

    function isEmail(email) {
        var re =
            /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(String(email).toLowerCase());
    }

    $('#Username').keyup(function () {
        var $th = $(this);
        $th.val($th.val().replace(/[^a-zA-Z0-9]/g, function (str) { return ''; }));
    });

    $("#Username").on("keyup change",
        function () {
            var max_length = $(this).attr("maxlength");
            var telval = $(this).val().trim();
            if (telval.length > 0) {
                if (this.value.length >= max_length) {
                    $(this).val($(this).val().substr(0, max_length));
                }
            }
        });

    $('#FullName').bind('keypress', function (event) {
        var regex = new RegExp("^[a-zA-ZÂâÎîİıÇçŞşÜüÖöĞğÇ. ]*$");
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
        if (event.keyCode !== 8 && event.keyCode !== 46 && event.keyCode !== 9 && event.keyCode !== 13 && !(event.keyCode >= 35 && event.keyCode <= 40)) {
            if (!regex.test(key)) {
                event.preventDefault();
                return false;
            }
        }
    });

    $('#FullName').bind('keypress',
        function(event) {
            var $th = $(this);
            $th.val($th.val().replace(/(\s{2,})|[^a-zA-ZÂâÎîİıÇçŞşÜüÖöĞğÇ,.']/g, ' '));
            $th.val($th.val().replace(/^\s*/, ''));
        });

    $('#Mail').bind('keypress',
        function (event) {
            var regex = new RegExp("^[ ]*$");
            var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
            if (regex.test(key)) {
                event.preventDefault();
                return false;
            }
        });

    jQuery.validator.addMethod("strictemail", function (value, element) {
        var valid = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/i.test(value);
        return valid
    }, "Please enter valid email address.");

    $('#Mail').keyup(function () {
        var $th = $(this);
        $th.val($th.val().replace(/\s+/g, function (str) { return ''; }));
    });

    jQuery.validator.addMethod('iename', function (value, element) {
        if (element.value.length < 2) {
            return false;
        } else {
            return true;
        };
    }, "*");

    jQuery.validator.addMethod('iecode',
        function (value, element) {
            if (element.value.length < 2) {
                return false;
            } else {
                return true;
            };
        },
        "*");

    jQuery.validator.addMethod('countworditem',
        function(value) {
            var words = $.trim(value).replace(/\s+/gi, ' ').split(' ').length;
            return (words > 1);
        },
        "*");

    var errlog = "";
    $.validator.messages.required = '';
    $('#registerform').validate({ 
        focusInvalid: false,
        rules: {
            FullName: {
                required: true,
                minlength: 2,
                maxlength: 50,
                iename: true
            },
            Username: {
                required: true,
                minlength: 2,
                maxlength: 50
            },
            Mail: {
                required: true,
                strictemail: true,
                maxlength: 50
            },
            Password: {
                required: true,
            },
            pass2: {
                required: true,
                equalTo: "#Password"
            }
        },
        errorPlacement: function (error, element) {
            // don't add the error labels
            if ($(element).attr("type") == "checkbox") {
                $(element).parent().find("label").addClass('err');
            }
            return true;
        },
        success: function (error, element) {
            $(element).parent().find("span").removeClass("error");
            if ($(element).attr("type") == "checkbox") {
                $(element).parent().find("label").removeClass('err');
            }
        },
        submitHandler: function (form) {
            var form = $("#registerform");
            $("#overlay").fadeIn(300);
            $("#btnCreate").prop('disabled', true);

            $.ajax({
                url: location.pathname,
                type: "POST",
                data: form.serialize(),
                crossDomain: navigator.appVersion.indexOf("MSIE 9.") !== -1 ? "" : true,
                success: function (data) {
                    if (data) {
                        showSuccessMessage("Your account has been created.<br>You can login.","0");
                    }
                    else  {
                        showErrorMessage("Error occured, please try again later.");
                    }

                    $("#overlay").fadeOut(300);
                    $("#btnCreate").prop('disabled', false);
                },
                error: function (jqXhr, textStatus, errorThrown) {
                    $("#btnCreate").prop('disabled', false);
                },
                complete: function () {
                    $("#btnCreate").prop('disabled', false);
                }
            });
        },
        invalidHandler: function (form, validator) {

            $.each(validator.invalid,
                function (key, value) {
                    var email = isEmail($('input[name=Mail]').val());
                    var firstname = $('input[name=FullName]').val() != "";
                    var username = $('input[name=Username]').val() != "";

                    if (firstname == false) {
                        $('input[name=FullName]').addClass('error');
                        errlog += "01|";
                    } else {
                        if ($('input[name=FullName]').val().length < 2) {
                            $('input[name=FullName]').addClass('error');
                            errlog += "02|";
                        } else {
                            $('input[name=FullName]').removeClass('error');
                        }
                    }

                    if (username == false) {
                        $('input[name=Username]').addClass('error');
                        errlog += "03|";
                    } else {
                        if ($('input[name=Username]').val().length < 2) {
                            $('input[name=Username]').addClass('error');
                            errlog += "04|";
                        } else {
                            $('input[name=Username]').removeClass('error');
                        }
                    }

                    if ($('input[name=Mail]').val().length === 0) {
                        $('input[name=Mail]').addClass('error');
                        errlog += "05|";
                    }
                    else if (email === false) {
                        $('input[name=Mail]').addClass('error');
                        errlog += "06|";
                    } else {
                        $('input[name=Mail]').removeClass('error');
                    }

                    if (validator.numberOfInvalids() > 0) {
                        showInputErrorMessage(errlog);
                    } else if (validator.numberOfInvalids() === 0) {
                        showInputErrorMessage(errlog);
                    } else {
                        showInputErrorMessage(errlog);
                    }

                    return false;
                });
        }
    });

});




















function Register() {
    var isim = $("#FullName").val()
    if (isim == "") var i = true;
    else i = false;
    var User = $("#Username").css("border-color")
    if (User == "rgb(204, 204, 204)") var k = true;
    else k = false;
    var mail = $("#Mail").css("border-color")
    if (mail == "rgb(204, 204, 204)") var e = true;
    else e = false;
    var Password = $("#Password").css("border-color")
    if (Password == "rgb(204, 204, 204)") var s = true;
    else s = false;

    if (i | k | e | s) {
        $("#missing-message").slideDown("fast");
        setTimeout(function () {
            $("#missing-message").slideUp("slow")
        }, 3000)
    }
    else {
        var datacik = $("form").serializeArray();
        $("#overlay").fadeIn(300);
        $.ajax({
            url: '/Home/Register',
            method: 'POST',
            data: datacik,
            success: function (sonuc) {
                if (sonuc) {
                    showSuccessMessage("The user has been created.");
                } else {
                    showErrorMessage("Registration failed. Please try again later.");
                }
                $("#overlay").fadeOut(300);
            },
            error: function () {
                $("#overlay").fadeOut(300);
                showErrorMessage("An unexpected error has occurred. Please try again later.");
            }
        })
    }
}