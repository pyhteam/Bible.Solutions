using Bible.Database.Entities;

namespace Bible.DTOs.Views
{
    public class SectionView
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<BookView>? Books { get; set; }
    }
}
