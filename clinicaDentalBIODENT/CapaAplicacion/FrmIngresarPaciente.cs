using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaAplicacion
{
    public partial class FrmIngresarPaciente : Form
    {
        public bool editar = false;
        public string cedulaAnterior;
        Doctor doctor;
        Paciente paciente;
        HistoriaClinica historiaClinica;
        AntecedentePF antecedentePF;
        public FrmIngresarPaciente()
        {
            InitializeComponent();
        }
        public void asignarDoctor(Object doctor)
        {
            this.doctor = (Doctor)doctor;
        }

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtApellidoPaterno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtNombres_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtOcupacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten letras", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private bool validarEmail(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCedula.Text != "")
                {
                    if(txtApellidos.Text != "")
                    {
                        if(txtNombres.Text != "")
                        {
                            if(txtDireccion.Text != "")
                            {
                                if (txtCorreoElectronico.Text != "")
                                {
                                    if (validarEmail(txtCorreoElectronico.Text))
                                    {
                                        paciente = new Paciente();
                                        paciente.Cedula = txtCedula.Text;
                                        paciente.FechaNacimiento = dtpFechaNacimiento.Value;
                                        paciente.Apellidos = txtApellidos.Text;
                                        paciente.Nombres = txtNombres.Text;
                                        paciente.Direccion = txtDireccion.Text;
                                        paciente.Ocupacion = txtOcupacion.Text;
                                        paciente.Telefono = txtTelefono.Text;
                                        paciente.Celular = txtCelular.Text;
                                        paciente.EstadoCivil = cbxEstadoCivil.Text;
                                        if (rdbMasculino.Checked)
                                            paciente.Sexo = false;
                                        else
                                            paciente.Sexo = true;
                                        paciente.CorreoElectronico = txtCorreoElectronico.Text;
                                        historiaClinica = new HistoriaClinica();
                                        historiaClinica.TratamientoMedicoActual = txtMotivo.Text;
                                        historiaClinica.TomaMedicamentoActual = txtMedicamento.Text;
                                        historiaClinica.Observaciones = txtHObservaciones.Text;
                                        historiaClinica.Paciente = paciente;
                                        antecedentePF = new AntecedentePF();
                                        if (chbxAlergiaAntibiotico.Checked)
                                            antecedentePF.AlergiaAntibiotico = true;
                                        else
                                            antecedentePF.AlergiaAntibiotico = false;
                                        if (chbxAlergiaAnestesia.Checked)
                                            antecedentePF.AlergiaAnestesia = true;
                                        else
                                            antecedentePF.AlergiaAnestesia = false;
                                        if (chbxHemorragia.Checked)
                                            antecedentePF.Hemorragia = true;
                                        else
                                            antecedentePF.Hemorragia = false;
                                        if (chbxSida.Checked)
                                            antecedentePF.Sida= true;
                                        else
                                            antecedentePF.Sida = false;
                                        if (chbxTuberculosis.Checked)
                                            antecedentePF.Tuberculosis = true;
                                        else
                                            antecedentePF.Tuberculosis = false;
                                        if (chbxDiabetes.Checked)
                                            antecedentePF.Diabetes = true;
                                        else
                                            antecedentePF.Diabetes = false;
                                        if (chbxHipertension.Checked)
                                            antecedentePF.Hipertension = true;
                                        else
                                            antecedentePF.Hipertension = false;
                                        if (chbxAsma.Checked)
                                            antecedentePF.Asma = true;
                                        else
                                            antecedentePF.Asma = false;
                                        if (chbxEnfCardiaca.Checked)
                                            antecedentePF.EnfermedadCardiaca = true;
                                        else
                                            antecedentePF.EnfermedadCardiaca = false;
                                        if (chbxBebidasAlcoholicas.Checked)
                                            antecedentePF.BebidasAlcoholicas = true;                                        
                                        else
                                            antecedentePF.BebidasAlcoholicas = false;
                                        antecedentePF.Frecuencia = txtFrecuencia.Text;
                                        if (chbxFuma.Checked)
                                            antecedentePF.Fuma = true;
                                        else
                                            antecedentePF.Fuma = false;
                                        antecedentePF.NumeroCigarros = txtCantidad.Text;
                                        antecedentePF.Observaciones = txtAPFObservaciones.Text;
                                        historiaClinica.Antecedentes = antecedentePF;
                                        if (editar)
                                        {
                                            if (doctor.actualizarPaciente(historiaClinica, cedulaAnterior))
                                            {
                                                MessageBox.Show("Paciente modificado con éxito", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                FrmPaciente frmPaciente = Owner as FrmPaciente;
                                                frmPaciente.llenarDataGridView(doctor.obtenerPacientes());
                                                this.Close();
                                            }
                                            else
                                                MessageBox.Show("El paciente no se pudo modificar. \n Revise los campos", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                        else
                                        {
                                            if (doctor.ingresarPaciente(paciente, historiaClinica))
                                            {
                                                MessageBox.Show("Paciente ingresado con éxito", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                limpiarTextos();
                                                FrmPaciente frmPaciente = Owner as FrmPaciente;
                                                frmPaciente.llenarDataGridView(doctor.obtenerPacientes());
                                            }
                                            else
                                                MessageBox.Show("El paciente ya se encuentra registrado. \n La cédula ya existe registrada", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                        MessageBox.Show("La dirección de correo electrónico está mal escrita", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                }
                                else
                                {
                                    paciente = new Paciente();
                                    paciente.Cedula = txtCedula.Text;
                                    paciente.FechaNacimiento = dtpFechaNacimiento.Value;
                                    paciente.Apellidos = txtApellidos.Text;
                                    paciente.Nombres = txtNombres.Text;
                                    paciente.Direccion = txtDireccion.Text;
                                    paciente.Ocupacion = txtOcupacion.Text;
                                    paciente.Telefono = txtTelefono.Text;
                                    paciente.Celular = txtCelular.Text;
                                    paciente.EstadoCivil = cbxEstadoCivil.Text;
                                    if (rdbMasculino.Checked)
                                        paciente.Sexo = false;
                                    else
                                        paciente.Sexo = true;
                                    paciente.CorreoElectronico = txtCorreoElectronico.Text;
                                    historiaClinica = new HistoriaClinica();
                                    historiaClinica.TratamientoMedicoActual = txtMotivo.Text;
                                    historiaClinica.TomaMedicamentoActual = txtMedicamento.Text;
                                    historiaClinica.Observaciones = txtHObservaciones.Text;
                                    historiaClinica.Paciente = paciente;
                                    antecedentePF = new AntecedentePF();
                                    if (chbxAlergiaAntibiotico.Checked)
                                        antecedentePF.AlergiaAntibiotico = true;
                                    else
                                        antecedentePF.AlergiaAntibiotico = false;
                                    if (chbxAlergiaAnestesia.Checked)
                                        antecedentePF.AlergiaAnestesia = true;
                                    else
                                        antecedentePF.AlergiaAnestesia = false;
                                    if (chbxHemorragia.Checked)
                                        antecedentePF.Hemorragia = true;
                                    else
                                        antecedentePF.Hemorragia = false;
                                    if (chbxSida.Checked)
                                        antecedentePF.Sida = true;
                                    else
                                        antecedentePF.Sida = false;
                                    if (chbxTuberculosis.Checked)
                                        antecedentePF.Tuberculosis = true;
                                    else
                                        antecedentePF.Tuberculosis = false;
                                    if (chbxDiabetes.Checked)
                                        antecedentePF.Diabetes = true;
                                    else
                                        antecedentePF.Diabetes = false;
                                    if (chbxHipertension.Checked)
                                        antecedentePF.Hipertension = true;
                                    else
                                        antecedentePF.Hipertension = false;
                                    if (chbxAsma.Checked)
                                        antecedentePF.Asma = true;
                                    else
                                        antecedentePF.Asma = false;
                                    if (chbxEnfCardiaca.Checked)
                                        antecedentePF.EnfermedadCardiaca = true;
                                    else
                                        antecedentePF.EnfermedadCardiaca = false;
                                    if (chbxBebidasAlcoholicas.Checked)
                                        antecedentePF.BebidasAlcoholicas = true;
                                    else
                                        antecedentePF.BebidasAlcoholicas = false;
                                    antecedentePF.Frecuencia = txtFrecuencia.Text;
                                    if (chbxFuma.Checked)
                                        antecedentePF.Fuma = true;
                                    else
                                        antecedentePF.Fuma = false;
                                    antecedentePF.NumeroCigarros = txtFrecuencia.Text;
                                    antecedentePF.Observaciones = txtAPFObservaciones.Text;
                                    historiaClinica.Antecedentes = antecedentePF;
                                    if (editar)
                                    {
                                        if (doctor.actualizarPaciente(historiaClinica, cedulaAnterior))
                                        {
                                            MessageBox.Show("Paciente modificado con éxito", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            FrmPaciente frmPaciente = Owner as FrmPaciente;
                                            frmPaciente.llenarDataGridView(doctor.obtenerPacientes());
                                            this.Close();
                                        }
                                        else
                                            MessageBox.Show("El paciente no se pudo modificar. \n Revise los campos", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        if (doctor.ingresarPaciente(paciente, historiaClinica))
                                        {
                                            MessageBox.Show("Paciente ingresado con éxito", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            limpiarTextos();
                                            FrmPaciente frmPaciente = Owner as FrmPaciente;
                                            frmPaciente.llenarDataGridView(doctor.obtenerPacientes());
                                        }
                                        else
                                            MessageBox.Show("El paciente ya se encuentra registrado. \n La cédula ya existe registrada", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                                MessageBox.Show("Ingrese la dirección de domicilio", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        else
                            MessageBox.Show("Ingrese los nombres", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    else
                        MessageBox.Show("Ingrese los apellidos", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                    MessageBox.Show("Ingrese el número de cédula", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            catch
            {
                MessageBox.Show("No se pudo ingresar el paciente.\n Revise que los datos estén correctos", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void limpiarTextos()
        {
            txtCedula.Text = "";
            txtApellidos.Text = "";
            txtNombres.Text = "";
            txtDireccion.Text = "";
            txtOcupacion.Text = "";
            txtTelefono.Text = "";
            txtCelular.Text = "";
            cbxEstadoCivil.SelectedIndex = 0;
            rdbMasculino.Checked = true;
            txtCorreoElectronico.Text = "";
            rdbTNo.Checked = true;
            rdbMNo.Checked = true;
            txtHObservaciones.Text = "";
            chbxAlergiaAntibiotico.Checked = false;
            chbxAlergiaAnestesia.Checked = false;
            chbxHemorragia.Checked = false;
            chbxSida.Checked = false;
            chbxTuberculosis.Checked = false;
            chbxDiabetes.Checked = false;
            chbxHipertension.Checked = false;
            chbxAsma.Checked = false;
            chbxEnfCardiaca.Checked = false;
            chbxBebidasAlcoholicas.Checked = false;
            chbxFuma.Checked = false;
            txtFrecuencia.Text = "";
            txtCantidad.Text = "";
            txtAPFObservaciones.Text = "";
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdbTSi_CheckedChanged(object sender, EventArgs e)
        {
            txtMotivo.Enabled = true;
        }

        private void rdbTNo_CheckedChanged(object sender, EventArgs e)
        {
            txtMotivo.Enabled = false;
        }

        private void rdbMSi_CheckedChanged(object sender, EventArgs e)
        {
            txtMedicamento.Enabled = true;
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
