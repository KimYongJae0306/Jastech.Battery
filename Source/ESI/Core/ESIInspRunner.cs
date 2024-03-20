using ESI.Core.AppsTask;
using Jastech.Battery.Structure;
using Jastech.Framework.Device.LightCtrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Core
{
    public class ESIInspRunner
    {
        #region 필드
        #endregion

        #region 속성
        private LightCtrlHandler LightCtrlHandler { get; set; } = null;
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        #endregion

        private InspProcessTaskHandler InspProcessTaskHandler { get; set; } = new InspProcessTaskHandler();

        public void Initialize()
        {
            var inspModel = ModelManager.Instance().CurrentModel as AppsInspModel;

            if (inspModel == null)
                return;

            InspProcessTaskHandler.Initalize();
        }

        public void Release()
        {
            StopDevice();
            //InspProcessTask.StopTask();
            InspProcessTaskHandler.StopTask();
            StopSeqTask();
        }

        public void StopDevice()
        {
            LightCtrlHandler?.TurnOff();
        }

        public void StopSeqTask()
        {

        }
        //private void StopInspTask()
        //{
        //    foreach (var inspTask in InspTaskList)
        //        inspTask.Dispose();
        //}
    }
}
