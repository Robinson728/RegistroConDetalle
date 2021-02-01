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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            IdnumericUpDown1.Value = 0;
            txt_alias.Text = string.Empty;
            txt_email.Text = string.Empty;
            txt_nombre.Text = string.Empty;
            txt_clave.Text = string.Empty;
            comboBox1.Text = string.Empty;
            txt_confirmar.Text = string.Empty;
            txt_costohora.Text = string.Empty;
            numericUpDown1.Value = 0;
            dateTimePicker1.Value = DateTime.Now;
            errorProvider1.Clear();
        }

        private void LlenaCampo(Persona personas)
        {
            
            IdnumericUpDown1.Value = personas.UsuarioId;
            txt_nombre.Text = personas.Nombre;
            txt_alias.Text = personas.Alias;
            txt_email.Text = personas.Email;
            txt_clave.Text = personas.Clave;
            comboBox1.Text = personas.Rol;
            txt_confirmar.Text = personas.ConfirmarClave;
            txt_costohora.Text = personas.Costo;
            numericUpDown1.Value = personas.RolId;
            dateTimePicker1.Value = personas.FechaIngreso;
            checkBox1.Checked = personas.Activo;
        }

        private Persona LlenaClase()
        {
            Persona personas = new Persona();
            personas.UsuarioId = (int)IdnumericUpDown1.Value;
            personas.Nombre = txt_nombre.Text;
            personas.Email = txt_email.Text;
            personas.Alias = txt_alias.Text;
            personas.Clave = txt_clave.Text;
            personas.ConfirmarClave = txt_confirmar.Text;
            personas.Costo = txt_costohora.Text;
            personas.Rol = comboBox1.Text;
            personas.RolId = (int)numericUpDown1.Value;
            personas.FechaIngreso = dateTimePicker1.Value;
            personas.Activo = checkBox1.Checked;

            return personas;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Persona personas = PersonaBLL.Buscar((int)IdnumericUpDown1.Value);

            return (personas != null);
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider1.Clear();
            string cadena = "";
            string cadena2 = "";

            cadena = txt_clave.Text;
            cadena2 = txt_confirmar.Text;

            if(txt_alias.Text == string.Empty)
            {
                errorProvider1.SetError(txt_alias, "El campo nombre no puede estar vacio");
                txt_alias.Focus();
                paso = false;
            }
            else if (txt_nombre.Text == string.Empty)
            {
                errorProvider1.SetError(txt_nombre, "El campo Alias no puede estar vacio");
                txt_nombre.Focus();
                paso = false;
            }
            else if (txt_clave.Text == string.Empty)
            {
                errorProvider1.SetError(txt_clave, "El campo Email no puede estar vacio");
                txt_clave.Focus();
                paso = false;
            }
            else if (txt_confirmar.Text == string.Empty)
            {
                errorProvider1.SetError(txt_confirmar, "El campo Alias no puede estar vacio");
                txt_confirmar.Focus();
                paso = false;
            }
            else if (txt_email.Text == string.Empty)
            {
                errorProvider1.SetError(txt_email, "El campo Alias no puede estar vacio");
                txt_email.Focus();
                paso = false;
            }
            else if (txt_costohora.Text == string.Empty)
            {
                errorProvider1.SetError(txt_costohora, "El campo Alias no puede estar vacio");
                txt_costohora.Focus();
                paso = false;
            }
            else if(string.Equals(cadena, cadena2) == true)
            {
                paso = true;
            }
            else
            {
                errorProvider1.SetError(txt_confirmar, "La clave es distinta");
                txt_confirmar.Focus();
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
            int.TryParse(IdnumericUpDown1.Text, out id);

            Limpiar();

            if (PersonaBLL.Eliminar(id))
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                errorProvider1.SetError(IdnumericUpDown1, "Id no existente");
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
            int.TryParse(IdnumericUpDown1.Text, out id);

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

        private void button1_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txt_confirmar_TextChanged(object sender, EventArgs e)
        {
            txt_confirmar.PasswordChar = '*';
        }

        private void txt_costohora_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txt_clave_TextChanged(object sender, EventArgs e)
        {
            txt_clave.PasswordChar = '*';
        }
    }
}
