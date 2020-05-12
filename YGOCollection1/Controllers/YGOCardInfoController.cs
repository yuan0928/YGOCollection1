using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using YGOCollection1.Models;

namespace YGOCollection1.Controllers
{
    public class YGOCardInfoController : Controller
    {
        YGOCardInfoEntities db = new YGOCardInfoEntities();
        // GET: YGOCardInfo
        public ActionResult Details(string password)
        {
            if (password == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var monsterinfo = db.YGOMonsters.Where( m => m.CardPassword ==password );
            if (monsterinfo == null)
            {
                return HttpNotFound();
            }
            return View(monsterinfo);
        }
    }
}