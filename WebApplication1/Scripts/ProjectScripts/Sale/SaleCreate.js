var subdirectory = "../../";

$(document.body).on("change", "#CustomerId", function () {
    var CustomerId = $(this).val();
    if (CustomerId > 0) {

        var url = subdirectory + "Sale/GetByCustomerId";
        var params = { id: CustomerId };
        $.post(url, params, function (rData) {
            if (rData != undefined) {
                document.getElementById("loyalityPoint").value = "0";

                $.each(rData, function (k, v) {
                    var lPoint = v.LoyaltyPoint;
                    document.getElementById("loyalityPoint").value = lPoint;
                });

            } else {
                document.getElementById("loyalityPoint").value = "0";
            }
        });
    }
});

$(document.body).on("change", "#ItemName", function () {
    var ProductId = $(this).val();
    if (ProductId > 0) {

        var url = subdirectory + "Sale/GetByProductId";
        var params = { id: ProductId };
        $.post(url, params, function (rData) {
            if (rData != undefined) {
                //$("#avQuantity").empty();
                //$("#unitPrice").empty();
                document.getElementById("avQuantity").value = "0";
                document.getElementById("ItemPrice").value = "";

                $.each(rData, function (k, v) {

                    var avQuantity = v.Quantity; 
                    var mrp = v.MRP;
                    document.getElementById("avQuantity").value = avQuantity;
                    document.getElementById("ItemPrice").value = v.MRP;

                     //var avQuantity = "<input class=form-control value='" + v.Quantity + "' readonly>";
                    //$("#avQuantity").append(avQuantity);

                    //var unitPrice = "<input class=form-control value='" + v.UnitPrice + "' readonly>";
                    //$("#unitPrice").append(unitPrice);
                });

            } else {
                document.getElementById("avQuantity").value = "";
                document.getElementById("ItemPrice").value = "";


                //$("#avQuantity").empty();
                //$("#unitPrice").empty();
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

    var productId = "<td> <input type='hidden' id='ItemName" + index + "'  name='SaleDetailses[" + index + "].ProductId' value='" + selectedItem.ItemId + "' /> " + selectedItem.ItemName + " </td>";
    var quantity = "<td> <input type='hidden' id='ItemQty" + index + "'  name='SaleDetailses[" + index + "].Quantity' value='" + selectedItem.ItemQty + "' /> " + selectedItem.ItemQty + " </td>";
    var unitPrice = "<td> <input type='hidden' id='ItemPrice" + index + "'  name='SaleDetailses[" + index + "].UnitPrice' value='" + selectedItem.ItemPrice + "' /> " + selectedItem.ItemPrice + " </td>";
    var totalPrice = "<td> " + selectedItem.TotalPrice + " </td>";

    var actionTd = "<td> <input type='button' class='editButton' data-index='" + index + "' value='Edit'/> <input type='button' onclick='deleteRow(this)' class='deleteButton' data-index='" + index + "' value='Delete'/> </td>";

    var newRow = "<tr id='row" + index + "'>" + indexTd + slTd + productId + quantity + unitPrice + totalPrice + actionTd + " </tr>";

    $("#SaleDetailsTable").append(newRow);
    $("#ItemName").val("");
    $("#ItemQty").val("");
    $("#ItemPrice").val("");
    $("#avQuantity").val("");

}

function getSelectedItem() {
    var itemId = $("#ItemName option:selected").val();
    var itemName = $("#ItemName option:selected").text();

    var itemQty = $("#ItemQty").val();
    var itemPrice = $("#ItemPrice").val();
    var totalPrice = $("#ItemQty").val() * $("#ItemPrice").val();
    var item = {
        "ItemName": itemName,
        "ItemId": itemId,
        "ItemQty": itemQty,
        "ItemPrice": itemPrice,
        "TotalPrice": totalPrice
    };
    return item;
}

function deleteRow(r) {

    var i = r.parentNode.parentNode.rowIndex;
    document.getElementById("table").deleteRow(i);

    var table = document.getElementById("SaleDetailsTable"), sumVal = 0;
    for (var i = 0; i < table.rows.length; i++) {
        sumVal = sumVal + parseInt(table.rows[i].cells[5].innerHTML);
    }
    document.getElementById("grandTotalValue").value = sumVal;
}


$(document.body).on("click", ".editButton", function () {
    var index = $(this).attr("data-index");
    var productName = $("#quantity" + index).val();
    alert(productName);
});

//Find Grand Total

$(document.body).on("click", "#AddButton", function () {

    

    var table = document.getElementById("SaleDetailsTable"), sumVal = 0;
    for (var i = 0; i < table.rows.length; i++) {
        sumVal = sumVal + parseInt(table.rows[i].cells[5].innerHTML);
    }
    document.getElementById("grandTotalValue").value =sumVal;
});