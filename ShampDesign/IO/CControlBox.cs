using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jhjo.Util.Print;
using System.Threading;

namespace ShampDesign
{
    public class CControlBox : IDisposable
    {
        #region SINGLE TON
        private static CControlBox Src_It = null;

        public static CControlBox It
        {
            get
            {
                CControlBox OResult = null;

                try
                {
                    if (CControlBox.Src_It == null)
                    {
                        CControlBox.Src_It = new CControlBox();
                    }

                    OResult = CControlBox.Src_It;
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
        private ushort m_U16Card = 0;
        private bool m_BRegisted = false;

        private List<CIOSignal> m_LstOSignal = null;

        private Thread m_OWorker = null;
        private bool m_BDoWork = false;

        private object m_OInterrupt = null;
        #endregion


        #region PROPERTIES
        public List<CIOSignal> LstOSignal
        {
            get { return this.m_LstOSignal; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        protected CControlBox()
        {
            try
            {
                this.Regist();

                this.m_LstOSignal = new List<CIOSignal>();
                if (this.m_BRegisted == true)
                {
                    for (ushort _Index = 0; _Index < 16; _Index++)
                    {
                        this.m_LstOSignal.Add(new CIOSignal(this.m_U16Card, _Index));
                    }
                }
                this.m_OInterrupt = new object();

                this.BeginWork();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        ~CControlBox()
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
        private void Regist()
        {
            try
            {
                this.m_U16Card = (ushort)CPCI7230.Register_Card(CPCI7230.PCI_7230, 0);
                CPCI7230.DO_WriteLine(this.m_U16Card, 0, 1, 1);
                this.m_BRegisted = true;
            }
            catch
            {
                this.m_BRegisted = false;
            }
        }


        public void On(ushort U16Line)
        {
            try
            {
                this.BeginSync();

                foreach (CIOSignal _Item in this.m_LstOSignal)
                {
                    if (_Item.U16Line != U16Line) continue;

                    _Item.On();
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.EndSync();
            }
        }


        public void Off(ushort U16Line)
        {
            try
            {
                this.BeginSync();

                foreach (CIOSignal _Item in this.m_LstOSignal)
                {
                    if (_Item.U16Line != U16Line) continue;

                    _Item.Off();
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.EndSync();
            }
        }


        private void Release()
        {
            try
            {
                if (this.m_BRegisted == true)
                {
                    CPCI7230.DO_WriteLine(this.m_U16Card, 0, 1, 0);
                    CPCI7230.Release_Card(this.m_U16Card);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


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

                        foreach (CIOSignal _Item in this.m_LstOSignal)
                        {
                            _Item.Process();
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
                CError.Ignore(ex);
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
                CError.Ignore(ex);
            }
        }


        public void BeginSync()
        {
            try
            {
                Monitor.Enter(this.m_OInterrupt);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public void EndSync()
        {
            try
            {
                Monitor.Exit(this.m_OInterrupt);
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
                this.Release();
            }
            catch (Exception ex)
            {
                CError.Ignore(ex);
            }
        }
        #endregion
    }
}

    
