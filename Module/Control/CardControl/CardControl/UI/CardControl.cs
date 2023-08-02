using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CardControlLib.UI
{
    public partial class CardControl : UserControl
    {
        private string _cardInfo = string.Empty;
        private bool _isFlipp = false;
        private bool _isRotate = false;

        public enum FlipStatus
        {
            Back,
            Front,
        }

        public CardControl()
        {
            InitializeComponent();
        }

        // public void setCardData(CardData cardData)
        // {
        //     _cardInfo = cardData.info;
        //     cardPicture.Image = (Image)cardData.image.Clone();
        // }

        // 앞뒤 뒤집는거 추가하기

        private void cardPicture_DoubleClick(object sender, EventArgs e)
        {
            degreeCard();
        }

        public void degreeCard()    // 90도 회전
        {
            pictureRotate(cardPicture.Image);

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
            {
                cardPicture.Image = Properties.Resources.iu;
                if (this._isRotate)
                    pictureRotate(cardPicture.Image);
            }
            else if (status == FlipStatus.Front)
            {
                cardPicture.Image = Properties.Resources.c20556fee77525a3;
                if (this._isRotate)
                    pictureRotate(cardPicture.Image);
            }

            //현재상태의 반대로 저장 ((예) true 일경우 !true 는 false 임으로 false 가 저장됨)
            this._isFlipp = !this._isFlipp;
        }

        public void setVisible(bool value)  // 카드 및 내용 보이기
        {
            this.Visible = value;
        }

        private void cardPicture_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;
            if (_isFlipp)
            {
                setFlippStatus(FlipStatus.Front);
            }
            else if (!_isFlipp)
            {
                setFlippStatus(FlipStatus.Back);
            }
        }

        private void cardPicture_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        private void cardPicture_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }
    }
}
