using System.Drawing;

namespace TarotLib.Models
{
    public class Card : IDisposable
    {
        private bool _disposed = false;

        public string name { get; private set; } = string.Empty;
        public string category { get; private set; } = string.Empty;
        public int number { get; set; } = 0;
        public Bitmap backImage { get; set; } = null;
        public Bitmap frontImage { get; set; } = null;
        public string info { get; private set; } = string.Empty;

        public Card() // 생성자 오버로딩
        {

        }

        public Card(string name, Bitmap frontImage, Bitmap backImage, string info) // 생성자 오버로딩
        {
            this.name = name;
            this.backImage = backImage;
            this.frontImage = frontImage;
            this.info = info;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setBackImage(Bitmap img)
        {
            this.backImage = img;
        }
        public void setFrontImage(Bitmap img)
        {
            this.frontImage = img;
        }

        public void setInfo(string info)
        {
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
                backImage.Dispose();
                frontImage.Dispose();
            }
            _disposed = true;
        }
    }
}
