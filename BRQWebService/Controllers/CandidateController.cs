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

        [HttpGet(Name = "GetCandidateByCertification")]
        public IList<Candidate> Get([FromBody] IList<Certification> certifications)
        {
            return _candidaterepository.Select(certifications).GetAwaiter().GetResult();
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

                return Created(Request.GetEncodedUrl() + new Random().Next(), candidate);
            }
            catch (Exception error)
            {
                return BadRequest(new { message = $"Não foi possível inserir o candidato. ({error.Message})" });
            }
        }
    }
}