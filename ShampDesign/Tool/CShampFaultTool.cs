using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Daekhon.Common;
using Jhjo.Util.Print;
using System.Threading;
using Cognex.VisionPro;
using Jhjo.File.DB;


namespace ShampDesign
{
    public class CShampFaultTool : ITool, IDisposable
    {
        #region SINGLE TON
        private static CShampFaultTool Src_It = null;

        public static CShampFaultTool It
        {
            get
            {
                CShampFaultTool OResult = null;

                try
                {
                    if (CShampFaultTool.Src_It == null)
                    {
                        CShampFaultTool.Src_It = new CShampFaultTool();
                    }

                    OResult = CShampFaultTool.Src_It;
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
        private CShampFaultRecipe m_ORecipe = null;

        private int m_I32FrontLeft = 0;
        private int m_I32FrontRight = 0;
        private int m_I32BackLeft = 0;
        private int m_I32BackRight = 0;
        
        private CDesignFinderTool m_OFrontLeftFinder = null;
        private CDesignFinderTool m_OFrontRightFinder = null;
        private CDesignFinderTool m_OBackLeftFinder = null;
        private CDesignFinderTool m_OBackRightFinder = null;
        private List<long> m_LstOInspectionTick = null;

        private bool m_BInspect = true;
        private bool m_BDoInspect = false;
        private ushort m_U16IOLine = 0;
        private bool m_BReject = false;
        private bool m_BSaveNG = true;

        private Thread m_OWorker = null;
        private bool m_BDoWork = false;
        private object m_OInterrupt = null;

        private Dictionary<string, CogImage8Grey> m_OImageBuffer = null;
        private string m_StrDirectory = string.Empty;

        public delegate void InspectedHandler(CShampFaultResult OResult);
        public InspectedHandler Inspected = null;

        public delegate void RecipeChagedHandler(IRecipe ORecipe);
        public RecipeChagedHandler RecipeChanged = null;
        #endregion


        #region PROPERTIES
        public int I32FrontLeft
        {
            get { return this.m_I32FrontLeft;}
            set { this.m_I32FrontLeft = value;}
        }


        public int I32FrontRight
        {
            get { return this.m_I32FrontRight; }
            set { this.m_I32FrontRight = value; }
        }


        public int I32BackLeft
        {
            get { return this.m_I32BackLeft; }
            set { this.m_I32BackLeft = value; }
        }


        public int I32BackRight
        {
            get { return this.m_I32BackRight; }
            set { this.m_I32BackRight = value; }
        }


        public IRecipe ORecipe
        {
            get { return m_ORecipe; }
            set 
            {
                try
                {
                    Monitor.Enter(this.m_OInterrupt);
                    this.m_OFrontLeftFinder.BeginSyncRecipe();
                    this.m_OFrontRightFinder.BeginSyncRecipe();
                    this.m_OBackLeftFinder.BeginSyncRecipe();
                    this.m_OBackRightFinder.BeginSyncRecipe();

                    if (value == null)
                    {
                        if (this.m_ORecipe != null) this.m_ORecipe.Dispose();

                        this.m_ORecipe = null;
                        this.m_OFrontLeftFinder.ORecipe = null;
                        this.m_OFrontRightFinder.ORecipe = null;
                        this.m_OBackLeftFinder.ORecipe = null;
                        this.m_OBackRightFinder.ORecipe = null;
                    }
                    else
                    {
                        ((CShampFaultRecipe)value).Load();
                        if (this.m_ORecipe != null) this.m_ORecipe.Dispose();

                        this.m_ORecipe = (CShampFaultRecipe)value;
                        this.m_OFrontLeftFinder.ORecipe = this.m_ORecipe.OFrontLeft;
                        this.m_OFrontRightFinder.ORecipe = this.m_ORecipe.OFrontRight;
                        this.m_OBackLeftFinder.ORecipe = this.m_ORecipe.OBackLeft;
                        this.m_OBackRightFinder.ORecipe = this.m_ORecipe.OBackRight;
                    }

                    this.OnRecipeChanged(ORecipe);
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
                finally
                {
                    this.m_OFrontLeftFinder.EndSyncRecipe();
                    this.m_OFrontRightFinder.EndSyncRecipe();
                    this.m_OBackLeftFinder.EndSyncRecipe();
                    this.m_OBackRightFinder.EndSyncRecipe();
                    Monitor.Exit(this.m_OInterrupt);
                }
            }
        }


        public CDesignFinderTool OFrontLeftFinder
        {
            get { return this.m_OFrontLeftFinder; }
        }

        public CDesignFinderTool OFrontRightFinder
        {
            get { return this.m_OFrontRightFinder; }
        }

        public CDesignFinderTool OBackLeftFinder
        {
            get { return this.m_OBackLeftFinder; }
        }

        public CDesignFinderTool OBackRightFinder
        {
            get { return this.m_OBackRightFinder; }
        }


        public bool BDoInspect
        {
            get { return this.m_BDoInspect; }
            set { this.m_BDoInspect = value; }
        }


        public bool BInspect
        {
            get { return this.m_BInspect; }
            set 
            {
                try
                {
                    Monitor.Enter(this.m_OInterrupt);
                    this.m_OFrontLeftFinder.BeginSyncRecipe();
                    this.m_OFrontRightFinder.BeginSyncRecipe();
                    this.m_OBackLeftFinder.BeginSyncRecipe();
                    this.m_OBackRightFinder.BeginSyncRecipe();

                    this.m_BInspect = value;
                    this.m_OFrontLeftFinder.BInspect = value;
                    this.m_OFrontRightFinder.BInspect = value;
                    this.m_OBackLeftFinder.BInspect = value;
                    this.m_OBackRightFinder.BInspect = value;
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
                finally
                {
                    this.m_OFrontLeftFinder.EndSyncRecipe();
                    this.m_OFrontRightFinder.EndSyncRecipe();
                    this.m_OBackLeftFinder.EndSyncRecipe();
                    this.m_OBackRightFinder.EndSyncRecipe();
                    Monitor.Exit(this.m_OInterrupt);
                }
            }
        }


        public ushort U16IOLine
        {
            get { return this.m_U16IOLine; }
            set { this.m_U16IOLine = value; }
        }


        public bool BReject
        {
            get { return this.m_BReject; }
            set { this.m_BReject = value; }
        }


        public bool BSaveNG
        {
            get { return this.m_BSaveNG; }
            set { this.m_BSaveNG = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        protected CShampFaultTool()
        {
            try
            {
                this.m_OFrontLeftFinder = new CDesignFinderTool(ECAMERA.FRONT_LEFT);
                this.m_OFrontLeftFinder.OExporter = CAcquisitionManager.It.OFrontLeft;
                this.m_OFrontRightFinder = new CDesignFinderTool(ECAMERA.FRONT_RIGHT);
                this.m_OFrontRightFinder.OExporter = CAcquisitionManager.It.OFrontRight;
                this.m_OBackLeftFinder = new CDesignFinderTool(ECAMERA.BACK_LEFT);
                this.m_OBackLeftFinder.OExporter = CAcquisitionManager.It.OBackLeft;
                this.m_OBackRightFinder = new CDesignFinderTool(ECAMERA.BACK_RIGHT);
                this.m_OBackRightFinder.OExporter = CAcquisitionManager.It.OBackRight;

                this.m_LstOInspectionTick = new List<long>();
                this.m_OImageBuffer = new Dictionary<string, CogImage8Grey>();
                this.m_OInterrupt = new object();

                this.BeginWork();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CShampFaultTool()
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
                        Monitor.Enter(this.m_OInterrupt);

                        CShampFaultResult OResult = this.GetResult();

                        if (this.m_BDoInspect == true)
                        {
                            if (OResult != null)
                            {
                                OResult = this.DoInspect(OResult);
                                this.m_LstOInspectionTick.Add(OResult.OTime.Ticks);
                                this.OnInspected(OResult);

                                if ((OResult.BInspected == true) && (OResult.BOK == false))
                                {
                                    if (this.m_BReject == false) CControlBox.It.On(this.U16IOLine);
                                    if (this.m_BSaveNG == true) this.SaveImage(OResult);
                                    this.SaveData(OResult);
                                }

                                GC.Collect();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CError.Ignore(ex);
                    }
                    finally
                    {
                        Monitor.Exit(this.m_OInterrupt);
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


        private CShampFaultResult GetResult()
        {
            CShampFaultResult OResult = null;

            try
            {
                this.m_OFrontLeftFinder.BeginSyncResult();
                this.m_OFrontRightFinder.BeginSyncResult();
                this.m_OBackLeftFinder.BeginSyncResult();
                this.m_OBackRightFinder.BeginSyncResult();

                if ((this.m_OFrontLeftFinder.OResult != null) &&
                    (this.m_OFrontRightFinder.OResult != null) &&
                    (this.m_OBackLeftFinder.OResult != null) &&
                    (this.m_OBackRightFinder.OResult != null))
                {
                    OResult = new CShampFaultResult();
                    OResult.OFrontLeft = (CDesignFinderResult)this.m_OFrontLeftFinder.OResult;
                    OResult.OFrontRight = (CDesignFinderResult)this.m_OFrontRightFinder.OResult;
                    OResult.OBackLeft = (CDesignFinderResult)this.m_OBackLeftFinder.OResult;
                    OResult.OBackRight = (CDesignFinderResult)this.m_OBackRightFinder.OResult;

                    this.m_OFrontLeftFinder.OResult = null;
                    this.m_OFrontRightFinder.OResult = null;
                    this.m_OBackLeftFinder.OResult = null;
                    this.m_OBackRightFinder.OResult = null;
                }
                else if ((this.m_OFrontLeftFinder.OResult != null) ||
                        (this.m_OFrontRightFinder.OResult != null) ||
                        (this.m_OBackLeftFinder.OResult != null) ||
                        (this.m_OBackRightFinder.OResult != null))
                {
                    long I64FirstTick = long.MaxValue;

                    if (this.m_OFrontLeftFinder.OResult != null)
                    {
                        if (I64FirstTick > this.m_OFrontLeftFinder.OResult.OImageInfo.OTime.Ticks)
                        {
                            I64FirstTick = this.m_OFrontLeftFinder.OResult.OImageInfo.OTime.Ticks;
                        }
                    }
                    if (this.m_OFrontRightFinder.OResult != null)
                    {
                        if (I64FirstTick > this.m_OFrontRightFinder.OResult.OImageInfo.OTime.Ticks)
                        {
                            I64FirstTick = this.m_OFrontRightFinder.OResult.OImageInfo.OTime.Ticks;
                        }
                    }
                    if (this.m_OBackLeftFinder.OResult != null)
                    {
                        if (I64FirstTick > this.m_OBackLeftFinder.OResult.OImageInfo.OTime.Ticks)
                        {
                            I64FirstTick = this.m_OBackLeftFinder.OResult.OImageInfo.OTime.Ticks;
                        }
                    }
                    if (this.m_OBackRightFinder.OResult != null)
                    {
                        if (I64FirstTick > this.m_OBackRightFinder.OResult.OImageInfo.OTime.Ticks)
                        {
                            I64FirstTick = this.m_OBackRightFinder.OResult.OImageInfo.OTime.Ticks;
                        }
                    }

                    if (I64FirstTick + 3000000 < DateTime.Now.Ticks)
                    {
                        OResult = new CShampFaultResult();
                        OResult.OFrontLeft = this.m_OFrontLeftFinder.OResult;
                        OResult.OFrontRight = this.m_OFrontRightFinder.OResult;
                        OResult.OBackLeft = this.m_OBackLeftFinder.OResult;
                        OResult.OBackRight = this.m_OBackRightFinder.OResult;

                        this.m_OFrontLeftFinder.OResult = null;
                        this.m_OFrontRightFinder.OResult = null;
                        this.m_OBackLeftFinder.OResult = null;
                        this.m_OBackRightFinder.OResult = null;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.m_OFrontLeftFinder.EndSyncResult();
                this.m_OFrontRightFinder.EndSyncResult();
                this.m_OBackLeftFinder.EndSyncResult();
                this.m_OBackRightFinder.EndSyncResult();
            }

            return OResult;
        }


        private CShampFaultResult DoInspect(CShampFaultResult OSource)
        {
            CShampFaultResult OResult = null;

            try
            {
                if ((this.m_ORecipe != null) && (this.BInspect == true))
                {
                    bool BOK = true;

                    for (int _Index = 1; _Index < 5; _Index++)
                    {
                        if (((this.m_I32FrontLeft != _Index) || (OSource.OFrontLeft == null) || ((this.m_I32FrontLeft == _Index) && (OSource.OFrontLeft.BEnable == false))) &&
                            ((this.m_I32FrontRight != _Index) || (OSource.OFrontRight == null) || ((this.m_I32FrontRight == _Index) && (OSource.OFrontRight.BEnable == false))) &&
                            ((this.m_I32BackLeft != _Index) || (OSource.OBackLeft == null) || ((this.m_I32BackLeft == _Index) && (OSource.OBackLeft.BEnable == false))) &&
                            ((this.m_I32BackRight != _Index) || (OSource.OBackRight == null) || ((this.m_I32BackRight == _Index) && (OSource.OBackRight.BEnable == false))))
                        {
                            continue;
                        }

                        BOK = false;

                        if ((OSource.OFrontLeft != null) && (OSource.OFrontLeft.BEnable == true) && (this.m_I32FrontLeft == _Index))
                        {
                            if ((OSource.OFrontLeft.BInspected == true) && (OSource.OFrontLeft.BOK == true))
                            {
                                BOK = true;
                            }
                        }
                        if ((OSource.OFrontRight != null) && (OSource.OFrontRight.BEnable == true) && (this.m_I32FrontRight == _Index))
                        {
                            if ((OSource.OFrontRight.BInspected == true) && (OSource.OFrontRight.BOK == true))
                            {
                                BOK = true;
                            }
                        }
                        if ((OSource.OBackLeft != null) && (OSource.OBackLeft.BEnable == true) && (this.m_I32BackLeft == _Index))
                        {
                            if ((OSource.OBackLeft.BInspected == true) && (OSource.OBackLeft.BOK == true))
                            {
                                BOK = true;
                            }
                        }
                        if ((OSource.OBackRight != null) && (OSource.OBackRight.BEnable == true) && (this.m_I32BackRight == _Index))
                        {
                            if ((OSource.OBackRight.BInspected == true) && (OSource.OBackRight.BOK == true))
                            {
                                BOK = true;
                            }
                        }

                        if (BOK == false) break;
                    }

                    OSource.BInspected = true;
                    OSource.BOK = BOK;
                }

                OResult = OSource;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }

            return OResult;
        }


        private void SaveImage(CShampFaultResult OResult)
        {
            try
            {
                if (CImageSaveTool.It.BCanSave == true)
                {
                    string StrDirectory = String.Format(".\\불량이미지\\{0:yyyy}\\{0:MM}\\{0:dd}\\{0:HH}-{0:mm}-{0:ss} {0:fff}\\", OResult.OTime);

                    if (OResult.OFrontLeft != null)
                    {
                        OResult.OFrontLeft.StrFile = StrDirectory + "FrontLeft.bmp";
                        this.m_OImageBuffer.Add(OResult.OFrontLeft.StrFile, OResult.OFrontLeft.OImageInfo.OImage);
                    }
                    if (OResult.OFrontRight != null)
                    {
                        OResult.OFrontRight.StrFile = StrDirectory + "FrontRight.bmp";
                        this.m_OImageBuffer.Add(OResult.OFrontRight.StrFile, OResult.OFrontRight.OImageInfo.OImage);
                    }
                    if (OResult.OBackLeft != null)
                    {
                        OResult.OBackLeft.StrFile = StrDirectory + "BackLeft.bmp";
                        this.m_OImageBuffer.Add(OResult.OBackLeft.StrFile, OResult.OBackLeft.OImageInfo.OImage);
                    }
                    if (OResult.OBackRight != null)
                    {
                        OResult.OBackRight.StrFile = StrDirectory + "BackRight.bmp";
                        this.m_OImageBuffer.Add(OResult.OBackRight.StrFile, OResult.OBackRight.OImageInfo.OImage);
                    }

                    CImageSaveTool.It.SetImages(this.m_OImageBuffer);
                    this.m_OImageBuffer.Clear();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void SaveData(CShampFaultResult OResult)
        {
            try
            {
                CDynamicTable OTable = CDB.It.GetDynamicTable(CDB.TABLE_REPORT);
                OTable.BeginSyncData();

                try
                {
                    int I32RowIndex = OTable.InsertRow();
                    OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_DATETIME, OResult.OTime.ToString("yyyy.MM.dd HH:mm:ss fff"));
                    OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_RECIPE, this.m_ORecipe.StrName);
                    OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_FRONT_LEFT_ENABLE, this.m_ORecipe.OFrontLeft.BEnabled);
                    OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_FRONT_RIGHT_ENABLE, this.m_ORecipe.OFrontRight.BEnabled);
                    OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_BACK_LEFT_ENABLE, this.m_ORecipe.OBackLeft.BEnabled);
                    OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_BACK_RIGHT_ENABLE, this.m_ORecipe.OBackRight.BEnabled);
                    OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_FRONT_LEFT_MIN, Convert.ToInt32(this.m_ORecipe.OFrontLeft.F64MinScore));
                    OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_FRONT_RIGHT_MIN, Convert.ToInt32(this.m_ORecipe.OFrontRight.F64MinScore));
                    OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_BACK_LEFT_MIN, Convert.ToInt32(this.m_ORecipe.OBackLeft.F64MinScore));
                    OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_BACK_RIGHT_MIN, Convert.ToInt32(this.m_ORecipe.OBackRight.F64MinScore));

                    if ((OResult.OFrontLeft != null) && (OResult.OFrontLeft.BEnable == true))
                    {
                        OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_FRONT_LEFT_SCORE, OResult.OFrontLeft.I32Score.ToString());
                        OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_FRONT_LEFT_FILE, OResult.OFrontLeft.StrFile);
                    }
                    else
                    {
                        OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_FRONT_LEFT_SCORE, "-");
                    }
                    if ((OResult.OFrontRight != null) && (OResult.OFrontRight.BEnable == true))
                    {
                        OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_FRONT_RIGHT_SCORE, OResult.OFrontRight.I32Score.ToString());
                        OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_FRONT_RIGHT_FILE, OResult.OFrontRight.StrFile);
                    }
                    else
                    {
                        OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_FRONT_RIGHT_SCORE, "-");
                    }
                    if ((OResult.OBackLeft != null) && (OResult.OBackLeft.BEnable == true))
                    {
                        OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_BACK_LEFT_SCORE, OResult.OBackLeft.I32Score.ToString());
                        OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_BACK_LEFT_FILE, OResult.OBackLeft.StrFile);
                    }
                    else
                    {
                        OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_BACK_LEFT_SCORE, "-");
                    }
                    if ((OResult.OBackRight != null) && (OResult.OBackRight.BEnable == true))
                    {
                        OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_BACK_RIGHT_SCORE, OResult.OBackRight.I32Score.ToString());
                        OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_BACK_RIGHT_FILE, OResult.OBackRight.StrFile);
                    }
                    else
                    {
                        OTable.Update(I32RowIndex, CDB.REPORT_COLUMN_BACK_RIGHT_SCORE, "-");
                    }
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
                finally
                {
                    OTable.EndSyncData();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public int GetInspectionCount()
        {
            int I32Result = 0;

            try
            {
                Monitor.Enter(this.m_OInterrupt);

                long I32Tick = DateTime.Now.Ticks;
                if (this.m_LstOInspectionTick.Count > 0)
                {
                    while (I32Tick - this.m_LstOInspectionTick[0] > 600000000)
                    {
                        this.m_LstOInspectionTick.RemoveAt(0);
                        if (this.m_LstOInspectionTick.Count == 0) break;
                    }
                }

                I32Result = this.m_LstOInspectionTick.Count;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }

            return I32Result;
        }


        private void OnRecipeChanged(IRecipe ORecipe)
        {
            try
            {
                if (this.RecipeChanged != null)
                {
                    this.RecipeChanged(ORecipe);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void OnInspected(CShampFaultResult OResult)
        {
            try
            {
                if (this.Inspected != null)
                {
                    this.Inspected(OResult);
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
                this.EndWork();

                if (this.m_OFrontLeftFinder != null)
                {
                    this.m_OFrontLeftFinder.Dispose();
                    this.m_OFrontLeftFinder = null;
                }
                if (this.m_OFrontRightFinder != null)
                {
                    this.m_OFrontRightFinder.Dispose();
                    this.m_OFrontRightFinder = null;
                }
                if (this.m_OBackLeftFinder != null)
                {
                    this.m_OBackLeftFinder.Dispose();
                    this.m_OBackLeftFinder = null;
                }
                if (this.m_OBackRightFinder != null)
                {
                    this.m_OBackRightFinder.Dispose();
                    this.m_OBackRightFinder = null;
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
