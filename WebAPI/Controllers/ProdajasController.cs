using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/klients/{klientId}/prodajas")]
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
        public IActionResult GetProdajasForKlient(Guid klientId)
        {
            var klient = _repository.Klient.GetKlient(klientId, trackChanges: false);
            if (klient == null)
            {
                _logger.LogInfo($"Company with id: {klientId} doesn't exist in the database.");
                return NotFound();
            }
            var prodajasFromDb = _repository.Prodaja.GetProdajas(klientId, trackChanges: false);
            var prodajasDto = _mapper.Map<IEnumerable<ProdajaDto>>(prodajasFromDb);
            return Ok(prodajasFromDb);
        }
        [HttpGet("{id}", Name = "GetProdajaForKlient")]
        public IActionResult GetProdajaForKlient(Guid klientId, Guid Id)
        {
            var klient = _repository.Klient.GetKlient(klientId, trackChanges: false);
            if (klient == null)
            {
                _logger.LogInfo($"Company with id: {klientId} doesn't exist in the database.");
                return NotFound();
            }
            var prodajaDb = _repository.Prodaja.GetProdaja(klientId, Id, trackChanges: false);
            if (prodajaDb == null)
            {
                _logger.LogInfo($"Employee with id: {Id} doesn't exist in th database.");
                 return NotFound();
            }
            var prodaja = _mapper.Map<ProdajaDto>(prodajaDb);
            return Ok(prodaja);
        }
        [HttpPost]
        public IActionResult CreateProdajaForKlient(Guid klientId, [FromBody] ProdajaForCreationDto prodaja)
        {
            if (prodaja == null)
            {
                _logger.LogError("EmployeeForCreationDto object sent from client is null.");
                return BadRequest("EmployeeForCreationDto object is null");
            }
            var klient = _repository.Klient.GetKlient(klientId, trackChanges: false);
            if (klient == null)
            {
                _logger.LogInfo($"Company with id: {klientId} doesn't exist in th database.");
                return NotFound();
            }
            var prodajaEntity = _mapper.Map<Prodaja>(prodaja);
            _repository.Prodaja.CreateProdajaForKlient(klientId, prodajaEntity);
            _repository.Save();
            var prodajaToReturn = _mapper.Map<ProdajaDto>(prodajaEntity);
            return CreatedAtRoute("GetProdajaForKlient", new
            {
                klientId,
                Id = prodajaToReturn.Id
            }, prodajaToReturn);
        }
    }
}
