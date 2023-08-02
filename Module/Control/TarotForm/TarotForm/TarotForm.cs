using CardControlLib.UI;

namespace TarotForm
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
                    CardControl card = new CardControl();
                    Controls.Add(card);
                    int x = (j * card.Width) / 2;
                    int y = (i * card.Height) / 2;
                    card.Location = new Point(x, y);
                    card.MouseMove += cardMouseDrag;
                    card.MouseDown += cardMouseDown;
                }
            }
        }

        private void cardMouseDrag(object sender, MouseEventArgs e)
        {
            CardControl card = (CardControl)sender;
            if (e.Button == MouseButtons.Left)
            {
                card.Left = e.X + card.Left - _mousePoint.X;
                card.Top = e.Y + card.Top - _mousePoint.Y;
                card.BringToFront();
            }
        }

        private void cardMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _mousePoint = e.Location;
        }
    }
}