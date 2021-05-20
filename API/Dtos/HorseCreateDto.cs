using System;

namespace EquuSystem.Dtos
{
    public class HorseCreateDto
    {
        public string horse_name { get; set; }
        public int horse_breed_id { get; set; }
        public DateTime horse_dob { get; set; }
    }
}