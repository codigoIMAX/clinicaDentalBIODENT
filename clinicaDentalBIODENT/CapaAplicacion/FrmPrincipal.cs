using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CapaNegocio;

namespace CapaAplicacion
{
    public partial class FrmPrincipal : Form
    {
        Doctor doctor;
        Paciente paciente;
        HistoriaClinica historiaClinica;
        public FrmPrincipal()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        public void asignarDoctor(Object doctor)
        {
            this.doctor = (Doctor)doctor;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnCerrar_MouseMove(object sender, MouseEventArgs e)
        {
            btnCerrar.BackColor = Color.FromArgb(0, 167, 141);
        }
        private void btnCerrar_MouseLeave(object sender, EventArgs e)
        {
            btnCerrar.BackColor = Color.FromArgb(0, 122, 204);
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void btnMinimizar_MouseMove(object sender, MouseEventArgs e)
        {
            btnMinimizar.BackColor = Color.FromArgb(0, 167, 141);
        }
        private void btnMinimizar_MouseLeave(object sender, EventArgs e)
        {
            btnMinimizar.BackColor = Color.FromArgb(0, 122, 204);
        }
        private void pnlBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            cpbReloj.Minimum = 0;
            cpbReloj.Maximum = 59;
        }
        private void tmrFechaHora_Tick(object sender, EventArgs e)
         {
            try
            {
                lblSegundos.Text = DateTime.Now.ToString("ss");
                cpbReloj.Value = Convert.ToInt32(DateTime.Now.ToString("ss"));
                lblHora.Text = DateTime.Now.ToString("HH:mm");
                lblFecha.Text = DateTime.Now.ToString("dddd, dd MMMM");
                lblAnio.Text = DateTime.Today.ToString("yyyy");
            }
            catch
            {

            }
        }
        private void btnPacientes_Click(object sender, EventArgs e)
        {
            btnHistoriaClinica.Visible = true;
            btnPlanTratamiento.Visible = true;
            btnTratamiento.Visible = true;
            btnSalir.Visible = true;
            FrmPaciente frmPaciente = new FrmPaciente();
            DataTable tbl = doctor.obtenerPacientes();
            frmPaciente.asignarDoctor(this.doctor);
            frmPaciente.llenarDataGridView(tbl);
            AddOwnedForm(frmPaciente);
            abrirFormHijo(frmPaciente);
        }
        private void ocultarElementos()
        {
            btnHistoriaClinica.Visible = false;
            btnPlanTratamiento.Visible = false;
            btnTratamiento.Visible = false;
            btnSalir.Visible = false;
            pnlHistoriaClinica.Visible = false;
            pnlPlanTratamiento.Visible = false;
            pnlTratamiento.Visible = false;
            pnlSalir.Visible = false;
        }
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            ocultarElementos();
        }
        private void btnHistoriaClinica_MouseMove(object sender, MouseEventArgs e)
        {
            pnlHistoriaClinica.Visible = true;
            pnlPlanTratamiento.Visible = false;
            pnlTratamiento.Visible = false;
            pnlSalir.Visible = false;
        }
        private void btnPlanTratamiento_MouseMove(object sender, MouseEventArgs e)
        {
            pnlHistoriaClinica.Visible = false;
            pnlPlanTratamiento.Visible = true;
            pnlTratamiento.Visible = false;
            pnlSalir.Visible = false;
        }
        private void btnTratamiento_MouseMove(object sender, MouseEventArgs e)
        {
            pnlHistoriaClinica.Visible = false;
            pnlPlanTratamiento.Visible = false;
            pnlTratamiento.Visible = true;
            pnlSalir.Visible = false;
        }
        private void btnSalir_MouseMove(object sender, MouseEventArgs e)
        {
            pnlHistoriaClinica.Visible = false;
            pnlPlanTratamiento.Visible = false;
            pnlTratamiento.Visible = false;
            pnlSalir.Visible = true;
        }
        public void abrirFormHijo(object frmHijo)
        {
            if (pnlContenedor.Controls.Count > 0)
                pnlContenedor.Controls.RemoveAt(0);
            Form fh = frmHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            pnlContenedor.Controls.Add(fh);
            pnlContenedor.Tag = fh;
            fh.Show();
        }
        public void asignarPaciente(Object paciente)
        {
            this.paciente = (Paciente)paciente;
        }
        public void asignarHistoriaClinica(Object historia)
        {
            this.historiaClinica = (HistoriaClinica)historia;
        }
        private void btnHistoriaClinica_Click(object sender, EventArgs e)
        {
            try
            {
                pnlHistoriaClinica.Visible = true;
                pnlPlanTratamiento.Visible = false;
                pnlTratamiento.Visible = false;
                pnlSalir.Visible = false;
                FrmHistoriaClinica frmHistoriaClinica = new FrmHistoriaClinica();
                frmHistoriaClinica.txtApellidos.Text = paciente.Apellidos;
                frmHistoriaClinica.txtNombres.Text = paciente.Nombres;
                if (historiaClinica.TratamientoMedicoActual != "")
                {
                    frmHistoriaClinica.txtMotivo.Text = historiaClinica.TratamientoMedicoActual;
                    frmHistoriaClinica.rdbTSi.Checked = true;
                    frmHistoriaClinica.txtMotivo.Enabled = true;
                }
                if (historiaClinica.TomaMedicamentoActual != "")
                {
                    frmHistoriaClinica.txtMedicamento.Text = historiaClinica.TomaMedicamentoActual;
                    frmHistoriaClinica.rdbMSi.Checked = true;
                    frmHistoriaClinica.txtMedicamento.Enabled = true;
                }
                frmHistoriaClinica.txtHObservaciones.Text = historiaClinica.Observaciones;
                if (historiaClinica.Antecedentes.AlergiaAntibiotico)
                    frmHistoriaClinica.chbxAlergiaAntibiotico.Checked = true;
                if (historiaClinica.Antecedentes.AlergiaAnestesia)
                    frmHistoriaClinica.chbxAlergiaAnestesia.Checked = true;
                if (historiaClinica.Antecedentes.Hemorragia)
                    frmHistoriaClinica.chbxHemorragia.Checked = true;
                if (historiaClinica.Antecedentes.Sida)
                    frmHistoriaClinica.chbxSida.Checked = true;
                if (historiaClinica.Antecedentes.Tuberculosis)
                    frmHistoriaClinica.chbxTuberculosis.Checked = true;
                if (historiaClinica.Antecedentes.Diabetes)
                    frmHistoriaClinica.chbxDiabetes.Checked = true;
                if (historiaClinica.Antecedentes.Hipertension)
                    frmHistoriaClinica.chbxHipertension.Checked = true;
                if (historiaClinica.Antecedentes.Asma)
                    frmHistoriaClinica.chbxAsma.Checked = true;
                if (historiaClinica.Antecedentes.EnfermedadCardiaca)
                    frmHistoriaClinica.chbxEnfCardiaca.Checked = true;
                if (historiaClinica.Antecedentes.BebidasAlcoholicas)
                {
                    frmHistoriaClinica.chbxBebidasAlcoholicas.Checked = true;
                    frmHistoriaClinica.txtFrecuencia.Text = historiaClinica.Antecedentes.Frecuencia;
                    frmHistoriaClinica.txtFrecuencia.Enabled = true;
                }
                if (historiaClinica.Antecedentes.Fuma)
                {
                    frmHistoriaClinica.chbxFuma.Checked = true;
                    frmHistoriaClinica.txtCantidad.Text = historiaClinica.Antecedentes.NumeroCigarros;
                    frmHistoriaClinica.txtCantidad.Enabled = true;
                }
                frmHistoriaClinica.txtAPFObservaciones.Text = historiaClinica.Antecedentes.Observaciones;
                abrirFormHijo(frmHistoriaClinica);
            }
            catch
            {
                MessageBox.Show("Seleccione un paciente en la sección PACIENTES para visualizar su Historia Clínica", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPlanTratamiento_Click(object sender, EventArgs e)
        {
            try
            {
                pnlHistoriaClinica.Visible = false;
                pnlPlanTratamiento.Visible = true;
                pnlTratamiento.Visible = false;
                pnlSalir.Visible = false;
                FrmPlanDeTratamiento frmPlanDeTratamiento = new FrmPlanDeTratamiento();
                frmPlanDeTratamiento.txtApellidos.Text = paciente.Apellidos;
                frmPlanDeTratamiento.txtNombres.Text = paciente.Nombres;
                frmPlanDeTratamiento.llenarDataGridView(doctor.obtenerPlanesTratamiento(historiaClinica.NumeroHistoriaClinica));
                frmPlanDeTratamiento.asignarDoctor(this.doctor, this.historiaClinica);
                abrirFormHijo(frmPlanDeTratamiento);
            }
            catch
            {
                MessageBox.Show("Seleccione un paciente en la sección PACIENTES para visualizar sus Planes de Tratamiento", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnTratamiento_Click(object sender, EventArgs e)
        {
            pnlHistoriaClinica.Visible = false;
            pnlPlanTratamiento.Visible = false;
            pnlTratamiento.Visible = true;
            pnlSalir.Visible = false;
        }
    }
}
