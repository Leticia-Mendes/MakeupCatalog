using Database.MakeupCatalog;
using Domain.MakeupCatalog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeupCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeupTypesController : ControllerBase
    {
        private readonly MakeupDbContext _context;

        public MakeupTypesController(MakeupDbContext context)
        {
            _context = context;
        }

        // GET: api/MakeupTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MakeupType>>> GetMakeupType()
        {
            try
            {
                return await _context.MakeupType.ToListAsync();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/MakeupTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MakeupType>> GetMakeupType(int id)
        {
            try
            {
                var makeupType = await _context.MakeupType.FindAsync(id);

                if (makeupType == null)
                {
                    return NotFound($"The makeup type id={id} was not found.");
                }

                return makeupType;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/MakeupTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMakeupType(int id, MakeupType makeupType)
        {
            try
            {
                if (id != makeupType.MakeupTypeId)
                {
                    return BadRequest();
                }

                _context.Entry(makeupType).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok($"The makeup type id={id} has been update successfully.");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MakeupTypeExists(id))
                {
                    return NotFound($"The makeup type id={id} was not found.");
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/MakeupTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MakeupType>> PostMakeupType(MakeupType makeupType)
        {
            try
            {
                _context.MakeupType.Add(makeupType);
                await _context.SaveChangesAsync();

                return new CreatedAtRouteResult("GetMakeupType", new { id = makeupType.MakeupTypeId }, makeupType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/MakeupTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMakeupType(int id)
        {
            try
            {
                var makeupType = await _context.MakeupType.FindAsync(id);
                if (makeupType == null)
                {
                    return NotFound($"The makeup type id={id} was not found.");
                }

                _context.MakeupType.Remove(makeupType);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        private bool MakeupTypeExists(int id)
        {
            return _context.MakeupType.Any(e => e.MakeupTypeId == id);
        }
    }
}