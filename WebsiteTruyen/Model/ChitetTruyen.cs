using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteTruyen.Model
{
    public partial class ChitetTruyen
    {
        public ChitetTruyen()
        {
            NoiDungTruyen = new HashSet<NoiDungTruyen>();
        }

        [Key]
        public int IdChitietTruyen { get; set; }
        [StringLength(250)]
        public string AnhMoTaChitietTruyen { get; set; }
        public int? DanhGia { get; set; }
        [StringLength(250)]
        public string MoTaTruyen { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeCreated { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeUpdated { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeDeleted { get; set; }
        public int? UserCreated { get; set; }

        [ForeignKey(nameof(IdChitietTruyen))]
        [InverseProperty(nameof(Truyen.ChitetTruyen))]
        public virtual Truyen IdChitietTruyenNavigation { get; set; }
        [InverseProperty("IdchietTietTruyenNavigation")]
        public virtual ICollection<NoiDungTruyen> NoiDungTruyen { get; set; }
    }
}
