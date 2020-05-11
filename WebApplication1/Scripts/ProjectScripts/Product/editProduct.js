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

$(document).ready(function () {
    $("#ProductEdit").validate({
        rules: {
            Code: {
                required: true,
                minlength: 3
            },
            Name: {
                required: true,
            },
            ReOrderLevel: {
                required: true,
            },
            UploadFile: {
                required: true,
            },
        },
        messages: {
            Name: "Please enter your product name!",
            Code: {
                required: "Please enter your product code",
                minlength: "Code should be at least 3 characters"
            },
            ReOrderLevel: "Please enter your product re-order level!",
            UploadFile: "Please enter your product image!",
        }
    });
});

$(document).ready(function () {
    var url =  "/../Product/GetAllCategory";

    $.post(url, function (rData) {
        if (rData != undefined) {
            $("#CategoryId").empty();
            $("#CategoryId").append("<option value=''>---Select---</option>");
            $.each(rData, function (k, v) {
                var option = "<option value=" + v.Id + ">" + v.Name + "</option>";
                $("#CategoryId").append(option);

            });
        }
    });
});