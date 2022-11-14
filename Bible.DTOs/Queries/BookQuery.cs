namespace Bible.DTOs.Queries
{
    public class BookQuery
    {
        public string? Name { get; set; }
        public string? CodeBook { get; set; }
        public string? Introduce { get; set; }
        public int SectionId { get; set; }
        public int BiblesId { get; set; }
    }
}
