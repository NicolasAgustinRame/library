using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Library.Model;
[Table("autores")]
public class Autor
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
    public DateTime FechaNacimiento { get; set; }
}