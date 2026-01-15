using LibraryAPI.Entities;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryAPI.Controllers
{
    [Route("api/borrowing")]
    [ApiController]
    [Authorize]
    public class BorrowingController : Controller
    {
        private readonly IBorrowingService _service;
        public BorrowingController(IBorrowingService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            var borrowings = _service.GetBorrowings();

            return Ok(borrowings);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Category> GetById([FromRoute] int id)
        {
            var borrowing = _service.GetBorrowingById(id);

            if (borrowing == null) return NotFound();

            return Ok(borrowing);
        }

        [HttpPost]
        public ActionResult AddBorrowing([FromBody] Borrowing borrowing)
        {
            var newBorrowingId = _service.CreateBorrowing(borrowing);

            return Created($"/api/book/{newBorrowingId}", null);
        }

        [HttpDelete]
        public ActionResult DeleteBorrowing([FromRoute] int id)
        {
            _service.DeleteBorrowing(id);

            return NoContent();
        }

        [HttpPut]
        public ActionResult EditBorrowing([FromRoute] int id, [FromBody] UpdateBorrowingDto dto)
        {
            var isEdited = _service.EditBorrowing(id, dto);

            return Ok(isEdited);
        }
    }
}

