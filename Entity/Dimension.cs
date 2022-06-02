using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity;

public class Dimension : EntityBase, IEntityTypeConfiguration<Dimension>
{
    public long UnitId { get; set; }
    public string UnitFaName { get; set; } = null!;
    public string UnitEnName { get; set; } = null!;
    public string UnitSymbol { get; set; } = null!;

    public virtual Unit Unit { get; set; } = null!;
    public virtual ICollection<Unit> Units { get; set; } = null!;

    public void Configure(EntityTypeBuilder<Dimension> builder)
    {
        builder.Property(p => p.UnitSymbol).HasMaxLength(3);
    }
}