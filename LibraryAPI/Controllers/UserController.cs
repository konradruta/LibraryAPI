using LibraryAPI.Entities;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LibraryAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAllUsers()
        {
            var users = _service.GetAll();

            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetByIdUser([FromRoute] int id)
        {
            var user = _service.GetById(id);

            if (user == null) return BadRequest();

            return Ok(user);
        }

        [HttpPost]
        public ActionResult AddUser([FromBody] User user)
        {
            var userId = _service.Create(user);

            return Created($"api/author/{userId}", null);
        }

        [HttpPut]
        public ActionResult UpdateUser([FromRoute] int id, [FromBody] UpdateUserDto dto)
        {
            var isEdited = _service.Update(id, dto);

            if (!isEdited) return NotFound();

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteUser([FromRoute] int id)
        {
            var isDeleted = _service.Delete(id);

            if (!isDeleted) return NotFound();

            return NoContent();
        }
    }
}

