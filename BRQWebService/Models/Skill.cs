namespace BRQWebService.Models
{
    public class Skill
    {
        public int Id { get; set; }

        public string? SkillName { get; set; }

        public long CandidateKey { get; set; }
        public Candidate? Candidate { get; set; }
    }
}