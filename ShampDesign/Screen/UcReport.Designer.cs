namespace ShampDesign
{
    partial class UcReport
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcReport));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlTop = new Daekhon.Control.Custom.CPanel();
            this.LblTitle = new Daekhon.Control.Custom.CLabel();
            this.PnlBottom = new Daekhon.Control.Custom.CPanel();
            this.PnlBack = new Daekhon.Control.Custom.CPanel();
            this.PnlBackRight = new Daekhon.Control.Custom.CPanel();
            this.CdpBackRight = new Cognex.VisionPro.Display.CogDisplay();
            this.LblTitleBackRight = new Daekhon.Control.Custom.CLabel();
            this.PnlBackLeft = new Daekhon.Control.Custom.CPanel();
            this.CdpBackLeft = new Cognex.VisionPro.Display.CogDisplay();
            this.LblTitleBackLeft = new Daekhon.Control.Custom.CLabel();
            this.PnlFront = new Daekhon.Control.Custom.CPanel();
            this.PnlFrontRight = new Daekhon.Control.Custom.CPanel();
            this.CdpFrontRight = new Cognex.VisionPro.Display.CogDisplay();
            this.LblTitleFrontRight = new Daekhon.Control.Custom.CLabel();
            this.PnlFrontLeft = new Daekhon.Control.Custom.CPanel();
            this.CdpFrontLeft = new Cognex.VisionPro.Display.CogDisplay();
            this.LblTitleFrontLeft = new Daekhon.Control.Custom.CLabel();
            this.PnlLeft = new Daekhon.Control.Custom.CPanel();
            this.PnlReport = new System.Windows.Forms.Panel();
            this.DgvReport = new System.Windows.Forms.DataGridView();
            this.ColDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRecipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFrontLeftEnable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFrontLeftMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFrontLeftScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFrontLeftFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFrontRightEnable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFrontRightMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFrontRightScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColFrontRightFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBackLeftEnable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBackLeftMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBackLeftScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBackLeftFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBackRightEnable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBackRightMin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBackRightScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBackRightFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PnlSearch = new Daekhon.Control.Custom.CPanel();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.LblTitleSearch = new Daekhon.Control.Custom.CLabel();
            this.PnlTop.SuspendLayout();
            this.PnlBottom.SuspendLayout();
            this.PnlBack.SuspendLayout();
            this.PnlBackRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CdpBackRight)).BeginInit();
            this.PnlBackLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CdpBackLeft)).BeginInit();
            this.PnlFront.SuspendLayout();
            this.PnlFrontRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CdpFrontRight)).BeginInit();
            this.PnlFrontLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CdpFrontLeft)).BeginInit();
            this.PnlLeft.SuspendLayout();
            this.PnlReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReport)).BeginInit();
            this.PnlSearch.SuspendLayout();
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
            this.PnlTop.Size = new System.Drawing.Size(1920, 40);
            this.PnlTop.TabIndex = 4;
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
            this.LblTitle.Size = new System.Drawing.Size(1920, 40);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "NG 보고서";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlBottom
            // 
            this.PnlBottom.BDrawBorderBottom = false;
            this.PnlBottom.BDrawBorderLeft = false;
            this.PnlBottom.BDrawBorderRight = false;
            this.PnlBottom.BDrawBorderTop = false;
            this.PnlBottom.Controls.Add(this.PnlBack);
            this.PnlBottom.Controls.Add(this.PnlFront);
            this.PnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlBottom.Location = new System.Drawing.Point(0, 565);
            this.PnlBottom.Name = "PnlBottom";
            this.PnlBottom.Size = new System.Drawing.Size(1920, 420);
            this.PnlBottom.TabIndex = 5;
            // 
            // PnlBack
            // 
            this.PnlBack.BDrawBorderBottom = false;
            this.PnlBack.BDrawBorderLeft = false;
            this.PnlBack.BDrawBorderRight = false;
            this.PnlBack.BDrawBorderTop = false;
            this.PnlBack.Controls.Add(this.PnlBackRight);
            this.PnlBack.Controls.Add(this.PnlBackLeft);
            this.PnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBack.Location = new System.Drawing.Point(960, 0);
            this.PnlBack.Name = "PnlBack";
            this.PnlBack.Size = new System.Drawing.Size(960, 420);
            this.PnlBack.TabIndex = 1;
            // 
            // PnlBackRight
            // 
            this.PnlBackRight.BDrawBorderBottom = false;
            this.PnlBackRight.BDrawBorderLeft = false;
            this.PnlBackRight.BDrawBorderRight = false;
            this.PnlBackRight.BDrawBorderTop = false;
            this.PnlBackRight.Controls.Add(this.CdpBackRight);
            this.PnlBackRight.Controls.Add(this.LblTitleBackRight);
            this.PnlBackRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBackRight.Location = new System.Drawing.Point(480, 0);
            this.PnlBackRight.Name = "PnlBackRight";
            this.PnlBackRight.Size = new System.Drawing.Size(480, 420);
            this.PnlBackRight.TabIndex = 3;
            // 
            // CdpBackRight
            // 
            this.CdpBackRight.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.CdpBackRight.ColorMapLowerRoiLimit = 0D;
            this.CdpBackRight.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.CdpBackRight.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.CdpBackRight.ColorMapUpperRoiLimit = 1D;
            this.CdpBackRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CdpBackRight.Location = new System.Drawing.Point(0, 40);
            this.CdpBackRight.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.CdpBackRight.MouseWheelSensitivity = 1D;
            this.CdpBackRight.Name = "CdpBackRight";
            this.CdpBackRight.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CdpBackRight.OcxState")));
            this.CdpBackRight.Size = new System.Drawing.Size(480, 380);
            this.CdpBackRight.TabIndex = 20;
            // 
            // LblTitleBackRight
            // 
            this.LblTitleBackRight.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleBackRight.BDrawBorderBottom = true;
            this.LblTitleBackRight.BDrawBorderLeft = false;
            this.LblTitleBackRight.BDrawBorderRight = false;
            this.LblTitleBackRight.BDrawBorderTop = false;
            this.LblTitleBackRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleBackRight.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleBackRight.ForeColor = System.Drawing.Color.White;
            this.LblTitleBackRight.Location = new System.Drawing.Point(0, 0);
            this.LblTitleBackRight.Name = "LblTitleBackRight";
            this.LblTitleBackRight.OColor = System.Drawing.Color.Black;
            this.LblTitleBackRight.Size = new System.Drawing.Size(480, 40);
            this.LblTitleBackRight.TabIndex = 18;
            this.LblTitleBackRight.Text = "4";
            this.LblTitleBackRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlBackLeft
            // 
            this.PnlBackLeft.BDrawBorderBottom = false;
            this.PnlBackLeft.BDrawBorderLeft = false;
            this.PnlBackLeft.BDrawBorderRight = false;
            this.PnlBackLeft.BDrawBorderTop = false;
            this.PnlBackLeft.Controls.Add(this.CdpBackLeft);
            this.PnlBackLeft.Controls.Add(this.LblTitleBackLeft);
            this.PnlBackLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlBackLeft.Location = new System.Drawing.Point(0, 0);
            this.PnlBackLeft.Name = "PnlBackLeft";
            this.PnlBackLeft.Size = new System.Drawing.Size(480, 420);
            this.PnlBackLeft.TabIndex = 2;
            // 
            // CdpBackLeft
            // 
            this.CdpBackLeft.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.CdpBackLeft.ColorMapLowerRoiLimit = 0D;
            this.CdpBackLeft.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.CdpBackLeft.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.CdpBackLeft.ColorMapUpperRoiLimit = 1D;
            this.CdpBackLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CdpBackLeft.Location = new System.Drawing.Point(0, 40);
            this.CdpBackLeft.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.CdpBackLeft.MouseWheelSensitivity = 1D;
            this.CdpBackLeft.Name = "CdpBackLeft";
            this.CdpBackLeft.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CdpBackLeft.OcxState")));
            this.CdpBackLeft.Size = new System.Drawing.Size(480, 380);
            this.CdpBackLeft.TabIndex = 20;
            // 
            // LblTitleBackLeft
            // 
            this.LblTitleBackLeft.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleBackLeft.BDrawBorderBottom = true;
            this.LblTitleBackLeft.BDrawBorderLeft = false;
            this.LblTitleBackLeft.BDrawBorderRight = true;
            this.LblTitleBackLeft.BDrawBorderTop = false;
            this.LblTitleBackLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleBackLeft.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleBackLeft.ForeColor = System.Drawing.Color.White;
            this.LblTitleBackLeft.Location = new System.Drawing.Point(0, 0);
            this.LblTitleBackLeft.Name = "LblTitleBackLeft";
            this.LblTitleBackLeft.OColor = System.Drawing.Color.Black;
            this.LblTitleBackLeft.Size = new System.Drawing.Size(480, 40);
            this.LblTitleBackLeft.TabIndex = 18;
            this.LblTitleBackLeft.Text = "3";
            this.LblTitleBackLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlFront
            // 
            this.PnlFront.BDrawBorderBottom = false;
            this.PnlFront.BDrawBorderLeft = false;
            this.PnlFront.BDrawBorderRight = false;
            this.PnlFront.BDrawBorderTop = false;
            this.PnlFront.Controls.Add(this.PnlFrontRight);
            this.PnlFront.Controls.Add(this.PnlFrontLeft);
            this.PnlFront.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlFront.Location = new System.Drawing.Point(0, 0);
            this.PnlFront.Name = "PnlFront";
            this.PnlFront.Size = new System.Drawing.Size(960, 420);
            this.PnlFront.TabIndex = 0;
            // 
            // PnlFrontRight
            // 
            this.PnlFrontRight.BDrawBorderBottom = false;
            this.PnlFrontRight.BDrawBorderLeft = false;
            this.PnlFrontRight.BDrawBorderRight = false;
            this.PnlFrontRight.BDrawBorderTop = false;
            this.PnlFrontRight.Controls.Add(this.CdpFrontRight);
            this.PnlFrontRight.Controls.Add(this.LblTitleFrontRight);
            this.PnlFrontRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlFrontRight.Location = new System.Drawing.Point(480, 0);
            this.PnlFrontRight.Name = "PnlFrontRight";
            this.PnlFrontRight.Size = new System.Drawing.Size(480, 420);
            this.PnlFrontRight.TabIndex = 1;
            // 
            // CdpFrontRight
            // 
            this.CdpFrontRight.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.CdpFrontRight.ColorMapLowerRoiLimit = 0D;
            this.CdpFrontRight.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.CdpFrontRight.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.CdpFrontRight.ColorMapUpperRoiLimit = 1D;
            this.CdpFrontRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CdpFrontRight.Location = new System.Drawing.Point(0, 40);
            this.CdpFrontRight.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.CdpFrontRight.MouseWheelSensitivity = 1D;
            this.CdpFrontRight.Name = "CdpFrontRight";
            this.CdpFrontRight.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CdpFrontRight.OcxState")));
            this.CdpFrontRight.Size = new System.Drawing.Size(480, 380);
            this.CdpFrontRight.TabIndex = 20;
            // 
            // LblTitleFrontRight
            // 
            this.LblTitleFrontRight.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleFrontRight.BDrawBorderBottom = true;
            this.LblTitleFrontRight.BDrawBorderLeft = false;
            this.LblTitleFrontRight.BDrawBorderRight = true;
            this.LblTitleFrontRight.BDrawBorderTop = false;
            this.LblTitleFrontRight.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleFrontRight.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleFrontRight.ForeColor = System.Drawing.Color.White;
            this.LblTitleFrontRight.Location = new System.Drawing.Point(0, 0);
            this.LblTitleFrontRight.Name = "LblTitleFrontRight";
            this.LblTitleFrontRight.OColor = System.Drawing.Color.Black;
            this.LblTitleFrontRight.Size = new System.Drawing.Size(480, 40);
            this.LblTitleFrontRight.TabIndex = 18;
            this.LblTitleFrontRight.Text = "2";
            this.LblTitleFrontRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlFrontLeft
            // 
            this.PnlFrontLeft.BDrawBorderBottom = false;
            this.PnlFrontLeft.BDrawBorderLeft = false;
            this.PnlFrontLeft.BDrawBorderRight = false;
            this.PnlFrontLeft.BDrawBorderTop = false;
            this.PnlFrontLeft.Controls.Add(this.CdpFrontLeft);
            this.PnlFrontLeft.Controls.Add(this.LblTitleFrontLeft);
            this.PnlFrontLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlFrontLeft.Location = new System.Drawing.Point(0, 0);
            this.PnlFrontLeft.Name = "PnlFrontLeft";
            this.PnlFrontLeft.Size = new System.Drawing.Size(480, 420);
            this.PnlFrontLeft.TabIndex = 0;
            // 
            // CdpFrontLeft
            // 
            this.CdpFrontLeft.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.CdpFrontLeft.ColorMapLowerRoiLimit = 0D;
            this.CdpFrontLeft.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.CdpFrontLeft.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.CdpFrontLeft.ColorMapUpperRoiLimit = 1D;
            this.CdpFrontLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CdpFrontLeft.Location = new System.Drawing.Point(0, 40);
            this.CdpFrontLeft.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.CdpFrontLeft.MouseWheelSensitivity = 1D;
            this.CdpFrontLeft.Name = "CdpFrontLeft";
            this.CdpFrontLeft.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CdpFrontLeft.OcxState")));
            this.CdpFrontLeft.Size = new System.Drawing.Size(480, 380);
            this.CdpFrontLeft.TabIndex = 19;
            // 
            // LblTitleFrontLeft
            // 
            this.LblTitleFrontLeft.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleFrontLeft.BDrawBorderBottom = true;
            this.LblTitleFrontLeft.BDrawBorderLeft = false;
            this.LblTitleFrontLeft.BDrawBorderRight = true;
            this.LblTitleFrontLeft.BDrawBorderTop = false;
            this.LblTitleFrontLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleFrontLeft.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleFrontLeft.ForeColor = System.Drawing.Color.White;
            this.LblTitleFrontLeft.Location = new System.Drawing.Point(0, 0);
            this.LblTitleFrontLeft.Name = "LblTitleFrontLeft";
            this.LblTitleFrontLeft.OColor = System.Drawing.Color.Black;
            this.LblTitleFrontLeft.Size = new System.Drawing.Size(480, 40);
            this.LblTitleFrontLeft.TabIndex = 18;
            this.LblTitleFrontLeft.Text = "1";
            this.LblTitleFrontLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlLeft
            // 
            this.PnlLeft.BDrawBorderBottom = false;
            this.PnlLeft.BDrawBorderLeft = false;
            this.PnlLeft.BDrawBorderRight = false;
            this.PnlLeft.BDrawBorderTop = false;
            this.PnlLeft.Controls.Add(this.PnlReport);
            this.PnlLeft.Controls.Add(this.PnlSearch);
            this.PnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlLeft.Location = new System.Drawing.Point(0, 40);
            this.PnlLeft.Name = "PnlLeft";
            this.PnlLeft.Size = new System.Drawing.Size(1920, 525);
            this.PnlLeft.TabIndex = 6;
            // 
            // PnlReport
            // 
            this.PnlReport.Controls.Add(this.DgvReport);
            this.PnlReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlReport.Location = new System.Drawing.Point(0, 95);
            this.PnlReport.Name = "PnlReport";
            this.PnlReport.Size = new System.Drawing.Size(1920, 430);
            this.PnlReport.TabIndex = 1;
            // 
            // DgvReport
            // 
            this.DgvReport.AllowUserToAddRows = false;
            this.DgvReport.AllowUserToDeleteRows = false;
            this.DgvReport.AllowUserToResizeRows = false;
            this.DgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDateTime,
            this.ColRecipe,
            this.ColFrontLeftEnable,
            this.ColFrontLeftMin,
            this.ColFrontLeftScore,
            this.ColFrontLeftFile,
            this.ColFrontRightEnable,
            this.ColFrontRightMin,
            this.ColFrontRightScore,
            this.ColFrontRightFile,
            this.ColBackLeftEnable,
            this.ColBackLeftMin,
            this.ColBackLeftScore,
            this.ColBackLeftFile,
            this.ColBackRightEnable,
            this.ColBackRightMin,
            this.ColBackRightScore,
            this.ColBackRightFile});
            this.DgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvReport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgvReport.Location = new System.Drawing.Point(0, 0);
            this.DgvReport.MultiSelect = false;
            this.DgvReport.Name = "DgvReport";
            this.DgvReport.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 15F);
            this.DgvReport.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvReport.RowTemplate.Height = 23;
            this.DgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvReport.Size = new System.Drawing.Size(1920, 430);
            this.DgvReport.TabIndex = 0;
            this.DgvReport.SelectionChanged += new System.EventHandler(this.DgvReport_SelectionChanged);
            // 
            // ColDateTime
            // 
            this.ColDateTime.DataPropertyName = "DATETIME";
            this.ColDateTime.HeaderText = "시간";
            this.ColDateTime.Name = "ColDateTime";
            this.ColDateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColRecipe
            // 
            this.ColRecipe.DataPropertyName = "RECIPE";
            this.ColRecipe.HeaderText = "레시피";
            this.ColRecipe.Name = "ColRecipe";
            this.ColRecipe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColFrontLeftEnable
            // 
            this.ColFrontLeftEnable.DataPropertyName = "FRONT_LEFT_ENABLE";
            this.ColFrontLeftEnable.HeaderText = "1-사용유무";
            this.ColFrontLeftEnable.Name = "ColFrontLeftEnable";
            this.ColFrontLeftEnable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColFrontLeftMin
            // 
            this.ColFrontLeftMin.DataPropertyName = "FRONT_LEFT_MIN";
            this.ColFrontLeftMin.HeaderText = "1-최소점수";
            this.ColFrontLeftMin.Name = "ColFrontLeftMin";
            this.ColFrontLeftMin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColFrontLeftScore
            // 
            this.ColFrontLeftScore.DataPropertyName = "FRONT_LEFT_SCORE";
            this.ColFrontLeftScore.HeaderText = "1-점수";
            this.ColFrontLeftScore.Name = "ColFrontLeftScore";
            this.ColFrontLeftScore.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColFrontLeftFile
            // 
            this.ColFrontLeftFile.DataPropertyName = "FRONT_LEFT_FILE";
            this.ColFrontLeftFile.HeaderText = "FL FILE";
            this.ColFrontLeftFile.Name = "ColFrontLeftFile";
            this.ColFrontLeftFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColFrontLeftFile.Visible = false;
            // 
            // ColFrontRightEnable
            // 
            this.ColFrontRightEnable.DataPropertyName = "FRONT_RIGHT_ENABLE";
            this.ColFrontRightEnable.HeaderText = "2-사용유무";
            this.ColFrontRightEnable.Name = "ColFrontRightEnable";
            this.ColFrontRightEnable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColFrontRightMin
            // 
            this.ColFrontRightMin.DataPropertyName = "FRONT_RIGHT_MIN";
            this.ColFrontRightMin.HeaderText = "2-최소점수";
            this.ColFrontRightMin.Name = "ColFrontRightMin";
            this.ColFrontRightMin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColFrontRightScore
            // 
            this.ColFrontRightScore.DataPropertyName = "FRONT_RIGHT_SCORE";
            this.ColFrontRightScore.HeaderText = "2-점수";
            this.ColFrontRightScore.Name = "ColFrontRightScore";
            this.ColFrontRightScore.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColFrontRightFile
            // 
            this.ColFrontRightFile.DataPropertyName = "FRONT_RIGHT_FILE";
            this.ColFrontRightFile.HeaderText = "FR FILE";
            this.ColFrontRightFile.Name = "ColFrontRightFile";
            this.ColFrontRightFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColFrontRightFile.Visible = false;
            // 
            // ColBackLeftEnable
            // 
            this.ColBackLeftEnable.DataPropertyName = "BACK_LEFT_ENABLE";
            this.ColBackLeftEnable.HeaderText = "3-사용유무";
            this.ColBackLeftEnable.Name = "ColBackLeftEnable";
            this.ColBackLeftEnable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColBackLeftMin
            // 
            this.ColBackLeftMin.DataPropertyName = "BACK_LEFT_MIN";
            this.ColBackLeftMin.HeaderText = "3-최소점수";
            this.ColBackLeftMin.Name = "ColBackLeftMin";
            this.ColBackLeftMin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColBackLeftScore
            // 
            this.ColBackLeftScore.DataPropertyName = "BACK_LEFT_SCORE";
            this.ColBackLeftScore.HeaderText = "3-점수";
            this.ColBackLeftScore.Name = "ColBackLeftScore";
            this.ColBackLeftScore.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColBackLeftFile
            // 
            this.ColBackLeftFile.DataPropertyName = "BACK_LEFT_FILE";
            this.ColBackLeftFile.HeaderText = "BL FILE";
            this.ColBackLeftFile.Name = "ColBackLeftFile";
            this.ColBackLeftFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColBackLeftFile.Visible = false;
            // 
            // ColBackRightEnable
            // 
            this.ColBackRightEnable.DataPropertyName = "BACK_RIGHT_ENABLE";
            this.ColBackRightEnable.HeaderText = "4-사용유무";
            this.ColBackRightEnable.Name = "ColBackRightEnable";
            this.ColBackRightEnable.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColBackRightMin
            // 
            this.ColBackRightMin.DataPropertyName = "BACK_RIGHT_MIN";
            this.ColBackRightMin.HeaderText = "4-최소점수";
            this.ColBackRightMin.Name = "ColBackRightMin";
            this.ColBackRightMin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColBackRightScore
            // 
            this.ColBackRightScore.DataPropertyName = "BACK_RIGHT_SCORE";
            this.ColBackRightScore.HeaderText = "4-점수";
            this.ColBackRightScore.Name = "ColBackRightScore";
            this.ColBackRightScore.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColBackRightFile
            // 
            this.ColBackRightFile.DataPropertyName = "BACK_RIGHT_FILE";
            this.ColBackRightFile.HeaderText = "BR FILE";
            this.ColBackRightFile.Name = "ColBackRightFile";
            this.ColBackRightFile.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColBackRightFile.Visible = false;
            // 
            // PnlSearch
            // 
            this.PnlSearch.BDrawBorderBottom = false;
            this.PnlSearch.BDrawBorderLeft = false;
            this.PnlSearch.BDrawBorderRight = false;
            this.PnlSearch.BDrawBorderTop = false;
            this.PnlSearch.Controls.Add(this.DtpDate);
            this.PnlSearch.Controls.Add(this.BtnSearch);
            this.PnlSearch.Controls.Add(this.LblTitleSearch);
            this.PnlSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlSearch.Location = new System.Drawing.Point(0, 0);
            this.PnlSearch.Name = "PnlSearch";
            this.PnlSearch.Size = new System.Drawing.Size(1920, 95);
            this.PnlSearch.TabIndex = 0;
            // 
            // DtpDate
            // 
            this.DtpDate.CustomFormat = "";
            this.DtpDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.DtpDate.Font = new System.Drawing.Font("맑은 고딕", 15.75F);
            this.DtpDate.Location = new System.Drawing.Point(5, 49);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(1756, 35);
            this.DtpDate.TabIndex = 21;
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSearch.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnSearch.ForeColor = System.Drawing.Color.White;
            this.BtnSearch.Location = new System.Drawing.Point(1767, 44);
            this.BtnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(150, 45);
            this.BtnSearch.TabIndex = 20;
            this.BtnSearch.Tag = "FRONT_LEFT";
            this.BtnSearch.Text = "검색";
            this.BtnSearch.UseVisualStyleBackColor = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // LblTitleSearch
            // 
            this.LblTitleSearch.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleSearch.BDrawBorderBottom = true;
            this.LblTitleSearch.BDrawBorderLeft = false;
            this.LblTitleSearch.BDrawBorderRight = false;
            this.LblTitleSearch.BDrawBorderTop = false;
            this.LblTitleSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleSearch.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.LblTitleSearch.ForeColor = System.Drawing.Color.White;
            this.LblTitleSearch.Location = new System.Drawing.Point(0, 0);
            this.LblTitleSearch.Name = "LblTitleSearch";
            this.LblTitleSearch.OColor = System.Drawing.Color.Black;
            this.LblTitleSearch.Size = new System.Drawing.Size(1920, 40);
            this.LblTitleSearch.TabIndex = 19;
            this.LblTitleSearch.Text = "검색";
            this.LblTitleSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UcReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlLeft);
            this.Controls.Add(this.PnlBottom);
            this.Controls.Add(this.PnlTop);
            this.Name = "UcReport";
            this.PnlTop.ResumeLayout(false);
            this.PnlBottom.ResumeLayout(false);
            this.PnlBack.ResumeLayout(false);
            this.PnlBackRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CdpBackRight)).EndInit();
            this.PnlBackLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CdpBackLeft)).EndInit();
            this.PnlFront.ResumeLayout(false);
            this.PnlFrontRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CdpFrontRight)).EndInit();
            this.PnlFrontLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CdpFrontLeft)).EndInit();
            this.PnlLeft.ResumeLayout(false);
            this.PnlReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvReport)).EndInit();
            this.PnlSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Daekhon.Control.Custom.CPanel PnlTop;
        private Daekhon.Control.Custom.CLabel LblTitle;
        private Daekhon.Control.Custom.CPanel PnlBottom;
        private Daekhon.Control.Custom.CPanel PnlFront;
        private Daekhon.Control.Custom.CPanel PnlBack;
        private Daekhon.Control.Custom.CPanel PnlBackRight;
        private Daekhon.Control.Custom.CPanel PnlBackLeft;
        private Daekhon.Control.Custom.CPanel PnlFrontRight;
        private Daekhon.Control.Custom.CPanel PnlFrontLeft;
        private Daekhon.Control.Custom.CLabel LblTitleBackRight;
        private Daekhon.Control.Custom.CLabel LblTitleBackLeft;
        private Daekhon.Control.Custom.CLabel LblTitleFrontRight;
        private Daekhon.Control.Custom.CLabel LblTitleFrontLeft;
        private Cognex.VisionPro.Display.CogDisplay CdpBackRight;
        private Cognex.VisionPro.Display.CogDisplay CdpBackLeft;
        private Cognex.VisionPro.Display.CogDisplay CdpFrontRight;
        private Cognex.VisionPro.Display.CogDisplay CdpFrontLeft;
        private Daekhon.Control.Custom.CPanel PnlLeft;
        private Daekhon.Control.Custom.CPanel PnlSearch;
        private Daekhon.Control.Custom.CLabel LblTitleSearch;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.Panel PnlReport;
        private System.Windows.Forms.DataGridView DgvReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRecipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFrontLeftEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFrontLeftMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFrontLeftScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFrontLeftFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFrontRightEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFrontRightMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFrontRightScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColFrontRightFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBackLeftEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBackLeftMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBackLeftScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBackLeftFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBackRightEnable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBackRightMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBackRightScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBackRightFile;
    }
}
