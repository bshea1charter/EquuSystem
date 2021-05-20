using System;

namespace EquuSystem.Dtos
{
    public class InstructorReadDto
    {
        public int instructor_id { get; set; }
        public string instructor_first_name { get; set; }
        public string instructor_last_name { get; set; }
        public string instructor_phone { get; set; }
        public string instructor_user_id { get; set; }
        public string instructor_password { get; set; }
        public byte? instructor_admin { get; set; }
        public float? instructor_core_rate { get; set; }
        public float? instructor_session_rate { get; set; }
        public float? instructor_over_head_rate { get; set; }
        public float? instructor_session_over_head_rate { get; set; }
        public float? instructor_training_rate { get; set; }
    }
}