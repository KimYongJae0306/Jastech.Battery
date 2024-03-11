using Jastech.Battery.Structure;
using Jastech.Battery.Structure.Data;
using Jastech.Battery.Winform;
using Jastech.Framework.Winform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Core.AppsTask
{
    public class InspProcessTaskHandler
    {
        #region 필드
        #endregion

        #region 속성
        private List<InspProcessTask> UpperInspTaskList { get; set; } = new List<InspProcessTask>();

        private List<InspProcessTask> LowerInspTaskList { get; set; } = new List<InspProcessTask>();
        #endregion

        #region 이벤트

        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        public bool Initalize()
        {
            var inspModel = ModelManager.Instance().CurrentModel as AppsInspModel;

            if (inspModel == null)
                return false;

            int inspThreadCount = 1;// inspModel.InspThreadCount;

            var upperLineCamera = LineCameraManager.Instance().GetLineCamera("Upper");
            InitalizeInspUpper(upperLineCamera, inspThreadCount);

            var lowerLineCamera = LineCameraManager.Instance().GetLineCamera("Lower");
            InitalizeInspLower(lowerLineCamera, inspThreadCount);

            return true;
        }

        public void Dispose()
        {
            DisposeInspTopTask();
            DisposeInspBottomTask();
        }

        private void InitalizeInspUpper(LineCamera lineCamera, int threadCount)
        {
            DisposeInspTopTask();

            for (int i = 0; i < threadCount; i++)
            {
                InspProcessTask task = new InspProcessTask(lineCamera, InspDirection.Upper);
                task.SliceInspectDoneDelegateEvent += SliceInspectDone;
                task.StartTask();

                UpperInspTaskList.Add(task);
            }
        }

        private void InitalizeInspLower(LineCamera lineCamera, int threadCount)
        {
            DisposeInspBottomTask();

            for (int i = 0; i < threadCount; i++)
            {
                InspProcessTask task = new InspProcessTask(lineCamera, InspDirection.Lower);
                task.SliceInspectDoneDelegateEvent += SliceInspectDone;
                task.StartTask();

                LowerInspTaskList.Add(task);
            }
        }

        private void DisposeInspTopTask()
        {
            foreach (var inspTask in UpperInspTaskList)
            {
                inspTask.SliceInspectDoneDelegateEvent -= SliceInspectDone;
                inspTask.Dispose();
            }
            UpperInspTaskList.Clear();
        }

        private void DisposeInspBottomTask()
        {
            foreach (var inspTask in LowerInspTaskList)
            {
                inspTask.SliceInspectDoneDelegateEvent -= SliceInspectDone;
                inspTask.Dispose();
            }
            LowerInspTaskList.Clear();
        }

        private void SliceInspectDone(SliceInspResult sliceInspResult)
        {
            if(sliceInspResult.InspDirection == InspDirection.Upper)
            {

            }
            else
            {

            }
        }

        public void StopTask()
        {

        }
        #endregion
    }
}
