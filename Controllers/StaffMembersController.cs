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

        //so changes can be updated directly from database
        private readonly DataContext _context;
        public StaffMembersController (DataContext context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<List<StaffMembers>>> Get()
        {

            return Ok(members);
        }


        [HttpPost]
        public async Task<ActionResult<List<StaffMembers>>> AddMember(StaffMembers  member )
        {
            // add and then enables save changes to database.
            _context.StaffMembers.Add(member);
            await _context.SaveChangesAsync();

            return Ok(await _context.StaffMembers.ToListAsync());
        }


        [HttpPut]
        public async Task<ActionResult<List<StaffMembers>>> UpdateStaff(StaffMembers request  )
        {  
            // add and then enables save changes to database.
            var dbstaffmembers = await _context.StaffMembers.FindAsync(request.id);
            if (dbstaffmembers == null)
                return BadRequest("Member not found");

            dbstaffmembers.FirstName = request.FirstName;
            dbstaffmembers.Otchectva = request.Otchectva;
            dbstaffmembers.LastName = request.LastName;
            dbstaffmembers.Address = request.Address;
            dbstaffmembers.Salary = request.Salary;

            await _context.SaveChangesAsync();

            return Ok(await _context.StaffMembers.ToListAsync());
        }



        [HttpDelete("{id}")]
        public async Task<ActionResult<List<StaffMembers>>> Delete(int id )
        {
            var dbstaffmembers = await _context.StaffMembers.FindAsync(id);
            if (dbstaffmembers == null)
                return BadRequest("Member not found");

            _context.StaffMembers.Remove(dbstaffmembers);
            await _context.SaveChangesAsync();

            return Ok(await _context.StaffMembers.ToListAsync());
        }




    }

}
