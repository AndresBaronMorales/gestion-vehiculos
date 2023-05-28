using System.Collections.Generic;

namespace GestionVehiculos.Clases
{
    internal class TipoVehiculo
    {
        private string nombre;
        private List<Vehiculo> vehiculos;

        public string Nombre { get => nombre; set => nombre = value; }
        public List<Vehiculo> Vehiculos { get => vehiculos; set => vehiculos = value; }

        public TipoVehiculo() { }
    }
}
