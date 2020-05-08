
$("#UserName").keyup(function () {

    var usernameVal = $(this).val();
    if (usernameVal != undefined && usernameVal != "") {

        //-------------Key---Value
        var params = { username: usernameVal };
        $.ajax({
            type: "POST",
            url: "../Account/IsUserNameExist",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData !== false && rData != undefined) {
                    $("#UserNameSpan").text(rData);
                    //var btn = "<input type='button' value='Close' class='btn btn-info'>";

                    //$("#ButtonDiv").html(btn);
                } else {
                    $("#UserNameSpan").text("");
                    //$("#ButtonDiv").html("");
                }
            }
        });
    }
});

$(document).ready(function () {
    $("#AccountCreate").validate({
        rules: {
            FirstName: {
                required: true,
                
            },
            LastName: {
                required: true,
            },
            Email: {
                required: true,
            },
            UserName: {
                required: true,
                minlength: 6
            },
            Password: {
                required: true,
                minlength: 6
            },
        },
        messages: {
            FirstName: "Please enter your first name!",
            LastName: "Please enter your last name!",
            Email: "The email should be in the format: abc@domain.tld!",
            UserName: {
                required: "Please enter user name",
                minlength: "Code should be at least 6 alphanumeric characters"
            },
            Password: {
                required: "Please enter your password",

                minlength: "Password should be at least 6  characters"
            },
           
        }
    });
});