using JJXML.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace JJXML.Lectores
{
    public static class EdificioReader
    {
        public static bool Read(string path,EntornoData entorno)
        {
            //List<Edificio> Edificios = new List<Edificio>();
            string file = path + "default.xcfg";
            XDocument doc = XDocument.Load(file, LoadOptions.SetBaseUri | LoadOptions.SetLineInfo);
            //doc.Save(@"E:\Circutor\CompartidaVM\Editor\Editor\20210129\Cfg\pruebajj.xml", SaveOptions.DisableFormatting);
            //String str = File.ReadAllText(@"E:\Circutor\CompartidaVM\Editor\Editor\20210129\Cfg\pruebajj.xml");

            //var query = from c in doc.Root.Descendants("commSystem")
            //            where (int)c.Attribute("id") < 4
            //            select c.Element("firstName").Value + " " +
            //                   c.Element("lastName").Value;
            //var query = from c in doc.Root.Descendants("commSystem")
            //            select c;

            XDocument doc2 = new XDocument(
                new XElement("Root",
                    from el in doc.Descendants("commSystem").Elements()
                    where el.Name == "device"
                    select el)
            );
            //List<string> idCosas = (from item in doc2.Descendants("device")
            //                        select item.Element("name").Value).ToList();
            //doc2.Root.Descendants()
            //.ToList()
            //.ForEach(e => Console.WriteLine(e.Name));
            int count = 0;
            foreach (var device in doc2.Descendants("device"))
            {
                string edificioName = device.Element("name").Value;
                string edificioDescription = device.Element("description").Value;
                count++;
                //Console.WriteLine(count +" -  "+edificioName);
                Edificio edificio = new Edificio(edificioName, edificioDescription);                
                entorno.Edificios.Add(edificio);
                foreach (var child in device.Descendants("childDevice"))
                {
                    string sensorName = child.Element("name").Value;
                    string sensorDescription = child.Element("description").Value;
                    Sensor sensor = new Sensor(sensorName, sensorDescription, entorno.VariablesSistema);
                    edificio.Sensores.Add(sensor);
                    entorno.Sensores.Add(sensor);
                    entorno.VariablesSistema.Add(sensor);
                    //Console.WriteLine(sensorName);
                }
            }
            //Console.WriteLine(doc2);
            //Console.WriteLine(idCosas[0]);
            return true;
        }
    }


}
