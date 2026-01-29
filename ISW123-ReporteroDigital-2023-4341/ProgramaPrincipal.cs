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

        public async Task<string> DescargarTextoAsycn()
        {

            OnIniciando?.Invoke("Tamo decargando la vaina");

            Console.WriteLine("Descargando...");
            await Task.Delay(2000); 

            OnFinalizado?.Invoke("Pa, ya se decargo.");
            return "Texto descargado.";

        }

        // Simulando la descarga de una imagen de manera asincrona

        public async Task<string> DescargarImagenAsync()
        {
            OnIniciando?.Invoke("Lider, yo se que tu wifi ta lento pero decarga esto...");

            Console.WriteLine("Descargando imagen...");
            await Task.Delay(3000); 

            OnFinalizado?.Invoke("Descarga de imagen nitida.");
            return "[Foto_Goku.jpg, Foto_Naruto.png]";
        }

        // Datos de visitas de noticias

        public async Task<string> DescargarEstadisticasAsycn()
        {
            OnIniciando?.Invoke("Los Datos de Analisis...");

            Console.WriteLine("Descargando estadisticas...");
            await Task.Delay(1500);

            // Uso de excepcion personalizada throw new

            Random rnd = new Random();
            if (rnd.Next(0, 2) == 0) 
            {
                throw new ExcepcionReportero("Mi loco, se daño la vuelta, no hicieron como a maduro y se cayo el sistema.", "Estadisticas");
            }

            OnFinalizado?.Invoke("Estadisticas listas.");
            return "Visitas: 1500, Likes: 300, Shares: 75";
        }

       

    }




    // Clase principal del programa con Async y Await
    public class ProgramaPrincipal
    {
    }
}

