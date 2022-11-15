namespace Bible.DTOs.Queries
{
    public class AudioVerseQuery
    {
        public String? Name { get; set; }
        public String? Vocal { get; set; } = "Male"; // Default: "Male": "Female"
        public String? LinkAudio { get; set; }
        public String? CreatedBy { get; set; } = "admin";
        public String? UpdatedBy { get; set; }
        public Boolean IsActive { get; set; } = true;
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public Int32 VerseId { get; set; }
    }
}
