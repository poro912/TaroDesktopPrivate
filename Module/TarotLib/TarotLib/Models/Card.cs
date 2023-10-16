using System.Drawing;

namespace TarotLib.Models
{
    public class Card : IDisposable
    {
        private bool _disposed = false;

        public string Name { get; private set; } = string.Empty;
        public string Category { get; private set; } = string.Empty;
        public int number { get; set; } = 0;
        public Bitmap BackImage { get; set; } = null;
        public Bitmap FrontImage { get; set; } = null;
        public string Info { get; private set; } = string.Empty;

        public Card() // 생성자 오버로딩
        {

        }

        public Card(string name, Bitmap frontImage, Bitmap backImage, string info) // 생성자 오버로딩
        {
            this.Name = name;
            this.BackImage = backImage;
            this.FrontImage = frontImage;
            this.Info = info;
        }

        public void setName(string name)
        {
            this.Name = name;
        }

        public void setBackImage(Bitmap img)
        {
            this.BackImage = img;
        }
        public void setFrontImage(Bitmap img)
        {
            this.FrontImage = img;
        }

        public void setInfo(string info)
        {
            this.Info = info;
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
                Info = string.Empty;
                Name = string.Empty;
                BackImage.Dispose();
                FrontImage.Dispose();
            }
            _disposed = true;
        }
    }
}
