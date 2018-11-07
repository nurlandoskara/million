using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Million.Data;
using Million.Models;
using Million.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Million.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Questions.Include(q => q.QuestionScope);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.QuestionScope)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            ViewData["QuestionScopeId"] = new SelectList(_context.QuestionScopes, "Id", "Name");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(QuestionViewModel questionViewModel)
        {
            if (ModelState.IsValid)
            {
                var question = new Question
                {
                    Text = questionViewModel.Text,
                    QuestionScopeId = questionViewModel.QuestionScopeId
                };
                _context.Add(question);
                _context.SaveChanges();

                var correctAnswer = new Answer
                {
                    QuestionId = question.Id,
                    Text = questionViewModel.Answer1
                };
                int correctAnswerId;
               
                _context.Set<Answer>().Add(correctAnswer);
                _context.SaveChanges();
                correctAnswerId = correctAnswer.Id;

                question.CorrectAnswerId = correctAnswerId;
                _context.Update(question);
                _context.SaveChanges();

                var answers = new List<Answer>
                {
                    new Answer
                    {
                        QuestionId = question.Id,
                        Text = questionViewModel.Answer2
                    },
                    new Answer
                    {
                        QuestionId = question.Id,
                        Text = questionViewModel.Answer3
                    },
                    new Answer
                    {
                        QuestionId = question.Id,
                        Text = questionViewModel.Answer4
                    }
                };

                foreach (var answer in answers)
                {
                    _context.Set<Answer>().Add(answer);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuestionScopeId"] = new SelectList(_context.QuestionScopes, "Id", "Name", questionViewModel.QuestionScopeId);
            return View(questionViewModel);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["QuestionScopeId"] = new SelectList(_context.QuestionScopes, "Id", "Id", question.QuestionScopeId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Text,CorrectAnswerId,QuestionScopeId,Id,IsDeleted")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuestionScopeId"] = new SelectList(_context.QuestionScopes, "Id", "Id", question.QuestionScopeId);
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.QuestionScope)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
            return _context.Questions.Any(e => e.Id == id);
        }
    }
}
