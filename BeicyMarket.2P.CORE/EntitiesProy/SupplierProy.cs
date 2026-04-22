using Dapper.Contrib.Extensions;
namespace BeicyMarket._2P.CORE.EntitiesProy;



[Table("SupplierProy")]
public class SupplierProy:EntityBaseProy
{
    
    
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    
}