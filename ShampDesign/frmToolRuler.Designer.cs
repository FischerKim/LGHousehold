namespace ShampDesign
{
    partial class frmToolRuler
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
            this.BtnCancel = new System.Windows.Forms.Button();
            this.PnlBody = new Daekhon.Control.Custom.CPanel();
            this.CmbIndex4 = new System.Windows.Forms.ComboBox();
            this.CmbCamera4 = new System.Windows.Forms.ComboBox();
            this.CmbIndex3 = new System.Windows.Forms.ComboBox();
            this.CmbIndex2 = new System.Windows.Forms.ComboBox();
            this.CmbCamera3 = new System.Windows.Forms.ComboBox();
            this.CmbIndex1 = new System.Windows.Forms.ComboBox();
            this.CmbCamera2 = new System.Windows.Forms.ComboBox();
            this.CmbCamera1 = new System.Windows.Forms.ComboBox();
            this.LblTitleFrontRight = new Daekhon.Control.Custom.CLabel();
            this.LblTitleFrontLeft = new Daekhon.Control.Custom.CLabel();
            this.PnlTop.SuspendLayout();
            this.PnlButton.SuspendLayout();
            this.PnlBody.SuspendLayout();
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
            this.PnlTop.Size = new System.Drawing.Size(400, 40);
            this.PnlTop.TabIndex = 4;
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitle.BDrawBorderBottom = true;
            this.LblTitle.BDrawBorderLeft = true;
            this.LblTitle.BDrawBorderRight = true;
            this.LblTitle.BDrawBorderTop = true;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitle.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(0, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.OColor = System.Drawing.Color.Black;
            this.LblTitle.Size = new System.Drawing.Size(400, 40);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "검사 규칙 정의 화면";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlButton
            // 
            this.PnlButton.BDrawBorderBottom = false;
            this.PnlButton.BDrawBorderLeft = false;
            this.PnlButton.BDrawBorderRight = false;
            this.PnlButton.BDrawBorderTop = true;
            this.PnlButton.Controls.Add(this.BtnApply);
            this.PnlButton.Controls.Add(this.BtnCancel);
            this.PnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlButton.Location = new System.Drawing.Point(0, 265);
            this.PnlButton.Name = "PnlButton";
            this.PnlButton.Size = new System.Drawing.Size(400, 50);
            this.PnlButton.TabIndex = 5;
            // 
            // BtnApply
            // 
            this.BtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnApply.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnApply.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnApply.ForeColor = System.Drawing.Color.White;
            this.BtnApply.Location = new System.Drawing.Point(91, 3);
            this.BtnApply.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(150, 45);
            this.BtnApply.TabIndex = 22;
            this.BtnApply.Text = "적용";
            this.BtnApply.UseVisualStyleBackColor = false;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnCancel.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(247, 3);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(150, 45);
            this.BtnCancel.TabIndex = 21;
            this.BtnCancel.Text = "취소";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // PnlBody
            // 
            this.PnlBody.BDrawBorderBottom = false;
            this.PnlBody.BDrawBorderLeft = false;
            this.PnlBody.BDrawBorderRight = false;
            this.PnlBody.BDrawBorderTop = true;
            this.PnlBody.Controls.Add(this.CmbIndex4);
            this.PnlBody.Controls.Add(this.CmbCamera4);
            this.PnlBody.Controls.Add(this.CmbIndex3);
            this.PnlBody.Controls.Add(this.CmbIndex2);
            this.PnlBody.Controls.Add(this.CmbCamera3);
            this.PnlBody.Controls.Add(this.CmbIndex1);
            this.PnlBody.Controls.Add(this.CmbCamera2);
            this.PnlBody.Controls.Add(this.CmbCamera1);
            this.PnlBody.Controls.Add(this.LblTitleFrontRight);
            this.PnlBody.Controls.Add(this.LblTitleFrontLeft);
            this.PnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBody.Location = new System.Drawing.Point(0, 40);
            this.PnlBody.Name = "PnlBody";
            this.PnlBody.Size = new System.Drawing.Size(400, 225);
            this.PnlBody.TabIndex = 6;
            // 
            // CmbIndex4
            // 
            this.CmbIndex4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIndex4.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.CmbIndex4.FormattingEnabled = true;
            this.CmbIndex4.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.CmbIndex4.Location = new System.Drawing.Point(5, 184);
            this.CmbIndex4.Name = "CmbIndex4";
            this.CmbIndex4.Size = new System.Drawing.Size(144, 36);
            this.CmbIndex4.TabIndex = 11;
            // 
            // CmbCamera4
            // 
            this.CmbCamera4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCamera4.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.CmbCamera4.FormattingEnabled = true;
            this.CmbCamera4.Items.AddRange(new object[] {
            "CAM 1",
            "CAM 2",
            "CAM 3",
            "CAM 4"});
            this.CmbCamera4.Location = new System.Drawing.Point(155, 184);
            this.CmbCamera4.Name = "CmbCamera4";
            this.CmbCamera4.Size = new System.Drawing.Size(240, 36);
            this.CmbCamera4.TabIndex = 11;
            // 
            // CmbIndex3
            // 
            this.CmbIndex3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIndex3.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.CmbIndex3.FormattingEnabled = true;
            this.CmbIndex3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.CmbIndex3.Location = new System.Drawing.Point(5, 139);
            this.CmbIndex3.Name = "CmbIndex3";
            this.CmbIndex3.Size = new System.Drawing.Size(144, 36);
            this.CmbIndex3.TabIndex = 11;
            // 
            // CmbIndex2
            // 
            this.CmbIndex2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIndex2.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.CmbIndex2.FormattingEnabled = true;
            this.CmbIndex2.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.CmbIndex2.Location = new System.Drawing.Point(5, 94);
            this.CmbIndex2.Name = "CmbIndex2";
            this.CmbIndex2.Size = new System.Drawing.Size(144, 36);
            this.CmbIndex2.TabIndex = 11;
            // 
            // CmbCamera3
            // 
            this.CmbCamera3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCamera3.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.CmbCamera3.FormattingEnabled = true;
            this.CmbCamera3.Items.AddRange(new object[] {
            "CAM 1",
            "CAM 2",
            "CAM 3",
            "CAM 4"});
            this.CmbCamera3.Location = new System.Drawing.Point(155, 139);
            this.CmbCamera3.Name = "CmbCamera3";
            this.CmbCamera3.Size = new System.Drawing.Size(240, 36);
            this.CmbCamera3.TabIndex = 11;
            // 
            // CmbIndex1
            // 
            this.CmbIndex1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIndex1.Enabled = false;
            this.CmbIndex1.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.CmbIndex1.FormattingEnabled = true;
            this.CmbIndex1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.CmbIndex1.Location = new System.Drawing.Point(5, 49);
            this.CmbIndex1.Name = "CmbIndex1";
            this.CmbIndex1.Size = new System.Drawing.Size(144, 36);
            this.CmbIndex1.TabIndex = 11;
            // 
            // CmbCamera2
            // 
            this.CmbCamera2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCamera2.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.CmbCamera2.FormattingEnabled = true;
            this.CmbCamera2.Items.AddRange(new object[] {
            "CAM 1",
            "CAM 2",
            "CAM 3",
            "CAM 4"});
            this.CmbCamera2.Location = new System.Drawing.Point(155, 94);
            this.CmbCamera2.Name = "CmbCamera2";
            this.CmbCamera2.Size = new System.Drawing.Size(240, 36);
            this.CmbCamera2.TabIndex = 11;
            // 
            // CmbCamera1
            // 
            this.CmbCamera1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCamera1.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.CmbCamera1.FormattingEnabled = true;
            this.CmbCamera1.Items.AddRange(new object[] {
            "CAM 1",
            "CAM 2",
            "CAM 3",
            "CAM 4"});
            this.CmbCamera1.Location = new System.Drawing.Point(155, 49);
            this.CmbCamera1.Name = "CmbCamera1";
            this.CmbCamera1.Size = new System.Drawing.Size(240, 36);
            this.CmbCamera1.TabIndex = 11;
            // 
            // LblTitleFrontRight
            // 
            this.LblTitleFrontRight.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleFrontRight.BDrawBorderBottom = true;
            this.LblTitleFrontRight.BDrawBorderLeft = false;
            this.LblTitleFrontRight.BDrawBorderRight = true;
            this.LblTitleFrontRight.BDrawBorderTop = false;
            this.LblTitleFrontRight.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleFrontRight.ForeColor = System.Drawing.Color.White;
            this.LblTitleFrontRight.Location = new System.Drawing.Point(150, 0);
            this.LblTitleFrontRight.Name = "LblTitleFrontRight";
            this.LblTitleFrontRight.OColor = System.Drawing.Color.Black;
            this.LblTitleFrontRight.Size = new System.Drawing.Size(250, 45);
            this.LblTitleFrontRight.TabIndex = 7;
            this.LblTitleFrontRight.Text = "카메라";
            this.LblTitleFrontRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleFrontLeft
            // 
            this.LblTitleFrontLeft.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleFrontLeft.BDrawBorderBottom = true;
            this.LblTitleFrontLeft.BDrawBorderLeft = true;
            this.LblTitleFrontLeft.BDrawBorderRight = true;
            this.LblTitleFrontLeft.BDrawBorderTop = false;
            this.LblTitleFrontLeft.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleFrontLeft.ForeColor = System.Drawing.Color.White;
            this.LblTitleFrontLeft.Location = new System.Drawing.Point(0, 0);
            this.LblTitleFrontLeft.Name = "LblTitleFrontLeft";
            this.LblTitleFrontLeft.OColor = System.Drawing.Color.Black;
            this.LblTitleFrontLeft.Size = new System.Drawing.Size(150, 45);
            this.LblTitleFrontLeft.TabIndex = 8;
            this.LblTitleFrontLeft.Text = "조건번호";
            this.LblTitleFrontLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmToolRuler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 315);
            this.Controls.Add(this.PnlBody);
            this.Controls.Add(this.PnlButton);
            this.Controls.Add(this.PnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmToolRuler";
            this.ShowInTaskbar = false;
            this.Text = "검사 규칙 정의 화면";
            this.Load += new System.EventHandler(this.frmToolRuler_Load);
            this.PnlTop.ResumeLayout(false);
            this.PnlButton.ResumeLayout(false);
            this.PnlBody.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Daekhon.Control.Custom.CPanel PnlTop;
        private Daekhon.Control.Custom.CLabel LblTitle;
        private Daekhon.Control.Custom.CPanel PnlButton;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.Button BtnCancel;
        private Daekhon.Control.Custom.CPanel PnlBody;
        private System.Windows.Forms.ComboBox CmbCamera4;
        private System.Windows.Forms.ComboBox CmbCamera3;
        private System.Windows.Forms.ComboBox CmbCamera2;
        private System.Windows.Forms.ComboBox CmbCamera1;
        private Daekhon.Control.Custom.CLabel LblTitleFrontRight;
        private Daekhon.Control.Custom.CLabel LblTitleFrontLeft;
        private System.Windows.Forms.ComboBox CmbIndex4;
        private System.Windows.Forms.ComboBox CmbIndex3;
        private System.Windows.Forms.ComboBox CmbIndex2;
        private System.Windows.Forms.ComboBox CmbIndex1;
    }
}