namespace Bible.Database.Entities
{
    public class Verse
    {
        public Int32 Id { get; set; }
        public int VerseNumber { get; set; }
        public String? Content { get; set; }

        // forgein key
        public Int32? ChapterId { get; set; }
        public Chapter? Chapter { get; set; }
        public Int32? AudioVerseId { get; set; }
        public AudioVerse? AudioVerse { get; set; }

    }
}
