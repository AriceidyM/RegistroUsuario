﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegistroUsuarios.UI.Registros;

namespace RegistroUsuarios
{
    public partial class MainForms : Form
    {
        public MainForms()
        {
            InitializeComponent();
        }

        private void RegistroDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Registros rUsuario = new Registros();
            rUsuario.Show();

        }
    }
}
