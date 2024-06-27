using System.ComponentModel.DataAnnotations.Schema;

namespace Api_Library.Model;
[Table("roles")]
public class Roles
{
    public Guid Id { get; set; }
    public string Rol { get; set; }
    public string Descripcion { get; set; }
}