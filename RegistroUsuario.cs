using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistroUsuarios.Entidades;
using RegistroUsuarios.BLL;
using RegistroUsuarios.DAL;

namespace RegistroUsuarios
{
    public partial class RegistroUsuarios : Form
    {
        public RegistroUsuarios()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            AliasTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            NombreTextBox.Text = string.Empty;
            ClaveTextBox.Text = string.Empty;
            RolComboBox.Text = string.Empty;
            ConfirmarTextBox.Text = string.Empty;
            numericUpDown1.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            errorProvider1.Clear();
        }

        private void LlenaCampo(Persona personas)
        {
            
            IdNumericUpDown.Value = personas.UsuarioId;
            NombreTextBox.Text = personas.Nombre;
            AliasTextBox.Text = personas.Alias;
            EmailTextBox.Text = personas.Email;
            ClaveTextBox.Text = personas.Clave;
            RolComboBox.Text = personas.Rol;
            ConfirmarTextBox.Text = personas.ConfirmarClave;
            numericUpDown1.Value = personas.RolId;
            FechaDateTimePicker.Value = personas.FechaIngreso;
            ActivoCheckBox.Checked = personas.Activo;
        }

        private Persona LlenaClase()
        {
            Persona personas = new Persona();
            personas.UsuarioId = (int)IdNumericUpDown.Value;
            personas.Nombre = NombreTextBox.Text;
            personas.Email = EmailTextBox.Text;
            personas.Alias = AliasTextBox.Text;
            personas.Clave = ClaveTextBox.Text;
            personas.ConfirmarClave = ConfirmarTextBox.Text;
            personas.Rol = RolComboBox.Text;
            personas.RolId = (int)numericUpDown1.Value;
            personas.FechaIngreso = FechaDateTimePicker.Value;
            personas.Activo = ActivoCheckBox.Checked;

            return personas;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Persona personas = PersonaBLL.Buscar((int)IdNumericUpDown.Value);

            return (personas != null);
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider1.Clear();
            string cadena = "";
            string cadena2 = "";

            cadena = ClaveTextBox.Text;
            cadena2 = ConfirmarTextBox.Text;

            if(AliasTextBox.Text == string.Empty)
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
            else if(string.Equals(cadena, cadena2) == true)
            {
                paso = true;
            }
            else
            {
                errorProvider1.SetError(ConfirmarTextBox, "La clave es distinta");
                ConfirmarTextBox.Focus();
                paso = false;
            }

            return paso;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_descripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            int id;
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            if (PersonaBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                errorProvider1.SetError(IdNumericUpDown, "Id no existente");
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            Persona personas;
            bool paso = false;

            if (!Validar())
                return;

            personas = LlenaClase();

            paso = PersonaBLL.Guardar(personas);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No fue posible guardar, Id en existencia", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            int id;
            Persona personas = new Persona();
            int.TryParse(IdNumericUpDown.Text, out id);

            Limpiar();

            personas = PersonaBLL.Buscar(id);

            if (personas != null)
            {
                LlenaCampo(personas);
            }
            else
            {
                MessageBox.Show("Persona no encontrada", "Id Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void ConfirmarTextBox_TextChanged(object sender, EventArgs e)
        {
            ConfirmarTextBox.PasswordChar = '*';
        }

        private void ActivoCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ClaveTextBox_TextChanged(object sender, EventArgs e)
        {
            ClaveTextBox.PasswordChar = '*';
        }

        private void IdNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void AliasTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void NombreTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void FechaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void EmailTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void RolComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
