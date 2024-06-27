using Api_Library.Model;
using Api_Library.Query;
using FluentValidation;

namespace Api_Library.Validations.ValidationsLibros;

public class PostLibroValidation : AbstractValidator<NewLibroQuery>
{
    public PostLibroValidation()
    {
        RuleFor(x => x.ISBN).NotEmpty().WithMessage("Ingresar ISBN");
        RuleFor(x => x.Titulo).NotEmpty().WithMessage("Ingresar Titulo");
        RuleFor(x => x.Autor).NotEmpty().WithMessage("Ingresar Autor");
        RuleFor(x => x.FechaDePublicacion).NotEmpty().WithMessage("Ingresar Fecha de publicacion");
        RuleFor(x => x.Genero).NotEmpty().WithMessage("Ingresar Genero");
    }
}