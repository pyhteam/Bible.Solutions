namespace Bible.Database.Entities
{
    public class Verse
    {
        public Int32 Id { get; set; }
        public String? Content { get; set; }

        // forgein key
        public Int32? ChapterId { get; set; }
        public Chapter? Chapter { get; set; }
        public List<AudioVerse>? AudioVerses { get; set; }

    }
}
