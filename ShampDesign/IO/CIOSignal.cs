using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Util.Print;

namespace ShampDesign
{
    public class CIOSignal
    {
        #region VARIABLE
        private ushort m_U16Card = 0;
        private ushort m_U16Line = 0;

        private bool m_BOn = false;
        private IIOProcessor m_OProcessor = null;
        #endregion


        #region PROPERTIES
        public ushort U16Line
        {
            get { return this.m_U16Line; }
        }


        public bool BOn
        {
            get { return this.m_BOn; }
        }


        public IIOProcessor OProcessor
        {
            get { return this.m_OProcessor; }
            set { this.m_OProcessor = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CIOSignal(ushort U16Card, ushort U16Line)
        {
            try
            {
                this.m_U16Card = U16Card;
                this.m_U16Line = U16Line;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTION
        public void On()
        {
            try
            {
                if (this.m_OProcessor != null)
                {
                    this.m_OProcessor.On();
                }
                this.m_BOn = true;

                CPCI7230.DO_WriteLine(this.m_U16Card, 0, this.m_U16Line, 1);
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
                if (this.m_OProcessor != null)
                {
                    this.m_OProcessor.Off();
                }
                this.m_BOn = false;

                CPCI7230.DO_WriteLine(this.m_U16Card, 0, this.m_U16Line, 0);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Process()
        {
            try
            {
                if (this.m_OProcessor != null)
                {
                    if (this.m_U16Line == 1)
                    {
                        Console.WriteLine("test");
                    }


                    if (this.m_BOn == false)
                    {
                        if (this.m_OProcessor.ProcessOn() == true) this.On();
                    }
                    else
                    {
                        if (this.m_OProcessor.ProcessOff() == true) this.Off();
                    }
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
