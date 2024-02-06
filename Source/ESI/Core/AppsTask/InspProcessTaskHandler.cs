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
        private List<InspProcessTask> TopInspTaskList { get; set; } = new List<InspProcessTask>();

        private List<InspProcessTask> BottomInspTaskList { get; set; } = new List<InspProcessTask>();
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

            int inspThreadCount = inspModel.InspThreadCount;

            var topLineCamera =LineCameraManager.Instance().GetLineCamera("Top");
            InitalizeInspTop(topLineCamera, inspThreadCount);

            var bottomLineCamera = LineCameraManager.Instance().GetLineCamera("Bottom");
            InitalizeInspBottom(bottomLineCamera, inspThreadCount);

            return true;
        }

        public void Dispose()
        {
            DisposeInspTopTask();
            DisposeInspBottomTask();
        }

        private void InitalizeInspTop(LineCamera lineCamera, int threadCount)
        {
            DisposeInspTopTask();

            for (int i = 0; i < threadCount; i++)
            {
                InspProcessTask task = new InspProcessTask(lineCamera, InspDirection.Upper);
                task.SliceInspectDoneDelegateEvent += SliceInspectDone;
                task.StartTask();

                TopInspTaskList.Add(task);
            }
        }

        private void InitalizeInspBottom(LineCamera lineCamera, int threadCount)
        {
            DisposeInspBottomTask();

            for (int i = 0; i < threadCount; i++)
            {
                InspProcessTask task = new InspProcessTask(lineCamera, InspDirection.Lower);
                task.SliceInspectDoneDelegateEvent += SliceInspectDone;
                task.StartTask();

                BottomInspTaskList.Add(task);
            }
        }

        private void DisposeInspTopTask()
        {
            foreach (var inspTask in TopInspTaskList)
            {
                inspTask.SliceInspectDoneDelegateEvent -= SliceInspectDone;
                inspTask.Dispose();
            }
            TopInspTaskList.Clear();
        }

        private void DisposeInspBottomTask()
        {
            foreach (var inspTask in BottomInspTaskList)
            {
                inspTask.SliceInspectDoneDelegateEvent -= SliceInspectDone;
                inspTask.Dispose();
            }
            BottomInspTaskList.Clear();
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
        #endregion
    }
}
