using ESI.Core.AppsTask;
using Jastech.Battery.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESI.Core
{
    public class ESIInspRunner
    {
        private InspProcessTaskHandler InspProcessTaskHandler { get; set; } = new InspProcessTaskHandler();

        public void Initialize()
        {
            var inspModel = ModelManager.Instance().CurrentModel as AppsInspModel;

            if (inspModel == null)
                return;

            InspProcessTaskHandler.Initalize();
        }

        //private void StopInspTask()
        //{
        //    foreach (var inspTask in InspTaskList)
        //        inspTask.Dispose();
        //}
    }
}
