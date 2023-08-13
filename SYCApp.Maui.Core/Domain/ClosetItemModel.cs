using System;
using SYCApp.Maui.Core.Database;

namespace SYCApp.Maui.Core.Domain
{
   
    public class ClosetItemModel : BaseDatabaseItem
    {
        public string Name { get; set; }
        public string Season { get; set; }
        public string ItemType { get; set; }
        public string Size { get; set; }
        public string Desc { get; set; }
    }
}


