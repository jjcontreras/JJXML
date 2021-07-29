using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Entidades
{
    public class VariableInterna
    {
        public String Name { get; }
        public VariableBase referencia;
        private readonly List<VariableBase> listaGlobalVars;
        bool errorState = false;

        public VariableInterna(String name, List<VariableBase> listaGlobalVars)
        {
            Name = name;
            this.listaGlobalVars = listaGlobalVars;
        }
        public bool ErrorState()
        {
            referencia = listaGlobalVars.Where(x => x.Name == Name).FirstOrDefault();
            if (referencia == null)
            {
                errorState = true;                
            }
            else
            {
                errorState = referencia.ErrorState();
            }            
            return errorState;
        }
    }
}
