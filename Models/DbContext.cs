using Microsoft.EntityFrameworkCore;

namespace CIDM_3312_Final_Project_1.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
    {

    }

    public DbSet<Team> Teams {get; set;}
    public DbSet<Player> Players {get; set;}

}
