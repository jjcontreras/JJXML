using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Entidades
{
    public class VariableDeCuenta
    {
        public string Name;
        public bool VariableExistente;
        public int Cuenta;
        public VariableDeCuenta(string name, bool variableExistente=false)
        {
            Name = name;
            VariableExistente = variableExistente;
            Cuenta = 1;
        }
    }
}
