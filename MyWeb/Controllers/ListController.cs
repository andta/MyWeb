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

        // GET: Default/Details/5
        //详细内容
        public ActionResult Details(int id)
        {
            return View();
        }

    }
}
