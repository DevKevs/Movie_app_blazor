using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Movie_app.Shared.Models;

namespace Movie_app.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PeliculasController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Peliculas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPeliculas()
        {
            return await _context.Peliculas.ToListAsync();
        }

        // GET: api/Peliculas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pelicula>> GetPelicula(int id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);

            if (pelicula == null)
            {
                return NotFound();
            }

            return pelicula;
        }

        // PUT: api/Peliculas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseMovie>> PutPelicula(int id, Pelicula pelicula)
        {
            if (id != pelicula.Id)
            {
                return BadRequest();
            }

            _context.Entry(pelicula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return new ResponseMovie() { Message = "Editado corectamente", ok = true };
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculaExists(id))
                {
                    return new ResponseMovie() { Message = "No se puedo editar la pelicula", ok = false };
                }
                else
                {
                    throw;
                }
            }

        }

        // POST: api/Peliculas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ResponseMovie>> PostPelicula(Pelicula pelicula)
        {
            try
            {
                _context.Peliculas.Add(pelicula);
                await _context.SaveChangesAsync();
                return new ResponseMovie() { Message = "Agregado corectamente", ok = true };
            }
            catch (Exception)
            {

                return new ResponseMovie() { Message = "No se puedo agregar la pelicula", ok = false };
            }
           
        }

        // DELETE: api/Peliculas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseMovie>> DeletePelicula(int id)
        {
            var pelicula = await _context.Peliculas.FindAsync(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            try
            {
                _context.Peliculas.Remove(pelicula);
                await _context.SaveChangesAsync();
                return new ResponseMovie() { Message = "Eliminado corectamente", ok = true };
            }
            catch (Exception)
            {

                return new ResponseMovie() { Message = "No se pudo eliminar", ok = false };
            }
           
        }

        private bool PeliculaExists(int id)
        {
            return _context.Peliculas.Any(e => e.Id == id);
        }
        public class ResponseMovie
        {
            public string Message { get; set; }
            public bool ok { get; set; }
        }
    }
}
