namespace ShampDesign
{
    partial class frmCameraSelector
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlTop = new Daekhon.Control.Custom.CPanel();
            this.LblTitleCamSelector = new Daekhon.Control.Custom.CLabel();
            this.PnlMiddleTop = new Daekhon.Control.Custom.CPanel();
            this.LblBackRight = new Daekhon.Control.Custom.CLabel();
            this.LblBackLeft = new Daekhon.Control.Custom.CLabel();
            this.LblFrontRight = new Daekhon.Control.Custom.CLabel();
            this.LblTitleBackRight = new Daekhon.Control.Custom.CLabel();
            this.LblFrontLeft = new Daekhon.Control.Custom.CLabel();
            this.LblTitleBackLeft = new Daekhon.Control.Custom.CLabel();
            this.LblTitleFrontRight = new Daekhon.Control.Custom.CLabel();
            this.BtnSelectBackRight = new System.Windows.Forms.Button();
            this.LblTitleFrontLeft = new Daekhon.Control.Custom.CLabel();
            this.BtnSelectBackLeft = new System.Windows.Forms.Button();
            this.BtnSelectFrontRight = new System.Windows.Forms.Button();
            this.BtnSelectFrontLeft = new System.Windows.Forms.Button();
            this.LblTitleCamSelection = new Daekhon.Control.Custom.CLabel();
            this.PnlButton = new Daekhon.Control.Custom.CPanel();
            this.BtnApply = new System.Windows.Forms.Button();
            this.BtnClose = new System.Windows.Forms.Button();
            this.PnlMiddleBottom = new Daekhon.Control.Custom.CPanel();
            this.DgvCamList = new System.Windows.Forms.DataGridView();
            this.LblTitleCamList = new Daekhon.Control.Custom.CLabel();
            this.ColCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PnlTop.SuspendLayout();
            this.PnlMiddleTop.SuspendLayout();
            this.PnlButton.SuspendLayout();
            this.PnlMiddleBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCamList)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.BDrawBorderBottom = false;
            this.PnlTop.BDrawBorderLeft = false;
            this.PnlTop.BDrawBorderRight = false;
            this.PnlTop.BDrawBorderTop = false;
            this.PnlTop.Controls.Add(this.LblTitleCamSelector);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(519, 40);
            this.PnlTop.TabIndex = 3;
            // 
            // LblTitleCamSelector
            // 
            this.LblTitleCamSelector.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitleCamSelector.BDrawBorderBottom = true;
            this.LblTitleCamSelector.BDrawBorderLeft = false;
            this.LblTitleCamSelector.BDrawBorderRight = false;
            this.LblTitleCamSelector.BDrawBorderTop = false;
            this.LblTitleCamSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitleCamSelector.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleCamSelector.ForeColor = System.Drawing.Color.White;
            this.LblTitleCamSelector.Location = new System.Drawing.Point(0, 0);
            this.LblTitleCamSelector.Name = "LblTitleCamSelector";
            this.LblTitleCamSelector.OColor = System.Drawing.Color.Black;
            this.LblTitleCamSelector.Size = new System.Drawing.Size(519, 40);
            this.LblTitleCamSelector.TabIndex = 0;
            this.LblTitleCamSelector.Text = "카메라 설정 화면";
            this.LblTitleCamSelector.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlMiddleTop
            // 
            this.PnlMiddleTop.BDrawBorderBottom = false;
            this.PnlMiddleTop.BDrawBorderLeft = true;
            this.PnlMiddleTop.BDrawBorderRight = false;
            this.PnlMiddleTop.BDrawBorderTop = false;
            this.PnlMiddleTop.Controls.Add(this.LblBackRight);
            this.PnlMiddleTop.Controls.Add(this.LblBackLeft);
            this.PnlMiddleTop.Controls.Add(this.LblFrontRight);
            this.PnlMiddleTop.Controls.Add(this.LblTitleBackRight);
            this.PnlMiddleTop.Controls.Add(this.LblFrontLeft);
            this.PnlMiddleTop.Controls.Add(this.LblTitleBackLeft);
            this.PnlMiddleTop.Controls.Add(this.LblTitleFrontRight);
            this.PnlMiddleTop.Controls.Add(this.BtnSelectBackRight);
            this.PnlMiddleTop.Controls.Add(this.LblTitleFrontLeft);
            this.PnlMiddleTop.Controls.Add(this.BtnSelectBackLeft);
            this.PnlMiddleTop.Controls.Add(this.BtnSelectFrontRight);
            this.PnlMiddleTop.Controls.Add(this.BtnSelectFrontLeft);
            this.PnlMiddleTop.Controls.Add(this.LblTitleCamSelection);
            this.PnlMiddleTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlMiddleTop.Location = new System.Drawing.Point(0, 40);
            this.PnlMiddleTop.Name = "PnlMiddleTop";
            this.PnlMiddleTop.Size = new System.Drawing.Size(519, 220);
            this.PnlMiddleTop.TabIndex = 6;
            // 
            // LblBackRight
            // 
            this.LblBackRight.BackColor = System.Drawing.Color.White;
            this.LblBackRight.BDrawBorderBottom = false;
            this.LblBackRight.BDrawBorderLeft = false;
            this.LblBackRight.BDrawBorderRight = true;
            this.LblBackRight.BDrawBorderTop = false;
            this.LblBackRight.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblBackRight.ForeColor = System.Drawing.Color.Black;
            this.LblBackRight.Location = new System.Drawing.Point(159, 175);
            this.LblBackRight.Name = "LblBackRight";
            this.LblBackRight.OColor = System.Drawing.Color.Black;
            this.LblBackRight.Size = new System.Drawing.Size(200, 45);
            this.LblBackRight.TabIndex = 7;
            this.LblBackRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblBackLeft
            // 
            this.LblBackLeft.BackColor = System.Drawing.Color.White;
            this.LblBackLeft.BDrawBorderBottom = true;
            this.LblBackLeft.BDrawBorderLeft = false;
            this.LblBackLeft.BDrawBorderRight = true;
            this.LblBackLeft.BDrawBorderTop = false;
            this.LblBackLeft.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblBackLeft.ForeColor = System.Drawing.Color.Black;
            this.LblBackLeft.Location = new System.Drawing.Point(159, 130);
            this.LblBackLeft.Name = "LblBackLeft";
            this.LblBackLeft.OColor = System.Drawing.Color.Black;
            this.LblBackLeft.Size = new System.Drawing.Size(200, 45);
            this.LblBackLeft.TabIndex = 7;
            this.LblBackLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblFrontRight
            // 
            this.LblFrontRight.BackColor = System.Drawing.Color.White;
            this.LblFrontRight.BDrawBorderBottom = true;
            this.LblFrontRight.BDrawBorderLeft = false;
            this.LblFrontRight.BDrawBorderRight = true;
            this.LblFrontRight.BDrawBorderTop = false;
            this.LblFrontRight.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblFrontRight.ForeColor = System.Drawing.Color.Black;
            this.LblFrontRight.Location = new System.Drawing.Point(159, 85);
            this.LblFrontRight.Name = "LblFrontRight";
            this.LblFrontRight.OColor = System.Drawing.Color.Black;
            this.LblFrontRight.Size = new System.Drawing.Size(200, 45);
            this.LblFrontRight.TabIndex = 7;
            this.LblFrontRight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleBackRight
            // 
            this.LblTitleBackRight.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleBackRight.BDrawBorderBottom = false;
            this.LblTitleBackRight.BDrawBorderLeft = false;
            this.LblTitleBackRight.BDrawBorderRight = true;
            this.LblTitleBackRight.BDrawBorderTop = false;
            this.LblTitleBackRight.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleBackRight.ForeColor = System.Drawing.Color.White;
            this.LblTitleBackRight.Location = new System.Drawing.Point(0, 175);
            this.LblTitleBackRight.Name = "LblTitleBackRight";
            this.LblTitleBackRight.OColor = System.Drawing.Color.Black;
            this.LblTitleBackRight.Size = new System.Drawing.Size(159, 45);
            this.LblTitleBackRight.TabIndex = 6;
            this.LblTitleBackRight.Text = "4";
            this.LblTitleBackRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblFrontLeft
            // 
            this.LblFrontLeft.BackColor = System.Drawing.Color.White;
            this.LblFrontLeft.BDrawBorderBottom = true;
            this.LblFrontLeft.BDrawBorderLeft = false;
            this.LblFrontLeft.BDrawBorderRight = true;
            this.LblFrontLeft.BDrawBorderTop = false;
            this.LblFrontLeft.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblFrontLeft.ForeColor = System.Drawing.Color.Black;
            this.LblFrontLeft.Location = new System.Drawing.Point(159, 40);
            this.LblFrontLeft.Name = "LblFrontLeft";
            this.LblFrontLeft.OColor = System.Drawing.Color.Black;
            this.LblFrontLeft.Size = new System.Drawing.Size(200, 45);
            this.LblFrontLeft.TabIndex = 7;
            this.LblFrontLeft.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleBackLeft
            // 
            this.LblTitleBackLeft.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleBackLeft.BDrawBorderBottom = true;
            this.LblTitleBackLeft.BDrawBorderLeft = false;
            this.LblTitleBackLeft.BDrawBorderRight = true;
            this.LblTitleBackLeft.BDrawBorderTop = false;
            this.LblTitleBackLeft.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleBackLeft.ForeColor = System.Drawing.Color.White;
            this.LblTitleBackLeft.Location = new System.Drawing.Point(0, 130);
            this.LblTitleBackLeft.Name = "LblTitleBackLeft";
            this.LblTitleBackLeft.OColor = System.Drawing.Color.Black;
            this.LblTitleBackLeft.Size = new System.Drawing.Size(159, 45);
            this.LblTitleBackLeft.TabIndex = 6;
            this.LblTitleBackLeft.Text = "3";
            this.LblTitleBackLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.LblTitleFrontRight.Location = new System.Drawing.Point(0, 85);
            this.LblTitleFrontRight.Name = "LblTitleFrontRight";
            this.LblTitleFrontRight.OColor = System.Drawing.Color.Black;
            this.LblTitleFrontRight.Size = new System.Drawing.Size(159, 45);
            this.LblTitleFrontRight.TabIndex = 6;
            this.LblTitleFrontRight.Text = "2";
            this.LblTitleFrontRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSelectBackRight
            // 
            this.BtnSelectBackRight.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSelectBackRight.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.BtnSelectBackRight.ForeColor = System.Drawing.Color.White;
            this.BtnSelectBackRight.Location = new System.Drawing.Point(365, 175);
            this.BtnSelectBackRight.Name = "BtnSelectBackRight";
            this.BtnSelectBackRight.Size = new System.Drawing.Size(150, 45);
            this.BtnSelectBackRight.TabIndex = 5;
            this.BtnSelectBackRight.Tag = "BACK_RIGHT";
            this.BtnSelectBackRight.Text = "선택";
            this.BtnSelectBackRight.UseVisualStyleBackColor = false;
            this.BtnSelectBackRight.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // LblTitleFrontLeft
            // 
            this.LblTitleFrontLeft.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleFrontLeft.BDrawBorderBottom = true;
            this.LblTitleFrontLeft.BDrawBorderLeft = false;
            this.LblTitleFrontLeft.BDrawBorderRight = true;
            this.LblTitleFrontLeft.BDrawBorderTop = false;
            this.LblTitleFrontLeft.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleFrontLeft.ForeColor = System.Drawing.Color.White;
            this.LblTitleFrontLeft.Location = new System.Drawing.Point(0, 40);
            this.LblTitleFrontLeft.Name = "LblTitleFrontLeft";
            this.LblTitleFrontLeft.OColor = System.Drawing.Color.Black;
            this.LblTitleFrontLeft.Size = new System.Drawing.Size(159, 45);
            this.LblTitleFrontLeft.TabIndex = 6;
            this.LblTitleFrontLeft.Text = "1";
            this.LblTitleFrontLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnSelectBackLeft
            // 
            this.BtnSelectBackLeft.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSelectBackLeft.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.BtnSelectBackLeft.ForeColor = System.Drawing.Color.White;
            this.BtnSelectBackLeft.Location = new System.Drawing.Point(365, 130);
            this.BtnSelectBackLeft.Name = "BtnSelectBackLeft";
            this.BtnSelectBackLeft.Size = new System.Drawing.Size(150, 45);
            this.BtnSelectBackLeft.TabIndex = 5;
            this.BtnSelectBackLeft.Tag = "BACK_LEFT";
            this.BtnSelectBackLeft.Text = "선택";
            this.BtnSelectBackLeft.UseVisualStyleBackColor = false;
            this.BtnSelectBackLeft.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // BtnSelectFrontRight
            // 
            this.BtnSelectFrontRight.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSelectFrontRight.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.BtnSelectFrontRight.ForeColor = System.Drawing.Color.White;
            this.BtnSelectFrontRight.Location = new System.Drawing.Point(365, 85);
            this.BtnSelectFrontRight.Name = "BtnSelectFrontRight";
            this.BtnSelectFrontRight.Size = new System.Drawing.Size(150, 45);
            this.BtnSelectFrontRight.TabIndex = 5;
            this.BtnSelectFrontRight.Tag = "FRONT_RIGHT";
            this.BtnSelectFrontRight.Text = "선택";
            this.BtnSelectFrontRight.UseVisualStyleBackColor = false;
            this.BtnSelectFrontRight.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // BtnSelectFrontLeft
            // 
            this.BtnSelectFrontLeft.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSelectFrontLeft.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.BtnSelectFrontLeft.ForeColor = System.Drawing.Color.White;
            this.BtnSelectFrontLeft.Location = new System.Drawing.Point(365, 40);
            this.BtnSelectFrontLeft.Name = "BtnSelectFrontLeft";
            this.BtnSelectFrontLeft.Size = new System.Drawing.Size(150, 45);
            this.BtnSelectFrontLeft.TabIndex = 5;
            this.BtnSelectFrontLeft.Tag = "FRONT_LEFT";
            this.BtnSelectFrontLeft.Text = "선택";
            this.BtnSelectFrontLeft.UseVisualStyleBackColor = false;
            this.BtnSelectFrontLeft.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // LblTitleCamSelection
            // 
            this.LblTitleCamSelection.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleCamSelection.BDrawBorderBottom = true;
            this.LblTitleCamSelection.BDrawBorderLeft = false;
            this.LblTitleCamSelection.BDrawBorderRight = false;
            this.LblTitleCamSelection.BDrawBorderTop = false;
            this.LblTitleCamSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleCamSelection.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleCamSelection.ForeColor = System.Drawing.Color.White;
            this.LblTitleCamSelection.Location = new System.Drawing.Point(0, 0);
            this.LblTitleCamSelection.Name = "LblTitleCamSelection";
            this.LblTitleCamSelection.OColor = System.Drawing.Color.Black;
            this.LblTitleCamSelection.Size = new System.Drawing.Size(519, 40);
            this.LblTitleCamSelection.TabIndex = 4;
            this.LblTitleCamSelection.Text = "카메라 선택";
            this.LblTitleCamSelection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.PnlButton.Location = new System.Drawing.Point(0, 557);
            this.PnlButton.Name = "PnlButton";
            this.PnlButton.Size = new System.Drawing.Size(519, 50);
            this.PnlButton.TabIndex = 7;
            // 
            // BtnApply
            // 
            this.BtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnApply.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnApply.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.BtnApply.ForeColor = System.Drawing.Color.White;
            this.BtnApply.Location = new System.Drawing.Point(209, 3);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(150, 45);
            this.BtnApply.TabIndex = 4;
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
            this.BtnClose.Location = new System.Drawing.Point(365, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(150, 45);
            this.BtnClose.TabIndex = 4;
            this.BtnClose.Text = "닫기";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // PnlMiddleBottom
            // 
            this.PnlMiddleBottom.BDrawBorderBottom = false;
            this.PnlMiddleBottom.BDrawBorderLeft = false;
            this.PnlMiddleBottom.BDrawBorderRight = false;
            this.PnlMiddleBottom.BDrawBorderTop = false;
            this.PnlMiddleBottom.Controls.Add(this.DgvCamList);
            this.PnlMiddleBottom.Controls.Add(this.LblTitleCamList);
            this.PnlMiddleBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMiddleBottom.Location = new System.Drawing.Point(0, 260);
            this.PnlMiddleBottom.Name = "PnlMiddleBottom";
            this.PnlMiddleBottom.Size = new System.Drawing.Size(519, 297);
            this.PnlMiddleBottom.TabIndex = 8;
            // 
            // DgvCamList
            // 
            this.DgvCamList.AllowUserToAddRows = false;
            this.DgvCamList.AllowUserToDeleteRows = false;
            this.DgvCamList.AllowUserToResizeColumns = false;
            this.DgvCamList.AllowUserToResizeRows = false;
            this.DgvCamList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvCamList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvCamList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DgvCamList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvCamList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCamList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCompany,
            this.ColModel,
            this.ColIP,
            this.ColSerial,
            this.ColKey});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCamList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvCamList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCamList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgvCamList.Location = new System.Drawing.Point(0, 40);
            this.DgvCamList.MultiSelect = false;
            this.DgvCamList.Name = "DgvCamList";
            this.DgvCamList.RowHeadersVisible = false;
            this.DgvCamList.RowTemplate.Height = 23;
            this.DgvCamList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCamList.Size = new System.Drawing.Size(519, 257);
            this.DgvCamList.TabIndex = 4;
            // 
            // LblTitleCamList
            // 
            this.LblTitleCamList.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleCamList.BDrawBorderBottom = false;
            this.LblTitleCamList.BDrawBorderLeft = false;
            this.LblTitleCamList.BDrawBorderRight = false;
            this.LblTitleCamList.BDrawBorderTop = true;
            this.LblTitleCamList.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleCamList.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleCamList.ForeColor = System.Drawing.Color.White;
            this.LblTitleCamList.Location = new System.Drawing.Point(0, 0);
            this.LblTitleCamList.Name = "LblTitleCamList";
            this.LblTitleCamList.OColor = System.Drawing.Color.Black;
            this.LblTitleCamList.Size = new System.Drawing.Size(519, 40);
            this.LblTitleCamList.TabIndex = 3;
            this.LblTitleCamList.Text = "카메라 목록";
            this.LblTitleCamList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ColCompany
            // 
            this.ColCompany.DataPropertyName = "COMPANY";
            this.ColCompany.HeaderText = "Company";
            this.ColCompany.Name = "ColCompany";
            this.ColCompany.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCompany.Visible = false;
            // 
            // ColModel
            // 
            this.ColModel.DataPropertyName = "MODEL";
            this.ColModel.HeaderText = "모델";
            this.ColModel.Name = "ColModel";
            this.ColModel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColIP
            // 
            this.ColIP.DataPropertyName = "IP";
            this.ColIP.HeaderText = "IP";
            this.ColIP.Name = "ColIP";
            this.ColIP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColSerial
            // 
            this.ColSerial.DataPropertyName = "SERIAL";
            this.ColSerial.HeaderText = "시리얼번호";
            this.ColSerial.Name = "ColSerial";
            this.ColSerial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColKey
            // 
            this.ColKey.DataPropertyName = "KEY";
            this.ColKey.HeaderText = "KEY";
            this.ColKey.Name = "ColKey";
            this.ColKey.Visible = false;
            // 
            // frmCameraSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 607);
            this.Controls.Add(this.PnlMiddleBottom);
            this.Controls.Add(this.PnlButton);
            this.Controls.Add(this.PnlMiddleTop);
            this.Controls.Add(this.PnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCameraSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "카메라 설정 화면";
            this.Load += new System.EventHandler(this.frmCameraSelector_Load);
            this.PnlTop.ResumeLayout(false);
            this.PnlMiddleTop.ResumeLayout(false);
            this.PnlButton.ResumeLayout(false);
            this.PnlMiddleBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCamList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Daekhon.Control.Custom.CPanel PnlTop;
        private Daekhon.Control.Custom.CLabel LblTitleCamSelector;
        private Daekhon.Control.Custom.CPanel PnlMiddleTop;
        private Daekhon.Control.Custom.CLabel LblBackRight;
        private Daekhon.Control.Custom.CLabel LblBackLeft;
        private Daekhon.Control.Custom.CLabel LblFrontRight;
        private Daekhon.Control.Custom.CLabel LblTitleBackRight;
        private Daekhon.Control.Custom.CLabel LblFrontLeft;
        private Daekhon.Control.Custom.CLabel LblTitleBackLeft;
        private Daekhon.Control.Custom.CLabel LblTitleFrontRight;
        private System.Windows.Forms.Button BtnSelectBackRight;
        private Daekhon.Control.Custom.CLabel LblTitleFrontLeft;
        private System.Windows.Forms.Button BtnSelectBackLeft;
        private System.Windows.Forms.Button BtnSelectFrontRight;
        private System.Windows.Forms.Button BtnSelectFrontLeft;
        private Daekhon.Control.Custom.CLabel LblTitleCamSelection;
        private Daekhon.Control.Custom.CPanel PnlButton;
        private System.Windows.Forms.Button BtnApply;
        private System.Windows.Forms.Button BtnClose;
        private Daekhon.Control.Custom.CPanel PnlMiddleBottom;
        private System.Windows.Forms.DataGridView DgvCamList;
        private Daekhon.Control.Custom.CLabel LblTitleCamList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKey;

    }
}