using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YGOCollection1.Models;

namespace YGOCollection1.Controllers
{
    public class YGOMonstersController : Controller
    {
        private YGOCardInfoEntities db = new YGOCardInfoEntities();

        // GET: YGOMonsters
        public ActionResult Index()
        {
            var yGOMonsters = db.YGOMonsters.Include(y => y.refAttribute).Include(y => y.refCardList).Include(y => y.refMonsterType).Include(y => y.TypeMonsterCard).Where(y => y.cardenable == true);
            return View(yGOMonsters.ToList());
        }

        // GET: YGOMonsters/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YGOMonsters yGOMonsters = db.YGOMonsters.Find(id);
            if (yGOMonsters == null)
            {
                return HttpNotFound();
            }
            return View(yGOMonsters);
        }

        // GET: YGOMonsters/Create
        public ActionResult Create()
        {
            ViewBag.CardAttributeID = new SelectList(db.refAttribute, "ID", "attribute");
            ViewBag.CardNumberID = new SelectList(db.refCardList, "ID", "code");
            ViewBag.MonsterTypeID = new SelectList(db.refMonsterType, "ID", "Attribute");
            ViewBag.CardTypeID = new SelectList(db.TypeMonsterCard, "ID", "cardtype");
            return View();
        }

        // POST: YGOMonsters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardID,CardName,CardAttributeID,CardLevel,MonsterTypeID,CardTypeID,ATK,DEF,CardNumberID,CardPassword,CardExtra,create_at,update_at,CardNumber")] YGOMonsters yGOMonsters)
        {
            if (ModelState.IsValid)
            {
                db.YGOMonsters.Add(yGOMonsters);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CardAttributeID = new SelectList(db.refAttribute, "ID", "attribute", yGOMonsters.CardAttributeID);
            ViewBag.CardNumberID = new SelectList(db.refCardList, "ID", "code", yGOMonsters.CardNumberID);
            ViewBag.MonsterTypeID = new SelectList(db.refMonsterType, "ID", "Attribute", yGOMonsters.MonsterTypeID);
            ViewBag.CardTypeID = new SelectList(db.TypeMonsterCard, "ID", "cardtype", yGOMonsters.CardTypeID);
            return View(yGOMonsters);
        }

        // GET: YGOMonsters/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YGOMonsters yGOMonsters = db.YGOMonsters.Find(id);
            if (yGOMonsters == null)
            {
                return HttpNotFound();
            }
            ViewBag.CardAttributeID = new SelectList(db.refAttribute, "ID", "attribute", yGOMonsters.CardAttributeID);
            ViewBag.CardNumberID = new SelectList(db.refCardList, "ID", "code", yGOMonsters.CardNumberID);
            ViewBag.MonsterTypeID = new SelectList(db.refMonsterType, "ID", "Attribute", yGOMonsters.MonsterTypeID);
            ViewBag.CardTypeID = new SelectList(db.TypeMonsterCard, "ID", "cardtype", yGOMonsters.CardTypeID);
            return View(yGOMonsters);
        }

        // POST: YGOMonsters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CardID,CardName,CardAttributeID,CardLevel,MonsterTypeID,CardTypeID,ATK,DEF,CardNumberID,CardPassword,CardExtra,create_at,update_at,CardNumber")] YGOMonsters yGOMonsters)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yGOMonsters).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CardAttributeID = new SelectList(db.refAttribute, "ID", "attribute", yGOMonsters.CardAttributeID);
            ViewBag.CardNumberID = new SelectList(db.refCardList, "ID", "code", yGOMonsters.CardNumberID);
            ViewBag.MonsterTypeID = new SelectList(db.refMonsterType, "ID", "Attribute", yGOMonsters.MonsterTypeID);
            ViewBag.CardTypeID = new SelectList(db.TypeMonsterCard, "ID", "cardtype", yGOMonsters.CardTypeID);
            return View(yGOMonsters);
        }

        // GET: YGOMonsters/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YGOMonsters yGOMonsters = db.YGOMonsters.Find(id);
            if (yGOMonsters == null)
            {
                return HttpNotFound();
            }
            return View(yGOMonsters);
        }

        // POST: YGOMonsters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            YGOMonsters yGOMonsters = db.YGOMonsters.Find(id);
            db.YGOMonsters.Remove(yGOMonsters);
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
