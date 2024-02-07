﻿using System.IO;
using System.Windows.Forms;

namespace Jastech.Battery.Winform.UI.Controls
{
    public partial class LogControl : UserControl
    {
        #region 생성자
        public LogControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        public void DisplayOnLogFile(string path)
        {
            StreamReader sr = new StreamReader(path);
            string contents = sr.ReadToEnd().Replace("  위치:", "\r\n위치:");
            rtxLogMessage.Text = contents;

            sr.Close();
            sr.Dispose();
        }
        #endregion
    }
}
