using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace YGOCollection1.ViewModels
{
    public class MainPageViewModel
    {
        public List<MainPageAllList> MainPageAlls { get; set; }

    }
    public class MainPageAllList
    {
        public string GroupNames { get; set; }
        public List<MainPageList> MainPages { get; set; }
    }
    public class MainPageAllList2
    {
        public List<GroupNameList> GroupNames { get; set; }
        public List<MainPageList> MainPages { get; set; }
    }
    public class MainPageList
    {
        public short ID { get; set; }
        public string Code { get; set; }
        public Nullable<short> Packgroup { get; set; }

    }
    public class GroupNameList
    {
        public string Groupname { get; set; }
    }
    public class forindex3{
        public List<GroupNameList> GroupNames { get; set; }
        public List<MainPageList> per1 { get; set; }
        public List<MainPageList> per2 { get; set; }
        public List<MainPageList> per3 { get; set; }
        public List<MainPageList> per4 { get; set; }
        public List<MainPageList> per5 { get; set; }
        public List<MainPageList> per6 { get; set; }
        public List<MainPageList> per7 { get; set; }
        public List<MainPageList> per8 { get; set; }
    }
    public class forindex3_1
    {
        public List<GroupNameList> GroupNames { get; set; }
        public List<MainPageList> Per { get; set; }
      
    }
    public class forindex3_2
    {
    
        public string Groupnames { get; set; }
        public List<string> Per { get; set; }

    }
    public class forindex3_2_1
    {

        public string Groupnames { get; set; }
        public short GroupID { get; set; }
        public List<string> Per { get; set; }

    }
    public class forindex3_2_2
    {

        public string Groupnames { get; set; }
        public short GroupID { get; set; }
        public List<string> Percode { get; set; }
        public List<short> PerId { get; set; }

    }
    public class forindex3_2_3
    {

        public string Groupnames { get; set; }
        public short GroupID { get; set; }
        public List<PerList> Per { get; set; }


    }
    public class PerList {
        public short ID { get; set; }
        public string Code { get; set; }
    }

}