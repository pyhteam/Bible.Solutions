namespace Bible.DTOs.Queries
{
    public class AudioVerseQuery
    {
        public String? Name { get; set; }
        public String? Vocal { get; set; } // Default: "Male": "Female"
        public String? LinkAudio { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public Int32 VerseId { get; set; }
    }
}
