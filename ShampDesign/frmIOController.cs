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
    public partial class frmIOController : Form
    {
        #region VARIABLE
        private ushort m_U16ReadyPort = 0;
        private int m_I32ReadyOnInterval = 0;
        private int m_I32ReadyOffInterval = 0;

        private ushort m_U16NGPort = 0;
        private int m_I32NGInterval = 0;
        #endregion


        #region PROPERTIES
        public ushort U16ReadyPort
        {
            get { return this.m_U16ReadyPort; }
            set { this.m_U16ReadyPort = value; }
        }


        public int I32ReadyOnInterval
        {
            get { return this.m_I32ReadyOnInterval; }
            set { this.m_I32ReadyOnInterval = value; }
        }


        public int I32ReadyOffInterval
        {
            get { return this.m_I32ReadyOffInterval; }
            set { this.m_I32ReadyOffInterval = value; }
        }


        public ushort U16NGPort
        {
            get { return this.m_U16NGPort; }
            set { this.m_U16NGPort = value; }
        }


        public int I32NGInterval
        {
            get { return this.m_I32NGInterval; }
            set { this.m_I32NGInterval = value; }
        }
        #endregion


        #region CONSTRUCTOR & DESTRUCTOR
        public frmIOController()
        {
            InitializeComponent();
        }
        #endregion


        #region EVENT
        #region BUTTON EVENT
        private void frmIOController_Load(object sender, EventArgs e)
        {
            try
            {
                this.NudReadyPort.Value = this.m_U16ReadyPort;
                this.NudReadyOnInterval.Value = this.m_I32ReadyOnInterval;
                this.NudReadyOffInterval.Value = this.m_I32ReadyOffInterval;

                this.NudNGPort.Value = this.m_U16NGPort;
                this.NudNGOffInterval.Value = this.m_I32NGInterval;
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
                if (this.NudReadyPort.Value == this.NudNGPort.Value)
                {
                    CMsgBox.Warning("NG 포트와 READY 포트는 동일할 수 없습니다.");
                    return;
                }


                this.m_U16ReadyPort = Convert.ToUInt16(this.NudReadyPort.Value);
                this.m_I32ReadyOnInterval = Convert.ToUInt16(this.NudReadyOnInterval.Value);
                this.m_I32ReadyOffInterval = Convert.ToUInt16(this.NudReadyOffInterval.Value);

                this.m_U16NGPort = Convert.ToUInt16(this.NudNGPort.Value);
                this.m_I32NGInterval = Convert.ToUInt16(this.NudNGOffInterval.Value);


                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }


        private void BtnClose_Click(object sender, EventArgs e)
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
