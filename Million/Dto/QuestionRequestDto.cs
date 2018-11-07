using System.Collections.Generic;

namespace Million.Dto
{
    public class QuestionRequestDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public Dictionary<int, string> Answers { get; set; }
        public int QuestionRating { get; set; }
    }
}
