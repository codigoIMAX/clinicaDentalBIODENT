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
    public partial class FrmCambiarUsuario : Form
    {
        Doctor doctor;
        public FrmCambiarUsuario()
        {
            InitializeComponent();
        }

        private void FrmCambiarUsuario_Load(object sender, EventArgs e)
        {
            txtUsuarioActual.Text = doctor.Usuario;
        }
        public void asignarDoctor(object doctor)
        {
            this.doctor = (Doctor)doctor;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNuevoNombre.Text != "")
            {
                DialogResult dialogo = MessageBox.Show("¿Desea modificar el nombre de usuario?", "BIO-DENT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogo == DialogResult.Yes)
                {
                    MessageBox.Show(doctor.cambiarNombreUsuario(txtUsuarioActual.Text, txtNuevoNombre.Text), "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            else
                MessageBox.Show("Ingrese el nuevo nombre de usuario.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FrmPrincipal frmPrincipal = Owner as FrmPrincipal;
            FrmInicio frmInicio = new FrmInicio();
            frmPrincipal.abrirFormHijo(frmInicio);
        }
    }
}
