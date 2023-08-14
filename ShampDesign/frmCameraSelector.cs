using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Daekhon.Common;
using Jhjo.Util.Print;
using PylonC.NET;


namespace ShampDesign
{
    public partial class frmCameraSelector : Form
    {
        #region VARIABLE
        private CCameraInfo m_OFrontLeft = null;
        private CCameraInfo m_OFrontRight = null;
        private CCameraInfo m_OBackLeft = null;
        private CCameraInfo m_OBackRight = null;
        #endregion


        #region PROPERTIES
        public CCameraInfo OFrontLeft
        {
            get { return this.m_OFrontLeft; }
            set { this.m_OFrontLeft = value; }
        }


        public CCameraInfo OFrontRight
        {
            get { return this.m_OFrontRight; }
            set { this.m_OFrontRight = value; }
        }


        public CCameraInfo OBackLeft
        {
            get { return this.m_OBackLeft; }
            set { this.m_OBackLeft = value; }
        }


        public CCameraInfo OBackRight
        {
            get { return this.m_OBackRight; }
            set { this.m_OBackRight = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public frmCameraSelector()
        {
            InitializeComponent();
        }
        #endregion


        #region EVENT
        #region FORM EVENT
        private void frmCameraSelector_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable ODataSource = new DataTable();
                ODataSource.Columns.Add("COMPANY", typeof(string));
                ODataSource.Columns.Add("MODEL", typeof(string));
                ODataSource.Columns.Add("IP", typeof(string));
                ODataSource.Columns.Add("SERIAL", typeof(string));
                ODataSource.Columns.Add("KEY", typeof(uint));

                uint U32Count = Pylon.EnumerateDevices();
                for (uint _Index = 0; _Index < U32Count; _Index++)
                {
                    PYLON_DEVICE_INFO_HANDLE OHandle = Pylon.GetDeviceInfoHandle(_Index);

                    DataRow ORow = ODataSource.NewRow();
                    ORow["COMPANY"] = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "VendorName");
                    ORow["MODEL"] = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "ModelName");
                    ORow["IP"] = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "IpAddress");
                    ORow["SERIAL"] = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber");
                    ORow["KEY"] = _Index;
                    ODataSource.Rows.Add(ORow);
                }

                this.DgvCamList.DataSource = ODataSource;


                if (this.m_OFrontLeft != null) this.LblFrontLeft.Text = this.m_OFrontLeft.StrIP;
                if (this.m_OFrontRight != null) this.LblFrontRight.Text = this.m_OFrontRight.StrIP;
                if (this.m_OBackLeft != null) this.LblBackLeft.Text = this.m_OBackLeft.StrIP;
                if (this.m_OBackRight != null) this.LblBackRight.Text = this.m_OBackRight.StrIP;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region BUTTON EVENT
        private void BtnSelect_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.DgvCamList.CurrentRow == null)
                {
                    CMsgBox.Warning("Please select camera infomation to assign!");
                    return;
                }


                ECAMERA ECamera = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)((Button)sender).Tag);
                string StrIP = (string)(((DataRowView)(this.DgvCamList.CurrentRow.DataBoundItem)).Row)["IP"];

                if (ECamera == ECAMERA.FRONT_LEFT)
                {
                    this.LblFrontLeft.Text = StrIP;

                    if (StrIP == this.LblFrontRight.Text) this.LblFrontRight.Text = string.Empty;
                    if (StrIP == this.LblBackLeft.Text) this.LblBackLeft.Text = string.Empty;
                    if (StrIP == this.LblBackRight.Text) this.LblBackRight.Text = string.Empty;
                }
                else if (ECamera == ECAMERA.FRONT_RIGHT)
                {
                    this.LblFrontRight.Text = StrIP;

                    if (StrIP == this.LblFrontLeft.Text) this.LblFrontLeft.Text = string.Empty;
                    if (StrIP == this.LblBackLeft.Text) this.LblBackLeft.Text = string.Empty;
                    if (StrIP == this.LblBackRight.Text) this.LblBackRight.Text = string.Empty;
                }
                else if (ECamera == ECAMERA.BACK_LEFT)
                {
                    this.LblBackLeft.Text = StrIP;

                    if (StrIP == this.LblFrontLeft.Text) this.LblFrontLeft.Text = string.Empty;
                    if (StrIP == this.LblFrontRight.Text) this.LblFrontRight.Text = string.Empty;
                    if (StrIP == this.LblBackRight.Text) this.LblBackRight.Text = string.Empty;
                }
                else if (ECamera == ECAMERA.BACK_RIGHT)
                {
                    this.LblBackRight.Text = StrIP;

                    if (StrIP == this.LblFrontLeft.Text) this.LblFrontLeft.Text = string.Empty;
                    if (StrIP == this.LblFrontRight.Text) this.LblFrontRight.Text = string.Empty;
                    if (StrIP == this.LblBackLeft.Text) this.LblBackLeft.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(this.LblFrontLeft.Text) == true) this.m_OFrontLeft = null;
                if (String.IsNullOrEmpty(this.LblFrontRight.Text) == true) this.m_OFrontRight = null;
                if (String.IsNullOrEmpty(this.LblBackLeft.Text) == true) this.m_OBackLeft = null;
                if (String.IsNullOrEmpty(this.LblBackRight.Text) == true) this.m_OBackRight = null;
                

                DataTable ODataSource = (DataTable)this.DgvCamList.DataSource;

                foreach (DataRow _Item in ODataSource.Rows)
                {
                    if ((string)_Item["IP"] == this.LblFrontLeft.Text)
                    {
                        if (this.m_OFrontLeft == null) this.m_OFrontLeft = new CCameraInfo();
                        this.m_OFrontLeft.StrVender = (string)_Item["COMPANY"];
                        this.m_OFrontLeft.StrModel = (string)_Item["MODEL"];
                        this.m_OFrontLeft.StrIP = (string)_Item["IP"];
                        this.m_OFrontLeft.StrSerial = (string)_Item["SERIAL"];
                        this.m_OFrontLeft.OKey = (uint)_Item["KEY"];
                    }
                    else if ((string)_Item["IP"] == this.LblFrontRight.Text)
                    {
                        if (this.m_OFrontRight == null) this.m_OFrontRight = new CCameraInfo();
                        this.m_OFrontRight.StrVender = (string)_Item["COMPANY"];
                        this.m_OFrontRight.StrModel = (string)_Item["MODEL"];
                        this.m_OFrontRight.StrIP = (string)_Item["IP"];
                        this.m_OFrontRight.StrSerial = (string)_Item["SERIAL"];
                        this.m_OFrontRight.OKey = (uint)_Item["KEY"];
                    }
                    else if ((string)_Item["IP"] == this.LblBackLeft.Text)
                    {
                        if (this.m_OBackLeft == null) this.m_OBackLeft = new CCameraInfo();
                        this.m_OBackLeft.StrVender = (string)_Item["COMPANY"];
                        this.m_OBackLeft.StrModel = (string)_Item["MODEL"];
                        this.m_OBackLeft.StrIP = (string)_Item["IP"];
                        this.m_OBackLeft.StrSerial = (string)_Item["SERIAL"];
                        this.m_OBackLeft.OKey = (uint)_Item["KEY"];
                    }
                    else if ((string)_Item["IP"] == this.LblBackRight.Text)
                    {
                        if (this.m_OBackRight == null) this.m_OBackRight = new CCameraInfo();
                        this.m_OBackRight.StrVender = (string)_Item["COMPANY"];
                        this.m_OBackRight.StrModel = (string)_Item["MODEL"];
                        this.m_OBackRight.StrIP = (string)_Item["IP"];
                        this.m_OBackRight.StrSerial = (string)_Item["SERIAL"];
                        this.m_OBackRight.OKey = (uint)_Item["KEY"];
                    }
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnClose_Click(object sender, EventArgs e)
        {
            try
            {
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion
        #endregion
    }
}
