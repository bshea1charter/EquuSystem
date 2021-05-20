using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EquuSystem.Repository.Models
{
    [Table("horses")]
    public partial class Horse
    {
        [Key]
        [Column("horse_id")]
        public int horse_id { get; set; }
        [Column("horse_name")]
        [StringLength(20)]
        public string horse_name { get; set; }
        [Column("horse_breed_id")]
        public int? horse_breed_id { get; set; }
        [Column("horse_dob", TypeName = "date")]
        public DateTime? horse_dob { get; set; }
    }
}
