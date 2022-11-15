namespace Bible.DTOs.Queries
{
    public class PartQuery
    {
        public String? Name { get; set; }
        public Int32 BiblesId { get; set; }
        public Int32 PartParentId { get; set; }
    }
}
