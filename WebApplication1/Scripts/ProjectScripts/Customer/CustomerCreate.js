
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