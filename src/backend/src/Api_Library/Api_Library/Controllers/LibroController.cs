using Api_Library.Interfaces.Services;
using Api_Library.Query;
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

   [HttpGet("libros/GetById/{id}")]
   public async Task<IActionResult> GetById(Guid id)
   {
      var response = await _librosService.GetById(id);
      return Ok(response);
   }

   [HttpPost("libros/PostLibro")]
   public async Task<IActionResult> PostLibro([FromBody] NewLibroQuery query)
   {
      var response = await _librosService.PostLibro(query);
      return Ok(response);
   }

   [HttpPut("libros/UpdateLibro")]
   public async Task<IActionResult> UpdateLibro([FromBody] UpdateLibroQuery query)
   {
      var response = await _librosService.UpdateLibro(query);
      return Ok(response);
   }

   [HttpDelete("libros/DeleteLibro/{ISBN}")]
   public async Task<IActionResult> DeleteLibro(Guid ISBN)
   {
      var response = await _librosService.DeleteLibro(ISBN);
      return Ok(response);
   }
   
}