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

        public async Task<IList<Candidate>> Select(IList<Certification> certifications)
        {
            return null;
        }

        public async Task<IList<Candidate>> Select(IList<Skill> skills) 
        {
            return null;
        }
    }
}