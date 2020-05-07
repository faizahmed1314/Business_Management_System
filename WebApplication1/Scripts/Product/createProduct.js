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
