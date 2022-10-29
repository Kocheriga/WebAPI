using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/klients/{KlientsId}/prodajas")]
    [ApiController]
    public class ProdajasController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public ProdajasController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;

        }
        [HttpGet]
        public IActionResult GetProdajasForKlient(int KlientsId)
        {
            var klient = _repository.Table1.GetKlient(KlientsId, trackChanges: false);
            if(klient == null)
            {
                _logger.LogInfo($"Klient with id: {KlientsId} doesn't exist in the database.");
                return NotFound();
            }
            var prodajasFromDb = _repository.Table2.GetProdajas(KlientsId, trackChanges: false);
            var prodajaDto = _mapper.Map<IEnumerable<ProdajaDto>>(prodajasFromDb);
            return Ok(prodajaDto);
        }
        [HttpGet("{Id}")]
        public IActionResult GetEmployeeForCompany(int KlientsId, int Id)
        {
            var klient = _repository.Table1.GetKlient(KlientsId, trackChanges: false);
            if (klient == null)
            {
                _logger.LogInfo($"Company with id: {KlientsId} doesn't exist in the database.");
            return NotFound();
            }
            var prodajaDb = _repository.Table2.GetProdaja(KlientsId, Id, trackChanges: false);
            if (prodajaDb== null)
            {
                _logger.LogInfo($"Employee with id: {Id} doesn't exist in the database.");
            return NotFound();
            }
            var prodaja = _mapper.Map<ProdajaDto>(prodajaDb);
            return Ok(prodaja);
        }
    }
}
