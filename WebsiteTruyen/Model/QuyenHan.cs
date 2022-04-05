using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteTruyen.Model
{
    public partial class QuyenHan
    {
        [Key]
        [Column("IDQuyenHan")]
        public int IdquyenHan { get; set; }
        [StringLength(50)]
        public string TenQuyenHan { get; set; }

        [ForeignKey(nameof(IdquyenHan))]
        [InverseProperty(nameof(NguoiDung.QuyenHanNavigation))]
        public virtual NguoiDung IdquyenHanNavigation { get; set; }
    }
}
