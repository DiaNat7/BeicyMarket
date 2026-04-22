using Dapper.Contrib.Extensions;
namespace BeicyMarket._2P.CORE.EntitiesProy;


[Table("PaymentProy")]
public class PaymentProy : EntityBaseProy
{
    
        public int SaleId { get; set; }
        public string Method { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
    
}