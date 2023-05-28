namespace GestionVehiculos.Clases
{
    internal class VehiculoRegistro
    {
        private string tipoVehiculo;
        private string marca;
        private string modelo;
        private string matricula;

        public string TipoVehiculo { get => tipoVehiculo; set => tipoVehiculo = value; }
        public string Marca { get => marca; set => marca = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Matricula { get => matricula; set => matricula = value; }

        public VehiculoRegistro(string tipoVehiculo, string marca, string modelo, string matricula)
        {
            this.tipoVehiculo = tipoVehiculo;
            this.marca = marca;
            this.modelo = modelo;
            this.matricula = matricula;
        }
    }
}
