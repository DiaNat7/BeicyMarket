namespace BeicyMarket._2P.CORE.HttpProy;

public class ResponseProy <T>
{
    // Aquí va la información real que se pide
    public T Data { get; set; }
    
    // Un mensaje rápido 
    public string Message { get; set; } = "";
    
    // Si algo explota o falla, aquí guardamos la lista de los problemas
    public List<string> Errors { get; set; } = new List<string>();

}