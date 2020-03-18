var subdirectory = "../../";

$(document.body).on("change", "#CustomerId", function () {
    var CustomerId = $(this).val();
    if (CustomerId > 0) {

        var url = subdirectory + "Sale/GetByCustomerId";
        var params = { id: CustomerId };
        $.post(url, params, function (rData) {
            if (rData != undefined) {
                $("#loyalityPoint").empty();

                $.each(rData, function (k, v) {
                    var lPoint = "<input class=form-control value='" + v.LoyaltyPoint + "' readonly>";
                    $("#loyalityPoint").append(lPoint);
                });
            } else {
                $("#loyalityPoint").empty();
            }
        });
    }
});

$(document.body).on("change", "#ProductId", function () {
    var ProductId = $(this).val();
    if (ProductId > 0) {

        var url = subdirectory + "Sale/GetProductById";
        var params = { ProductId: ProductId };
        $.post(url, params, function (rData) {
            if (rData != undefined) {
                $("#avQuantity").empty();
                $("#unitPrice").empty();
               
                $.each(rData, function (k, v) {
                    
                    var avQuantity = "<input class=form-control value='" + v.Quantity + "' readonly>";
                    $("#avQuantity").append(avQuantity);

                    var unitPrice = "<input class=form-control value='" + v.UnitPrice + "' readonly>";
                    $("#unitPrice").append(unitPrice);
                });
                
            } else {
                $("#avQuantity").empty();
                $("#unitPrice").empty();
            }

        });
    }
});
// add table
$("#AddButton").click(function () {
    createRowForSale();

});


var index = 0;
function createRowForSale() {

    //Get Selected Item from UI
    var selectedItem = getSelectedItem();

    //Check Last Row Index
    var index = $("#SaleDetailsTable").children("tr").length;
    var sl = index;

    //For Model List<Property> Binding For MVC
    var indexTd = "<td style='display:none'><input type='hidden' id='Index" + index + "' name='SaleDetailses.Index' value='" + index + "' /> </td>";

    //For Serial No For UI
    var slTd = "<td id='Sl" + index + "'> " + (++sl) + " </td>";

    var productId = "<td> <input type='hidden' id='productId" + index + "'  name='SaleDetailses[" + index + "].ProductId' value='" + selectedItem.ProductId + "' /> " + selectedItem.ProductName + " </td>";
    var quantity = "<td> <input type='hidden' id='quantity" + index + "'  name='SaleDetailses[" + index + "].Quantity' value='" + selectedItem.Quantity + "' /> " + selectedItem.Quantity + " </td>";
    var unitPrice = "<td> <input type='hidden' id='unitPrice" + index + "'  name='SaleDetailses[" + index + "].UnitPrice' value='" + selectedItem.UnitPrice + "' /> " + selectedItem.UnitPrice + " </td>";
    var totalPrice = "<td> " + selectedItem.TotalPrice + " </td>";

    var actionTd = "<td> <input type='button' class='editButton' data-index='" + index + "' value='Edit'/> <input type='button' class='deleteButton' data-index='" + index + "' value='Delete'/> </td>";

    var newRow = "<tr id='row" + index + "'>" + indexTd + slTd + productId + quantity + unitPrice + totalPrice + actionTd + " </tr>";

    $("#SaleDetailsTable").append(newRow);
    $("#ProductId").val("");
    $("#quantity").val("");
    $("#unitPriceValue").val("");
    $("#avQuantityValue").val("");

}
function getSelectedItem() {
    var productId = $("#ProductId option:selected").val();
    var productName = $("#ProductId option:selected").text();

    var quantity = $("#quantity").val();
    var unitPrice = $("#unitPriceValue").val();
    var totalPrice = $("#quantity").val() * $("#unitPriceValue").val();
    var item = {
        "ProductName": productName,
        "ProductId": productId,
        "Quantity": quantity,
        "UnitPrice": unitPrice,
        "TotalPrice": totalPrice
    };
    return item;
}