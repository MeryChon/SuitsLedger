using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SuitLedgerContext : DbContext
    {

        public DbSet<AuthorizedPerson> AuthorizedPersons { get; set; }
        public DbSet<Suit> Suits { get; set; }


        public SuitLedgerContext(DbContextOptions<SuitLedgerContext> options) : base(options)
        {
        }


    }
}