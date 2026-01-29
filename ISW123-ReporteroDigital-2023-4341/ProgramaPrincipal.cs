using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ISW123_ReporteroDigital_2023_4341
{

    //Excepcion perzonalizada

    public class ExcepcionReportero : Exception
    { 
        public string RecursoFallido { get; }
        public ExcepcionReportero(string message, string recurso) : base(message)
        {
            RecursoFallido = recurso;
        }
    }


    // Clase principal del programa con Async y Await
    public class ProgramaPrincipal
    {
    }
}

