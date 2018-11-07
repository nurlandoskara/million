using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Million.Data;
using Million.Dto;
using System;
using System.Linq;
using System.Threading.Tasks;
using Million.Models;

namespace Million.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public QuestionsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        public QuestionRequestDto GetQuestion(int rating)
        {
            var questions = _context.Questions.Where(x => x.QuestionRating >= rating).ToList();
            var rand = new Random();
            var question = questions.Skip(rand.Next(questions.Count)).FirstOrDefault();
            if (question == null)
            {
                return null;
            }
            var answers = _context.Answers.Where(x => x.QuestionId == question.Id)
                .Select(x => new { x.Id, x.Text }).ToDictionary(x => x.Id, x => x.Text);
            var questionDto = new QuestionRequestDto
            {
                Answers = answers,
                Id = question.Id,
                Text = question.Text,
                QuestionRating = question.QuestionRating
            };
            return questionDto;
        }

        // PUT: api/QuestionsApi/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuestion([FromRoute] int id, [FromBody] QuestionAnswerDto questionAnswerDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!IsUser(questionAnswerDto.UserId, questionAnswerDto.Hash)) return BadRequest();

            var question = _context.Questions.FirstOrDefault(x => x.Id == id);
            if (question == null) return BadRequest();//todo: respond wrong answer
            var userAnswer = new UserAnswer
            {
                QuestionId = id,
                AnswerId = questionAnswerDto.AnswerId,
                UserId = questionAnswerDto.UserId
            };
            _context.UserAnswers.Add(userAnswer);
            await _context.SaveChangesAsync();
            if (question.CorrectAnswerId == questionAnswerDto.AnswerId) ;//todo: respond and calculate money or smth
            return Ok(GetQuestion(questionAnswerDto.QuestionRating));
        }

        // POST: api/QuestionsApi
        [HttpPost]
        public IActionResult PostQuestion([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (!IsUser(userDto.Id, userDto.Hash)) return BadRequest();
            return Ok(GetQuestion(userDto.QuestionRating));
        }

        private bool IsUser(int id, Guid hash)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            return user != null && user.Hash == hash;
        }
    }
}