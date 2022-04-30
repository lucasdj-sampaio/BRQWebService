using Microsoft.AspNetCore.Mvc;

namespace BRQWebService.Models
{
    public class SearchCondition
    {
        [FromQuery]
        public long Cpf { get; set; }

        [FromQuery]
        public string? Name { get; set; }

        [FromQuery]
        public string? Email { get; set; }

        [FromQuery]
        public string? Skill { get; set; }

        [FromQuery]
        public string? Certification { get; set; }
    }
}