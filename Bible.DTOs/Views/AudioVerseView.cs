namespace Bible.DTOs.Views
{
    public class AudioVerseView
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }
        public String? Vocal { get; set; }  // Default: "Male": "Female"
        public String? LinkAudio { get; set; }
        public String? CreatedBy { get; set; }
        public String? UpdatedBy { get; set; }
        public Boolean IsActive { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Int32 VerseId { get; set; }
        public String? VerseName { get; set; }
    }
}
