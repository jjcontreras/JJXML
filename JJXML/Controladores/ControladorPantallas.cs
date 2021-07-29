using JJXML.Entidades;
using JJXML.Escritores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Controladores
{
    public class ControladorPantallas
    {
        private readonly EntornoData entorno;
        private readonly string pathOut;

        public ControladorPantallas(EntornoData entorno, String outPath)
        {
            this.entorno = entorno;
            this.pathOut = outPath;
        }
        public void Pantallas_ListaConEstado ()
        {
            string path = pathOut + "Pantallas_ListaConEstado.csv";
            List<string> lineas = new List<string>();
            lineas.Add("Pantalla;Error");
            foreach (var p in entorno.Pantallas)
            {
                    lineas.Add(p.Name + ";" + p.ErrorState().ToString());
            }
            WriteTextToFile.Write(path, lineas);
        }
        public void VariablesyEventosConErrorEnReferencia()
        {
            string path = pathOut + "Pantallas-VariablesyEventosConErrorPorPantalla.csv";
            List<string> lineas = new List<string>();
            lineas.Add("Pantalla;Nombre;Etiqueta;ReferenciasEnPantalla;ExisteLaReferencia");
            foreach (var p in entorno.Pantallas)
            {
                foreach (var v in p.VariablesPropias)
                {
                    if (v.ErrorState())
                    {
                        lineas.Add(p.Name+ ";" + v.Name + ";" + v.EtiquetaOrigen + ";" + v.NumReferencias + ";" + (v.referencia != null).ToString());                        
                    }
                }
            }
            WriteTextToFile.Write(path, lineas);
        }
        public void VariablesRefenciadasNoEncontradas()
        {
            ListaDeVariablesConCuenta variablesNoEncontradas = new ListaDeVariablesConCuenta();
            foreach (var p in entorno.Pantallas)
            {
                foreach (var v in p.VariablesPropias)
                {
                    if (v.ErrorState())
                    {
                        variablesNoEncontradas.Add(v.Name, (v.referencia != null)); 
                    }
                }
            }

            string path = pathOut + "Pantallas-VariablesRefenciadasConError.csv";
            List<string> lineas = new List<string>();
            lineas.Add("Nombre;NumReferencias");
            foreach (var v in variablesNoEncontradas.lista)
            {
                lineas.Add(v.Name + ";" + v.Cuenta+";"+ v.VariableExistente.ToString());
            }

            WriteTextToFile.Write(path, lineas);
        }
    }
}
