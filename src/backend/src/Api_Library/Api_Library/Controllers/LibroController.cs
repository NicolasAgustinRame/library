using Api_Library.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api_Library.Controllers;

public class LibroController : Controller
{
   private readonly ILibrosService _librosService;

   public LibroController(ILibrosService librosService)
   {
      _librosService = librosService;
   }

   [HttpGet("libros/GetAll")]
   public async Task<IActionResult> GetAll()
   {
      var response = await _librosService.GetAll();
      return Ok(response);
   }
   
}