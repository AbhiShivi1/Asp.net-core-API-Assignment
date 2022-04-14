using AssignmentWebAPI.Models;
using AssignmentWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AssignmentWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyValueController : ControllerBase
    {
        private readonly IKeyValueRepository _keyValueRepository;

        public KeyValueController(IKeyValueRepository keyValueRepository)
        {
            _keyValueRepository = keyValueRepository;
        }


        [HttpGet("keys/{key}")]
        public async Task<IActionResult> GetValueByKey([FromRoute]string key)
        {
            
           var value= await _keyValueRepository.GetValueByKeyAsync(key);
            if(value==null)
            {
                return NotFound();
            }
            return Ok(value.Value);
        }

        [HttpPost("keys")]
        public async Task<IActionResult> AddKeyValue([FromBody] KeyValueModel keyValueModel)
        {
            var result = await _keyValueRepository.AddKeyValueAsync(keyValueModel);
            if (result == false)
            {
                return Conflict();
            }
            return Ok();
        }

        [HttpPatch("keys/{key}/{value}")]
        public async Task<IActionResult> UpdateKeyPatch([FromRoute]string key, [FromRoute] string value)
        {
            var answer = await _keyValueRepository.UpdateKeyPatchAsync(key, value);
            if(answer==false)
            {
                return NotFound();
            }
            return Ok();

        }

        [HttpDelete("{key}")]
        public async Task<IActionResult> DeleteBook([FromRoute] string key)
        {
           var record= await _keyValueRepository.DeleteKeyValueAsync(key);

            if(record==false)
            {
                return NotFound();

            }
            return Ok();
        }
    }
}
