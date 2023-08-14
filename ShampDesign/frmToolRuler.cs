using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Util.Print;

namespace ShampDesign
{
    public partial class frmToolRuler : Form
    {
        #region VARIABLE
        private int m_I32Index1 = 1;
        private int m_I32Index2 = 2;
        private int m_I32Index3 = 3;
        private int m_I32Index4 = 4;
        
        private ECAMERA m_ECamera1 = ECAMERA.FRONT_LEFT;
        private ECAMERA m_ECamera2 = ECAMERA.FRONT_RIGHT;
        private ECAMERA m_ECamera3 = ECAMERA.BACK_LEFT;
        private ECAMERA m_ECamera4 = ECAMERA.BACK_RIGHT;
        #endregion


        #region PROPERTIES
        public int I32Index1
        {
            get { return this.m_I32Index1; }
            set { this.m_I32Index1 = value; }
        }


        public int I32Index2
        {
            get { return this.m_I32Index2; }
            set { this.m_I32Index2 = value; }
        }


        public int I32Index3
        {
            get { return this.m_I32Index3; }
            set { this.m_I32Index3 = value; }
        }


        public int I32Index4
        {
            get { return this.m_I32Index4; }
            set { this.m_I32Index4 = value; }
        }


        public ECAMERA ECamera1
        {
            get { return this.m_ECamera1; }
            set { this.m_ECamera1 = value; }
        }


        public ECAMERA ECamera2
        {
            get { return this.m_ECamera2; }
            set { this.m_ECamera2 = value; }
        }


        public ECAMERA ECamera3
        {
            get { return this.m_ECamera3; }
            set { this.m_ECamera3 = value; }
        }


        public ECAMERA ECamera4
        {
            get { return this.m_ECamera4; }
            set { this.m_ECamera4 = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public frmToolRuler()
        {
            InitializeComponent();
        }
        #endregion


        #region EVENT
        #region FORM EVENT
        private void frmToolRuler_Load(object sender, EventArgs e)
        {
            try
            {
                this.CmbIndex1.Text = "1";
                this.CmbIndex2.Text = this.m_I32Index2.ToString();
                this.CmbIndex3.Text = this.m_I32Index3.ToString();
                this.CmbIndex4.Text = this.m_I32Index4.ToString();

                this.CmbCamera1.SelectedIndex = (int)this.m_ECamera1;
                this.CmbCamera2.SelectedIndex = (int)this.m_ECamera2;
                this.CmbCamera3.SelectedIndex = (int)this.m_ECamera3;
                this.CmbCamera4.SelectedIndex = (int)this.m_ECamera4;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion


        #region BUTTON EVENT
        private void BtnApply_Click(object sender, EventArgs e)
        {
            try
            {
                int[] ArrI32Index = new int[4];
                ArrI32Index[0] = Convert.ToInt32(this.CmbIndex1.Text);
                ArrI32Index[1] = Convert.ToInt32(this.CmbIndex2.Text);
                ArrI32Index[2] = Convert.ToInt32(this.CmbIndex3.Text);
                ArrI32Index[3] = Convert.ToInt32(this.CmbIndex4.Text);

                ECAMERA[] ArrECamera = new ECAMERA[4];
                ArrECamera[0] = (ECAMERA)Enum.ToObject(typeof(ECAMERA), this.CmbCamera1.SelectedIndex);
                ArrECamera[1] = (ECAMERA)Enum.ToObject(typeof(ECAMERA), this.CmbCamera2.SelectedIndex);
                ArrECamera[2] = (ECAMERA)Enum.ToObject(typeof(ECAMERA), this.CmbCamera3.SelectedIndex);
                ArrECamera[3] = (ECAMERA)Enum.ToObject(typeof(ECAMERA), this.CmbCamera4.SelectedIndex);


                for (int _Index = 1; _Index < ArrI32Index.Length; _Index++)
                {
                    if ((ArrI32Index[_Index - 1] != ArrI32Index[_Index]) && (ArrI32Index[_Index - 1] + 1 != ArrI32Index[_Index]))
                    {
                        CMsgBox.Warning("Please input index according to step by step.");
                        return;
                    }
                }

                for (int _Index1 = 0; _Index1 < ArrECamera.Length - 1; _Index1++)
                {
                    for (int _Index2 = _Index1 + 1; _Index2 < ArrECamera.Length; _Index2++)
                    {
                        if (ArrECamera[_Index1] == ArrECamera[_Index2])
                        {
                            CMsgBox.Warning("Cannot setup duplicate camera.");
                            return;
                        }
                    }
                }


                this.m_I32Index1 = ArrI32Index[0];
                this.m_I32Index2 = ArrI32Index[1];
                this.m_I32Index3 = ArrI32Index[2];
                this.m_I32Index4 = ArrI32Index[3];
                this.m_ECamera1 = ArrECamera[0];
                this.m_ECamera2 = ArrECamera[1];
                this.m_ECamera3 = ArrECamera[2];
                this.m_ECamera4 = ArrECamera[3];

                this.DialogResult = DialogResult.OK;
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
                this.DialogResult = DialogResult.Cancel;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
        #endregion

        
        #endregion
    }
}
