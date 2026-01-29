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

        public async Task<string> DescargarEstadisticasAsycn(bool explotar)
        {
            OnIniciando?.Invoke("Los Datos de Analisis...");

            Console.WriteLine("Descargando estadisticas...");
            await Task.Delay(1500);

            // Uso de excepcion personalizada throw new

            if (explotar)
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
        //Metodo principal del programa con main y async

        public static async Task Main(string[] args)
        {
            //Bienvenida al programa

            Console.WriteLine("=================================================");
            Console.WriteLine(" REPORTERO DIGITAL - MATRÍCULA 2023-4341");
            Console.WriteLine("=================================================");

            // Verificar matricula

            Console.WriteLine("Ingrese su matrícula por favor mi loco:");
            string matricula = Console.ReadLine() ?? "";

            // Si para verificar la matricula

            if (matricula != "2023-4341")
            {
                Console.WriteLine("Matrícula incorrecta. mi loco, quien tu ere, aqui solo puede entrar mi querido martin (2023-4341).");
                return;
            }

            Console.WriteLine($"\nBienvenido manito. Vamos a armar la noticia.\n");


            //Seleccion de modo de fallo
            Console.WriteLine("¿Quieres que las estadísticas EXPLOTEN? (Escribe 'S' para Sí, cualquier otra tecla para No):");
            string respuesta = Console.ReadLine()?.ToUpper() ?? "N";
            bool modoExplosion = (respuesta == "S");

            if (modoExplosion)
                Console.WriteLine(" OJO: Elegiste que el sistema falle a propósito.\n");
            else
                Console.WriteLine(" OJO: Elegiste que todo funcione bien.\n");

            GestorNoticias gestor = new GestorNoticias();

            // Suscripcion a eventos y try catch
            gestor.OnIniciando += mensaje => Console.WriteLine($"[INICIO]: {mensaje}");
            gestor.OnFinalizado += mensaje => Console.WriteLine($"[FINALIZADO]: {mensaje}");
            try
            {
                var tareaTexto = gestor.DescargarTextoAsycn();
                var tareaFotos = gestor.DescargarImagenAsync();
                var tareaStats = gestor.DescargarEstadisticasAsycn(modoExplosion);

                // Esperamos a que todas terminen (o que alguna falle)
                await Task.WhenAll(tareaTexto, tareaFotos, tareaStats);

                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine(" NOTICIA COMPLETADA EXITOSAMENTE:");
                Console.WriteLine($"1. {await tareaTexto}");
                Console.WriteLine($"2. Adjuntos: {await tareaFotos}");
                Console.WriteLine($"3. Data: {await tareaStats}");
                Console.WriteLine("--------------------------------------------------");
            }
            catch (ExcepcionReportero ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n DIABLO MANITO, HUBO UN ERROR: {ex.Message}");
                Console.WriteLine($" Lo que falló fue: {ex.RecursoFallido}");
                Console.ResetColor();
                Console.WriteLine("Publicaremos la noticia incompleta (sin esa parte pa que funcione).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general no controlado: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nProceso finalizado. Presiona una tecla para salir.");
                Console.ReadKey();
            }
        }
        
    }
}
    

