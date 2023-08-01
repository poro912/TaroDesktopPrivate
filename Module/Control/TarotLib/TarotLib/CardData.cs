using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TarotLib
{
    public class CardData : IDisposable
    {
        private bool _disposed = false;

        public string name;
        public Image image;
        public string info;

        public void cardData(string name, Image image, string info)
        {
            this.name = name;
            this.image = image;
            this.info = info;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            if (disposing)
            {
                info = string.Empty;
                name = string.Empty;
                image.Dispose();
            }
            _disposed = true;
        }
    }
}
