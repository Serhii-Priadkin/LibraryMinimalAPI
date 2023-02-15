using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int Score { get; set; }
    }
}
