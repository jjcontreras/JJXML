using JJXML.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JJXML.Lectores
{
    class VariableReader
    {
        public static List<Variable> Read(String path, EntornoData entorno)
        {
            List<Variable> Variables = new List<Variable>();
            String file = path + "default.xcal";
            XDocument doc = XDocument.Load(file, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);


            //variablesGroup variable

            foreach (var grupo in doc.Descendants("variablesGroup"))
            {
                string grupoName = grupo.Element("name").Value.Trim();
                //Console.WriteLine(grupo.Element("name").Value);
                foreach (var variable in grupo.Descendants("variable"))
                {
                    String name = variable.Element("name").Value.Trim();
                    String namevar = "R$CAL_" + grupoName + "." + name;
                    string description = (variable.Element("description")?.Value.Trim() ?? "");
                    //Console.WriteLine(" - " + namevar);
                    String value = variable.Element("value").Value;
                    //Console.WriteLine(" - " + value);

                    var str = ValueSplitter.Split(value);
                    var variabledef = new Variable(namevar, description, str, entorno.VariablesSistema,value);

                    entorno.Variables.Add(variabledef);
                    entorno.VariablesSistema.Add(variabledef);

                    //foreach (string s in str)
                    //    Console.WriteLine(" *" + s);

                    //Console.WriteLine("            ------          ");
                }
            }
            return Variables;
        }
    }
}
