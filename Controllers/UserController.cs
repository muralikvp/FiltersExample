using Filters.FilterExamp;
using Filters.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace Filters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {


        private readonly ILogger<UserController> _logger;
        private readonly HTContext _context;
        public UserController(ILogger<UserController> logger, HTContext context)
        {
            _logger = logger;
            _context = context;
        }

        [TypeFilter(typeof(ResourceFileAttribute),Arguments = new object[]{"User"})]
        [HttpGet]
        [Route("GetAllUsers")]
        public IEnumerable<User> GetUser()
        {
            //select * from user 

            return _context.user.ToList();
        }

        [HttpPost]
        [Route("InsertUser")]
        public ActionResult<User> InsertUser(User userOb)
        {
            //insert into[HTInfo_1].[dbo].[User] values('krishnan', 'krishnankvp', 'test', 1)
            _context.user.Add(userOb);
            _context.SaveChanges();
            return CreatedAtAction("GetUsers", new { id = userOb.Id }, userOb);
        }


    }
}
