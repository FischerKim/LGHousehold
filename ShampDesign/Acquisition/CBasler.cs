using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using PylonC.NET;
using PylonC.NETSupportLibrary;

using Daekhon.Common;

using Jhjo.Util.Print;

namespace ShampDesign
{
    public class CBasler : ICamera, IDisposable
    {
        #region VARIABLE
        private CCameraInfo m_OInfo = null;

        private ImageProvider m_OImageProvider = null;
        private NODE_HANDLE m_OWidthHandle = null;
        private NODE_HANDLE m_OHeightHandle = null;
        private NODE_HANDLE m_OCenterXHandle = null;
        private NODE_HANDLE m_OOffsetXHandle = null;
        private NODE_HANDLE m_OGainHandle = null;
        private NODE_HANDLE m_OExposureHandle = null;
        private NODE_HANDLE m_OTriggerSelectorHandle = null;
        private NODE_HANDLE m_OTriggerModeHandle = null;
        private NODE_HANDLE m_OTriggerSourceHandle = null;

        private Bitmap m_OImage = null;
        private bool m_BIsRunning = false;
        #endregion


        #region DELEGATE & EVENT
        public event ExportedHandler Exported = null;
        #endregion


        #region PROPERTIES
        public CCameraInfo OInfo
        {
            get { return this.m_OInfo; }
        }


        public int I32Width
        {
            get { return (int)GenApi.IntegerGetValue(this.m_OWidthHandle); }
            set { GenApi.IntegerSetValue(this.m_OWidthHandle, value); }
        }


        public int I32WidthMin
        {
            get { return (int)GenApi.IntegerGetMin(this.m_OWidthHandle); }
        }


        public int I32WidthMax
        {
            get { return (int)GenApi.IntegerGetMax(this.m_OWidthHandle); }
        }


        public int I32Height
        {
            get { return (int)GenApi.IntegerGetValue(this.m_OHeightHandle); }
            set { GenApi.IntegerSetValue(this.m_OHeightHandle, value); }
        }


        public int I32HeightMin
        {
            get { return (int)GenApi.IntegerGetMin(this.m_OHeightHandle); }
        }


        public int I32HeightMax
        {
            get { return (int)GenApi.IntegerGetMax(this.m_OHeightHandle); }
        }


        public bool BCenterX
        {
            get { return GenApi.BooleanGetValue(this.m_OCenterXHandle); }
            set
            {
                GenApi.BooleanSetValue(this.m_OCenterXHandle, value);
                if (value == false) GenApi.IntegerSetValue(this.m_OOffsetXHandle, 0);
            }
        }


        public int I32Gain
        {
            get { return (int)GenApi.IntegerGetValue(this.m_OGainHandle); }
            set { GenApi.IntegerSetValue(this.m_OGainHandle, value); }
        }


        public int I32GainMin
        {
            get { return (int)GenApi.IntegerGetMin(this.m_OGainHandle); }
        }


        public int I32GainMax
        {
            get { return (int)GenApi.IntegerGetMax(this.m_OGainHandle); }
        }


        public int I32ExposureTime
        {
            get { return (int)GenApi.IntegerGetValue(this.m_OExposureHandle); }
            set { GenApi.IntegerSetValue(this.m_OExposureHandle, value); }
        }


        public int I32ExposureTimeMin
        {
            get { return (int)GenApi.IntegerGetMin(this.m_OExposureHandle); }
        }


        public int I32ExposureTimeMax
        {
            get { return (int)GenApi.IntegerGetMax(this.m_OExposureHandle); }
        }


        public string StrTriggerSelector
        {
            get { return GenApi.NodeToString(this.m_OTriggerSelectorHandle); }
            set { GenApi.NodeFromString(this.m_OTriggerSelectorHandle, value); }
        }


        public string StrTriggerMode
        {
            get { return GenApi.NodeToString(this.m_OTriggerModeHandle); }
            set { GenApi.NodeFromString(this.m_OTriggerModeHandle, value); }
        }


        public string StrTriggerSource
        {
            get { return GenApi.NodeToString(this.m_OTriggerSourceHandle); }
            set { GenApi.NodeFromString(this.m_OTriggerSourceHandle, value); }
        }


        public bool BIsRunning
        {
            get { return this.m_BIsRunning; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CBasler()
        {
            try
            {
                PYLON_DEVICE_INFO_HANDLE OHandle = Pylon.GetDeviceInfoHandle(0);

                this.m_OInfo = new CCameraInfo();
                this.m_OInfo.StrVender = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "VendorName");
                this.m_OInfo.StrModel = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "ModelName");
                this.m_OInfo.StrSerial = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "SerialNumber");
                this.m_OInfo.StrIP = Pylon.DeviceInfoGetPropertyValueByName(OHandle, "IpAddress");
                this.m_OInfo.OKey = (uint)0;


                this.m_OImageProvider = new ImageProvider();
                this.m_OImageProvider.Open(0);
                this.m_OImageProvider.DeviceRemovedEvent += new ImageProvider.DeviceRemovedEventHandler(this.OImageProvider_DeviceRemovedEvent);
                this.m_OImageProvider.ImageReadyEvent += new ImageProvider.ImageReadyEventHandler(this.OImageProvider_ImageReadyEvent);
                this.m_OWidthHandle = this.m_OImageProvider.GetNodeFromDevice("Width");
                this.m_OHeightHandle = this.m_OImageProvider.GetNodeFromDevice("Height");
                this.m_OCenterXHandle = this.m_OImageProvider.GetNodeFromDevice("CenterX");
                this.m_OOffsetXHandle = this.m_OImageProvider.GetNodeFromDevice("OffsetX");
                this.m_OGainHandle = this.m_OImageProvider.GetNodeFromDevice("GainRaw");
                this.m_OExposureHandle = this.m_OImageProvider.GetNodeFromDevice("ExposureTimeRaw");
                this.m_OTriggerSelectorHandle = this.m_OImageProvider.GetNodeFromDevice("TriggerSelector");
                this.m_OTriggerModeHandle = this.m_OImageProvider.GetNodeFromDevice("TriggerMode");
                this.m_OTriggerSourceHandle = this.m_OImageProvider.GetNodeFromDevice("TriggerSource");
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CBasler(CCameraInfo OCameraInfo)
        {
            try
            {
                this.m_OInfo = OCameraInfo;

                this.m_OImageProvider = new ImageProvider();
                this.m_OImageProvider.Open((uint)OCameraInfo.OKey);
                this.m_OImageProvider.DeviceRemovedEvent += new ImageProvider.DeviceRemovedEventHandler(OImageProvider_DeviceRemovedEvent);
                this.m_OImageProvider.ImageReadyEvent += new ImageProvider.ImageReadyEventHandler(OImageProvider_ImageReadyEvent);
                this.m_OWidthHandle = this.m_OImageProvider.GetNodeFromDevice("Width");
                this.m_OHeightHandle = this.m_OImageProvider.GetNodeFromDevice("Height");
                this.m_OCenterXHandle = this.m_OImageProvider.GetNodeFromDevice("CenterX");
                this.m_OOffsetXHandle = this.m_OImageProvider.GetNodeFromDevice("OffsetX");
                this.m_OGainHandle = this.m_OImageProvider.GetNodeFromDevice("GainRaw");
                this.m_OExposureHandle = this.m_OImageProvider.GetNodeFromDevice("ExposureTimeRaw");
                this.m_OTriggerSelectorHandle = this.m_OImageProvider.GetNodeFromDevice("TriggerSelector");
                this.m_OTriggerModeHandle = this.m_OImageProvider.GetNodeFromDevice("TriggerMode");
                this.m_OTriggerSourceHandle = this.m_OImageProvider.GetNodeFromDevice("TriggerSource");
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CBasler()
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                CError.Ignore(ex);
            }
        }
        #endregion


        #region EVENT
        private void OImageProvider_DeviceRemovedEvent()
        {
            try
            {
                this.m_OImageProvider.Stop();
                this.m_OImageProvider.Close();
            }
            catch (Exception ex)
            {
                CError.Ignore(ex);
            }
        }


        private void OImageProvider_ImageReadyEvent()
        {
            try
            {
                ImageProvider.Image OImage = this.m_OImageProvider.GetLatestImage();

                if (OImage != null)
                {
                    if (this.m_OImage != null)
                    {
                        this.m_OImage.Dispose();
                        this.m_OImage = null;
                    }

                    BitmapFactory.CreateBitmap(out this.m_OImage, OImage.Width, OImage.Height, OImage.Color);
                    BitmapFactory.UpdateBitmap(this.m_OImage, OImage.Buffer, OImage.Width, OImage.Height, OImage.Color);

                     CImageInfo OImageInfo = new CImageInfo(this.m_OImage);
                    this.OnExported(OImageInfo);

                    this.m_OImageProvider.ReleaseImage();
                }
            }
            catch (Exception ex)
            {
                CError.Ignore(ex);
            }
        }
        #endregion


        #region FUNCTION
        public void Start()
        {
            try
            {
                this.m_OImageProvider.ContinuousShot();
                this.m_BIsRunning = true;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Stop()
        {
            try
            {
                this.m_OImageProvider.Stop();
                this.m_BIsRunning = false;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void OnExported(CImageInfo OImageInfo)
        {
            try
            {
                if (this.Exported != null)
                {
                    this.Exported(OImageInfo);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Dispose()
        {
            try
            {
                if (this.m_OImageProvider != null)
                {
                    this.m_OImageProvider.Close();
                    this.m_OImageProvider = null;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
