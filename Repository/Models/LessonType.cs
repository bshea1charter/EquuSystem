using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EquuSystem.Repository.Models
{
    [Table("lesson_type")]
    public partial class LessonType
    {
        [Key]
        [Column("lesson_type_id")]
        public int LessonTypeId { get; set; }
        [Column("lesson_type_text")]
        [StringLength(50)]
        public string LessonTypeText { get; set; }
        [Column("lesson_type_display_order")]
        public int? LessonTypeDisplayOrder { get; set; }
    }
}
