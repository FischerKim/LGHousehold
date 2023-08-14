using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Jhjo.Util.Print;

namespace ShampDesign
{
    public partial class UcScreen : UserControl
    {
        #region CONSTRUCTOR & DESTRUCTOR
        public UcScreen()
        {
            InitializeComponent();
        }
        #endregion


        #region DELEGATE & EVENT
        public delegate void ScreenFixedHandler(bool BFixed);
        public event ScreenFixedHandler ScreenFixed = null;
        #endregion


        #region FUNCTION
        public virtual void OnAdd() { }
        public virtual void OnRemove() { }
        public virtual void OnTimer1000() { }


        protected void OnScreenFixed(bool BFixed)
        {
            try
            {
                if (this.ScreenFixed != null)
                {
                    this.ScreenFixed(BFixed);
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
