using RegistroUsuarios.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistroUsuarios.UI.Registros
{
    public partial class Registros : Form
    {
        public Registros()
        {
            InitializeComponent();
        }

        private Usuarios LlenaClase()
        {
            Usuarios usuarios = new Usuarios();
            usuarios.UsuarioId = Convert.ToInt32(UsuarioIDnumericUpDown.Value);
            usuarios.Nombres = NombrestextBox.Text;
            usuarios.Email = EmailstextBox.Text;
            usuarios.NivelUsuario = NivelUsuariotextBox.Text;
            usuarios.Usuario = UsuariotextBox.Text;
            usuarios.Clave = ClavetextBox.Text;
            usuarios.FechaIngreso = DateTime.Now;

            return usuarios;
        }

        /// <summary>
        /// Aqui Validamos los campos 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public bool Validar(int error)
        {
            bool paso = false;

            if (error == 1 && UsuarioIDnumericUpDown.Value == 0)
            {
                errorProvider.SetError(UsuarioIDnumericUpDown, "Llenar ID");
                paso = true;
            }
            if (error == 2 && string.IsNullOrEmpty(NombrestextBox.Text))
            {
                errorProvider.SetError(NombrestextBox, "Favor LLenar");
                paso = true;
            }
            if (error == 3 && string.IsNullOrEmpty(EmailstextBox.Text))
            {
                errorProvider.SetError(EmailstextBox, "Favor LLenar");
                paso = true;
            }
            if (error == 4 && string.IsNullOrEmpty(NivelUsuariotextBox.Text))
            {
                errorProvider.SetError(NivelUsuariotextBox, "Favor Llenar");
                paso = true;
            }
            if (error == 4 && string.IsNullOrEmpty(UsuariotextBox.Text))
            {
                errorProvider.SetError(UsuariotextBox, "Favor Llenar");
                paso = true;
            }
            if (error == 4 && string.IsNullOrEmpty(ClavetextBox.Text))
            {
                errorProvider.SetError(ClavetextBox, "Favor Llenar");
                paso = true;
            }


            return paso;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            UsuarioIDnumericUpDown.Value = 0;
            NombrestextBox.Clear();
            EmailstextBox.Clear();
            NivelUsuariotextBox.Clear();
            UsuariotextBox.Clear();
            ClavetextBox.Clear();
            FechaIngresodateTimePicker.Value = DateTime.Now;
            errorProvider.Clear();

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(2))
            {
                MessageBox.Show("Llenar campos", "Llene los campos",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                usuario articulo = LlenaClase();

                bool paso = false;


                if (UsuarioIDnumericUpDown.Value == 0)
                {
                    paso = BLL.UsuarioBLL.Guardar(articulo);

                }
                else
                {
                    paso = BLL.UsuarioBLL.Modificar(LlenaClase());
                }
                if (paso)
                {
                    MessageBox.Show("Guardado!!", "Se Guardo Correctamente",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UsuarioIDnumericUpDown.Value = 0;
                    NombrestextBox.Clear();
                    EmailstextBox.Clear();
                    NivelUsuariotextBox.Clear();
                    UsuariotextBox.Clear();
                    ClavetextBox.Clear();
                    FechaIngresodateTimePicker.Value = DateTime.Now;
                    errorProvider.Clear();
                }
                else
                {
                    MessageBox.Show("No se guardo!!", "Intente Guardar de nuevo",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (Validar(1))
            {
                MessageBox.Show("El TipoID esta vacio", "Llene Campo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                int id = Convert.ToInt32(UsuarioIDnumericUpDown.Value);

                if (BLL.UsuarioBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado", "Bien hecho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UsuarioIDnumericUpDown.Value = 0;
                    NombrestextBox.Clear();
                    EmailstextBox.Clear();
                    NivelUsuariotextBox.Clear();
                    UsuariotextBox.Clear();
                    ClavetextBox.Clear();
                    FechaIngresodateTimePicker.Value = DateTime.Now;
                    errorProvider.Clear();
                }
                else
                {
                    MessageBox.Show("No se puede Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(UsuarioIDnumericUpDown.Value);
            usuario usuarios = BLL.UsuarioBLL.Buscar(id);



            if (usuarios != null)
            {
                UsuarioIDnumericUpDown.Value = usuarios.UsuarioId;
                NombrestextBox.Text = usuarios.Nombres;
                EmailstextBox.Text = usuarios.Email;
                NivelUsuariotextBox.Text = usuarios.NivelUsuario;
                UsuariotextBox.Text = usuarios.Usuario;
                ClavetextBox.Text = usuarios.Clave;
                FechaIngresodateTimePicker.Value = usuarios.FechaIngreso;

            }
            else
            {
                MessageBox.Show("No se encontro", "Intente Buscar de nuevo",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void NombrestextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegistroDeUsuarios_Load(object sender, EventArgs e)
        {

        }

        private void FechaIngresodateTimePicker_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
