using LibraryAPI.Entities;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace LibraryAPI.Controllers
{
    [Route("api/author")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _service;
        public AuthorController(IAuthorService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Author>> GetAllAuthors()
        {
            var authors = _service.GetAll();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public ActionResult<Author> GetByIdAuthor([FromRoute] int id)
        {
            var author = _service.GetById(id);

            if (author == null) return BadRequest();

            return Ok(author);
        }

        [HttpPost]
        public ActionResult AddAuthor([FromBody] Author author)
        {
            var authorId = _service.Create(author);

            return Created($"api/author/{authorId}", null);
        }

        [HttpPut]
        public ActionResult UpdateAuthor([FromRoute] int id, [FromBody] UpdateAuthorDto dto)
        {
            var isEdited = _service.Update(id, dto);

            if (!isEdited) return NotFound();

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteAuthor([FromRoute] int id)
        {
            var isDeleted = _service.Delete(id);

            if (!isDeleted) return NotFound();

            return NoContent();
        }
    }
}
