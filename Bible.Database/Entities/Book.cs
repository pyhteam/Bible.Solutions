namespace Bible.Database.Entities
{
    public class Book
    {
        public Int32 Id { get; set; }
        public String? CodeBook { get; set; }
        public String? Name { get; set; }
        public String? Introduce { get; set; }

        // Forgein key
        public Int32 BiblesId { get; set; }
        public Bibles? Bibles { get; set; }
        public Int32 SectionId { get; set; }
        public Section? Section { get; set; }
        public List<Chapter>? Chapters { get; set; }
    }
}
