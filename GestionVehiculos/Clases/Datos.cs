using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace GestionVehiculos.Clases
{
    internal class Datos
    {
        private string ruta;
        private List<TipoVehiculo> vehiculos;

        //Leer json
        private string LeerJson() {
            string jsonFile;
            using (var lectura = new StreamReader(this.ruta)) {
                jsonFile = lectura.ReadToEnd();
            }
            return jsonFile;
        }

        //Deserializa json
        private void DeserializeJson(){
            this.vehiculos = JsonConvert.DeserializeObject<List<TipoVehiculo>>(LeerJson());
        }

        //Obtener Tipo
        public List<string>GetTipos() {
            List<string> tipos = new List<string>();
            this.vehiculos.ForEach(tipo => tipos.Add(tipo.Nombre));
            return tipos;
        }

        //Obtener Marca
        public List<string> GetMarcas(string tipo) {
            List<string> marcas = new List<string>();
            foreach (var tipoVehiculo in this.vehiculos)
            {
                if (tipoVehiculo.Nombre == tipo) {
                    tipoVehiculo.Vehiculos.ForEach(marca => marcas.Add(marca.NombreMarca));
                }
            }
            return marcas;
        }

        //Obtener Modelo
        public List<string> GetModelos(string tipo,string marca) {
            List<string> modelos = new List<string>();
            foreach (var tipoVehiculo in this.vehiculos)
            {
                if (tipoVehiculo.Nombre == tipo)
                {
                    foreach (var vehiculo in tipoVehiculo.Vehiculos)
                    {
                        if (vehiculo.NombreMarca == marca) {
                            foreach (var modelo in vehiculo.Modelos)
                            {
                                modelos.Add(modelo);
                            }
                        }
                    }
                }
            }
            return modelos;
        }

        public Datos(string ruta) {
            this.ruta = ruta;
            DeserializeJson();
        }
    }
}
