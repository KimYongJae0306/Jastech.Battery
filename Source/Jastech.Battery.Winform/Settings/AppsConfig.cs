using Jastech.Framework.Config;
using Jastech.Framework.Util.Helper;
using System.IO;

namespace Jastech.Battery.Winform.Settings
{
    public class AppsConfig
    {
        #region 필드
        private static AppsConfig _instance = null;
        #endregion

        #region 속성
        public string MachineName { get; set; } = "ESI";

		public string ProgramType { get; set; } = string.Empty;

        public bool EnablePLCTime { get; set; } = false;

        public bool UseTeachingArea { get; set; } = false;

        public const int VERTICAL_COATING_MAX_COUNT = 5;

        public double Zoom { get; set; } = 0.08825;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        public static AppsConfig Instance()
        {
            if (_instance == null)
            {
                _instance = new AppsConfig();
            }

            return _instance;
        }

        public void Initialize()
        {
            string dirPath = ConfigSet.Instance().Path.Config;
            string fullPath = Path.Combine(ConfigSet.Instance().Path.Config, "AppsConfig.cfg");

            if (!File.Exists(fullPath))
            {
                Save();
                return;
            }
            Load();
        }

        public void Save()
        {
            string dirPath = ConfigSet.Instance().Path.Config;
            string fullPath = Path.Combine(ConfigSet.Instance().Path.Config, "AppsConfig.cfg");

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            JsonConvertHelper.Save(fullPath, this);
        }

        public void Load()
        {
            string dirPath = ConfigSet.Instance().Path.Config;
            string fullPath = Path.Combine(ConfigSet.Instance().Path.Config, "AppsConfig.cfg");

            if (!File.Exists(fullPath))
            {
                Save();
                return;
            }

            JsonConvertHelper.LoadToExistingTarget<AppsConfig>(fullPath, this);
        }
        #endregion
    }

    public enum ProcessType
    {
        Coater,
        Press,
        Slitter,
    }
}
