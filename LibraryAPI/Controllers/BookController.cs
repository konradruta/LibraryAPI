using LibraryAPI.Entities;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace LibraryAPI.Controllers
{
    [Route("api/book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _service;
        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<LibraryDbContext>> GetAll() 
        {
            var books = _service.GetAll();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<LibraryDbContext> GetById([FromRoute] int id)
        {
            var book = _service.GetById(id);

            return Ok(book);
        }

        [HttpPost]
        public ActionResult Create([FromBody] Book book)
        {
            var bookId = _service.Create(book);

            return Created($"/api/library/{bookId}", null);
        }

        [HttpPut]
        public ActionResult Update([FromRoute] int id, [FromBody] UpdateDto dto)
        {
            var isUpdate = _service.Update(id, dto);

            if (!isUpdate) return NotFound();

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteById([FromRoute] int id)
        {
            var isDelete = _service.Delete(id);

            if (!isDelete) return NotFound();

            return NoContent();
        }
    }
}
