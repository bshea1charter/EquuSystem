using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EquuSystem.Repository.Models
{
    [Table("free_lesson")]
    public partial class FreeLesson
    {
        [Key]
        [Column("free_lesson_id")]
        public int FreeLessonId { get; set; }
        [Column("free_lesson_rider_id")]
        public int? FreeLessonRiderId { get; set; }
        [Column("free_lesson_type_id")]
        public int? FreeLessonTypeId { get; set; }
        [Column("free_lesson_date", TypeName = "date")]
        public DateTime? FreeLessonDate { get; set; }
    }
}
