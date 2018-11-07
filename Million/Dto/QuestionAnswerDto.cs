using System;

namespace Million.Dto
{
    public class QuestionAnswerDto
    {
        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public Guid Hash { get; set; }
        public int QuestionRating { get; set; }
    }
}
