using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WorkWhiz.Core.Models;
using WorkWhiz.Infraestructure.Interfaces;

namespace WorkWhiz.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosterController : ControllerBase
    {
        readonly IPosterRepository _posterRepository;
        public PosterController(IPosterRepository posterRepository)
        {
            _posterRepository = posterRepository;
        }
        [HttpGet]
        public ActionResult<List<Poster>> Get()
        {
            return Ok(_posterRepository.GetPosters());
        }
    }
}
