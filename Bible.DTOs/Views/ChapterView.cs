namespace Bible.DTOs.Views
{
    public class ChapterView
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }
        public String? Summary { get; set; }
        public Int32 BookId { get; set; }
        public String? BookName { get; set; }
        public List<VerserView>? VerserViews { get; set; }
    }
}
