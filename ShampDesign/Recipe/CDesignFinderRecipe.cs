using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Daekhon.Common;
using Jhjo.Util.Print;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ShampDesign
{
    public class CDesignFinderRecipe : IRecipe, IDisposable
    {
        #region VARIABLE
        private string m_StrName = string.Empty;
        private ECAMERA m_EDirection = ECAMERA.NONE;

        private string m_StrDirectory = string.Empty;
        private CogPMAlignTool m_OTool = null;

        private bool m_BEnabled = true;
        private double m_F64AngleLow = -45;
        private double m_F64AngleHigh = 45;
        private double m_F64ScaleLow = 0.8;
        private double m_F64ScaleHigh = 1.2;
        private double m_F64ScoreMin = 80;
        #endregion


        #region PROPERTIES
        public string StrName
        {
            get { return this.m_StrName; }
            set { this.m_StrName = value; }
        }


        public ECAMERA EDirection
        {
            get { return this.m_EDirection; }
        }


        public string StrDirectory
        {
            get { return this.m_StrDirectory; }
        }


        public CogPMAlignTool OTool
        {
            get { return this.m_OTool; }
        }


        public bool BEnabled
        {
            get { return this.m_BEnabled; }
            set { this.m_BEnabled = value; }
        }


        public double F64AngleLow
        {
            get { return this.m_F64AngleLow; }
            set { this.m_F64AngleLow = value; }
        }


        public double F64AngleHigh
        {
            get { return this.m_F64AngleHigh; }
            set { this.m_F64AngleHigh = value; }
        }


        public double F64ScaleLow
        {
            get { return this.m_F64ScaleLow; }
            set { this.m_F64ScaleLow = value; }
        }


        public double F64ScaleHigh
        {
            get { return this.m_F64ScaleHigh; }
            set { this.m_F64ScaleHigh = value; }
        }


        public double F64MinScore
        {
            get { return this.m_F64ScoreMin; }
            set { this.m_F64ScoreMin = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CDesignFinderRecipe(string StrName, ECAMERA EDirection, string StrDirectory)
        {
            try
            {
                this.m_StrName = StrName;
                this.m_EDirection = EDirection;
                this.m_StrDirectory = StrDirectory;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public CDesignFinderRecipe(CDesignFinderRecipe OSource)
        {
            try
            {
                this.m_StrName = OSource.m_StrName;
                this.m_EDirection = OSource.m_EDirection;
                this.m_StrDirectory = OSource.m_StrDirectory;

                this.m_BEnabled = OSource.m_BEnabled;
                this.m_F64AngleLow = OSource.m_F64AngleLow;
                this.m_F64AngleHigh = OSource.m_F64AngleHigh;
                this.m_F64ScaleLow = OSource.m_F64ScaleLow;
                this.m_F64ScaleHigh = OSource.m_F64ScaleHigh;
                this.m_F64ScoreMin = OSource.m_F64ScoreMin;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CDesignFinderRecipe()
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
        public void Create()
        {
            try
            {
                CogRectangle OTrainBound = new CogRectangle();
                OTrainBound.X = 0;
                OTrainBound.Y = 0;
                OTrainBound.Width = 200;
                OTrainBound.Height = 200;
                OTrainBound.Color = CogColorConstants.Red;
                OTrainBound.SelectedColor = CogColorConstants.Red;
                OTrainBound.Visible = false;
                OTrainBound.Interactive = true;
                OTrainBound.GraphicDOFEnable = CogRectangleDOFConstants.All;
                
                CogRectangle OSearchBound = new CogRectangle();
                OSearchBound.X = 0;
                OSearchBound.Y = 0;
                OSearchBound.Width = 200;
                OSearchBound.Height = 200;
                OSearchBound.Color = CogColorConstants.Blue;
                OSearchBound.SelectedColor = CogColorConstants.Blue;
                OSearchBound.Visible = false;
                OSearchBound.Interactive = true;
                OSearchBound.GraphicDOFEnable = CogRectangleDOFConstants.All;
                
                this.m_OTool = new CogPMAlignTool();
                this.m_OTool.Pattern.TrainRegion = OTrainBound;
                this.m_OTool.SearchRegion = OSearchBound;
                this.m_OTool.RunParams.RunAlgorithm = CogPMAlignRunAlgorithmConstants.PatQuick;
                this.m_OTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
                this.m_OTool.RunParams.ZoneAngle.Low = CogMisc.DegToRad(this.m_F64AngleLow);
                this.m_OTool.RunParams.ZoneAngle.High = CogMisc.DegToRad(this.m_F64AngleHigh);
                this.m_OTool.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.LowHigh;
                this.m_OTool.RunParams.ZoneScale.Low = this.m_F64ScaleLow;
                this.m_OTool.RunParams.ZoneScale.High = this.m_F64ScaleHigh;
                this.m_OTool.RunParams.TimeoutEnabled = true;
                this.m_OTool.RunParams.Timeout = 200;
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
                this.m_OTool = (CogPMAlignTool)CogSerializer.LoadObjectFromFile
                (
                    this.m_StrDirectory + "\\" + this.m_EDirection.ToString() + ".vpp",
                    typeof(BinaryFormatter),
                    CogSerializationOptionsConstants.All
                );


                this.m_OTool.RunParams.ZoneAngle.Configuration = CogPMAlignZoneConstants.LowHigh;
                this.m_OTool.RunParams.ZoneAngle.Low = CogMisc.DegToRad(this.m_F64AngleLow);
                this.m_OTool.RunParams.ZoneAngle.High = CogMisc.DegToRad(this.m_F64AngleHigh);
                this.m_OTool.RunParams.ZoneScale.Configuration = CogPMAlignZoneConstants.LowHigh;
                this.m_OTool.RunParams.ZoneScale.Low = this.m_F64ScaleLow;
                this.m_OTool.RunParams.ZoneScale.High = this.m_F64ScaleHigh;
                this.m_OTool.RunParams.TimeoutEnabled = true;
                this.m_OTool.RunParams.Timeout = 200;

                if (this.m_OTool.SearchRegion == null)
                {
                    CogRectangle OSearchBound = new CogRectangle();
                    OSearchBound.X = 0;
                    OSearchBound.Y = 0;
                    OSearchBound.Width = 200;
                    OSearchBound.Height = 200;
                    OSearchBound.Color = CogColorConstants.Blue;
                    OSearchBound.SelectedColor = CogColorConstants.Blue;
                    OSearchBound.Visible = ((CogRectangle)this.m_OTool.Pattern.TrainRegion).Visible;
                    OSearchBound.Interactive = true;
                    OSearchBound.GraphicDOFEnable = CogRectangleDOFConstants.All;
                    this.m_OTool.SearchRegion = OSearchBound;
                }
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
                Directory.CreateDirectory(this.m_StrDirectory);
                CogSerializer.SaveObjectToFile
                (
                    this.m_OTool,
                    this.m_StrDirectory + "\\" + this.m_EDirection.ToString() + ".vpp"
                );
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void Copy(CDesignFinderRecipe OSource)
        {
            try
            {
                Directory.CreateDirectory(this.m_StrDirectory);
                File.Copy
                (
                    OSource.m_StrDirectory + "\\" + OSource.m_EDirection + ".vpp",
                    this.m_StrDirectory + "\\" + this.m_EDirection + ".vpp"
                );

                this.m_BEnabled = OSource.m_BEnabled;
                this.m_F64AngleLow = OSource.m_F64AngleLow;
                this.m_F64AngleHigh = OSource.m_F64AngleHigh;
                this.m_F64ScaleLow = OSource.m_F64ScaleLow;
                this.m_F64ScaleHigh = OSource.m_F64ScaleHigh;
                this.m_F64ScoreMin = OSource.m_F64ScoreMin;
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
                if (this.m_OTool != null)
                {
                    this.m_OTool.Dispose();
                    this.m_OTool = null;
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