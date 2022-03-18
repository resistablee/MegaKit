using MegaKit.EL.DBMegaKit.Entites;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MegaKit.EL
{
    public class ReturnValue<T> : IDisposable
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public T Data { get; set; }
        public int? DataCount { get; set; }
        public bool AnyData { get; set; }
        public int? StatusCode { get; set; }
        public Exception Exception { get; set; }
        public string ErrorCode { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Title = null;
                this.Text = null;
                //this.Data = null
                this.DataCount = null;
                //this.AnyData = null;
                this.StatusCode = null;
                this.Exception = null;
                this.ErrorCode = null;
            }
        }
    }
}
