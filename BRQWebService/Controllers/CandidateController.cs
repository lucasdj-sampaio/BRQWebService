using BRQWebService.Models;
using BRQWebService.Repository;
using BRQWebService.Repository.Context;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace BRQWebService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CandidateController : ControllerBase
    {
        private CandidateDao _candidaterepository { get; set; }

        public CandidateController(DataBaseContext context) 
            => _candidaterepository = new CandidateDao(context);


        [HttpGet("{cpf:long}", Name = "GetCandidateByCpf")]
        public IList<Candidate> Get([FromHeader] long userCpf)
        {
            return null;
        }

        [HttpGet("{email:string}", Name = "GetCandidateByEmail")]
        public IList<Candidate> Get([FromHeader] string userEmail)
        {
            return null;
        }

        [HttpGet(Name = "GetCandidateBySkill")]
        public IList<Candidate> Get([FromBody] IList<Skill> skills)
        {
            return _candidaterepository.Select(skills).GetAwaiter().GetResult();
        }

        [HttpPost(Name = "InsertCandidate")]
        public ActionResult<Candidate> Post([FromBody] ServiceCandidate candidate) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
               if (!(_candidaterepository.Insert(candidate).GetAwaiter().GetResult()))
                    return BadRequest(new { message = $"Não foi possível inserir o candidato." });

                return Created(Request.GetEncodedUrl(), candidate);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir o candidato. ({error.Message})" });
            }
        }
    }
}