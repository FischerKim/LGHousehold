using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daekhon.Common;
using Cognex.VisionPro;

namespace ShampDesign
{
    public class CDesignFinderResult : IDirectResult
    {
        #region VARIABLE
        private CImageInfo m_OImageInfo = null;
        private ECAMERA m_EDirection = ECAMERA.NONE;
        private bool m_BEanble = false;
        private int m_I32MinScore = 0;

        private bool m_BInspected = false;
        private bool m_BOK = false;        
        private int m_I32Score = 0;
        private CogCompositeShape m_OGraphic = null;

        private string m_StrFile = string.Empty;
        #endregion


        #region PROPERTIES
        public CImageInfo OImageInfo
        {
            get { return this.m_OImageInfo; }
            set { this.m_OImageInfo = value; }
        }


        public ECAMERA EDirection
        {
            get { return this.m_EDirection; }
            set { this.m_EDirection = value; }
        }


        public bool BEnable
        {
            get { return this.m_BEanble; }
            set { this.m_BEanble = value; }
        }


        public int I32MinScore
        {
            get { return this.m_I32MinScore; }
            set { this.m_I32MinScore = value; }
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


        public int I32Score
        {
            get { return this.m_I32Score; }
            set { this.m_I32Score = value; }
        }


        public CogCompositeShape OGraphic
        {
            get { return this.m_OGraphic; }
            set { this.m_OGraphic = value; }
        }


        public string StrFile
        {
            get { return this.m_StrFile; }
            set { this.m_StrFile = value; }
        }
        #endregion
    }
}
