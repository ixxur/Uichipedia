using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Categories { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? ArticleCategory { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> categoryQuery = from a in _context.Article
                                            orderby a.Category
                                            select a.Category;

            var articles = from a in _context.Article
                         select a;

            if (!string.IsNullOrEmpty(SearchString))
            {
                articles = articles.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(ArticleCategory))
            {
                articles = articles.Where(x => x.Category == ArticleCategory);
            }
            Categories = new SelectList(await categoryQuery.Distinct().ToListAsync());

            Article = await articles.ToListAsync();
        }
    }
}
