namespace BeicyMarket._2P.CORE.EntitiesProy;

public class ProductProy : EntityBaseProy
{
    public int CategoryId { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public decimal SalePrice { get; set; }
    public int Stock { get; set; }
    public string Description { get; set; }
    public string Image { get; set; }
    public int Status { get; set; }
   
}