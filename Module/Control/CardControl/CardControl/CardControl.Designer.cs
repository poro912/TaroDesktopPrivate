namespace CardControl
{
    partial class CardControl
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            cardPicture = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)cardPicture).BeginInit();
            SuspendLayout();
            // 
            // cardPicture
            // 
            cardPicture.Dock = DockStyle.Fill;
            cardPicture.Image = Properties.Resources.c20556fee77525a3;
            cardPicture.Location = new Point(0, 0);
            cardPicture.Name = "cardPicture";
            cardPicture.Size = new Size(320, 477);
            cardPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            cardPicture.TabIndex = 0;
            cardPicture.TabStop = false;
            cardPicture.DoubleClick += cardPicture_DoubleClick;
            cardPicture.MouseClick += cardPicture_MouseClick;
            // 
            // CardControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cardPicture);
            Name = "CardControl";
            Size = new Size(320, 477);
            ((System.ComponentModel.ISupportInitialize)cardPicture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox cardPicture;
    }
}
