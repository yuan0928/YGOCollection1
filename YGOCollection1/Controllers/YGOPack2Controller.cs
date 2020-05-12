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
    public class YGOPack2Controller : Controller
    { 
        // GET: YGOPack2
        public ActionResult Index(short? cardnumberID)
        {
            YGOCardInfoEntities db = new YGOCardInfoEntities();
            YGOPack2ViewModel ygocardlist = new YGOPack2ViewModel();

            var packlist = db.refCardList.Where(rc => rc.ID == cardnumberID).ToList();
            foreach (var item in packlist) {
                ygocardlist.YGOPackLists = new YGOPackListViewModel()
                {

                    code = item.code,
                    packname = item.packname,
                    piece = item.piece
                };
            }
                
            //Monster Card
            var monsterlist = db.YGOMonsters.Where(y => y.CardNumberID == cardnumberID && y.cardenable ==true)
                                         .ToList();
         
            ygocardlist.YGOMonsterLists = new List<YGOMonsterListViewModel>();
            foreach(var item in monsterlist)
            {
                ygocardlist.YGOMonsterLists.Add(new YGOMonsterListViewModel()
                {
                    CardName = item.CardName,
                    CardNumber = item.CardNumber,
                    CardPassword = item.CardPassword,
                    CardExtra = item.CardExtra

                });
            }

            //Spell Card
            var spelllist = db.YGOSpells.Where(y => y.CardNumberID == cardnumberID && y.cardenable == true)
                                        .ToList();

            ygocardlist.YGOSpellLists = new List<YGOSpellListViewModel>();
            foreach (var item in spelllist)
            {
                ygocardlist.YGOSpellLists.Add(new YGOSpellListViewModel()
                {
                    CardName = item.CardName,
                    CardNumber = item.CardNumber,
                    CardPassword = item.CardPassword,
                });
            }
            //Trap Card
            var traplist = db.YGOTraps.Where(y => y.CardNumberID == cardnumberID && y.cardenable == true)
                                        .ToList();

            ygocardlist.YGOTrapLists = new List<YGOTrapListViewModel>();
            foreach (var item in traplist)
            {
                ygocardlist.YGOTrapLists.Add(new YGOTrapListViewModel()
                {
                    CardName = item.CardName,
                    CardNumber = item.CardNumber,
                    CardPassword = item.CardPassword,
                });
            }





            return View(ygocardlist);
        }
    }
}