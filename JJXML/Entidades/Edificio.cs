using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Entidades
{
    public class Edificio
    {
        public string Name { get;}
        string Id { get; set; }
        string Description { get; set; }
        public List<Sensor> Sensores = new List<Sensor>();
        public Edificio(String name, String descripcion)
        {
            Name = name;
            Description = descripcion;
        }
    }
}
