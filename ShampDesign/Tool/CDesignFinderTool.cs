using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Daekhon.Common;
using Jhjo.Util.Print;
using System.Threading;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro;

namespace ShampDesign
{
    public class CDesignFinderTool : IDirectTool, IDisposable
    {
        #region VARIABLE
        private ECAMERA m_EDirection = ECAMERA.NONE;

        private IImageExporter m_OExporter = null;
        private List<CImageInfo> m_LstOImageInfo = null;
        private object m_OImageInterrupt = null;
        
        private CDesignFinderRecipe m_ORecipe = null;
        private object m_ORecipeInterrupt = null;

        private Thread m_OWorker = null;
        private bool m_BDoWork = false;

        private CDesignFinderResult m_OResult = null;
        private object m_OResultInterrupt = null;

        private bool m_BInspect = true;
        #endregion


        #region PROPERTIES
        public IImageExporter OExporter
        {
            get { return this.m_OExporter; }
            set
            {
                try
                {
                    if (this.m_OExporter != null)
                    {
                        this.m_OExporter.Exported -= new ExportedHandler(this.OExporter_Exported);
                    }

                    this.m_OExporter = value;

                    if (this.m_OExporter != null)
                    {
                        this.m_OExporter.Exported += new ExportedHandler(this.OExporter_Exported);
                    }
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
            }
        }


        public IRecipe ORecipe
        {
            get { return this.m_ORecipe; }
            set 
            {
                try
                {
                    if (value == null) this.m_ORecipe = null;
                    else this.m_ORecipe = (CDesignFinderRecipe)value;
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
            }
        }


        public CDesignFinderResult OResult
        {
            get { return this.m_OResult; }
            set { this.m_OResult = value; }
        }


        public bool BInspect
        {
            get { return this.m_BInspect; }
            set { this.m_BInspect = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CDesignFinderTool(ECAMERA EDirection)
        {
            try
            {
                this.m_EDirection = EDirection;

                this.m_LstOImageInfo = new List<CImageInfo>();
                this.m_OImageInterrupt = new object();
                this.m_ORecipeInterrupt = new object();
                this.m_OResultInterrupt = new object();

                this.BeginWork();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CDesignFinderTool()
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
        private void OExporter_Exported(CImageInfo OImageInfo)
        {
            try
            {
                this.SetImageInfo(OImageInfo);

                Console.WriteLine(this.m_EDirection.ToString() + " : " + OImageInfo.OTime.ToString("yyyy-MM-dd HH:mm:ss fff"));
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region FUNCTION
        private void BeginWork()
        {
            try
            {
                if (this.m_OWorker == null)
                {
                    this.m_BDoWork = true;

                    this.m_OWorker = new Thread(this.Work);
                    this.m_OWorker.IsBackground = true;
                    this.m_OWorker.Start();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void Work()
        {
            try
            {
                while (this.m_BDoWork == true)
                {
                    try
                    {
                        CImageInfo OImageInfo = this.GetImageInfo();
                        if (OImageInfo != null)
                        {
                            CDesignFinderResult OResult = this.DoInspect(OImageInfo);
                            this.SetResult(OResult);
                        }
                    }
                    catch (Exception ex)
                    {
                        CError.Ignore(ex);
                    }

                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void EndWork()
        {
            try
            {
                if (this.m_OWorker != null)
                {
                    this.m_BDoWork = false;

                    this.m_OWorker.Join();
                    this.m_OWorker = null;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private CDesignFinderResult DoInspect(CImageInfo OImageInfo)
        {
            CDesignFinderResult OResult = null;

            try
            {
                Monitor.Enter(this.m_ORecipeInterrupt);

                OResult = new CDesignFinderResult();
                OResult.OImageInfo = OImageInfo;
                OResult.EDirection = this.m_EDirection;

                if ((this.m_ORecipe != null) && (this.m_ORecipe.BEnabled == true))
                {
                    OResult.BEnable = true;
                    OResult.I32MinScore = Convert.ToInt32(this.m_ORecipe.F64MinScore);

                    if (this.m_BInspect == true)
                    {
                        this.m_ORecipe.OTool.InputImage = OImageInfo.OImage;
                        this.m_ORecipe.OTool.Run();

                        if ((this.m_ORecipe.OTool.Results != null) && (this.m_ORecipe.OTool.Results.Count > 0))
                        {
                            OResult.I32Score = Convert.ToInt32(Math.Round(this.m_ORecipe.OTool.Results[0].Score, 2) * 100);

                            if (OResult.I32Score >= this.m_ORecipe.F64MinScore)
                            {
                                OResult.OGraphic = this.m_ORecipe.OTool.Results[0].CreateResultGraphics(CogPMAlignResultGraphicConstants.BoundingBox);
                                OResult.BOK = true;
                            }
                        }

                        OResult.BInspected = true;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_ORecipeInterrupt);
            }

            return OResult;
        }


        private void SetImageInfo(CImageInfo OImageInfo)
        {
            try
            {
                Monitor.Enter(this.m_OImageInterrupt);

                this.m_LstOImageInfo.Add(OImageInfo);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OImageInterrupt);
            }
        }


        private CImageInfo GetImageInfo()
        {
            CImageInfo OResult = null;

            try
            {
                Monitor.Enter(this.m_OImageInterrupt);

                if (this.m_LstOImageInfo.Count > 0)
                {
                    OResult = this.m_LstOImageInfo[0];
                    this.m_LstOImageInfo.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OImageInterrupt);
            }

            return OResult;
        }


        private void SetResult(CDesignFinderResult OResult)
        {
            try
            {
                Monitor.Enter(this.m_OResultInterrupt);

                this.m_OResult = OResult;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OResultInterrupt);
            }
        }


        public void BeginSyncRecipe()
        {
            try
            {
                Monitor.Enter(this.m_ORecipeInterrupt);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void EndSyncRecipe()
        {
            try
            {
                Monitor.Exit(this.m_ORecipeInterrupt);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void BeginSyncResult()
        {
            try
            {
                Monitor.Enter(this.m_OResultInterrupt);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void EndSyncResult()
        {
            try
            {
                Monitor.Exit(this.m_OResultInterrupt);
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
                this.EndWork();
            }
            catch (Exception ex)
            {
                CError.Ignore(ex);
            }
        }
        #endregion
    }
}
