using GranShopAPI.Data;
using GranShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GranShopAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController(AppDbContext db) : ControllerBase
    {
        private readonly AppDbContext _db = db;

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_db.Produtos.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var produto = _db.Produtos
            .Include(i => i.Categoria)
            .FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produto produto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Produto informado com problemas");
            _db.Produtos.Add(produto);
            _db.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, [FromBody] Produto produto)
        {
            if (!ModelState.IsValid || id != produto.Id)
                return BadRequest("Produto informado com problemas");
            _db.Produtos.Update(produto);
            _db.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _db.Produtos.Find(id);
            if (produto == null)
                return NotFound();
            _db.Produtos.Remove(produto);
            _db.SaveChanges();
            return NoContent();

        }
        
        // [HttpGet("/MEUOVO/{id}")]
        // public IActionResult Getfodase(int id)
        // {
        //     var meuOvo = _db.Produtos.Include(i => i.Categoria).Where(w => w.Id == id).FirstOrDefault();
        //     return Ok(meuOvo.Categoria);
        // }
    }
}