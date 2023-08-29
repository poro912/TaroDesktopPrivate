using System.ComponentModel;
using TarotLib.Models;

namespace Tarot.UI
{
    public partial class CardView : UserControl
    {
        public Card CardData;
        private bool _isFlip;
        private bool _isRotate;

        public enum FlipStatus
        {
            Back,
            Front,
        }

        public CardView()
        {
            InitializeComponent();
            CardData = new Card();
            _isFlip = false;
            _isRotate = false;
        }

        public CardView(string name, Bitmap frontImage, Bitmap backImage, string info)
        {
            InitializeComponent();
            _isFlip = false;
            _isRotate = false;
            CardData = new Card(name, frontImage, backImage, info);
            cardPicture.Image = CardData.BackImage;
        }

        public void degreeCard()    // 90도 회전
        {
            pictureRotate(CardData.BackImage);
            pictureRotate(CardData.FrontImage);

            int oldWidth = this.Width;
            int oldHeight = this.Height;
            this.Width = oldHeight;
            this.Height = oldWidth;

            // 십자가 모양
            int posX = this.Location.X + (cardPicture.Height / 2) - (oldHeight / 2);
            int posY = this.Location.Y + (cardPicture.Width / 2) - (oldWidth / 2);
            this.Location = new Point(posX, posY);

            this._isRotate = !this._isRotate;

            this.Refresh();
        }

        public void pictureRotate(Image image)
        {
            image.RotateFlip(RotateFlipType.Rotate90FlipX);
        }

        public void setFlippStatus(FlipStatus status)   // 카드 뒤집기
        {
            if (status == FlipStatus.Back)
                cardPicture.Image = CardData.BackImage;
            else if (status == FlipStatus.Front)
                cardPicture.Image = CardData.FrontImage;

            //현재상태의 반대로 저장 ((예) true 일경우 !true 는 false 임으로 false 가 저장됨)
            this._isFlip = !this._isFlip;
        }

        public void setVisible(bool value)  // 카드 및 내용 보이기
        {
            this.Visible = value;
        }

        #region Event Method
        private void cardPicture_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        private void cardPicture_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        private void cardPicture_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            degreeCard();
        }

        private void cardPicture_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            if (_isFlip)
            {
                setFlippStatus(FlipStatus.Front);
            }
            else if (!_isFlip)
            {
                setFlippStatus(FlipStatus.Back);
            }
        }
        #endregion
    }
}
