using System;

namespace Million.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public Guid Hash { get; set; }
        public int QuestionRating { get; set; }
    }
}
