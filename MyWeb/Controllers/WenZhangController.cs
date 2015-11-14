using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyWeb.Models;

namespace MyWeb.Controllers
{
    public class WenZhangController : Controller
    {
        private ModelContext db = new ModelContext();

        // GET: WenZhang
        public ActionResult Index()
        {
            var dbSet_WenZhang = db.DbSet_WenZhang.Include(w => w.YongHu);
            return View(dbSet_WenZhang.ToList());
        }

        // GET: WenZhang/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WenZhang wenZhang = db.DbSet_WenZhang.Find(id);
            if (wenZhang == null)
            {
                return HttpNotFound();
            }
            return View(wenZhang);
        }

        // GET: WenZhang/Create
        public ActionResult Create()
        {
            ViewBag.YongHuID = new SelectList(db.DbSet_YongHu, "ID", "YongHuMing");
            return View();
        }

        // POST: WenZhang/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Exclude = "YongHuID,ChuangJianRiQi,XiuGaiRiQi,PingLunLiang,ShouCangLiang,YueDuLiang", Include = "ID,BiaoTi,JianYao,ZhengWenNeiRong,JianYaoTuPian")] WenZhang wenZhang)
        {
            if (ModelState.IsValid)
            {
                wenZhang.YongHuID = 1;
                wenZhang.ChuangJianRiQi = DateTime.Now;
                wenZhang.XiuGaiRiQi = DateTime.Now;
                wenZhang.PingLunLiang = wenZhang.ShouCangLiang = wenZhang.YueDuLiang = 0;

                db.DbSet_WenZhang.Add(wenZhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.YongHuID = new SelectList(db.DbSet_YongHu, "ID", "YongHuMing", wenZhang.YongHuID);
            return View(wenZhang);
        }

        // GET: WenZhang/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WenZhang wenZhang = db.DbSet_WenZhang.Find(id);
            if (wenZhang == null)
            {
                return HttpNotFound();
            }
            ViewBag.YongHuID = new SelectList(db.DbSet_YongHu, "ID", "YongHuMing", wenZhang.YongHuID);
            return View(wenZhang);
        }

        // POST: WenZhang/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BiaoTi,JianYao,ZhengWenNeiRong,JianYaoTuPian,YongHuID,ChuangJianRiQi,XiuGaiRiQi,PingLunLiang,ShouCangLiang,YueDuLiang")] WenZhang wenZhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(wenZhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.YongHuID = new SelectList(db.DbSet_YongHu, "ID", "YongHuMing", wenZhang.YongHuID);
            return View(wenZhang);
        }

        // GET: WenZhang/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WenZhang wenZhang = db.DbSet_WenZhang.Find(id);
            if (wenZhang == null)
            {
                return HttpNotFound();
            }
            return View(wenZhang);
        }

        // POST: WenZhang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WenZhang wenZhang = db.DbSet_WenZhang.Find(id);
            db.DbSet_WenZhang.Remove(wenZhang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
