using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebAPIStoredProcedureCall.Model
{
    public class ProcedureResultSet
    {
        [Key]
        public Int32 Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
