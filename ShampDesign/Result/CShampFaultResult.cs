using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daekhon.Common;
using Jhjo.Util.Print;

namespace ShampDesign
{
    public class CShampFaultResult : IResult
    {
        #region VARIABLE
        private DateTime m_OTime = DateTime.MinValue;

        private CDesignFinderResult m_OFrontLeft = null;
        private CDesignFinderResult m_OFrontRight = null;
        private CDesignFinderResult m_OBackLeft = null;
        private CDesignFinderResult m_OBackRight = null;

        private bool m_BInspected = false;
        private bool m_BOK = false;
        #endregion


        #region PROPERTIES
        public DateTime OTime
        {
            get { return this.m_OTime; }
            set { this.m_OTime = value; }
        }


        public CDesignFinderResult OFrontLeft
        {
            get { return this.m_OFrontLeft; }
            set { this.m_OFrontLeft = value; }
        }


        public CDesignFinderResult OFrontRight
        {
            get { return this.m_OFrontRight; }
            set { this.m_OFrontRight = value; }
        }


        public CDesignFinderResult OBackLeft
        {
            get { return this.m_OBackLeft; }
            set { this.m_OBackLeft = value;}
        }


        public CDesignFinderResult OBackRight
        {
            get { return this.m_OBackRight; }
            set { this.m_OBackRight = value; }
        }


        public bool BInspected
        {
            get { return this.m_BInspected; }
            set { this.m_BInspected = value; }
        }


        public bool BOK
        {
            get { return this.m_BOK; }
            set { this.m_BOK = value; }
        }
        #endregion


        #region CONSTRUCTOR
        public CShampFaultResult()
        {
            try
            {
                this.m_OTime = DateTime.Now;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
