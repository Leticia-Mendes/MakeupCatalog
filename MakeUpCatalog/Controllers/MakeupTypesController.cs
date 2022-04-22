using MakeupCatalog.Model;
using Microsoft.AspNetCore.Mvc;
using Repo.MakeupCatalog;
using System;
using System.Collections.Generic;
using Domain.MakeupCatalog;

namespace MakeupCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MakeupTypesController : ControllerBase
    {
        public readonly IRepository _repo;

        public MakeupTypesController(IRepository repo)
        {
            _repo = repo;
        }

        //// GET: api/MakeupTypes
        [HttpGet]
        public ActionResult<IEnumerable<MakeupTypeModel>> GetAllMakeupType()
        {
            try
            {
                var result = _repo.GetAllMakeupTypes(true);
                List<MakeupTypeModel> makeupTypeModelList = new List<MakeupTypeModel>();
                foreach (var mt in result)
                {
                    MakeupTypeModel makeupType = new MakeupTypeModel();
                    makeupType.MakeupTypeId = mt.MakeupTypeId;
                    makeupType.Name = mt.Name;
                    makeupType.Product = makeupType.Product;
                    makeupTypeModelList.Add(makeupType);
                }

                return makeupTypeModelList;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/MakeupTypes/5
        [HttpGet("{id}")]
        public IActionResult GetMakeupType(int id)
        {
            try
            {
                var makeupType = _repo.GetMakeupTypesById(id, false);
                if (makeupType == null)
                {
                    return NotFound($"The makeup type id={id} was not found.");
                }

                return Ok(makeupType);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/MakeupTypes
        [HttpPost]
        public IActionResult PostMakeupType([FromBody] MakeupTypeModel makeupType)
        {
            try
            {
                _repo.Add(new MakeupType()
                {
                    Name = makeupType.Name,
                });

                _repo.SaveChanges(makeupType);

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
        public IActionResult PutMakeupType(int id, [FromBody] MakeupTypeModel makeupType)
        {
            try
            {
                var makeupTypeFromDb = _repo.GetMakeupTypesById(id, false);
                if (makeupTypeFromDb == null)
                {
                    return NotFound($"The makeup type id={id} was not found.");
                }

                makeupTypeFromDb.Name = makeupType.Name;

                _repo.Update( makeupTypeFromDb);

                _repo.SaveChanges(makeupType);
                return Ok($"The makeup type id={id} has been update successfully.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/MakeupTypes/5
        [HttpDelete("{id}")]
        public IActionResult DeleteMakeupType(int id)
        {
            try
            {
                var makeupType = _repo.GetMakeupTypesById(id, false);
                if (makeupType == null)
                {
                    return NotFound($"The makeup type id={id} was not found.");
                }

                _repo.Delete(makeupType);
                _repo.SaveChanges(makeupType);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}