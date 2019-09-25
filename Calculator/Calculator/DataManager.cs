using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class DataManager
    {
        public IData Data { get; set; }
        public DataManager(IData data)
        {
            Data = data;
        }

        public IEnumerable<Auto> GetAllAutosDieEineWallboxBrauchen()
        {
            return Data.GetAutos().Where(x => x.BrauchtWallBox).OrderBy(x => x.Farbe);
        }

    }

    public interface IData
    {
        IEnumerable<Auto> GetAutos();
    }
}
