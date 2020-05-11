// For image showing in ui
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

var subdirectory = "../../";

//$(document.body).on("click", "#categorySubmitButton", function () {
//    var url = subdirectory + "Product/CreateCategory";
//    $.post(url, function(rData) {
//        if (rData != undefined) {
//            alert('Category Save Successful');
//        }
//    });
//});

//For Create New Category 
$("#CategoryIcon").click(function() {
    var url = subdirectory + "Product/GetCategoryPv";
    $.post(url, function(rData) {
        $("#CategoryCreatePvDiv").html(rData);
        //$("#modalPartialViewDiv").html(rData);
        //$("#myModal").modal("show");
    });
});

function CategorySaveSuccess(rData) {  
    $("#CategoryCreatePvDiv").html("");
    alert('Category Save Success');
}

function CategorySaveFailure(rData) {
    alert('Category Save Success');
}
//For Create New Category End


$(document).ready(function () {
    var url = subdirectory + "Product/GetAllCategory";

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


$(document).ready(function () {
    $("#ProductCreate").validate({
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

$("#Code").keyup(function () {

    var codeValue = $(this).val();
    if (codeValue != undefined && codeValue != "") {

        //-------------Key---Value
        var params = { code: codeValue };
        $.ajax({
            type: "POST",
            url: "../Product/IsCodeNoExist",
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
$("#Name").keyup(function () {

    var nameValue = $(this).val();
    if (nameValue != undefined && nameValue != "") {

        //-------------Key---Value
        var params = { name: nameValue };
        $.ajax({
            type: "POST",
            url: "../Product/IsNameExist",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData !== false && rData != undefined) {
                    $("#NameSpan").text(rData);
                    //var btn = "<input type='button' value='Close' class='btn btn-info'>";

                    //$("#ButtonDiv").html(btn);
                } else {
                    $("#NameSpan").text("");
                    //$("#ButtonDiv").html("");
                }
            }
        });
    }
});