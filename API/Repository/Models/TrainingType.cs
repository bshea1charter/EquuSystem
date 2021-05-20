using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EquuSystem.Repository.Models
{
    [Table("training_type")]
    public partial class TrainingType
    {
        [Key]
        [Column("training_type_id")]
        public int TrainingTypeId { get; set; }
        [Column("training_type_text")]
        [StringLength(30)]
        public string TrainingTypeText { get; set; }
        [Column("training_type_cost")]
        public float? TrainingTypeCost { get; set; }
        [Column("training_type_cost2")]
        public float? TrainingTypeCost2 { get; set; }
    }
}
