using BookApi.Data;
using BookApi.Dtos.BookDto;
using BookApi.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Repositories.BookRepository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public BookRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<GetBookRequestDto>> AddBook(AddBookRequestDto addBookRequest)
        {
            var serviceResponse = new ServiceResponse<GetBookRequestDto>();

            try
            {
                var book = _mapper.Map<Book>(addBookRequest);
                await _context.Books.AddAsync(book);
                await _context.SaveChangesAsync();

                serviceResponse.Message = "Book created successfully.";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
                return serviceResponse;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBookRequestDto>> DeleteBook(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetBookRequestDto>();
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id) ??
                            throw new Exception($"Book with Id '{id}' not found");

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                serviceResponse.Data = _mapper.Map<GetBookRequestDto>(book);
                serviceResponse.Message = "Book deleted successfully.";

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBookRequestDto>> GetBookById(Guid id)
        {
            var serviceResponse = new ServiceResponse<GetBookRequestDto>();
            try
            {
                var book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id) ??
                              throw new Exception($"Book with Id '{id}' not found");
                serviceResponse.Data = _mapper.Map<GetBookRequestDto>(book);

            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetBookRequestDto>>> GetBooks()
        {
            var serviceResponse = new ServiceResponse<List<GetBookRequestDto>>();

            var books = await _context.Books.ToListAsync();

            serviceResponse.Data = _mapper.Map<List<GetBookRequestDto>>(books);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBookRequestDto>> UpdateBook(UpdateBookRequestDto updateBookRequest)
        {
            var serviceResponse = new ServiceResponse<GetBookRequestDto>();
            try
            {

                var book = await _context.Books.FirstOrDefaultAsync(u => u.Id == updateBookRequest.Id) ??
                            throw new Exception($"Book with Id '{updateBookRequest.Id}' not found");

                book.Title = updateBookRequest.Title;
                book.Author = updateBookRequest.Author;
                book.PublicationYear = updateBookRequest.PublicationYear;
                await _context.SaveChangesAsync();

                serviceResponse.Message = "Update Success";
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
