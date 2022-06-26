using Microsoft.EntityFrameworkCore;

namespace FleetManager.YachtsContext
{
    public class YachtsContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=FleetManagerDev;Trusted_Connection=True;MultipleActiveResultSets=true;");
            optionsBuilder.LogTo(Console.WriteLine);
        }
    }
}