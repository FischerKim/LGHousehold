using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Util.Print;
using Daekhon.Common;

namespace ShampDesign
{
    public partial class frmMain : Form
    {
        #region VARIABLE
        private UcScreen m_OScreen = null;
        private UcHome m_OHome = null;
        private UcRecipe m_ORecipe = null;
        private UcReport m_OReport = null;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public frmMain()
        {
            InitializeComponent();
        }
        #endregion


        #region EVENT
        #region FORM EVENT
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                this.SetToolRule();
                this.ReadyRecipe();
                this.ReadyIO();

                this.m_OHome = new UcHome();
                this.m_OHome.Dock = DockStyle.Fill;
                this.m_OHome.ScreenFixed += new UcScreen.ScreenFixedHandler(this.OScreen_ScreenFixed);
                this.m_ORecipe = new UcRecipe();
                this.m_ORecipe.Dock = DockStyle.Fill;
                this.m_ORecipe.ScreenFixed += new UcScreen.ScreenFixedHandler(this.OScreen_ScreenFixed);
                this.m_OReport = new UcReport();
                this.m_OReport.Dock = DockStyle.Fill;
                this.m_OReport.ScreenFixed += new UcScreen.ScreenFixedHandler(this.OScreen_ScreenFixed);

                this.m_OHome.OnAdd();
                this.PnlBody.Controls.Add(this.m_OHome);
                this.m_OScreen = this.m_OHome;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region BUTTON EVENT
        private void BtnHome_Click(object sender, EventArgs e)
        {
            try
            {
                this.DisplayScreen(this.m_OHome);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void BtnRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                this.DisplayScreen(this.m_ORecipe);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void BtnReport_Click(object sender, EventArgs e)
        {
            try
            {
                this.DisplayScreen(this.m_OReport);
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion


        #region ETC EVENT
        private void Timer1000_Tick(object sender, EventArgs e)
        {
            try
            {
                this.LblTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                if (this.m_OScreen != null)
                {
                    this.m_OScreen.OnTimer1000();
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void OShampFaultTool_RecipeChanged(IRecipe ORecipe)
        {
            try
            {
                this.LblReicpe.Text = (ORecipe != null) ? ORecipe.StrName : string.Empty;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void OScreen_ScreenFixed(bool BFixed)
        {
            try
            {
                if (BFixed == true)
                {
                    this.BtnHome.BackColor = SystemColors.Control;
                    this.BtnRecipe.BackColor = SystemColors.Control;
                    this.BtnReport.BackColor = SystemColors.Control;
                    this.BtnExit.BackColor = SystemColors.Control;

                    this.BtnHome.Enabled = false;
                    this.BtnRecipe.Enabled = false;
                    this.BtnReport.Enabled = false;
                    this.BtnExit.Enabled = false;
                }
                else
                {
                    this.BtnHome.BackColor = Color.SteelBlue;
                    this.BtnRecipe.BackColor = Color.SteelBlue;
                    this.BtnReport.BackColor = Color.SteelBlue;
                    this.BtnExit.BackColor = Color.SteelBlue;

                    this.BtnHome.Enabled = true;
                    this.BtnRecipe.Enabled = true;
                    this.BtnReport.Enabled = true;
                    this.BtnExit.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
        #endregion


        #region FUNCTION
        private void SetToolRule()
        {
            try
            {
                int I32RowIndex1 = CDB.It[CDB.TABLE_TOOL_RULER].SelectRowIndex(CDB.TOOL_RULER_COLUMN_SEQ, 1);
                int I32RowIndex2 = CDB.It[CDB.TABLE_TOOL_RULER].SelectRowIndex(CDB.TOOL_RULER_COLUMN_SEQ, 2);
                int I32RowIndex3 = CDB.It[CDB.TABLE_TOOL_RULER].SelectRowIndex(CDB.TOOL_RULER_COLUMN_SEQ, 3);
                int I32RowIndex4 = CDB.It[CDB.TABLE_TOOL_RULER].SelectRowIndex(CDB.TOOL_RULER_COLUMN_SEQ, 4);

                ECAMERA[] ArrECamera = new ECAMERA[4];
                ArrECamera[0] = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex1, CDB.TOOL_RULER_COLUMN_CAMERA));
                ArrECamera[1] = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex2, CDB.TOOL_RULER_COLUMN_CAMERA));
                ArrECamera[2] = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex3, CDB.TOOL_RULER_COLUMN_CAMERA));
                ArrECamera[3] = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex4, CDB.TOOL_RULER_COLUMN_CAMERA));
                int[] ArrI32Index = new int[4];
                ArrI32Index[0] = (int)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex1, CDB.TOOL_RULER_COLUMN_INDEX);
                ArrI32Index[1] = (int)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex2, CDB.TOOL_RULER_COLUMN_INDEX);
                ArrI32Index[2] = (int)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex3, CDB.TOOL_RULER_COLUMN_INDEX);
                ArrI32Index[3] = (int)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex4, CDB.TOOL_RULER_COLUMN_INDEX);
                

                for (int _Index = 0; _Index < ArrECamera.Length; _Index++)
                {
                    switch (ArrECamera[_Index])
                    {
                        case ECAMERA.FRONT_LEFT:
                            CShampFaultTool.It.I32FrontLeft = ArrI32Index[_Index];
                            break;

                        case ECAMERA.FRONT_RIGHT:
                            CShampFaultTool.It.I32FrontRight = ArrI32Index[_Index];
                            break;

                        case ECAMERA.BACK_LEFT:
                            CShampFaultTool.It.I32BackLeft = ArrI32Index[_Index];
                            break;

                        case ECAMERA.BACK_RIGHT:
                            CShampFaultTool.It.I32BackRight = ArrI32Index[_Index];
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void ReadyRecipe()
        {
            try
            {
                string StrRecipe = CEnvironment.It.StrMainRecipe;
                if (String.IsNullOrEmpty(StrRecipe) == false)
                {
                    this.LblReicpe.Text = StrRecipe;

                    foreach (CShampFaultRecipe _Item in CRecipeManager.It.LstORecipe)
                    {
                        if (_Item.StrName != StrRecipe) continue;

                        CShampFaultTool.It.ORecipe = new CShampFaultRecipe(_Item);
                        break;
                    }
                }

                CShampFaultTool.It.RecipeChanged = this.OShampFaultTool_RecipeChanged;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void ReadyIO()
        {
            try
            {
                CControlBox.It.BeginSync();



                foreach (CIOSignal _Item in CControlBox.It.LstOSignal)
                {
                    if (_Item.U16Line == CEnvironment.It.U16ReadyPort)
                    {
                        CIOPulser OProcessor = new CIOPulser();
                        OProcessor.I32OnInterval = CEnvironment.It.I32ReadyOnInterval;
                        OProcessor.I32OffInterval = CEnvironment.It.I32ReadyOffInterval;

                        _Item.OProcessor = OProcessor;
                    }

                    if (_Item.U16Line == CEnvironment.It.U16NGPort)
                    {
                        CIOGeneral OProcessor = new CIOGeneral();
                        OProcessor.I32Interval = CEnvironment.It.I32NGInterval;

                        _Item.OProcessor = OProcessor;
                    }
                }

                CShampFaultTool.It.U16IOLine = CEnvironment.It.U16NGPort;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                CControlBox.It.EndSync();
            }
        }


        private void DisplayScreen(UcScreen OScreen)
        {
            try
            {
                if (this.m_OScreen.GetType() != OScreen.GetType())
                {
                    this.m_OScreen.OnRemove();
                    OScreen.OnAdd();

                    this.PnlBody.Controls.Add(OScreen);
                    OScreen.BringToFront();
                    this.PnlBody.Controls.Remove(this.m_OScreen);

                    this.m_OScreen = OScreen;
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
