namespace Bible.Database.Entities
{
    public class AudioVerse
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }
        public String? LinkAudio { get; set; }
        public DateTime? CreatedAt { get; set; }
        // forgein key
        public Int32 LanguageId { get; set; }
        public Language? Language { get; set; }
        public List<Verse>? Verses { get; set; }

    }
}
