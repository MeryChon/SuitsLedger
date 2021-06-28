using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.Interfaces.Repositories;
using Core.Specifications.Suits;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class SuitController : Controller
    {

        private readonly IGenericRepository<Suit> _suitRepository;

        public SuitController(IGenericRepository<Suit> suitRepository)
        {
            _suitRepository = suitRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Suit>>> GetSuits(SuitSpecificationParams filter)
        {
            var specification = new SuitWithAuthorizedPersonsSpecification(filter);

            return Ok(await _suitRepository.ListAsync(specification));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Suit>> GetSuit(int id)
        {
            var specification = new SuitWithAuthorizedPersonsSpecification(id);

            return await _suitRepository.GetEntityWithSpecification(specification);
        }
    }
}