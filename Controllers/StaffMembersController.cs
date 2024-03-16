using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Members.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffMembersController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var members = new List<StaffMembers>
            {
                new StaffMembers {id = 1,
                    Address="komsomolsky dom 6",
                    LastName =" Egor",
                    FirstName =" ivan",
                    Otchectva="egorvich",
                    Salary= 60000 }
  
            };
            return Ok(members);
        }
     
    }
}
