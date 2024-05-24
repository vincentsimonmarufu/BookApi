using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos.BookDto
{
    public class AddBookRequestDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title can't be longer than 100 characters")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author is required")]
        [StringLength(100, ErrorMessage = "Author name can't be longer than 100 characters")]
        public string Author { get; set; } = string.Empty;

        [Required(ErrorMessage = "Publication Year is required")]
        [Range(1000, 9999, ErrorMessage = "Publication year must be a valid year")]
        public int PublicationYear { get; set; }
    }
}
