using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShampDesign
{
    public interface IIOProcessor
    {
        #region PROPERTIES
        bool BEnabled { get; set; }
        #endregion


        #region FUNCTION
        void On();
        void Off();
        bool ProcessOn();
        bool ProcessOff();
        #endregion
    }
}
