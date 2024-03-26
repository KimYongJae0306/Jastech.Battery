using Jastech.Battery.Structure.Data;
using Jastech.Battery.Winform;
using Jastech.Battery.Winform.Forms;
using Jastech.Battery.Winform.Settings;
using Jastech.Framework.Comm;
using Jastech.Framework.Config;
using Jastech.Framework.Device.Cameras;
using Jastech.Framework.Device.LightCtrls;
using Jastech.Framework.Device.LightCtrls.Darea;
using Jastech.Framework.Device.LightCtrls.Darea.Parser;
using Jastech.Framework.Imaging;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform.Forms;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ESI
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool isRunning = false;
            Mutex mutex = new Mutex(true, "ESI", out isRunning);
            isRunning = true;
            if (isRunning)
            {
                Application.ThreadException += Application_ThreadException;
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
                AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                Logger.Initialize(ConfigSet.Instance().Path.Log);

                //MilHelper.InitApplication();
                CameraMil.BufferPoolCount = 400;
                //SystemHelper.StartChecker(@"D:\ATT_Memory_Test.txt");
                //AppsConfig.Instance().UnitCount = 1;

                ConfigSet.Instance().PathConfigCreated += ConfigSet_PathConfigCreated;
                ConfigSet.Instance().OperationConfigCreated += ConfigSet_OperationConfigCreated;
                ConfigSet.Instance().MachineConfigCreated += ConfigSet_MachineConfigCreated;
                ConfigSet.Instance().Initialize();

                AppsConfig.Instance().Initialize();
                UserManager.Instance().Initialize();

                var mainForm = new MainForm();
                SystemManager.Instance().Initialize(mainForm);
                Application.Run(mainForm);
            }
            else
            {
                MessageBox.Show("The program already started.");
                Application.Exit();
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            string message = "Application_ThreadException " + e.Exception.Message;
            Logger.Error(ErrorType.Apps, message);
            System.Diagnostics.Trace.WriteLine(message);
            MessageBox.Show(message);
            Application.Exit(new System.ComponentModel.CancelEventArgs(false));
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = (Exception)e.ExceptionObject;
            string message = "CurrentDomain_UnhandledException " + exception.Message + " Source: " + exception.Source.ToString() + "StackTrack :" + exception.StackTrace.ToString();
            Logger.Error(ErrorType.Apps, message);

            System.Diagnostics.Trace.WriteLine(message);
            MessageBox.Show(message);
        }

        private static void ConfigSet_PathConfigCreated(PathConfig config)
        {
            config.CreateDirectory();
        }

        private static void ConfigSet_OperationConfigCreated(OperationConfig config)
        {
            if (MessageBox.Show("Do you want to Virtual Mode?", "Setup", MessageBoxButtons.YesNo) == DialogResult.Yes)
                config.VirtualMode = true;
            else
                config.VirtualMode = false;
        }

        private static void ConfigSet_MachineConfigCreated(MachineConfig config)
        {
            if (ConfigSet.Instance().Operation.VirtualMode)
            {
                AppsConfig.Instance().MachineName = "ESI (Virtual)";

                // Initialize Config by Program Types
                string[] typeList = Enum.GetNames(typeof(ProcessType));
                ProgramSelectForm form = new ProgramSelectForm();
                form.SetList(typeList);
                form.ShowDialog();
                AppsConfig.Instance().ProgramType = form.SelectedProgramType;

                // Upper Linescanner
                var upperCamera = new CameraVirtual("UpperCamera", 16384, 1024, ColorFormat.Gray, SensorType.Line);
                upperCamera.OffsetX = 0;
                upperCamera.PixelResolution_um = 3.52F;
                upperCamera.LensScale = 0.2F;
                config.Add(upperCamera);

                // Lower Linescanner
                var lowerCamera = new CameraVirtual("LowerCamera", 16384, 1024, ColorFormat.Gray, SensorType.Line);
                lowerCamera.OffsetX = 0;
                lowerCamera.PixelResolution_um = 3.52F;
                lowerCamera.LensScale = 0.2F;
                config.Add(lowerCamera);

                var light = new VirtualLightCtrl("Light", 6);
                light.ChannelNameMap["Ch.White"] = 1; // channel 지정
                config.Add(light);
            }
            else
            {
                // Initialize Config by Program Types
                string[] typeList = Enum.GetNames(typeof(ProcessType));
                ProgramSelectForm form = new ProgramSelectForm();
                form.SetList(typeList);
                form.ShowDialog();
                AppsConfig.Instance().ProgramType = form.SelectedProgramType;

                var programType = StringHelper.StringToEnum<ProcessType>(AppsConfig.Instance().ProgramType);
                switch (programType)
                {
                    case ProcessType.Coating:
                        AppsConfig.Instance().MachineName = "ESI (Coater)";
                        CreateCoaterDeviceConfig(config);
                        break;

                    case ProcessType.Press:
                        AppsConfig.Instance().MachineName = "ESI (Press)";
                        CreatePressDeviceConfig(config);
                        break;

                    case ProcessType.Slitting:
                        AppsConfig.Instance().MachineName = "ESI (Slitter)";
                        CreateSlitterDeviceConfig(config);
                        break;
                }
            }
        }

        private static void CreateCoaterDeviceConfig(MachineConfig config)
        {
            // Linescanner
            int upperCameraMaxWidth = 1024 * 16;
            int upperCameraWidth = 1024 * 16;
            int upperCameraOffsetX = 0;
            int upperCameraHeight = 1024;

            if (CheckCameraProperty(ref upperCameraWidth, ref upperCameraOffsetX, upperCameraMaxWidth) == true)
            {
                var upperCamera = new CameraDalsa("UpperCamera", upperCameraWidth, upperCameraHeight, ColorFormat.Gray, SensorType.Line);
                config.Add(upperCamera);
            }

            int lowerCameraMaxWidth = 1024 * 16;
            int lowerCameraWidth = 1024 * 16;
            int lowerCameraOffsetX = 0;
            int lowerCameraHeight = 1024;

            if (CheckCameraProperty(ref lowerCameraWidth, ref lowerCameraOffsetX, lowerCameraMaxWidth) == true)
            {
                var upperCamera = new CameraDalsa("UpperCamera", lowerCameraWidth, lowerCameraHeight, ColorFormat.Gray, SensorType.Line);
                config.Add(upperCamera);
            }

            // Light
            var backLight = new DareaLightCtrl("Back", 8, new SerialPortComm("COM1", 9600), new DareaSerialParser());
            backLight.ChannelNameMap["Ch.UV"] = 1; // channel 지정
            config.Add(backLight);
        }

        private static void CreatePressDeviceConfig(MachineConfig config)
        {
            // Linescanner
            int upperCameraMaxWidth = 1024 * 16;
            int upperCameraWidth = 1024 * 16;
            int upperCameraOffsetX = 0;
            int upperCameraHeight = 1024;

            if (CheckCameraProperty(ref upperCameraWidth, ref upperCameraOffsetX, upperCameraMaxWidth) == true)
            {
                var upperCamera = new CameraDalsa("UpperCamera", upperCameraWidth, upperCameraHeight, ColorFormat.Gray, SensorType.Line);
                config.Add(upperCamera);
            }

            int lowerCameraMaxWidth = 1024 * 16;
            int lowerCameraWidth = 1024 * 16;
            int lowerCameraOffsetX = 0;
            int lowerCameraHeight = 1024;

            if (CheckCameraProperty(ref lowerCameraWidth, ref lowerCameraOffsetX, lowerCameraMaxWidth) == true)
            {
                var upperCamera = new CameraDalsa("UpperCamera", lowerCameraWidth, lowerCameraHeight, ColorFormat.Gray, SensorType.Line);
                config.Add(upperCamera);
            }

            // Light
            var backLight = new DareaLightCtrl("Back", 8, new SerialPortComm("COM1", 9600), new DareaSerialParser());
            backLight.ChannelNameMap["Ch.UV"] = 1; // channel 지정
            config.Add(backLight);
        }

        private static void CreateSlitterDeviceConfig(MachineConfig config)
        {
            // Linescanner
            int upperCameraMaxWidth = 1024 * 16;
            int upperCameraWidth = 1024 * 16;
            int upperCameraOffsetX = 0;
            int upperCameraHeight = 1024;

            if (CheckCameraProperty(ref upperCameraWidth, ref upperCameraOffsetX, upperCameraMaxWidth) == true)
            {
                var upperCamera = new CameraDalsa("UpperCamera", upperCameraWidth, upperCameraHeight, ColorFormat.Gray, SensorType.Line);
                config.Add(upperCamera);
            }

            int lowerCameraMaxWidth = 1024 * 16;
            int lowerCameraWidth = 1024 * 16;
            int lowerCameraOffsetX = 0;
            int lowerCameraHeight = 1024;
             
            if (CheckCameraProperty(ref lowerCameraWidth, ref lowerCameraOffsetX, lowerCameraMaxWidth) == true)
            {
                var upperCamera = new CameraDalsa("UpperCamera", lowerCameraWidth, lowerCameraHeight, ColorFormat.Gray, SensorType.Line);
                config.Add(upperCamera);
            }

            // Light
            var backLight = new DareaLightCtrl("Back", 8, new SerialPortComm("COM1", 9600), new DareaSerialParser());
            backLight.ChannelNameMap["Ch.UV"] = 1; // channel 지정
            config.Add(backLight);
        }

        private static bool CheckCameraProperty(ref int width, ref int offsetX, int fullPixelSize)
        {
            if (width % 16 != 0 || offsetX % 16 != 0)
            {
                string errorMessage = string.Format("Set parameter to a multiple of 16\r\n Width : {0}, Offset : {1}", width, offsetX);
                Logger.Debug(LogType.Device, errorMessage);

                MessageConfirmForm form = new MessageConfirmForm();
                form.Message = errorMessage;

                return false;
            }

            if (width > fullPixelSize)
                width = fullPixelSize;

            if (width + offsetX > fullPixelSize)
            {
                string errorMessage = "Width + Offset <= " + fullPixelSize.ToString();
                Logger.Debug(LogType.Device, errorMessage);

                int newOffsetX = fullPixelSize - width;
                errorMessage = string.Format("{0}\r\n\r\nInput Width : {1},Offset : {2}\r\n\r\nDo you want to Change Parameter?\r\n\r\nSet Width : {3},Offset : {4}",
                                            errorMessage, width, offsetX, width, newOffsetX);

                MessageYesNoForm form = new MessageYesNoForm();
                form.Message = errorMessage;
                if (form.ShowDialog() == DialogResult.Yes)
                {
                    offsetX = newOffsetX;
                    return true;
                }
                else
                    return false;
            }
            else
                return true;
        }
    }
}
