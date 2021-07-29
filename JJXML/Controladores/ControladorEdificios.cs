using JJXML.Entidades;
using JJXML.Escritores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Controladores
{
    public class ControladorEdificios
    {
        private readonly EntornoData entorno;
        private readonly string pathOut;

        public ControladorEdificios(EntornoData entorno, String outPath)
        {
            this.entorno = entorno;
            this.pathOut = outPath;
        }

        public void ListadoEdificiosSensores()
        {
            string path = pathOut + "ListadoEdificiosSensores.csv";
            List<string> lineas = new List<string>();
            lineas.Add("Edificio;NumSensores");
            foreach (var edif in entorno.Edificios)
                lineas.Add(edif.Name + ";" + edif.Sensores.Count.ToString());
            WriteTextToFile.Write(path, lineas);
        }


    }
}
