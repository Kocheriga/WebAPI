using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ActionFilters;

namespace WebAPI.Controllers
{
    [Route("api/klients/{klientId}/prodajas")]
    [ApiController]
    public class ProdajasController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IDataShaper<ProdajaDto> _dataShaper;
        public ProdajasController(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IDataShaper<ProdajaDto> dataShaper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
            _dataShaper = dataShaper;
        }
        [HttpGet]
        [HttpHead]
        public async Task<IActionResult> GetProdajasForKlient(Guid klientId,
 [FromQuery] ProdajaParameters prodajaParameters)
        {
            if (!prodajaParameters.ValidCostRange)
                return BadRequest("Max cost can't be less than min cost.");
            var klient = await _repository.Klient.GetKlientAsync(klientId, trackChanges: false);
            if (klient == null)
            {
                _logger.LogInfo($"Company with id: {klientId} doesn't exist in the database.");
                return NotFound();
            }
            var prodajasFromDb = await _repository.Prodaja.GetProdajasAsync(klientId, prodajaParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(prodajasFromDb.MetaData));
            var prodajasDto = _mapper.Map<IEnumerable<ProdajaDto>>(prodajasFromDb);
            return Ok(_dataShaper.ShapeData(prodajasDto, prodajaParameters.Fields));
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
        [ServiceFilter(typeof(ValidateProdajaForKlientExistsAttribute))]
        public async Task<IActionResult> DeleteProdajaForKlient(Guid klientId, Guid id)
        {
            var prodajaForKlient = HttpContext.Items["prodaja"] as Prodaja;
            _repository.Prodaja.DeleteProdaja(prodajaForKlient);
            await _repository.SaveAsync();
            return NoContent();
        }
        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [ServiceFilter(typeof(ValidateProdajaForKlientExistsAttribute))]
        public async Task<IActionResult> UpdateProdajaForKlient(Guid klientId, Guid id, [FromBody]
ProdajaForUpdateDto prodaja)
        {
            var prodajaEntity = HttpContext.Items["prodaja"] as Prodaja;
            _mapper.Map(prodaja, prodajaEntity);
            await _repository.SaveAsync();
            return NoContent();
        }
        [HttpPatch("{id}")]
        [ServiceFilter(typeof(ValidateProdajaForKlientExistsAttribute))]
        public async Task<IActionResult> PartiallyUpdateProdajaForKlient(Guid klientId, Guid id,
 [FromBody] JsonPatchDocument<ProdajaForUpdateDto> patchDoc)
        {
            if (patchDoc == null)
            {
                _logger.LogError("patchDoc object sent from client is null.");
                return BadRequest("patchDoc object is null");
            }
            var prodajaEntity = HttpContext.Items["prodaja"] as Prodaja;
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
