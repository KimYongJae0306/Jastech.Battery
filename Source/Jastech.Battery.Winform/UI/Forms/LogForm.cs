using Jastech.Battery.Winform.UI.Controls;
using Jastech.Framework.Winform.Helper;
using Jastech.Framework.Winform.Controls;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Jastech.Battery.Winform.Forms
{
    public partial class LogForm : Form
    {
        #region 필드
        private Color _selectedColor;

        private Color _nonSelectedColor;

        private string _logPath { get; set; } = string.Empty;

        private string _resultPath { get; set; } = string.Empty;

        private PageType _selectedPageType { get; set; } = PageType.Log;

        private string _selectedPagePath { get; set; } = string.Empty;

        private StyledCalender cdrMonthCalendar { get; set; } = null;
        #endregion

        #region 속성
        private LogControl LogControl { get; set; } = null;

        private DrawBoxControl InspDisplayControl { get; set; } = null;

        public DateTime DateTime { get; set; } = DateTime.Now;
        #endregion

        #region 생성자
        public LogForm()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        private void LogForm_Load(object sender, EventArgs e)
        {
            AddControls();
            InitializeUI();
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            InspDisplayControl.DisposeImage();
            InspDisplayControl.Dispose();
            ControlHelper.DisposeChildControls(InspDisplayControl);
            ControlHelper.DisposeChildControls(LogControl);
        }

        private void AddControls()
        {
            cdrMonthCalendar = new StyledCalender
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(26, 26, 26),
                Font = new Font("맑은 고딕", 12.75F, FontStyle.Bold, GraphicsUnit.Point, 129),
                Margin = new Padding(0),
                MaxSelectionCount = 28,
                TitleBackColor = Color.DimGray,
                TitleForeColor = Color.White,
                TrailingForeColor = Color.Silver,
            };
            LogControl = new LogControl { Dock = DockStyle.Fill };
            InspDisplayControl = new DrawBoxControl { Dock = DockStyle.Top, Height = tvwLogPath.Height + cdrMonthCalendar.Height - pnlLogType.Height };
            cdrMonthCalendar.DateChanged += new DateRangeEventHandler(cdrMonthCalendar_DateChanged);

            tlpBasicFunction.Controls.Add(cdrMonthCalendar, 0, 0);
            tlpBasicFunction.SetColumnSpan(cdrMonthCalendar, 2);
        }

        private void InitializeUI()
        {
            _selectedColor = Color.FromArgb(104, 104, 104);
            _nonSelectedColor = Color.FromArgb(52, 52, 52);

            SetPageType(PageType.Log);
            cdrMonthCalendar.SelectionRange = new SelectionRange { Start = DateTime.Now.AddDays((cdrMonthCalendar.MaxSelectionCount - 1)*-1), End = DateTime.Now.AddDays(1) };
        }

        private void SetPageType(PageType pageType)
        {
            _selectedPageType = pageType;

            ClearSelectedLabel();
            pnlContents.Controls.Clear();

            switch (pageType)
            {
                case PageType.Log:
                    _selectedPagePath = _logPath;
                    btnSelectionLog.BackColor = _selectedColor;

                    pnlContents.Controls.Add(LogControl);
                    break;

                case PageType.Image:
                    _selectedPagePath = _resultPath;
                    btnSelectionImage.BackColor = _selectedColor;

                    pnlContents.Controls.Add(InspDisplayControl);
                    break;

                default:
                    break;
            }

            SetDateChange();
        }

        private void ClearSelectedLabel()
        {
            foreach (Control control in pnlLogType.Controls)
            {
                if (control is Button)
                    control.BackColor = _nonSelectedColor;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSelectionLog_Click(object sender, EventArgs e)
        {
            SetPageType(PageType.Log);
        }

        private void btnSelectionImage_Click(object sender, EventArgs e)
        {
            SetPageType(PageType.Image);
        }

        public void SetLogViewPath(string logPath, string resultPath, string modelName)
        {
            _logPath = logPath;
            _resultPath = Path.Combine(resultPath, modelName);
        }

        private void cdrMonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            SetDateChange();
        }

        private void SetDateChange()
        {
            if (_selectedPagePath == string.Empty)
                return;

            tvwLogPath.Nodes.Clear();

            for (DateTime dateTime = cdrMonthCalendar.SelectionStart; dateTime <= cdrMonthCalendar.SelectionEnd; dateTime = dateTime.AddDays(1))
            {
                string date = dateTime.ToString("yyyyMMdd");
                string rootPath = _selectedPagePath;

                DirectoryInfo rootDirectoryInfo = new DirectoryInfo(rootPath);
                TreeNode rootNode;
                if (tvwLogPath.Nodes.ContainsKey(rootDirectoryInfo.Name) == false)
                {
                    rootNode = new TreeNode { Name = rootDirectoryInfo.Name, Text = rootDirectoryInfo.Name };
                    tvwLogPath.Nodes.Add(rootNode);
                }
                else
                    rootNode = tvwLogPath.Nodes[rootDirectoryInfo.Name];

                string subRootPath = Path.Combine(_selectedPagePath, date);
                DirectoryInfo subDirectoryInfo = new DirectoryInfo($@"{subRootPath}");
                if (Directory.Exists(subDirectoryInfo.FullName))
                    rootNode.Nodes.Add(RecursiveDirectory(subDirectoryInfo));
            }
        }

        private TreeNode RecursiveDirectory(DirectoryInfo directoryInfo)
        {
            TreeNode newNode = new TreeNode { Name = directoryInfo.Name, Text = directoryInfo.Name };
            try
            {
                foreach (FileInfo file in directoryInfo.GetFiles())
                {
                    if (file.Name.ToLower().Contains("summary"))
                        continue;
                    if (_selectedPageType == PageType.Image && (file.Name.ToLower().Contains(".txt") || file.Name.ToLower().Contains(".csv")))
                        continue;

                    newNode.Nodes.Add(new TreeNode(file.Name));
                }

                // PageType이 Image인 경우에만 Recursive로 순회하여 경로 취득
                if (_selectedPageType == PageType.Image)
                {
                    foreach (DirectoryInfo subDirectory in directoryInfo.GetDirectories())
                        newNode.Nodes.Add(RecursiveDirectory(subDirectory));
                }

                return newNode;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        private TreeNode GetFirstNode(TreeNode root)
        {
            if (root.Parent == null)
                return root;
            else
                return GetFirstNode(root.Parent);
            //if (root.Parent != null)
            //    GetFirstNode(root.Parent);

            //return root;
        }

        private void tvwLogPath_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (tvwLogPath.SelectedNode == null)
                    return;

                var firstNodeName = @"\" + GetFirstNode(tvwLogPath.SelectedNode).Text;

                var firsntNodePath = _selectedPagePath.Replace(firstNodeName, "");
                string fullPath = Path.Combine(firsntNodePath, tvwLogPath.SelectedNode.FullPath);

                string extension = Path.GetExtension(fullPath);
                if (extension == string.Empty)
                    return;

                DisplaySelectedNode(extension, fullPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Cursor = Cursors.Default;
            }
        }

        private void DisplaySelectedNode(string extension, string fullPath)
        {
            Cursor = Cursors.WaitCursor;
            switch (extension.ToLower())
            {
                case ".log":
                case ".txt":
                    DisplayTextFile(fullPath);
                    break;

                case ".bmp":
                case ".jpg":
                case ".jpeg":
                case ".png":
                    DisplayImageFile(fullPath);
                    break;


                case ".csv":
                    DisplayCSVFile(fullPath);
                    break;

                default:
                    break;
            }
            Cursor = Cursors.Default;
        }

        private void DisplayTextFile(string fullPath)
        {
            LogControl.DisplayOnLogFile(fullPath);
        }

        private void DisplayImageFile(string fullPath)
        {
            try
            {
                InspDisplayControl.DisposeImage();

                var image = new Bitmap(fullPath);
                InspDisplayControl.SetImage(image);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void DisplayCSVFile(string fullPath)
        {
            switch (_selectedPageType)
            {
                default:
                    break;
            }
        }
        #endregion
    }

    public enum PageType
    {
        Log,
        Image,
        Mismatch
    }
}
