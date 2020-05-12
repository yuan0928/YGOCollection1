using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using YGOCollection1.Models;
using YGOCollection1.ViewModels;

namespace YGOCollection1.Controllers
{
    public class MainPageController : Controller
    {
        // GET: MianPage
        public ActionResult Index()
        {

            YGOCardInfoEntities db = new YGOCardInfoEntities();
            var packlistviewmodel = new MainPageViewModel();

            var groupnamelist = db.refpackgroup.ToList();

            packlistviewmodel.MainPageAlls = new List<MainPageAllList>();

            var objmainpacklist = new List<MainPageList>();


            foreach (var item in groupnamelist)
            {

                packlistviewmodel.MainPageAlls.Add(new MainPageAllList()
                {
                    GroupNames = item.groupname
                });
            }
            return View(packlistviewmodel);

        }
        public ActionResult Index2() {
            YGOCardInfoEntities db = new YGOCardInfoEntities();
            //var packlistviewmodel = new MainPageViewModel();
            var packlistviewmodel = new MainPageAllList2();

            var groupnamelist = db.refpackgroup.ToList();


            //packlistviewmodel.MainPageAlls = new List<MainPageAllList>();

            packlistviewmodel.GroupNames = new List<GroupNameList>();
            foreach (var item in groupnamelist) {
                packlistviewmodel.GroupNames.Add(new GroupNameList() {
                    Groupname = item.groupname
                });
            }

            var codellist = db.refCardList.ToList();
            packlistviewmodel.MainPages = new List<MainPageList>();
            foreach (var item in codellist) {
                packlistviewmodel.MainPages.Add(new MainPageList() {
                    ID = item.ID,
                    Code = item.code,
                    Packgroup = item.packgroup
                });
            }
            /*     
                  foreach(var item in groupnamelist)
                  {
                      packlistviewmodel.MainPageAlls.Add(new MainPageAllList()
                      {
                          GroupNames = item.groupname
                      }) ;
                      for (int i = 1; i <= groupnamelist.Count(); i++)
                      {
                          var packcode = db.refCardList.Where(rc => rc.packgroup == i).ToList();
                          var packcodelist = new List<MainPageList>();
                          foreach (var item2 in packcode) {
                              packcodelist.Add(new MainPageList() {
                                  ID =item2.ID,
                                  Code = item2.code,
                                  Packgroup =item2.packgroup

                              });
                          }


                          packlistviewmodel.MainPageAlls.Add(new MainPageAllList()
                          {
                              MainPages=packcodelist
                          });


                      }

                  }
                  */
            return View(packlistviewmodel);
        }
        public ActionResult Index3()
        {
            YGOCardInfoEntities db = new YGOCardInfoEntities();
            var packlistviewmodel = new forindex3();

            var groupnamelist = db.refpackgroup.ToList();
            packlistviewmodel.GroupNames = new List<GroupNameList>();
            foreach (var item in groupnamelist) {
                packlistviewmodel.GroupNames.Add(new GroupNameList() {
                    Groupname = item.groupname
                });
            }

            for (int i = 1; i <= groupnamelist.Count(); i++)
            {

                var codelist = db.refCardList.Where(rc => rc.packgroup == i).ToList();
                packlistviewmodel.per1 = new List<MainPageList>();
                foreach (var item in codelist)
                {
                    packlistviewmodel.per1.Add(new MainPageList() {
                        ID = item.ID,
                        Code = item.code,
                        Packgroup = item.packgroup
                    });
                }
            }

            return View(packlistviewmodel);
        }
        public ActionResult Index3_1()
        {
            YGOCardInfoEntities db = new YGOCardInfoEntities();
            var packlistviewmodel = new forindex3_1();

            var groupnamelist = db.refpackgroup.ToList();
            packlistviewmodel.GroupNames = new List<GroupNameList>();
            foreach (var item in groupnamelist) {
                packlistviewmodel.GroupNames.Add(new GroupNameList() {
                    Groupname = item.groupname
                });
            }

            packlistviewmodel.Per = new List<MainPageList>();
            // for (int i = 1; i <= groupnamelist.Count(); i++)
            //{
            var codelist = db.refCardList.ToList();
            foreach (var item in codelist)
            {
                packlistviewmodel.Per.Add(new MainPageList()
                {
                    ID = item.ID,
                    Code = item.code,
                    Packgroup = item.packgroup
                });
            }


            //}
            return View(packlistviewmodel);
        }

        public ActionResult Index3_2()
        {
            YGOCardInfoEntities db = new YGOCardInfoEntities();
            // var packlistviewmodel = new forindex3_2();
            var packlist = db.refCardList.Include(rc => rc.refpackgroup)
                                            .GroupBy(rc => rc.refpackgroup.groupname, rc => rc.code, (key, group) => new forindex3_2
                                            {
                                                Groupnames = key,
                                                Per = group.ToList()
                                            }).ToList();
           

            //IEnumerable<IGrouping<short?, string>> model = db.refCardList.GroupBy(rc => rc.packgroup,rc => rc.code);


            return View(packlist);
        }
        public ActionResult Index3_2_1() {
            YGOCardInfoEntities db = new YGOCardInfoEntities();
            var packlist = db.refCardList.Include(rc => rc.refpackgroup)
                                              .GroupBy(rc => new { rc.refpackgroup.groupname, rc.packgroup},rc =>rc.code)
                                              .Select(rc => new forindex3_2_1
                                              {
                                                  Groupnames = rc.Key.groupname,
                                                  GroupID = rc.Key.packgroup,
                                                  Per = rc.ToList()
                                              })
                                              .OrderBy(rc => rc.GroupID)
                                              .ToList();
            return View(packlist);
        }
        public ActionResult Index3_2_2()
        {
            YGOCardInfoEntities db = new YGOCardInfoEntities();
            var packlist = db.refCardList.Include(rc => rc.refpackgroup)
                                              .GroupBy(rc => new { rc.refpackgroup.groupname, rc.packgroup }  )
                                              .Select(g => new forindex3_2_2
                                              {
                                                  Groupnames = g.Key.groupname,
                                                  GroupID = g.Key.packgroup,
                                                  Percode =g.Select( rc =>rc.code).ToList(),
                                                  PerId = g.Select(rc => rc.ID).ToList(),
                                              })
                                              .OrderBy(rc => rc.GroupID)
                                              .ToList();
            return View(packlist);
        }
        public ActionResult Index3_2_3()
        {
            YGOCardInfoEntities db = new YGOCardInfoEntities();
            
            var packlist = db.refCardList.Include(rc => rc.refpackgroup)
                                              .GroupBy(rc => new { rc.refpackgroup.groupname, rc.packgroup })
                                              .Select(g => new forindex3_2_3
                                              {
                                                  Groupnames = g.Key.groupname,
                                                  GroupID = g.Key.packgroup,
                                                
                                              })
                                              .OrderBy(rc => rc.GroupID)
                                              .ToList();
            
            return View(packlist);
        }
    }
    
}
