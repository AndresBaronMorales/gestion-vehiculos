using GestionVehiculos.Clases;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestionVehiculos
{
    public partial class formGestionVehiculos : Form
    {
        public formGestionVehiculos()
        {
            InitializeComponent();

            //Cargando datos en el comboBox Tipo
            Datos opcionesComboBox = new Datos(@"C:\Datos\opcionesComboBox.json");
            cbxFormRegistroTipo.Items.AddRange(opcionesComboBox.GetTipos().ToArray());

            //datagrid
            dgvCargarDatos();            
        }

        //Headers datagrid
        public void dgvHeaders(DataGridView dvg)
        {
            dvg.Columns[0].HeaderText = "Tipo de vehículo";
            dvg.Columns[1].HeaderText = "Marca";
            dvg.Columns[2].HeaderText = "Modelo";
            dvg.Columns[3].HeaderText = "Matricula";
        }

        //Cargando datos al datagrid
        public void dgvCargarDatos()
        {
            DatosRegistros registros = new DatosRegistros();
            
            if (registros.VehiculoRegistro != null) {
                List<VehiculoRegistro> lista = registros.VehiculoRegistro;
                var datos = new BindingSource();

                datos.DataSource = lista;
                dgvRegistros.DataSource = datos;
                dgvHeaders(dgvRegistros);
            }
        }

        //Elemento seleccionado del comboBox
        public static string seleccionComboBox(ComboBox cbx)
        {
            string elemento = Convert.ToString(cbx.Items[cbx.SelectedIndex]);
            return elemento;
        }

        //Registrando datos comboBox Marca
        private void cbxFormRegistroTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            Datos opcionesComboBox = new Datos(@"C:\Datos\opcionesComboBox.json");
            
            cbxFormRegistroMarca.Items.Clear();
            cbxFormRegistroModelo.Items.Clear();

            cbxFormRegistroMarca.Items.AddRange(opcionesComboBox.GetMarcas(seleccionComboBox(cbxFormRegistroTipo)).ToArray());
        }

        //Registrando datos comboBox Modelo
        private void cbxFormRegistroMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            Datos opcionesComboBox = new Datos(@"C:\Datos\opcionesComboBox.json");

            cbxFormRegistroModelo.Items.Clear();
            cbxFormRegistroModelo.Items.AddRange(opcionesComboBox.GetModelos(seleccionComboBox(cbxFormRegistroTipo), seleccionComboBox(cbxFormRegistroMarca)).ToArray());
        }

        //Registro btn
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            //Registrando datos en el json
            VehiculoRegistro datosRegistrados = new VehiculoRegistro(seleccionComboBox(cbxFormRegistroTipo), seleccionComboBox(cbxFormRegistroMarca), seleccionComboBox(cbxFormRegistroModelo), txtMatricula.Text);
            Registro registro = new Registro(datosRegistrados);
            registro.RegistrarVehiculo();

            dgvCargarDatos();

            //Clear formulario
            cbxFormRegistroTipo.SelectedIndex = 0;
            txtMatricula.Clear();
        }
    }
}
