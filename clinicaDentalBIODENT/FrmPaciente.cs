using clinicaDentalBIODENT.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clinicaDentalBIODENT
{
    public partial class FrmPaciente : Form
    {
        Doctor doctor;
        Paciente paciente;
        public FrmPaciente()
        {
            InitializeComponent();
        }
        public void asignarDoctor(Object doctor)
        {
            this.doctor = (Doctor)doctor;
        }
        public void llenarDataGridView(DataTable tbl)
        {
            dgvPacientes.DataSource = tbl;
        }

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                
                if (dgvPacientes.SelectedRows.Count > 0)
                {
                    paciente = doctor.buscarPaciente(dgvPacientes.Rows[e.RowIndex].Cells[1].Value.ToString());
                    FrmPrincipal frmPrincipal = Owner as FrmPrincipal;
                    frmPrincipal.asignarPaciente(paciente);
                }
                else
                    MessageBox.Show("Por favor seleccione una fila", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmIngresarPaciente frmIngresarPaciente = new FrmIngresarPaciente();
            AddOwnedForm(frmIngresarPaciente);
            frmIngresarPaciente.asignarDoctor(this.doctor);
            frmIngresarPaciente.ShowDialog();
        }
    }
}
