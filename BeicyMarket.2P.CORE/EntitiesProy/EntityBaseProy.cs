namespace BeicyMarket._2P.CORE.EntitiesProy;

public class EntityBaseProy
{
    // El identificador único del registro
    public int Id { get; set; }
    
    // Hacer que parezca borrado sin eliminarlo de la base de datos
    public bool IsDeleted { get; set; }
    
    // Quien creó el registro
    public string CreatedBy { get; set; }
    
    // Cuando se creó
    public DateTime CreatedDate { get; set; }
    
    // Quien fue el último en modificarlo
    public string UpdatedBy { get; set; }
    
    // Cuando fue la última vez que se modificó
    public DateTime UpdatedDate { get; set; }
}

// Test1 hereda de EntityBase.
// Ya no tienes que volver a escribir los datos porque ya los tiene todos por herencia.
public class Test1 : EntityBaseProy
{
    // Aquí ya solo pones lo específico de Test1 
}
