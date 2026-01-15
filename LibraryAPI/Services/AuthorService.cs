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
    public interface IAuthorService
    {
        IEnumerable<AuthorDto> GetAll();
        ActionResult<AuthorDto> GetById(int id);
        int Create(Author author);
        bool Update(int id, UpdateAuthorDto dto);
        bool Delete(int id);
    }
    public class AuthorService : IAuthorService
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;
        public AuthorService(LibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<AuthorDto> GetAll()
        {
            var authors = _context.Authors
                .Include(a => a.Books)
                .ToList();

            var authorsDto = _mapper.Map<List<AuthorDto>>(authors);

            return authorsDto;
        }

        public ActionResult<AuthorDto> GetById(int id)
        {
            var author = _context.Authors
                .Include (a => a.Books)
                .FirstOrDefault(a => a.Id == id);

            var authorDto = _mapper.Map<AuthorDto>(author);

            return authorDto;
        }

        public int Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();

            return author.Id;
        }

        public bool Update(int id, UpdateAuthorDto dto)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Id == id);

            if (author == null) return false;

            author.Name = dto.Name;
            author.Biography = dto.Description;

            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var author = _context.Authors.FirstOrDefault(a => a.Id == id);

            if (author == null) return false;

            _context.Remove(author);
            _context.SaveChanges();

            return true;
        }
    }
}
