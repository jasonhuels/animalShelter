using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public virtual DbSet<Species> Species { get; set; }
    public DbSet<Animal> Animals { get; set; }

    public AnimalShelterContext(DbContextOptions options) : base(options) { }
  }
}