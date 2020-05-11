$("#Code").keyup(function () {

    var codeValue = $(this).val();
    if (codeValue != undefined && codeValue != "") {

        //-------------Key---Value
        var params = { code: codeValue };
        $.ajax({
            type: "POST",
            url: "../Category/IsCodeNoExist",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData !== false && rData != undefined) {
                    $("#CodeSpan").text(rData);
                    var btn = "<input type='button' value='Close' class='btn btn-danger'>";

                    $("#ButtonSpan").html(btn);
                } else {
                    $("#CodeSpan").text("");
                    $("#ButtonSpan").html("");
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
            url: "../Category/IsNameNoExist",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData !== false && rData != undefined) {
                    $("#NameSpan").text(rData);
                    var btn = "<input type='button' value='Close' class='btn btn-danger'>";

                    $("#ButtonSpan").html(btn);
                } else {
                    $("#NameSpan").text("");
                    $("#ButtonSpan").html("");
                }
            }
        });
    }
});

