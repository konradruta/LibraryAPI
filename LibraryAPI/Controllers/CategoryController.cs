using LibraryAPI.Entities;
using LibraryAPI.Models;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace LibraryAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _service;
        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetAll()
        {
            var categories = _service.GetCategories();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetById([FromRoute] int id)
        {
            var category = _service.GetCategoryById(id);

            if (category == null) return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public ActionResult AddCategory([FromBody] Category category)
        {
            var newCategoryId = _service.CreateCategory(category);

            return Created($"/api/book/{newCategoryId}", null);
        }

        [HttpDelete]
        public ActionResult DeleteCategory([FromRoute] int id)
        {
            _service.DeleteCategory(id);

            return NoContent();
        }

        [HttpPut]
        public ActionResult EditCategory([FromRoute] int id, [FromBody] UpdateCategoryDto dto)
        {
            var isEdited = _service.EditCategory(id, dto);

            return Ok(isEdited);
        }
        
    }
}
