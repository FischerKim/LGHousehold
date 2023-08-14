using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daekhon.Common;
using Cognex.VisionPro.PMAlign;
using Jhjo.Util.Print;
using System.IO;
using Cognex.VisionPro;

namespace ShampDesign
{
    public class CShampFaultRecipe : IRecipe, IDisposable
    {
        #region VARIABLE
        private string m_StrName = string.Empty;
        private string m_StrDirectory = string.Empty;

        private CDesignFinderRecipe m_OFrontLeft = null;
        private CDesignFinderRecipe m_OFrontRight = null;
        private CDesignFinderRecipe m_OBackLeft = null;
        private CDesignFinderRecipe m_OBackRight = null;
        #endregion


        #region PROPERTIES
        public string StrName
        {
            get { return this.m_StrName; }
            set { this.m_StrName = value; }
        }


        public string StrDirectory
        {
            get { return this.m_StrDirectory; }
            set { this.m_StrDirectory = value; }
        }


        public CDesignFinderRecipe OFrontLeft
        {
            get { return this.m_OFrontLeft; }
        }


        public CDesignFinderRecipe OFrontRight
        {
            get { return this.m_OFrontRight; }
        }


        public CDesignFinderRecipe OBackLeft
        {
            get { return this.m_OBackLeft; }
        }


        public CDesignFinderRecipe OBackRight
        {
            get { return this.m_OBackRight; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CShampFaultRecipe(string StrName)
        {
            try
            {
                this.m_StrName = StrName;
                this.m_StrDirectory = ".\\RECIPE\\" + StrName;
                this.m_OFrontLeft = new CDesignFinderRecipe(this.m_StrName, ECAMERA.FRONT_LEFT, this.m_StrDirectory);
                this.m_OFrontRight = new CDesignFinderRecipe(this.m_StrName, ECAMERA.FRONT_RIGHT, this.m_StrDirectory);
                this.m_OBackLeft = new CDesignFinderRecipe(this.m_StrName, ECAMERA.BACK_LEFT, this.m_StrDirectory);
                this.m_OBackRight = new CDesignFinderRecipe(this.m_StrName, ECAMERA.BACK_RIGHT, this.m_StrDirectory);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CShampFaultRecipe(string StrName, string StrDirectory)
        {
            try
            {
                this.m_StrName = StrName;
                this.m_StrDirectory = StrDirectory;
                this.m_OFrontLeft = new CDesignFinderRecipe(this.m_StrName, ECAMERA.FRONT_LEFT, this.m_StrDirectory);
                this.m_OFrontRight = new CDesignFinderRecipe(this.m_StrName, ECAMERA.FRONT_RIGHT, this.m_StrDirectory);
                this.m_OBackLeft = new CDesignFinderRecipe(this.m_StrName, ECAMERA.BACK_LEFT, this.m_StrDirectory);
                this.m_OBackRight = new CDesignFinderRecipe(this.m_StrName, ECAMERA.BACK_RIGHT, this.m_StrDirectory);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CShampFaultRecipe(CShampFaultRecipe OSource)
        {
            try
            {
                this.m_StrName = OSource.m_StrName;
                this.m_StrDirectory = OSource.m_StrDirectory;
                this.m_OFrontLeft = new CDesignFinderRecipe(OSource.m_OFrontLeft);
                this.m_OFrontRight = new CDesignFinderRecipe(OSource.m_OFrontRight);
                this.m_OBackLeft = new CDesignFinderRecipe(OSource.m_OBackLeft);
                this.m_OBackRight = new CDesignFinderRecipe(OSource.m_OBackRight);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTION
        public void Create()
        {
            try
            {
                this.m_OFrontLeft.Create();
                this.m_OFrontRight.Create();
                this.m_OBackLeft.Create();
                this.m_OBackRight.Create();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Load()
        {
            try
            {
                this.m_OFrontLeft.Load();
                this.m_OFrontRight.Load();
                this.m_OBackLeft.Load();
                this.m_OBackRight.Load();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Save()
        {
            try
            {
                this.m_OFrontLeft.Save();
                this.m_OFrontRight.Save();
                this.m_OBackLeft.Save();
                this.m_OBackRight.Save();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Copy(CShampFaultRecipe OSource)
        {
            try
            {
                this.m_OFrontLeft.Copy(OSource.m_OFrontLeft);
                this.m_OFrontRight.Copy(OSource.m_OFrontRight);
                this.m_OBackLeft.Copy(OSource.m_OBackLeft);
                this.m_OBackRight.Copy(OSource.m_OBackRight);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Delete()
        {
            try
            {
                if (Directory.Exists(this.m_StrDirectory) == true)
                {
                    Directory.Delete(this.m_StrDirectory, true);
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
                CError.Throw(ex);
            }
        }
        #endregion
    }
}
