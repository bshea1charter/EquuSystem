using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EquuSystem.Repository.Models
{
    public partial class training
    {
        [Key]
        [Column("training_id")]
        public int TrainingId { get; set; }
        [Column("training_instructor_id")]
        public int? TrainingInstructorId { get; set; }
        [Column("training_horse_id")]
        public int? TrainingHorseId { get; set; }
        [Column("training_training_type_id")]
        public int? TrainingTrainingTypeId { get; set; }
        [Column("training_date", TypeName = "datetime")]
        public DateTime? TrainingDate { get; set; }
        [Column("training_notes", TypeName = "text")]
        public string TrainingNotes { get; set; }
    }
}
