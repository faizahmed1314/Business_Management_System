var subdirectory = "../../";

$(document.body).on("change", "#ProductId", function () {
    var ProductId = $(this).val();
    if (ProductId > 0) {

        var url = subdirectory + "Purchase/GetByProductId";
        var params = { id: ProductId };
        $.post(url, params, function (rData) {
            if (rData != undefined) {
                $("#code").empty();

                $.each(rData, function (k, v) {
                    var code = "<input id='productCode' class='form-control' value='" + v.Code + "' readonly>";
                    $("#code").append(code);
                });
            } else {
                $("#code").empty();
            }
        });
    }
});


$(document.body).on("change", "#unitPrice", function () {
    $("#total").empty();
    var total = ($("#quantity").val()) * ($("#unitPrice").val());
    var t = "<input id='totalPrice' class='form-control' value='" + total + "' readonly>";
    $("#total").append(t);

    $("#newCostPrice").empty();
    var newCostPrice = ($("#unitPrice").val());
    var n = "<input id='newCostPriceText' class='form-control' value='" + newCostPrice + "'>";
    $("#newCostPrice").append(n);

    $("#mrp").empty();
    var unitP = parseFloat($("#unitPrice").val());
    var mrp = unitP + ((unitP * 25) / 100);
    var m = "<input id='mRP' class='form-control' value='" + mrp + "'>";
    $("#mrp").append(m);
});

$(document.body).on("change", "#quantity", function () {
    $("#total").empty();
    var total = ($("#quantity").val()) * ($("#unitPrice").val());
    var t = "<input class='form-control' value='" + total + "' readonly>";
    $("#total").append(t);
});

/*table data show*/
$("#AddButton").click(function () {
    createRowForPurchase();

});


var index = 0;
function createRowForPurchase() {

    //Get Selected Item from UI
    var selectedItem = getSelectedItem();

    //Check Last Row Index
    var index = $("#PurchaseDetailsTable").children("tr").length;
    var sl = index;

    //For Model List<Property> Binding For MVC
    var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='PurchaseDetailses.Index' value='" + index + "' /> </td>";

    //For Serial No For UI
    var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";

    var productId = "<td> <input type='hidden' id='productId" + index + "'  name='PurchaseDetailses[" + index + "].ProductId' value='" + selectedItem.ProductId + "' /> " + selectedItem.Code + " </td>";
    var manufactureDate = "<td> <input type='hidden' id='manufactureDate" + index + "'  name='PurchaseDetailses[" + index + "].ManufactureDate' value='" + selectedItem.ManufactureDate + "' /> " + selectedItem.ManufactureDate + " </td>";
    var expireDate = "<td> <input type='hidden' id='expireDate" + index + "'  name='PurchaseDetailses[" + index + "].ExpireDate' value='" + selectedItem.ExpireDate + "' /> " + selectedItem.ExpireDate + " </td>";
    var quantity = "<td> <input type='hidden' id='quantity" + index + "'  name='PurchaseDetailses[" + index + "].Quantity' value='" + selectedItem.Quantity + "' /> " + selectedItem.Quantity + " </td>";
    var unitPrice = "<td> <input type='hidden' id='unitPrice" + index + "'  name='PurchaseDetailses[" + index + "].UnitPrice' value='" + selectedItem.UnitPrice + "' /> " + selectedItem.UnitPrice + " </td>";
    var totalPrice = "<td> " + selectedItem.TotalPrice + " </td>";
    var mrp = "<td> <input type='hidden' id='mrp" + index + "'  name='PurchaseDetailses[" + index + "].MRP' value='" + selectedItem.MRP + "' /> " + selectedItem.MRP + " </td>";

    var actionTd = "<td> <input type='button' class='editButton' data-index='" + index + "' value='Edit'/> <input type='button' class='deleteButton' data-index='" + index + "' value='Delete'/> </td>";

    var newRow = "<tr id='row" + index + "'>" + indexTd + slTd + productId + manufactureDate + expireDate + quantity + unitPrice + totalPrice + mrp + actionTd + " </tr>";

    $("#PurchaseDetailsTable").append(newRow);

    $("#ProductId").val("");
    $("#productCode").val("");
    $("#manufactureDate").val("");
    $("#expireDate").val("");
    $("#quantity").val("");
    $("#unitPrice").val("");
    $("#mRP").val("");
    $("#totalPrice").val("");
    $("#newCostPriceText").val("");

}
function getSelectedItem() {
    var code = $("#productCode").val();
    var productId = $("#ProductId option:selected").val();
    var manufactureDate = $("#manufactureDate").val();
    var expireDate = $("#expireDate").val();
    var quantity = $("#quantity").val();
    var unitPrice = $("#unitPrice").val();
    var totalPrice = $("#totalPrice").val();
    var mrp = $("#mRP").val();

    var item = {
        "Code": code,
        "ProductId": productId,
        "ManufactureDate": manufactureDate,
        "ExpireDate": expireDate,
        "Quantity": quantity,
        "UnitPrice": unitPrice,
        "TotalPrice": totalPrice,
        "MRP": mrp
    };
    return item;
}

$(document.body).on("click", ".editButton", function () {
    var index = $(this).attr("data-index");
    var itemName = $("#productId" + index).val();
    alert(itemName);


});
$(document.body).on("click", ".deleteButton", function () {
    var index = $(this).attr("data-index");
    $("#row" + index).remove();

});



//check if bill no is exist

$("#BillTextBox").keyup(function () {

    var billValue = $(this).val();
    if (billValue != undefined && billValue != "") {

        //-------------Key---Value
        var params = { bill: billValue };
        $.ajax({
            type: "POST",
            url: "../Purchase/IsBillNoExist",
            contentType: "application/Json; charset=utf-8",
            data: JSON.stringify(params),
            success: function (rData) {
                if (rData !== false && rData != undefined) {
                    $("#BillSpan").text(rData);
                    //var btn = "<input type='button' value='Close' class='btn btn-info'>";

                    $("#ButtonDiv").html(btn);
                } else {
                    $("#BillSpan").text("");
                    //$("#ButtonDiv").html("");
                }
            }
        });
    }
});