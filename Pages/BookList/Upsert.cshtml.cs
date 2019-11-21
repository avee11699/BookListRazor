using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListrazor.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListrazor.Pages.BookList
{
    public class UpsertModel : PageModel
    {
        private ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public books books { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            books = new books();
            if (id==null)
            {
                //create
                return Page();
            }
            //update
            books = await _db.Books.FirstOrDefaultAsync(u => u.BookId == id);
            if (books==null)
            {
                return NotFound();
            }
            return Page();
            
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if(books.BookId==0)
                {
                    _db.Books.Add(books);
                }
                else
                {
                    _db.Books.Update(books);
                }
                

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}