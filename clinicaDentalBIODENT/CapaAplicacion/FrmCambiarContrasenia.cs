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
    public partial class FrmCambiarContrasenia : Form
    {
        Doctor doctor;
        public FrmCambiarContrasenia()
        {
            InitializeComponent();
        }
        public void asignarDoctor(object doctor)
        {
            this.doctor = (Doctor)doctor;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FrmPrincipal frmPrincipal = Owner as FrmPrincipal;
            FrmInicio frmInicio = new FrmInicio();
            frmPrincipal.abrirFormHijo(frmInicio);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(txtContraseniaActual.Text != "")
            {
                if(txtNuevaContrasenia.Text != "")
                {
                    if(txtRepeticionContrasenia.Text != "")
                    {
                        if (txtRepeticionContrasenia.Text.Equals(txtNuevaContrasenia.Text))
                        {
                            DialogResult dialogo = MessageBox.Show("¿Desea modificar la contraseñia de acceso?", "BIO-DENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (dialogo == DialogResult.Yes)
                            {
                                MessageBox.Show(doctor.cambiarContrasenia(txtContraseniaActual.Text, txtNuevaContrasenia.Text, doctor.Usuario), "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Application.Exit();
                            }
                        }
                        else
                            MessageBox.Show("Las contraseñas no coinciden.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                        MessageBox.Show("Confirme la contraseña.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                    MessageBox.Show("Ingrese la nueva contraseña.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
                MessageBox.Show("Ingrese la contraseña actual.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void txtContraseniaActual_Enter(object sender, EventArgs e)
        {
            txtContraseniaActual.PasswordChar = '*';
        }

        private void txtNuevaContrasenia_Enter(object sender, EventArgs e)
        {
            txtNuevaContrasenia.PasswordChar = '*';
        }

        private void txtRepeticionContrasenia_Enter(object sender, EventArgs e)
        {
            txtRepeticionContrasenia.PasswordChar = '*';
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            txtContraseniaActual.PasswordChar = '\0';
            txtNuevaContrasenia.PasswordChar = '\0';
            txtRepeticionContrasenia.PasswordChar = '\0';
        }
    }
}
