using System;
using System.Windows.Forms;
using Encuesta.Logica.Logica;

namespace ControlAsistenciaApp.forms
{
    public partial class frmCalificarTardanzas : Form
    {
        public frmCalificarTardanzas()
        {
            InitializeComponent();
        }

        private void btn_calcular_Click(object sender, EventArgs e)
        {
            var reporteTardanza = new ReporteTardanza(txt_desde.Value, txt_hasta.Value);
            var response = reporteTardanza.generateDocument(Convert.ToInt32(txt_minuto.Text));
            MessageBox.Show(string.Format("{0} {1}", response.ToString(), "documento (s) creados con exito"));

        }

        private void frmCalificarTardanzas_Load(object sender, EventArgs e)
        {

        }
    }
}
