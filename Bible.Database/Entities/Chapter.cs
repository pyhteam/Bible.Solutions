using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bible.Database.Entities
{
    public class Chapter
    {
        public Int32 Id { get; set; }
        public int ChapterNumber { get; set; }
        public String? Name { get; set; }
        public String? Summary { get; set; }

        // forgein key
        public List<Verse>? Verses { get; set; }
        public Int32? BookId { get; set; }
        public Book? Book { get; set; }
    }
}
