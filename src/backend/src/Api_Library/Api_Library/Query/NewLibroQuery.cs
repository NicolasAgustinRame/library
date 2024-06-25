namespace Api_Library.Query;

public class NewLibroQuery
{
    public Guid ISBN { get; set; }
    public string Titulo { get; set; }
    public Guid Autor { get; set; }
    public DateTime FechaDePublicacion { get; set; }
    public Guid Genero { get; set; }
}