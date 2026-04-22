using Dapper.Contrib.Extensions;
namespace BeicyMarket._2P.CORE.EntitiesProy;


[Table("SaleDetailProy")]
public class SaleProy:EntityBaseProy
{
    
        public int UserId { get; set; } 
        public string ReceiptType { get; set; } 
        public DateTime Date { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    
}