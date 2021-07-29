using JJXML.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Lectores
{
    public static class ValueSplitter
    {
        public static string QuitarPuntosVarSensor(String varName)
        {
            if (varName.StartsWith("R$CAL_")) return varName;
            //if (varName.StartsWith("R$EVE_")) return varName;
            var varSplit = varName.Split('.');
            if (varSplit.Length > 2)
            {
                Console.WriteLine("********************          QUITAR PUNTOS: ERROR DE PUNTOS EN SENSOR *********************");
                return varSplit[0]+varSplit[1];
            }
            //Console.WriteLine("********************          QUITAR PUNTOS: VARIABLE ESPERADA *********************");
            return varSplit[0];
        }

        public static List<String> Split(String valor)
        {
            List<String> result = new List<String>();
            var variables = valor.Split('[').ToList();
            variables.RemoveAt(0);
            foreach(String t in variables)
            {
                String r = t.Split(']').FirstOrDefault();
                r = QuitarPuntosVarSensor(r);
                if (!result.Exists(x=> x == r))
                {
                    result.Add(r);
                }
                else
                {
                    //Console.WriteLine("DUPLICADO");
                }                               
            }
            return result;
        }
    }
}
