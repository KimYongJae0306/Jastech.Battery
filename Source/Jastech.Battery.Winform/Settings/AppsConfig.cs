using Jastech.Framework.Config;
using Jastech.Framework.Util.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Winform.Settings
{
    public class AppsConfig
    {
        #region 필드
        private static AppsConfig _instance = null;
        #endregion

        #region 속성
        [JsonProperty]
        public string MachineName { get; set; } = "ESI";
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
}
