using System.ComponentModel.DataAnnotations.Schema;

namespace Million.Models
{
    public class Answer: BaseDbObject
    {
        public string Text { get; set; }
        [ForeignKey("Question")]
        public int QuestionId { get; set; }
    }
}
