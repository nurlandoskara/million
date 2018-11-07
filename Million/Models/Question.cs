using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Million.Models
{
    public class Question: BaseDbObject
    {
        public string Text { get; set; }
        [ForeignKey("Answer")]
        public int CorrectAnswerId { get; set; }
        [ForeignKey("QuestionScope")]
        public int QuestionScopeId { get; set; }
        public QuestionScope QuestionScope { get; set; }
        public List<UserAnswer> UserAnswers { get; set; }

        public int QuestionRating => (UserAnswers != null && UserAnswers.Any())
            ? UserAnswers.Count(x => x.AnswerId != CorrectAnswerId) -
              UserAnswers.Count(x => x.AnswerId == CorrectAnswerId)
            : 0;
    }
}
