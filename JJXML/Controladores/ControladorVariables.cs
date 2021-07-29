using JJXML.Entidades;
using JJXML.Escritores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Controladores
{
    public class ControladorVariables
    {
        private readonly EntornoData entorno;
        private readonly string pathOut;

        public ControladorVariables(EntornoData entorno, String outPath)
        {
            this.entorno = entorno;
            this.pathOut = outPath;
        }

        public void VariablesConValorDirecto()
        {
            string path = pathOut + "VariablesConValorDirecto.csv";
            List<string> lineas = new List<string>();
            lineas.Add("Variable;Descripcion;Valor");
            foreach (var v in entorno.Variables)
            {
                if (v.VariablesPropias.Count() == 0)
                {
                    lineas.Add(v.Name + ";" + v.Description + ";" + v.Value);
                }
            }
            WriteTextToFile.Write(path, lineas);
        }

        public int ComprobarErrores()
        {
            int NumErrores = 0;
            foreach (var v in entorno.VariablesSistema)
            {
                if (v.ErrorState())
                {
                    //Console.WriteLine(v.Name);
                    NumErrores++;
                }
            }
            return NumErrores;
        }
        public void VariablesyEventosConErrorEnReferencia()
        {
            string path = pathOut + "VariablesyEventosConErrorEnReferencia.csv";
            List<string> lineas = new List<string>();
            lineas.Add("Tipo;Nombre;Descripcion;ReferenciasNoValidas;ExpresionDondeSeUsa");
            foreach (var v in entorno.Variables)
            {
                if (v.ErrorState())
                {
                    string varNoValidas = "";
                    if (v.VariablesPropias.Count() != 0)
                    {                        
                        foreach (var vp in v.VariablesPropias)
                        {
                            if (vp.referencia == null)
                            {
                                if (varNoValidas != "")
                                    varNoValidas += ",";
                                varNoValidas += vp.Name;
                            }
                        }
                        if (varNoValidas != "")
                            lineas.Add("Variable" + ";" + v.Name + ";" + v.Description + ";" + varNoValidas + ";" + v.Value);
                    }                    
                }
            }
            foreach (var v in entorno.Eventos)
            {
                if (v.ErrorState())
                {
                    string varNoValidas = "";
                    if (v.VariablesPropias.Count() != 0)
                    {
                        
                        foreach (var vp in v.VariablesPropias)
                        {
                            if (vp.referencia == null)
                            {
                                if (varNoValidas != "")
                                    varNoValidas += ",";
                                varNoValidas += vp.Name;
                            }
                        }
                        if (varNoValidas!="")
                            lineas.Add("Evento" + ";" + v.Name + ";" + " "/*v.Description*/ + ";" + varNoValidas + ";" + "" /*+ v.Condition*/);
                    }                    
                }
            }            
            WriteTextToFile.Write(path, lineas);
        }
        public void VariablesRefenciadasNoEncontradas()
        {
            ListaDeVariablesConCuenta variablesNoEncontradas = new ListaDeVariablesConCuenta();
            foreach (var v in entorno.VariablesSistema)
            {
                if (v.VariablesPropias.Count != 0)
                {                    
                    foreach (var vp in v.VariablesPropias)
                    {
                        if (vp.referencia == null)
                        {
                            variablesNoEncontradas.Add(vp.Name);
                        }
                    }
                }
            }

            string path = pathOut + "VariablesRefenciadasNoEncontradas.csv";
            List<string> lineas = new List<string>();
            lineas.Add("Nombre;NumReferencias");
            foreach (var v in variablesNoEncontradas.lista)
            {               
                lineas.Add(v.Name + ";" + v.Cuenta );
            }

            WriteTextToFile.Write(path, lineas);
        }
    }
}
