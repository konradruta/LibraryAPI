using AutoMapper;
using LibraryAPI.Entities;
using LibraryAPI.Models;
using System.Linq;

namespace LibraryAPI
{
    public class BookMappingProfile : Profile
    {
        public BookMappingProfile() 
        {
            CreateMap<Book, BookDto>()
                .ForMember(b => b.Author, c => c.MapFrom(a => a.Author.Name))
                .ForMember(b => b.Categories, e => e.MapFrom(c => c.BookCategories.Select(bc => bc.Category.Name)));

            CreateMap<Author, AuthorDto>()
                .ForMember(a => a.Books, b => b.MapFrom(c => c.Books.Select(bt => bt.Title)));

            CreateMap<Borrowing, BorrowingDto>()
                .ForMember(b => b.BookTitle, e => e.MapFrom(c => c.Book.Title))
                .ForMember(b => b.UserName, e => e.MapFrom(u => u.User.Name));

            CreateMap<Category, CategoryDto>()
                .ForMember(c => c.Books, e => e.MapFrom(b => b.BookCategories.Select(bt => bt.Book.Title)));

            CreateMap<User, UserDto>()
                .ForMember(u => u.BorrowedBooks, e => e.MapFrom(b => b.Borrowings.Select(bt => bt.Book.Title)));
        }
    }
}
