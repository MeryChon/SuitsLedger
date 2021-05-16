using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class SuitController : Controller
    {

        private readonly SuitLedgerContext _db;

        public SuitController(SuitLedgerContext dbContext)
        {
            _db = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Suit>>> GetSuits()
        {
            var suits = await _db.Suits.ToListAsync();

            return Ok(suits);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Suit>> GetSuit(int id)
        {
            return await _db.Suits.FindAsync(id);
        }
    }
}