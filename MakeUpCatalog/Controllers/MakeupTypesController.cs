using Domain.MakeupCatalog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repository.MakeupCatalog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MakeupCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeupTypesController : ControllerBase
    {
        private readonly IUnitOfWork _context;

        public MakeupTypesController(IUnitOfWork context)
        {
            _context = context;
        }

        // GET: api/MakeupTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MakeupType>>> GetMakeupType()
        {
            try
            {
                return await _context.MakeupTypeRepository.Get().ToListAsync();
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
                var makeupType = await _context.MakeupTypeRepository.GetById(x => x.MakeupTypeId == id);

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

        // POST: api/MakeupTypes
        [HttpPost]
        public async Task<ActionResult> PostMakeupType([FromBody] MakeupType makeupType)
        {
            try
            {
                _context.MakeupTypeRepository.Add(makeupType);
                await _context.Commit();

                new CreatedAtRouteResult("GetMakeupType",
                    new { id = makeupType.MakeupTypeId }, makeupType);
                return Ok("Ok.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/MakeupTypes/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutMakeupType(int id, [FromBody] MakeupType makeupType)
        {
            try
            {
                if (id != makeupType.MakeupTypeId)
                {
                    return NotFound($"The makeup type id={id} was not found.");
                }

                _context.MakeupTypeRepository.Update(makeupType);
                await _context.Commit();
                return Ok($"The makeup type id={id} has been update successfully.");
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
                var makeupType = await _context.MakeupTypeRepository.GetById(x => x.MakeupTypeId == id);
                if (makeupType == null)
                {
                    return NotFound($"The makeup type id={id} was not found.");
                }

                _context.MakeupTypeRepository.Delete(makeupType);
                await _context.Commit();

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}