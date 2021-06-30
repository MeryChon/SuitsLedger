using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces.Repositories;
using Core.Specifications.Suits;
using AutoMapper;
using API.DTOs;
using API.Helper;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class SuitController : Controller
    {

        private readonly IGenericRepository<Suit> _suitRepository;

        private readonly IMapper _mapper;

        public SuitController(IGenericRepository<Suit> suitRepository, IMapper mapper)
        {
            _suitRepository = suitRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<SuitToReturnDTO>>> GetSuits([FromQuery] SuitSpecificationParams filter)
        {
            var specification = new SuitWithAuthorizedPersonsSpecification(filter);

            var countSpecification = new SuitWithFiltersForCount(filter);

            var totalItems = await _suitRepository.CountAsync(countSpecification);

            var suits = await _suitRepository.ListAsync(specification);

            var data = _mapper.Map<IReadOnlyList<SuitToReturnDTO>>(suits);

            return Ok(new Pagination<SuitToReturnDTO>(filter.PageIndex, filter.PageSize, totalItems, data));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Suit>> GetSuit(int id)
        {
            var specification = new SuitWithAuthorizedPersonsSpecification(id);

            return await _suitRepository.GetEntityWithSpecification(specification);
        }

        [HttpPost]
        public async Task<ActionResult<Suit>> CreateSuit(SuitDTO model)
        {
            var suit = _mapper.Map<Suit>(model);
            var createdSuit = await _suitRepository.Create(suit);
            return Ok(createdSuit);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Suit>> UpdateSuit(int id, SuitDTO model)
        {
            Suit suit = _mapper.Map<Suit>(model);
            suit.Id = id;
            var updatedSuit = await _suitRepository.Update(suit);
            return Ok(updatedSuit);
        }

        [HttpDelete("{id}")]
        public void DeleteSuit(int id)
        {
            _suitRepository.Delete(id);
        }
    }
}