using Bible.Database.Entities;

namespace Bible.DTOs.Views
{
    public class BookView
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }
        public String? CodeBook { get; set; }
        public String? Introduce { get; set; }
        public Int32 PartId { get; set; }
        public String? PartName { get; set; }
        public Int32 BiblesId { get; set; }
        public String? BiblesName { get; set; }
        public String? BiblesCode { get; set; }
        public List<ChapterView>? Chapters { get; set; }
    }
}
