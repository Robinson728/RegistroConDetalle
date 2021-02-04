﻿using System;
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

        private void LlenaCampo(Usuario usuarios)
        {
            
            IdNumericUpDown.Value = usuarios.UsuarioId;
            NombreTextBox.Text = usuarios.Nombre;
            AliasTextBox.Text = usuarios.Alias;
            EmailTextBox.Text = usuarios.Email;
            ClaveTextBox.Text = usuarios.Clave;
            RolComboBox.Text = usuarios.Rol;
            ConfirmarTextBox.Text = usuarios.ConfirmarClave;
            numericUpDown1.Value = usuarios.RolId;
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
            usuarios.RolId = (int)numericUpDown1.Value;
            usuarios.FechaIngreso = FechaDateTimePicker.Value;
            usuarios.Activo = ActivoCheckBox.Checked;

            return usuarios;
        }
        private bool ExisteEnLaBaseDeDatos()
        {
            Usuario usuarios = UsuarioBLL.Buscar((int)IdNumericUpDown.Value);

            return (usuarios != null);
        }

        private bool Validar()
        {
            bool paso = true;
            errorProvider1.Clear();

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
            else if(string.Equals(ClaveTextBox.Text, ConfirmarTextBox.Text) != true)
            {
                errorProvider1.SetError(ConfirmarTextBox, "La clave es distinta");
                ConfirmarTextBox.Focus();
                paso = false;
            }
            else if(UsuarioBLL.ExisteAlias(AliasTextBox.Text))
            {
                errorProvider1.SetError(AliasTextBox, "El Campo alias ya existe");
                AliasTextBox.Focus();
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
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                errorProvider1.SetError(IdNumericUpDown, "Id no existente");
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Usuario usuarios;
            bool paso = false;

            if (!Validar())
                return;

            usuarios = LlenaClase();

            if ((ExisteEnLaBaseDeDatos()))
            {
                paso = UsuarioBLL.Guardar(usuarios);
                MessageBox.Show("Modificado!!", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                paso = UsuarioBLL.Guardar(usuarios);

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
                MessageBox.Show("Persona no encontrada", "Id Incorrecto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
