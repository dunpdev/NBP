using Microsoft.AspNetCore.Mvc;
using NBP2024.Domain.Interfaces;
using NBP2024.Domain.Models;

namespace NBP2024.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : Controller
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorsController(IAuthorRepository authorRepository)
        {
            this.authorRepository = authorRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var authors = await authorRepository.GetAll();
            return Ok(authors);
        }
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] Author author)
        {
            await authorRepository.Create(author);
            return Ok(author);
        }
        [HttpGet("{aid}/teaches/{cid}")]
        public async Task<IActionResult> AuthorCourseRel(int aid,int cid)
        {
            await authorRepository.AuthorCourseRel(aid,cid);
            return Ok();
        }
    }
}
