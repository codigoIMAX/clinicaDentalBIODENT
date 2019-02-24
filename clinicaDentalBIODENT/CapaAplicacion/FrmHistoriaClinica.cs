using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaAplicacion
{
    public partial class FrmHistoriaClinica : Form
    {
        public FrmHistoriaClinica()
        {
            InitializeComponent();
        }

        private void rdbTSi_CheckedChanged(object sender, EventArgs e)
        {
            txtMotivo.Enabled = true;
        }

        private void rdbMSi_CheckedChanged(object sender, EventArgs e)
        {
            txtMedicamento.Enabled = true;
        }

        private void rdbTNo_CheckedChanged(object sender, EventArgs e)
        {
            txtMotivo.Enabled = false;
        }

        private void rdbMNo_CheckedChanged(object sender, EventArgs e)
        {
            txtMedicamento.Enabled = false;
        }

        private void chbxBebidasAlcoholicas_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxBebidasAlcoholicas.Checked)
                txtFrecuencia.Enabled = true;
            else
                txtFrecuencia.Enabled = false;
        }

        private void chbxFuma_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxFuma.Checked)
                txtCantidad.Enabled = true;
            else
                txtCantidad.Enabled = false;
        }
    }
}
