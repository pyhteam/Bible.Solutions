namespace Bible.DTOs.Views
{
    public class AudioVerseView
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }
        public String? Vocal { get; set; } // Default: "Male": "Female"
        public String? LinkAudio { get; set; }
        public DateTime? CreatedAt { get; set; }
        public Int32 VerseId { get; set; }
    }
}
