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


        [HttpGet(Name = "GetCandidate")]
        public ActionResult<IList<Candidate>> Get([FromQuery] SearchCondition condition)
        {
            try
            {
                var candidates = _candidaterepository.Select(condition);

                if (candidates.Count == 0)
                    return NoContent();

                return Ok(candidates);
            }
            catch (KeyNotFoundException ex)
            {
                return BadRequest(new { message = $"Não foi possível retornar os dados. ({ex.Message})" });
            }
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