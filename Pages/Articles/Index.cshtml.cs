using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Uichipedia.Data;
using Uichipedia.Model;

namespace Uichipedia.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly Uichipedia.Data.UichipediaContext _context;

        public IndexModel(Uichipedia.Data.UichipediaContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Article != null)
            {
                Article = await _context.Article.ToListAsync();
            }
        }
    }
}
