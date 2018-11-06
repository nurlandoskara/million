using System.ComponentModel.DataAnnotations.Schema;

namespace Million.Models
{
    public class QuestionRating: BaseDbObject
    {
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public bool Answered { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
