using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces.Repositories;
using AutoMapper;
using API.Helper;
using API.DTOs;
using Core.Specifications.AuthorizedPerson;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizedPersonController : Controller
    {

        private readonly IGenericRepository<AuthorizedPerson> _authorizedPersonRepository;

        private readonly IMapper _mapper;

        public AuthorizedPersonController(IGenericRepository<AuthorizedPerson> authorizedPersonRepository, IMapper mapper)
        {
            _authorizedPersonRepository = authorizedPersonRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<AuthorizedPersonToReturnDTO>>> GetAuthorizedPeople([FromQuery] AuthorizedPersonSpecificationParams filter)
        {
            var specification = new AuthorizedPersonWithSuitsSpecification(filter);

            var countSpecification = new AuthorizedPersonWithFiltersForCount(filter);

            var totalItems = await _authorizedPersonRepository.CountAsync(countSpecification);

            var authorizedPeope = await _authorizedPersonRepository.ListAsync(specification);

            var data = _mapper.Map<IReadOnlyList<AuthorizedPersonToReturnDTO>>(authorizedPeope);

            return Ok(new Pagination<AuthorizedPersonToReturnDTO>(filter.PageIndex, filter.PageSize, totalItems, data));
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorizedPerson>> GetAuthorizedPerson(int id)
        {
            var specification = new AuthorizedPersonWithSuitsSpecification(id);

            return await _authorizedPersonRepository.GetEntityWithSpecification(specification);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorizedPerson>> CreateAuthorizedPerson(AuthorizedPersonDTO model)
        {
            var authorizedPerson = _mapper.Map<AuthorizedPerson>(model);
            var createdAuthorizedPerson = await _authorizedPersonRepository.Create(authorizedPerson);
            return Ok(createdAuthorizedPerson);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AuthorizedPerson>> UpdateAuthorizedPerson(int id, AuthorizedPersonDTO model)
        {
            AuthorizedPerson authorizedPerson = _mapper.Map<AuthorizedPerson>(model);
            authorizedPerson.Id = id;
            var updatedAuthorizedPerson = await _authorizedPersonRepository.Update(authorizedPerson);
            return Ok(updatedAuthorizedPerson);
        }

        [HttpDelete("{id}")]
        public void DeleteAuthorizedPerson(int id)
        {
            _authorizedPersonRepository.Delete(id);
        }

    }
}