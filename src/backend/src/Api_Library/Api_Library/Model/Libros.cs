using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Api_Library.Model;
[Table("libros")]
public class Libros
{
    [Key]
    public Guid ISBN{ get; set; }
    public string Titulo { get; set; }
    
    public Guid IdAutor { get; set; }
    [ForeignKey("IdAutor")] 
    public Autor Autor { get; set; }
    
    public DateTime FechaDePublicacion { get; set; }
    
    public Guid IdGenero { get; set; }
    [ForeignKey("IdGenero")] 
    public Genero Genero { get; set; }
}