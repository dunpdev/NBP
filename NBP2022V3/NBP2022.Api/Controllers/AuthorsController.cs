using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NBP2022.Api.DTOs;
using NBP2022.Data.Models;
using NBP2022.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBP2022.Api.Controllers
{
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public AuthorsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        //READ
        // GetAll
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var authors = await unitOfWork.AuthorRepository.GetAllAsync();
            var authorsDTO = mapper.Map<IEnumerable<Author>, IEnumerable<AuthorDTO>>(authors);
            return Ok(authorsDTO);
        }
        // GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var author = await unitOfWork.AuthorRepository.GetAuthorWithCoursesAsync(id);
            if (author == null)
                return NotFound($"Author with {id} not found");
            var authorDTO = mapper.Map<AuthorDTO>(author);
            return Ok(authorDTO);
        }
        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaveAuthorDTO saveAuthor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var author = mapper.Map<SaveAuthorDTO, Author>(saveAuthor);
            await unitOfWork.AuthorRepository.AddAsync(author);
            await unitOfWork.CompleteAsync();
            return Ok(author);
        }
        //UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] SaveAuthorDTO author)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var fAuthor = await unitOfWork.AuthorRepository.GetByIdAsync(id);
            if (fAuthor == null)
                return NotFound();

            mapper.Map<SaveAuthorDTO, Author>(author, fAuthor);

            await unitOfWork.CompleteAsync();
            return Ok(fAuthor);
        }
        //DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var author = await unitOfWork.AuthorRepository.GetByIdAsync(id);
            if (author == null)
                return NotFound();

            unitOfWork.AuthorRepository.Remove(author);
            await unitOfWork.CompleteAsync();
            return Ok(author);
        }
    }
}
