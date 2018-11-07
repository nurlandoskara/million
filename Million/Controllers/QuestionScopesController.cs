using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Million.Data;
using Million.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Million.Controllers
{
    public class QuestionScopesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuestionScopesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: QuestionScopes
        public async Task<IActionResult> Index()
        {
            return View(await _context.QuestionScopes.ToListAsync());
        }

        // GET: QuestionScopes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionScope = await _context.QuestionScopes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionScope == null)
            {
                return NotFound();
            }

            return View(questionScope);
        }

        // GET: QuestionScopes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuestionScopes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id,IsDeleted")] QuestionScope questionScope)
        {
            if (ModelState.IsValid)
            {
                _context.Add(questionScope);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(questionScope);
        }

        // GET: QuestionScopes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionScope = await _context.QuestionScopes.FindAsync(id);
            if (questionScope == null)
            {
                return NotFound();
            }
            return View(questionScope);
        }

        // POST: QuestionScopes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,IsDeleted")] QuestionScope questionScope)
        {
            if (id != questionScope.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(questionScope);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionScopeExists(questionScope.Id))
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
            return View(questionScope);
        }

        // GET: QuestionScopes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var questionScope = await _context.QuestionScopes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (questionScope == null)
            {
                return NotFound();
            }

            return View(questionScope);
        }

        // POST: QuestionScopes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var questionScope = await _context.QuestionScopes.FindAsync(id);
            _context.QuestionScopes.Remove(questionScope);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionScopeExists(int id)
        {
            return _context.QuestionScopes.Any(e => e.Id == id);
        }
    }
}
