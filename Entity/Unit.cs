using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity;

public class Unit : EntityBase, IEntityTypeConfiguration<Unit>
{
    public long? ParentId { get; set; }

    public string Symbol { get; set; } = null!;
    public string ToBasic { get; set; } = null!;
    public string FromBasic { get; set; } = null!;

    public virtual Unit? Parent { get; set; }

    public void Configure(EntityTypeBuilder<Unit> builder)
    {
        builder.Property(p => p.Symbol).HasMaxLength(3);
    }
}