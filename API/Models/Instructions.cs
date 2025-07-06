using API.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
namespace API.Models
{
    public partial class Instructions
    {
        public int InstructionID { get; set; }
        public string? Name { get; set; }
        public DateTime? DateCreation { get; set; }
        public string State { get; set; }
    }

}
