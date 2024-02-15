using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Entities
{
    public class BookEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ISBN { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Genre { get; set; }

        public DateTime? ReturnDate { get; set; }

        public DateTime? TakenDate { get; set; }
    }
}
