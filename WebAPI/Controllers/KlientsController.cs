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
using WebAPI.ModelBinders;

namespace WebAPI.Controllers
{
    [Route("api/klients")]
    [ApiController]
    public class KlientsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public KlientsController(IRepositoryManager repository, ILoggerManager
       logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetKlients()
        {
            try
            {
                var klients = _repository.Klient.GetAllKlients(trackChanges: false);
                var klientsDto = klients.Select(c => new KlientDto
                {
                    Id = c.Id,
                    KlientName = c.KlientName,
                    City = c.City
                }).ToList();
                return Ok(klientsDto);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the { nameof(GetKlients)} action { ex} ");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpGet("{id}", Name ="KlientById")]
        public IActionResult GetKlient(Guid Id)
        {
            var klient = _repository.Klient.GetKlient(Id, trackChanges: false);
            if (klient == null)
            {
                _logger.LogInfo($"Company with id: {Id} doesn't exist in the database.");
                return NotFound();
            }
            else 
            {
                var klientDto = _mapper.Map<KlientDto>(klient);
                return Ok(klientDto);
            }
        }
        [HttpGet("collection/({ids})", Name = "KlientCollection")]
        public IActionResult GetKlientCollection([ModelBinder(BinderType =
            typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
        {
            if (ids == null)
            {
                _logger.LogError("Parameter ids is null");
                return BadRequest("Parameter ids is null");
            }
            var klientEntities = _repository.Klient.GetByIds(ids, trackChanges: false);
            if (ids.Count() != klientEntities.Count())
            {
                _logger.LogError("Some ids are not valid in a collection");
                return NotFound();
            }
            var klientsToReturn =
           _mapper.Map<IEnumerable<KlientDto>>(klientEntities);
            return Ok(klientsToReturn);
        }
        [HttpPost]
        public IActionResult CreateKlient([FromBody] KlientForCreationDto klient) 
        {
            if (klient == null)
            {
                _logger.LogError("KlientForCreationDto object sent from client is null.");
            return BadRequest("KlientForCreationDto object is null");
            }
            var klientEntity = _mapper.Map<Klient>(klient);
            _repository.Klient.CreateKlient(klientEntity);
            _repository.Save();
            var klientToReturn = _mapper.Map<KlientDto>(klientEntity);
            return CreatedAtRoute("KlientById", new { id =klientToReturn.Id },
            klientToReturn);
        }
        [HttpPost("collection")]
        public IActionResult CreateKlientCollection([FromBody] IEnumerable<KlientForCreationDto> klientCollection)
        {
            if (klientCollection == null)
            {
                _logger.LogError("Company collection sent from client is null.");
                return BadRequest("Company collection is null");
            }
            var klientEntities = _mapper.Map<IEnumerable<Klient>>(klientCollection);
            foreach (var klient in klientEntities)
            {
                _repository.Klient.CreateKlient(klient);
            }
            _repository.Save();
            var klientCollectionToReturn =
            _mapper.Map<IEnumerable<KlientDto>>(klientEntities);
            var ids = string.Join(",", klientCollectionToReturn.Select(c => c.Id));
            return CreatedAtRoute("CompanyCollection", new { ids },
            klientCollectionToReturn);
        }
    }
}
