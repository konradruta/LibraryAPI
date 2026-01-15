using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LibraryAPI.Services
{
    public interface IBorrowingService
    {
        IEnumerable<BorrowingDto> GetBorrowings();
        ActionResult<BorrowingDto> GetBorrowingById(int id);
        int CreateBorrowing(Borrowing borrowing);
        bool EditBorrowing(int id, UpdateBorrowingDto dto);
        bool DeleteBorrowing(int id);

    }
    public class BorrowingService : IBorrowingService
    {
        private readonly LibraryDbContext _context;
        private readonly IMapper _mapper;
        public BorrowingService(LibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IEnumerable<BorrowingDto> GetBorrowings()
        {
            var borrowings = _context.Borrowings
                .Include(b => b.Book)
                .Include(b => b.User)
                .ToList();

            var borrowingsdto = _mapper.Map<List<BorrowingDto>>(borrowings);

            return borrowingsdto;
        }

        public ActionResult<BorrowingDto> GetBorrowingById(int id)
        {
            var borrowing = _context.Borrowings
                .Include(b => b.Book)
                .Include(b => b.User)
                .FirstOrDefault(b => b.Id == id);

            var borrowingdto = _mapper.Map<BorrowingDto>(borrowing);

            return borrowingdto;
        }

        public int CreateBorrowing(Borrowing borrowing)
        {
            _context.Borrowings.Add(borrowing);
            _context.SaveChanges();

            return borrowing.Id;
        }

        public bool EditBorrowing(int id, UpdateBorrowingDto dto)
        {
            var borrowing = _context.Borrowings.FirstOrDefault(c => c.Id == id);

            if (borrowing != null) return false;

            borrowing.BookId = dto.BookId;
            borrowing.Book = dto.book;
            borrowing.User = dto.User;
            borrowing.UserId = dto.UserId;
            borrowing.BorrowedDate = dto.BorrowedDate;
            borrowing.ReturnedDate = dto.ReturnedDate;

            _context.SaveChanges();

            return true;
        }

        public bool DeleteBorrowing(int id)
        {
            var borrowing = _context.Borrowings.FirstOrDefault(c => c.Id == id);

            if (borrowing != null) return false;

            _context.Borrowings.Remove(borrowing);
            _context.SaveChanges();

            return true;
        }
    }
}
