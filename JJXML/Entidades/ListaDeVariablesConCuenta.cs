using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JJXML.Entidades
{
    public class ListaDeVariablesConCuenta
    {
        public List<VariableDeCuenta> lista = new List<VariableDeCuenta>() ;
        public void Add(string name, bool varEexistente =false)
        {
            var v = lista.Where(x => x.Name == name).FirstOrDefault();
            if (v == null)
            {
                lista.Add(new VariableDeCuenta(name, varEexistente));
            }
            else {
                v.Cuenta++;
            }
        }
    }
}
