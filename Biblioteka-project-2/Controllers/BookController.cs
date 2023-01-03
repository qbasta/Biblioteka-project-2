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

namespace Biblioteka_project_2.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index(string SortOrder, string SearchString)
        {
            //przeszukiwanie po nazwie
            ViewData["CurrentFilter"] = SearchString;
            var books = from b in _context.Books
                        select b;
            if (!String.IsNullOrEmpty(SearchString))
            {
                books = books.Where(b => b.Title.Contains(SearchString));
            }

            //przeszukiwanie po kategorii z dropdownlist
            var CategoriesList = (from b in _context.Books
                                  select new SelectListItem()
                                  {
                                      Text = b.Category,
                                      Value = b.Id.ToString()
                                  }).ToList();
            CategoriesList.Insert(0, new SelectListItem()
            {
                Text = "---Wybierz kategorię---",
                Value = string.Empty
            });
            ViewBag.ListOfCategories = CategoriesList;
            

            //sortowanie po tytule
            ViewData["TitleSortParam"] = String.IsNullOrEmpty(SortOrder) ? "title_sort" : "";
            ViewData["CategorySortParam"] = SortOrder == "Category" ? "category_sort" : "category_sort";
            ViewData["AuthorSortParam"] = SortOrder == "Autor" ? "author_sort" : "author_sort";
            switch (SortOrder)
            {
                case "title_sort":
                    default:
                    books = books.OrderBy(b => b.Title);
                    break;
                case "category_sort":
                    books = books.OrderBy(b => b.Category);
                    break;
                case "author_sort":
                    books = books.OrderBy(b => b.Autor); 
                    break;
            }

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
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                _context.Authors.Add(new Authors(){ Name = book.Autor });
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
