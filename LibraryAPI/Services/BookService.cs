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
    public interface IBookService
    {
        IEnumerable<BookDto> GetAll();
        ActionResult<BookDto> GetById(int id);
        int Create(Book book);
        bool Update(int id, UpdateDto dto);
        bool Delete(int id);
    }
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;
        public BookService(LibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<BookDto> GetAll()
        {
            var books = _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .ToList();

            var booksDto = _mapper.Map<List<BookDto>>(books);

            return booksDto;
        }

        public ActionResult<BookDto> GetById(int id)
        {
            var book = _context.Books
                .Include(b => b.Author)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                 .FirstOrDefault(b => b.Id == id);

            var bookDto = _mapper.Map<BookDto>(book);

            return bookDto;
        }

        public int Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return book.Id;
        }

        public bool Update(int id, UpdateDto dto)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (book != null) return false;

            book.Title = dto.Title;
            book.Description = dto.Description;
            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (book != null) return false;

            _context.Remove(book);
            _context.SaveChanges();

            return true;
        }
    }
}
