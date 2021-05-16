using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class SuitController: Controller
    {
        [HttpGet]
        public string GetSuits() 
        {
            return "This will return list of suits";
        }


        [HttpGet("{id}")]
        public string GetSuit(int id) 
        {
            return "This will return a suit";
        }
    }
}