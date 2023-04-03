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
    public class RequestlinesController : ControllerBase
    {
        private readonly PRSV2DbContext _context;

        public RequestlinesController(PRSV2DbContext context)
        {
            _context = context;
        }
        //recalculate total for requests
        private async Task<IActionResult> Recalculate(int requestId)
        {
            var request = await _context.Requests.FindAsync(requestId);
            request.Total = (from rl in _context.Requestlines
                             join p in _context.Products
                             on rl.ProductId equals p.Id
                             where rl.RequestId == requestId
                             select new
                             {
                                 lineTotal = rl.Quantity * p.Price
                             }).Sum(x => x.lineTotal);
            await _context.SaveChangesAsync();
            return Ok();
        }
        
        //private async Task<IActionResult> Recalculate(int requestId)
        //{
        //    var request = await _context.Requests.FindAsync(requestId);

        //    request.Total = (from rl in _context.Requestlines
        //                     join p in _context.Products
        //                     on rl.ProductId equals p.Id
        //                     where rl.RequestId == requestId
        //                     select new
        //                     {
        //                         lineTotal = rl.Quantity * p.Price
        //                     }).Sum(x => x.lineTotal);
        //    await _context.SaveChangesAsync();
        //    return Ok();
        //}




        // GET: api/Requestlines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requestlines>>> GetRequestlines()
        {
          if (_context.Requestlines == null)
          {
              return NotFound();
          }
            return await _context.Requestlines.ToListAsync();
        }

        // GET: api/Requestlines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requestlines>> GetRequestlines(int id)
        {
          if (_context.Requestlines == null)
          {
              return NotFound();
          }
            var requestlines = await _context.Requestlines.FindAsync(id);

            if (requestlines == null)
            {
                return NotFound();
            }

            return requestlines;
        }

        // PUT: api/Requestlines/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestlines(int id, Requestlines requestlines)
        {
            if (id != requestlines.Id)
            {
                return BadRequest();
            }

            _context.Entry(requestlines).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestlinesExists(id))
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

        // POST: api/Requestlines
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Requestlines>> PostRequestlines(Requestlines requestlines)
        {
          if (_context.Requestlines == null)
          {
              return Problem("Entity set 'PRSV2DbContext.Requestlines'  is null.");
          }
            _context.Requestlines.Add(requestlines);
            await Recalculate(requestlines.Id);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestlines", new { id = requestlines.Id }, requestlines);
        }

        // DELETE: api/Requestlines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestlines(int id)
        {
            if (_context.Requestlines == null)
            {
                return NotFound();
            }
            var requestlines = await _context.Requestlines.FindAsync(id);
            if (requestlines == null)
            {
                return NotFound();
            }

            _context.Requestlines.Remove(requestlines);
            await Recalculate(requestlines.Id);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestlinesExists(int id)
        {
            return (_context.Requestlines?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
