using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorizedPersonController : Controller
    {

        private readonly SuitLedgerContext _db;

        public AuthorizedPersonController(SuitLedgerContext dbContext)
        {
            _db = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorizedPerson>>> GetAuthorizedPersons()
        {
            var authorizedPersons = await _db.AuthorizedPersons.ToListAsync();
            return Ok(authorizedPersons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorizedPerson>> GetAuthorizedPerson(int id)
        {
            return await _db.AuthorizedPersons.FindAsync(id);
        }

    }
}