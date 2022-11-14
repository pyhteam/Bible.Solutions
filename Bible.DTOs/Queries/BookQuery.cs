namespace Bible.DTOs.Queries
{
    public class BookQuery
    {
        public string? Name { get; set; }
        public string? CodeBook { get; set; }
        public string? Introduce { get; set; }
        public int LanguageId { get; set; }
        public int SectionId { get; set; }
    }
}
