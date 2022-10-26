using Microsoft.EntityFrameworkCore;
using WebAPIStoredProcedureCall.Model;

#nullable disable

namespace WebAPIStoredProcedureCall.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public virtual DbSet<ProcedureResultSet> ProcedureReturn { get; set; }
    }
}
