using Bible.Database.Entities;

namespace Bible.DTOs.Views
{
    public class PartView
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }
        public String? BiblesName { get; set; }
        public Int32 BiblesId { get; set; }
        public Int32 PartParentId { get; set; }
        public String? PartParentName { get; set; }
        public List<PartView>? ListChildPart { get; set; }
        public List<BookView>? Books { get; set; }

    }
}
