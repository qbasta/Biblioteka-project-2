using Biblioteka_project_2.Data;
using Biblioteka_project_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteka_project_2.Controllers
{
    public class BookProposalController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BookProposalController> _logger;

        public BookProposalController(ApplicationDbContext context, ILogger<BookProposalController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Category,Autor,Description")] BookProposal bookProposal)
        {
            var query1 = from b in _context.BookProposals
                         where b.Title.ToLower() == bookProposal.Title.ToLower()
                         select b;


            if (query1.ToList().Count != 0)
            {
                ModelState.AddModelError("", "Książka o podanym tytule już istnieje");
            }


            if (ModelState.IsValid)
            {
                _context.BookProposals.Add(bookProposal);
                _context.Authors.Add(new Authors() { Name = bookProposal.Autor });
                _context.Categories.Add(new Category() { Name = bookProposal.Category });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookProposal);
        }





    }
}

