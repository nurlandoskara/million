using System.ComponentModel.DataAnnotations.Schema;

namespace Million.Models
{
    public class UserAnswer: BaseDbObject
    {
        public int QuestionId { get; set; }
        public int AnswerId { get; set; }
        public int UserId { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}
