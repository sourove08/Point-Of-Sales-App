$(document).ready(function () {
    $("#t_stock").DataTable();
});


$('#CategoryId').change(function () {
    var categoryId = $("#CategoryId").val();
    if (categoryId == "") {
        $("#ProductId").empty();
        var option = "<option value=''>Select...</option>";
        $("#ProductId").append(option);
        return;
    }

    $.ajax({
        type: "POST",
        url: "/Product/GetProductByCategory",
        datatype:"Json",
        data:{categoryId:$('#CategoryId').val()},
        success: function (data) {
            $("#ProductId").empty();
            $.each(data, function (index, value) {
                $('#ProductId').append('<option value="' + value.Id + '">' + value.Name + '</option>');
            });
        }

    });
});



$("#btn_stock_add").click(function () {

    var stockDetail = GetStockDetail();
    var index = $('#tbl_stock tr').length;
    var productCell = "<td> <input type='hidden' name='StockDetails[" + index + "].ProductId' value='" + stockDetail.productId + "'/><input type='hidden' name='StockDetails[" + index + "].Quantity' value='" + stockDetail.quantity + "' />" + stockDetail.productName + "</td>";
    var quantityCell = "<td>"+stockDetail.quantity+ "</td>";
    var trItem = "<tr id='stock_" + index + "'>" + productCell + quantityCell + " </tr>";
    $("#tbl_stock").append(trItem);

});

function GetStockDetail() {
    var productId = $("#ProductId").val();
    var quantity = $("#Quantity").val();
    var productName = $("#ProductId option:selected").text();
    if (productId=="") {
        return null;
    }
    var stock =
    {
        productId: productId,
        quantity: quantity,
        productName: productName
    };
    return stock;
};
