using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Entidades
{
    public class Variable: VariableBase
    {
        public Variable(string name, string descripcion, List<String> varInternas, List<VariableBase> listaGlobalVars, string value) : base(name, descripcion, varInternas, listaGlobalVars)
        {
            Value = value;
        }
        public string Value { get; }
        public List<VariableBase> vars = new List<VariableBase>();

    }
}
