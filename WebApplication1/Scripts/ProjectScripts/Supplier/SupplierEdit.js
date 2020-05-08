﻿$(document).ready(function () {
    $("#SupplierEdit").validate({
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
            UploadFile: {
                required: true,

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
            UploadFile: {
                required: "Please upload your image"
            }

        }
    });
});