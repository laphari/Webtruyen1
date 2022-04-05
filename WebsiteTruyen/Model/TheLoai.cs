using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteTruyen.Model
{
    public partial class TheLoai
    {
        public TheLoai()
        {
            Truyen = new HashSet<Truyen>();
        }

        [Key]
        [Column("IDTheLoai")]
        public int IdtheLoai { get; set; }
        [StringLength(50)]
        public string TenTheLoai { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeCreated { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeUpdated { get; set; }
        [Column(TypeName = "date")]
        public DateTime? TimeDeleted { get; set; }
        public int? UserCreated { get; set; }

        [InverseProperty("IdtheLoaiNavigation")]
        public virtual ICollection<Truyen> Truyen { get; set; }
    }
}
