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
            url: "../Supplier/IsCodeNoExist",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData !== false && rData != undefined) {
                    $("#CodeSpan").text(rData);
                    
                } else {
                    $("#CodeSpan").text("");
                    
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
            url: "../Supplier/IsEmailExist",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData !== false && rData != undefined) {
                    $("#EmailSpan").text(rData);

                } else {
                    $("#EmailSpan").text("");

                }
            }
        });
    }
});

$(document).ready(function () {
    $("#SupplierCreate").validate({
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
            ContactPerson: {
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
            ContactPerson: {
                required: "Please enter the contact person number",

                minlength: "Contact person should be at least 11  characters"
            },
        }
    });
});
