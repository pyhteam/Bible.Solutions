using Bible.Database.Entities;

namespace Bible.DTOs.Views
{
    public class VerserView
    {
        public Int32 Id { get; set; }
        public String? Content { get; set; }
        public Int32 ChapterId { get; set; }
        public String? ChapterName { get; set; }
        public List<AudioVerseView>? AudioVerses { get; set; }
    }
}
