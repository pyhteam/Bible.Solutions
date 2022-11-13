namespace Bible.Database.Entities
{
    public class Language
    {
        public Int32 Id { get; set; }
        public String? Code { get; set; }
        public String? Name { get; set; }

        // Forgein key
        public Int32? BookId { get; set; }
        public Book? Book { get; set; }
        public List<AudioVerse>? AudioVerses { get; set; }

    }
}
