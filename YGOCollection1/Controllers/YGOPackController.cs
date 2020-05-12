using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YGOCollection1.Models;
using YGOCollection1.ViewModels;

namespace YGOCollection1.Controllers
{
    public class YGOPackController : Controller
    {
        // GET: YGOPack
        public ActionResult Index(short? cardnumberID)
        {
            YGOCardInfoEntities db = new YGOCardInfoEntities();
            List<YGOPackViewModel> YGOPack = new List<YGOPackViewModel>();

            
            var YGOPackList = db.refCardList.Where(rc => rc.ID == cardnumberID)
                            .Join(db.YGOMonsters, rc => rc.ID, ym => ym.CardNumberID,
                            (rc, ym) => new {
                                rc.packname,
                                rc.piece,
                                ym.CardName,
                                ym.CardPassword,
                                ym.CardExtra,
                                ym.CardNumber,
                                ym.cardenable
                            })
                            .Where(ym => ym.cardenable == true)
                            .ToList();
                  
            foreach (var item in YGOPackList)
            {
                YGOPackViewModel objvm = new YGOPackViewModel();
                objvm.packname = item.packname;
                objvm.piece = item.piece;
                objvm.CardPassword = item.CardPassword;
                objvm.CardExtra = item.CardExtra;
                objvm.CardNumber = item.CardNumber;
                objvm.CardName = item.CardName;
                YGOPack.Add(objvm);
            }

            return View(YGOPack);
        } 
    }
}