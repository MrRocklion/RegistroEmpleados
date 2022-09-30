using MaterialSkin;
using MaterialSkin.Controls;
using RegistroEmpleados.data;
using RegistroEmpleados.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroEmpleados
{
    public partial class Form1 : MaterialForm
    {
        readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public Form1()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = true;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo500, MaterialSkin.Primary.Indigo700, MaterialSkin.Primary.Indigo100, MaterialSkin.Accent.Pink200, MaterialSkin.TextShade.WHITE);
            CargarGrid();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Debe Llenar todos Los campos");
            }
            else if (txtApellidos.Text.Trim() == "")
            {
                MessageBox.Show("Debe Llenar todos Los campos");
            }
            else if (txtNombres.Text.Trim() == "")
            {
                MessageBox.Show("Debe Llenar todos Los campos");
            }
            else if (txtEdad.Text.Trim() == "")
            {
                MessageBox.Show("Debe Llenar todos Los campos");
            }
            else if (dateFechaNacimiento.Text.Trim() == "")
            {
                MessageBox.Show("Debe Llenar todos Los campos");
            }
            else if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Debe Llenar todos Los campos");
            }
            else
            {
                try {                
                    Empleado em = new Empleado();
                    em.Documento = txtDocumento.Text.Trim().ToUpper();
                    em.Nombres = txtNombres.Text.Trim().ToUpper();
                    em.Apellidos = txtApellidos.Text.Trim().ToUpper();
                    em.Edad = Convert.ToInt32(txtEdad.Text.Trim().ToUpper());
                    em.Direccion = txtDireccion.Text.Trim().ToUpper();
                    em.Fecha_nacimiento = dateFechaNacimiento.Value.Year+"-"+dateFechaNacimiento.Value.Month+"-"+ dateFechaNacimiento.Value.Day;
                    if (EmpleadoN.guardar(em))
                    {
                        CargarGrid();
                        MessageBox.Show("Empleado Agregado con éxito!", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Error al agreagar empleado", "Ventana De Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }catch(Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex, "Ventana De Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void CargarGrid()
        {
            DataTable datos = EmpleadoN.traerDatos();
            if(datos == null)
            {
                MessageBox.Show("ERROR: Error al cargar los datos", "Ventana De Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataTableEmpleados.DataSource = datos.DefaultView;
            }
        }
        private void LimpiarCampos() {
            txtDocumento.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtDireccion.Text = "";
            dateFechaNacimiento.Text = "";
            consultado = false;

        
        }
        bool consultado = false;
        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Documento Incorrecto");
            }
            else
            {
              Empleado empleado =  EmpleadoN.consultar(txtDocumento.Text.Trim());
                if(empleado == null)
                {
                    MessageBox.Show("No existe documento");
                }
                else{
                    txtDocumento.Text = empleado.Documento;
                    txtNombres.Text = empleado.Nombres;
                    txtApellidos.Text = empleado.Apellidos;
                    txtEdad.Text = empleado.Edad.ToString();
                    txtDireccion.Text = empleado.Direccion;
                    dateFechaNacimiento.Text = empleado.Fecha_nacimiento;
                    consultado = true;

                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            if (consultado == false)
            {
                MessageBox.Show("Debe Consultar Primer");
            }
            else if (txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Debe Llenar todos Los campos");
            }
            else if (txtApellidos.Text.Trim() == "")
            {
                MessageBox.Show("Debe Llenar todos Los campos");
            }
            else if (txtNombres.Text.Trim() == "")
            {
                MessageBox.Show("Debe Llenar todos Los campos");
            }
            else if (txtEdad.Text.Trim() == "")
            {
                MessageBox.Show("Debe Llenar todos Los campos");
            }
            else if (dateFechaNacimiento.Text.Trim() == "")
            {
                MessageBox.Show("Debe Llenar todos Los campos");
            }
            else if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Debe Llenar todos Los campos");
            }
            else
            {
                try
                {
                    Empleado em = new Empleado();
                    em.Documento = txtDocumento.Text.Trim().ToUpper();
                    em.Nombres = txtNombres.Text.Trim().ToUpper();
                    em.Apellidos = txtApellidos.Text.Trim().ToUpper();
                    em.Edad = Convert.ToInt32(txtEdad.Text.Trim().ToUpper());
                    em.Direccion = txtDireccion.Text.Trim().ToUpper();
                    em.Fecha_nacimiento = dateFechaNacimiento.Value.Year + "-" + dateFechaNacimiento.Value.Month + "-" + dateFechaNacimiento.Value.Day;
                    if (EmpleadoN.actualizar(em))
                    {
                        CargarGrid();
                        MessageBox.Show("Empleado actualizado con éxito!", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Error al actualizar empleado ", "Ventana De Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex, "Ventana De Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (consultado == false)
            {
                MessageBox.Show("Debe Consultar Primer");
            }
            else if (txtDocumento.Text.Trim() == "")
            {
                MessageBox.Show("Debe Llenar todos Los campos");
            }
            else
            {
                try
                {
                    if (EmpleadoN.eliminar(txtDocumento.Text.Trim()))
                    {
                        CargarGrid();
                        MessageBox.Show("Empleado eliminado con éxito!", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Error al eliminar empleado ", "Ventana De Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: " + ex, "Ventana De Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
