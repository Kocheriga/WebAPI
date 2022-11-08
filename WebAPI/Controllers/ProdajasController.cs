using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        public async Task<IActionResult> GetProdajasForKlient(Guid klientId)
        {
            var klient = await _repository.Klient.GetKlientAsync(klientId, trackChanges: false);
            if (klient == null)
            {
                _logger.LogInfo($"Company with id: {klientId} doesn't exist in the database.");
                return NotFound();
            }
            var prodajasFromDb =await _repository.Prodaja.GetProdajasAsync(klientId, trackChanges: false);
            var prodajasDto = _mapper.Map<IEnumerable<ProdajaDto>>(prodajasFromDb);
            return Ok(prodajasFromDb);
        }
        [HttpGet("{id}", Name = "GetProdajaForKlient")]
        public async Task<IActionResult> GetProdajaForKlient(Guid klientId, Guid Id)
        {
            var klient =await  _repository.Klient.GetKlientAsync(klientId, trackChanges: false);
            if (klient == null)
            {
                _logger.LogInfo($"Company with id: {klientId} doesn't exist in the database.");
                return NotFound();
            }
            var prodajaDb = await _repository.Prodaja.GetProdajaAsync(klientId, Id, trackChanges: false);
            if (prodajaDb == null)
            {
                _logger.LogInfo($"Employee with id: {Id} doesn't exist in th database.");
                 return NotFound();
            }
            var prodaja = _mapper.Map<ProdajaDto>(prodajaDb);
            return Ok(prodaja);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProdajaForKlient(Guid klientId, [FromBody] ProdajaForCreationDto prodaja)
        {
            if (prodaja == null)
            {
                _logger.LogError("EmployeeForCreationDto object sent from client is null.");
                return BadRequest("EmployeeForCreationDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the ЗкщвфофForCreationDto object");
                return UnprocessableEntity(ModelState);
            }
            var klient = await _repository.Klient.GetKlientAsync(klientId, trackChanges: false);
            if (klient == null)
            {
                _logger.LogInfo($"Company with id: {klientId} doesn't exist in th database.");
                return NotFound();
            }
            var prodajaEntity = _mapper.Map<Prodaja>(prodaja);
            _repository.Prodaja.CreateProdajaForKlient(klientId, prodajaEntity);
            await _repository.SaveAsync();
            var prodajaToReturn = _mapper.Map<ProdajaDto>(prodajaEntity);
            return CreatedAtRoute("GetProdajaForKlient", new
            {
                klientId,
                Id = prodajaToReturn.Id
            }, prodajaToReturn);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProdajaForKlient(Guid klientId, Guid id)
        {
            var klient = await _repository.Klient.GetKlientAsync(klientId, trackChanges: false);
            if (klient == null)
            {
                _logger.LogInfo($"Company with id: {klientId} doesn't exist in the database.");
                return NotFound();
            }
            var prodajaForKlient = await _repository.Prodaja.GetProdajaAsync(klientId, id,
            trackChanges: false);
            if (prodajaForKlient == null)
            {
                _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
                return NotFound();
            }
            _repository.Prodaja.DeleteProdaja(prodajaForKlient);
            await _repository.SaveAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProdajaForKlient(Guid klientId, Guid id, [FromBody]
ProdajaForUpdateDto prodaja)
        {
            if (prodaja == null)
            {
                _logger.LogError("EmployeeForUpdateDto object sent from client is null.");
            return BadRequest("EmployeeForUpdateDto object is null");
            }
            if (!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the EmployeeForUpdateDto object");
                return UnprocessableEntity(ModelState);
            }
            var klient =await _repository.Klient.GetKlientAsync(klientId, trackChanges: false);
            if (klient == null)
            {
                _logger.LogInfo($"Company with id: {klientId} doesn't exist in the database.");
            return NotFound();
            }
            var prodajaEntity = await _repository.Prodaja.GetProdajaAsync(klientId, id, trackChanges: true);
            if (prodajaEntity == null)
            {
                _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
            return NotFound();
            }
            _mapper.Map(prodaja, prodajaEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PartiallyUpdateProdajaForKlient(Guid klientId, Guid id,
 [FromBody] JsonPatchDocument<ProdajaForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }
            var klient = await _repository.Klient.GetKlientAsync(klientId, trackChanges: false);
            if (klient == null)
            {
                _logger.LogInfo($"Company with id: {klientId} doesn't exist in the database.");
            return NotFound();
            }
            var prodajaEntity = await _repository.Prodaja.GetProdajaAsync( klientId, id, trackChanges:  true);
            if (prodajaEntity == null)
            {
                _logger.LogInfo($"Employee with id: {id} doesn't exist in the database.");
            return NotFound();
            }
            var prodajaToPatch = _mapper.Map<ProdajaForUpdateDto>(prodajaEntity);
            patchDoc.ApplyTo(prodajaToPatch, ModelState);
            TryValidateModel(prodajaToPatch);
            if(!ModelState.IsValid)
            {
                _logger.LogError("Invalid model state for the patch document");
                return UnprocessableEntity(ModelState);
            }
            _mapper.Map(prodajaToPatch, prodajaEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
    }
}
