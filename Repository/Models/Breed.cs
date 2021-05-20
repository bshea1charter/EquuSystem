using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EquuSystem.Repository.Models
{
    [Table("breeds")]
    public partial class Breed
    {
        [Key]
        [Column("breed_id")]
        public int breed_id { get; set; }
        [Column("breed_name")]
        [StringLength(20)]
        public string breed_name { get; set; }
    }
}
