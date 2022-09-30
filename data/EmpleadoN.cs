using RegistroEmpleados.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RegistroEmpleados.data
{
    class EmpleadoN
    {
        public static bool guardar(Empleado e)
        {
            try { 

            DbConnection c = new DbConnection();
            String sql = "INSERT INTO tb_empleados VALUES('"+e.Documento+"','"+e.Nombres+"','"+e.Apellidos+"',"+e.Edad+ ",'"+e.Direccion+ "','"+e.Fecha_nacimiento+"')";
            SqlCommand comando = new SqlCommand(sql,c.conectar());
            int cantidad = comando.ExecuteNonQuery();
            if (cantidad == 1)
                {
                    c.desconectar();
                    return true;
                }
                else
                {
                    c.desconectar();
                    return false;
                }

            } 
            catch (Exception ex)
            {
                return false;
            }
        }
        public static DataTable traerDatos()
        {
            try
            {

                DbConnection c = new DbConnection();
                String sql = "SELECT * From tb_empleados";
                SqlCommand comando = new SqlCommand(sql, c.conectar());

                SqlDataReader datos = comando.ExecuteReader(CommandBehavior.CloseConnection);
                DataTable dt = new DataTable();
                dt.Load(datos);
                return dt;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static Empleado consultar(string documento)
        {
            try
            {

                DbConnection c = new DbConnection();
                String sql = "SELECT * From tb_empleados WHERE documento = '"+documento+"' ";
                SqlCommand comando = new SqlCommand(sql, c.conectar());
                SqlDataReader datos = comando.ExecuteReader();
                Empleado em = new Empleado();
                if (datos.Read())
                {
                    em.Documento = datos["documento"].ToString();
                    em.Nombres = datos["nombres"].ToString();
                    em.Apellidos = datos["apellidos"].ToString();
                    em.Edad = Convert.ToInt32(datos["edad"].ToString());
                    em.Direccion = datos["direccion"].ToString();
                    em.Fecha_nacimiento = datos["fecha_nacimiento"].ToString();
                    c.desconectar();
                    return em;
                }
                else
                {
                    c.desconectar();
                    return null;
                }


            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static bool actualizar(Empleado e)
        {
            try
            {

                DbConnection c = new DbConnection();
                String sql = "UPDATE tb_empleados SET nombres= '" + e.Nombres + "', apellidos = '" + e.Apellidos + "', edad= " + e.Edad + ", direccion = '" + e.Direccion + "',fecha_nacimiento= '" + e.Fecha_nacimiento + "' WHERE documento= '" + e.Documento + "'";                              
                SqlCommand comando = new SqlCommand(sql, c.conectar());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    c.desconectar();
                    return true;
                }
                else
                {
                    c.desconectar();
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }



        }

        public static bool eliminar(string documento)
        {
            try
            {

                DbConnection c = new DbConnection();
                String sql = "DELETE tb_empleados  WHERE documento= '" +documento+ "'";
                SqlCommand comando = new SqlCommand(sql, c.conectar());
                int cantidad = comando.ExecuteNonQuery();
                if (cantidad == 1)
                {
                    c.desconectar();
                    return true;
                }
                else
                {
                    c.desconectar();
                    return false;
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
