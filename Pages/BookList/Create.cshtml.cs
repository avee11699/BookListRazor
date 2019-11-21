using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListrazor.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListrazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public books books { get; set; }


        public void OnGet()
        {

        }

        public async Task<IActionResult>OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Books.AddAsync(books);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}