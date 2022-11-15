using Bible.Database.Entities;

namespace Bible.DTOs.Views
{
    public class VerserView
    {
        public Int32 Id { get; set; }
        public Byte Number { get; set; }
        public String? Content { get; set; }
        public Int32 SectionId { get; set; }
        public String? SectionName { get; set; }
        public List<AudioVerseView>? AudioVerses { get; set; }
    }
}
