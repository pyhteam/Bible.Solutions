namespace Bible.DTOs.Views
{
    public class BiblesView
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int LanguageId { get; set; }
        public string? LanguageName { get; set; }
        public string? LanguageCode { get; set; }
        public List<BookView>? BookViews { get; set; }
    }
}
