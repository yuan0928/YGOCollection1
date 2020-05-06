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
    public class YGOSpellsController : Controller
    {
        private YGOCardInfoEntities db = new YGOCardInfoEntities();

        // GET: YGOSpells
        public ActionResult Index()
        {
            var yGOSpells = db.YGOSpells.Include(y => y.refCardList).Include(y => y.TypeSpellCard);
            return View(yGOSpells.ToList());
        }

        // GET: YGOSpells/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YGOSpells yGOSpells = db.YGOSpells.Find(id);
            if (yGOSpells == null)
            {
                return HttpNotFound();
            }
            return View(yGOSpells);
        }

        // GET: YGOSpells/Create
        public ActionResult Create()
        {
            ViewBag.CardNumberID = new SelectList(db.refCardList, "ID", "code");
            ViewBag.CardTypeID = new SelectList(db.TypeSpellCard, "ID", "cardtype");
            return View();
        }

        // POST: YGOSpells/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CardID,CardName,CardTypeID,CardNumberID,CardPassword,create_at,update_at,CardNumber")] YGOSpells yGOSpells)
        {
            if (ModelState.IsValid)
            {
                db.YGOSpells.Add(yGOSpells);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CardNumberID = new SelectList(db.refCardList, "ID", "code", yGOSpells.CardNumberID);
            ViewBag.CardTypeID = new SelectList(db.TypeSpellCard, "ID", "cardtype", yGOSpells.CardTypeID);
            return View(yGOSpells);
        }

        // GET: YGOSpells/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YGOSpells yGOSpells = db.YGOSpells.Find(id);
            if (yGOSpells == null)
            {
                return HttpNotFound();
            }
            ViewBag.CardNumberID = new SelectList(db.refCardList, "ID", "code", yGOSpells.CardNumberID);
            ViewBag.CardTypeID = new SelectList(db.TypeSpellCard, "ID", "cardtype", yGOSpells.CardTypeID);
            return View(yGOSpells);
        }

        // POST: YGOSpells/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CardID,CardName,CardTypeID,CardNumberID,CardPassword,create_at,update_at,CardNumber")] YGOSpells yGOSpells)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yGOSpells).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CardNumberID = new SelectList(db.refCardList, "ID", "code", yGOSpells.CardNumberID);
            ViewBag.CardTypeID = new SelectList(db.TypeSpellCard, "ID", "cardtype", yGOSpells.CardTypeID);
            return View(yGOSpells);
        }

        // GET: YGOSpells/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YGOSpells yGOSpells = db.YGOSpells.Find(id);
            if (yGOSpells == null)
            {
                return HttpNotFound();
            }
            return View(yGOSpells);
        }

        // POST: YGOSpells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            YGOSpells yGOSpells = db.YGOSpells.Find(id);
            db.YGOSpells.Remove(yGOSpells);
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
