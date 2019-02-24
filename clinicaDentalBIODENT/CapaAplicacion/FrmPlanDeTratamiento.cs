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
    public partial class FrmPlanDeTratamiento : Form
    {
        Doctor doctor;
        PlanTratamiento planTratamiento;
        Detalle detalle;
        List<Detalle> detalles = new List<Detalle>();
        HistoriaClinica historiaClinica;
        int idTratamiento;
        int idDetalle = 1;
        bool editar = false;
        public FrmPlanDeTratamiento()
        {
            InitializeComponent();
        }
        public void asignarDoctor(Object doctor, Object historia)
        {
            this.doctor = (Doctor)doctor;
            this.historiaClinica = (HistoriaClinica)historia;
        }
        public void llenarDataGridView(DataTable tbl)
        {
            dgvPlanesTratamientos.DataSource = tbl;
            dgvPlanesTratamientos.Columns["Id"].Visible = false;
            DataTable tabla = new DataTable();
            tabla.Columns.Add("N°");
            tabla.Columns.Add("Actividad");
            tabla.Columns.Add("Cantidad");
            tabla.Columns.Add("Precio Unitario");
            dgvDetalles.DataSource = tabla;
        }

        private void dgvPlanesTratamientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPlanesTratamientos.SelectedRows.Count > 0)
                {
                    txtNumeroTratamiento.Text = dgvPlanesTratamientos.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtDescripcion.Text = dgvPlanesTratamientos.Rows[e.RowIndex].Cells[2].Value.ToString();
                    if (dgvPlanesTratamientos.Rows[e.RowIndex].Cells[3].Value.ToString() == "Terminado")
                        rdbTerminado.Checked = true;
                    else
                        rdbActivo.Checked = true;
                    dtpFechaPlanTratamiento.Value = Convert.ToDateTime(dgvPlanesTratamientos.Rows[e.RowIndex].Cells[4].Value.ToString());
                    txtSubtotal.Text = dgvPlanesTratamientos.Rows[e.RowIndex].Cells[5].Value.ToString();
                    txtTotal.Text = dgvPlanesTratamientos.Rows[e.RowIndex].Cells[6].Value.ToString();
                    idTratamiento = Convert.ToInt32(dgvPlanesTratamientos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    dgvDetalles.DataSource = doctor.obtenerDetalles(idTratamiento);
                    detalles = doctor.llenarDetalles(idTratamiento);
                    idDetalle += detalles.Last().IdDetalle;
                    btnEliminar.Enabled = true;
                    editar = true;
                }
                else
                    MessageBox.Show("Por favor seleccione una fila.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {

            }
        }
        private void txtTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != 46))
            {
                MessageBox.Show("Solo se permiten valores monetarios.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
                return;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtDescripcion.Text != "")
                {
                    if(txtTotal.Text != "")
                    {
                        if (detalles.Any())
                        {
                            planTratamiento = new PlanTratamiento();
                            planTratamiento.Descripcion = txtDescripcion.Text;
                            planTratamiento.FechaPlanTratamiento = dtpFechaPlanTratamiento.Value;
                            planTratamiento.Subtotal = Convert.ToDouble(txtSubtotal.Text);
                            planTratamiento.Total = Convert.ToDouble(txtTotal.Text);
                            if (rdbActivo.Checked)
                                planTratamiento.Estado = true;
                            else
                                planTratamiento.Estado = false;
                            idDetalle = 1;
                            foreach (var aux in detalles)
                                aux.IdDetalle = idDetalle++;
                            planTratamiento.Detalles = detalles;
                            if (editar)
                            {
                                planTratamiento.IdPlanTratamiento = idTratamiento;
                                if (doctor.modificarPlanTratamiento(planTratamiento))
                                {
                                    MessageBox.Show("Plan de Tratamiento modificado con éxito.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    llenarDataGridView(doctor.obtenerPlanesTratamiento(historiaClinica.NumeroHistoriaClinica));
                                    nuevoPlan();
                                }
                                 else
                                    MessageBox.Show("No se pudo modificar el Plan de Tratamiento.\n Revise que todos los campos estén correctos. ", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                if (doctor.ingresarPlanTratamiento(planTratamiento, historiaClinica.NumeroHistoriaClinica))
                                {
                                    MessageBox.Show("Nuevo Plan de Tratamiento ingresado con éxito.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    llenarDataGridView(doctor.obtenerPlanesTratamiento(historiaClinica.NumeroHistoriaClinica));
                                    nuevoPlan();
                                }
                                else
                                    MessageBox.Show("No se pudo ingresar el Plan de Tratamiento.\n Revise que todos los campos estén correctos. ", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                            MessageBox.Show("Para guardar un Plan de Tratamiento, debe almenos ingresar una actividad dentro del presupuesto.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("El valor total del tratamiento no puede estar vacío.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Especifique una descripción general del Plan de Tratamiento.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("No se pudo ingresar el paciente.\n Revise que los datos estén correctos", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtActividad_MouseClick(object sender, MouseEventArgs e)
        {
            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
        }

        private void txtPrecioUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != 46))
            {
                MessageBox.Show("Solo se permiten valores monetarios.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Handled = true;
                return;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtActividad.Text != "")
                {
                    if(txtCantidad.Text != "")
                    {
                        if(txtPrecioUnitario.Text != "")
                        {
                            detalle = new Detalle();
                            detalle.IdDetalle = idDetalle++;
                            detalle.Actividad = txtActividad.Text;
                            detalle.Cantidad = Convert.ToInt32(txtCantidad.Text);
                            detalle.PrecioUnitario = Convert.ToDouble(txtPrecioUnitario.Text);
                            detalles.Add(detalle);
                            actualizarDataGridViewDetalles();
                            limpiarTextos();
                            btnAgregar.Enabled = false;
                            btnNuevoItem.Enabled = false;
                        }
                        else
                            MessageBox.Show("Ingrese el valor del precio unitario.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Ingrese la cantidad.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Llene el campo actividad.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

            }
        }
        private void actualizarDataGridViewDetalles()
        {
            double total = 0;
            DataTable tbl = new DataTable();
            tbl.Columns.Add("N°");
            tbl.Columns.Add("Actividad");
            tbl.Columns.Add("Cantidad");
            tbl.Columns.Add("Precio Unitario");
            tbl.Columns.Add("Sub Total");
            foreach (var aux in detalles)
            {
                tbl.Rows.Add(aux.IdDetalle, aux.Actividad, aux.Cantidad, aux.PrecioUnitario, aux.Cantidad * aux.PrecioUnitario);
                total = total + (aux.Cantidad * aux.PrecioUnitario);
            }
            dgvDetalles.DataSource = tbl;
            txtSubtotal.Text = Convert.ToString(total);
            txtTotal.Text = Convert.ToString(total);
            btnAgregar.Enabled = false;
        }

        private void dgvDetalles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDetalles.SelectedRows.Count > 0)
                {
                    detalle = new Detalle();
                    detalle.IdDetalle = Convert.ToInt32(dgvDetalles.Rows[e.RowIndex].Cells[0].Value.ToString());
                    detalle.Actividad = dgvDetalles.Rows[e.RowIndex].Cells[1].Value.ToString();
                    detalle.Cantidad = Convert.ToInt32(dgvDetalles.Rows[e.RowIndex].Cells[2].Value.ToString());
                    detalle.PrecioUnitario = Convert.ToDouble(dgvDetalles.Rows[e.RowIndex].Cells[3].Value.ToString());
                    txtActividad.Text = detalle.Actividad;
                    txtCantidad.Text = Convert.ToString(detalle.Cantidad);
                    txtPrecioUnitario.Text = Convert.ToString(detalle.PrecioUnitario);
                    txtTotalDetalle.Text = Convert.ToString(detalle.Cantidad * detalle.PrecioUnitario);
                    btnQuitar.Enabled = true;
                    btnAgregar.Enabled = false;
                    btnNuevoItem.Enabled = true;
                }
                else
                    MessageBox.Show("Por favor seleccione una fila.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch
            {

            }
            
        }
        private void limpiarTextos()
        {
            txtActividad.Text = "";
            txtCantidad.Text = "";
            txtPrecioUnitario.Text = "";
            txtTotalDetalle.Text = "00.00";
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            var item = detalles.SingleOrDefault(aux => aux.IdDetalle == detalle.IdDetalle);
            if(item != null)
            {
                detalles.Remove(item);
                actualizarDataGridViewDetalles();
                limpiarTextos();
            }
            btnQuitar.Enabled = false;
            btnNuevoItem.Enabled = false;
        }

        private void txtPrecioUnitario_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtCantidad.Text != "")
                {
                    txtTotalDetalle.Text = Convert.ToString(Convert.ToInt32(txtCantidad.Text) * Convert.ToDouble(txtPrecioUnitario.Text));
                }
            }
            catch { }
        }

        private void txtCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (txtPrecioUnitario.Text != "")
                {
                    txtTotalDetalle.Text = Convert.ToString(Convert.ToInt32(txtCantidad.Text) * Convert.ToDouble(txtPrecioUnitario.Text));
                }
            }
            catch { }
        }
        private void btnNuevoItem_Click(object sender, EventArgs e)
        {
            limpiarTextos();
            btnAgregar.Enabled = false;
            btnEliminar.Enabled = false;
            btnNuevoItem.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion = MessageBox.Show("¿Está segur@ de eliminar el Plan de Tratamiento seleccionado?", "BIO-DENT", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.Yes)
                {
                    if (doctor.eliminarPlanTratamiento(idTratamiento))
                    {
                        MessageBox.Show("Plan de Tratamiento eliminado con éxito.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        llenarDataGridView(doctor.obtenerPlanesTratamiento(historiaClinica.NumeroHistoriaClinica));
                    }
                    else
                        MessageBox.Show("El Plan de Tratamiento no se pudo eliminar.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch
            {
                MessageBox.Show("No se pudo eliminar el Plan de Tratamiento.\n Asegurese de seleccionar un registro.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void nuevoPlan()
        {
            detalles = new List<Detalle>();
            DataTable tbl = new DataTable();
            tbl.Columns.Add("N°");
            tbl.Columns.Add("Actividad");
            tbl.Columns.Add("Cantidad");
            tbl.Columns.Add("Precio Unitario");
            tbl.Columns.Add("Sub Total");
            dgvDetalles.DataSource = tbl;
            dtpFechaPlanTratamiento.Value = DateTime.Today;
            txtDescripcion.Text = "";
            txtSubtotal.Text = "00.00";
            txtTotal.Text = "00.00";
            txtNumeroTratamiento.Text = "";
            limpiarTextos();
            btnEliminar.Enabled = false;
            rdbActivo.Checked = true;
            idDetalle = 1;
            editar = false;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nuevoPlan();
        }
    }
}
