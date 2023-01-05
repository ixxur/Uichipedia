using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Uichipedia.Model;

namespace Uichipedia.Data
{
    public class UichipediaContext : DbContext
    {
        public UichipediaContext (DbContextOptions<UichipediaContext> options)
            : base(options)
        {
        }

        public DbSet<Uichipedia.Model.Article> Article { get; set; } = default!;
    }
}
