using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Util.Print;
using Daekhon.Common;
using Cognex.VisionPro;
using System.IO;

namespace ShampDesign
{
    public partial class UcRecipe : UcScreen
    {
        #region VARIABLE
        private EEDIT m_EEdit = EEDIT.NONE;
        private CShampFaultRecipe m_ORecipe = null;

        private bool m_BPreventEvent = false;
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public UcRecipe()
        {
            InitializeComponent();

            try
            {
                this.RefreshRecipeList();
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
        

        #region EVENT
        #region BUTTON EVENT
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string StrName = this.TxtName.Text.Trim();
                if (String.IsNullOrEmpty(StrName) == true)
                {
                    CMsgBox.Warning("Please write 'Name' of recipe!");
                    return;
                }
                foreach (IRecipe _Item in CRecipeManager.It.LstORecipe)
                {
                    if (_Item.StrName != StrName) continue;

                    CMsgBox.Warning("The written 'Name' of recipe is already existed!");
                    return;
                }


                this.m_ORecipe = new CShampFaultRecipe(StrName);
                this.m_ORecipe.Create();
                this.m_EEdit = EEDIT.ADD;


                this.CdpFrontLeft.Image = null;
                this.CdpFrontRight.Image = null;
                this.CdpBackLeft.Image = null;
                this.CdpBackRight.Image = null;
                this.CdpFrontLeft.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OFrontLeft.OTool.Pattern.TrainRegion, "TrainROI", true);
                this.CdpFrontLeft.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OFrontLeft.OTool.SearchRegion, "SearchROI", true);
                this.CdpFrontRight.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OFrontRight.OTool.Pattern.TrainRegion, "TrainROI", true);
                this.CdpFrontRight.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OFrontRight.OTool.SearchRegion, "SearchROI", true);
                this.CdpBackLeft.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OBackLeft.OTool.Pattern.TrainRegion, "TrainROI", true);
                this.CdpBackLeft.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OBackLeft.OTool.SearchRegion, "SearchROI", true);
                this.CdpBackRight.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OBackRight.OTool.Pattern.TrainRegion, "TrainROI", true);
                this.CdpBackRight.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OBackRight.OTool.SearchRegion, "SearchROI", true);


                this.BtnAdd.BackColor = SystemColors.Control;
                this.BtnModify.BackColor = SystemColors.Control;
                this.BtnDelete.BackColor = SystemColors.Control;
                this.BtnSave.BackColor = Color.SteelBlue;
                this.BtnCancel.BackColor = Color.SteelBlue;
                this.BtnApply.BackColor = SystemColors.Control;
                this.ChkFrontLeftEnabled.BackColor = Color.SteelBlue;
                this.ChkFrontRightEnabled.BackColor = Color.SteelBlue;
                this.ChkBackLeftEnabled.BackColor = Color.SteelBlue;
                this.ChkBackRightEnabled.BackColor = Color.SteelBlue;

                this.TxtName.Enabled = false;
                this.BtnAdd.Enabled = false;
                this.BtnModify.Enabled = false;
                this.BtnDelete.Enabled = false;
                this.BtnSave.Enabled = true;
                this.BtnCancel.Enabled = true;
                this.BtnApply.Enabled = false;
                this.ChkFrontLeftEnabled.Enabled = true;
                this.ChkFrontRightEnabled.Enabled = true;
                this.ChkBackLeftEnabled.Enabled = true;
                this.ChkBackRightEnabled.Enabled = true;

                base.OnScreenFixed(true);
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


        private void BtnModify_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_BPreventEvent = true;

                string StrName = (string)this.LtbRecipeList.SelectedItem;
                if (String.IsNullOrEmpty(StrName) == true)
                {
                    CMsgBox.Warning("Please select recipe infomation to modfiy!");
                    return;
                }


                foreach (IRecipe _Item in CRecipeManager.It.LstORecipe)
                {
                    if (_Item.StrName != StrName) continue;

                    this.m_ORecipe = new CShampFaultRecipe((CShampFaultRecipe)_Item);
                    this.m_ORecipe.Load();
                    break;
                }
                this.m_EEdit = EEDIT.MODIFY;


                this.CdpFrontLeft.Image = this.m_ORecipe.OFrontLeft.OTool.Pattern.TrainImage;
                this.CdpFrontRight.Image = this.m_ORecipe.OFrontRight.OTool.Pattern.TrainImage;
                this.CdpBackLeft.Image = this.m_ORecipe.OBackLeft.OTool.Pattern.TrainImage;
                this.CdpBackRight.Image = this.m_ORecipe.OBackRight.OTool.Pattern.TrainImage;


                this.CdpFrontLeft.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OFrontLeft.OTool.Pattern.TrainRegion, "TrainROI", true);
                this.CdpFrontLeft.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OFrontLeft.OTool.SearchRegion, "SearchROI", true);
                this.CdpFrontRight.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OFrontRight.OTool.Pattern.TrainRegion, "TrainROI", true);
                this.CdpFrontRight.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OFrontRight.OTool.SearchRegion, "SearchROI", true);
                this.CdpBackLeft.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OBackLeft.OTool.Pattern.TrainRegion, "TrainROI", true);
                this.CdpBackLeft.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OBackLeft.OTool.SearchRegion, "SearchROI", true);
                this.CdpBackRight.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OBackRight.OTool.Pattern.TrainRegion, "TrainROI", true);
                this.CdpBackRight.InteractiveGraphics.Add((ICogGraphicInteractive)this.m_ORecipe.OBackRight.OTool.SearchRegion, "SearchROI", true);
                

                #region FRONT_LEFT
                if (this.m_ORecipe.OFrontLeft.BEnabled == true)
                {
                    this.ChkFrontLeftEnabled.Text = "Enable";
                    this.ChkFrontLeftEnabled.BackColor = Color.ForestGreen;
                    this.ChkFrontLeftEnabled.Checked = true;

                    this.NudFrontLeftAngleLow.Value = Convert.ToDecimal(this.m_ORecipe.OFrontLeft.F64AngleLow);
                    this.NudFrontLeftAngleLow.Controls[1].Text = this.NudFrontLeftAngleLow.Value.ToString("0.0");
                    this.NudFrontLeftAngleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OFrontLeft.F64AngleHigh);
                    this.NudFrontLeftAngleHigh.Controls[1].Text = this.NudFrontLeftAngleHigh.Value.ToString("0.0");
                    this.NudFrontLeftScaleLow.Value = Convert.ToDecimal(this.m_ORecipe.OFrontLeft.F64ScaleLow);
                    this.NudFrontLeftScaleLow.Controls[1].Text = this.NudFrontLeftScaleLow.Value.ToString("0.0");
                    this.NudFrontLeftScaleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OFrontLeft.F64ScaleHigh);
                    this.NudFrontLeftScaleHigh.Controls[1].Text = this.NudFrontLeftScaleHigh.Value.ToString("0.0");
                    this.NudFrontLeftMinScore.Value = Convert.ToDecimal(this.m_ORecipe.OFrontLeft.F64MinScore);
                    this.NudFrontLeftMinScore.Controls[1].Text = this.NudFrontLeftMinScore.Value.ToString();
                    this.BtnFrontLeftGrap.BackColor = Color.SteelBlue;
                    this.BtnFrontLeftTrain.BackColor = Color.SteelBlue;

                    this.NudFrontLeftAngleLow.Enabled = true;
                    this.NudFrontLeftAngleHigh.Enabled = true;
                    this.NudFrontLeftScaleLow.Enabled = true;
                    this.NudFrontLeftScaleHigh.Enabled = true;
                    this.NudFrontLeftMinScore.Enabled = true;
                    this.BtnFrontLeftGrap.Enabled = true;
                    this.BtnFrontLeftTrain.Enabled = true;
                }
                else
                {
                    this.ChkFrontLeftEnabled.Text = "Disable";
                    this.ChkFrontLeftEnabled.BackColor = Color.SteelBlue;
                    this.ChkFrontLeftEnabled.Checked = false;

                    this.NudFrontLeftAngleLow.Value = -45;
                    this.NudFrontLeftAngleLow.Controls[1].Text = string.Empty;
                    this.NudFrontLeftAngleHigh.Value = 45;
                    this.NudFrontLeftAngleHigh.Controls[1].Text = string.Empty;
                    this.NudFrontLeftScaleLow.Value = 0.8m;
                    this.NudFrontLeftScaleLow.Controls[1].Text = string.Empty;
                    this.NudFrontLeftScaleHigh.Value = 1.2m;
                    this.NudFrontLeftScaleHigh.Controls[1].Text = string.Empty;
                    this.NudFrontLeftMinScore.Value = 80;
                    this.NudFrontLeftMinScore.Controls[1].Text = string.Empty;
                    this.BtnFrontLeftGrap.BackColor = SystemColors.Control;
                    this.BtnFrontLeftTrain.BackColor = SystemColors.Control;

                    this.NudFrontLeftAngleLow.Enabled = false;
                    this.NudFrontLeftAngleHigh.Enabled = false;
                    this.NudFrontLeftScaleLow.Enabled = false;
                    this.NudFrontLeftScaleHigh.Enabled = false;
                    this.NudFrontLeftMinScore.Enabled = false;
                    this.BtnFrontLeftGrap.Enabled = false;
                    this.BtnFrontLeftTrain.Enabled = false;
                }
                #endregion

                #region FRONT_RIGHT
                if (this.m_ORecipe.OFrontRight.BEnabled == true)
                {
                    this.ChkFrontRightEnabled.Text = "Enable";
                    this.ChkFrontRightEnabled.BackColor = Color.ForestGreen;
                    this.ChkFrontRightEnabled.Checked = true;

                    this.NudFrontRightAngleLow.Value = Convert.ToDecimal(this.m_ORecipe.OFrontRight.F64AngleLow);
                    this.NudFrontRightAngleLow.Controls[1].Text = this.NudFrontRightAngleLow.Value.ToString("0.0");
                    this.NudFrontRightAngleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OFrontRight.F64AngleHigh);
                    this.NudFrontRightAngleHigh.Controls[1].Text = this.NudFrontRightAngleHigh.Value.ToString("0.0");
                    this.NudFrontRightScaleLow.Value = Convert.ToDecimal(this.m_ORecipe.OFrontRight.F64ScaleLow);
                    this.NudFrontRightScaleLow.Controls[1].Text = this.NudFrontRightScaleLow.Value.ToString("0.0");
                    this.NudFrontRightScaleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OFrontRight.F64ScaleHigh);
                    this.NudFrontRightScaleHigh.Controls[1].Text = this.NudFrontRightScaleHigh.Value.ToString("0.0");
                    this.NudFrontRightMinScore.Value = Convert.ToDecimal(this.m_ORecipe.OFrontRight.F64MinScore);
                    this.NudFrontRightMinScore.Controls[1].Text = this.NudFrontRightMinScore.Value.ToString();
                    this.BtnFrontRightGrap.BackColor = Color.SteelBlue;
                    this.BtnFrontRightTrain.BackColor = Color.SteelBlue;

                    this.NudFrontRightAngleLow.Enabled = true;
                    this.NudFrontRightAngleHigh.Enabled = true;
                    this.NudFrontRightScaleLow.Enabled = true;
                    this.NudFrontRightScaleHigh.Enabled = true;
                    this.NudFrontRightMinScore.Enabled = true;
                    this.BtnFrontRightGrap.Enabled = true;
                    this.BtnFrontRightTrain.Enabled = true;
                }
                else
                {
                    this.ChkFrontRightEnabled.Text = "Disable";
                    this.ChkFrontRightEnabled.BackColor = Color.SteelBlue;
                    this.ChkFrontRightEnabled.Checked = false;


                    this.NudFrontRightAngleLow.Value = -45;
                    this.NudFrontRightAngleLow.Controls[1].Text = string.Empty;
                    this.NudFrontRightAngleHigh.Value = 45;
                    this.NudFrontRightAngleHigh.Controls[1].Text = string.Empty;
                    this.NudFrontRightScaleLow.Value = 0.8m;
                    this.NudFrontRightScaleLow.Controls[1].Text = string.Empty;
                    this.NudFrontRightScaleHigh.Value = 1.2m;
                    this.NudFrontRightScaleHigh.Controls[1].Text = string.Empty;
                    this.NudFrontRightMinScore.Value = 80;
                    this.NudFrontRightMinScore.Controls[1].Text = string.Empty;
                    this.BtnFrontRightGrap.BackColor = SystemColors.Control;
                    this.BtnFrontRightTrain.BackColor = SystemColors.Control;

                    this.NudFrontRightAngleLow.Enabled = false;
                    this.NudFrontRightAngleHigh.Enabled = false;
                    this.NudFrontRightScaleLow.Enabled = false;
                    this.NudFrontRightScaleHigh.Enabled = false;
                    this.NudFrontRightMinScore.Enabled = false;
                    this.BtnFrontRightGrap.Enabled = false;
                    this.BtnFrontRightTrain.Enabled = false;
                }
                #endregion

                #region BACK_LEFT
                if (this.m_ORecipe.OBackLeft.BEnabled == true)
                {
                    this.ChkBackLeftEnabled.Text = "Enable";
                    this.ChkBackLeftEnabled.BackColor = Color.ForestGreen;
                    this.ChkBackLeftEnabled.Checked = true;
                    this.NudBackLeftAngleLow.Value = Convert.ToDecimal(this.m_ORecipe.OBackLeft.F64AngleLow);
                    this.NudBackLeftAngleLow.Controls[1].Text = this.NudBackLeftAngleLow.Value.ToString("0.0");
                    this.NudBackLeftAngleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OBackLeft.F64AngleHigh);
                    this.NudBackLeftAngleHigh.Controls[1].Text = this.NudBackLeftAngleHigh.Value.ToString("0.0");
                    this.NudBackLeftScaleLow.Value = Convert.ToDecimal(this.m_ORecipe.OBackLeft.F64ScaleLow);
                    this.NudBackLeftScaleLow.Controls[1].Text = this.NudBackLeftScaleLow.Value.ToString("0.0");
                    this.NudBackLeftScaleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OBackLeft.F64ScaleHigh);
                    this.NudBackLeftScaleHigh.Controls[1].Text = this.NudBackLeftScaleHigh.Value.ToString("0.0");
                    this.NudBackLeftMinScore.Value = Convert.ToDecimal(this.m_ORecipe.OBackLeft.F64MinScore);
                    this.NudBackLeftMinScore.Controls[1].Text = this.NudBackLeftMinScore.Value.ToString();
                    this.BtnBackLeftGrap.BackColor = Color.SteelBlue;
                    this.BtnBackLeftTrain.BackColor = Color.SteelBlue;

                    this.NudBackLeftAngleLow.Enabled = true;
                    this.NudBackLeftAngleHigh.Enabled = true;
                    this.NudBackLeftScaleLow.Enabled = true;
                    this.NudBackLeftScaleHigh.Enabled = true;
                    this.NudBackLeftMinScore.Enabled = true;
                    this.BtnBackLeftGrap.Enabled = true;
                    this.BtnBackLeftTrain.Enabled = true;
                }
                else
                {
                    this.ChkBackLeftEnabled.Text = "Disable";
                    this.ChkBackLeftEnabled.BackColor = Color.SteelBlue;
                    this.ChkBackLeftEnabled.Checked = false;

                    this.NudBackLeftAngleLow.Value = -45;
                    this.NudBackLeftAngleLow.Controls[1].Text = string.Empty;
                    this.NudBackLeftAngleHigh.Value = 45;
                    this.NudBackLeftAngleHigh.Controls[1].Text = string.Empty;
                    this.NudBackLeftScaleLow.Value = 0.8m;
                    this.NudBackLeftScaleLow.Controls[1].Text = string.Empty;
                    this.NudBackLeftScaleHigh.Value = 1.2m;
                    this.NudBackLeftScaleHigh.Controls[1].Text = string.Empty;
                    this.NudBackLeftMinScore.Value = 80;
                    this.NudBackLeftMinScore.Controls[1].Text = string.Empty;
                    this.BtnBackLeftGrap.BackColor = SystemColors.Control;
                    this.BtnBackLeftTrain.BackColor = SystemColors.Control;

                    this.NudBackLeftAngleLow.Enabled = false;
                    this.NudBackLeftAngleHigh.Enabled = false;
                    this.NudBackLeftScaleLow.Enabled = false;
                    this.NudBackLeftScaleHigh.Enabled = false;
                    this.NudBackLeftMinScore.Enabled = false;
                    this.BtnBackLeftGrap.Enabled = false;
                    this.BtnBackLeftTrain.Enabled = false;
                }
                #endregion

                #region BACK_RIGHT
                if (this.m_ORecipe.OBackRight.BEnabled == true)
                {
                    this.ChkBackRightEnabled.Text = "Enable";
                    this.ChkBackRightEnabled.BackColor = Color.ForestGreen;
                    this.ChkBackRightEnabled.Checked = true;
                    this.NudBackRightAngleLow.Value = Convert.ToDecimal(this.m_ORecipe.OBackRight.F64AngleLow);
                    this.NudBackRightAngleLow.Controls[1].Text = this.NudBackRightAngleLow.Value.ToString("0.0");
                    this.NudBackRightAngleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OBackRight.F64AngleHigh);
                    this.NudBackRightAngleHigh.Controls[1].Text = this.NudBackRightAngleHigh.Value.ToString("0.0");
                    this.NudBackRightScaleLow.Value = Convert.ToDecimal(this.m_ORecipe.OBackRight.F64ScaleLow);
                    this.NudBackRightScaleLow.Controls[1].Text = this.NudBackRightScaleLow.Value.ToString("0.0");
                    this.NudBackRightScaleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OBackRight.F64ScaleHigh);
                    this.NudBackRightScaleHigh.Controls[1].Text = this.NudBackRightScaleHigh.Value.ToString("0.0");
                    this.NudBackRightMinScore.Value = Convert.ToDecimal(this.m_ORecipe.OBackRight.F64MinScore);
                    this.NudBackRightMinScore.Controls[1].Text = this.NudBackRightMinScore.Value.ToString();
                    this.BtnBackRightGrap.BackColor = Color.SteelBlue;
                    this.BtnBackRightTrain.BackColor = Color.SteelBlue;

                    this.NudBackRightAngleLow.Enabled = true;
                    this.NudBackRightAngleHigh.Enabled = true;
                    this.NudBackRightScaleLow.Enabled = true;
                    this.NudBackRightScaleHigh.Enabled = true;
                    this.NudBackRightMinScore.Enabled = true;
                    this.BtnBackRightGrap.Enabled = true;
                    this.BtnBackRightTrain.Enabled = true;
                }
                else
                {
                    this.ChkBackRightEnabled.Text = "Disable";
                    this.ChkBackRightEnabled.BackColor = Color.SteelBlue;
                    this.ChkBackRightEnabled.Checked = false;

                    this.NudBackRightAngleLow.Value = -45;
                    this.NudBackRightAngleLow.Controls[1].Text = string.Empty;
                    this.NudBackRightAngleHigh.Value = 45;
                    this.NudBackRightAngleHigh.Controls[1].Text = string.Empty;
                    this.NudBackRightScaleLow.Value = 0.8m;
                    this.NudBackRightScaleLow.Controls[1].Text = string.Empty;
                    this.NudBackRightScaleHigh.Value = 1.2m;
                    this.NudBackRightScaleHigh.Controls[1].Text = string.Empty;
                    this.NudBackRightMinScore.Value = 80;
                    this.NudBackRightMinScore.Controls[1].Text = string.Empty;
                    this.BtnBackRightGrap.BackColor = SystemColors.Control;
                    this.BtnBackRightTrain.BackColor = SystemColors.Control;

                    this.NudBackRightAngleLow.Enabled = false;
                    this.NudBackRightAngleHigh.Enabled = false;
                    this.NudBackRightScaleLow.Enabled = false;
                    this.NudBackRightScaleHigh.Enabled = false;
                    this.NudBackRightMinScore.Enabled = false;
                    this.BtnBackRightGrap.Enabled = false;
                    this.BtnBackRightTrain.Enabled = false;
                }
                #endregion
                

                this.TxtName.Text = StrName;
                this.BtnAdd.BackColor = SystemColors.Control;
                this.BtnModify.BackColor = SystemColors.Control;
                this.BtnDelete.BackColor = SystemColors.Control;
                this.BtnSave.BackColor = Color.SteelBlue;
                this.BtnCancel.BackColor = Color.SteelBlue;
                this.BtnApply.BackColor = SystemColors.Control;

                this.TxtName.Enabled = false;
                this.BtnAdd.Enabled = false;
                this.BtnModify.Enabled = false;
                this.BtnDelete.Enabled = false;
                this.BtnSave.Enabled = true;
                this.BtnCancel.Enabled = true;
                this.BtnApply.Enabled = false;
                this.ChkFrontLeftEnabled.Enabled = true;
                this.ChkFrontRightEnabled.Enabled = true;
                this.ChkBackLeftEnabled.Enabled = true;
                this.ChkBackRightEnabled.Enabled = true;

                base.OnScreenFixed(true);
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


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string StrName = (string)this.LtbRecipeList.SelectedItem;
                if (String.IsNullOrEmpty(StrName) == true)
                {
                    CMsgBox.Warning("Please select recipe infomation to delete!");
                    return;
                }
                if (CShampFaultTool.It.ORecipe != null)
                {
                    if (CShampFaultTool.It.ORecipe.StrName == StrName)
                    {
                        CMsgBox.Warning("Cannot delete recipe infomation currently using!");
                        return;
                    }
                }


                if (CMsgBox.OKCancel("Do you want to remove '" + StrName + "' recipe, Really?") == DialogResult.OK)
                {
                    foreach (IRecipe _Item in CRecipeManager.It.LstORecipe)
                    {
                        if (_Item.StrName != StrName) continue;

                        CDB.It[CDB.TABLE_RECIPE_LIST].DeleteRow(CDB.RECIPE_LIST_COLUMN_NAME, StrName);
                        CDB.It[CDB.TABLE_RECIPE_INFO].DeleteRow(CDB.RECIPE_INFO_COLUMN_RECIPE, StrName);
                        CDB.It[CDB.TABLE_RECIPE_LIST].Commit();
                        CDB.It[CDB.TABLE_RECIPE_INFO].Commit();

                        ((CShampFaultRecipe)_Item).Delete();

                        CRecipeManager.It.LstORecipe.Remove(_Item);
                        break;
                    }

                    this.RefreshRecipeList();
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ((this.ChkFrontLeftEnabled.Checked == true) && (this.m_ORecipe.OFrontLeft.OTool.Pattern.Trained == false))
                {
                    CMsgBox.Warning("Please train the front-left recipe!");
                    return;
                }
                if ((this.ChkFrontRightEnabled.Checked == true) && (this.m_ORecipe.OFrontRight.OTool.Pattern.Trained == false))
                {
                    CMsgBox.Warning("Please train the front-right recipe!");
                    return;
                }
                if ((this.ChkBackLeftEnabled.Checked == true) && (this.m_ORecipe.OBackLeft.OTool.Pattern.Trained == false))
                {
                    CMsgBox.Warning("Please train the back-left recipe!");
                    return;
                }
                if ((this.ChkBackRightEnabled.Checked == true) && (this.m_ORecipe.OBackRight.OTool.Pattern.Trained == false))
                {
                    CMsgBox.Warning("Please train the back-right recipe!");
                    return;
                }


                if (this.ChkFrontLeftEnabled.Checked == true)
                {
                    this.m_ORecipe.OFrontLeft.BEnabled = true;
                    this.m_ORecipe.OFrontLeft.F64AngleLow = Convert.ToDouble(this.NudFrontLeftAngleLow.Value);
                    this.m_ORecipe.OFrontLeft.F64AngleHigh = Convert.ToDouble(this.NudFrontLeftAngleHigh.Value);
                    this.m_ORecipe.OFrontLeft.F64ScaleLow = Convert.ToDouble(this.NudFrontLeftScaleLow.Value);
                    this.m_ORecipe.OFrontLeft.F64ScaleHigh = Convert.ToDouble(this.NudFrontLeftScaleHigh.Value);
                    this.m_ORecipe.OFrontLeft.F64MinScore = Convert.ToDouble(this.NudFrontLeftMinScore.Value);
                }
                else
                {
                    this.m_ORecipe.OFrontLeft.BEnabled = false;
                    this.m_ORecipe.OFrontLeft.F64AngleLow = -45;
                    this.m_ORecipe.OFrontLeft.F64AngleHigh = 45;
                    this.m_ORecipe.OFrontLeft.F64ScaleLow = 0.8;
                    this.m_ORecipe.OFrontLeft.F64ScaleHigh = 1.2;
                    this.m_ORecipe.OFrontLeft.F64MinScore = 80;
                }
                
                if (this.ChkFrontRightEnabled.Checked == true)
                {
                    this.m_ORecipe.OFrontRight.BEnabled = true;
                    this.m_ORecipe.OFrontRight.F64AngleLow = Convert.ToDouble(this.NudFrontRightAngleLow.Value);
                    this.m_ORecipe.OFrontRight.F64AngleHigh = Convert.ToDouble(this.NudFrontRightAngleHigh.Value);
                    this.m_ORecipe.OFrontRight.F64ScaleLow = Convert.ToDouble(this.NudFrontRightScaleLow.Value);
                    this.m_ORecipe.OFrontRight.F64ScaleHigh = Convert.ToDouble(this.NudFrontRightScaleHigh.Value);
                    this.m_ORecipe.OFrontRight.F64MinScore = Convert.ToDouble(this.NudFrontRightMinScore.Value);
                }
                else
                {
                    this.m_ORecipe.OFrontRight.BEnabled = false;
                    this.m_ORecipe.OFrontRight.F64AngleLow = -45;
                    this.m_ORecipe.OFrontRight.F64AngleHigh = 45;
                    this.m_ORecipe.OFrontRight.F64ScaleLow = 0.8;
                    this.m_ORecipe.OFrontRight.F64ScaleHigh = 1.2;
                    this.m_ORecipe.OFrontRight.F64MinScore = 80;
                }
                
                if (this.ChkBackLeftEnabled.Checked == true)
                {
                    this.m_ORecipe.OBackLeft.BEnabled = true;
                    this.m_ORecipe.OBackLeft.F64AngleLow = Convert.ToDouble(this.NudBackLeftAngleLow.Value);
                    this.m_ORecipe.OBackLeft.F64AngleHigh = Convert.ToDouble(this.NudBackLeftAngleHigh.Value);
                    this.m_ORecipe.OBackLeft.F64ScaleLow = Convert.ToDouble(this.NudBackLeftScaleLow.Value);
                    this.m_ORecipe.OBackLeft.F64ScaleHigh = Convert.ToDouble(this.NudBackLeftScaleHigh.Value);
                    this.m_ORecipe.OBackLeft.F64MinScore = Convert.ToDouble(this.NudBackLeftMinScore.Value);
                }
                else
                {
                    this.m_ORecipe.OBackLeft.BEnabled = false;
                    this.m_ORecipe.OBackLeft.F64AngleLow = -45;
                    this.m_ORecipe.OBackLeft.F64AngleHigh = 45;
                    this.m_ORecipe.OBackLeft.F64ScaleLow = 0.8;
                    this.m_ORecipe.OBackLeft.F64ScaleHigh = 1.2;
                    this.m_ORecipe.OBackLeft.F64MinScore = 80;
                }
                
                if (this.ChkBackRightEnabled.Checked == true)
                {
                    this.m_ORecipe.OBackRight.BEnabled = true;
                    this.m_ORecipe.OBackRight.F64AngleLow = Convert.ToDouble(this.NudBackRightAngleLow.Value);
                    this.m_ORecipe.OBackRight.F64AngleHigh = Convert.ToDouble(this.NudBackRightAngleHigh.Value);
                    this.m_ORecipe.OBackRight.F64ScaleLow = Convert.ToDouble(this.NudBackRightScaleLow.Value);
                    this.m_ORecipe.OBackRight.F64ScaleHigh = Convert.ToDouble(this.NudBackRightScaleHigh.Value);
                    this.m_ORecipe.OBackRight.F64MinScore = Convert.ToDouble(this.NudBackRightMinScore.Value);
                }
                else
                {
                    this.m_ORecipe.OBackRight.BEnabled = false;
                    this.m_ORecipe.OBackRight.F64AngleLow = -45;
                    this.m_ORecipe.OBackRight.F64AngleHigh = 45;
                    this.m_ORecipe.OBackRight.F64ScaleLow = 0.8;
                    this.m_ORecipe.OBackRight.F64ScaleHigh = 1.2;
                    this.m_ORecipe.OBackRight.F64MinScore = 80;
                }

                this.m_ORecipe.Save();


                if (this.m_EEdit == EEDIT.ADD)
                {
                    int I32RowIndex = CDB.It[CDB.TABLE_RECIPE_LIST].InsertRow();
                    CDB.It[CDB.TABLE_RECIPE_LIST].Update(I32RowIndex, CDB.RECIPE_LIST_COLUMN_NAME, this.m_ORecipe.StrName);
                    CDB.It[CDB.TABLE_RECIPE_LIST].Update(I32RowIndex, CDB.RECIPE_LIST_COLUMN_DIRECTORY, this.m_ORecipe.StrDirectory);

                    I32RowIndex = CDB.It[CDB.TABLE_RECIPE_INFO].InsertRow();
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_RECIPE, this.m_ORecipe.StrName);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_DIRECTION, this.m_ORecipe.OFrontLeft.EDirection.ToString());
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_ENABLED, this.m_ORecipe.OFrontLeft.BEnabled);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_ANGLE_LOW, this.m_ORecipe.OFrontLeft.F64AngleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_ANGLE_HIGH, this.m_ORecipe.OFrontLeft.F64AngleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_SCALE_LOW, this.m_ORecipe.OFrontLeft.F64ScaleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_SCALE_HIGH, this.m_ORecipe.OFrontLeft.F64ScaleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_MIN_SCORE, this.m_ORecipe.OFrontLeft.F64MinScore);

                    I32RowIndex = CDB.It[CDB.TABLE_RECIPE_INFO].InsertRow();
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_RECIPE, this.m_ORecipe.StrName);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_DIRECTION, this.m_ORecipe.OFrontRight.EDirection.ToString());
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_ENABLED, this.m_ORecipe.OFrontRight.BEnabled);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_ANGLE_LOW, this.m_ORecipe.OFrontRight.F64AngleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_ANGLE_HIGH, this.m_ORecipe.OFrontRight.F64AngleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_SCALE_LOW, this.m_ORecipe.OFrontRight.F64ScaleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_SCALE_HIGH, this.m_ORecipe.OFrontRight.F64ScaleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_MIN_SCORE, this.m_ORecipe.OFrontRight.F64MinScore);

                    I32RowIndex = CDB.It[CDB.TABLE_RECIPE_INFO].InsertRow();
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_RECIPE, this.m_ORecipe.StrName);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_DIRECTION, this.m_ORecipe.OBackLeft.EDirection.ToString());
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_ENABLED, this.m_ORecipe.OBackLeft.BEnabled);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_ANGLE_LOW, this.m_ORecipe.OBackLeft.F64AngleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_ANGLE_HIGH, this.m_ORecipe.OBackLeft.F64AngleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_SCALE_LOW, this.m_ORecipe.OBackLeft.F64ScaleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_SCALE_HIGH, this.m_ORecipe.OBackLeft.F64ScaleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_MIN_SCORE, this.m_ORecipe.OBackLeft.F64MinScore);

                    I32RowIndex = CDB.It[CDB.TABLE_RECIPE_INFO].InsertRow();
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_RECIPE, this.m_ORecipe.StrName);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_DIRECTION, this.m_ORecipe.OBackRight.EDirection.ToString());
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_ENABLED, this.m_ORecipe.OBackRight.BEnabled);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_ANGLE_LOW, this.m_ORecipe.OBackRight.F64AngleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_ANGLE_HIGH, this.m_ORecipe.OBackRight.F64AngleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_SCALE_LOW, this.m_ORecipe.OBackRight.F64ScaleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_SCALE_HIGH, this.m_ORecipe.OBackRight.F64ScaleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(I32RowIndex, CDB.RECIPE_INFO_COLUMN_MIN_SCORE, this.m_ORecipe.OBackRight.F64MinScore);

                    CDB.It[CDB.TABLE_RECIPE_LIST].Commit();
                    CDB.It[CDB.TABLE_RECIPE_INFO].Commit();


                    CRecipeManager.It.LstORecipe.Add(new CShampFaultRecipe(this.m_ORecipe));
                    this.RefreshRecipeList();
                }
                else
                {
                    List<int> LstI32RowIndex = CDB.It[CDB.TABLE_RECIPE_INFO].SelectRowIndexs
                    (
                        new string[] { CDB.RECIPE_INFO_COLUMN_RECIPE, CDB.RECIPE_INFO_COLUMN_DIRECTION },
                        new object[] { this.m_ORecipe.StrName, this.m_ORecipe.OFrontLeft.EDirection.ToString() }
                    );
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_ENABLED, this.m_ORecipe.OFrontLeft.BEnabled);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_ANGLE_LOW, this.m_ORecipe.OFrontLeft.F64AngleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_ANGLE_HIGH, this.m_ORecipe.OFrontLeft.F64AngleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_SCALE_LOW, this.m_ORecipe.OFrontLeft.F64ScaleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_SCALE_HIGH, this.m_ORecipe.OFrontLeft.F64ScaleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_MIN_SCORE, this.m_ORecipe.OFrontLeft.F64MinScore);

                    LstI32RowIndex = CDB.It[CDB.TABLE_RECIPE_INFO].SelectRowIndexs
                    (
                        new string[] { CDB.RECIPE_INFO_COLUMN_RECIPE, CDB.RECIPE_INFO_COLUMN_DIRECTION },
                        new object[] { this.m_ORecipe.StrName, this.m_ORecipe.OFrontRight.EDirection.ToString() }
                    );
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_ENABLED, this.m_ORecipe.OFrontRight.BEnabled);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_ANGLE_LOW, this.m_ORecipe.OFrontRight.F64AngleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_ANGLE_HIGH, this.m_ORecipe.OFrontRight.F64AngleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_SCALE_LOW, this.m_ORecipe.OFrontRight.F64ScaleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_SCALE_HIGH, this.m_ORecipe.OFrontRight.F64ScaleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_MIN_SCORE, this.m_ORecipe.OFrontRight.F64MinScore);

                    LstI32RowIndex = CDB.It[CDB.TABLE_RECIPE_INFO].SelectRowIndexs
                    (
                        new string[] { CDB.RECIPE_INFO_COLUMN_RECIPE, CDB.RECIPE_INFO_COLUMN_DIRECTION },
                        new object[] { this.m_ORecipe.StrName, this.m_ORecipe.OBackLeft.EDirection.ToString() }
                    );
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_ENABLED, this.m_ORecipe.OBackLeft.BEnabled);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_ANGLE_LOW, this.m_ORecipe.OBackLeft.F64AngleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_ANGLE_HIGH, this.m_ORecipe.OBackLeft.F64AngleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_SCALE_LOW, this.m_ORecipe.OBackLeft.F64ScaleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_SCALE_HIGH, this.m_ORecipe.OBackLeft.F64ScaleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_MIN_SCORE, this.m_ORecipe.OBackLeft.F64MinScore);

                    LstI32RowIndex = CDB.It[CDB.TABLE_RECIPE_INFO].SelectRowIndexs
                    (
                        new string[] { CDB.RECIPE_INFO_COLUMN_RECIPE, CDB.RECIPE_INFO_COLUMN_DIRECTION },
                        new object[] { this.m_ORecipe.StrName, this.m_ORecipe.OBackRight.EDirection.ToString() }
                    );
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_ENABLED, this.m_ORecipe.OBackRight.BEnabled);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_ANGLE_LOW, this.m_ORecipe.OBackRight.F64AngleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_ANGLE_HIGH, this.m_ORecipe.OBackRight.F64AngleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_SCALE_LOW, this.m_ORecipe.OBackRight.F64ScaleLow);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_SCALE_HIGH, this.m_ORecipe.OBackRight.F64ScaleHigh);
                    CDB.It[CDB.TABLE_RECIPE_INFO].Update(LstI32RowIndex[0], CDB.RECIPE_INFO_COLUMN_MIN_SCORE, this.m_ORecipe.OBackRight.F64MinScore);

                    CDB.It[CDB.TABLE_RECIPE_INFO].Commit();


                    for (int _Index = 0; _Index < CRecipeManager.It.LstORecipe.Count; _Index++)
                    {
                        if (CRecipeManager.It.LstORecipe[_Index].StrName != this.m_ORecipe.StrName) continue;

                        CRecipeManager.It.LstORecipe[_Index] = new CShampFaultRecipe(this.m_ORecipe);
                        break;
                    }
                    if (CShampFaultTool.It.ORecipe != null)
                    {
                        if (CShampFaultTool.It.ORecipe.StrName == this.m_ORecipe.StrName)
                        {
                            CShampFaultTool.It.ORecipe = new CShampFaultRecipe(this.m_ORecipe);
                        }
                    }
                }

                this.BtnCancel.PerformClick();
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_BPreventEvent = true;


                this.m_EEdit = EEDIT.NONE;
                if (this.m_ORecipe != null)
                {
                    this.m_ORecipe.Dispose();
                    this.m_ORecipe = null;
                }


                this.CdpFrontLeft.InteractiveGraphics.Clear();
                this.CdpFrontRight.InteractiveGraphics.Clear();
                this.CdpBackLeft.InteractiveGraphics.Clear();
                this.CdpBackRight.InteractiveGraphics.Clear();

                this.TxtName.Text = string.Empty;
                this.BtnAdd.BackColor = Color.SteelBlue;
                this.BtnModify.BackColor = Color.SteelBlue;
                this.BtnDelete.BackColor = Color.SteelBlue;
                this.BtnSave.BackColor = SystemColors.Control;
                this.BtnCancel.BackColor = SystemColors.Control;
                this.BtnApply.BackColor = Color.SteelBlue;
                this.CdpFrontLeft.Image = null;
                this.ChkFrontLeftEnabled.Text = "Disable";
                this.ChkFrontLeftEnabled.BackColor = SystemColors.Control;
                this.ChkFrontLeftEnabled.Checked = false;
                this.NudFrontLeftAngleLow.Value = -45;
                this.NudFrontLeftAngleLow.Controls[1].Text = string.Empty;
                this.NudFrontLeftAngleHigh.Value = 45;
                this.NudFrontLeftAngleHigh.Controls[1].Text = string.Empty;
                this.NudFrontLeftScaleLow.Value = Convert.ToDecimal(0.8);
                this.NudFrontLeftScaleLow.Controls[1].Text = string.Empty;
                this.NudFrontLeftScaleHigh.Value = Convert.ToDecimal(1.2);
                this.NudFrontLeftScaleHigh.Controls[1].Text = string.Empty;
                this.NudFrontLeftMinScore.Value = 80;
                this.NudFrontLeftMinScore.Controls[1].Text = string.Empty;
                this.BtnFrontLeftGrap.BackColor = SystemColors.Control;
                this.BtnFrontLeftTrain.BackColor = SystemColors.Control;
                this.CdpFrontRight.Image = null;
                this.ChkFrontRightEnabled.Text = "Disable";
                this.ChkFrontRightEnabled.Checked = false;
                this.ChkFrontRightEnabled.BackColor = SystemColors.Control;
                this.NudFrontRightAngleLow.Value = -45;
                this.NudFrontRightAngleLow.Controls[1].Text = string.Empty;
                this.NudFrontRightAngleHigh.Value = 45;
                this.NudFrontRightAngleHigh.Controls[1].Text = string.Empty;
                this.NudFrontRightScaleLow.Value = Convert.ToDecimal(0.8);
                this.NudFrontRightScaleLow.Controls[1].Text = string.Empty;
                this.NudFrontRightScaleHigh.Value = Convert.ToDecimal(1.2);
                this.NudFrontRightScaleHigh.Controls[1].Text = string.Empty;
                this.NudFrontRightMinScore.Value = 80;
                this.NudFrontRightMinScore.Controls[1].Text = string.Empty;
                this.BtnFrontRightGrap.BackColor = SystemColors.Control;
                this.BtnFrontRightTrain.BackColor = SystemColors.Control;
                this.CdpBackLeft.Image = null;
                this.ChkBackLeftEnabled.Text = "Disable";
                this.ChkBackLeftEnabled.Checked = false;
                this.ChkBackLeftEnabled.BackColor = SystemColors.Control;
                this.NudBackLeftAngleLow.Value = -45;
                this.NudBackLeftAngleLow.Controls[1].Text = string.Empty;
                this.NudBackLeftAngleHigh.Value = 45;
                this.NudBackLeftAngleHigh.Controls[1].Text = string.Empty;
                this.NudBackLeftScaleLow.Value = Convert.ToDecimal(0.8);
                this.NudBackLeftScaleLow.Controls[1].Text = string.Empty;
                this.NudBackLeftScaleHigh.Value = Convert.ToDecimal(1.2);
                this.NudBackLeftScaleHigh.Controls[1].Text = string.Empty;
                this.NudBackLeftMinScore.Value = 80;
                this.NudBackLeftMinScore.Controls[1].Text = string.Empty;
                this.BtnBackLeftGrap.BackColor = SystemColors.Control;
                this.BtnBackLeftTrain.BackColor = SystemColors.Control;
                this.CdpBackRight.Image = null;
                this.ChkBackRightEnabled.Text = "Disable";
                this.ChkBackRightEnabled.Checked = false;
                this.ChkBackRightEnabled.BackColor = SystemColors.Control;
                this.NudBackRightAngleLow.Value = -45;
                this.NudBackRightAngleLow.Controls[1].Text = string.Empty;
                this.NudBackRightAngleHigh.Value = 45;
                this.NudBackRightAngleHigh.Controls[1].Text = string.Empty;
                this.NudBackRightScaleLow.Value = Convert.ToDecimal(0.8);
                this.NudBackRightScaleLow.Controls[1].Text = string.Empty;
                this.NudBackRightScaleHigh.Value = Convert.ToDecimal(1.2);
                this.NudBackRightScaleHigh.Controls[1].Text = string.Empty;
                this.NudBackRightMinScore.Value = 80;
                this.NudBackRightMinScore.Controls[1].Text = string.Empty;
                this.BtnBackRightGrap.BackColor = SystemColors.Control;
                this.BtnBackRightTrain.BackColor = SystemColors.Control;

                this.TxtName.Enabled = true;
                this.BtnAdd.Enabled = true;
                this.BtnModify.Enabled = true;
                this.BtnDelete.Enabled = true;
                this.BtnSave.Enabled = false;
                this.BtnCancel.Enabled = false;
                this.BtnApply.Enabled = true;
                this.ChkFrontLeftEnabled.Enabled = false;
                this.NudFrontLeftAngleLow.Enabled = false;
                this.NudFrontLeftAngleHigh.Enabled = false;
                this.NudFrontLeftScaleLow.Enabled = false;
                this.NudFrontLeftScaleHigh.Enabled = false;
                this.NudFrontLeftMinScore.Enabled = false;
                this.BtnFrontLeftGrap.Enabled = false;
                this.BtnFrontLeftTrain.Enabled = false;
                this.ChkFrontRightEnabled.Enabled = false;
                this.NudFrontRightAngleLow.Enabled = false;
                this.NudFrontRightAngleHigh.Enabled = false;
                this.NudFrontRightScaleLow.Enabled = false;
                this.NudFrontRightScaleHigh.Enabled = false;
                this.NudFrontRightMinScore.Enabled = false;
                this.BtnFrontRightGrap.Enabled = false;
                this.BtnFrontRightTrain.Enabled = false;
                this.ChkBackLeftEnabled.Enabled = false;
                this.NudBackLeftAngleLow.Enabled = false;
                this.NudBackLeftAngleHigh.Enabled = false;
                this.NudBackLeftScaleLow.Enabled = false;
                this.NudBackLeftScaleHigh.Enabled = false;
                this.NudBackLeftMinScore.Enabled = false;
                this.BtnBackLeftGrap.Enabled = false;
                this.BtnBackLeftTrain.Enabled = false;
                this.ChkBackRightEnabled.Enabled = false;
                this.NudBackRightAngleLow.Enabled = false;
                this.NudBackRightAngleHigh.Enabled = false;
                this.NudBackRightScaleLow.Enabled = false;
                this.NudBackRightScaleHigh.Enabled = false;
                this.NudBackRightMinScore.Enabled = false;
                this.BtnBackRightGrap.Enabled = false;
                this.BtnBackRightTrain.Enabled = false;


                base.OnScreenFixed(false);
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


        private void BtnGrab_Click(object sender, EventArgs e)
        {
            try
            {
                ECAMERA ECamera = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)((Button)sender).Tag);

                if (ECamera == ECAMERA.FRONT_LEFT)
                {
                    if (File.Exists(".\\RECIPE\\IMAGE\\FRONT_LEFT.bmp") == true)
                    {
                        Bitmap OSource = new Bitmap(".\\RECIPE\\IMAGE\\FRONT_LEFT.bmp");
                        CogImage8Grey OImage = new CogImage8Grey(OSource);
                        OSource.Dispose();

                        this.m_ORecipe.OFrontLeft.OTool.Pattern.TrainImage = OImage;
                        this.CdpFrontLeft.Image = OImage;
                    }
                    else CMsgBox.Warning("The not existed image is existed");
                }
                else if (ECamera == ECAMERA.FRONT_RIGHT)
                {
                    if (File.Exists(".\\RECIPE\\IMAGE\\FRONT_RIGHT.bmp") == true)
                    {
                        Bitmap OSource = new Bitmap(".\\RECIPE\\IMAGE\\FRONT_RIGHT.bmp");
                        CogImage8Grey OImage = new CogImage8Grey(OSource);
                        OSource.Dispose();

                        this.m_ORecipe.OFrontRight.OTool.Pattern.TrainImage = OImage;
                        this.CdpFrontRight.Image = OImage;
                    }
                    else CMsgBox.Warning("The not existed image is existed");
                }
                else if (ECamera == ECAMERA.BACK_LEFT)
                {
                    if (File.Exists(".\\RECIPE\\IMAGE\\BACK_LEFT.bmp") == true)
                    {
                        Bitmap OSource = new Bitmap(".\\RECIPE\\IMAGE\\BACK_LEFT.bmp");
                        CogImage8Grey OImage = new CogImage8Grey(OSource);
                        OSource.Dispose();

                        this.m_ORecipe.OBackLeft.OTool.Pattern.TrainImage = OImage;
                        this.CdpBackLeft.Image = OImage;
                    }
                    else CMsgBox.Warning("The not existed image is existed");
                }
                else if (ECamera == ECAMERA.BACK_RIGHT)
                {
                    if (File.Exists(".\\RECIPE\\IMAGE\\BACK_RIGHT.bmp") == true)
                    {
                        Bitmap OSource = new Bitmap(".\\RECIPE\\IMAGE\\BACK_RIGHT.bmp");
                        CogImage8Grey OImage = new CogImage8Grey(OSource);
                        OSource.Dispose();

                        this.m_ORecipe.OBackRight.OTool.Pattern.TrainImage = OImage;
                        this.CdpBackRight.Image = OImage;
                    }
                    else CMsgBox.Warning("The not existed image is existed");
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                string StrName = (string)this.LtbRecipeList.SelectedItem;
                if (String.IsNullOrEmpty(StrName) == true)
                {
                    CMsgBox.Warning("Please select recipe infomation to modfiy!");
                    return;
                }
                if (CShampFaultTool.It.ORecipe != null)
                {
                    if (CShampFaultTool.It.ORecipe.StrName == StrName) return;
                }


                CEnvironment.It.StrMainRecipe = StrName;
                CEnvironment.It.Commit();


                foreach (IRecipe _Item in CRecipeManager.It.LstORecipe)
                {
                    if (_Item.StrName != StrName) continue;

                    CShampFaultTool.It.ORecipe = new CShampFaultRecipe((CShampFaultRecipe)_Item);
                    break;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnTrain_Click(object sender, EventArgs e)
        {
            try
            {
                ECAMERA EDirection = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)((Button)sender).Tag);

                switch (EDirection)
                {
                    case ECAMERA.FRONT_LEFT:
                        this.m_ORecipe.OFrontLeft.OTool.Pattern.Train();
                        break;

                    case ECAMERA.FRONT_RIGHT:
                        this.m_ORecipe.OFrontRight.OTool.Pattern.Train();
                        break;

                    case ECAMERA.BACK_LEFT:
                        this.m_ORecipe.OBackLeft.OTool.Pattern.Train();
                        break;

                    case ECAMERA.BACK_RIGHT:
                        this.m_ORecipe.OBackRight.OTool.Pattern.Train();
                        break;
                }

                CMsgBox.Info("Trained Successfully!");
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region ETC EVENT
        private void ChkEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_BPreventEvent == true) return;

            try
            {
                ECAMERA EDirection = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)((CheckBox)sender).Tag);

                switch (EDirection)
                {
                    case ECAMERA.FRONT_LEFT:
                        if (this.ChkFrontLeftEnabled.Checked == true)
                        {
                            ((ICogGraphicInteractive)this.m_ORecipe.OFrontLeft.OTool.Pattern.TrainRegion).Visible = true;
                            ((ICogGraphicInteractive)this.m_ORecipe.OFrontLeft.OTool.SearchRegion).Visible = true;

                            this.ChkFrontLeftEnabled.Text = "Enable";
                            this.ChkFrontLeftEnabled.BackColor = Color.ForestGreen;
                            this.NudFrontLeftAngleLow.Value = Convert.ToDecimal(this.m_ORecipe.OFrontLeft.F64AngleLow);
                            this.NudFrontLeftAngleLow.Controls[1].Text = this.NudFrontLeftAngleLow.Value.ToString("0.0");
                            this.NudFrontLeftAngleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OFrontLeft.F64AngleHigh);
                            this.NudFrontLeftAngleHigh.Controls[1].Text = this.NudFrontLeftAngleHigh.Value.ToString("0.0");
                            this.NudFrontLeftScaleLow.Value = Convert.ToDecimal(this.m_ORecipe.OFrontLeft.F64ScaleLow);
                            this.NudFrontLeftScaleLow.Controls[1].Text = this.NudFrontLeftScaleLow.Value.ToString("0.0");
                            this.NudFrontLeftScaleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OFrontLeft.F64ScaleHigh);
                            this.NudFrontLeftScaleHigh.Controls[1].Text = this.NudFrontLeftScaleHigh.Value.ToString("0.0");
                            this.NudFrontLeftMinScore.Value = Convert.ToDecimal(this.m_ORecipe.OFrontLeft.F64MinScore);
                            this.NudFrontLeftMinScore.Controls[1].Text = this.NudFrontLeftMinScore.Value.ToString("0.0");
                            this.BtnFrontLeftGrap.BackColor = Color.SteelBlue;
                            this.BtnFrontLeftTrain.BackColor = Color.SteelBlue;

                            this.NudFrontLeftAngleLow.Enabled = true;
                            this.NudFrontLeftAngleHigh.Enabled = true;
                            this.NudFrontLeftScaleLow.Enabled = true;
                            this.NudFrontLeftScaleHigh.Enabled = true;
                            this.NudFrontLeftMinScore.Enabled = true;
                            this.BtnFrontLeftGrap.Enabled = true;
                            this.BtnFrontLeftTrain.Enabled = true;
                        }
                        else
                        {
                            ((ICogGraphicInteractive)this.m_ORecipe.OFrontLeft.OTool.Pattern.TrainRegion).Visible = false;
                            ((ICogGraphicInteractive)this.m_ORecipe.OFrontLeft.OTool.SearchRegion).Visible = false;

                            this.ChkFrontLeftEnabled.Text = "Disable";
                            this.ChkFrontLeftEnabled.BackColor = Color.SteelBlue;
                            this.NudFrontLeftAngleLow.Controls[1].Text = string.Empty;
                            this.NudFrontLeftAngleHigh.Controls[1].Text = string.Empty;
                            this.NudFrontLeftScaleLow.Controls[1].Text = string.Empty;
                            this.NudFrontLeftScaleHigh.Controls[1].Text = string.Empty;
                            this.NudFrontLeftMinScore.Controls[1].Text = string.Empty;
                            this.BtnFrontLeftGrap.BackColor = SystemColors.Control;
                            this.BtnFrontLeftTrain.BackColor = SystemColors.Control;

                            this.NudFrontLeftAngleLow.Enabled = false;
                            this.NudFrontLeftAngleHigh.Enabled = false;
                            this.NudFrontLeftScaleLow.Enabled = false;
                            this.NudFrontLeftScaleHigh.Enabled = false;
                            this.NudFrontLeftMinScore.Enabled = false;
                            this.BtnFrontLeftGrap.Enabled = false;
                            this.BtnFrontLeftTrain.Enabled = false;
                        }
                        break;

                    case ECAMERA.FRONT_RIGHT:
                        if (this.ChkFrontRightEnabled.Checked == true)
                        {
                            ((ICogGraphicInteractive)this.m_ORecipe.OFrontRight.OTool.Pattern.TrainRegion).Visible = true;
                            ((ICogGraphicInteractive)this.m_ORecipe.OFrontRight.OTool.SearchRegion).Visible = true;

                            this.ChkFrontRightEnabled.Text = "Enable";
                            this.ChkFrontRightEnabled.BackColor = Color.ForestGreen;
                            this.NudFrontRightAngleLow.Value = Convert.ToDecimal(this.m_ORecipe.OFrontRight.F64AngleLow);
                            this.NudFrontRightAngleLow.Controls[1].Text = this.NudFrontRightAngleLow.Value.ToString("0.0");
                            this.NudFrontRightAngleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OFrontRight.F64AngleHigh);
                            this.NudFrontRightAngleHigh.Controls[1].Text = this.NudFrontRightAngleHigh.Value.ToString("0.0");
                            this.NudFrontRightScaleLow.Value = Convert.ToDecimal(this.m_ORecipe.OFrontRight.F64ScaleLow);
                            this.NudFrontRightScaleLow.Controls[1].Text = this.NudFrontRightScaleLow.Value.ToString("0.0");
                            this.NudFrontRightScaleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OFrontRight.F64ScaleHigh);
                            this.NudFrontRightScaleHigh.Controls[1].Text = this.NudFrontRightScaleHigh.Value.ToString("0.0");
                            this.NudFrontRightMinScore.Value = Convert.ToDecimal(this.m_ORecipe.OFrontRight.F64MinScore);
                            this.NudFrontRightMinScore.Controls[1].Text = this.NudFrontRightMinScore.Value.ToString("0.0");
                            this.BtnFrontRightGrap.BackColor = Color.SteelBlue;
                            this.BtnFrontRightTrain.BackColor = Color.SteelBlue;

                            this.NudFrontRightAngleLow.Enabled = true;
                            this.NudFrontRightAngleHigh.Enabled = true;
                            this.NudFrontRightScaleLow.Enabled = true;
                            this.NudFrontRightScaleHigh.Enabled = true;
                            this.NudFrontRightMinScore.Enabled = true;
                            this.BtnFrontRightGrap.Enabled = true;
                            this.BtnFrontRightTrain.Enabled = true;
                        }
                        else
                        {
                            ((ICogGraphicInteractive)this.m_ORecipe.OFrontRight.OTool.Pattern.TrainRegion).Visible = false;
                            ((ICogGraphicInteractive)this.m_ORecipe.OFrontRight.OTool.SearchRegion).Visible = false;

                            this.ChkFrontRightEnabled.Text = "Disable";
                            this.ChkFrontRightEnabled.BackColor = Color.SteelBlue;
                            this.NudFrontRightAngleLow.Controls[1].Text = string.Empty;
                            this.NudFrontRightAngleHigh.Controls[1].Text = string.Empty;
                            this.NudFrontRightScaleLow.Controls[1].Text = string.Empty;
                            this.NudFrontRightScaleHigh.Controls[1].Text = string.Empty;
                            this.NudFrontRightMinScore.Controls[1].Text = string.Empty;
                            this.BtnFrontRightGrap.BackColor = SystemColors.Control;
                            this.BtnFrontRightTrain.BackColor = SystemColors.Control;

                            this.NudFrontRightAngleLow.Enabled = false;
                            this.NudFrontRightAngleHigh.Enabled = false;
                            this.NudFrontRightScaleLow.Enabled = false;
                            this.NudFrontRightScaleHigh.Enabled = false;
                            this.NudFrontRightMinScore.Enabled = false;
                            this.BtnFrontRightGrap.Enabled = false;
                            this.BtnFrontRightTrain.Enabled = false;
                        }
                        break;

                    case ECAMERA.BACK_LEFT:
                        if (this.ChkBackLeftEnabled.Checked == true)
                        {
                            ((ICogGraphicInteractive)this.m_ORecipe.OBackLeft.OTool.Pattern.TrainRegion).Visible = true;
                            ((ICogGraphicInteractive)this.m_ORecipe.OBackLeft.OTool.SearchRegion).Visible = true;

                            this.ChkBackLeftEnabled.Text = "Enable";
                            this.ChkBackLeftEnabled.BackColor = Color.ForestGreen;
                            this.NudBackLeftAngleLow.Value = Convert.ToDecimal(this.m_ORecipe.OBackLeft.F64AngleLow);
                            this.NudBackLeftAngleLow.Controls[1].Text = this.NudBackLeftAngleLow.Value.ToString("0.0");
                            this.NudBackLeftAngleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OBackLeft.F64AngleHigh);
                            this.NudBackLeftAngleHigh.Controls[1].Text = this.NudBackLeftAngleHigh.Value.ToString("0.0");
                            this.NudBackLeftScaleLow.Value = Convert.ToDecimal(this.m_ORecipe.OBackLeft.F64ScaleLow);
                            this.NudBackLeftScaleLow.Controls[1].Text = this.NudBackLeftScaleLow.Value.ToString("0.0");
                            this.NudBackLeftScaleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OBackLeft.F64ScaleHigh);
                            this.NudBackLeftScaleHigh.Controls[1].Text = this.NudBackLeftScaleHigh.Value.ToString("0.0");
                            this.NudBackLeftMinScore.Value = Convert.ToDecimal(this.m_ORecipe.OBackLeft.F64MinScore);
                            this.NudBackLeftMinScore.Controls[1].Text = this.NudBackLeftMinScore.Value.ToString("0.0");
                            this.BtnBackLeftGrap.BackColor = Color.SteelBlue;
                            this.BtnBackLeftTrain.BackColor = Color.SteelBlue;

                            this.NudBackLeftAngleLow.Enabled = true;
                            this.NudBackLeftAngleHigh.Enabled = true;
                            this.NudBackLeftScaleLow.Enabled = true;
                            this.NudBackLeftScaleHigh.Enabled = true;
                            this.NudBackLeftMinScore.Enabled = true;
                            this.BtnBackLeftGrap.Enabled = true;
                            this.BtnBackLeftTrain.Enabled = true;
                        }
                        else
                        {
                            ((ICogGraphicInteractive)this.m_ORecipe.OBackLeft.OTool.Pattern.TrainRegion).Visible = false;
                            ((ICogGraphicInteractive)this.m_ORecipe.OBackLeft.OTool.SearchRegion).Visible = false;

                            this.ChkBackLeftEnabled.Text = "Disable";
                            this.ChkBackLeftEnabled.BackColor = Color.SteelBlue;
                            this.NudBackLeftAngleLow.Controls[1].Text = string.Empty;
                            this.NudBackLeftAngleHigh.Controls[1].Text = string.Empty;
                            this.NudBackLeftScaleLow.Controls[1].Text = string.Empty;
                            this.NudBackLeftScaleHigh.Controls[1].Text = string.Empty;
                            this.NudBackLeftMinScore.Controls[1].Text = string.Empty;
                            this.BtnBackLeftGrap.BackColor = SystemColors.Control;
                            this.BtnBackLeftTrain.BackColor = SystemColors.Control;

                            this.NudBackLeftAngleLow.Enabled = false;
                            this.NudBackLeftAngleHigh.Enabled = false;
                            this.NudBackLeftScaleLow.Enabled = false;
                            this.NudBackLeftScaleHigh.Enabled = false;
                            this.NudBackLeftMinScore.Enabled = false;
                            this.BtnBackLeftGrap.Enabled = false;
                            this.BtnBackLeftTrain.Enabled = false;
                        }
                        break;

                    case ECAMERA.BACK_RIGHT:
                        if (this.ChkBackRightEnabled.Checked == true)
                        {
                            ((ICogGraphicInteractive)this.m_ORecipe.OBackRight.OTool.Pattern.TrainRegion).Visible = true;
                            ((ICogGraphicInteractive)this.m_ORecipe.OBackRight.OTool.SearchRegion).Visible = true;

                            this.ChkBackRightEnabled.Text = "Enable";
                            this.ChkBackRightEnabled.BackColor = Color.ForestGreen;
                            this.NudBackRightAngleLow.Value = Convert.ToDecimal(this.m_ORecipe.OBackRight.F64AngleLow);
                            this.NudBackRightAngleLow.Controls[1].Text = this.NudBackRightAngleLow.Value.ToString("0.0");
                            this.NudBackRightAngleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OBackRight.F64AngleHigh);
                            this.NudBackRightAngleHigh.Controls[1].Text = this.NudBackRightAngleHigh.Value.ToString("0.0");
                            this.NudBackRightScaleLow.Value = Convert.ToDecimal(this.m_ORecipe.OBackRight.F64ScaleLow);
                            this.NudBackRightScaleLow.Controls[1].Text = this.NudBackRightScaleLow.Value.ToString("0.0");
                            this.NudBackRightScaleHigh.Value = Convert.ToDecimal(this.m_ORecipe.OBackRight.F64ScaleHigh);
                            this.NudBackRightScaleHigh.Controls[1].Text = this.NudBackRightScaleHigh.Value.ToString("0.0");
                            this.NudBackRightMinScore.Value = Convert.ToDecimal(this.m_ORecipe.OBackRight.F64MinScore);
                            this.NudBackRightMinScore.Controls[1].Text = this.NudBackRightMinScore.Value.ToString("0.0");
                            this.BtnBackRightGrap.BackColor = Color.SteelBlue;
                            this.BtnBackRightTrain.BackColor = Color.SteelBlue;

                            this.NudBackRightAngleLow.Enabled = true;
                            this.NudBackRightAngleHigh.Enabled = true;
                            this.NudBackRightScaleLow.Enabled = true;
                            this.NudBackRightScaleHigh.Enabled = true;
                            this.NudBackRightMinScore.Enabled = true;
                            this.BtnBackRightGrap.Enabled = true;
                            this.BtnBackRightTrain.Enabled = true;
                        }
                        else
                        {
                            ((ICogGraphicInteractive)this.m_ORecipe.OBackRight.OTool.Pattern.TrainRegion).Visible = false;
                            ((ICogGraphicInteractive)this.m_ORecipe.OBackRight.OTool.SearchRegion).Visible = false;

                            this.ChkBackRightEnabled.Text = "Disable";
                            this.ChkBackRightEnabled.BackColor = Color.SteelBlue;
                            this.NudBackRightAngleLow.Controls[1].Text = string.Empty;
                            this.NudBackRightAngleHigh.Controls[1].Text = string.Empty;
                            this.NudBackRightScaleLow.Controls[1].Text = string.Empty;
                            this.NudBackRightScaleHigh.Controls[1].Text = string.Empty;
                            this.NudBackRightMinScore.Controls[1].Text = string.Empty;
                            this.BtnBackRightGrap.BackColor = SystemColors.Control;
                            this.BtnBackRightTrain.BackColor = SystemColors.Control;

                            this.NudBackRightAngleLow.Enabled = false;
                            this.NudBackRightAngleHigh.Enabled = false;
                            this.NudBackRightScaleLow.Enabled = false;
                            this.NudBackRightScaleHigh.Enabled = false;
                            this.NudBackRightMinScore.Enabled = false;
                            this.BtnBackRightGrap.Enabled = false;
                            this.BtnBackRightTrain.Enabled = false;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnOpenToolRuler_Click(object sender, EventArgs e)
        {
            try
            {
                int I32RowIndex1 = CDB.It[CDB.TABLE_TOOL_RULER].SelectRowIndex(CDB.TOOL_RULER_COLUMN_SEQ, 1);
                int I32RowIndex2 = CDB.It[CDB.TABLE_TOOL_RULER].SelectRowIndex(CDB.TOOL_RULER_COLUMN_SEQ, 2);
                int I32RowIndex3 = CDB.It[CDB.TABLE_TOOL_RULER].SelectRowIndex(CDB.TOOL_RULER_COLUMN_SEQ, 3);
                int I32RowIndex4 = CDB.It[CDB.TABLE_TOOL_RULER].SelectRowIndex(CDB.TOOL_RULER_COLUMN_SEQ, 4);

                frmToolRuler OWindow = new frmToolRuler();
                OWindow.I32Index1 = (int)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex1, CDB.TOOL_RULER_COLUMN_INDEX);
                OWindow.I32Index2 = (int)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex2, CDB.TOOL_RULER_COLUMN_INDEX);
                OWindow.I32Index3 = (int)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex3, CDB.TOOL_RULER_COLUMN_INDEX);
                OWindow.I32Index4 = (int)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex4, CDB.TOOL_RULER_COLUMN_INDEX);
                OWindow.ECamera1 = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex1, CDB.TOOL_RULER_COLUMN_CAMERA));
                OWindow.ECamera2 = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex2, CDB.TOOL_RULER_COLUMN_CAMERA));
                OWindow.ECamera3 = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex3, CDB.TOOL_RULER_COLUMN_CAMERA));
                OWindow.ECamera4 = (ECAMERA)Enum.Parse(typeof(ECAMERA), (string)CDB.It[CDB.TABLE_TOOL_RULER].Select(I32RowIndex4, CDB.TOOL_RULER_COLUMN_CAMERA));

                if (OWindow.ShowDialog() == DialogResult.OK)
                {
                    CDB.It[CDB.TABLE_TOOL_RULER].Update(I32RowIndex1, CDB.TOOL_RULER_COLUMN_INDEX, OWindow.I32Index1);
                    CDB.It[CDB.TABLE_TOOL_RULER].Update(I32RowIndex2, CDB.TOOL_RULER_COLUMN_INDEX, OWindow.I32Index2);
                    CDB.It[CDB.TABLE_TOOL_RULER].Update(I32RowIndex3, CDB.TOOL_RULER_COLUMN_INDEX, OWindow.I32Index3);
                    CDB.It[CDB.TABLE_TOOL_RULER].Update(I32RowIndex4, CDB.TOOL_RULER_COLUMN_INDEX, OWindow.I32Index4);
                    CDB.It[CDB.TABLE_TOOL_RULER].Update(I32RowIndex1, CDB.TOOL_RULER_COLUMN_CAMERA, OWindow.ECamera1.ToString());
                    CDB.It[CDB.TABLE_TOOL_RULER].Update(I32RowIndex2, CDB.TOOL_RULER_COLUMN_CAMERA, OWindow.ECamera2.ToString());
                    CDB.It[CDB.TABLE_TOOL_RULER].Update(I32RowIndex3, CDB.TOOL_RULER_COLUMN_CAMERA, OWindow.ECamera3.ToString());
                    CDB.It[CDB.TABLE_TOOL_RULER].Update(I32RowIndex4, CDB.TOOL_RULER_COLUMN_CAMERA, OWindow.ECamera4.ToString());
                    CDB.It[CDB.TABLE_TOOL_RULER].Commit();

                    int[] ArrI32Index = new int[4];
                    ArrI32Index[0] = OWindow.I32Index1;
                    ArrI32Index[1] = OWindow.I32Index2;
                    ArrI32Index[2] = OWindow.I32Index3;
                    ArrI32Index[3] = OWindow.I32Index4;
                    ECAMERA[] ArrECamera = new ECAMERA[4];
                    ArrECamera[0] = OWindow.ECamera1;
                    ArrECamera[1] = OWindow.ECamera2;
                    ArrECamera[2] = OWindow.ECamera3;
                    ArrECamera[3] = OWindow.ECamera4;

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
            }
            catch (Exception ex)
            {
                CError.Show(ex);
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

                this.TxtName.Text = string.Empty;
                this.BtnAdd.BackColor = Color.SteelBlue;
                this.BtnModify.BackColor = Color.SteelBlue;
                this.BtnDelete.BackColor = Color.SteelBlue;
                this.BtnSave.BackColor = SystemColors.Control;
                this.BtnCancel.BackColor = SystemColors.Control;
                this.BtnApply.BackColor = Color.SteelBlue;
                this.CdpFrontLeft.Image = null;
                this.ChkFrontLeftEnabled.Text = "Disable";
                this.ChkFrontLeftEnabled.BackColor = SystemColors.Control;
                this.NudFrontLeftAngleLow.Value = -45;
                this.NudFrontLeftAngleLow.Controls[1].Text = string.Empty;
                this.NudFrontLeftAngleHigh.Value = 45;
                this.NudFrontLeftAngleHigh.Controls[1].Text = string.Empty;
                this.NudFrontLeftScaleLow.Value = Convert.ToDecimal(0.8);
                this.NudFrontLeftScaleLow.Controls[1].Text = string.Empty;
                this.NudFrontLeftScaleHigh.Value = Convert.ToDecimal(1.2);
                this.NudFrontLeftScaleHigh.Controls[1].Text = string.Empty;
                this.NudFrontLeftMinScore.Value = 80;
                this.NudFrontLeftMinScore.Controls[1].Text = string.Empty;
                this.BtnFrontLeftGrap.BackColor = SystemColors.Control;
                this.BtnFrontLeftTrain.BackColor = SystemColors.Control;
                this.CdpFrontRight.Image = null;
                this.ChkFrontRightEnabled.Text = "Disable";
                this.ChkFrontRightEnabled.BackColor = SystemColors.Control;
                this.NudFrontRightAngleLow.Value = -45;
                this.NudFrontRightAngleLow.Controls[1].Text = string.Empty;
                this.NudFrontRightAngleHigh.Value = 45;
                this.NudFrontRightAngleHigh.Controls[1].Text = string.Empty;
                this.NudFrontRightScaleLow.Value = Convert.ToDecimal(0.8);
                this.NudFrontRightScaleLow.Controls[1].Text = string.Empty;
                this.NudFrontRightScaleHigh.Value = Convert.ToDecimal(1.2);
                this.NudFrontRightScaleHigh.Controls[1].Text = string.Empty;
                this.NudFrontRightMinScore.Value = 80;
                this.NudFrontRightMinScore.Controls[1].Text = string.Empty;
                this.BtnFrontRightGrap.BackColor = SystemColors.Control;
                this.BtnFrontRightTrain.BackColor = SystemColors.Control;
                this.CdpBackLeft.Image = null;
                this.ChkBackLeftEnabled.Text = "Disable";
                this.ChkBackLeftEnabled.BackColor = SystemColors.Control;
                this.NudBackLeftAngleLow.Value = -45;
                this.NudBackLeftAngleLow.Controls[1].Text = string.Empty;
                this.NudBackLeftAngleHigh.Value = 45;
                this.NudBackLeftAngleHigh.Controls[1].Text = string.Empty;
                this.NudBackLeftScaleLow.Value = Convert.ToDecimal(0.8);
                this.NudBackLeftScaleLow.Controls[1].Text = string.Empty;
                this.NudBackLeftScaleHigh.Value = Convert.ToDecimal(1.2);
                this.NudBackLeftScaleHigh.Controls[1].Text = string.Empty;
                this.NudBackLeftMinScore.Value = 80;
                this.NudBackLeftMinScore.Controls[1].Text = string.Empty;
                this.BtnBackLeftGrap.BackColor = SystemColors.Control;
                this.BtnBackLeftTrain.BackColor = SystemColors.Control;
                this.CdpBackRight.Image = null;
                this.ChkBackRightEnabled.Text = "Disable";
                this.ChkBackRightEnabled.BackColor = SystemColors.Control;
                this.NudBackRightAngleLow.Value = -45;
                this.NudBackRightAngleLow.Controls[1].Text = string.Empty;
                this.NudBackRightAngleHigh.Value = 45;
                this.NudBackRightAngleHigh.Controls[1].Text = string.Empty;
                this.NudBackRightScaleLow.Value = Convert.ToDecimal(0.8);
                this.NudBackRightScaleLow.Controls[1].Text = string.Empty;
                this.NudBackRightScaleHigh.Value = Convert.ToDecimal(1.2);
                this.NudBackRightScaleHigh.Controls[1].Text = string.Empty;
                this.NudBackRightMinScore.Value = 80;
                this.NudBackRightMinScore.Controls[1].Text = string.Empty;
                this.BtnBackRightGrap.BackColor = SystemColors.Control;
                this.BtnBackRightTrain.BackColor = SystemColors.Control;

                this.TxtName.Enabled = true;
                this.BtnAdd.Enabled = true;
                this.BtnModify.Enabled = true;
                this.BtnDelete.Enabled = true;
                this.BtnSave.Enabled = false;
                this.BtnCancel.Enabled = false;
                this.BtnApply.Enabled = true;
                this.ChkFrontLeftEnabled.Enabled = false;
                this.NudFrontLeftAngleLow.Enabled = false;
                this.NudFrontLeftAngleHigh.Enabled = false;
                this.NudFrontLeftScaleLow.Enabled = false;
                this.NudFrontLeftScaleHigh.Enabled = false;
                this.NudFrontLeftMinScore.Enabled = false;
                this.BtnFrontLeftGrap.Enabled = false;
                this.BtnFrontLeftTrain.Enabled = false;
                this.ChkFrontRightEnabled.Enabled = false;
                this.NudFrontRightAngleLow.Enabled = false;
                this.NudFrontRightAngleHigh.Enabled = false;
                this.NudFrontRightScaleLow.Enabled = false;
                this.NudFrontRightScaleHigh.Enabled = false;
                this.NudFrontRightMinScore.Enabled = false;
                this.BtnFrontRightGrap.Enabled = false;
                this.BtnFrontRightTrain.Enabled = false;
                this.ChkBackLeftEnabled.Enabled = false;
                this.NudBackLeftAngleLow.Enabled = false;
                this.NudBackLeftAngleHigh.Enabled = false;
                this.NudBackLeftScaleLow.Enabled = false;
                this.NudBackLeftScaleHigh.Enabled = false;
                this.NudBackLeftMinScore.Enabled = false;
                this.BtnBackLeftGrap.Enabled = false;
                this.BtnBackLeftTrain.Enabled = false;
                this.ChkBackRightEnabled.Enabled = false;
                this.NudBackRightAngleLow.Enabled = false;
                this.NudBackRightAngleHigh.Enabled = false;
                this.NudBackRightScaleLow.Enabled = false;
                this.NudBackRightScaleHigh.Enabled = false;
                this.NudBackRightMinScore.Enabled = false;
                this.BtnBackRightGrap.Enabled = false;
                this.BtnBackRightTrain.Enabled = false;
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


        private void RefreshRecipeList()
        {
            try
            {
                this.LtbRecipeList.Items.Clear();
                foreach (IRecipe _Item in CRecipeManager.It.LstORecipe)
                {
                    this.LtbRecipeList.Items.Add(_Item.StrName);
                }
            }
            catch (Exception ex)
            {
                CError.Throw(ex);
            }
        }
        #endregion
    }


    #region ENUM
    public enum EEDIT : byte
    {
        NONE = 0x00,
        ADD,
        MODIFY,
        DELETE
    }
    #endregion
}
