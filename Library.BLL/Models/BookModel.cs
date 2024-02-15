namespace Library.BLL.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        public long ISBN { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public DateTime ReturnDate { get; set; }

        public DateTime TakenDate { get; set; }
    }
}
