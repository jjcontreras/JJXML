using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Entidades
{
    public class Evento : VariableBase
    {
        public Evento(string name, string descripcion, List<String> varInternas, List<VariableBase> listaGlobalVars, string condition) : base(name, descripcion, varInternas, listaGlobalVars)
        {
            Condition = condition;
        }

        public string Condition { get; }
       
    }
}
