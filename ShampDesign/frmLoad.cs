using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

using PylonC.NET;
using Daekhon.Common;
using Jhjo.Util.Print;

namespace ShampDesign
{
    public partial class frmLoad : Form
    {
        #region CONST
        private const string SYSTEM_INI = ".\\System.ini";
        #endregion


        #region VARIABLE
        private CCameraInfo m_OFrontLeft = null;
        private CCameraInfo m_OFrontRight = null;
        private CCameraInfo m_OBackLeft = null;
        private CCameraInfo m_OBackRight = null;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public frmLoad()
        {
            InitializeComponent();
        }
        #endregion


        #region EVENT
        #region FORM EVENT
        private void frmLoad_Load(object sender, EventArgs e)
        {
            try
            {
                StringBuilder OFrontLeft = new StringBuilder();
                StringBuilder OFrontRight = new StringBuilder();
                StringBuilder OBackLeft = new StringBuilder();
                StringBuilder OBackRight = new StringBuilder();

                if (File.Exists(frmLoad.SYSTEM_INI) == false)
                {
                    File.WriteAllText(frmLoad.SYSTEM_INI, ShampDesign.Properties.Resources.System);
                }

                frmLoad.GetPrivateProfileString(ECAMERA.FRONT_LEFT.ToString(), "IP", string.Empty, OFrontLeft, 255, frmLoad.SYSTEM_INI);
                frmLoad.GetPrivateProfileString(ECAMERA.FRONT_RIGHT.ToString(), "IP", string.Empty, OFrontRight, 255, frmLoad.SYSTEM_INI);
                frmLoad.GetPrivateProfileString(ECAMERA.BACK_LEFT.ToString(), "IP", string.Empty, OBackLeft, 255, frmLoad.SYSTEM_INI);
                frmLoad.GetPrivateProfileString(ECAMERA.BACK_RIGHT.ToString(), "IP", string.Empty, OBackRight, 255, frmLoad.SYSTEM_INI);


                uint U32Count = Pylon.EnumerateDevices();
                for (uint _Index = 0; _Index < U32Count; _Index++)
                {
                    PYLON_DEVICE_INFO_HANDLE OHandle = Pylon.GetDeviceInfoHandle(_Index);
                    string StrSerial = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "IpAddress");

                    if (StrSerial == OFrontLeft.ToString())
                    {
                        this.m_OFrontLeft = new CCameraInfo();
                        this.m_OFrontLeft.StrVender = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "VendorName");
                        this.m_OFrontLeft.StrModel = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "ModelName");
                        this.m_OFrontLeft.StrSerial = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber");
                        this.m_OFrontLeft.StrIP = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "IpAddress");
                        this.m_OFrontLeft.OKey = _Index;
                    }
                    if (StrSerial == OFrontRight.ToString())
                    {
                        this.m_OFrontRight = new CCameraInfo();
                        this.m_OFrontRight.StrVender = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "VendorName");
                        this.m_OFrontRight.StrModel = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "ModelName");
                        this.m_OFrontRight.StrSerial = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber");
                        this.m_OFrontRight.StrIP = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "IpAddress");
                        this.m_OFrontRight.OKey = _Index;
                    }
                    if (StrSerial == OBackLeft.ToString())
                    {
                        this.m_OBackLeft = new CCameraInfo();
                        this.m_OBackLeft.StrVender = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "VendorName");
                        this.m_OBackLeft.StrModel = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "ModelName");
                        this.m_OBackLeft.StrSerial = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber");
                        this.m_OBackLeft.StrIP = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "IpAddress");
                        this.m_OBackLeft.OKey = _Index;
                    }
                    if (StrSerial == OBackRight.ToString())
                    {
                        this.m_OBackRight = new CCameraInfo();
                        this.m_OBackRight.StrVender = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "VendorName");
                        this.m_OBackRight.StrModel = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "ModelName");
                        this.m_OBackRight.StrSerial = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber");
                        this.m_OBackRight.StrIP = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "IpAddress");
                        this.m_OBackRight.OKey = _Index;
                    }
                }


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
                frmCameraSelector OWindow = new frmCameraSelector();
                OWindow.OFrontLeft = this.m_OFrontLeft;
                OWindow.OFrontRight = this.m_OFrontRight;
                OWindow.OBackLeft = this.m_OBackLeft;
                OWindow.OBackRight = this.m_OBackRight;

                if (OWindow.ShowDialog() == DialogResult.OK)
                {
                    this.m_OFrontLeft = OWindow.OFrontLeft;
                    this.m_OFrontRight = OWindow.OFrontRight;
                    this.m_OBackLeft = OWindow.OBackLeft;
                    this.m_OBackRight = OWindow.OBackRight;

                    if (this.m_OFrontLeft != null) this.LblFrontLeft.Text = this.m_OFrontLeft.StrIP;
                    if (this.m_OFrontRight != null) this.LblFrontRight.Text = this.m_OFrontRight.StrIP;
                    if (this.m_OBackLeft != null) this.LblBackLeft.Text = this.m_OBackLeft.StrIP;
                    if (this.m_OBackRight != null) this.LblBackRight.Text = this.m_OBackRight.StrIP;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                //if ((this.m_OFrontLeft == null) ||
                //    (this.m_OFrontRight == null) ||
                //    (this.m_OBackLeft == null) ||
                //    (this.m_OBackRight == null))
                //{
                //    CMsgBox.Warning("Please select all camera for Vision");
                //    return;
                //}


                if (this.m_OFrontLeft != null)
                {
                    frmLoad.WritePrivateProfileString(ECAMERA.FRONT_LEFT.ToString(), "Company", this.m_OFrontLeft.StrVender, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString(ECAMERA.FRONT_LEFT.ToString(), "Product", this.m_OFrontLeft.StrModel, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString(ECAMERA.FRONT_LEFT.ToString(), "Serial", this.m_OFrontLeft.StrSerial, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString(ECAMERA.FRONT_LEFT.ToString(), "IP", this.m_OFrontLeft.StrIP, SYSTEM_INI);
                }
                if (this.m_OFrontRight != null)
                {
                    frmLoad.WritePrivateProfileString(ECAMERA.FRONT_RIGHT.ToString(), "Company", this.m_OFrontRight.StrVender, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString(ECAMERA.FRONT_RIGHT.ToString(), "Product", this.m_OFrontRight.StrModel, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString(ECAMERA.FRONT_RIGHT.ToString(), "Serial", this.m_OFrontRight.StrSerial, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString(ECAMERA.FRONT_RIGHT.ToString(), "IP", this.m_OFrontRight.StrIP, SYSTEM_INI);
                }
                if (this.m_OBackLeft != null)
                {
                    frmLoad.WritePrivateProfileString(ECAMERA.BACK_LEFT.ToString(), "Company", this.m_OBackLeft.StrVender, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString(ECAMERA.BACK_LEFT.ToString(), "Product", this.m_OBackLeft.StrModel, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString(ECAMERA.BACK_LEFT.ToString(), "Serial", this.m_OBackLeft.StrSerial, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString(ECAMERA.BACK_LEFT.ToString(), "IP", this.m_OBackLeft.StrIP, SYSTEM_INI);
                }
                if (this.m_OBackRight != null)
                {
                    frmLoad.WritePrivateProfileString(ECAMERA.BACK_RIGHT.ToString(), "Company", this.m_OBackRight.StrVender, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString(ECAMERA.BACK_RIGHT.ToString(), "Product", this.m_OBackRight.StrModel, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString(ECAMERA.BACK_RIGHT.ToString(), "Serial", this.m_OBackRight.StrSerial, SYSTEM_INI);
                    frmLoad.WritePrivateProfileString(ECAMERA.BACK_RIGHT.ToString(), "IP", this.m_OBackRight.StrIP, SYSTEM_INI);
                }


                CDB.It.Load();
                CRecipeManager.It.Load();
                if (this.m_OFrontLeft != null) CAcquisitionManager.It.OFrontLeft = new CBasler(this.m_OFrontLeft);
                if (this.m_OFrontRight != null) CAcquisitionManager.It.OFrontRight = new CBasler(this.m_OFrontRight);
                if (this.m_OBackLeft != null) CAcquisitionManager.It.OBackLeft = new CBasler(this.m_OBackLeft);
                if (this.m_OBackRight != null) CAcquisitionManager.It.OBackRight = new CBasler(this.m_OBackRight);


                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnExit_Click(object sender, EventArgs e)
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


        #region EXTERNAL FUNCTION
        [DllImport("kernel32")]
        public static extern bool GetPrivateProfileString(string StrAppName, string StrKey, string StrDefault, StringBuilder StrValue, int I32Size, string StrFile);

        [DllImport("kernel32")]
        public static extern bool WritePrivateProfileString(string StrAppName, string StrKey, string StrValue, string StrFile);
        #endregion
    }
}
