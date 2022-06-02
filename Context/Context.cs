using Entity;
using Microsoft.EntityFrameworkCore;

namespace Context;

public class Context : DbContext, IContext
{
    public DbSet<Dimension> Dimensions { get; set; } = null!;
    public DbSet<Unit> Units { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityBase).Assembly);

        modelBuilder.Entity<Unit>().HasData(FakeData.FakeData.Units);

        modelBuilder.Entity<Dimension>().HasData(FakeData.FakeData.Dimensions);
    }
}