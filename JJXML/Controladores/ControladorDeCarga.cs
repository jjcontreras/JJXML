using JJXML.Entidades;
using JJXML.Lectores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Controladores
{
    public class ControladorDeCarga
    {
        public void CargarDatos(EntornoData data, string path)
        {
            EdificioReader.Read(path,data);
            VariableReader.Read(path, data);
            EventoReader.Read(path,data);
            PantallaReader.Read(path, data);
        }
    }
}
