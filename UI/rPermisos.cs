using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistroDetalle.BLL;
using RegistroDetalle.Entidades;

namespace RegistroDetalle.UI
{
    public partial class rPermisos : Form
    {
        public rPermisos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            PermisoTextBox.Clear();
            ErrorProvider.Clear();
        }

        private void LlenaCampo(Permisos permiso)
        {
            IdNumericUpDown.Value = permiso.PermisoId;
            PermisoTextBox.Text = permiso.Permiso;
        }

        private Permisos LlenaClase()
        {
            Permisos permiso = new Permisos();
            permiso.PermisoId = (int)IdNumericUpDown.Value;
            permiso.Permiso = PermisoTextBox.Text;

            return permiso;
        }
        /*private bool ExisteEnLaBaseDeDatos()
        {
            Permisos permiso = PermisosBLL.Buscar((int)IdNumericUpDown.Value);

            return (permiso != null);
        }

        private bool Validar()
        {
            bool paso = true;
            ErrorProvider.Clear();

            if (PermisoTextBox.Text == string.Empty)
            {
                ErrorProvider.SetError(PermisoTextBox, "El campo Permiso no puede estar vacío");
                PermisoTextBox.Focus();
                paso = false;
            }
            if (PermisosBLL.ExistePermiso(PermisoTextBox.Text, (int)IdNumericUpDown.Value))
            {
                ErrorProvider.SetError(PermisoTextBox, "Este Permiso ya existe");
                PermisoTextBox.Focus();
                paso = false;
            }

            return paso;
        }*/

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Permisos permiso = new Permisos();
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            permiso = PermisosBLL.Buscar(id);

            if (permiso != null)
            {
                LlenaCampo(permiso);
            }
            else
            {
                MessageBox.Show("Permiso no encontrado", "Id no existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            /*Permisos permiso;
            bool paso = false;

            if (!Validar())
                return;

            permiso = LlenaClase();

            if (IdNumericUpDown.Value == 0)
                paso = PermisosBLL.Guardar(permiso);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar", "Modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                paso = PermisosBLL.Modificar(permiso);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No fue posible guardar!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
           /* ErrorProvider.Clear();
            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            if (PermisosBLL.Eliminar(id))
                MessageBox.Show("Eliminado Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                ErrorProvider.SetError(IdNumericUpDown, "Id no existe");*/
        }
    }
}
