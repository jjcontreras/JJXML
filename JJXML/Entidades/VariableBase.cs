using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Entidades
{
    public class VariableBase
    {
        public String Name { get;}
        String Id { get; set; }
        public String Description { get; }
        List<VariableBase> ListaGlobalVars;
        public List<VariableInterna> VariablesPropias = new List<VariableInterna>();
        bool VariableEvaluada = true;
        bool EstadoDeError = false;
        int NumeroDeReferencias = 0;

        public VariableBase(string name, string descripcion, List<String> varInternas, List<VariableBase> listaGlobalVars)
        {
            Name = name;
            Description = descripcion;
            ListaGlobalVars = listaGlobalVars;
            foreach (var str in varInternas)
            {
                VariablesPropias.Add(new VariableInterna(str,listaGlobalVars));
                VariableEvaluada = false;
            }
        }
        public VariableBase(string name, string descripcion, List<VariableBase> listaGlobalVars)
        {
            Name = name;
            Description = descripcion;
            ListaGlobalVars = listaGlobalVars;
        }

        public bool ErrorState()
        {
            NumeroDeReferencias++;
            if (VariableEvaluada) return EstadoDeError;
            VariableEvaluada = true;
            foreach (var v in VariablesPropias)
            {
                EstadoDeError |= v.ErrorState();
            }
            return EstadoDeError;           
        }
    }
}
