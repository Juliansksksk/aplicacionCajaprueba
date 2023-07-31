using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;



namespace aplicacionCaja
{


    public partial class FormularioCliente : Form
    {

        Class1.Cliente clientess = new Class1.Cliente();
        public FormularioCliente()
        {
            InitializeComponent();
           

            List<string> listaElementos = new List<string>();
            listaElementos.Add("Cedula de ciudadania");
            listaElementos.Add("Cedula de extranjeria");
            listaElementos.Add("Pasaporte");

            listBox1.DataSource = listaElementos;

            SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog=GestionDocumentaldos;Integrated Security=True;");

            string query = "SELECT TipologiaDocumental FROM EntidadesFinancieras";
            SqlCommand command = new SqlCommand(query, conexion);
            conexion.Open();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                listBox2.Items.Add(reader["TipologiaDocumental"].ToString());
            }

            reader.Close();
            conexion.Close();

            

            //List<string> listaElementos2 = new List<string>();
            //listaElementos2.Add("Formulario de Solicitud");
            //listaElementos2.Add("Cédula de Ciudadanía");
            //listaElementos2.Add("Declaración de Renta");

            //listBox2.DataSource = listaElementos2;

            //SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog=GestionDocumentaldos;Integrated Security=True;");

            //string query = "SELECT NombreEntidad FROM EntidadesFinancieras";
            //SqlCommand command = new SqlCommand(query, conexion);
            //conexion.Open();
            //SqlDataReader reader = command.ExecuteReader();
            //while (reader.Read())
            //{
            //    listBox3.Items.Add(reader["NombreEntidad"].ToString());
            //}

            //reader.Close();
            //conexion.Close();





        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //try
            //{


              
            string idcarpeta = textBox1.Text;
            string TipoIdentificacion = listBox1.SelectedItem.ToString();
                int NumeroIdentificacion = int.Parse(textBox2.Text);
                string Nombres = textBox3.Text;
                string Apellidos = textBox4.Text;
                string Direccion = textBox5.Text;
                int telefonoFijo = int.Parse(textBox6.Text);
                int TelefonoCelular = (int)Int64.Parse(textBox7.Text);
                

               

                if (TipoIdentificacion == "Cedula de ciudadania")
                {
                    TipoIdentificacion = "01";
                }
                else if (TipoIdentificacion == "Cedula de extranjeria")
                {
                    TipoIdentificacion = "02";
                }
                else if (TipoIdentificacion == "Pasaporte")
                {
                    TipoIdentificacion = "03";
                }


                int IdCliente = 0;

                string TipoDocumento = listBox2.SelectedItem.ToString();

                string Rutaimagen = "url";

                // Crear la conexión a la base de datos
                SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog=GestionDocumentaldos;Integrated Security=True;");

                // Crear la consulta SQL para insertar la información de la caja
                string consulta = "INSERT INTO Clientes (TipoIdentificacion, NumeroIdentificacion, Nombres, Apellidos, Direccion, TelefonoFijo, TelefonoCelular) VALUES (@TipoIdentificacion, @NumeroIdentificacion, @Nombres, @Apellidos,@Direccion, @TelefonoFijo, @TelefonoCelular)";


                // Crear el comando SQL y agregar los parámetros
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@TipoIdentificacion", TipoIdentificacion);
                comando.Parameters.AddWithValue("@NumeroIdentificacion", NumeroIdentificacion);
                comando.Parameters.AddWithValue("@Nombres", Nombres);
                comando.Parameters.AddWithValue("@Apellidos", Apellidos);
                comando.Parameters.AddWithValue("@Direccion", Direccion);
                comando.Parameters.AddWithValue("@TelefonoFijo", telefonoFijo);
                comando.Parameters.AddWithValue("@TelefonoCelular", TelefonoCelular);

            // Abrir la conexión y ejecutar la consulta
            conexion.Open();
            comando.ExecuteNonQuery();
            conexion.Close();

               


            string query2 = "SELECT IdCliente FROM Clientes ";
            SqlCommand command2 = new SqlCommand(query2, conexion);
            conexion.Open();
            SqlDataReader reader2 = command2.ExecuteReader();
            while (reader2.Read())
            {
                clientess.IdCliente = reader2.GetInt32(0);
            }

            reader2.Close();
            conexion.Close();


            string consulta2 = "INSERT INTO Folios (Idcarpeta, TipoDocumento, Imagen) VALUES (@Idcarpeta, @TipoDocumento, @Imagen)";
            SqlCommand comando2 = new SqlCommand(consulta2, conexion);
            comando2.Parameters.AddWithValue("@Idcarpeta", idcarpeta);
            comando2.Parameters.AddWithValue("@TipoDocumento", TipoDocumento);
            comando2.Parameters.AddWithValue("@Imagen", Rutaimagen);

            // Abrir la conexión y ejecutar la consulta
            conexion.Open();
            
            comando2.ExecuteNonQuery();
            conexion.Close();
            MessageBox.Show("La información de la caja se ha almacenado correctamente.");




            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("La información de la caja no se pudo almacenar .");
            //}


        }

        private void button2_Click(object sender, EventArgs e)
        {
            FormularioCaja form3 = new FormularioCaja();
            form3.Show();
            this.Hide();
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormularioCarpeta form2 = new FormularioCarpeta();
            form2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e) { }
       
    }
}
