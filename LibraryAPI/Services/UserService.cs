using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Services
{
    public interface IUserService
    {
        IEnumerable<UserDto> GetAll();
        ActionResult<UserDto> GetById(int id);
        int Create(User user);
        bool Update(int id, UpdateUserDto dto);
        bool Delete(int id);
    }
    public class UserService : IUserService
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;
        public UserService(LibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<UserDto> GetAll()
        {
            var users = _context.Users
                .Include(u => u.Borrowings)
                    .ThenInclude(u => u.Book)
                .ToList();

            var userdto = _mapper.Map<List<UserDto>>(users);

            return userdto;
        }

        public ActionResult<UserDto> GetById(int id)
        {
            var user = _context.Users
                .Include(u => u.Borrowings)
                    .ThenInclude(u => u.Book)
                .FirstOrDefault(b => b.Id == id);

            var userdto = _mapper.Map<UserDto>(user);

            return userdto;
        }

        public int Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

            return user.Id;
        }

        public bool Update(int id, UpdateUserDto dto)
        {
            var user = _context.Users.FirstOrDefault(b => b.Id == id);

            if (user != null) return false;

            user.Name = dto.Name;
            user.Email = dto.Email;
            user.Borrowings = dto.Borrowings;
            _context.SaveChanges();

            return true;
        }

        public bool Delete(int id)
        {
            var user = _context.Users.FirstOrDefault(b => b.Id == id);

            if (user != null) return false;

            _context.Remove(user);
            _context.SaveChanges();

            return true;
        }
    }
}
