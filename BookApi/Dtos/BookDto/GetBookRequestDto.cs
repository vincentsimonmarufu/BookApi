﻿namespace BookApi.Dtos.BookDto
{
    public class GetBookRequestDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public int PublicationYear { get; set; }
    }
}
