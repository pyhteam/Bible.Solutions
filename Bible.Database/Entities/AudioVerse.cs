namespace Bible.Database.Entities
{
    public class AudioVerse
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }
        public String? Vocal { get; set; }
        public String? LinkAudio { get; set; }
        public String? CreatedBy { get; set; }
        public String? UpdatedBy { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdateAt { get; set; }

        // forgein key
        public Int32 VerseId { get; set; }
        public Verse? Verse { get; set; }

    }
}
