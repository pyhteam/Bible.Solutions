namespace Bible.DTOs.Queries
{
    public class PartQuery
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }
        public Int32 BiblesId { get; set; }
        public Int32 PartParentId { get; set; }
    }
}
