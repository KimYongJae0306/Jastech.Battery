using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Jastech.Battery.Winform.UI.Forms;
using Jastech.Battery.Structure.Data;
using Jastech.Battery.Winform.Forms;
using Jastech.Battery.Winform;

namespace ESI.UI.Pages
{
    public partial class TeachingPage : UserControl
    {
        public TeachingPage()
        {
            InitializeComponent();
        }

        private void btnLowerInspectionPage_Click(object sender, EventArgs e)
        {
            InspectionTeachingForm form = new InspectionTeachingForm();
            form.InspDirection = InspDirection.Upper;
            form.ShowDialog();
        }

        private void btnUpperInspectionPage_Click(object sender, EventArgs e)
        {
            InspectionTeachingForm form = new InspectionTeachingForm();
            form.InspDirection = InspDirection.Lower;
            form.ShowDialog();
        }

        private void btnUpperCameraSetting_Click(object sender, EventArgs e)
        {
            OpticTeachingForm form = new OpticTeachingForm();
            form.LineCamera = LineCameraManager.Instance().GetLineCamera("Upper");
            form.ShowDialog();
        }

        private void btnLowerCameraSetting_Click(object sender, EventArgs e)
        {
            OpticTeachingForm form = new OpticTeachingForm();
            form.LineCamera = LineCameraManager.Instance().GetLineCamera("Lower");
            form.ShowDialog();
        }

        
    }
}
