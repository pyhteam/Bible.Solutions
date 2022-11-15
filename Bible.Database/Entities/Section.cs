namespace Bible.Database.Entities
{
    public class Section
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }
        public Int32 ChapterId { get; set; }
        // Forgein key
        public Chapter? Chapter { get; set; }

        public List<Verse>? Verses { get; set; }
    }
}
