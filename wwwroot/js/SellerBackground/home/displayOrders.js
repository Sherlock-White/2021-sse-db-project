let ord = new Vue({
    el: '#home-list',
    data:{
        objectList: [],
        draw:false,
    }
})

<<<<<<< HEAD
<<<<<<< HEAD
=======


>>>>>>> parent of 32415d6 (Merge branch 'main' into main)
=======
>>>>>>> parent of 624510a (Merge pull request #33 from 1654364091/main)
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
=======
            }
>>>>>>> parent of 624510a (Merge pull request #33 from 1654364091/main)
        }
    });
}

<<<<<<< HEAD
<<<<<<< HEAD
//这边修改传入的参数！！（从coockie中拿sellerID->shopID
=======

>>>>>>> parent of 32415d6 (Merge branch 'main' into main)
=======
//这边修改传入的参数！！（从coockie中拿sellerID->shopID
>>>>>>> parent of 624510a (Merge pull request #33 from 1654364091/main)
window.onload = displayorders("1");
