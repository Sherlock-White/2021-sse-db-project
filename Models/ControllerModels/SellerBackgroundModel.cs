﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetMall.Models
{
    public class ShopSignUp     //新建店铺
    {
        public string SellerID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }

    public class DisplayOrders //显示店铺订单
    {
        public string ShopID { get; set; }
    }

    public class DisplayShops  //显示卖家拥有的订单
    {
        public string SellerID { get; set; }
    }
    public class CheckShop     //记录有无店铺的信息
    {
        public string IfShop { get; set; }
    }


}


