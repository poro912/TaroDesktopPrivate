using Tarot.UI;
using Resources = Tarot.Properties.Resources;

namespace Tarot.Forms
{
    public partial class TarotForm : Form
    {
        private Point _mousePoint;

        public TarotForm()
        {
            InitializeComponent();

            // ★ 코드 짠거 테스트 해보기.
            // this.cardControl1.setVisible(false);
        }

        private void TarotForm_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    CardView card = new CardView("",Resources.iu, Resources.c20556fee77525a3,"");
                    Controls.Add(card);
                    int x = (j * card.Width) / 2;
                    int y = (i * card.Height) / 2;
                    card.Location = new Point(x, y);
                    card.MouseMove += onCardMouseDrag;
                    card.MouseDown += onCardMouseDown;
                }
            }
        }

        #region Event Method
        // 카드를 마우스로 드래그 할 때, 카드 움직임
        private void onCardMouseDrag(object? sender, MouseEventArgs e)  // ? = nullable
        {
            if (sender == null) return;
            CardView card = (CardView)sender;
            if (e.Button == MouseButtons.Left)
            {
                card.Left = e.X + card.Left - _mousePoint.X;
                card.Top = e.Y + card.Top - _mousePoint.Y;
                card.BringToFront();
            }
        }

        // 카드를 마우스로 클릭할 때, 그 위치를 지정
        private void onCardMouseDown(object? sender, MouseEventArgs e)
        {
            if (sender == null) return;
            if (e.Button == MouseButtons.Left)
                _mousePoint = e.Location;
        }
        #endregion
    }
}