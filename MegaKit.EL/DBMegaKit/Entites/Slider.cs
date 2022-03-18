
namespace MegaKit.EL.DBMegaKit.Entites
{
    public class Slider : Base
    {
        public byte PageID { get; set; }
        public string SmallTitle { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public string ImageURL { get; set; }
        public string Link { get; set; }
        public string Button1Name { get; set; }
        public string Button2Name { get; set; }
        public bool Button1Status { get; set; }
        public bool Button2Status { get; set; }
        public string Button1Link { get; set; }
        public string Button2Link { get; set; }
        public byte SortId { get; set; }
    }
}
