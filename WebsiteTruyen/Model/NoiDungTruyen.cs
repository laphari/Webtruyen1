using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteTruyen.Model
{
    public partial class NoiDungTruyen
    {
        [Key]
        public int IdNoiDungTruyen { get; set; }
        public int? ChuongTruyen { get; set; }
        [Column("NoiDungTruyen")]
        [StringLength(255)]
        public string NoiDungTruyen1 { get; set; }
        [StringLength(255)]
        public string AnhTruyen { get; set; }
        [Column("IDChietTietTruyen")]
        public int? IdchietTietTruyen { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeCreated { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeUpdated { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeDeleted { get; set; }

        [ForeignKey(nameof(IdchietTietTruyen))]
        [InverseProperty(nameof(ChitetTruyen.NoiDungTruyen))]
        public virtual ChitetTruyen IdchietTietTruyenNavigation { get; set; }
    }
}
