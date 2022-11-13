namespace Bible.Database.Entities
{
    public class Section
    {
        public Int32? Id { get; set; }
        public String? Name { get; set; }

        // Forgein key
        public List<Book>? Books { get; set; }
    }
}
