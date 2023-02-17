namespace Library.Models.DTO
{
    public class ReviewCreateDTO
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int BookId { get; set; }
        public string Reviewer { get; set; }
    }
}
