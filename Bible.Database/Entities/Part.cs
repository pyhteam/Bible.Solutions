namespace Bible.Database.Entities
{
    public class Part
    {
        public Int32 Id { get; set; }
        public String? Name { get; set; }
        public Int32 BiblesId { get; set; }
        public Int32? PartParentId { get; set; }

        // Forgein key
        public Bibles? Bibles { get; set; }
        public Part? PartParent { get; set; }
        public List<Part>? ChildParts { get; set; }
        public List<Book>? Books { get; set; }
    }
}
