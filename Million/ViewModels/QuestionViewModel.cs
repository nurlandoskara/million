using System.ComponentModel.DataAnnotations;

namespace Million.ViewModels
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Answer1 { get; set; }
        [Required]
        public string Answer2 { get; set; }
        [Required]
        public string Answer3 { get; set; }
        [Required]
        public string Answer4 { get; set; }
        [Required]
        public int QuestionScopeId { get; set; }
    }
}
