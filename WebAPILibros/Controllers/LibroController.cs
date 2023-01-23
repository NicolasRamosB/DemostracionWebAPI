using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPILibros.Data;
using WebAPILibros.Models;

namespace WebAPILibros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
            private readonly DBLibrosContext context;
            
            public LibroController(DBLibrosContext context)
            {

                this.context = context;

            }


        //Get By Autor
        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.Libros.ToList();
        }


        //Get By Autor
        [HttpGet("autor/{IdAutor}")]
        public ActionResult<IEnumerable<Libro>> GetbyAutor(int IdAutor)
        {

            List<Libro> libro = (from l in context.Libros
                           where l.IdAutor == IdAutor
                           select l).ToList();

            return libro;

        }


        //Get By Id
        [HttpGet("{id}")]
        public ActionResult<Libro> GetbyId(int id)

        {
            Libro libro = (from l in context.Libros
                           where l.Id == id
                           select l).SingleOrDefault();

            return libro;

        }


        //Post
        [HttpPost]
        public ActionResult Post(Libro libro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            context.Libros.Add(libro);
            context.SaveChanges();
            return Ok();
        }


        //Put
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Libro libro)
        {
            if (id != libro.Id)
            {
                return BadRequest();
            }

            context.Entry(libro).State = EntityState.Modified;
            context.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id}")]
        public ActionResult<Libro> DeleteLibro(int id)
        {
            var libro = (from a in context.Libros
                         where a.Id == id
                         select a).SingleOrDefault();
            if (libro == null)
            {

                return NotFound();

            }
            context.Libros.Remove(libro);
            context.SaveChanges();
            return libro;

        }

    }
}
