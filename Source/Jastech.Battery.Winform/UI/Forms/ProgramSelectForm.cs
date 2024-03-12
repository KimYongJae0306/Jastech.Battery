using System.Windows.Forms;

namespace Jastech.Battery.Winform.Forms
{
    public partial class ProgramSelectForm : Form
    {
        public string SelectedProgramType => cbxProgramTypes.Text;

        public ProgramSelectForm()
        {
            InitializeComponent();
        }

        public void SetList(string[] types)
        {
            cbxProgramTypes.Items.Clear();
            cbxProgramTypes.Items.AddRange(types);
            cbxProgramTypes.SelectedIndex = 0;
        }
    }
}