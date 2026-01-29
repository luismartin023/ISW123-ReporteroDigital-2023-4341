using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace ISW123_ReporteroDigital_2023_4341
{

    //Excepcion perzonalizada:

    public class ExcepcionReportero : Exception
    { 
        public string RecursoFallido { get; }
        public ExcepcionReportero(string message, string recurso) : base(message)
        {
            RecursoFallido = recurso;
        }
    }

    // Clase para el administrador de noticias y aplicacion de Async y Await:

    public class GestorNoticias
    {

        //Inicio de eventos 

        public event Action<string>? OnIniciando;
        public event Action<string>? OnFinalizado;

        //Invocacion de eventos y await



    }


    // Clase principal del programa con Async y Await
    public class ProgramaPrincipal
    {
    }
}

