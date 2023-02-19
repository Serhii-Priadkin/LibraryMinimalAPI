namespace Library.Models.DTO
{
    public class RatingCreateDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Score { get; set; }
    }
}
