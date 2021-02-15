using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collection.Models
{
    public class CdContext : DbContext
    {

        public CdContext(DbContextOptions<CdContext> options) : base(options)
        {

        }
        public DbSet<Cd> Cds { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Loan> Loans { get; set; }
    }
}
