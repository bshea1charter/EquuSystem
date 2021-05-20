using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EquuSystem.Repository.Models
{
    [Table("rider_waitlist")]
    public partial class RiderWaitlist
    {
        [Key]
        [Column("rider_waitlist_id")]
        public int RiderWaitlistId { get; set; }
        [Column("rider_waitlist_first_name")]
        [StringLength(30)]
        public string RiderWaitlistFirstName { get; set; }
        [Column("rider_waitlist_last_name")]
        [StringLength(50)]
        public string RiderWaitlistLastName { get; set; }
        [Column("rider_waitlist_phone")]
        [StringLength(12)]
        public string RiderWaitlistPhone { get; set; }
        [Column("rider_waitlist_email")]
        [StringLength(50)]
        public string RiderWaitlistEmail { get; set; }
        [Column("rider_waitlist_date", TypeName = "date")]
        public DateTime? RiderWaitlistDate { get; set; }
        [Column("rider_waitlist_notes")]
        [StringLength(255)]
        public string RiderWaitlistNotes { get; set; }
    }
}
