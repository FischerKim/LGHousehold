namespace ShampDesign
{
    partial class frmMain
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PnlBody = new Daekhon.Control.Custom.CPanel();
            this.LblReicpe = new Daekhon.Control.Custom.CLabel();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnReport = new System.Windows.Forms.Button();
            this.BtnMinimize = new System.Windows.Forms.Button();
            this.LblTitle = new Daekhon.Control.Custom.CLabel();
            this.PicLogo = new System.Windows.Forms.PictureBox();
            this.BtnHome = new System.Windows.Forms.Button();
            this.PnlHeader = new Daekhon.Control.Custom.CPanel();
            this.LblTime = new Daekhon.Control.Custom.CLabel();
            this.PnlFooter = new Daekhon.Control.Custom.CPanel();
            this.BtnRecipe = new System.Windows.Forms.Button();
            this.Timer1000 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).BeginInit();
            this.PnlHeader.SuspendLayout();
            this.PnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlBody
            // 
            this.PnlBody.BDrawBorderBottom = false;
            this.PnlBody.BDrawBorderLeft = false;
            this.PnlBody.BDrawBorderRight = false;
            this.PnlBody.BDrawBorderTop = false;
            this.PnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBody.Location = new System.Drawing.Point(0, 45);
            this.PnlBody.Name = "PnlBody";
            this.PnlBody.Size = new System.Drawing.Size(1920, 985);
            this.PnlBody.TabIndex = 5;
            // 
            // LblReicpe
            // 
            this.LblReicpe.BackColor = System.Drawing.Color.DimGray;
            this.LblReicpe.BDrawBorderBottom = false;
            this.LblReicpe.BDrawBorderLeft = false;
            this.LblReicpe.BDrawBorderRight = true;
            this.LblReicpe.BDrawBorderTop = false;
            this.LblReicpe.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblReicpe.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblReicpe.ForeColor = System.Drawing.Color.White;
            this.LblReicpe.Location = new System.Drawing.Point(510, 0);
            this.LblReicpe.Name = "LblReicpe";
            this.LblReicpe.OColor = System.Drawing.Color.Black;
            this.LblReicpe.Size = new System.Drawing.Size(1123, 45);
            this.LblReicpe.TabIndex = 2;
            this.LblReicpe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnExit.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.BtnExit.ForeColor = System.Drawing.Color.White;
            this.BtnExit.Location = new System.Drawing.Point(1767, 2);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(150, 45);
            this.BtnExit.TabIndex = 0;
            this.BtnExit.Text = "종료";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnReport
            // 
            this.BtnReport.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnReport.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.BtnReport.ForeColor = System.Drawing.Color.White;
            this.BtnReport.Location = new System.Drawing.Point(315, 3);
            this.BtnReport.Name = "BtnReport";
            this.BtnReport.Size = new System.Drawing.Size(150, 45);
            this.BtnReport.TabIndex = 0;
            this.BtnReport.Text = "보고서";
            this.BtnReport.UseVisualStyleBackColor = false;
            this.BtnReport.Click += new System.EventHandler(this.BtnReport_Click);
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnMinimize.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.BtnMinimize.ForeColor = System.Drawing.Color.White;
            this.BtnMinimize.Location = new System.Drawing.Point(1877, 2);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(40, 40);
            this.BtnMinimize.TabIndex = 2;
            this.BtnMinimize.Text = "_";
            this.BtnMinimize.UseVisualStyleBackColor = false;
            this.BtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.DimGray;
            this.LblTitle.BDrawBorderBottom = false;
            this.LblTitle.BDrawBorderLeft = false;
            this.LblTitle.BDrawBorderRight = true;
            this.LblTitle.BDrawBorderTop = false;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblTitle.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.LblTitle.Location = new System.Drawing.Point(210, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.OColor = System.Drawing.Color.Black;
            this.LblTitle.Size = new System.Drawing.Size(300, 45);
            this.LblTitle.TabIndex = 2;
            this.LblTitle.Text = "샴푸 문양 비젼";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PicLogo
            // 
            this.PicLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.PicLogo.Image = global::ShampDesign.Properties.Resources.Logo;
            this.PicLogo.Location = new System.Drawing.Point(0, 0);
            this.PicLogo.Name = "PicLogo";
            this.PicLogo.Size = new System.Drawing.Size(210, 45);
            this.PicLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicLogo.TabIndex = 0;
            this.PicLogo.TabStop = false;
            // 
            // BtnHome
            // 
            this.BtnHome.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnHome.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.BtnHome.ForeColor = System.Drawing.Color.White;
            this.BtnHome.Location = new System.Drawing.Point(3, 3);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Size = new System.Drawing.Size(150, 45);
            this.BtnHome.TabIndex = 0;
            this.BtnHome.Text = "홈";
            this.BtnHome.UseVisualStyleBackColor = false;
            this.BtnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // PnlHeader
            // 
            this.PnlHeader.BDrawBorderBottom = false;
            this.PnlHeader.BDrawBorderLeft = false;
            this.PnlHeader.BDrawBorderRight = false;
            this.PnlHeader.BDrawBorderTop = false;
            this.PnlHeader.Controls.Add(this.LblTime);
            this.PnlHeader.Controls.Add(this.BtnMinimize);
            this.PnlHeader.Controls.Add(this.LblReicpe);
            this.PnlHeader.Controls.Add(this.LblTitle);
            this.PnlHeader.Controls.Add(this.PicLogo);
            this.PnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlHeader.Location = new System.Drawing.Point(0, 0);
            this.PnlHeader.Name = "PnlHeader";
            this.PnlHeader.Size = new System.Drawing.Size(1920, 45);
            this.PnlHeader.TabIndex = 4;
            // 
            // LblTime
            // 
            this.LblTime.BackColor = System.Drawing.Color.DimGray;
            this.LblTime.BDrawBorderBottom = false;
            this.LblTime.BDrawBorderLeft = false;
            this.LblTime.BDrawBorderRight = true;
            this.LblTime.BDrawBorderTop = false;
            this.LblTime.Dock = System.Windows.Forms.DockStyle.Left;
            this.LblTime.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTime.ForeColor = System.Drawing.Color.White;
            this.LblTime.Location = new System.Drawing.Point(1633, 0);
            this.LblTime.Name = "LblTime";
            this.LblTime.OColor = System.Drawing.Color.Black;
            this.LblTime.Size = new System.Drawing.Size(242, 45);
            this.LblTime.TabIndex = 2;
            this.LblTime.Text = "2014-10-07 11:33:20";
            this.LblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlFooter
            // 
            this.PnlFooter.BDrawBorderBottom = false;
            this.PnlFooter.BDrawBorderLeft = false;
            this.PnlFooter.BDrawBorderRight = false;
            this.PnlFooter.BDrawBorderTop = true;
            this.PnlFooter.Controls.Add(this.BtnExit);
            this.PnlFooter.Controls.Add(this.BtnHome);
            this.PnlFooter.Controls.Add(this.BtnRecipe);
            this.PnlFooter.Controls.Add(this.BtnReport);
            this.PnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlFooter.Location = new System.Drawing.Point(0, 1030);
            this.PnlFooter.Name = "PnlFooter";
            this.PnlFooter.Size = new System.Drawing.Size(1920, 50);
            this.PnlFooter.TabIndex = 3;
            // 
            // BtnRecipe
            // 
            this.BtnRecipe.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnRecipe.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.BtnRecipe.ForeColor = System.Drawing.Color.White;
            this.BtnRecipe.Location = new System.Drawing.Point(159, 3);
            this.BtnRecipe.Name = "BtnRecipe";
            this.BtnRecipe.Size = new System.Drawing.Size(150, 45);
            this.BtnRecipe.TabIndex = 0;
            this.BtnRecipe.Text = "레시피";
            this.BtnRecipe.UseVisualStyleBackColor = false;
            this.BtnRecipe.Click += new System.EventHandler(this.BtnRecipe_Click);
            // 
            // Timer1000
            // 
            this.Timer1000.Enabled = true;
            this.Timer1000.Interval = 1000;
            this.Timer1000.Tick += new System.EventHandler(this.Timer1000_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.PnlBody);
            this.Controls.Add(this.PnlHeader);
            this.Controls.Add(this.PnlFooter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Daekhon Coperation - Shamp Design Vision";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PicLogo)).EndInit();
            this.PnlHeader.ResumeLayout(false);
            this.PnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Daekhon.Control.Custom.CPanel PnlBody;
        private Daekhon.Control.Custom.CLabel LblReicpe;
        private System.Windows.Forms.Button BtnExit;
        private System.Windows.Forms.Button BtnReport;
        private System.Windows.Forms.Button BtnMinimize;
        private Daekhon.Control.Custom.CLabel LblTitle;
        private System.Windows.Forms.PictureBox PicLogo;
        private System.Windows.Forms.Button BtnHome;
        private Daekhon.Control.Custom.CPanel PnlHeader;
        private Daekhon.Control.Custom.CLabel LblTime;
        private Daekhon.Control.Custom.CPanel PnlFooter;
        private System.Windows.Forms.Timer Timer1000;
        private System.Windows.Forms.Button BtnRecipe;
    }
}

