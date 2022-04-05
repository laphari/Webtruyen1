using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteTruyen.Model
{
    public partial class NguoiDung
    {
        [Key]
        public int IdNguoidung { get; set; }
        [StringLength(50)]
        public string TenNguoiDung { get; set; }
        [StringLength(50)]
        public string MailNguoiDung { get; set; }
        [StringLength(50)]
        public string MatKhauNguoiDung { get; set; }
        public int? QuyenHan { get; set; }

        [InverseProperty("IdquyenHanNavigation")]
        public virtual QuyenHan QuyenHanNavigation { get; set; }
    }
}
