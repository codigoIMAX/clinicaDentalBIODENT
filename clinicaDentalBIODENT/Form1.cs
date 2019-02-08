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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
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
            btnCerrar.BackColor = Color.FromArgb(170, 216, 239);
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
            btnMinimizar.BackColor = Color.FromArgb(170, 216, 239);
        }
        private void btnSalir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Usted acaba de salir del sistema", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Doctor doctor = new Doctor(txtUsuario.Text, txtContrasenia.Text);
            if (doctor.validarDoctor())
            {
                MessageBox.Show("Bienvenid@ al sistema", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FrmPrincipal frmPrincipal = new FrmPrincipal();
                desplazar();
                frmPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario y/o Contraseñia incorrectos", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = "";
                txtContrasenia.Text = "";
            }
        }
        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                e.Handled = true;
                return;
            }
        }
        private void txtContrasenia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 39)
            {
                e.Handled = true;
                return;
            }
        }
        private void desplazar()
        {
            Point punto = new Point(this.Location.X, this.Location.Y);
            for (int i = 0; i < 500; i++)
            {
                punto.X += 1;
                this.Location = punto;
            }
        }
    }
}
