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
                var klients = _repository.Table1.GetAllKlients(trackChanges: false);
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
        [HttpGet("{id}")]
        public IActionResult GetKlient(int Id)
        {
            var klient = _repository.Table1.GetKlient(Id, trackChanges: false);
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
    }
}
