using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EquuSystem.Repository.Models
{
    [Table("lesson_rates")]
    public partial class LessonRate
    {
        [Key]
        [Column("lesson_rate_id")]
        public int LessonRateId { get; set; }
        [Column("lesson_rate_text")]
        [StringLength(30)]
        public string LessonRateText { get; set; }
        [Column("lesson_rate_rate")]
        public float? LessonRateRate { get; set; }
    }
}
