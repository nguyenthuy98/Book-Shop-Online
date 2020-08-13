using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopOnline.Common
{
    [Serializable]
    public class UserLogin
    {
        public long UserID { set; get; }
        public string UserName { set; get; }
        public long GroupID { set; get; }
        public string Image { set; get; }
        public string Name { set; get; }
    }
}