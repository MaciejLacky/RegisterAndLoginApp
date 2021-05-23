// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    console.log("ready");
    $(document).on("click", ".edit-product-button", function () {
        console.log(" clicked : " + $(this).val());

        var productId = $(this).val();
        $.ajax({
            type: "json",
            data: { "id": productId },
            url: "/product/ShowOneProductJSON",
            success: function (data) {
                console.log(data);

                //fill in the form
                $("#modal-input-id").val(data.id);
                $("#modal-input-name").val(data.name);
                $("#modal-input-price").val(data.price);
                $("#modal-input-description").val(data.description);
            }
            


        });

    });

    $("#save-button").click(function () {
        var Product = {
            "Id": $("#modal-input-id").val(),
            "Name": $("#modal-input-name").val(),
            "Price": $("#modal-input-price").val(),
            "Description": $("#modal-input-description").val(),
        };
        //save the update product
        $.ajax({
            type: "json",
            data: Product,
            url: "/product/ProcessEditReturnPartial",
            success: function (data) {
                $("#card-number-" + Product.Id).html(data);
            }
        })

    });

});