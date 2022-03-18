using MegaKit.EL.DBMegaKit.Entites;
using System;
using System.Collections.Generic;

namespace MegaKit.EL.DTO
{
    public class TeamDTO : IDisposable
    {
        public IList<Team> Team { get; set; }
        public IList<Contact> Contact { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Team = null;
                Contact = null;
            }
        }
    }
}
