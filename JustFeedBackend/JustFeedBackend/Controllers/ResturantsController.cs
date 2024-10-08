﻿#nullable disable
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
    public class ResturantsController : ControllerBase
    {
        private readonly DataContext _context;

        public ResturantsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Resturants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resturant>>> GetResturants()
        {
            return await _context.Resturants.ToListAsync();
        }

        // GET: api/Resturants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resturant>> GetResturant(int id)
        {
            var resturant = await _context.Resturants.FindAsync(id);

            if (resturant == null)
            {
                return NotFound();
            }

            return resturant;
        }

        // PUT: api/Resturants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResturant(int id, Resturant resturant)
        {
            if (id != resturant.Id)
            {
                return BadRequest();
            }

            _context.Entry(resturant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResturantExists(id))
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

        // POST: api/Resturants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Resturant>> PostResturant(Resturant resturant)
        {
            _context.Resturants.Add(resturant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetResturant", new { id = resturant.Id }, resturant);
        }

        // DELETE: api/Resturants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResturant(int id)
        {
            var resturant = await _context.Resturants.FindAsync(id);
            if (resturant == null)
            {
                return NotFound();
            }

            _context.Resturants.Remove(resturant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ResturantExists(int id)
        {
            return _context.Resturants.Any(e => e.Id == id);
        }
    }
}
