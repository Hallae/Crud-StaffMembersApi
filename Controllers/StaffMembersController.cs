using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;

namespace Members.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffMembersController : ControllerBase
    {

        private static List<StaffMembers> members = new List<StaffMembers>()
        {
             {
                new StaffMembers {id = 1,
                    Address="komsomolsky dom 6",
                    LastName =" Egor",
                    FirstName =" ivan",
                    Otchectva="egorvich",
                    Salary= 60000 }

        }  };






        [HttpGet]
        public async Task<ActionResult<List<StaffMembers>>> Get()
        {

            return Ok(members);
        }


        [HttpPost]
        public async Task<ActionResult<List<StaffMembers>>> AddMember(StaffMembers  member )
        {
            
            members.Add(member);
            return Ok(members);
        }


        [HttpPut]
        public async Task<ActionResult<List<StaffMembers>>> UpdateStaff(StaffMembers request  )
        {
            var member = members.Find(h => h.id == request.id);
            if (member == null)
                return BadRequest("Member not found");

            member.FirstName = request.FirstName;
            member.Otchectva = request.Otchectva;
            member.LastName = request.LastName;
            member.Address = request.Address;
            member.Salary = request.Salary;

            return Ok(members);
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<List<StaffMembers>>> Delete(int id )
        {
            var member = members.Find(h => h.id == id);
            if (member == null)
                return BadRequest("Member not found");

            return Ok(members);
        }




    }

}
