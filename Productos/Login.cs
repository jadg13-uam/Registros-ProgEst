using Productos.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Productos
{
    public partial class Login : Form
    {
        UsuarioDao users = new UsuarioDao();
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(users.Validar(tbUsuario.Text, tbPassword.Text)) { 
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Credenciales invalida", "Advertencia", MessageBoxButtons.OK , MessageBoxIcon.Warning );
            }
        }
    }
}
