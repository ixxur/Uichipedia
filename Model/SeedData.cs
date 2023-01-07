using Microsoft.EntityFrameworkCore;
using Uichipedia.Data;

namespace Uichipedia.Model;
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new UichipediaContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<UichipediaContext>>()))
        {
            if (context == null || context.Article == null)
            {
                throw new ArgumentNullException("Null UichipediaArticleContext");
            }

            // Look for any movies.
            if (context.Article.Any())
            {
                return;   // DB has been seeded
            }

            context.Article.AddRange(
                new Article
                {
                    Title = "William Shakespeare",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Category = "Literature",
                    Content = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\""
                },

                new Article
                {
                    Title = "Ghosts",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Category = "Science",
                    Content = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\""
                },

                new Article
                {
                    Title = "Pythagorean theorem",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Category = "Science",
                    Content = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\""
                },

                new Article
                {
                    Title = "Queen Elizabeth II",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Category = "History",
                    Content = "\"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.\""
                }
            );
            context.SaveChanges();
        }
    }
}
