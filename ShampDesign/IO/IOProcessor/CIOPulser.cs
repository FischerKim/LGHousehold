using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Util.Print;

namespace ShampDesign
{
    public class CIOPulser : IIOProcessor
    {
        #region VARIABLE
        private bool m_BEnabled = false;

        private long m_I64OnTick = 0;
        private long m_I32OnInterval = 10000000;

        private long m_I64OffTick = 0;
        private long m_I32OffInterval = 10000000;
        #endregion


        #region PROPERTIES
        public bool BEnabled
        {
            get { return this.m_BEnabled; }
            set { this.m_BEnabled = value; }
        }


        public long I32OnInterval
        {
            get { return this.m_I32OnInterval; }
            set { this.m_I32OnInterval = value; }
        }


        public long I32OffInterval
        {
            get { return this.m_I32OffInterval; }
            set { this.m_I32OffInterval = value; }
        }
        #endregion


        #region FUNCTION
        public void On()
        {
            try
            {
                this.m_I64OnTick = DateTime.Now.Ticks;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Off()
        {
            try
            {
                this.m_I64OffTick = DateTime.Now.Ticks;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public bool ProcessOn()
        {
            bool BResult = false;

            try
            {
                if (this.m_BEnabled == true)
                {
                    if (this.m_I64OffTick + (this.m_I32OffInterval * 10000) < DateTime.Now.Ticks)
                    {
                        BResult = true;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return BResult;
        }


        public bool ProcessOff()
        {
            bool BResult = false;

            try
            {
                if (this.m_BEnabled == true)
                {
                    if (this.m_I64OnTick + (this.m_I32OnInterval * 10000) < DateTime.Now.Ticks)
                    {
                        BResult = true;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return BResult;
        }
        #endregion
    }
}
