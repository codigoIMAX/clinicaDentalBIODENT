using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaAplicacion
{
    public partial class FrmPaciente : Form
    {
        Doctor doctor;
        Paciente paciente;
        HistoriaClinica historiaClinica;
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
                    historiaClinica = doctor.buscarHistoriaClinica(paciente.Cedula);
                    historiaClinica.Paciente = paciente;
                    btnModificar.Enabled = true;
                    btnEliminar.Enabled = true;
                    FrmPrincipal frmPrincipal = Owner as FrmPrincipal;
                    frmPrincipal.asignarPaciente(paciente);
                    frmPrincipal.asignarHistoriaClinica(historiaClinica);
                }
                else
                    MessageBox.Show("Por favor seleccione una fila.", "IESS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            FrmIngresarPaciente frmIngresarPaciente = new FrmIngresarPaciente();
            AddOwnedForm(frmIngresarPaciente);
            frmIngresarPaciente.asignarDoctor(this.doctor);
            frmIngresarPaciente.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion = MessageBox.Show("La eliminación de un paciente eliminará su Historia Clínica junto con sus planes de tratamiento.\n ¿Está segur@ de eliminar el paciente.?", "BIO-DENT", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    if (doctor.eliminarPaciente(paciente.Cedula))
                        MessageBox.Show("Paciente eliminado con éxito.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("El paciente no se pudo eliminar.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch
            {
                MessageBox.Show("No se pudo eliminar el paciente.\n Asegurese de seleccionar un registro.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            btnEliminar.Enabled = false;
            btnModificar.Enabled = false;
            FrmIngresarPaciente frmIngresarPaciente = new FrmIngresarPaciente();
            AddOwnedForm(frmIngresarPaciente);
            frmIngresarPaciente.cedulaAnterior = paciente.Cedula;
            frmIngresarPaciente.asignarDoctor(this.doctor);
            frmIngresarPaciente.editar = true;
            frmIngresarPaciente.txtCedula.Text = paciente.Cedula;
            frmIngresarPaciente.dtpFechaNacimiento.Value = paciente.FechaNacimiento;
            frmIngresarPaciente.txtApellidos.Text = paciente.Apellidos;
            frmIngresarPaciente.txtNombres.Text = paciente.Nombres;
            frmIngresarPaciente.txtDireccion.Text = paciente.Direccion;
            frmIngresarPaciente.txtOcupacion.Text = paciente.Ocupacion;
            frmIngresarPaciente.txtTelefono.Text = paciente.Telefono;
            frmIngresarPaciente.txtCelular.Text = paciente.Celular;
            if (paciente.Sexo)
                frmIngresarPaciente.rdbFemenino.Checked = true;
            frmIngresarPaciente.cbxEstadoCivil.Text = paciente.EstadoCivil;
            frmIngresarPaciente.txtCorreoElectronico.Text = paciente.CorreoElectronico;
            if (historiaClinica.TratamientoMedicoActual != "")
            {
                frmIngresarPaciente.txtMotivo.Text = historiaClinica.TratamientoMedicoActual;
                frmIngresarPaciente.rdbTSi.Checked = true;
                frmIngresarPaciente.txtMotivo.Enabled = true;
            }
            if (historiaClinica.TomaMedicamentoActual != "")
            {
                frmIngresarPaciente.txtMedicamento.Text = historiaClinica.TomaMedicamentoActual;
                frmIngresarPaciente.rdbMSi.Checked = true;
                frmIngresarPaciente.txtMedicamento.Enabled = true;
            }
            frmIngresarPaciente.txtHObservaciones.Text = historiaClinica.Observaciones;
            if (historiaClinica.Antecedentes.AlergiaAntibiotico)
                frmIngresarPaciente.chbxAlergiaAntibiotico.Checked = true;
            if (historiaClinica.Antecedentes.AlergiaAnestesia)
                frmIngresarPaciente.chbxAlergiaAnestesia.Checked = true;
            if (historiaClinica.Antecedentes.Hemorragia)
                frmIngresarPaciente.chbxHemorragia.Checked = true;
            if (historiaClinica.Antecedentes.Sida)
                frmIngresarPaciente.chbxSida.Checked = true;
            if (historiaClinica.Antecedentes.Tuberculosis)
                frmIngresarPaciente.chbxTuberculosis.Checked = true;
            if (historiaClinica.Antecedentes.Diabetes)
                frmIngresarPaciente.chbxDiabetes.Checked = true;
            if (historiaClinica.Antecedentes.Hipertension)
                frmIngresarPaciente.chbxHipertension.Checked = true;
            if (historiaClinica.Antecedentes.Asma)
                frmIngresarPaciente.chbxAsma.Checked = true;
            if (historiaClinica.Antecedentes.EnfermedadCardiaca)
                frmIngresarPaciente.chbxEnfCardiaca.Checked = true;
            if (historiaClinica.Antecedentes.BebidasAlcoholicas)
            {
                frmIngresarPaciente.chbxBebidasAlcoholicas.Checked = true;
                frmIngresarPaciente.txtFrecuencia.Text = historiaClinica.Antecedentes.Frecuencia;
                frmIngresarPaciente.txtFrecuencia.Enabled = true;
            }
            if (historiaClinica.Antecedentes.Fuma)
            {
                frmIngresarPaciente.chbxFuma.Checked = true;
                frmIngresarPaciente.txtCantidad.Text = historiaClinica.Antecedentes.NumeroCigarros;
                frmIngresarPaciente.txtCantidad.Enabled = true;
            }
            frmIngresarPaciente.txtAPFObservaciones.Text = historiaClinica.Antecedentes.Observaciones;
            frmIngresarPaciente.ShowDialog();
        }
    }
}
