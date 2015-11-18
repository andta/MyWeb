using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;


namespace MyWeb.Controllers
{
    public class ListController : Controller
    {
        private ModelContext db = new ModelContext();
        // GET: Default
        //列表
        public ActionResult Index()
        {

            return View(db.DbSet_WenZhang.ToList());
        }
        public ActionResult ListPanel(int skipCount, int takeCount)
        {
            //var m = from us in db.DbSet_WenZhang where us.BiaoTi == "中国" && us.JianYao == "中国" select us;
            var m = from us in db.DbSet_WenZhang  select us;
            //if (m.Count() != 0)
            //{

            //}
          
            var list = m.ToList().Skip(skipCount).Take(takeCount).ToList();
            return PartialView(list);
        }
 

        // GET: Default/Details/5
        //详细内容
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
