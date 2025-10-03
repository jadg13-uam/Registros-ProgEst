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

namespace Productos.Formularios
{
    public partial class FrmArreglo : Form
    {
        public FrmArreglo()
        {
            InitializeComponent();
        }

        private void tbEdad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                agregar();
            }
        }

        public void agregar()
        {
            int edad=0;
            try
            {
                edad = int.Parse(tbEdad.Text);
                EdadDao.edades[EdadDao.pos++] = edad;
            }
            catch(FormatException)
            {
                MessageBox.Show("No se permiten letras, solo números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("No se admiten más elementos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }finally
            {
                Utileria();
            }   
        }

        public void Utileria()
        {
            tbEdad.Clear();
            tbEdad.Focus();
            mostrarEdades();
        }

        public void mostrarEdades()
        {
            lbEdades.DataSource = null;
            lbEdades.DataSource = EdadDao.edades;
            lbEdades.Refresh();
        }

        private void FrmArreglo_Load(object sender, EventArgs e)
        {
            mostrarEdades();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            agregar();
        }

        private void tbEdad_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }

}
