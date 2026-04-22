using Dapper.Contrib.Extensions;
namespace BeicyMarket._2P.CORE.EntitiesProy; 

[Table("ShippingProy")]
public class ShippingProy: EntityBaseProy
{
   
        public int SaleId { get; set; }
        public string ShippingAddress { get; set; }
        public string Status { get; set; }
    
}