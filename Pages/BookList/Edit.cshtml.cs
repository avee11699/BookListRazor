using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListrazor.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public books books { get; set; }

        public async Task OnGet(int id)
        {
            books = await _db.Books.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var BookFromDb = await _db.Books.FindAsync(books.BookId);
                BookFromDb.BookName = books.BookName;
                BookFromDb.ISPN = books.ISPN;
                BookFromDb.Author = books.Author;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}