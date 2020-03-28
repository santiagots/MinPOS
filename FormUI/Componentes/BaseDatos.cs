using System;
using System.IO;
using System.Reflection;

namespace FormUI.Componentes
{
    public class BaseDatos
    {
        private static string[] ExtencionesBaseDatos = { ".mdf", "_log.ldf" };

        public static void Inicializar(string NombreBaseDatos)
        {
            CopiarBaseDatosEnAppData(NombreBaseDatos);
            DefinirDataDirectory();
        }

        private static void CopiarBaseDatosEnAppData(string NombreBaseDatos)
        {

            if (!Directory.Exists(ObtenerRutaDestinoBaseDatos()))
                Directory.CreateDirectory(ObtenerRutaDestinoBaseDatos());

            foreach (string extencion in ExtencionesBaseDatos)
            {
                string nombreBaseDatosCompleto = NombreBaseDatos + extencion;
                string rutaOrigen = Path.Combine(ObtenerRutaBaseDatosEjecutable(), nombreBaseDatosCompleto);
                string rutaDestino = Path.Combine(ObtenerRutaDestinoBaseDatos(), nombreBaseDatosCompleto);
                if ((!File.Exists(rutaDestino)))
                    File.Copy(rutaOrigen, rutaDestino);
            }
        }

        private static void DefinirDataDirectory() => AppDomain.CurrentDomain.SetData("DataDirectory", ObtenerRutaDestinoBaseDatos());

        private static string ObtenerRutaBaseDatosEjecutable()
        {
            string rutaArchivoEjecutable = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string rutaBaseDatos = "DB";
            return Path.Combine(rutaArchivoEjecutable, rutaBaseDatos);
        }
        private static string ObtenerRutaDestinoBaseDatos()
        {
            string rutaCarpetaAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string nombreAplicacion = Assembly.GetExecutingAssembly().GetName().Name;
            return Path.Combine(rutaCarpetaAppData, nombreAplicacion);
        }
    }
}
