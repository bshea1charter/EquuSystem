using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EquuSystem.Repository.Models
{
    [Table("state")]
    public partial class State
    {
        [Key]
        [Column("state_id")]
        public int StateId { get; set; }
        [Column("state_abbr")]
        [StringLength(2)]
        public string StateAbbr { get; set; }
        [Column("state_name")]
        [StringLength(50)]
        public string StateName { get; set; }
    }
}
