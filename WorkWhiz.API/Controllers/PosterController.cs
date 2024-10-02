using Microsoft.AspNetCore.Mvc;
using WorkWhiz.Core.DTOs;
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
        public ActionResult<List<PosterDto>> Get()
        {
            return Ok(_posterRepository.GetPosters());
        }
    }
}
