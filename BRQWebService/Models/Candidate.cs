using BRQWebService.Interfaces;

namespace BRQWebService.Models
{
    public class Candidate : ICandidate
    {
        public string? Name { get; set; }

        public long Cpf { get; set; }

        public string? Email { get; set; }

        public long CellPhone { get; set; }

        public char Gender { get; set; }

        public DateTime BirthDate { get; set; }

        public ICollection<Certification>? CertificationCollection { get; set; }

        public ICollection<Skill>? SkillCollection { get; set; }
    }
}