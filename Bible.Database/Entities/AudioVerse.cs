namespace Bible.Database.Entities
{
    public class AudioVerse
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }
        public String? Vocal { get; set; } // Default: "Male": "Female"
        public String? LinkAudio { get; set; }
        public DateTime? CreatedAt { get; set; }
        // forgein key
        public Int32 VerseId { get; set; }
        public Verse? Verse { get; set; }

    }
}
