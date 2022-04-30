using BRQWebService.Models;
using BRQWebService.Repository.Context;
using BRQWebService.Util;

namespace BRQWebService.Repository
{
    public class CandidateDao
    {
        private DataBaseContext _context { get; set; }

        public CandidateDao(DataBaseContext context) => _context = context;

        public async Task<bool> Insert(ServiceCandidate candidate) 
        {
            try
            {
                await _context.DbCandidates.AddAsync(ClassConverter.TransformObj(candidate));

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public IList<Candidate> Select(SearchCondition condition)
        {
            var searched = _context.DbCandidates
                .Where(c => (condition.Cpf == 0 || c.Cpf == condition.Cpf) && 
                    (condition.Email == null || c.Email == condition.Email) &&
                    (condition.Name == null || c.Name == condition.Name) &&
                    (condition.Skill == null 
                        || c.SkillCollection.Any(a => a.SkillName == condition.Skill)) &&
                    (condition.Certification == null 
                        || c.CertificationCollection.Any(a => a.CertificationName == condition.Certification)))
                .ToList<Candidate>();

            foreach (var candidate in searched)
            {
                candidate.SkillCollection = _context.DbSkill
                        .Where(s => s.CandidateKey == candidate.Cpf)
                        .ToList<Skill>();

                candidate.CertificationCollection = _context.DbCertification
                    .Where(c => c.CandidateKey == candidate.Cpf)
                    .ToList<Certification>();
            }

            return searched;
        }
    }
}