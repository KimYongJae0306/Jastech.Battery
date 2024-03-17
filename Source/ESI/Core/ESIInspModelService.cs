using Jastech.Battery.Structure;
using Jastech.Battery.Structure.Data;
using Jastech.Battery.Structure.Parameters;
using Jastech.Battery.Winform.Settings;
using Jastech.Framework.Device.LightCtrls;
using Jastech.Framework.Structure;
using Jastech.Framework.Structure.Service;
using Jastech.Framework.Util.Helper;
using Jastech.Framework.Winform;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Core
{
    public class ESIInspModelService : InspModelService
    {
        #region 메서드
        public override InspModel New()
        {
            return new InspModel();
        }

        public override void AddModelData(InspModel inspModel)
        {
            AppsInspModel appInspModel = inspModel as AppsInspModel;

            foreach (UnitName unitName in Enum.GetValues(typeof(UnitName)))
            {
                Unit unit = new Unit();

                unit.Name = unitName.ToString();
                unit.CameraData = new LineCameraData();
                unit.CameraData.Name = unitName.ToString() + "Camera";

                unit.LightParam = CreateLightParameter();

                for (int laneIndex = 0; laneIndex < appInspModel.LaneCount; laneIndex++)
                {

                }
            }
        }

        public override InspModel Load(string filePath)
        {
            var model = new AppsInspModel();

            JsonConvertHelper.LoadToExistingTarget<AppsInspModel>(filePath, model);

            string rootDir = Path.GetDirectoryName(filePath);

            return model;
        }

        public override void Save(string filePath, InspModel model)
        {
            AppsInspModel attInspModel = model as AppsInspModel;

            JsonConvertHelper.Save(filePath, attInspModel);
        }

        public override void SaveExceptVpp(string filePath, InspModel model)
        {
            
        }

        private LightParameter CreateLightParameter()
        {
            LightParameter lightParameter = new LightParameter("Light");

            var lightCtrlHandler = DeviceManager.Instance().LightCtrlHandler;
            var backLightCtrl = lightCtrlHandler.Get("Back");
            var spotLightCtrl = lightCtrlHandler.Get("Spot");
            var ringLightCtrl = lightCtrlHandler.Get("Ring");

            lightParameter.Add(backLightCtrl, new LightValue(backLightCtrl.TotalChannelCount));
            lightParameter.Add(spotLightCtrl, new LightValue(spotLightCtrl.TotalChannelCount));
            lightParameter.Add(ringLightCtrl, new LightValue(ringLightCtrl.TotalChannelCount));

            return lightParameter;
        }
        #endregion
    }
}
