using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Uichipedia.Data;
using Uichipedia.Model;

namespace Uichipedia.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly Uichipedia.Data.UichipediaContext _context;

        public CreateModel(Uichipedia.Data.UichipediaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Article.Add(Article);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public String createDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}
