#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JustFeedBackend.Data;
using JustFeedBackend.Models;

namespace JustFeedBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Dish_typeController : ControllerBase
    {
        private readonly DataContext _context;

        public Dish_typeController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Dish_type
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish_type>>> GetDish_Types()
        {
            return await _context.Dish_Types.ToListAsync();
        }

        // GET: api/Dish_type/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dish_type>> GetDish_type(int id)
        {
            var dish_type = await _context.Dish_Types.FindAsync(id);

            if (dish_type == null)
            {
                return NotFound();
            }

            return dish_type;
        }

        // PUT: api/Dish_type/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDish_type(int id, Dish_type dish_type)
        {
            if (id != dish_type.Id)
            {
                return BadRequest();
            }

            _context.Entry(dish_type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Dish_typeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Dish_type
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dish_type>> PostDish_type(Dish_type dish_type)
        {
            _context.Dish_Types.Add(dish_type);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDish_type", new { id = dish_type.Id }, dish_type);
        }

        // DELETE: api/Dish_type/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish_type(int id)
        {
            var dish_type = await _context.Dish_Types.FindAsync(id);
            if (dish_type == null)
            {
                return NotFound();
            }

            _context.Dish_Types.Remove(dish_type);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool Dish_typeExists(int id)
        {
            return _context.Dish_Types.Any(e => e.Id == id);
        }
    }
}
