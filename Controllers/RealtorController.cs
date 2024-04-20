using Echo_HemAPI.Data.Context;
using Echo_HemAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Echo_HemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealtorController : ControllerBase
    {
        private readonly UserManager<Realtor> _userManager;
        private readonly ApplicationDbContext _context;

        public RealtorController(UserManager<Realtor> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        // GET: api/<RealtorController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RealtorController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RealtorController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RealtorController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RealtorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
