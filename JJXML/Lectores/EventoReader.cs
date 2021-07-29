using JJXML.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JJXML.Lectores
{
    class EventoReader
    {
        public static List<Evento> Read(string path, EntornoData entorno)
        {
            List<Evento> Eventos = new List<Evento>();
            string file = path + "default.xeve";
            XDocument doc = XDocument.Load(file, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
            

            //XDocument doc2 = new XDocument(
            //    new XElement("Root",
            //        from el in doc.Descendants("commSystem").Elements()
            //        where el.Name == "device"
            //        select el)
            //);
            

            foreach (var elem in doc.Descendants("event"))
            {
                String name = elem.Element("name").Value.Trim();
                String namevar = "R$EVE_" + name;
                string description = (elem.Element("description")?.Value.Trim() ?? "");
                description = description.Replace(Environment.NewLine, " ");
                description = description.Replace(";", "-");
                //Console.WriteLine(" - " + name);
                String condition = elem.Element("condition").Value;                
                //Console.WriteLine(condition);
                var str = ValueSplitter.Split(condition);
                Evento evento = new Evento(namevar, description, str, entorno.VariablesSistema,condition);
                entorno.Eventos.Add(evento);
                entorno.VariablesSistema.Add(evento);

                //foreach (string s in str)
                //    Console.WriteLine(s);
                //Console.WriteLine("            ------          ");

            }
            return Eventos;
        }
    }
}
