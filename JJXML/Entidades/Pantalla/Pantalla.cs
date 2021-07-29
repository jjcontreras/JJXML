using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Entidades
{
    public class Pantalla
    {
        private readonly List<VariableBase> listaGlobalVars;
        public List<VarPantalla> VariablesPropias = new List<VarPantalla>();

        public String Name { get; }
        public String Description { get; }
        public int NumeroDeReferencias { get; private set; }
        public bool PantallaEvaluada { get; private set; }
        public bool EstadoDeError { get; private set; }

        public Pantalla(string name, string descripcion, List<VariableBase> listaGlobalVars)
        {
            Name = name;
            this.listaGlobalVars = listaGlobalVars;
            Description = descripcion;            
        }

        void Add(String name, String etiqueta)
        {
            var v = VariablesPropias.Where(x => x.Name == name).FirstOrDefault();
            if (v == null)
            {
                VariablesPropias.Add(new VarPantalla(name, etiqueta, listaGlobalVars));
            }
            else
            {
                v.NumReferencias++;
            }
        }

        public void AddVar(String v,String etiqueta)
        {
            Add(v, etiqueta);
        }

        public void AddVar(List<String> lv, String etiqueta)
        {
            foreach(var v in lv)
            {
                Add(v, etiqueta);
            }
        }

        public bool ErrorState()
        {
            NumeroDeReferencias++;
            if (PantallaEvaluada) return EstadoDeError;
            PantallaEvaluada = true;
            foreach (var v in VariablesPropias)
            {
                EstadoDeError |= v.ErrorState();
            }
            return EstadoDeError;
        }

    }
}
