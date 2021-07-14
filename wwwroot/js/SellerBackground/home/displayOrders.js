let ord = new Vue({
    el: '#home-list',
    data:{
        objectList: [],
        draw:false,
    }
})

<<<<<<< HEAD
=======


>>>>>>> parent of 32415d6 (Merge branch 'main' into main)
function displayorders(shopID) {
    $.ajax({
        type: "post",
        url: "/SellerBackground/DisplayOrdersForm",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ "ShopID": shopID }),
        success: function (result) {
            //let temp = JSON.stringify(result);
            //console.log(result);
            if (result==null) {
                alert("No orders!");
                console.log("null")
            }
            else {
                ord.objectList = result;
                ord.draw = true;
<<<<<<< HEAD
            }
=======
                console.log("draw1");
                console.log(ord.draw);
                /*console.log("!!!result");
                console.log(result);
                console.log("ord.objectList!!!!");
                console.log(ord.objectList)*/
                console.log("not null");
            }
            //console.log(result);
>>>>>>> parent of 32415d6 (Merge branch 'main' into main)
        }
    });
}

<<<<<<< HEAD
//这边修改传入的参数！！（从coockie中拿sellerID->shopID
=======

>>>>>>> parent of 32415d6 (Merge branch 'main' into main)
window.onload = displayorders("1");
