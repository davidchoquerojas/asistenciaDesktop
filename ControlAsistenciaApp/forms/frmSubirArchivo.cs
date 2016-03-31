using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Encuesta.Logica.Logica;

namespace EncuestaApp.forms
{
    public partial class frmSubirArchivo : Form
    {
        public frmSubirArchivo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Seleccione el archivo";
            dialog.Filter = "Excel File|*.xlsx";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var carga = new CargaLogica(dialog.FileName);
                carga.readFile();
                dataGridView1.DataSource = carga.data;

                MessageBox.Show(string.Format("{0} {1} {2}", carga.totalSave, " registro (s) creados correctamente ",carga.existeDatosDB > 0?carga.messsage:""));
            }
        }
    }
}
