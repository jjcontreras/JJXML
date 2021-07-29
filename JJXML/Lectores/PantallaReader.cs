using JJXML.Entidades;
//using JJXML.Entidades.Pantalla;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace JJXML.Lectores
{
    public static class PantallaReader
    {
        public static List<Evento> Read(string path, EntornoData entorno)
        {
            List<Evento> Eventos = new List<Evento>();
            string[] files = Directory.GetFiles(path, "*.xscn");

            foreach (var f in files)
            {
                XDocument doc = XDocument.Load(f, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
                foreach (var layout in doc.Descendants("page"))
                {
                    foreach (var graph in layout.Elements())
                    {
                        String NodoName = graph.Name.ToString();
                        switch (NodoName)
                        {
                            case "id":
                            case "name":
                            case "width":
                            case "height":
                            case "rounded":
                            case "xgrid":
                            case "ygrid":
                            case "backgroundImage":
                            case "scadaGraph":
                            case "formule":
                            case "showDevice":
                            case "forceValues":
                            case "showGraph":
                            case "showScada": // Ver si se pueden validar las cargas de una pantalla desde otra
                            case "showReport":// Ver si se pueden validar las cargas de un report desde otra
                            case "launchApp": // Ver Apps lanzadas desde una pantalla
                            case "conditioned":
                            case "label":
                                break;
                            default:
                                Console.WriteLine("*** NODO NO TRATADO *** " + NodoName);
                                //Console.WriteLine(graph.Value);
                                break;
                        }


                    }
                }
                foreach (var layout in doc.Descendants("scadaLayout"))
                {
                    String name = layout.Element("name").Value.Trim();
                    Console.WriteLine("Name: " + name);
                    Pantalla pantalla = new Pantalla(name,"", entorno.VariablesSistema);
                    entorno.Pantallas.Add(pantalla);
                    foreach (var graph in layout.Descendants("scadaGraph"))
                    {
                        foreach (var variable in graph.Descendants("variable"))
                        {
                            String varname = variable.Element("id").Value.Trim();
                            //Console.WriteLine("Var: " + varname);
                            String varSensor = ValueSplitter.QuitarPuntosVarSensor(varname);
                            //Console.WriteLine("*VarSensor: " + varSensor);
                            pantalla.AddVar(varSensor, "scadaGraph");
                        }
                    }
                    foreach (var graph in layout.Descendants("showGraph"))
                    {
                        foreach (var variable in graph.Descendants("variable"))
                        {
                            String varname = variable.Element("id").Value.Trim();
                            //Console.WriteLine("showGraph: " + varname);
                            String varSensor = ValueSplitter.QuitarPuntosVarSensor(varname);
                            //Console.WriteLine("*showGraph: " + varSensor);
                            pantalla.AddVar(varSensor, "showGraph");
                        }
                    }
                    foreach (var graph in layout.Descendants("conditioned"))
                    {
                        foreach (var variable in graph.Descendants("control"))
                        {
                            String varname = variable.Element("condition").Value.Trim();
                            //Console.WriteLine("conditioned: " + varname);
                            List<String> str = ValueSplitter.Split(varname);
                            //foreach (var t in str)
                            //    Console.WriteLine("*conditioned: " + t);
                            pantalla.AddVar(str, "conditioned");
                        }
                    }
                    foreach (var graph in layout.Descendants("forceValues"))
                    {
                        foreach (var variable in graph.Descendants("variable"))
                        {
                            String varname = variable.Element("id").Value.Trim();
                            //Console.WriteLine("forceValues: " + varname);
                            pantalla.AddVar(varname, "forceValues");
                        }
                    }
                    foreach (var form in layout.Descendants("formule"))
                    {
                        String varname = form.Element("value")?.Value.Trim();
                        if (varname != null)
                        {
                            var str = ValueSplitter.Split(varname);
                            //Console.WriteLine("Var: " + varname);
                            //foreach (var t in str)
                            //    Console.WriteLine("*VarSplit: " + t);
                            pantalla.AddVar(str, "formule");
                        }
                    }
                    foreach (var form in layout.Descendants("showDevice"))
                    {
                        String varname = form.Element("device").Value.Trim();
                        //Console.WriteLine("Var: " + varname);
                        pantalla.AddVar(varname, "showDevice");
                    }
                }            
            }
            return Eventos;
        }
    }
}
