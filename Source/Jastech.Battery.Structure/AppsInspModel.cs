using Jastech.Battery.Structure.Data;
using Jastech.Battery.Structure.Parameters;
using Jastech.Framework.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jastech.Battery.Structure
{
    public class AppsInspModel : InspModel
    {
        #region 속성
        public int LaneCount { get; set; } = 1;

        public MaterialInfo MaterialInfo { get; set; } = new MaterialInfo();

        public int InspThreadCount { get; set; } = 10;

        public ProcessType ProcessType { get; set; } = ProcessType.None;

        public List<Unit> UnitList { get; set; } = new List<Unit>();
        #endregion

        #region 메소드
        public Unit GetUnit(string name)
        {
            Unit unit = null;
            lock (UnitList)
                unit = UnitList.FirstOrDefault(x => x.Name == name);

            return unit;
        }

        public Unit GetUnit(UnitName name)
        {
            Unit unit = null;
            lock (UnitList)
                unit = UnitList.FirstOrDefault(x => x.Name == name.ToString());

            return unit;
        }

        public void AddUnit(Unit unit)
        {
            lock (UnitList)
                UnitList.Add(unit);
        }

        public List<Unit> GetUnitList()
        {
            lock (UnitList)
                return UnitList;
        }

        public void SetUnitList(List<Unit> newUnitList)
        {
            lock (UnitList)
            {
                foreach (var unit in UnitList)
                    unit.Dispose();

                UnitList.Clear();

                UnitList.AddRange(newUnitList.Select(x => x.DeepCopy()).ToList());
            }
        }
        #endregion
    }
}
