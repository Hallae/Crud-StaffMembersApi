using Microsoft.EntityFrameworkCore;

namespace Members.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext>options): base(options) { }
       public DbSet<StaffMembers> StaffMembers { get; set; }
    }
}
