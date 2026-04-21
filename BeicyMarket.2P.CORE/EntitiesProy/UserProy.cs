namespace BeicyMarket._2P.CORE.EntitiesProy;

public class UserProy : EntityBaseProy
{
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
    public string? Address { get; set; }
    public string? Phone { get; set; }
    public int Status { get; set; }
}