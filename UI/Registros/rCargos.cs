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

namespace RegistroUsuarios.UI.Registros
{
    public partial class DescripcionrCargos : Form
    {
        public DescripcionrCargos()
        {
            InitializeComponent();
        }

        private Cargos LlenaClase()
        {
            Cargos cargos = new Cargos();
            cargos.Id = Convert.ToInt32(IdnumericUpDown.Value);
            cargos.Descripcion = DescripcionTextBox.Text;

            return cargos;
        }

        public bool Validar(int error)
        {
            bool paso = false;

            if (error == 1 && IdnumericUpDown.Value == 0)
            {
                errorProvider.SetError(IdnumericUpDown, "Llenar ID");
                paso = true;
            }
            if (error == 2 && string.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                errorProvider.SetError(DescripcionTextBox, "Favor LLenar");
                paso = true;
            }

            return paso;
        }



        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdnumericUpDown.Value);
            Usuarios usuarios = BLL.UsuarioBLL.Buscar(id);



            if (usuarios != null)
            {
                IdnumericUpDown.Value = usuarios.UsuarioId;
                DescripcionTextBox.Text = usuarios.Nombres;

            }
            else
            {
                MessageBox.Show("No se encontro", "Intente Buscar de nuevo",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            DescripcionTextBox.Clear();
            
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
                int id = Convert.ToInt32(IdnumericUpDown.Value);

                if (BLL.UsuarioBLL.Eliminar(id))
                {
                    MessageBox.Show("Eliminado", "Bien hecho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IdnumericUpDown.Value = 0;
                    DescripcionTextBox.Clear();
                    errorProvider.Clear();
                }
                else
                {
                    MessageBox.Show("No se puede Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
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
                Cargos cargo = LlenaClase();

                bool paso = false;


                if (IdnumericUpDown.Value == 0)
                {
                    paso = BLL.CargoBLL.Guardar(cargo);

                }
                else
                {
                    paso = BLL.CargoBLL.Modificar(LlenaClase());
                }
                if (paso)
                {
                    MessageBox.Show("Guardado!!", "Se Guardo Correctamente",
                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IdnumericUpDown.Value = 0;
                    DescripcionTextBox.Clear();
                    errorProvider.Clear();
                }
                else
                {
                    MessageBox.Show("No se guardo!!", "Intente Guardar de nuevo",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }
    }
}
