let data = new Vue({
    el: "#card-list",
    data(){
        return{
        object: [{
            imgURL: "../../../Images/SellerBackground/home/followers_num.png",
            label: "关注人数",
            num: 233,
        }, {
            imgURL: "../../../Images/SellerBackground/home/recent_profit.png",
            label: "本月盈利",
            num: 234,
        }, {
            imgURL: "../../../Images/SellerBackground/home/orders_num .png",
            label: "待发货订单",
            num: 2335,
        }, {
            imgURL: "../../../Images/SellerBackground/home/service_num.png",
            label: "退款售后订单",
            num: 2332,
                }],
            shopID:"",

    }
    },
    methods: {
        getData(shopID) {
            $.ajax({
                type: "post",
                //
                url: "",
                async: false,
                contentType: "application/json",
                dataType: "json",

                //传入ShopID
                data: JSON.stringify({ ShopID: shopID }), //请求类型
                success: function (result) {
                    for (let i = 0; i < 4; i++) {
                        //传出的result应该是一个长度为4的数组，里面存了对应的四个数
                        //关注人数、本月盈利、待发货订单数、退款售后订单数
                        this.object[i].num = result[i];
                    }
                }
            });
        },
        getShopID() {
            function getShopID() {
                $.ajax({
                    type: "get",
                    url: "/SellerBackground/GetShopIDForm",
                    async: false,
                    contentType: "application/json",
                    dataType: "json",
                    data: null,
                    success: function (result) {
                        ord.shopID = result;      //获取后端存储的shopID信息
                        console.log(result);
                        console.log("NowShopID:");
                        console.log(ord.shopID);
                    }
                });
            }
        }
    }
})

//传入ShopID
window.onload = data.getShopID();
window.onload = data.getData(data.shopID);