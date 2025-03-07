using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using InternetMall.Models;
using InternetMall.DBContext;
using InternetMall.Services;
using ThirdParty.Json.LitJson;
using Newtonsoft.Json;
using InternetMall.Models.BusinessEntity;

namespace InternetMall.Controllers
{
    public class SellerBackgroundController : Controller
    {
        //必要的成员变量与构造函数
        private readonly ModelContext _context;   //数据库上下文
        private ShopService shopService;
        private CommodityService commodityService;
        private SellerBackgroundServices sellerBackgroundService;
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;

        //构造函数
        [Obsolete]
        public SellerBackgroundController(ModelContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            shopService = new ShopService(_context);
            commodityService = new CommodityService(_context);
            sellerBackgroundService = new SellerBackgroundServices(_context);
            _hostingEnvironment = hostingEnvironment;
        }
        //显示页面
        public IActionResult Home()
        {
            //这里还需要再修改
            return View();
        }
        public IActionResult SwitchShop()
        {
            //这里还需要再修改
            return View();
        }
        public IActionResult Orders()
        {
            //这里还需要再修改
            return View();
        }

        public IActionResult Goods()
        {
            //这里还需要再修改
            return View();
        }

        public IActionResult Analysis()
        {
            //这里还需要再修改
            return View();
        }
        public IActionResult ShopSignUp()
        {
            if (Request.Cookies["sellerNickName"] != null)
            {
                return View();
            }
            else
            {
                return Redirect("/Entry/SellerLogIn");
            }
        }

        //前后端交互
        [HttpPost]
        [Obsolete]
        public IActionResult UploadCommodity()      //上传商品
        {
            var date = Request;
            var files = Request.Form.Files;   //上传的图片
            var data = Request.Form;     //上传的信息
            long size = files.Sum(f => f.Length);
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)   //上传图片成功
                {
                    long fileSize = formFile.Length; //获得文件大小，以字节为单位

                    var exetent = Path.GetExtension(formFile.FileName); //文件后缀名
                    var shopDicName = webRootPath + "/uploads/shops/1";//+ Request.Cookies["shopName"].ToString();
                    if (!Directory.Exists(shopDicName))
                    {
                        //新建对应的文件夹
                        Directory.CreateDirectory(shopDicName);
                    }
                    string newFileName = System.Guid.NewGuid().ToString(); //随机生成新的文件名
                    var filePath = shopDicName + "/" + newFileName + exetent; //newFileName;
                    var url = "/uploads/shops/1/" + newFileName + exetent;    //存入数据库中实际的内容

                    //新建商品
                    if (commodityService.Create(decimal.Parse(data["price"]), data["category"], data["description"], int.Parse(data["storage"])
                        , data["name"], "1", url))
                    {
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            formFile.CopyTo(stream);
                        }
                    }
                }
            }
            return Ok(new { count = files.Count, size });
        }

        [HttpPost]
        public IActionResult ShopSignUpForm([FromBody] ShopSignUp shopSignUp)     //申请店铺
        {
            short shopCategory;
            if (shopSignUp.Category == "官方旗舰店")
            {
                shopCategory = 1;
            }
            else if (shopSignUp.Category == "平台认证店")
            {
                shopCategory = 2;
            }
            else if (shopSignUp.Category == "个人店铺")
            {
                shopCategory = 3;
            }
            else  //未定义
            {
                shopCategory = 0;
            }

            if (shopService.createShop(shopSignUp.SellerID, shopSignUp.Name, shopCategory, shopSignUp.Description))
            {

                JsonData jsondata = new JsonData();
                jsondata["signUp"] = "SUCCESS";
                HttpContext.Response.Cookies.Append("shopName", shopSignUp.Name, new CookieOptions { Expires = DateTime.Now.AddSeconds(300) });
                return Json(jsondata.ToJson());
            }
            else
            {
                JsonData jsondata = new JsonData();
                jsondata["signUp"] = "ERROR";
                return Json(jsondata.ToJson());
            }
        }

        [HttpPost]
        public IActionResult DisplayOrdersForm([FromBody] DisplayOrders displayOrders)
        {
            var str = sellerBackgroundService.DisplayBriefOrder(displayOrders.ShopID);
            
            return new ContentResult { Content = str, ContentType = "application/json" };

        }

        [HttpPost]
        public IActionResult DisplayShopsForm([FromBody] DisplayShopsView displayshops)
        {
            var str = sellerBackgroundService.DisplayShops(displayshops.SellerID);

            if (str==null)
            {
                return new ContentResult { Content = "", ContentType = "application/json" };
            }
            return new ContentResult { Content = str, ContentType = "application/json" };         //进入“选择店铺”页面
        }
        [HttpPost]
        public IActionResult SetShopIDForm([FromBody] DisplayOrders sh)  //卖家选择店铺后更改全局的shopID信息
        {
            Global.GShopID = sh.ShopID;
            Console.WriteLine("修改后的shopID：" + Global.GShopID);
            JsonData jsondata = new JsonData();
            jsondata["result"] = Global.GShopID;
            return Json(jsondata.ToJson());
        }
        [HttpPost]
        public IActionResult GetShopIDForm()
        {
            var str = JsonConvert.SerializeObject(Global.GShopID);
            return new ContentResult { Content = str, ContentType = "application/json" }; ;
        }
        [HttpPost]
        public IActionResult SetIfShopForm([FromBody] CheckShop checkShop)
        {
            Global.GIfShop = checkShop.IfShop;
            JsonData jsondata = new JsonData();//返回值没用，只是为了符合返回要求
            jsondata["over"] = "YES";
            return Json(jsondata.ToJson());
        }
        [HttpPost]
        public IActionResult GetIfShopForm()
        {
            var str = JsonConvert.SerializeObject(Global.GIfShop);
            return new ContentResult { Content = str, ContentType = "application/json" }; ;
        }
    }
}
