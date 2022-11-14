namespace Bible.Database.Entities
{
    public class Language
    {
        public Int32 Id { get; set; }
        public String? Code { get; set; }
        public String? Name { get; set; }

        // Forgein key
        public List<Bibles>? Bibles { get; set; }

    }
}
