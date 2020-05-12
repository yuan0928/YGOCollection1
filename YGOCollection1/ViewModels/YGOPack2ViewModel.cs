using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace YGOCollection1.ViewModels
{
    public class YGOPack2ViewModel
    {

        public YGOPackListViewModel YGOPackLists { get; set; }
        public List<YGOMonsterListViewModel> YGOMonsterLists { get; set; }
        public List<YGOSpellListViewModel> YGOSpellLists { get; set; }
        public List<YGOTrapListViewModel> YGOTrapLists { get; set; }
    }
    public class YGOPackListViewModel
    {
        public string code { get; set; }
        public string packname { get; set; }
        public Nullable<short> piece { get; set; }

    }

    public class YGOMonsterListViewModel
    {
        public string CardName { get; set; }
        public string CardPassword { get; set; }
        public Nullable<bool> CardExtra { get; set; }
        public string CardNumber { get; set; }

    }
    public class YGOSpellListViewModel
    {
        public string CardName { get; set; }
        public string CardPassword { get; set; }
        public string CardNumber { get; set; }

    }
    public class YGOTrapListViewModel
    {
        public string CardName { get; set; }
        public string CardPassword { get; set; }
        public string CardNumber { get; set; }
    }
}