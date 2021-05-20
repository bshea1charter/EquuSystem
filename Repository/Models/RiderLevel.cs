using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EquuSystem.Repository.Models
{
    [Table("rider_level")]
    public partial class RiderLevel
    {
        [Key]
        [Column("rider_level_id")]
        public int RiderLevelId { get; set; }
        [Column("rider_level_text")]
        [StringLength(30)]
        public string RiderLevelText { get; set; }
    }
}
