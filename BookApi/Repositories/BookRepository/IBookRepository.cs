using BookApi.Dtos.BookDto;
using BookApi.Models;

namespace BookApi.Repositories.BookRepository
{
    public interface IBookRepository
    {
        Task<ServiceResponse<List<GetBookRequestDto>>> GetBooks();
        Task<ServiceResponse<GetBookRequestDto>> GetBookById(Guid id);
        Task<ServiceResponse<GetBookRequestDto>> AddBook(AddBookRequestDto addBookRequest);
        Task<ServiceResponse<GetBookRequestDto>> UpdateBook(UpdateBookRequestDto updateBookRequest);
        Task<ServiceResponse<GetBookRequestDto>> DeleteBook(Guid id);
    }
}
