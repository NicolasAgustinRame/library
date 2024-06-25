using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Library.Model;

[Table("generos")]
public class Genero
{
    public Guid Id { get; set; }
    public string Nombre { get; set; }
}