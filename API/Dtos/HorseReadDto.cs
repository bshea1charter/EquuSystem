using System;

namespace EquuSystem.Dtos
{
    public class HorseReadDto
    {
        public int horse_id { get; set; }
        public string horse_name { get; set; }
        public int horse_breed_id { get; set; }
        public DateTime horse_dob { get; set; }
    }
}