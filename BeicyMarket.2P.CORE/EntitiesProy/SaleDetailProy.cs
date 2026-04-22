using Dapper.Contrib.Extensions;
namespace BeicyMarket._2P.CORE.EntitiesProy;


[Table("SaleDetailProy")]
public class SaleDetailProy:EntityBaseProy
{
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }
    
}