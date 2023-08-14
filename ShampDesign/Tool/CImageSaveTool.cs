using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Threading;

using Cognex.VisionPro;
using Jhjo.Util.Print;


namespace ShampDesign
{
    public class CImageSaveTool : IDisposable
    {
        #region SINGLE TON
        private static CImageSaveTool Src_It = null;
        
        public static CImageSaveTool It
        {
            get
            {
                CImageSaveTool OResult = null;

                try
                {
                    if (CImageSaveTool.Src_It == null)
                    {
                        CImageSaveTool.Src_It = new CImageSaveTool();
                    }

                    OResult = CImageSaveTool.Src_It;
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
        private Dictionary<string, CogImage8Grey> m_OBuffer = null;
        private object m_OInterrupt = null;
        
        private Thread m_OWorker = null;
        private bool m_BDoWork = false;

        private string m_StrPath = string.Empty;
        private CogImage8Grey m_OSource = null;
        private Bitmap m_OTarget = null;
        #endregion


        #region PROPERTIES
        public bool BCanSave
        {
            get
            {
                bool BResult = true;

                try
                {
                    Monitor.Enter(this.m_OInterrupt);
                    BResult = (this.m_OBuffer.Count <= 100);
                }
                catch (Exception ex)
                {
                    CError.Throw(ex);
                }
                finally
                {
                    Monitor.Exit(this.m_OInterrupt);
                }

                return BResult;
            }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public CImageSaveTool()
        {
            try
            {
                this.m_OBuffer = new Dictionary<string, CogImage8Grey>();
                this.m_OInterrupt = new object();

                this.BeginWork();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CImageSaveTool()
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
                        while (this.GetImage(out this.m_StrPath, out this.m_OSource) == true)
                        {
                            FileInfo OFile = new FileInfo(this.m_StrPath);
                            if (OFile.Directory.Exists == false)
                            {
                                OFile.Directory.Create();
                            }

                            this.m_OTarget = this.m_OSource.ToBitmap();
                            this.m_OTarget.Save(this.m_StrPath);
                            this.m_OTarget.Dispose();
                            this.m_OTarget = null;
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


        public void SetImage(string StrPath, CogImage8Grey OImage)
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);
                this.m_OBuffer.Add(StrPath, OImage);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }
        }


        public void SetImages(Dictionary<string, CogImage8Grey> OImages)
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);

                foreach (string _Item in OImages.Keys)
                {
                    this.m_OBuffer.Add(_Item, OImages[_Item]);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }
        }

        private bool GetImage(out string StrPath, out CogImage8Grey OImage)
        {
            bool BResult = false;
            StrPath = string.Empty;
            OImage = null;

            try
            {
                Monitor.Enter(this.m_OInterrupt);

                if (this.m_OBuffer.Count > 0)
                {
                    KeyValuePair<string, CogImage8Grey> OItem = this.m_OBuffer.ElementAt(0);
                    this.m_OBuffer.Remove(OItem.Key);

                    StrPath = OItem.Key;
                    OImage = OItem.Value;
                    BResult = true;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                Monitor.Exit(this.m_OInterrupt);
            }

            return BResult;
        }

        public void Dispose()
        {
            try
            {
                this.EndWork();

                if (this.m_OBuffer != null)
                {
                    this.m_OBuffer.Clear();
                    this.m_OBuffer = null;
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
