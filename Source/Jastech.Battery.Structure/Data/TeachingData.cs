using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure.Data
{
    public class TeachingData
    {
        #region 필드
        private static TeachingData _instance = null;
        #endregion

        #region 속성
        public List<Unit> UnitList { get; set; } = new List<Unit>();
        #endregion

        #region 이벤트
        #endregion

        #region 델리게이트
        #endregion

        #region 생성자
        #endregion

        #region 메서드
        public static TeachingData Instance()
        {
            if (_instance == null)
                _instance = new TeachingData();

            return _instance;
        }

        public void UpdateTeachingData()
        {
            var inspModel = ModelManager.Instance().CurrentModel as AppsInspModel;
            if (inspModel != null)
            {
                Dispose();
                Initialize(inspModel);
            }
        }

        public void Initialize(AppsInspModel inspModel)
        {
            Dispose();
            lock (UnitList)
            {
                foreach (var unit in inspModel.GetUnitList())
                {
                    UnitList.Add(unit.DeepCopy());
                }
            }
        }

        public void Dispose()
        {
            lock (UnitList)
            {
                foreach (var unit in UnitList)
                    unit.Dispose();

                UnitList.Clear();

            }
        }

        public Unit GetUnit(string name)
        {
            Unit unit = null;
            lock (UnitList)
                unit = UnitList.FirstOrDefault(x => x.Name == name);

            return unit;
        }
        #endregion
    }
}
