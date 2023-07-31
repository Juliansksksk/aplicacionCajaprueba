using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplicacionCaja
{
    public partial class FormularioCaja : Form
    {
        public FormularioCaja()
        {
            InitializeComponent();

            SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog=GestionDocumentaldos;Integrated Security=True;");

            string query = "SELECT NombreEntidad FROM EntidadesFinancieras";
            SqlCommand command = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(reader["NombreEntidad"].ToString());
            }

            reader.Close();
            conexion.Close();



        }

        private void label1_Click(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {



            try
            {

           


            string EntidadFinanciera = listBox1.SelectedItem.ToString();
            int IdEntidadFinanciera = 0;
            string Zona =  textBoxZona.Text;
            string Seccion = textBoxSeccion.Text;
            string Nivel = textBoxNivel.Text;
            string Cara = textBoxCara.Text;
            string CodigoBarras = "NO";


            if (EntidadFinanciera == "Bancolombia")
            {
                IdEntidadFinanciera = (1);
            }
            else if (EntidadFinanciera == "Davivienda")
            {
                IdEntidadFinanciera = (2);
            }
           

            // Crear la conexión a la base de datos
            SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog=GestionDocumentaldos;Integrated Security=True;");

            // Crear la consulta SQL para insertar la información de la caja
            string consulta = "INSERT INTO Cajas (IdEntidadFinanciera, Zona, Seccion, Nivel, Cara, CodigoBarras) VALUES (@IdEntidadFinanciera, @Zona, @Seccion, @Nivel, @Cara,@CodigoBarras)";

            // Crear el comando SQL y agregar los parámetros
            SqlCommand comando = new SqlCommand(consulta, conexion);
            comando.Parameters.AddWithValue("@IdEntidadFinanciera", IdEntidadFinanciera);
            comando.Parameters.AddWithValue("@Zona", Zona);
            comando.Parameters.AddWithValue("@Seccion", Seccion);
            comando.Parameters.AddWithValue("@Nivel", Nivel);
            comando.Parameters.AddWithValue("@Cara", Cara);
            comando.Parameters.AddWithValue("@CodigoBarras", CodigoBarras);

            // Abrir la conexión y ejecutar la consulta
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();

            MessageBox.Show("La información de la caja se ha almacenado correctamente.");



            }
            catch (Exception)
            {
                MessageBox.Show("La información de la caja no se pudo almacenar .");
            }

        }

        private void FormularioCaja_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormularioCarpeta form2 = new FormularioCarpeta(); 
            form2.Show(); 
            this.Hide(); 
        }

        private void button3_Click(object sender, EventArgs e)
        {

            FormularioCliente form3 = new FormularioCliente(); 
            form3.Show(); 
            this.Hide(); 

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Reporte Form4 = new Reporte();
            Form4.Show();
            this.Hide();

        }
    }
}
