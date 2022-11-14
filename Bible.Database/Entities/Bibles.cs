namespace Bible.Database.Entities
{
    public class Bibles
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }
        public String? Code { get; set; }
        public Int32 LanguageId { get; set; }
        public Language? Language { get; set; }
        public List<Book>? Books { get; set; }
    }
}
