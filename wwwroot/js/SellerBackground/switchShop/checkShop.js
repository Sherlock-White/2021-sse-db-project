function checkshop() {
    $.ajax({
        type: "post",
        url: "/SellerBackground/GetIfShopForm",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ "ShopID": id }),
        success: function (result) {
            console.log("�޸�ȫ��shopID�Ƿ�ɹ���");
            console.log(result);
            window.location.href = "/SellerBackground/Home";
        }
    });
}