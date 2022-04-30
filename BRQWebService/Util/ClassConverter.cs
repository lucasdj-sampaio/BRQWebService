using BRQWebService.Models;

namespace BRQWebService.Util
{
    public static class ClassConverter
    {
        public static Candidate TransformObj(ServiceCandidate candidate)
        {
            IList<Certification> certifications = new List<Certification>();
            IList<Skill> skills = new List<Skill>();

            foreach (var item in candidate.CertificationList)
                certifications.Add(new Certification() { CertificationName = item });

            foreach (var item in candidate.SkillList)
                skills.Add(new Skill() { SkillName = item });

            return new Candidate {
                Cpf = candidate.Cpf,
                Name = candidate.Name,
                CellPhone = candidate.CellPhone,
                BirthDate = candidate.BirthDate,
                Email = candidate.Email,
                Gender = candidate.Gender,
                CertificationCollection = certifications,
                SkillCollection = skills,
            };
        }
    }
}