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
    public partial class FrmDetalleTratamiento : Form
    {
        Doctor          doctor;
        HistoriaClinica historiaClinica;
        Actividad       actividad;
        Abono           abono;
        Rectangle       rectangle;
        List<Actividad> actividades         = new List<Actividad>();
        List<Abono>     abonos              = new List<Abono>();
        DateTimePicker  dtpFechaTratamiento = new DateTimePicker();
        DateTimePicker  dtpFechaAbono       = new DateTimePicker();
        int    idTratamiento;
        int    idActividad = 1;
        int    idAbono     = 1;
        double suma        = 0;
        double totalTratamiento;
        public FrmDetalleTratamiento()
        {
            InitializeComponent();
            dgvTratamientos.Controls.Add(dtpFechaTratamiento);
            dgvAbonos.Controls.Add(dtpFechaAbono);
            dtpFechaTratamiento.Visible = false;
            dtpFechaTratamiento.Format = DateTimePickerFormat.Short;
            dtpFechaTratamiento.TextChanged += new EventHandler(dtpFechaTratamiento_TextChange);
            dtpFechaAbono.Visible = false;
            dtpFechaAbono.Format = DateTimePickerFormat.Short;
            dtpFechaAbono.TextChanged += new EventHandler(dtpFechaAbono_TextChange);
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
            dgvPlanesTratamientos.Columns["Subtotal"].Visible = false;
        }

        private void dgvTratamientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvTratamientos.SelectedRows.Count > 0)
                {
                    actividad = new Actividad();
                    actividad.IdActividad = Convert.ToInt32(dgvTratamientos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    actividad.FechaActividad = Convert.ToDateTime(dgvTratamientos.Rows[e.RowIndex].Cells[1].Value.ToString());
                    actividad.NumeroPieza = Convert.ToInt32(dgvTratamientos.Rows[e.RowIndex].Cells[2].Value.ToString());
                    actividad.Detalle = dgvTratamientos.Rows[e.RowIndex].Cells[3].Value.ToString();
                }
                else
                {
                    switch (dgvTratamientos.Columns[e.ColumnIndex].Name)
                    {
                        case "clmFechaActividad":
                            rectangle = dgvTratamientos.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                            dtpFechaTratamiento.Size = new Size(rectangle.Width, rectangle.Height);
                            dtpFechaTratamiento.Location = new Point(rectangle.X, rectangle.Y);
                            dtpFechaTratamiento.Visible = true;
                            break;
                        default:
                            dtpFechaTratamiento.Visible = false;
                            break;
                    }
                }
            }
            catch { }
        }
        private void dtpFechaTratamiento_TextChange(object sender, EventArgs e)
        {
            dgvTratamientos.CurrentCell.Value = dtpFechaTratamiento.Text.ToString();
        }

        private void dgvTratamientos_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtpFechaTratamiento.Visible = false;
        }

        private void dgvTratamientos_Scroll(object sender, ScrollEventArgs e)
        {
            dtpFechaTratamiento.Visible = false;
        }

        private void dgvAbonos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvAbonos.SelectedRows.Count > 0)
                {
                    abono = new Abono();
                    abono.IdAbono = Convert.ToInt32(dgvAbonos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    abono.FechaAbono = Convert.ToDateTime(dgvAbonos.Rows[e.RowIndex].Cells[1].Value.ToString());
                    abono.Cantidad = Convert.ToDouble(dgvAbonos.Rows[e.RowIndex].Cells[2].Value.ToString());
                }
                else
                {
                    switch (dgvAbonos.Columns[e.ColumnIndex].Name)
                    {
                        case "clmFechaAbono":
                            rectangle = dgvAbonos.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                            dtpFechaAbono.Size = new Size(rectangle.Width, rectangle.Height);
                            dtpFechaAbono.Location = new Point(rectangle.X, rectangle.Y);
                            dtpFechaAbono.Visible = true;
                            break;
                        default:
                            dtpFechaAbono.Visible = false;
                            break;
                    }
                }
            }
            catch { }
        }
        private void dtpFechaAbono_TextChange(object sender, EventArgs e)
        {
            dgvAbonos.CurrentCell.Value = dtpFechaAbono.Text.ToString();
        }

        private void dgvAbonos_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtpFechaAbono.Visible = false;
        }

        private void dgvAbonos_Scroll(object sender, ScrollEventArgs e)
        {
            dtpFechaAbono.Visible = false;
        }

        private void btnAgregarTratamiento_Click(object sender, EventArgs e)
        {
            dgvTratamientos.Rows.Add(Convert.ToString(idActividad++));
            btnQuitarTratamiento.Enabled = false;
        }

        private void btnAgregarAbono_Click(object sender, EventArgs e)
        {
            dgvAbonos.Rows.Add(Convert.ToString(idAbono++));
            btnQuitarAbono.Enabled = false;
        }

        private void dgvPlanesTratamientos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPlanesTratamientos.SelectedRows.Count > 0)
                {
                    dgvAbonos.Rows.Clear();
                    dgvTratamientos.Rows.Clear();
                    txtNumeroTratamiento.Text = dgvPlanesTratamientos.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtDescripcion.Text = dgvPlanesTratamientos.Rows[e.RowIndex].Cells[2].Value.ToString();
                    if (dgvPlanesTratamientos.Rows[e.RowIndex].Cells[3].Value.ToString() == "Terminado")
                        rdbTerminado.Checked = true;
                    else
                        rdbActivo.Checked = true;
                    dtpFechaPlanTratamiento.Value = Convert.ToDateTime(dgvPlanesTratamientos.Rows[e.RowIndex].Cells[4].Value.ToString());
                    idTratamiento = Convert.ToInt32(dgvPlanesTratamientos.Rows[e.RowIndex].Cells[0].Value.ToString());
                    totalTratamiento = Convert.ToDouble(dgvPlanesTratamientos.Rows[e.RowIndex].Cells[6].Value.ToString());
                    actividades = doctor.llenarActividades(idTratamiento);
                    if(actividades.Count() > 0)
                    {
                        foreach (var aux in actividades)
                        {
                            dgvTratamientos.Rows.Add(aux.IdActividad, aux.FechaActividad.ToString("dd/MM/yyyy"), aux.NumeroPieza.ToString(), aux.Detalle);
                        }
                        idActividad += actividades.Last().IdActividad;
                    }
                    abonos = doctor.llenarAbonos(idTratamiento);
                    suma = 0;
                    if(abonos.Count() > 0)
                    {
                        foreach (var aux in abonos)
                        {
                            dgvAbonos.Rows.Add(aux.IdAbono, aux.FechaAbono.ToString("dd/MM/yyyy"), aux.Cantidad);
                            suma = suma + aux.Cantidad;
                        }
                    }
                    txtTotalAbonos.Text = Convert.ToString(suma);
                    txtSaldo.Text = Convert.ToString(totalTratamiento - suma);
                    idAbono += abonos.Last().IdAbono;
                    btnGuardar.Enabled = true;
                    btnAgregarTratamiento.Enabled = true;
                    btnAgregarAbono.Enabled = true;
                    btnQuitarTratamiento.Enabled = true;
                    btnQuitarAbono.Enabled = true;
                }
                else
                    MessageBox.Show("Por favor seleccione una fila.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception expt)
            {
                btnGuardar.Enabled = true;
                btnAgregarTratamiento.Enabled = true;
                btnAgregarAbono.Enabled = true;
                MessageBox.Show(expt.Message);
            }
        }

        private void btnQuitarTratamiento_Click(object sender, EventArgs e)
        {
            var item = actividades.SingleOrDefault(aux => aux.IdActividad == actividad.IdActividad);
            if (item != null)
            {
                actividades.Remove(item);
            }
            actualizarDataGridViewTratamientos();
        }

        private void btnQuitarAbono_Click(object sender, EventArgs e)
        {
            var item = abonos.SingleOrDefault(aux => aux.IdAbono== abono.IdAbono);
            if (item != null)
            {
                abonos.Remove(item);
            }
            actualizarDataGridViewAbonos();
        }
        private void actualizarDataGridViewTratamientos()
        {
            dgvTratamientos.Rows.Clear();
            foreach (var aux in actividades)
            {
                dgvTratamientos.Rows.Add(aux.IdActividad, aux.FechaActividad.ToString("dd/MM/yyyy"), aux.NumeroPieza.ToString(), aux.Detalle);
            }
        }
        private void actualizarDataGridViewAbonos()
        {
            suma = 0;
            dgvAbonos.Rows.Clear();
            foreach (var aux in abonos)
            {
                dgvAbonos.Rows.Add(aux.IdAbono, aux.FechaAbono.ToString("dd/MM/yyyy"), aux.Cantidad);
                suma = suma + aux.Cantidad;
            }
            txtTotalAbonos.Text = Convert.ToString(suma);
            txtSaldo.Text = Convert.ToString(totalTratamiento - suma);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvTratamientos.Rows.Count > 0)
                {
                    actividades = new List<Actividad>();
                    idActividad = 1;
                    foreach(DataGridViewRow fila in dgvTratamientos.Rows)
                    {
                        actividad = new Actividad();
                        actividad.IdActividad = idActividad++;
                        actividad.FechaActividad = Convert.ToDateTime(fila.Cells["clmFechaActividad"].Value);
                        actividad.NumeroPieza = Convert.ToInt16(fila.Cells["clmNumeroPieza"].Value);
                        actividad.Detalle = Convert.ToString(fila.Cells["clmTratamiento"].Value);
                        actividades.Add(actividad);
                    }
                    if(doctor.ingresarActividades(actividades, idTratamiento))
                        MessageBox.Show("Registro de tratamientos ingesado con éxito.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No se pudo ingresar el registro de tratamientos.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                if (dgvAbonos.Rows.Count > 0)
                {
                    abonos = new List<Abono>();
                    idAbono = 1;
                    foreach (DataGridViewRow fila in dgvAbonos.Rows)
                    {
                        abono = new Abono();
                        abono.IdAbono = idAbono++;
                        abono.FechaAbono = Convert.ToDateTime(fila.Cells["clmFechaAbono"].Value);
                        abono.Cantidad = Convert.ToDouble(fila.Cells["clmAbono"].Value);
                        abonos.Add(abono);
                    }
                    if(doctor.ingresarAbonos(abonos, idTratamiento))
                        MessageBox.Show("Registro de abonos ingesado con éxito.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("No se pudo ingresar el registro de abonos.", "BIO-DENT", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                btnAgregarAbono.Enabled = false;
                btnAgregarTratamiento.Enabled = false;
                btnGuardar.Enabled = false;
                btnQuitarAbono.Enabled = false;
                btnQuitarTratamiento.Enabled = false;
            }
            catch { }

        }
        /*
* SqlCommand query = new SqlCommand("Insert INTO tbl VALUES (@numero, @nombre, @fecha)", conexion)
* conexion.open()
* try{
*      foreach(DataGridViewRow row in dgvTratamientos.Rows){
*          query.Parameters.Clear();
*          query.Parameters.AddWithValue("@numero", ConvertToInt32(row.Cells["clmNumero"].Value));
*          query.Parameters.AddWithValue("@nombre", ConvertToString(row.Cells["clmNombre"].Value));
*          query.ExecuteNonQuery();
*      }
*      MessasgeBox("Datos agregados");
* }
* catch(Exception ex){
*  MessaBox("Error al agregar")
* }
* finally{
*  conexion.Close();
* }
*/
    }
}
