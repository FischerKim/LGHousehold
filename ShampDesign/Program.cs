using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Jhjo.Util.Print;
using Cognex.VisionPro;

namespace ShampDesign
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Environment.SetEnvironmentVariable("PYLON_GIGE_HEARTBEAT", "1000" /*ms*/);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);


                bool BPMAlign = CogMisc.IsLicensedFeatureEnabled("VxPatQuick");
                if (BPMAlign == false)
                {
                    CMsgBox.Warning("Please insert license key!");
                    return;
                }

                frmLoad OWindow = new frmLoad();
                if (OWindow.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new frmMain());
                }
            }
            catch (Exception ex)
            {
                CError.Show(ex);
            }
        }
    }
}
