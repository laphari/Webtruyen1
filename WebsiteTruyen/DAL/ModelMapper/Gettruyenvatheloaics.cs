using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteTruyen.Model;

namespace WebsiteTruyen.DAL.ModelMapper
{
    public class Gettruyenvatheloaics
    {
        public Truyen Truyen {get;set;}
        public int IdNguoidung { get; set; }
        public string TenNguoiDung { get; set; }
    }
}