using BRQWebService.Interfaces;

namespace BRQWebService.Models
{
    public class ServiceCandidate : ICandidate
    {
        public string? Name { get; set; }

        public long Cpf { get; set; }

        public string? Email { get; set; }

        public long CellPhone { get; set; }

        public char Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public IList<string> SkillList { get; set; }

        public IList<string> CertificationList { get; set; }
    }
}