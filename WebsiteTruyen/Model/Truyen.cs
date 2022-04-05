using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteTruyen.Model
{
    public partial class Truyen
    {
        [Key]
        [Column("IDTruyen")]
        public int Idtruyen { get; set; }
        [StringLength(250)]
        public string TenTruyen { get; set; }
        public bool? Trangthai { get; set; }
        [Column(TypeName = "text")]
        public string AnhMoTaTruyen { get; set; }
        [Column("IDChitietTruyen")]
        public int? IdchitietTruyen { get; set; }
        [Column("IDTacGia")]
        public int? IdtacGia { get; set; }
        [Column("IDTheLoai")]
        public int IdtheLoai { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeCreated { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeUpdated { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeDeteted { get; set; }
        public int? UserCreated { get; set; }

        [ForeignKey(nameof(IdtheLoai))]
        [InverseProperty(nameof(TheLoai.Truyen))]
        public virtual TheLoai IdtheLoaiNavigation { get; set; }
        [InverseProperty("IdanhBiaNavigation")]
        public virtual AnhBia AnhBia { get; set; }
        [InverseProperty("IdChitietTruyenNavigation")]
        public virtual ChitetTruyen ChitetTruyen { get; set; }
    }
}
