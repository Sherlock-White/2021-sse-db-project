let data = new Vue({
    el: "card-list",
    data: {
        datalist: [],
        draw: false,
    }
});

Vue.component('card-list', {
    data: function () {

    },
    methods: {

    },
    template: `
        <el-card class="card">
                        <img src="~/Images/SellerBackground/home/followers_num.png">
                        <div class="info">
                            <div class="label">关注人数</div>
                            <div class="num">233</div>
                        </div>
                    </el-card>
                    <el-card class="card">
                        <img src="~/Images/SellerBackground/home/recent_profit.png">
                        <div class="info">
                            <div class="label">本月盈利</div>
                            <div class="num">233</div>
                        </div>
                    </el-card>
                    <el-card class="card">
                        <img src="~/Images/SellerBackground/home/orders_num .png">
                        <div class="info">
                            <div class="label">待发货订单</div>
                            <div class="num">233</div>
                        </div>
                    </el-card>
                    <el-card class="card">
                        <img src="~/Images/SellerBackground/home/service_num.png">
                        <div class="info">
                            <div class="label">退款售后订单</div>
                            <div class="num">233</div>
                        </div>
                    </el-card>
    `
});

function displayorders(shopID) {
    $.ajax({
        type: "post",
        //url: "/SellerBackground/DisplayOrdersForm",
        async: false,
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify({ "ShopID": shopID }),
        success: function (result) {
            if (result == null) {
                alert("No orders!");
            }
            else {
                data.datalist = result;
                data.draw = true;
            }
        }
    });
}

//window.onload = displayorders("1");