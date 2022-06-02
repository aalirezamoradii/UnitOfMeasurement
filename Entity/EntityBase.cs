using System.ComponentModel.DataAnnotations;

namespace Entity;

public class EntityBase
{
    [Key]
    public long Id { get; set; }
    
    public string FaName { get; set; } = null!;
    public string EnName { get; set; } = null!;
}