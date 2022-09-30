using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
namespace RegistroEmpleados
{

    class DbConnection
    {
        public SqlConnection cnx;
        public DbConnection()
            {
            try
            {
                String conexion = ConfigurationManager.ConnectionStrings["RegistroEmpleados.Properties.Settings.empleado_dbConnectionString"].ConnectionString;
                cnx = new SqlConnection(conexion);
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR: " + ex, "Ventana De Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public SqlConnection conectar()
        {
            try
            {
            cnx.Open();
            return cnx;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR CONEXION: " + ex, "Ventana De Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public bool desconectar()
        {
            try
            {
            cnx.Close();
            return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR DESCONEXION: " + ex, "Ventana De Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

    }
}
