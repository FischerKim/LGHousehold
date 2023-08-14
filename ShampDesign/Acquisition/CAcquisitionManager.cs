using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Util.Print;

namespace ShampDesign
{
    public class CAcquisitionManager : IDisposable
    {
        #region SIGNLETON
        private static CAcquisitionManager Src_It = null;

        public static CAcquisitionManager It
        {
            get
            {
                CAcquisitionManager OResult = null;

                try
                {
                    if (CAcquisitionManager.Src_It == null)
                    {
                        CAcquisitionManager.Src_It = new CAcquisitionManager();
                    }

                    OResult = CAcquisitionManager.Src_It;
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }

                return OResult;
            }
        }
        #endregion


        #region VARIABLE
        private CBasler m_OFrontLeft = null;
        private CBasler m_OFrontRight = null;
        private CBasler m_OBackLeft = null;
        private CBasler m_OBackRight = null;
        #endregion


        #region PROPERTIES
        public CBasler OFrontLeft
        {
            get { return this.m_OFrontLeft; }
            set 
            {
                try
                {
                    if (value != null)
                    {
                        this.m_OFrontLeft = value;
                        this.m_OFrontLeft.StrTriggerSelector = "FrameStart";
                        this.m_OFrontLeft.StrTriggerMode = "On";
                    }
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
            }
        }


        public CBasler OFrontRight
        {
            get { return this.m_OFrontRight; }
            set
            {
                try
                {
                    if (value != null)
                    {
                        this.m_OFrontRight = value;
                        this.m_OFrontRight.StrTriggerSelector = "FrameStart";
                        this.m_OFrontRight.StrTriggerMode = "On";
                    }
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
            }
        }


        public CBasler OBackLeft
        {
            get { return this.m_OBackLeft; }
            set
            {
                try
                {
                    if (value != null)
                    {
                        this.m_OBackLeft = value;
                        this.m_OBackLeft.StrTriggerSelector = "FrameStart";
                        this.m_OBackLeft.StrTriggerMode = "On";
                    }
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
            }
        }


        public CBasler OBackRight
        {
            get { return this.m_OBackRight; }
            set
            {
                try
                {
                    if (value != null)
                    {
                        this.m_OBackRight = value;
                        this.m_OBackRight.StrTriggerSelector = "FrameStart";
                        this.m_OBackRight.StrTriggerMode = "On";
                    }
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
            }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        protected CAcquisitionManager() { }


        ~CAcquisitionManager()
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


        #region FUNCTION
        public void Dispose()
        {
            try
            {
                if (this.m_OFrontLeft != null)
                {
                    this.m_OFrontLeft.Dispose();
                    this.m_OFrontLeft = null;
                }
                if (this.m_OFrontRight != null)
                {
                    this.m_OFrontRight.Dispose();
                    this.m_OFrontRight = null;
                }
                if (this.m_OBackLeft != null)
                {
                    this.m_OBackLeft.Dispose();
                    this.m_OBackLeft = null;
                }
                if (this.m_OBackRight != null)
                {
                    this.m_OBackRight.Dispose();
                    this.m_OBackRight = null;
                }
            }
            catch (Exception ex)
            {
                CError.Ignore(ex);
            }
        }
        #endregion
    }


    #region ENUM
    public enum ECAMERA : byte
    {
        FRONT_LEFT = 0x00,
        FRONT_RIGHT,
        BACK_LEFT,
        BACK_RIGHT,
        NONE = 0xFF
    }
    #endregion
}
