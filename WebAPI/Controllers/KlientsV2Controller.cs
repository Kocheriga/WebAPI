using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiVersion("2.0", Deprecated = true)]
    [Route("api/klients")]
    [ApiController]
    public class KlientsV2Controller : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        public KlientsV2Controller(IRepositoryManager repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetKlients()
        {
            var klients = await
           _repository.Klient.GetAllKlientsAsync(trackChanges: false);
            return Ok(klients);
        }
    }
}
