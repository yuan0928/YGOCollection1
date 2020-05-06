using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using YGOCollection1.Models;

namespace YGOCollection1.ViewModels
{
    /*
    public class YGOPackViewModel
    {
        public string packname { get; set; }
        public Nullable<short> piece { get; set; }
        public string CardName { get; set; }
        [Key]
        public string CardPassword { get; set; }
        public Nullable<bool> CardExtra { get; set; }

        public string CardNumber { get; set; }
        public Nullable<bool> cardenable { get; set; }

    }
    */
    public class YGOPackViewModel {
        public YGOPackListViewModel packlist { get; set; }
        public YGOCardListViewModel cardlist { get; set; }
    }
    public class YGOPackListViewModel
    {
        public string packname { get; set; }
        public Nullable<short> piece { get; set; }

    }
    public class YGOCardListViewModel
    {
        public string CardName { get; set; }
        [Key]
        public string CardPassword { get; set; }
        public Nullable<bool> CardExtra { get; set; }

        public string CardNumber { get; set; }
        public Nullable<bool> cardenable { get; set; }

    }

}