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
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
            SqlConnection conexion = new SqlConnection("Data Source=localhost;Initial Catalog=GestionDocumentaldos;Integrated Security=True;");

            string query = "SELECT c.Nombres AS Cliente, COUNT(*) AS TotalCarpetas, c.IdCliente as IdCliente, I.TipoDocumento as TipologiaDocumental FROM Clientes c " +
 "INNER JOIN Carpetas f ON c.IDCliente = f.IDCliente " +
 "INNER JOIN Folios I ON f.IdCarpeta = I.IdCarpeta " +
 "GROUP BY c.Nombres,c.IdCliente,I.TipoDocumento";

            // Punto 5: Crear un objeto SqlCommand y asignar la consulta SQL a su propiedad CommandText
            SqlCommand cmd = new SqlCommand(query, conexion);

            // Punto 6: Crear un objeto DataTable para almacenar los resultados de la consulta
            DataTable dt = new DataTable();

            // Punto 6 (continuación): Crear un objeto SqlDataAdapter y utilizarlo para llenar el objeto DataTable con los datos de la consulta
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            // Punto 7: Asignar el objeto DataTable al DataSource del DataGridView para mostrar los datos en el control
            dataGridView1.DataSource = dt;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormularioCaja form3 = new FormularioCaja();
            form3.Show();
            this.Hide();
        }
    }
}
