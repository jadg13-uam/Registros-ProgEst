using Productos.Dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
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
            try
            {
                if (int.TryParse(tbEdad.Text, out int edad) && edad > 0 && edad <= 120) EdadDao.edades[EdadDao.pos++] = edad;
                else MessageBox.Show("Solo se permiten numero enteros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } catch (IndexOutOfRangeException) {
                MessageBox.Show("No se puede agregr mas elementos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                Utileria();
            }
        }

        public void Utileria()
        {
            tbEdad.Clear();
            tbEdad.Focus();
            mostrarEdades();
            MostrarPromedio();
        }

        public void mostrarEdades()
        {
            lbEdades.DataSource = null;
            lbEdades.DataSource = EdadDao.edades;
            lbEdades.Refresh();
        }

        private void MostrarPromedio()
        {
            int suma = EdadDao.edades.Take(EdadDao.pos).Sum();
            double promedio = suma / EdadDao.pos;
            lblPromedio.Text = $"promedio: {promedio}";
        }
        private void FrmArreglo_Load(object sender, EventArgs e)
        {
            mostrarEdades();
        }
        
      
        private void tbEdad_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void lblPromedio_Click(object sender, EventArgs e)
        {

        }
    }

}
