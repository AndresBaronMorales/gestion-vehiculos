using System.Collections.Generic;

namespace GestionVehiculos.Clases
{
    internal class Vehiculo
    {
        private string nombreMarca;
        private List<string> modelos;

        public string NombreMarca { get => nombreMarca; set => nombreMarca = value; }
        public List<string> Modelos { get => modelos; set => modelos = value; }

        public Vehiculo() { }
    }
}
