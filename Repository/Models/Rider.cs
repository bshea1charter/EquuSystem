using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace EquuSystem.Repository.Models
{
    [Table("riders")]
    public partial class Rider
    {
        [Key]
        [Column("rider_id")]
        public int RiderId { get; set; }
        [Column("rider_first_name")]
        [StringLength(30)]
        public string RiderFirstName { get; set; }
        [Column("rider_last_name")]
        [StringLength(50)]
        public string RiderLastName { get; set; }
        [Column("rider_address_line_1")]
        [StringLength(50)]
        public string RiderAddressLine1 { get; set; }
        [Column("rider_address_line_2")]
        [StringLength(50)]
        public string RiderAddressLine2 { get; set; }
        [Column("rider_city")]
        [StringLength(30)]
        public string RiderCity { get; set; }
        [Column("rider_state")]
        public int? RiderState { get; set; }
        [Column("rider_zipcode")]
        [StringLength(10)]
        public string RiderZipcode { get; set; }
        [Column("rider_home_phone")]
        [StringLength(12)]
        public string RiderHomePhone { get; set; }
        [Column("rider_primary_contact")]
        [StringLength(30)]
        public string RiderPrimaryContact { get; set; }
        [Column("rider_primary_contact_phone")]
        [StringLength(12)]
        public string RiderPrimaryContactPhone { get; set; }
        [Column("rider_primary_contact_email")]
        [StringLength(50)]
        public string RiderPrimaryContactEmail { get; set; }
        [Column("rider_secondary_contact")]
        [StringLength(30)]
        public string RiderSecondaryContact { get; set; }
        [Column("rider_secondary_contact_phone")]
        [StringLength(12)]
        public string RiderSecondaryContactPhone { get; set; }
        [Column("rider_secondary_contact_email")]
        [StringLength(50)]
        public string RiderSecondaryContactEmail { get; set; }
        [Column("rider_dob", TypeName = "date")]
        public DateTime? RiderDob { get; set; }
        [Column("rider_since", TypeName = "date")]
        public DateTime? RiderSince { get; set; }
        [Column("rider_level_id")]
        public int? RiderLevelId { get; set; }
        [Column("rider_active")]
        public byte? RiderActive { get; set; }
        [Column("rider_nickname")]
        [StringLength(20)]
        public string RiderNickname { get; set; }
        [Column("rider_primary_contact_phone_2")]
        [StringLength(12)]
        public string RiderPrimaryContactPhone2 { get; set; }
        [Column("rider_secondary_contact_phone_2")]
        [StringLength(12)]
        public string RiderSecondaryContactPhone2 { get; set; }
        [Column("IMPORT_rider_id")]
        public int? ImportRiderId { get; set; }
        [Column("IMPORT_rider_level")]
        [StringLength(20)]
        public string ImportRiderLevel { get; set; }
        [Column("IMPORT_rider_notes")]
        [StringLength(255)]
        public string ImportRiderNotes { get; set; }
        [Column("IMPORT_balance")]
        public float? ImportBalance { get; set; }
        [Column("IMPORT_lesson_fee")]
        public float? ImportLessonFee { get; set; }
        [Column("IMPORT_private_lesson_fee")]
        public float? ImportPrivateLessonFee { get; set; }
        [Column("IMPORT_active")]
        [StringLength(20)]
        public string ImportActive { get; set; }
        [Column("IMPORT_state")]
        [StringLength(10)]
        public string ImportState { get; set; }
        [Column("IMPORT_rider_lookup")]
        [StringLength(100)]
        public string ImportRiderLookup { get; set; }
        [Column("rider_is_core")]
        public byte? RiderIsCore { get; set; }
        [Column("rider_is_ten_percent")]
        public byte? RiderIsTenPercent { get; set; }
        [Column("rider_private_core_rate")]
        public float? RiderPrivateCoreRate { get; set; }
        [Column("rider_semi_private_core_rate")]
        public float? RiderSemiPrivateCoreRate { get; set; }
    }
}
