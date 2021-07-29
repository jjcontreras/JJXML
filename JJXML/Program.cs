using JJXML.Controladores;
using JJXML.Entidades;
using JJXML.Lectores;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace JJXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //string WorkPath = @"E:\Circutor\CompartidaVM\Editor\Editor\20210129\Cfg\";
            string WorkPath = @"E:\Circutor\CompartidaVM\Cfg Real\Cfg\";
            string OutPath = @"E:\Circutor\Analisis\";


            ControladorDeCarga ctr = new ControladorDeCarga();
            EntornoData Entorno = new EntornoData();
            ctr.CargarDatos(Entorno, WorkPath);
            Console.WriteLine("Edificios: " + Entorno.Edificios.Count().ToString() );
            Console.WriteLine("Sensores: " + Entorno.Sensores.Count().ToString());
            Console.WriteLine("Variables: " + Entorno.Variables.Count().ToString());
            Console.WriteLine("Eventos: " + Entorno.Eventos.Count().ToString());
            Console.WriteLine("Total Variables: " + Entorno.VariablesSistema.Count().ToString());

            Console.WriteLine("Total Pantalla: " + Entorno.Pantallas.Count().ToString());


            ControladorEdificios controladorEdificios = new ControladorEdificios(Entorno, OutPath);
            controladorEdificios.ListadoEdificiosSensores();
            ControladorVariables controladorVariables = new ControladorVariables(Entorno, OutPath);
            controladorVariables.VariablesConValorDirecto();
            Console.WriteLine("Total Errores: " + controladorVariables.ComprobarErrores().ToString());

            controladorVariables.VariablesyEventosConErrorEnReferencia();
            controladorVariables.VariablesRefenciadasNoEncontradas();

            ControladorPantallas controladorPantallas = new ControladorPantallas(Entorno, OutPath);
            controladorPantallas.Pantallas_ListaConEstado();
            controladorPantallas.VariablesyEventosConErrorEnReferencia();
            controladorPantallas.VariablesRefenciadasNoEncontradas();

        }
    }
}
