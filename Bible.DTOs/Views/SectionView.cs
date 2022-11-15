using Bible.Database.Entities;

namespace Bible.DTOs.Views
{
    public class SectionView
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }
        public Int32? ChaterId { get; set; }
        public String? ChaterName { get; set; }
        public List<VerserView>? VerserViews { get; set; }
    }
}
