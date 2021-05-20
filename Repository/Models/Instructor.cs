using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EquuSystem.Repository.Models
{
    [Table("instructors")]
    public partial class Instructor
    {
        [Key]
        [Column("instructor_id")]
        public int instructor_id { get; set; }
        [Column("instructor_first_name")]
        [StringLength(30)]
        public string instructor_first_name { get; set; }
        [Column("instructor_last_name")]
        [StringLength(30)]
        public string instructor_last_name { get; set; }
        [Column("instructor_phone")]
        [StringLength(12)]
        public string instructor_phone { get; set; }
        [Column("instructor_user_id")]
        [StringLength(20)]
        public string instructor_user_id { get; set; }
        [Column("instructor_password")]
        [StringLength(20)]
        public string instructor_password { get; set; }
        [Column("instructor_admin")]
        public byte? instructor_admin { get; set; }
        [Column("instructor_core_rate")]
        public float? instructor_core_rate { get; set; }
        [Column("instructor_session_rate")]
        public float? instructor_session_rate { get; set; }
        [Column("instructor_over_head_rate")]
        public float? instructor_over_head_rate { get; set; }
        [Column("instructor_session_over_head_rate")]
        public float? instructor_session_over_head_rate { get; set; }
        [Column("instructor_training_rate")]
        public float? instructor_training_rate { get; set; }
    }
}
