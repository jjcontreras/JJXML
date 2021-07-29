using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Entidades
{
    public class VarPantalla
    {
        public String Name { get; }
        public String EtiquetaOrigen { get; }
        public VariableBase referencia;
        private bool errorState;

        public int NumReferencias { get; set; } = 0 ;
        private readonly List<VariableBase> listaGlobalVars;        

        public VarPantalla(String name, String etiquetaOrigen, List<VariableBase> listaGlobalVars)
        {
            Name = name;
            EtiquetaOrigen = etiquetaOrigen;
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
