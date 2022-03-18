
namespace MegaKit.EL.DBMegaKit.Entites
{
    public class Comments : Base
    {
        public string Comment { get; set; }
        public string Author { get; set; }
        public string AuthorCompany { get; set; }
        public bool Showing { get; set; }
        public byte SortId { get; set; }
    }
}
