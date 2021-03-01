using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistroDetalle.Entidades;
using RegistroDetalle.BLL;
using RegistroDetalle.DAL;

namespace RegistroDetalle.UI
{
    public partial class rUsuarios : Form
    {
        public rUsuarios()
        {
            InitializeComponent();
            RolComboBox.DataSource = RolesBLL.GetRoles();
            RolComboBox.DisplayMember = "Descripcion";
            RolComboBox.ValueMember = "RolId";
        }

        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            AliasTextBox.Clear();
            EmailTextBox.Clear();
            NombreTextBox.Clear();
            ClaveTextBox.Clear();
            ConfirmarTextBox.Clear();
            FechaDateTimePicker.Value = DateTime.Now;
            ActivoCheckBox.Checked = false;
            errorProvider1.Clear();
        }

        private void LlenaCampo(Usuario usuarios)
        {
            
            IdNumericUpDown.Value = usuarios.UsuarioId;
            NombreTextBox.Text = usuarios.Nombre;
            AliasTextBox.Text = usuarios.Alias;
            EmailTextBox.Text = usuarios.Email;
            ClaveTextBox.Text = usuarios.Clave;
            RolComboBox.Text = usuarios.Rol;
            ConfirmarTextBox.Text = usuarios.ConfirmarClave;
            FechaDateTimePicker.Value = usuarios.FechaIngreso;
            ActivoCheckBox.Checked = usuarios.Activo;
        }

        private Usuario LlenaClase()
        {
            Usuario usuarios = new Usuario();
            usuarios.UsuarioId = (int)IdNumericUpDown.Value;
            usuarios.Nombre = NombreTextBox.Text;
            usuarios.Email = EmailTextBox.Text;
            usuarios.Alias = AliasTextBox.Text;
            usuarios.Clave = ClaveTextBox.Text;
            usuarios.ConfirmarClave = ConfirmarTextBox.Text;
            usuarios.Rol = RolComboBox.Text;
            usuarios.FechaIngreso = FechaDateTimePicker.Value;
            usuarios.Activo = ActivoCheckBox.Checked;

            return usuarios;
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider1.Clear();

            if (AliasTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(AliasTextBox, "El campo nombre no puede estar vacio");
                AliasTextBox.Focus();
                paso = false;
            }
            else if (NombreTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(NombreTextBox, "El campo Alias no puede estar vacio");
                NombreTextBox.Focus();
                paso = false;
            }
            else if (ClaveTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(ClaveTextBox, "El campo Email no puede estar vacio");
                ClaveTextBox.Focus();
                paso = false;
            }
            else if (ConfirmarTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(ConfirmarTextBox, "El campo Alias no puede estar vacio");
                ConfirmarTextBox.Focus();
                paso = false;
            }
            else if (EmailTextBox.Text == string.Empty)
            {
                errorProvider1.SetError(EmailTextBox, "El campo Alias no puede estar vacio");
                EmailTextBox.Focus();
                paso = false;
            }
            else if (string.Equals(ClaveTextBox.Text, ConfirmarTextBox.Text) != true)
            {
                errorProvider1.SetError(ConfirmarTextBox, "La clave es distinta");
                ConfirmarTextBox.Focus();
                paso = false;
            }
            else if(UsuarioBLL.ExisteAlias(AliasTextBox.Text,(int)IdNumericUpDown.Value))
            {
                errorProvider1.SetError(AliasTextBox, "El Campo alias ya existe");
                AliasTextBox.Focus();
                paso = false;
            }
            else if (UsuarioBLL.ExisteRol(RolComboBox.Text, (int)IdNumericUpDown.Value)) 
            {
                errorProvider1.SetError(RolComboBox, "Este Rol ya existe");
                RolComboBox.Focus();
                paso = false;
            }
            return paso;
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            if (UsuarioBLL.Eliminar(id))
                MessageBox.Show("Transacción Exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                errorProvider1.SetError(IdNumericUpDown, "Id no existente");
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuario usuarios;

            if (!Validar())
                return;

            usuarios = LlenaClase();

            var paso = UsuarioBLL.Guardar(usuarios);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transacción Exitosa!!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Transacción Fallida!!", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            Usuario usuarios = new Usuario();
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            usuarios = UsuarioBLL.Buscar(id);

            if (usuarios != null)
            {
                LlenaCampo(usuarios);
            }
            else
            {
                MessageBox.Show("Transacción Fallida", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
