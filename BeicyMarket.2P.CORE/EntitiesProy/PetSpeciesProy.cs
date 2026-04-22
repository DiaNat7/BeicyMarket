using Dapper.Contrib.Extensions;

namespace BeicyMarket._2P.CORE.EntitiesProy;

[Table("PetSpeciesProy")]
public class PetSpeciesProy : EntityBaseProy
{
    public int CategoryId { get; set; }
    public string SpeciesName { get; set; }
    public string ClassificationType { get; set; }
    public string Size { get; set; }
    public string AgeStage { get; set; }  
}