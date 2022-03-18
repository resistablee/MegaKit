using System;

namespace MegaKit.EL.DBMegaKit.Entites
{
    public class Feedback : Base
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Text { get; set; }
        public DateTime InsertedDate { get; set; }
    }
}
