using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookShopOnline.Models
{
    [Serializable]
    public class CartItem
    {
        public Sach Sach { set; get; }
        public int SoLuong { set; get; }
    }
}