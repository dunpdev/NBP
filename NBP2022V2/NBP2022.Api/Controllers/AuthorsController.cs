using Microsoft.AspNetCore.Mvc;
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

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        //READ
        // GetAll
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var authors = await unitOfWork.AuthorRepository.GetAllAsync();
            return Ok(authors);
        }
        // GetById
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var author = await unitOfWork.AuthorRepository.GetByIdAsync(id);
            if (author == null)
                return NotFound($"Author with {id} not found");

            return Ok(author);
        }
        //CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Author author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //var author = new Author();
            //author.Name = form.Name;
            await unitOfWork.AuthorRepository.AddAsync(author);
            await unitOfWork.CompleteAsync();
            return Ok(author);
        }
        //UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,[FromBody] Author author)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var fAuthor = await unitOfWork.AuthorRepository.GetByIdAsync(id);
            if (fAuthor == null)
                return NotFound();
            fAuthor.Name = author.Name;

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
