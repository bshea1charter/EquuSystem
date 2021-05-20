using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EquuSystem.Repository.Models
{
    [Table("lesson_status")]
    public partial class LessonStatus
    {
        [Key]
        [Column("lesson_status_id")]
        public int LessonStatusId { get; set; }
        [Column("lesson_status_text")]
        [StringLength(30)]
        public string LessonStatusText { get; set; }
        [Column("lesson_status_sortorder")]
        public int? LessonStatusSortorder { get; set; }
        [Column("lesson_status_code")]
        [StringLength(5)]
        public string LessonStatusCode { get; set; }
    }
}
