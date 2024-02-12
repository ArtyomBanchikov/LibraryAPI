namespace Library.DAL.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }

        public int ISBN { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Genre { get; set; }

        public DateOnly ReturnDate { get; set; }

        public DateOnly TakenDate { get; set; }
    }
}
