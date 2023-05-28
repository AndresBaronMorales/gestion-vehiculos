using Newtonsoft.Json;
using System.IO;

namespace GestionVehiculos.Clases
{
    internal class Registro
    {
        private string ruta = @"C:\Datos\registros.json";
        private VehiculoRegistro vehiculoRegistro;

        public Registro(VehiculoRegistro vehiculoRegistro) {
            this.vehiculoRegistro = vehiculoRegistro;
        }

        public void RegistrarVehiculo()
        {
            string datosJson = JsonConvert.SerializeObject(this.vehiculoRegistro);
            string datosRegistrados = File.ReadAllText(this.ruta);
            
            if (datosRegistrados == "") datosRegistrados = "[]";
            if (datosRegistrados == "[]")
            {
                datosRegistrados = datosRegistrados.Insert(datosRegistrados.Length - 1, datosJson);
            }
            else
            {
                datosRegistrados = datosRegistrados.Insert(datosRegistrados.Length - 1, $",{datosJson}");
            }
            File.WriteAllText(this.ruta, datosRegistrados);
        }
    }
}
