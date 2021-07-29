using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Entidades
{
    public class Sensor: VariableBase
    {
        public Sensor(string name, string descripcion, List<VariableBase> listaGlobalVars) : base(name, descripcion, listaGlobalVars)
        {

        }

    }
}
