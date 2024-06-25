namespace Api_Library.Query;

public class UpdateLibroQuery
{
    public Guid ISBN { get; set; }
    public string Titulo { get; set; }
    public DateTime FechaDePublicacion { get; set; }
}