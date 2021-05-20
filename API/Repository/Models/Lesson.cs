using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EquuSystem.Repository.Models
{
    [Table("lessons")]
    public partial class Lesson
    {
        [Key]
        [Column("lesson_id")]
        public int LessonId { get; set; }
        [Column("lesson_rider_id")]
        public int? LessonRiderId { get; set; }
        [Column("lesson_instructor_id")]
        public int? LessonInstructorId { get; set; }
        [Column("lesson_horse_id")]
        public int? LessonHorseId { get; set; }
        [Column("lesson_date", TypeName = "date")]
        public DateTime? LessonDate { get; set; }
        [Column("lesson_completed")]
        public byte? LessonCompleted { get; set; }
        [Column("lesson_time")]
        public TimeSpan? LessonTime { get; set; }
        [Column("lesson_status_id")]
        public int? LessonStatusId { get; set; }
        [Column("lesson_type_id")]
        public int? LessonTypeId { get; set; }
        [Column("lesson_created", TypeName = "datetime")]
        public DateTime? LessonCreated { get; set; }
        [Column("lesson_completed_datetime", TypeName = "datetime")]
        public DateTime? LessonCompletedDatetime { get; set; }
        [Column("IMPORT_STUDENT")]
        [StringLength(50)]
        public string ImportStudent { get; set; }
        [Column("IMPORT_HORSE")]
        [StringLength(20)]
        public string ImportHorse { get; set; }
        [Column("IMPORT_COMPLETED")]
        [StringLength(20)]
        public string ImportCompleted { get; set; }
        [Column("IMPORT_REOCCURANCE_ID")]
        public int? ImportReoccuranceId { get; set; }
        [Column("IMPORT_PRIVATE_LESSON")]
        [StringLength(20)]
        public string ImportPrivateLesson { get; set; }
        [Column("lesson_notes", TypeName = "text")]
        public string LessonNotes { get; set; }
        [Column("old_lesson_type_id")]
        public int? OldLessonTypeId { get; set; }
    }
}
