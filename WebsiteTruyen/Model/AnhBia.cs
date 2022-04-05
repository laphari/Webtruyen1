using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebsiteTruyen.Model
{
    public partial class AnhBia
    {
        [Key]
        [Column("IDAnhBia")]
        public int IdanhBia { get; set; }
        [Column("AnhBia", TypeName = "text")]
        public string AnhBia1 { get; set; }
        [StringLength(50)]
        public string TenAnhBia { get; set; }
        [Column("IDtruyen")]
        public int? Idtruyen { get; set; }

        [ForeignKey(nameof(IdanhBia))]
        [InverseProperty(nameof(Truyen.AnhBia))]
        public virtual Truyen IdanhBiaNavigation { get; set; }
    }
}
