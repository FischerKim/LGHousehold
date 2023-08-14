using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Util.Print;
using System.IO;
using Daekhon.Common;

namespace ShampDesign
{
    public partial class UcHome : UcScreen
    {
        #region VARIABLE
        private bool m_BInspected = true;
        private bool m_BOK = true;

        private long m_I64TotalCount = 0;
        private long m_I64OKCount = 0;
        private long m_I64NGCount = 0;

        private CShampFaultResult m_OResult = null;
        private List<CShampFaultResult> m_LstONG = null;

        private bool m_BPreventEvent = false;
        #endregion
        

        #region CONSTRUCTOR & DESTRUCTOR
        public UcHome()
        {
            InitializeComponent();

            try
            {
                this.m_BPreventEvent = true;

                if (CAcquisitionManager.It.OFrontLeft != null)
                {
                    this.TrkFrontLeftGain.Maximum = CAcquisitionManager.It.OFrontLeft.I32GainMax;
                    this.TrkFrontLeftGain.Minimum = CAcquisitionManager.It.OFrontLeft.I32GainMin;
                    this.TrkFrontLeftGain.Value = CAcquisitionManager.It.OFrontLeft.I32Gain;
                    this.NudFrontLeftGain.Maximum = this.TrkFrontLeftGain.Maximum;
                    this.NudFrontLeftGain.Minimum = this.TrkFrontLeftGain.Minimum;
                    this.NudFrontLeftGain.Value = this.TrkFrontLeftGain.Value;


                    this.TrkFrontLeftExposureTime.Maximum = CAcquisitionManager.It.OFrontLeft.I32ExposureTimeMax;
                    this.TrkFrontLeftExposureTime.Minimum = CAcquisitionManager.It.OFrontLeft.I32ExposureTimeMin;
                    this.TrkFrontLeftExposureTime.Value = CAcquisitionManager.It.OFrontLeft.I32ExposureTime;
                    this.NudFrontLeftExposureTime.Maximum = this.TrkFrontLeftExposureTime.Maximum;
                    this.NudFrontLeftExposureTime.Minimum = this.TrkFrontLeftExposureTime.Minimum;
                    this.NudFrontLeftExposureTime.Value = this.TrkFrontLeftExposureTime.Value;
                }
                else
                {
                    this.NudFrontLeftGain.Controls[1].Text = string.Empty;
                    this.BtnApplyFrontLeftGain.BackColor = SystemColors.Control;
                    this.NudFrontLeftExposureTime.Controls[1].Text = string.Empty;
                    this.BtnApplyFrontLeftExposureTime.BackColor = SystemColors.Control;
                    
                    this.TrkFrontLeftGain.Enabled = false;
                    this.NudFrontLeftGain.Enabled = false;
                    this.BtnApplyFrontLeftGain.Enabled = false;
                    this.TrkFrontLeftExposureTime.Enabled = false;
                    this.NudFrontLeftExposureTime.Enabled = false;
                    this.BtnApplyFrontLeftExposureTime.Enabled = false;
                }

                if (CAcquisitionManager.It.OFrontRight != null)
                {
                    this.TrkFrontRightGain.Maximum = CAcquisitionManager.It.OFrontRight.I32GainMax;
                    this.TrkFrontRightGain.Minimum = CAcquisitionManager.It.OFrontRight.I32GainMin;
                    this.TrkFrontRightGain.Value = CAcquisitionManager.It.OFrontRight.I32Gain;
                    this.NudFrontRightGain.Maximum = this.TrkFrontRightGain.Maximum;
                    this.NudFrontRightGain.Minimum = this.TrkFrontRightGain.Minimum;
                    this.NudFrontRightGain.Value = this.TrkFrontRightGain.Value;


                    this.TrkFrontRightExposureTime.Maximum = CAcquisitionManager.It.OFrontRight.I32ExposureTimeMax;
                    this.TrkFrontRightExposureTime.Minimum = CAcquisitionManager.It.OFrontRight.I32ExposureTimeMin;
                    this.TrkFrontRightExposureTime.Value = CAcquisitionManager.It.OFrontRight.I32ExposureTime;
                    this.NudFrontRightExposureTime.Maximum = this.TrkFrontRightExposureTime.Maximum;
                    this.NudFrontRightExposureTime.Minimum = this.TrkFrontRightExposureTime.Minimum;
                    this.NudFrontRightExposureTime.Value = this.TrkFrontRightExposureTime.Value;
                }
                else
                {
                    this.NudFrontRightGain.Controls[1].Text = string.Empty;
                    this.BtnApplyFrontRightGain.BackColor = SystemColors.Control;
                    this.NudFrontRightExposureTime.Controls[1].Text = string.Empty;
                    this.BtnApplyFrontRightExposureTime.BackColor = SystemColors.Control;

                    this.TrkFrontRightGain.Enabled = false;
                    this.NudFrontRightGain.Enabled = false;
                    this.BtnApplyFrontRightGain.Enabled = false;
                    this.TrkFrontRightExposureTime.Enabled = false;
                    this.NudFrontRightExposureTime.Enabled = false;
                    this.BtnApplyFrontRightExposureTime.Enabled = false;
                }

                if (CAcquisitionManager.It.OBackLeft != null)
                {
                    this.TrkBackLeftGain.Maximum = CAcquisitionManager.It.OBackLeft.I32GainMax;
                    this.TrkBackLeftGain.Minimum = CAcquisitionManager.It.OBackLeft.I32GainMin;
                    this.TrkBackLeftGain.Value = CAcquisitionManager.It.OBackLeft.I32Gain;
                    this.NudBackLeftGain.Maximum = this.TrkBackLeftGain.Maximum;
                    this.NudBackLeftGain.Minimum = this.TrkBackLeftGain.Minimum;
                    this.NudBackLeftGain.Value = this.TrkBackLeftGain.Value;


                    this.TrkBackLeftExposureTime.Maximum = CAcquisitionManager.It.OBackLeft.I32ExposureTimeMax;
                    this.TrkBackLeftExposureTime.Minimum = CAcquisitionManager.It.OBackLeft.I32ExposureTimeMin;
                    this.TrkBackLeftExposureTime.Value = CAcquisitionManager.It.OBackLeft.I32ExposureTime;
                    this.NudBackLeftExposureTime.Maximum = this.TrkBackLeftExposureTime.Maximum;
                    this.NudBackLeftExposureTime.Minimum = this.TrkBackLeftExposureTime.Minimum;
                    this.NudBackLeftExposureTime.Value = this.TrkBackLeftExposureTime.Value;
                }
                else
                {
                    this.NudBackLeftGain.Controls[1].Text = string.Empty;
                    this.BtnApplyBackLeftGain.BackColor = SystemColors.Control;
                    this.NudBackLeftExposureTime.Controls[1].Text = string.Empty;
                    this.BtnApplyBackLeftExposureTime.BackColor = SystemColors.Control;

                    this.TrkBackLeftGain.Enabled = false;
                    this.NudBackLeftGain.Enabled = false;
                    this.BtnApplyBackLeftGain.Enabled = false;
                    this.TrkBackLeftExposureTime.Enabled = false;
                    this.NudBackLeftExposureTime.Enabled = false;
                    this.BtnApplyBackLeftExposureTime.Enabled = false;
                }

                if (CAcquisitionManager.It.OBackRight != null)
                {
                    this.TrkBackRightGain.Maximum = CAcquisitionManager.It.OBackRight.I32GainMax;
                    this.TrkBackRightGain.Minimum = CAcquisitionManager.It.OBackRight.I32GainMin;
                    this.TrkBackRightGain.Value = CAcquisitionManager.It.OBackRight.I32Gain;
                    this.NudBackRightGain.Maximum = this.TrkBackRightGain.Maximum;
                    this.NudBackRightGain.Minimum = this.TrkBackRightGain.Minimum;
                    this.NudBackRightGain.Value = this.TrkBackRightGain.Value;


                    this.TrkBackRightExposureTime.Maximum = CAcquisitionManager.It.OBackRight.I32ExposureTimeMax;
                    this.TrkBackRightExposureTime.Minimum = CAcquisitionManager.It.OBackRight.I32ExposureTimeMin;
                    this.TrkBackRightExposureTime.Value = CAcquisitionManager.It.OBackRight.I32ExposureTime;
                    this.NudBackRightExposureTime.Maximum = this.TrkBackRightExposureTime.Maximum;
                    this.NudBackRightExposureTime.Minimum = this.TrkBackRightExposureTime.Minimum;
                    this.NudBackRightExposureTime.Value = this.TrkBackRightExposureTime.Value;
                }
                else
                {
                    this.NudBackRightGain.Controls[1].Text = string.Empty;
                    this.BtnApplyBackRightGain.BackColor = SystemColors.Control;
                    this.NudBackRightExposureTime.Controls[1].Text = string.Empty;
                    this.BtnApplyBackRightExposureTime.BackColor = SystemColors.Control;

                    this.TrkBackRightGain.Enabled = false;
                    this.NudBackRightGain.Enabled = false;
                    this.BtnApplyBackRightGain.Enabled = false;
                    this.TrkBackRightExposureTime.Enabled = false;
                    this.NudBackRightExposureTime.Enabled = false;
                    this.BtnApplyBackRightExposureTime.Enabled = false;
                }

                this.m_LstONG = new List<CShampFaultResult>();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }
        #endregion


        #region EVENT
        #region BUTTON EVENT
        private void BtnApplyGain_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_BPreventEvent = true;

                ECAMERA ECamera = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)((Control)sender).Tag);

                if (ECamera == ECAMERA.FRONT_LEFT)
                {
                    int I32Value = Convert.ToInt32(this.NudFrontLeftGain.Value);

                    if (CAcquisitionManager.It.OFrontLeft != null)
                    {
                        CAcquisitionManager.It.OFrontLeft.I32Gain = I32Value;
                        this.TrkFrontLeftGain.Value = I32Value;
                    }
                }
                else if (ECamera == ECAMERA.FRONT_RIGHT)
                {
                    int I32Value = Convert.ToInt32(this.NudFrontRightGain.Value);

                    if (CAcquisitionManager.It.OFrontRight != null)
                    {
                        CAcquisitionManager.It.OFrontRight.I32Gain = I32Value;
                        this.TrkFrontRightGain.Value = I32Value;
                    }
                }
                else if (ECamera == ECAMERA.BACK_LEFT)
                {
                    int I32Value = Convert.ToInt32(this.NudBackLeftGain.Value);

                    if (CAcquisitionManager.It.OBackLeft != null)
                    {
                        CAcquisitionManager.It.OBackLeft.I32Gain = I32Value;
                        this.TrkBackLeftGain.Value = I32Value;
                    }
                }
                else if (ECamera == ECAMERA.BACK_RIGHT)
                {
                    int I32Value = Convert.ToInt32(this.NudBackRightGain.Value);

                    if (CAcquisitionManager.It.OBackRight != null)
                    {
                        CAcquisitionManager.It.OBackRight.I32Gain = I32Value;
                        this.TrkBackRightGain.Value = I32Value;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }


        private void BtnApplyExposureTime_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_BPreventEvent = true;

                ECAMERA ECamera = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)((Control)sender).Tag);

                if (ECamera == ECAMERA.FRONT_LEFT)
                {
                    int I32Value = Convert.ToInt32(this.NudFrontLeftExposureTime.Value);

                    if (CAcquisitionManager.It.OFrontLeft != null)
                    {
                        CAcquisitionManager.It.OFrontLeft.I32ExposureTime = I32Value;
                        this.TrkFrontLeftExposureTime.Value = I32Value;
                    }
                }
                else if (ECamera == ECAMERA.FRONT_RIGHT)
                {
                    int I32Value = Convert.ToInt32(this.NudFrontRightExposureTime.Value);

                    if (CAcquisitionManager.It.OFrontRight != null)
                    {
                        CAcquisitionManager.It.OFrontRight.I32ExposureTime = I32Value;
                        this.TrkFrontRightExposureTime.Value = I32Value;
                    }
                }
                else if (ECamera == ECAMERA.BACK_LEFT)
                {
                    int I32Value = Convert.ToInt32(this.NudBackLeftExposureTime.Value);

                    if (CAcquisitionManager.It.OBackLeft != null)
                    {
                        CAcquisitionManager.It.OBackLeft.I32ExposureTime = I32Value;
                        this.TrkBackLeftExposureTime.Value = I32Value;
                    }
                }
                else if (ECamera == ECAMERA.BACK_RIGHT)
                {
                    int I32Value = Convert.ToInt32(this.NudBackRightExposureTime.Value);

                    if (CAcquisitionManager.It.OBackRight != null)
                    {
                        CAcquisitionManager.It.OBackRight.I32ExposureTime = I32Value;
                        this.TrkBackRightExposureTime.Value = I32Value;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }


        private void BtnApplyMinScore_Click(object sender, EventArgs e)
        {
            try
            {
                string StrName = CShampFaultTool.It.ORecipe.StrName;

                List<int> LstI32RowIndex = CDB.It[CDB.TABLE_RECIPE_INFO].SelectRowIndexs
                (
                    new string[] { CDB.RECIPE_INFO_COLUMN_RECIPE, CDB.RECIPE_INFO_COLUMN_DIRECTION },
                    new object[] { StrName, ECAMERA.FRONT_LEFT.ToString() }
                );
                CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_MIN_SCORE, Convert.ToDouble(this.NudCam1MinScore.Value));

                LstI32RowIndex = CDB.It[CDB.TABLE_RECIPE_INFO].SelectRowIndexs
                (
                    new string[] { CDB.RECIPE_INFO_COLUMN_RECIPE, CDB.RECIPE_INFO_COLUMN_DIRECTION },
                    new object[] { StrName, ECAMERA.FRONT_RIGHT.ToString() }
                );
                CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_MIN_SCORE, Convert.ToDouble(this.NudCam2MinScore.Value));

                LstI32RowIndex = CDB.It[CDB.TABLE_RECIPE_INFO].SelectRowIndexs
                (
                    new string[] { CDB.RECIPE_INFO_COLUMN_RECIPE, CDB.RECIPE_INFO_COLUMN_DIRECTION },
                    new object[] { StrName, ECAMERA.BACK_LEFT.ToString() }
                );
                CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_MIN_SCORE, Convert.ToDouble(this.NudCam2MinScore.Value));

                LstI32RowIndex = CDB.It[CDB.TABLE_RECIPE_INFO].SelectRowIndexs
                (
                    new string[] { CDB.RECIPE_INFO_COLUMN_RECIPE, CDB.RECIPE_INFO_COLUMN_DIRECTION },
                    new object[] { StrName, ECAMERA.BACK_RIGHT.ToString() }
                );
                CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_MIN_SCORE, Convert.ToDouble(this.NudCam2MinScore.Value));
                CDB.It[CDB.TABLE_RECIPE_INFO].Commit();


                foreach (IRecipe _Item in CRecipeManager.It.LstORecipe)
                {
                    if (_Item.StrName != StrName) continue;

                    ((CShampFaultRecipe)_Item).OFrontLeft.F64MinScore = Convert.ToInt32(this.NudCam1MinScore.Value);
                    ((CShampFaultRecipe)_Item).OFrontRight.F64MinScore = Convert.ToInt32(this.NudCam2MinScore.Value);
                    ((CShampFaultRecipe)_Item).OBackLeft.F64MinScore = Convert.ToInt32(this.NudCam3MinScore.Value);
                    ((CShampFaultRecipe)_Item).OBackRight.F64MinScore = Convert.ToInt32(this.NudCam4MinScore.Value);
                    break;
                }

                ((CShampFaultRecipe)CShampFaultTool.It.ORecipe).OFrontLeft.F64MinScore = Convert.ToInt32(this.NudCam1MinScore.Value);
                ((CShampFaultRecipe)CShampFaultTool.It.ORecipe).OFrontRight.F64MinScore = Convert.ToInt32(this.NudCam2MinScore.Value);
                ((CShampFaultRecipe)CShampFaultTool.It.ORecipe).OBackLeft.F64MinScore = Convert.ToInt32(this.NudCam3MinScore.Value);
                ((CShampFaultRecipe)CShampFaultTool.It.ORecipe).OBackRight.F64MinScore = Convert.ToInt32(this.NudCam4MinScore.Value);
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnIOController_Click(object sender, EventArgs e)
        {
            try
            {
                frmIOController OWindow = new frmIOController();
                OWindow.U16ReadyPort = CEnvironment.It.U16ReadyPort;
                OWindow.I32ReadyOnInterval = CEnvironment.It.I32ReadyOnInterval;
                OWindow.I32ReadyOffInterval = CEnvironment.It.I32ReadyOffInterval;
                OWindow.U16NGPort = CEnvironment.It.U16NGPort;
                OWindow.I32NGInterval = CEnvironment.It.I32NGInterval;

                if (OWindow.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        CControlBox.It.BeginSync();

                        foreach (CIOSignal _Item in CControlBox.It.LstOSignal)
                        {
                            if (_Item.U16Line == CEnvironment.It.U16ReadyPort)
                            {
                                if (_Item.BOn == true)
                                {
                                    _Item.Off();
                                }

                                _Item.OProcessor = null;
                            }
                            if (_Item.U16Line == CEnvironment.It.U16NGPort)
                            {
                                if (_Item.BOn == true)
                                {
                                    _Item.Off();
                                }

                                _Item.OProcessor = null;
                            }
                        }

                        foreach (CIOSignal _Item in CControlBox.It.LstOSignal)
                        {
                            if (_Item.U16Line == OWindow.U16ReadyPort)
                            {
                                CIOPulser OProcessor = new CIOPulser();
                                OProcessor.I32OnInterval = OWindow.I32ReadyOnInterval;
                                OProcessor.I32OffInterval = OWindow.I32ReadyOffInterval;

                                _Item.OProcessor = OProcessor;
                            }

                            if (_Item.U16Line == OWindow.U16NGPort)
                            {
                                CIOGeneral OProcessor = new CIOGeneral();
                                OProcessor.I32Interval = OWindow.I32NGInterval;

                                _Item.OProcessor = OProcessor;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        CError.Throw(ex);
                    }
                    finally
                    {
                        CControlBox.It.EndSync();
                    }

                    CShampFaultTool.It.U16IOLine = OWindow.U16NGPort;

                    CEnvironment.It.U16ReadyPort = OWindow.U16ReadyPort;
                    CEnvironment.It.I32ReadyOnInterval = OWindow.I32ReadyOnInterval;
                    CEnvironment.It.I32ReadyOffInterval = OWindow.I32ReadyOffInterval;
                    CEnvironment.It.U16NGPort = OWindow.U16NGPort;
                    CEnvironment.It.I32NGInterval = OWindow.I32NGInterval;
                    CEnvironment.It.Commit();
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_I64TotalCount = 0;
                this.m_I64OKCount = 0;
                this.m_I64NGCount = 0;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                CShampFaultTool.It.BDoInspect = true;
                if (CAcquisitionManager.It.OFrontLeft != null) CAcquisitionManager.It.OFrontLeft.Start();
                if (CAcquisitionManager.It.OFrontRight != null) CAcquisitionManager.It.OFrontRight.Start();
                if (CAcquisitionManager.It.OBackLeft != null) CAcquisitionManager.It.OBackLeft.Start();
                if (CAcquisitionManager.It.OBackRight != null) CAcquisitionManager.It.OBackRight.Start();


                foreach (CIOSignal _Item in CControlBox.It.LstOSignal)
                {
                    if (_Item.U16Line != CEnvironment.It.U16ReadyPort) continue;

                    if (_Item.OProcessor != null)
                    {
                        _Item.OProcessor.BEnabled = true;
                    }
                    break;
                }

                
                this.BtnStart.BackColor = SystemColors.Control;
                this.BtnStop.BackColor = Color.SteelBlue;
                this.BtnStart.Enabled = false;
                this.BtnStop.Enabled = true;

                this.ChkLive.Enabled = false;
                this.BtnIOController.Enabled = false;
                this.BtnIOController.BackColor = SystemColors.Control;

                base.OnScreenFixed(true);
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                CShampFaultTool.It.BDoInspect = false;
                if (CAcquisitionManager.It.OFrontLeft != null) CAcquisitionManager.It.OFrontLeft.Stop();
                if (CAcquisitionManager.It.OFrontRight != null) CAcquisitionManager.It.OFrontRight.Stop();
                if (CAcquisitionManager.It.OBackLeft != null) CAcquisitionManager.It.OBackLeft.Stop();
                if (CAcquisitionManager.It.OBackRight != null) CAcquisitionManager.It.OBackRight.Stop();


                foreach (CIOSignal _Item in CControlBox.It.LstOSignal)
                {
                    if (_Item.U16Line != CEnvironment.It.U16ReadyPort) continue;

                    if (_Item.OProcessor != null)
                    {
                        _Item.OProcessor.BEnabled = false;
                    }
                    break;
                }


                this.BtnStart.BackColor = Color.SteelBlue;
                this.BtnStop.BackColor = SystemColors.Control;
                this.BtnStart.Enabled = true;
                this.BtnStop.Enabled = false;

                this.ChkLive.Enabled = true;
                this.BtnIOController.Enabled = true;
                this.BtnIOController.BackColor = Color.SteelBlue;

                this.OnScreenFixed(false);
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnToRecipe_Click(object sender, EventArgs e)
        {
            try
            {
                ECAMERA ECamera = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)((Control)sender).Tag);

                if (this.m_OResult != null)
                {
                    if (ECamera == ECAMERA.FRONT_LEFT)
                    {
                        if (this.m_OResult.OFrontLeft != null)
                        {
                            Directory.CreateDirectory(".\\RECIPE\\IMAGE");

                            Bitmap OImage = this.m_OResult.OFrontLeft.OImageInfo.OImage.ToBitmap();
                            OImage.Save(".\\RECIPE\\IMAGE\\FRONT_LEFT.bmp");
                            OImage.Dispose();
                        }
                        else CMsgBox.Warning("The current image is not existed");
                    }
                    else if (ECamera == ECAMERA.FRONT_RIGHT)
                    {
                        if (this.m_OResult.OFrontRight != null)
                        {
                            Directory.CreateDirectory(".\\RECIPE\\IMAGE");

                            Bitmap OImage = this.m_OResult.OFrontRight.OImageInfo.OImage.ToBitmap();
                            OImage.Save(".\\RECIPE\\IMAGE\\FRONT_RIGHT.bmp");
                            OImage.Dispose();
                        }
                        else CMsgBox.Warning("The current image is not existed");
                    }
                    else if (ECamera == ECAMERA.BACK_LEFT)
                    {
                        if (this.m_OResult.OBackLeft != null)
                        {
                            Directory.CreateDirectory(".\\RECIPE\\IMAGE");

                            Bitmap OImage = this.m_OResult.OBackLeft.OImageInfo.OImage.ToBitmap();
                            OImage.Save(".\\RECIPE\\IMAGE\\BACK_LEFT.bmp");
                            OImage.Dispose();
                        }
                        else CMsgBox.Warning("The current image is not existed");
                    }
                    else if (ECamera == ECAMERA.BACK_RIGHT)
                    {
                        if (this.m_OResult.OBackRight != null)
                        {
                            Directory.CreateDirectory(".\\RECIPE\\IMAGE");

                            Bitmap OImage = this.m_OResult.OBackRight.OImageInfo.OImage.ToBitmap();
                            OImage.Save(".\\RECIPE\\IMAGE\\BACK_RIGHT.bmp");
                            OImage.Dispose();
                        }
                        else CMsgBox.Warning("The current image is not existed");
                    }
                }
                else CMsgBox.Warning("The current image is not existed");
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region ETC EVENT
        private void TrkGain_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                ECAMERA ECamera = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)((Control)sender).Tag);

                if (ECamera == ECAMERA.FRONT_LEFT)
                {
                    int I32Value = this.TrkFrontLeftGain.Value;

                    if (CAcquisitionManager.It.OFrontLeft != null)
                    {
                        CAcquisitionManager.It.OFrontLeft.I32Gain = I32Value;
                        this.NudFrontLeftGain.Value = I32Value;
                    }
                }
                else if (ECamera == ECAMERA.FRONT_RIGHT)
                {
                    int I32Value = this.TrkFrontRightGain.Value;

                    if (CAcquisitionManager.It.OFrontRight != null)
                    {
                        CAcquisitionManager.It.OFrontRight.I32Gain = I32Value;
                        this.NudFrontRightGain.Value = I32Value;
                    }
                }
                else if (ECamera == ECAMERA.BACK_LEFT)
                {
                    int I32Value = this.TrkBackLeftGain.Value;

                    if (CAcquisitionManager.It.OBackLeft != null)
                    {
                        CAcquisitionManager.It.OBackLeft.I32Gain = I32Value;
                        this.NudBackLeftGain.Value = I32Value;
                    }
                }
                else if (ECamera == ECAMERA.BACK_RIGHT)
                {
                    int I32Value = this.TrkBackRightGain.Value;

                    if (CAcquisitionManager.It.OBackRight != null)
                    {
                        CAcquisitionManager.It.OBackRight.I32Gain = I32Value;
                        this.NudBackRightGain.Value = I32Value;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void TrkExposureTime_ValueChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                ECAMERA ECamera = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)((Control)sender).Tag);

                if (ECamera == ECAMERA.FRONT_LEFT)
                {
                    int I32Value = this.TrkFrontLeftExposureTime.Value;

                    if (CAcquisitionManager.It.OFrontLeft != null)
                    {
                        CAcquisitionManager.It.OFrontLeft.I32ExposureTime = I32Value;
                        this.NudFrontLeftExposureTime.Value = I32Value;
                    }
                }
                else if (ECamera == ECAMERA.FRONT_RIGHT)
                {
                    int I32Value = this.TrkFrontRightExposureTime.Value;

                    if (CAcquisitionManager.It.OFrontRight != null)
                    {
                        CAcquisitionManager.It.OFrontRight.I32ExposureTime = I32Value;
                        this.NudFrontRightExposureTime.Value = I32Value;
                    }
                }
                else if (ECamera == ECAMERA.BACK_LEFT)
                {
                    int I32Value = this.TrkBackLeftExposureTime.Value;

                    if (CAcquisitionManager.It.OBackLeft != null)
                    {
                        CAcquisitionManager.It.OBackLeft.I32ExposureTime = I32Value;
                        this.NudBackLeftExposureTime.Value = I32Value;
                    }
                }
                else if (ECamera == ECAMERA.BACK_RIGHT)
                {
                    int I32Value = this.TrkBackRightExposureTime.Value;

                    if (CAcquisitionManager.It.OBackRight != null)
                    {
                        CAcquisitionManager.It.OBackRight.I32ExposureTime = I32Value;
                        this.NudBackRightExposureTime.Value = I32Value;
                    }
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void LtbNG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                string StrSelectedItem = (string)this.LtbNG.SelectedItem;
                if (String.IsNullOrEmpty(StrSelectedItem) == true) return;
                
                foreach (CShampFaultResult _Item in this.m_LstONG)
                {
                    if (_Item.OTime.ToString("yyyy-MM-dd HH:mm:ss fff") != StrSelectedItem) continue;

                    this.DisplayNGResult(_Item);
                    this.DisplayNGImage(_Item);
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void ChkLive_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                CShampFaultTool.It.BInspect = !this.ChkLive.Checked;
                this.ChkLive.BackColor = (this.ChkLive.Checked == true) ? Color.ForestGreen : Color.SteelBlue;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void ChkReject_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                CShampFaultTool.It.BReject = this.ChkReject.Checked;
                this.ChkReject.BackColor = (this.ChkReject.Checked == true) ? Color.DarkRed : Color.SteelBlue;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void ChkSaveNG_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                CShampFaultTool.It.BSaveNG = this.ChkSaveNG.Checked;
                this.ChkSaveNG.BackColor = (this.ChkSaveNG.Checked == true) ? Color.ForestGreen : Color.SteelBlue;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        public void OShampFaultTool_Inspected(CShampFaultResult OResult)
        {
            try
            {
                if (this.InvokeRequired == true)
                {
                    this.DisplayImage(OResult);
                    this.BeginInvoke(new CShampFaultTool.InspectedHandler(this.OShampFaultTool_Inspected), OResult);
                    return;
                }

                this.m_OResult = OResult;
                this.DisplaySummary(OResult);
                this.DisplayResult(OResult);
                if ((OResult.BInspected == true) && (OResult.BOK == false))
                {
                    this.SetNGResult(OResult);
                }
            }
            catch (Exception ex)
            {
                CError.Ignore(ex);
            }
        }
        #endregion
        #endregion


        #region FUNCTION
        public override void OnAdd()
        {
            try
            {
                this.m_BPreventEvent = true;

                if (CShampFaultTool.It.ORecipe == null)
                {
                    this.NudCam1MinScore.Controls[1].Text = string.Empty;
                    this.NudCam2MinScore.Controls[1].Text = string.Empty;
                    this.NudCam3MinScore.Controls[1].Text = string.Empty;
                    this.NudCam4MinScore.Controls[1].Text = string.Empty;
                    this.BtnApplyMinScore.BackColor = SystemColors.Control;

                    this.NudCam1MinScore.Enabled = false;
                    this.NudCam2MinScore.Enabled = false;
                    this.NudCam3MinScore.Enabled = false;
                    this.NudCam4MinScore.Enabled = false;
                    this.BtnApplyMinScore.Enabled = false;
                }
                else
                {
                    CShampFaultRecipe ORecipe = (CShampFaultRecipe)CShampFaultTool.It.ORecipe;

                    if ((ORecipe.OFrontLeft.BEnabled == false) &&
                        (ORecipe.OFrontRight.BEnabled == false) &&
                        (ORecipe.OBackLeft.BEnabled == false) &&
                        (ORecipe.OBackRight.BEnabled == false))
                    {
                        this.NudCam1MinScore.Controls[1].Text = string.Empty;
                        this.NudCam2MinScore.Controls[1].Text = string.Empty;
                        this.NudCam3MinScore.Controls[1].Text = string.Empty;
                        this.NudCam4MinScore.Controls[1].Text = string.Empty;
                        this.BtnApplyMinScore.BackColor = SystemColors.Control;

                        this.NudCam1MinScore.Enabled = false;
                        this.NudCam2MinScore.Enabled = false;
                        this.NudCam3MinScore.Enabled = false;
                        this.NudCam4MinScore.Enabled = false;
                        this.BtnApplyMinScore.Enabled = false;
                    }
                    else
                    {
                        if (ORecipe.OFrontLeft.BEnabled == true)
                        {
                            this.NudCam1MinScore.Value = Convert.ToDecimal(ORecipe.OFrontLeft.F64MinScore);
                            this.NudCam1MinScore.Controls[1].Text = this.NudCam1MinScore.Value.ToString();
                            this.NudCam1MinScore.Enabled = true;
                        }
                        else
                        {
                            this.NudCam1MinScore.Controls[1].Text = string.Empty;
                            this.NudCam1MinScore.Enabled = false;
                        }

                        if (ORecipe.OFrontRight.BEnabled == true)
                        {
                            this.NudCam2MinScore.Value = Convert.ToDecimal(ORecipe.OFrontRight.F64MinScore);
                            this.NudCam2MinScore.Controls[1].Text = this.NudCam2MinScore.Value.ToString();
                            this.NudCam2MinScore.Enabled = true;
                        }
                        else
                        {
                            this.NudCam2MinScore.Controls[1].Text = string.Empty;
                            this.NudCam2MinScore.Enabled = false;
                        }
                        
                        if (ORecipe.OBackLeft.BEnabled == true)
                        {
                            this.NudCam3MinScore.Value = Convert.ToDecimal(ORecipe.OBackLeft.F64MinScore);
                            this.NudCam3MinScore.Controls[1].Text = this.NudCam3MinScore.Value.ToString();
                            this.NudCam3MinScore.Enabled = true;
                        }
                        else
                        {
                            this.NudCam3MinScore.Controls[1].Text = string.Empty;
                            this.NudCam3MinScore.Enabled = false;
                        }

                        if (ORecipe.OBackRight.BEnabled == true)
                        {
                            this.NudCam4MinScore.Value = Convert.ToDecimal(ORecipe.OBackRight.F64MinScore);
                            this.NudCam4MinScore.Controls[1].Text = this.NudCam4MinScore.Value.ToString();
                            this.NudCam4MinScore.Enabled = true;
                        }
                        else
                        {
                            this.NudCam4MinScore.Controls[1].Text = string.Empty;
                            this.NudCam4MinScore.Enabled = false;
                        }

                        this.BtnApplyMinScore.BackColor = Color.SteelBlue;
                        this.BtnApplyMinScore.Enabled = true;
                    }

                }



                this.ChkLive.Checked = (CShampFaultTool.It.BInspect == false);
                this.ChkReject.Checked = CShampFaultTool.It.BReject;
                this.ChkSaveNG.Checked = CShampFaultTool.It.BSaveNG;
                this.ChkLive.BackColor = (this.ChkLive.Checked == true) ? Color.ForestGreen : Color.SteelBlue;
                this.ChkReject.BackColor = (this.ChkReject.Checked == true) ? Color.DarkRed : Color.SteelBlue;
                this.ChkSaveNG.BackColor = (this.ChkSaveNG.Checked == true) ? Color.ForestGreen : Color.SteelBlue;
                CShampFaultTool.It.Inspected = this.OShampFaultTool_Inspected;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }


        public override void OnRemove()
        {
            try
            {
                CShampFaultTool.It.Inspected = null;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        public override void OnTimer1000()
        {
            try
            {
                this.LblMinute.Text = CShampFaultTool.It.GetInspectionCount().ToString();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void DisplayImage(CShampFaultResult OResult)
        {
            try
            {
                this.CdpFrontLeftImage.DrawingEnabled = false;
                this.CdpFrontRightImage.DrawingEnabled = false;
                this.CdpBackLeftImage.DrawingEnabled = false;
                this.CdpBackRightImage.DrawingEnabled = false;

                this.CdpFrontLeftImage.StaticGraphics.Clear();
                this.CdpFrontRightImage.StaticGraphics.Clear();
                this.CdpBackLeftImage.StaticGraphics.Clear();
                this.CdpBackRightImage.StaticGraphics.Clear();

                if (OResult.OFrontLeft != null)
                {
                    this.CdpFrontLeftImage.Image = OResult.OFrontLeft.OImageInfo.OImage;

                    if (OResult.OFrontLeft.OGraphic != null)
                    {
                        this.CdpFrontLeftImage.StaticGraphics.Add(OResult.OFrontLeft.OGraphic, "Result");
                    }
                }
                else this.CdpFrontLeftImage.Image = null;                

                if (OResult.OFrontRight != null)
                {
                    this.CdpFrontRightImage.Image = OResult.OFrontRight.OImageInfo.OImage;

                    if (OResult.OFrontRight.OGraphic != null)
                    {
                        this.CdpFrontRightImage.StaticGraphics.Add(OResult.OFrontRight.OGraphic, "Result");
                    }
                }
                else this.CdpFrontRightImage.Image = null;

                if (OResult.OBackLeft != null)
                {
                    this.CdpBackLeftImage.Image = OResult.OBackLeft.OImageInfo.OImage;

                    if (OResult.OBackLeft.OGraphic != null)
                    {
                        this.CdpBackLeftImage.StaticGraphics.Add(OResult.OBackLeft.OGraphic, "Result");
                    }
                }
                else this.CdpBackLeftImage.Image = null;

                if (OResult.OBackRight != null)
                {
                    this.CdpBackRightImage.Image = OResult.OBackRight.OImageInfo.OImage;

                    if (OResult.OBackRight.OGraphic != null)
                    {
                        this.CdpBackRightImage.StaticGraphics.Add(OResult.OBackRight.OGraphic, "Result");
                    }
                }
                else this.CdpBackRightImage.Image = null;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.CdpFrontLeftImage.DrawingEnabled = true;
                this.CdpFrontRightImage.DrawingEnabled = true;
                this.CdpBackLeftImage.DrawingEnabled = true;
                this.CdpBackRightImage.DrawingEnabled = true;
            }
        }


        private void DisplayResult(CShampFaultResult OResult)
        {
            try
            {
                if ((OResult.BInspected != this.m_BInspected) || (OResult.BOK != this.m_BOK))
                {
                    if (OResult.BInspected == true)
                    {
                        if (OResult.BOK == true)
                        {
                            this.LblResult.Text = "OK";
                            this.LblResult.BackColor = Color.ForestGreen;
                        }
                        else
                        {
                            this.LblResult.Text = "NG";
                            this.LblResult.BackColor = Color.DarkRed;
                        }
                    }
                    else
                    {
                        this.LblResult.Text = "BYPASS";
                        this.LblResult.BackColor = SystemColors.Control;
                    }

                    this.m_BInspected = OResult.BInspected;
                    this.m_BOK = OResult.BOK;
                }


                if ((OResult.OFrontLeft != null) &&
                    (OResult.OFrontLeft.BEnable == true) &&
                    (OResult.OFrontLeft.BInspected == true))
                {
                    this.LblFrontLeftInfo.Text = OResult.OFrontLeft.I32Score.ToString();
                    this.LblFrontLeftInfo.ForeColor = (OResult.OFrontLeft.BOK == true) ? Color.ForestGreen : Color.DarkRed;
                }
                else this.LblFrontLeftInfo.Text = string.Empty;

                if ((OResult.OFrontRight != null) &&
                    (OResult.OFrontRight.BEnable == true) &&
                    (OResult.OFrontRight.BInspected == true))
                {
                    this.LblFrontRightInfo.Text = OResult.OFrontRight.I32Score.ToString();
                    this.LblFrontRightInfo.ForeColor = (OResult.OFrontRight.BOK == true) ? Color.ForestGreen : Color.DarkRed;
                }
                else this.LblFrontRightInfo.Text = string.Empty;

                if ((OResult.OBackLeft != null) &&
                    (OResult.OBackLeft.BEnable == true) &&
                    (OResult.OBackLeft.BInspected == true))
                {
                    this.LblBackLeftInfo.Text = OResult.OBackLeft.I32Score.ToString();
                    this.LblBackLeftInfo.ForeColor = (OResult.OBackLeft.BOK == true) ? Color.ForestGreen : Color.DarkRed;
                }
                else this.LblBackLeftInfo.Text = string.Empty;

                if ((OResult.OBackRight != null) &&
                    (OResult.OBackRight.BEnable == true) &&
                    (OResult.OBackRight.BInspected == true))
                {
                    this.LblBackRightInfo.Text = OResult.OBackRight.I32Score.ToString();
                    this.LblBackRightInfo.ForeColor = (OResult.OBackRight.BOK == true) ? Color.ForestGreen : Color.DarkRed;
                }
                else this.LblBackRightInfo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void DisplaySummary(CShampFaultResult OResult)
        {
            try
            {
                if (OResult.BInspected == true)
                {
                    this.m_I64TotalCount++;
                    if (OResult.BOK == true) this.m_I64OKCount++;
                    else this.m_I64NGCount++;

                    this.LblTotalCount.Text = this.m_I64TotalCount.ToString();
                    this.LblOKCount.Text = this.m_I64OKCount.ToString();
                    this.LblNGCount.Text = this.m_I64NGCount.ToString();
                    this.LblOKPercent.Text = (Math.Round(this.m_I64OKCount / (float)this.m_I64TotalCount, 4) * 100).ToString();
                    this.LblNGPercent.Text = (Math.Round(this.m_I64NGCount / (float)this.m_I64TotalCount, 4) * 100).ToString();
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void SetNGResult(CShampFaultResult OResult)
        {
            this.m_BPreventEvent = true;

            try
            {
                this.m_LstONG.Add(OResult);
                this.LtbNG.Items.Add(OResult.OTime.ToString("yyyy-MM-dd HH:mm:ss fff"));

                if (this.LtbNG.Items.Count > 50)
                {
                    this.m_LstONG.RemoveAt(0);
                    this.LtbNG.Items.RemoveAt(0);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.m_BPreventEvent = false;
            }
        }


        private void DisplayNGResult(CShampFaultResult OResult)
        {
            try
            {
                this.LblTimeNG.Text = OResult.OTime.ToString("yyyy-MM-dd HH:mm:ss fff");

                if ((OResult.OFrontLeft != null) &&
                    (OResult.OFrontLeft.BEnable == true) &&
                    (OResult.OFrontLeft.BInspected == true))
                {
                    this.LblFrontLeftNGInfo.Text = OResult.OFrontLeft.I32Score.ToString();
                    this.LblFrontLeftNGInfo.ForeColor = (OResult.OFrontLeft.BOK == true) ? Color.ForestGreen : Color.DarkRed;
                }
                else this.LblFrontLeftNGInfo.Text = string.Empty;

                if ((OResult.OFrontRight != null) &&
                    (OResult.OFrontRight.BEnable == true) &&
                    (OResult.OFrontRight.BInspected == true))
                {
                    this.LblFrontRightNGInfo.Text = OResult.OFrontRight.I32Score.ToString();
                    this.LblFrontRightNGInfo.ForeColor = (OResult.OFrontRight.BOK == true) ? Color.ForestGreen : Color.DarkRed;
                }
                else this.LblFrontRightNGInfo.Text = string.Empty;

                if ((OResult.OBackLeft != null) &&
                    (OResult.OBackLeft.BEnable == true) &&
                    (OResult.OBackLeft.BInspected == true))
                {
                    this.LblBackLeftNGInfo.Text = OResult.OBackLeft.I32Score.ToString();
                    this.LblBackLeftNGInfo.ForeColor = (OResult.OBackLeft.BOK == true) ? Color.ForestGreen : Color.DarkRed;
                }
                else this.LblBackLeftNGInfo.Text = string.Empty;

                if ((OResult.OBackRight != null) &&
                    (OResult.OBackRight.BEnable == true) &&
                    (OResult.OBackRight.BInspected == true))
                {
                    this.LblBackRightNGInfo.Text = OResult.OBackRight.I32Score.ToString();
                    this.LblBackRightNGInfo.ForeColor = (OResult.OBackRight.BOK == true) ? Color.ForestGreen : Color.DarkRed;
                }
                else this.LblBackRightNGInfo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }


        private void DisplayNGImage(CShampFaultResult OResult)
        {
            try
            {
                this.CdpFrontLeftNGImage.DrawingEnabled = false;
                this.CdpFrontRightNGImage.DrawingEnabled = false;
                this.CdpBackLeftNGImage.DrawingEnabled = false;
                this.CdpBackRightNGImage.DrawingEnabled = false;


                this.CdpFrontLeftNGImage.StaticGraphics.Clear();
                this.CdpFrontRightNGImage.StaticGraphics.Clear();
                this.CdpBackLeftNGImage.StaticGraphics.Clear();
                this.CdpBackRightNGImage.StaticGraphics.Clear();

                if (OResult.OFrontLeft != null)
                {
                    this.CdpFrontLeftNGImage.Image = OResult.OFrontLeft.OImageInfo.OImage;

                    if (OResult.OFrontLeft.OGraphic != null)
                    {
                        this.CdpFrontLeftNGImage.StaticGraphics.Add(OResult.OFrontLeft.OGraphic, "Result");
                    }
                }
                else this.CdpFrontLeftNGImage.Image = null;
                
                if (OResult.OFrontRight != null)
                {
                    this.CdpFrontRightNGImage.Image = OResult.OFrontRight.OImageInfo.OImage;

                    if (OResult.OFrontRight.OGraphic != null)
                    {
                        this.CdpFrontRightNGImage.StaticGraphics.Add(OResult.OFrontRight.OGraphic, "Result");
                    }
                }
                else this.CdpFrontRightNGImage.Image = null;

                if (OResult.OBackLeft != null)
                {
                    this.CdpBackLeftNGImage.Image = OResult.OBackLeft.OImageInfo.OImage;

                    if (OResult.OBackLeft.OGraphic != null)
                    {
                        this.CdpBackLeftNGImage.StaticGraphics.Add(OResult.OBackLeft.OGraphic, "Result");
                    }
                }
                else this.CdpBackLeftNGImage.Image = null;

                if (OResult.OBackRight != null)
                {
                    this.CdpBackRightNGImage.Image = OResult.OBackRight.OImageInfo.OImage;

                    if (OResult.OBackRight.OGraphic != null)
                    {
                        this.CdpBackRightNGImage.StaticGraphics.Add(OResult.OBackRight.OGraphic, "Result");
                    }
                }
                else this.CdpBackRightNGImage.Image = null;
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
            finally
            {
                this.CdpFrontLeftNGImage.DrawingEnabled = true;
                this.CdpFrontRightNGImage.DrawingEnabled = true;
                this.CdpBackLeftNGImage.DrawingEnabled = true;
                this.CdpBackRightNGImage.DrawingEnabled = true;
            }
        }
        #endregion
    }
}
