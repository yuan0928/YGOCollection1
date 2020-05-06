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
        public ActionResult Index(short cardnumberID)
        {
            YGOCardInfoEntities db = new YGOCardInfoEntities();
            //List<YGOPackViewModel> YGOPack = new List<YGOPackViewModel>();
            var YGOPack = new YGOPackViewModel();
            var packlist = db.refCardList.Include(rc => rc.packname).Include(rc => rc.piece).Where(rc => rc.ID == cardnumberID).ToList();
            foreach (var item in packlist) {
                YGOPackListViewModel objpacklist = new YGOPackListViewModel();
                objpacklist.packname = item.packname;
                objpacklist.piece = item.piece;
                YGOPack.packlist =objpacklist;
            }
            
            
            if (packlist != null)
            {
                var cardlist = db.YGOMonsters.Include(ym => ym.CardName).Include(ym => ym.CardNumber).Include(ym => ym.CardExtra).Include(ym => ym.CardPassword)
                                                .Where(ym => ym.cardenable == true && ym.CardNumberID == cardnumberID).ToList();
                foreach (var item in cardlist)
                {
                    YGOCardListViewModel objcardlist = new YGOCardListViewModel();
                    objcardlist.CardPassword = item.CardPassword;
                    objcardlist.CardExtra = item.CardExtra;
                    objcardlist.CardNumber = item.CardNumber;
                    objcardlist.CardName = item.CardName;
                    YGOPack.cardlist= objcardlist;
                }
            }
           
            /*
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
                            .Where(ym =>ym.cardenable == true)
                            .ToList();

        foreach(var item in YGOPackList)
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
        */
            return View(YGOPack);
        } 
    }
}