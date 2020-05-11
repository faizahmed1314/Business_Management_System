function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#cntimage')
                .attr('src', e.target.result);
        };

        reader.readAsDataURL(input.files[0]);
    }
}

$("#Code").keyup(function () {

    var codeValue = $(this).val();
    if (codeValue != undefined && codeValue != "") {

        //-------------Key---Value
        var params = { code: codeValue };
        $.ajax({
            type: "POST",
            url: "../Customer/IsCodeNoExist",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData !== false && rData != undefined) {
                    $("#CodeSpan").text(rData);
                    //var btn = "<input type='button' value='Close' class='btn btn-info'>";

                    //$("#ButtonDiv").html(btn);
                } else {
                    $("#CodeSpan").text("");
                    //$("#ButtonDiv").html("");
                }
            }
        });
    }
});
$("#Email").keyup(function () {

    var emailValue = $(this).val();
    if (emailValue != undefined && emailValue != "") {

        //-------------Key---Value
        var params = { email: emailValue };
        $.ajax({
            type: "POST",
            url: "../Customer/IsEmailNoExist",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData !== false && rData != undefined) {
                    $("#EmailSpan").text(rData);
                    //var btn = "<input type='button' value='Close' class='btn btn-info'>";

                    //$("#ButtonDiv").html(btn);
                } else {
                    $("#EmailSpan").text("");
                    //$("#ButtonDiv").html("");
                }
            }
        });
    }
});

$(document).ready(function () {
    $("#CustomerCreate").validate({
        rules: {
            Code: {
                required: true,
                minlength: 3

            },
            Name: {
                required: true,

            },
            Email: {
                required: true,

            },
            ContactNumber: {
                required: true,
                minlength: 11
            },

        },
        messages: {
            Name: "Please enter your  name!",
            Email: "The email should be in the format: abc@domain.tld!",
            Code: {
                required: "Please enter your code",
                minlength: "Code should be at least 3 characters"
            },
            ContactNumber: {
                required: "Please enter your contact number",

                minlength: "Contact number should be at least 11  characters"
            },

        }
    });
});