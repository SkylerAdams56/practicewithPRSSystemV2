using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using practicewithPRSSystemV2.Models;

namespace practicewithPRSSystemV2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly PRSV2DbContext _context;

        public RequestsController(PRSV2DbContext context)
        {
            _context = context;
        }


        [HttpGet("reviews/{userid}")]
        public async Task<List<Requests>> GetReviews(int userId)
        {
            var request = await _context.Requests.Where(r => r.Status == "REVIEW" && userId != r.UserId).ToListAsync();
            return request;
        }


        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requests>>> GetRequests()
        {
          if (_context.Requests == null)
          {
              return NotFound();
          }
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requests>> GetRequests(int id)
        {
          if (_context.Requests == null)
          {
              return NotFound();
          }
            var requests = await _context.Requests.FindAsync(id);

            if (requests == null)
            {
                return NotFound();
            }

            return requests;
        }

        [HttpPut("review/{id}")]
        public async Task<IActionResult> Review(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                return NotFound();
            }
            if (request.Total <= 50)
            {
                request.Status = "APPROVED";
            }
            else
            {
                request.Status = "REVIEW";
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPut("approve/{id}")]
        public async Task Approve(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                NotFound();
            }
            else
            {
                request.Status = "APPROVED";
            }
            await _context.SaveChangesAsync();
            Ok();
        }
        [HttpPut("reject/{id}")]
        public async Task Reject(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
            {
                NotFound();
            }
            else
            {
                request.Status = "REJECTED";
            }
            await _context.SaveChangesAsync();
            Ok();
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequests(int id, Requests requests)
        {
            if (id != requests.Id)
            {
                return BadRequest();
            }

            _context.Entry(requests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestsExists(id))
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

        // POST: api/Requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Requests>> PostRequests(Requests requests)
        {
          if (_context.Requests == null)
          {
              return Problem("Entity set 'PRSV2DbContext.Requests'  is null.");
          }
            _context.Requests.Add(requests);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequests", new { id = requests.Id }, requests);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequests(int id)
        {
            if (_context.Requests == null)
            {
                return NotFound();
            }
            var requests = await _context.Requests.FindAsync(id);
            if (requests == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(requests);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestsExists(int id)
        {
            return (_context.Requests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
