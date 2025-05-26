using GranShopAPI.Data;
using GranShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GranShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController(AppDbContext db) : ControllerBase
    {

        private readonly AppDbContext _db = db;

        [HttpGet]
        public IActionResult get()
        {
            return Ok(_db.Categorias.ToList());
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }
        [HttpPost]
        public IActionResult create([FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid)
                return BadRequest("categoria informada com problemas");
            _db.Categorias.Add(categoria);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), categoria.Id, new { categoria });
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Categoria categoria)
        {
            if (!ModelState.IsValid || id != categoria.Id)
                return BadRequest("categoria informada com problemas");
            _db.Categorias.Update(categoria);
            _db.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var categoria = _db.Categorias.Find(id);
            if (categoria == null)
                return NotFound();
            _db.Categorias.Remove(categoria);
            _db.SaveChanges();
            return NoContent();
    }
}