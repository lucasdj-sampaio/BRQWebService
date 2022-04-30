namespace BRQWebService.Models
{
    public class Certification
    {
        public int Id { get; set; }

        public string? CertificationName { get; set; }

        public long CandidateKey { get; set; }
        public Candidate? Candidate { get; set; }
    }
}