using Dapper.Contrib.Extensions;

namespace BeicyMarket._2P.CORE.EntitiesProy;

[Table("CategoryProy")]
public class CategoryProy : EntityBaseProy
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int Status { get; set; }
}