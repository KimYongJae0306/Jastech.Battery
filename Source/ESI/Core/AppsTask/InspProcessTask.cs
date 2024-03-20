using Jastech.Battery.Structure;
using Jastech.Battery.Structure.Data;
using Jastech.Battery.Structure.VisionTool;
using Jastech.Battery.Winform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Jastech.Battery.Structure.AppsInspModel;

namespace ESI.Core.AppsTask
{
    public class InspProcessTask
    {
        #region 필드
        private AlgorithmTool _algorithmTool { get; set; } = new AlgorithmTool();
        #endregion

        #region 속성
        public LineCamera LineCamera { get; private set; }

        public InspDirection InspDirection { get; private set; }

        private Task InspTask { get; set; } = null;

        private CancellationTokenSource InspTaskCancellationTokenSource { get; set; }
        #endregion

        #region 이벤트
        public event SliceInspectDoneDelegate SliceInspectDoneDelegateEvent;
        #endregion

        #region 델리게이트
        public delegate void SliceInspectDoneDelegate(SliceInspResult sliceInspResult);
        #endregion

        #region 생성자
        public InspProcessTask(LineCamera lineCamera, InspDirection inspDirection)
        {
            LineCamera = lineCamera;
            InspDirection = inspDirection;
        }
        #endregion

        #region 메서드
        public void StartTask()
        {
            if (InspTask != null)
                return;

            InspTaskCancellationTokenSource = new CancellationTokenSource();
            InspTask = new Task(InspTaskAction, InspTaskCancellationTokenSource.Token);
            InspTask.Start();
        }

        private void InspTaskAction()
        {
            while (true)
            {
                // 작업 취소
                if (InspTaskCancellationTokenSource.IsCancellationRequested)
                    break;

                if (LineCamera != null)
                {
                    if (LineCamera.GetImageBuffer() is ImageBuffer imageBuffer)
                    {
                        var inspModel = ModelManager.Instance().CurrentModel as AppsInspModel;

                        SliceInspResult sliceInspResult = new SliceInspResult();
                        _algorithmTool.Inspect();

                        SliceInspectDoneDelegateEvent?.Invoke(sliceInspResult);
                    }
                }

                Thread.Sleep(1);
            }
        }

        public void StopTask()
        {
            if (InspTask != null)
            {
                InspTaskCancellationTokenSource.Cancel();
                InspTask.Wait();
                InspTask = null;
            }
        }

        public void Dispose()
        {
            StopTask();
        }
        #endregion
    }
}
