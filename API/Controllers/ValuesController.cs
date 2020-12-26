using Domain;
using Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesRepository _valuesRepository;
        public ValuesController(IValuesRepository valuesRepository)
        {
            _valuesRepository = valuesRepository;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _valuesRepository.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [Route("save")]
        public async Task<IActionResult> Save([FromBody]Value value)
        {
            var result = await _valuesRepository.Save(value);
            return Ok(result);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            var result = await _valuesRepository.Delete(id);
            return Ok(result);
        }
    }
}