using BookApi.Dtos.BookDto;
using BookApi.Models;
using BookApi.Repositories.BookRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetBookRequestDto>>>> GetBooks()
        {
            return Ok(await _bookRepository.GetBooks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetBookRequestDto>>> GetBook(Guid id)
        {
            var response = await _bookRepository.GetBookById(id);

            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetBookRequestDto>>> Create([FromBody] AddBookRequestDto addBookRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _bookRepository.AddBook(addBookRequest);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ServiceResponse<GetBookRequestDto>>> Delete([FromRoute] Guid id)
        {
            var response = await _bookRepository.DeleteBook(id);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetBookRequestDto>>> Update(UpdateBookRequestDto updateBookRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _bookRepository.UpdateBook(updateBookRequest);

            if (response.Data is null)
            {
                return NotFound(response);
            }

            return Ok(response);
        }
    }
}
