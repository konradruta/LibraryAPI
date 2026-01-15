using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetCategories();
        ActionResult<CategoryDto> GetCategoryById(int id);
        int CreateCategory(Category category);
        bool EditCategory(int id, UpdateCategoryDto dto);
        bool DeleteCategory(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;
        public CategoryService(LibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDto> GetCategories()
        {
            var categories = _context.Categories
                .Include(c => c.BookCategories)
                    .ThenInclude(c => c.Book)
                .ToList();

            var categoriesdto = _mapper.Map<List<CategoryDto>>(categories);

            return categoriesdto;
        }

        public ActionResult<CategoryDto> GetCategoryById(int id)
        {
            var category = _context.Categories
                .Include(c => c.BookCategories)
                    .ThenInclude(c => c.Book)
                 .FirstOrDefault(c => c.Id == id);

            var categorydto = _mapper.Map<CategoryDto>(category);

            return categorydto;
        }

        public int CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();

            return category.Id;
        }

        public bool EditCategory(int id, UpdateCategoryDto dto)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category != null) return false;

            category.Name = dto.Name;
            category.Description = dto.Description;

            _context.SaveChanges();

            return true;
        }

        public bool DeleteCategory(int id)
        {
            var category = _context.Categories.FirstOrDefault(c => c.Id == id);

            if (category != null) return false;

            _context.Categories.Remove(category);
            _context.SaveChanges();

            return true;
        }
    }
}
