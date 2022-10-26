using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WebAPIStoredProcedureCall.Data;
using WebAPIStoredProcedureCall.Model;

namespace WebAPIStoredProcedureCall.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProceduresController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ProceduresController(ApplicationDBContext context)
        {
            _context = context;
        }

        [Route("api/ProcedureWithResultSet")]
        [HttpPost]
        public async Task<ActionResult<IEnumerable<ProcedureResultSet>>> ProcedureWithResultSet(ProcedureParameter input)
        {
            string StoredProc = "exec ProcedureWithResultSet @Id=" + input.Id;
            return await _context.ProcedureReturn.FromSqlRaw(StoredProc).ToListAsync();
        }

        [Route("api/ProcedureWithOutReturn")]
        [HttpPost]
        public async Task<ActionResult<int>> ProcedureWithOutReturn(ProcedureParameter input)
        {
            string StoredProc = "exec ProcedureWithOutReturn @Name";
            var ret = await _context.Database.ExecuteSqlRawAsync(StoredProc,new SqlParameter("@Name",input.Name));

            //return number of affected rows
            return ret;
        }
    }
}
