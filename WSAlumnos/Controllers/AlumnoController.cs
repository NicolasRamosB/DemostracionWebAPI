using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSAlumnos.Models;

namespace WSAlumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private List<Alumno> Listado()
        {


            List<Alumno> alumnos = new List<Alumno>()
            {
                new Alumno(){Id = 1 , Apellido="Ramos", Nombre= "Nicolas" },
                new Alumno(){Id = 2, Apellido= "Rivero", Nombre= "Samuel"},
                new Alumno(){Id = 3, Apellido= "Abreu", Nombre= "Dayana"}
            };

            return alumnos;
        }

        //GET api/Alumno
        [HttpGet]
        public IEnumerable<Alumno> Get() { return Listado(); }


        //GET api/Alumno/3
        [HttpGet("{id}")]
        public ActionResult<Alumno> GetById(int id) {
            var alumno = (from a in Listado()
                         where a.Id == id
                         select a).SingleOrDefault();

            return alumno; 
        }
    }
}

