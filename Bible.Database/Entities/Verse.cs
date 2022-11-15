namespace Bible.Database.Entities
{
    public class Verse
    {
        public Int32 Id { get; set; }
        public Byte Number { get; set; }
        public String? Content { get; set; }
        public Int32 SectionId { get; set; }

        // forgein key
        public Section? Section { get; set; }
        public List<AudioVerse>? AudioVerses { get; set; }

    }
}
