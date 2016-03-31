using Encuesta.Logica.Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlAsistenciaApp.forms
{
    public partial class frmConsultaData : Form
    {
        public frmConsultaData()
        {
            InitializeComponent();
        }

        private void btn_consulta_Click(object sender, EventArgs e)
        {
            var listCarga = new CargaConsulta(txt_desde.Value, txt_hasta.Value);
            dgv_data.DataSource = listCarga.listAsistencia;
        }
    }
}
