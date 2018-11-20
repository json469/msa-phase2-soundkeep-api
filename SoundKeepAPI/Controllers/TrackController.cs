using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoundKeepAPI.Models;

namespace SoundKeepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly SoundKeepAPIContext _context;

        public TrackController(SoundKeepAPIContext context)
        {
            _context = context;
        }

        // GET: api/Track
        [HttpGet]
        public IEnumerable<TrackItem> GetTrackItem()
        {
            return _context.TrackItem;
        }

        // GET: api/Track/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetTrackItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trackItem = await _context.TrackItem.FindAsync(id);

            if (trackItem == null)
            {
                return NotFound();
            }

            return Ok(trackItem);
        }

        // PUT: api/Track/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrackItem([FromRoute] int id, [FromBody] TrackItem trackItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trackItem.ID)
            {
                return BadRequest();
            }

            _context.Entry(trackItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackItemExists(id))
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

        // POST: api/Track
        [HttpPost]
        public async Task<IActionResult> PostTrackItem([FromBody] TrackItem trackItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.TrackItem.Add(trackItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrackItem", new { id = trackItem.ID }, trackItem);
        }

        // DELETE: api/Track/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrackItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var trackItem = await _context.TrackItem.FindAsync(id);
            if (trackItem == null)
            {
                return NotFound();
            }

            _context.TrackItem.Remove(trackItem);
            await _context.SaveChangesAsync();

            return Ok(trackItem);
        }

        private bool TrackItemExists(int id)
        {
            return _context.TrackItem.Any(e => e.ID == id);
        }
    }
}