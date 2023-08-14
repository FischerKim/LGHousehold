using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Util.Print;

namespace ShampDesign
{
    public class CIOGeneral : IIOProcessor
    {
        #region VARIABLE
        private bool m_BEnable = true;

        private int m_I32Interval = 0;
        private long m_BOnTick = long.MaxValue;
        #endregion


        #region PROPERTIES
        public bool BEnabled
        {
            get { return this.m_BEnable; }
            set { this.m_BEnable = value; }
        }


        public int I32Interval
        {
            get { return this.m_I32Interval; }
            set { this.m_I32Interval = value; }
        }
        #endregion


        #region FUNCTION
        public void On()
        {
            try
            {
                if (this.m_BEnable == true)
                {
                    this.m_BOnTick = DateTime.Now.Ticks;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Off() { }


        public bool ProcessOn() { return false; }


        public bool ProcessOff()
        {
            bool BResult = false;

            try
            {
                if (this.m_BEnable == true)
                {
                    if (DateTime.Now.Ticks - this.m_BOnTick > this.m_I32Interval * 10000)
                    {
                        this.m_BOnTick = long.MaxValue;
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
