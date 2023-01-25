using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteka_project_2.Data;
using Biblioteka_project_2.Models;
using Microsoft.Data.SqlClient;
using DocumentFormat.OpenXml.Office.CustomUI;
using System.Net.Http.Headers;

namespace Biblioteka_project_2.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<BookController> _logger;

        public BookController(ApplicationDbContext context, ILogger<BookController> logger)
        {
            _context = context;
            _logger = logger;   
        }

        // GET: Book
        public async Task<IActionResult> Index(string SortOrder="", string SearchString="")
        {
            //przeszukiwanie po nazwie
            ViewData["CurrentFilter"] = SearchString;
            SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString.ToLower();
            var bookData = new BookViewModel();
            //segregowanie
            bookData.TitleSortOrder = String.IsNullOrEmpty(SortOrder) ? "title_desc" : "";
            bookData.CategorySortOrder = SortOrder == "Category" ? "category_desc" : "category_sort";
            bookData.AuthorSortOrder = SortOrder == "Autor" ? "author_desc" : "author_sort";
           
            var books = (from b in _context.Books
                        where SearchString == "" || b.Title.ToLower().StartsWith(SearchString)
                        select new Book
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Category = b.Category,
                            Autor = b.Autor,
                            Description = b.Description,
                            ISBN = b.ISBN,
                            Amount = b.Amount,
                        });

            if (!String.IsNullOrEmpty(SearchString))
            {
                books = books.Where(b => b.Title.Contains(SearchString));
            }

            //sortowanie po tytule
            switch (SortOrder)
            {
                case "title_desc":
                    books = books.OrderByDescending(b => b.Title);
                    break;
                case "category_desc":
                    books = books.OrderByDescending(b => b.Category);
                    break;
                case "author_desc":
                    books = books.OrderByDescending(b => b.Autor);
                    break;
                case "author_sort":
                    books = books.OrderBy(b => b.Autor);
                    break;
                case "category_sort":
                    books = books.OrderBy(b => b.Category);
                    break;
                default:
                    books = books.OrderBy(b => b.Title);
                    break;
            }

            List<string> products = new();

            foreach(var book in books)
            {
               
                products.Add(book.Category.ToString());  
                
            }
            
            var productList = products.Distinct().ToList();


            //przeszukiwanie po kategorii z dropdownlist
            List<SelectListItem> CategoriesList = new();

            foreach(var pro in productList)
            {
                var sel = new SelectListItem()
                {
                    Text = pro,
                    Value = pro

                };

                CategoriesList.Add(sel);
            }

            CategoriesList.Insert(0, new SelectListItem()
            {
                Text = "---Wybierz kategorię---",
                Value = string.Empty
            });
            ViewBag.ListOfCategories = CategoriesList;


            return View(await books.AsNoTracking().ToListAsync());
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Category,Autor,Description,ISBN,Amount")] Book book)
        {
            var query1 = from b in _context.Books
                         where b.Title.ToLower() == book.Title.ToLower()
                         select b;
              
            
            if (query1.ToList().Count != 0)
            {
                ModelState.AddModelError("", "Książka o podanym tytule już istnieje");
            }


            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.Authors.Add(new Authors() { Name = book.Autor });
                _context.Categories.Add(new Category() { Name = book.Category });
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            //logs of edit
            var username = HttpContext.User.Identity.Name;
            _logger.LogWarning((EventId)200, "{bookid} edited by {user} on {date}", id, username, DateTime.Now); 

            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Category,Autor,Description,ISBN,Amount")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _context.Books.Any(e => e.Id == id);
        }
    }
}
