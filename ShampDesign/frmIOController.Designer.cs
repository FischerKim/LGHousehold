namespace ShampDesign
{
    partial class frmIOController
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PnlTop = new Daekhon.Control.Custom.CPanel();
            this.LblTitle = new Daekhon.Control.Custom.CLabel();
            this.PnlButton = new Daekhon.Control.Custom.CPanel();
            this.BtnApply = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.PnlBody = new Daekhon.Control.Custom.CPanel();
            this.PnlLeft = new Daekhon.Control.Custom.CPanel();
            this.PnlRight = new Daekhon.Control.Custom.CPanel();
            this.LblTitleReady = new Daekhon.Control.Custom.CLabel();
            this.LblTitleNG = new Daekhon.Control.Custom.CLabel();
            this.LblTitleReadyOnInterval = new Daekhon.Control.Custom.CLabel();
            this.LblTitleReadyOffInterval = new Daekhon.Control.Custom.CLabel();
            this.LblTitleReadyPort = new Daekhon.Control.Custom.CLabel();
            this.LblTitleNGPort = new Daekhon.Control.Custom.CLabel();
            this.LblTitleNGOffInterval = new Daekhon.Control.Custom.CLabel();
            this.NudReadyPort = new System.Windows.Forms.NumericUpDown();
            this.NudReadyOnInterval = new System.Windows.Forms.NumericUpDown();
            this.NudReadyOffInterval = new System.Windows.Forms.NumericUpDown();
            this.NudNGPort = new System.Windows.Forms.NumericUpDown();
            this.NudNGOffInterval = new System.Windows.Forms.NumericUpDown();
            this.PnlTop.SuspendLayout();
            this.PnlButton.SuspendLayout();
            this.PnlBody.SuspendLayout();
            this.PnlLeft.SuspendLayout();
            this.PnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudReadyPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudReadyOnInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudReadyOffInterval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudNGPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudNGOffInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.BDrawBorderBottom = false;
            this.PnlTop.BDrawBorderLeft = false;
            this.PnlTop.BDrawBorderRight = false;
            this.PnlTop.BDrawBorderTop = false;
            this.PnlTop.Controls.Add(this.LblTitle);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(500, 40);
            this.PnlTop.TabIndex = 5;
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitle.BDrawBorderBottom = true;
            this.LblTitle.BDrawBorderLeft = false;
            this.LblTitle.BDrawBorderRight = false;
            this.LblTitle.BDrawBorderTop = true;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitle.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(0, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.OColor = System.Drawing.Color.Black;
            this.LblTitle.Size = new System.Drawing.Size(500, 40);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "IO Controller";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlButton
            // 
            this.PnlButton.BDrawBorderBottom = false;
            this.PnlButton.BDrawBorderLeft = false;
            this.PnlButton.BDrawBorderRight = false;
            this.PnlButton.BDrawBorderTop = true;
            this.PnlButton.Controls.Add(this.BtnApply);
            this.PnlButton.Controls.Add(this.BtnClose);
            this.PnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlButton.Location = new System.Drawing.Point(0, 200);
            this.PnlButton.Name = "PnlButton";
            this.PnlButton.Size = new System.Drawing.Size(500, 50);
            this.PnlButton.TabIndex = 6;
            // 
            // BtnApply
            // 
            this.BtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnApply.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnApply.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.BtnApply.ForeColor = System.Drawing.Color.White;
            this.BtnApply.Location = new System.Drawing.Point(192, 2);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(150, 45);
            this.BtnApply.TabIndex = 8;
            this.BtnApply.Text = "적용";
            this.BtnApply.UseVisualStyleBackColor = false;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnClose.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.BtnClose.ForeColor = System.Drawing.Color.White;
            this.BtnClose.Location = new System.Drawing.Point(348, 2);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(150, 45);
            this.BtnClose.TabIndex = 7;
            this.BtnClose.Text = "닫기";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // PnlBody
            // 
            this.PnlBody.BDrawBorderBottom = false;
            this.PnlBody.BDrawBorderLeft = false;
            this.PnlBody.BDrawBorderRight = false;
            this.PnlBody.BDrawBorderTop = false;
            this.PnlBody.Controls.Add(this.PnlRight);
            this.PnlBody.Controls.Add(this.PnlLeft);
            this.PnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBody.Location = new System.Drawing.Point(0, 40);
            this.PnlBody.Name = "PnlBody";
            this.PnlBody.Size = new System.Drawing.Size(500, 160);
            this.PnlBody.TabIndex = 7;
            // 
            // PnlLeft
            // 
            this.PnlLeft.BDrawBorderBottom = false;
            this.PnlLeft.BDrawBorderLeft = false;
            this.PnlLeft.BDrawBorderRight = false;
            this.PnlLeft.BDrawBorderTop = false;
            this.PnlLeft.Controls.Add(this.NudReadyOffInterval);
            this.PnlLeft.Controls.Add(this.NudReadyOnInterval);
            this.PnlLeft.Controls.Add(this.NudReadyPort);
            this.PnlLeft.Controls.Add(this.LblTitleReadyOffInterval);
            this.PnlLeft.Controls.Add(this.LblTitleReadyPort);
            this.PnlLeft.Controls.Add(this.LblTitleReadyOnInterval);
            this.PnlLeft.Controls.Add(this.LblTitleReady);
            this.PnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlLeft.Location = new System.Drawing.Point(0, 0);
            this.PnlLeft.Name = "PnlLeft";
            this.PnlLeft.Size = new System.Drawing.Size(250, 160);
            this.PnlLeft.TabIndex = 8;
            // 
            // PnlRight
            // 
            this.PnlRight.BDrawBorderBottom = false;
            this.PnlRight.BDrawBorderLeft = false;
            this.PnlRight.BDrawBorderRight = false;
            this.PnlRight.BDrawBorderTop = false;
            this.PnlRight.Controls.Add(this.NudNGOffInterval);
            this.PnlRight.Controls.Add(this.NudNGPort);
            this.PnlRight.Controls.Add(this.LblTitleNGOffInterval);
            this.PnlRight.Controls.Add(this.LblTitleNG);
            this.PnlRight.Controls.Add(this.LblTitleNGPort);
            this.PnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlRight.Location = new System.Drawing.Point(250, 0);
            this.PnlRight.Name = "PnlRight";
            this.PnlRight.Size = new System.Drawing.Size(250, 160);
            this.PnlRight.TabIndex = 9;
            // 
            // LblTitleReady
            // 
            this.LblTitleReady.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleReady.BDrawBorderBottom = false;
            this.LblTitleReady.BDrawBorderLeft = true;
            this.LblTitleReady.BDrawBorderRight = false;
            this.LblTitleReady.BDrawBorderTop = false;
            this.LblTitleReady.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleReady.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleReady.ForeColor = System.Drawing.Color.White;
            this.LblTitleReady.Location = new System.Drawing.Point(0, 0);
            this.LblTitleReady.Name = "LblTitleReady";
            this.LblTitleReady.OColor = System.Drawing.Color.Black;
            this.LblTitleReady.Size = new System.Drawing.Size(250, 40);
            this.LblTitleReady.TabIndex = 10;
            this.LblTitleReady.Text = "Ready 신호";
            this.LblTitleReady.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleNG
            // 
            this.LblTitleNG.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleNG.BDrawBorderBottom = false;
            this.LblTitleNG.BDrawBorderLeft = true;
            this.LblTitleNG.BDrawBorderRight = false;
            this.LblTitleNG.BDrawBorderTop = false;
            this.LblTitleNG.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleNG.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleNG.ForeColor = System.Drawing.Color.White;
            this.LblTitleNG.Location = new System.Drawing.Point(0, 0);
            this.LblTitleNG.Name = "LblTitleNG";
            this.LblTitleNG.OColor = System.Drawing.Color.Black;
            this.LblTitleNG.Size = new System.Drawing.Size(250, 40);
            this.LblTitleNG.TabIndex = 10;
            this.LblTitleNG.Text = "NG 신호";
            this.LblTitleNG.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleReadyOnInterval
            // 
            this.LblTitleReadyOnInterval.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleReadyOnInterval.BDrawBorderBottom = false;
            this.LblTitleReadyOnInterval.BDrawBorderLeft = true;
            this.LblTitleReadyOnInterval.BDrawBorderRight = true;
            this.LblTitleReadyOnInterval.BDrawBorderTop = true;
            this.LblTitleReadyOnInterval.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleReadyOnInterval.ForeColor = System.Drawing.Color.White;
            this.LblTitleReadyOnInterval.Location = new System.Drawing.Point(0, 80);
            this.LblTitleReadyOnInterval.Name = "LblTitleReadyOnInterval";
            this.LblTitleReadyOnInterval.OColor = System.Drawing.Color.Black;
            this.LblTitleReadyOnInterval.Size = new System.Drawing.Size(120, 40);
            this.LblTitleReadyOnInterval.TabIndex = 11;
            this.LblTitleReadyOnInterval.Text = "켬 간격(ms)";
            this.LblTitleReadyOnInterval.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleReadyOffInterval
            // 
            this.LblTitleReadyOffInterval.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleReadyOffInterval.BDrawBorderBottom = false;
            this.LblTitleReadyOffInterval.BDrawBorderLeft = true;
            this.LblTitleReadyOffInterval.BDrawBorderRight = true;
            this.LblTitleReadyOffInterval.BDrawBorderTop = true;
            this.LblTitleReadyOffInterval.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleReadyOffInterval.ForeColor = System.Drawing.Color.White;
            this.LblTitleReadyOffInterval.Location = new System.Drawing.Point(0, 120);
            this.LblTitleReadyOffInterval.Name = "LblTitleReadyOffInterval";
            this.LblTitleReadyOffInterval.OColor = System.Drawing.Color.Black;
            this.LblTitleReadyOffInterval.Size = new System.Drawing.Size(120, 40);
            this.LblTitleReadyOffInterval.TabIndex = 11;
            this.LblTitleReadyOffInterval.Text = "끔 간격(ms)";
            this.LblTitleReadyOffInterval.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleReadyPort
            // 
            this.LblTitleReadyPort.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleReadyPort.BDrawBorderBottom = false;
            this.LblTitleReadyPort.BDrawBorderLeft = true;
            this.LblTitleReadyPort.BDrawBorderRight = true;
            this.LblTitleReadyPort.BDrawBorderTop = true;
            this.LblTitleReadyPort.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleReadyPort.ForeColor = System.Drawing.Color.White;
            this.LblTitleReadyPort.Location = new System.Drawing.Point(0, 40);
            this.LblTitleReadyPort.Name = "LblTitleReadyPort";
            this.LblTitleReadyPort.OColor = System.Drawing.Color.Black;
            this.LblTitleReadyPort.Size = new System.Drawing.Size(120, 40);
            this.LblTitleReadyPort.TabIndex = 11;
            this.LblTitleReadyPort.Text = "포트";
            this.LblTitleReadyPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleNGPort
            // 
            this.LblTitleNGPort.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleNGPort.BDrawBorderBottom = false;
            this.LblTitleNGPort.BDrawBorderLeft = true;
            this.LblTitleNGPort.BDrawBorderRight = true;
            this.LblTitleNGPort.BDrawBorderTop = true;
            this.LblTitleNGPort.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleNGPort.ForeColor = System.Drawing.Color.White;
            this.LblTitleNGPort.Location = new System.Drawing.Point(0, 40);
            this.LblTitleNGPort.Name = "LblTitleNGPort";
            this.LblTitleNGPort.OColor = System.Drawing.Color.Black;
            this.LblTitleNGPort.Size = new System.Drawing.Size(120, 40);
            this.LblTitleNGPort.TabIndex = 11;
            this.LblTitleNGPort.Text = "포트";
            this.LblTitleNGPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleNGOffInterval
            // 
            this.LblTitleNGOffInterval.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleNGOffInterval.BDrawBorderBottom = true;
            this.LblTitleNGOffInterval.BDrawBorderLeft = true;
            this.LblTitleNGOffInterval.BDrawBorderRight = true;
            this.LblTitleNGOffInterval.BDrawBorderTop = true;
            this.LblTitleNGOffInterval.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleNGOffInterval.ForeColor = System.Drawing.Color.White;
            this.LblTitleNGOffInterval.Location = new System.Drawing.Point(0, 80);
            this.LblTitleNGOffInterval.Name = "LblTitleNGOffInterval";
            this.LblTitleNGOffInterval.OColor = System.Drawing.Color.Black;
            this.LblTitleNGOffInterval.Size = new System.Drawing.Size(120, 40);
            this.LblTitleNGOffInterval.TabIndex = 11;
            this.LblTitleNGOffInterval.Text = "끔 간격(ms)";
            this.LblTitleNGOffInterval.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NudReadyPort
            // 
            this.NudReadyPort.BackColor = System.Drawing.Color.White;
            this.NudReadyPort.Font = new System.Drawing.Font("맑은 고딕", 15.75F);
            this.NudReadyPort.ForeColor = System.Drawing.Color.Black;
            this.NudReadyPort.Location = new System.Drawing.Point(126, 43);
            this.NudReadyPort.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudReadyPort.Name = "NudReadyPort";
            this.NudReadyPort.Size = new System.Drawing.Size(118, 35);
            this.NudReadyPort.TabIndex = 32;
            this.NudReadyPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudReadyPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudReadyOnInterval
            // 
            this.NudReadyOnInterval.BackColor = System.Drawing.Color.White;
            this.NudReadyOnInterval.Font = new System.Drawing.Font("맑은 고딕", 15.75F);
            this.NudReadyOnInterval.ForeColor = System.Drawing.Color.Black;
            this.NudReadyOnInterval.Location = new System.Drawing.Point(126, 83);
            this.NudReadyOnInterval.Maximum = new decimal(new int[] {
            180000,
            0,
            0,
            0});
            this.NudReadyOnInterval.Name = "NudReadyOnInterval";
            this.NudReadyOnInterval.Size = new System.Drawing.Size(118, 35);
            this.NudReadyOnInterval.TabIndex = 32;
            this.NudReadyOnInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudReadyOnInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudReadyOffInterval
            // 
            this.NudReadyOffInterval.BackColor = System.Drawing.Color.White;
            this.NudReadyOffInterval.Font = new System.Drawing.Font("맑은 고딕", 15.75F);
            this.NudReadyOffInterval.ForeColor = System.Drawing.Color.Black;
            this.NudReadyOffInterval.Location = new System.Drawing.Point(126, 123);
            this.NudReadyOffInterval.Maximum = new decimal(new int[] {
            180000,
            0,
            0,
            0});
            this.NudReadyOffInterval.Name = "NudReadyOffInterval";
            this.NudReadyOffInterval.Size = new System.Drawing.Size(118, 35);
            this.NudReadyOffInterval.TabIndex = 32;
            this.NudReadyOffInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudReadyOffInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudNGPort
            // 
            this.NudNGPort.BackColor = System.Drawing.Color.White;
            this.NudNGPort.Font = new System.Drawing.Font("맑은 고딕", 15.75F);
            this.NudNGPort.ForeColor = System.Drawing.Color.Black;
            this.NudNGPort.Location = new System.Drawing.Point(126, 43);
            this.NudNGPort.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudNGPort.Name = "NudNGPort";
            this.NudNGPort.Size = new System.Drawing.Size(118, 35);
            this.NudNGPort.TabIndex = 32;
            this.NudNGPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudNGPort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudNGOffInterval
            // 
            this.NudNGOffInterval.BackColor = System.Drawing.Color.White;
            this.NudNGOffInterval.Font = new System.Drawing.Font("맑은 고딕", 15.75F);
            this.NudNGOffInterval.ForeColor = System.Drawing.Color.Black;
            this.NudNGOffInterval.Location = new System.Drawing.Point(126, 83);
            this.NudNGOffInterval.Maximum = new decimal(new int[] {
            180000,
            0,
            0,
            0});
            this.NudNGOffInterval.Name = "NudNGOffInterval";
            this.NudNGOffInterval.Size = new System.Drawing.Size(118, 35);
            this.NudNGOffInterval.TabIndex = 32;
            this.NudNGOffInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudNGOffInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // frmIOController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 250);
            this.Controls.Add(this.PnlBody);
            this.Controls.Add(this.PnlButton);
            this.Controls.Add(this.PnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIOController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "IO Controller";
            this.Load += new System.EventHandler(this.frmIOController_Load);
            this.PnlTop.ResumeLayout(false);
            this.PnlButton.ResumeLayout(false);
            this.PnlBody.ResumeLayout(false);
            this.PnlLeft.ResumeLayout(false);
            this.PnlRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NudReadyPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudReadyOnInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudReadyOffInterval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudNGPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudNGOffInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Daekhon.Control.Custom.CPanel PnlTop;
        private Daekhon.Control.Custom.CLabel LblTitle;
        private Daekhon.Control.Custom.CPanel PnlButton;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.Button BtnClose;
        private Daekhon.Control.Custom.CPanel PnlBody;
        private Daekhon.Control.Custom.CPanel PnlRight;
        private Daekhon.Control.Custom.CPanel PnlLeft;
        private Daekhon.Control.Custom.CLabel LblTitleNGOffInterval;
        private Daekhon.Control.Custom.CLabel LblTitleNG;
        private Daekhon.Control.Custom.CLabel LblTitleNGPort;
        private Daekhon.Control.Custom.CLabel LblTitleReadyOffInterval;
        private Daekhon.Control.Custom.CLabel LblTitleReadyPort;
        private Daekhon.Control.Custom.CLabel LblTitleReadyOnInterval;
        private Daekhon.Control.Custom.CLabel LblTitleReady;
        private System.Windows.Forms.NumericUpDown NudNGOffInterval;
        private System.Windows.Forms.NumericUpDown NudNGPort;
        private System.Windows.Forms.NumericUpDown NudReadyOffInterval;
        private System.Windows.Forms.NumericUpDown NudReadyOnInterval;
        private System.Windows.Forms.NumericUpDown NudReadyPort;
    }
}