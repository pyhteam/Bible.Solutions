using Bible.Database.Entities;

namespace Bible.DTOs.Views
{
    public class BookView
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? CodeBook { get; set; }
        public string? Introduce { get; set; }
        public int SectionId { get; set; }
        public string? SectionName { get; set; }
        public int BiblesId { get; set; }
        public string? BiblesName { get; set; }
        public string? BiblesCode { get; set; }
        public List<ChapterView>? Chapters { get; set; }
    }
}
