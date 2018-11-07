using System.ComponentModel.DataAnnotations.Schema;

namespace Million.Models
{
    public class UserAnswer: BaseDbObject
    {
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
        public int AnswerId { get; set; }
        public int UserId { get; set; }

    }
}
