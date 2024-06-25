using Api_Library.Model;

namespace Api_Library.Dtos;

public class LibroDto
{
    public Guid ISBN { get; set; }
    public string Titulo { get; set; }
    public AutorDto Autor { get; set; }
    public DateTime FechaDePublicacion { get; set; }
    public GeneroDto Genero { get; set; }
}