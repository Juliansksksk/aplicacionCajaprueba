using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace aplicacionCaja
{
    public partial class FormularioCarpeta : Form
    {
        public FormularioCarpeta()
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

            

            string query2 = "SELECT IdCaja FROM cajas";
            SqlCommand command1 = new SqlCommand(query2, conexion);
            conexion.Open();
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                listBox2.Items.Add(reader1["IdCaja"].ToString());
            }

            reader.Close();
            conexion.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            

                string EntidadFinanciera = listBox1.SelectedItem.ToString();
                int IdEntidadFinanciera = 0;
                int caja = int.Parse(listBox2.SelectedItem.ToString());
                string CodigoBarras = "NO";
                string Idcliente = textBox1.Text;
              


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
                string consulta = "INSERT INTO Carpetas (IdCliente, IdEntidadFinanciera,  Idcaja, CodigoBarras) VALUES (@IdCliente, @IdEntidadFinanciera, @Idcaja, @CodigoBarras)";

                // Crear el comando SQL y agregar los parámetros
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@IdCliente", Idcliente);
                comando.Parameters.AddWithValue("@IdEntidadFinanciera", IdEntidadFinanciera);
                comando.Parameters.AddWithValue("@Idcaja", caja);
                comando.Parameters.AddWithValue("@CodigoBarras", CodigoBarras);


                // Abrir la conexión y ejecutar la consulta
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();

                MessageBox.Show("La información de la caja se ha almacenado correctamente.");



            

        }

        private void button2_Click(object sender, EventArgs e)
        {

            FormularioCaja form2 = new FormularioCaja();
            form2.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {


            FormularioCliente form3 = new FormularioCliente();
            form3.Show();
            this.Hide();
        }
    }
}
