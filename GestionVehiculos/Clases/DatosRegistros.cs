using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace GestionVehiculos.Clases
{
    internal class DatosRegistros
    {
        private string ruta = @"C:\Datos\registros.json";
        private List<VehiculoRegistro> vehiculoRegistro;

        public List<VehiculoRegistro> VehiculoRegistro { get => vehiculoRegistro; set => vehiculoRegistro = value; }

        public DatosRegistros() {
            DeserializeJson();
        }

        //Deserialize
        private void DeserializeJson() {
            string jsonFile = File.ReadAllText(this.ruta);
            if(jsonFile != "") this.vehiculoRegistro = JsonConvert.DeserializeObject<List<VehiculoRegistro>>(jsonFile);        
        }
    }
}
