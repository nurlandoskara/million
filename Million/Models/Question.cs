using System.ComponentModel.DataAnnotations.Schema;

namespace Million.Models
{
    public class Question: BaseDbObject
    {
        public string Text { get; set; }
        [ForeignKey("Answer")]
        public int? CorrectAnswerId { get; set; }
        [ForeignKey("QuestionScope")]
        public int QuestionScopeId { get; set; }
        public QuestionScope QuestionScope { get; set; }
    }
}
