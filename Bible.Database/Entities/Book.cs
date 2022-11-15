namespace Bible.Database.Entities
{
    public class Book
    {
        public Int32 Id { get; set; }
        public String? CodeBook { get; set; }
        public String? Name { get; set; }
        public String? Introduce { get; set; }
        public Int32 PartId { get; set; }

        // Forgein key
        public Part? Part { get; set; }
        public List<Chapter>? Chapters { get; set; }
    }
}
