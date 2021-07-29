using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Entidades
{
    public class EntornoData
    {
        public List<Edificio> Edificios = new List<Edificio>();
        public List<Sensor> Sensores = new List<Sensor>();
        public List<Variable> Variables = new List<Variable>();
        public List<Evento> Eventos = new List<Evento>();
        public List<VariableBase> VariablesSistema = new List<VariableBase>();

        public List<Pantalla> Pantallas = new List<Pantalla>();

    }
}
