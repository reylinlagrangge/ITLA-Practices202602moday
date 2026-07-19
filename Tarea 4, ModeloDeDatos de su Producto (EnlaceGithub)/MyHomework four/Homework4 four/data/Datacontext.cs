using Microsoft.EntityFrameworkCore;

namespace Homework4_four_.data
{
    public class Datacontext: DbContext
    {
        public DbSet<Entities.Person> Pleople { get; set; }


        protected override void OnModelCreating(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("")
    }
}
