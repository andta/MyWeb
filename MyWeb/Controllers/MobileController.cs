using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;


namespace MyWeb.Controllers
{
    public class MobileController : Controller
    {
        private ModelContext db = new ModelContext();
        // GET: Default
        //列表全部数据
        public ActionResult Index()
        {
            return View(db.DbSet_WenZhang.ToList());
        }
        // GET: Mobile/ListPanel/n,m
        //列表加载更多，从第N条到第M条数据
        public ActionResult ListPanel(int skipCount, int takeCount)
        {
            //var m = from us in db.DbSet_WenZhang where us.BiaoTi == "中国" && us.JianYao == "中国" select us;
            var m = from us in db.DbSet_WenZhang select us;
            var list = m.ToList().Skip(skipCount).Take(takeCount).ToList();
            return PartialView(list);
        }
        // GET: Default/Details/5
        //详细内容
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: Mobile/AboutInfo
        //关于信息页面
        public ActionResult AboutInfo()
        {
            return View();
        }

    }
}
