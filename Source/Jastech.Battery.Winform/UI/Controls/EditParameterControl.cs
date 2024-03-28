using Jastech.Framework.Winform.Helper;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Jastech.Battery.Winform.UI.Controls
{
    public partial class EditParameterControl : UserControl
    {
        #region 필드
        private int _controlHeight;
        #endregion

        #region 속성
        public Color CheckBoxBackColor { get; set; } = Color.FromArgb(26,26,26);

        public Color ParameterNameBackColor { get; set; } = Color.FromArgb(104, 104, 104);

        public Color ParameterValueBackColor { get; set; } = Color.FromArgb(52,52,52);
        #endregion

        #region 생성자
        public EditParameterControl()
        {
            InitializeComponent();
        }
        #endregion

        #region 메서드
        public void SetData<T>(T parameterObject, int controlHeight) where T : class
        {
            _controlHeight = controlHeight;

            FieldInfo[] subParameters = parameterObject.GetType().GetFields();
            foreach(FieldInfo subParameter in subParameters)
            {
                var subParameterObject = subParameter.GetValue(parameterObject);
                PropertyInfo[] properties = subParameterObject.GetType().GetProperties();

                string checkBoxTitle = string.Join(" ", Regex.Split(subParameter.Name.Replace("Param", ""), @"(?<!^)(?=[A-Z](?![A-Z]|$))"));
                CheckBox checkBox = CreateNewCheckBox(checkBoxTitle);
                var enableParameter = properties.Single(info => info.PropertyType == typeof(bool));
                var enableBinding = new Binding("Checked", subParameterObject, enableParameter.Name, false, DataSourceUpdateMode.OnPropertyChanged);
                checkBox.DataBindings.Add(enableBinding);

                int objectStartIndex = 0;
                foreach (PropertyInfo property in properties)
                {
                    int insertIndex = tlpDataLayout.RowCount - 1;

                    if (property.PropertyType == typeof(bool))
                    {
                        objectStartIndex = insertIndex;
                        continue;
                    }

                    tlpDataLayout.RowStyles.Insert(insertIndex, new RowStyle(SizeType.Absolute, _controlHeight));

                    Label parameterName = CreateNewLabel(property.Name);
                    parameterName.BackColor = Color.FromArgb(104, 104, 104);
                    tlpDataLayout.Controls.Add(parameterName, 1, insertIndex);

                    Label parameterValue = CreateNewLabel("0,0");
                    var valueBinding = new Binding("Text", subParameterObject, property.Name, false, DataSourceUpdateMode.OnPropertyChanged);
                    parameterValue.BackColor = Color.FromArgb(52, 52, 52);
                    parameterValue.Click += ParameterValue_Click;
                    parameterValue.DataBindings.Add(valueBinding);

                    tlpDataLayout.Controls.Add(parameterValue, 2, insertIndex);
                    tlpDataLayout.RowCount++;
                }
                tlpDataLayout.Controls.Add(checkBox, 0, objectStartIndex);
                tlpDataLayout.SetRowSpan(checkBox, Math.Max(1, properties.Length - 1));
            }
            tlpDataLayout.AutoScrollPosition = tlpDataLayout.Location;
        }

        private Label CreateNewLabel(string text)
        {
            Label label = new Label
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = ParameterValueBackColor,
                Margin = new Padding(0, 2, 0, 0),
            };

            return label;
        }

        private CheckBox CreateNewCheckBox(string text)
        {
            CheckBox checkBox = new CheckBox
            {
                Text = text,
                TextAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Appearance = Appearance.Button,
                Dock = DockStyle.Fill,
                ImageList = StateImageList,
                BackColor = CheckBoxBackColor,
                Margin = new Padding(0, 2, 2, 0),
                FlatStyle = FlatStyle.Flat,
            };
            checkBox.FlatAppearance.BorderColor = Color.FromArgb(104, 104, 104);
            checkBox.FlatAppearance.BorderSize = 1;
            checkBox.FlatAppearance.CheckedBackColor = checkBox.BackColor;
            checkBox.CheckedChanged += CheckBox_CheckedChanged;
            CheckBox_CheckedChanged(checkBox, null);

            return checkBox;
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            checkBox.ImageIndex = checkBox.Checked ? 1 : 0;
        }

        private void ParameterValue_Click(object sender, EventArgs e)
        {
            var label = sender as Label;
            KeyPadHelper.SetLabelDoubleData(label);
        }
        #endregion
    }
}
