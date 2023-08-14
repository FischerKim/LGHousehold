using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Util.Print;
using Jhjo.File.DB;
using Cognex.VisionPro;
using System.IO;

namespace ShampDesign
{
    public partial class UcReport : UcScreen
    {
        #region CONSTRUCTOR & DESTRUCTOR
        public UcReport()
        {
            InitializeComponent();
        }
        #endregion


        #region EVENT
        #region BUTTON EVENT
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                CDynamicTable OTable = CDB.It.GetDynamicTable(CDB.TABLE_REPORT);
                this.DgvReport.DataSource = OTable.Select(this.DtpDate.Value, true).Copy();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region ETC EVENT
        private void DgvReport_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.DgvReport.CurrentRow == null) return;

                DataRow ORow = ((DataRowView)(this.DgvReport.CurrentRow.DataBoundItem)).Row;
                if (String.IsNullOrEmpty(ORow[CDB.REPORT_COLUMN_FRONT_LEFT_FILE].ToString()) == false)
                {
                    this.CdpFrontLeft.Image = this.GetImage(ORow[CDB.REPORT_COLUMN_FRONT_LEFT_FILE].ToString());
                }
                if (String.IsNullOrEmpty(ORow[CDB.REPORT_COLUMN_FRONT_RIGHT_FILE].ToString()) == false)
                {
                    this.CdpFrontRight.Image = this.GetImage(ORow[CDB.REPORT_COLUMN_FRONT_RIGHT_FILE].ToString());
                }
                if (String.IsNullOrEmpty(ORow[CDB.REPORT_COLUMN_BACK_LEFT_FILE].ToString()) == false)
                {
                    this.CdpBackLeft.Image = this.GetImage(ORow[CDB.REPORT_COLUMN_BACK_LEFT_FILE].ToString());
                }
                if (String.IsNullOrEmpty(ORow[CDB.REPORT_COLUMN_BACK_RIGHT_FILE].ToString()) == false)
                {
                    this.CdpBackRight.Image = this.GetImage(ORow[CDB.REPORT_COLUMN_BACK_RIGHT_FILE].ToString());
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion
        #endregion


        #region FUNCTION
        private CogImage8Grey GetImage(string StrPath)
        {
            CogImage8Grey OResult = null;

            try
            {
                if (File.Exists(StrPath) == true)
                {
                    Bitmap OSource = (Bitmap)Bitmap.FromFile(StrPath);
                    OResult = new CogImage8Grey(OSource);
                    OSource.Dispose();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return OResult;
        }
        #endregion
    }
}
