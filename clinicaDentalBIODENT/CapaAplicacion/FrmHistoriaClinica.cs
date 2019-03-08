using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using CapaNegocio;

namespace CapaAplicacion
{
    public partial class FrmHistoriaClinica : Form
    {
        Doctor            doctor;
        PiezaDental       piezaDental;
        AntecedentePF     antecedentePF;
        HistoriaClinica   historiaClinica;
        List<PictureBox>  pictures        = new List<PictureBox>();
        List<PiezaDental> piezasDentales  = new List<PiezaDental>();
        string color = "White";
        public FrmHistoriaClinica()
        {
            InitializeComponent();
        }
        public void asignarDoctor(object doctor, object historiaClinica)
        {
            this.doctor = (Doctor)doctor;
            this.historiaClinica = (HistoriaClinica)historiaClinica;
            int intAux         = 1;
            int intLazo        = 1;
            int intNumeroPieza = 11;
            while(intLazo <= 52)
            {
                var piezas = this.Controls.OfType<PictureBox>().Where(x => x.Name.StartsWith("p" + intNumeroPieza));
                foreach(var pieza in piezas)
                {
                    switch (intAux)
                    {
                        case 1:
                            pieza.BackColor = Color.FromName(this.historiaClinica.PiezasDentales[intLazo-1].ColorDerecha);
                            intAux++;
                            break;
                        case 2:
                            pieza.BackColor = Color.FromName(this.historiaClinica.PiezasDentales[intLazo - 1].ColorCentro);
                            intAux++;
                            break;
                        case 3:
                            pieza.BackColor = Color.FromName(this.historiaClinica.PiezasDentales[intLazo - 1].ColorIzquierda);
                            intAux++;
                            break;
                        case 4:
                            pieza.BackColor = Color.FromName(this.historiaClinica.PiezasDentales[intLazo - 1].ColorAbajo);
                            intAux++;
                            break;
                        case 5:
                            pieza.BackColor = Color.FromName(this.historiaClinica.PiezasDentales[intLazo - 1].ColorArriba);
                            intAux++;
                            break;
                    }
                }
                intAux = 1;
                intNumeroPieza++;
                if (intNumeroPieza == 19)
                    intNumeroPieza = 21;
                else if (intNumeroPieza == 29)
                    intNumeroPieza = 31;
                else if (intNumeroPieza == 39)
                    intNumeroPieza = 41;
                else if (intNumeroPieza == 49)
                    intNumeroPieza = 51;
                else if (intNumeroPieza == 56)
                    intNumeroPieza = 61;
                else if (intNumeroPieza == 66)
                    intNumeroPieza = 71;
                else if (intNumeroPieza == 76)
                    intNumeroPieza = 81;
                intLazo++;
            }
        }
        private void llenarOdontograma()
        {

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

        
        private void FrmHistoriaClinica_Load(object sender, EventArgs e)
        {

        }

        private void rdbPorRealizar_CheckedChanged(object sender, EventArgs e)
        {
            color = "Red";
        }

        private void rdbRealizado_CheckedChanged(object sender, EventArgs e)
        {
            color = "blue";
        }

        private void rdbExodoncia_CheckedChanged(object sender, EventArgs e)
        {
            color = "Green";
        }

        private void p11A_Click(object sender, EventArgs e)
        {
            p11A.BackColor = Color.FromName(color);
        }

        private void p11Ab_Click(object sender, EventArgs e)
        {
            p11Ab.BackColor = Color.FromName(color);
        }

        private void p11C_Click(object sender, EventArgs e)
        {
            p11C.BackColor = Color.FromName(color);
        }

        private void p11D_Click(object sender, EventArgs e)
        {
            p11D.BackColor = Color.FromName(color);
        }

        private void p11I_Click(object sender, EventArgs e)
        {
            p11I.BackColor = Color.FromName(color);
        }

        private void p12A_Click(object sender, EventArgs e)
        {
            p12A.BackColor = Color.FromName(color);
        }

        private void p12Ab_Click(object sender, EventArgs e)
        {
            p12Ab.BackColor = Color.FromName(color);
        }

        private void p12C_Click(object sender, EventArgs e)
        {
            p12C.BackColor = Color.FromName(color);
        }

        private void p12D_Click(object sender, EventArgs e)
        {
            p12D.BackColor = Color.FromName(color);
        }

        private void p12I_Click(object sender, EventArgs e)
        {
            p12I.BackColor = Color.FromName(color);
        }

        private void p13A_Click(object sender, EventArgs e)
        {
            p13A.BackColor = Color.FromName(color);
        }

        private void p13Ab_Click(object sender, EventArgs e)
        {
            p13Ab.BackColor = Color.FromName(color);
        }

        private void p13C_Click(object sender, EventArgs e)
        {
            p13C.BackColor = Color.FromName(color);
        }

        private void p13D_Click(object sender, EventArgs e)
        {
            p13D.BackColor = Color.FromName(color);
        }

        private void p13I_Click(object sender, EventArgs e)
        {
            p13I.BackColor = Color.FromName(color);
        }

        private void p14A_Click(object sender, EventArgs e)
        {
            p14A.BackColor = Color.FromName(color);
        }

        private void p14Ab_Click(object sender, EventArgs e)
        {
            p14Ab.BackColor = Color.FromName(color);
        }

        private void p14C_Click(object sender, EventArgs e)
        {
            p14C.BackColor = Color.FromName(color);
        }

        private void p14D_Click(object sender, EventArgs e)
        {
            p14D.BackColor = Color.FromName(color);
        }

        private void p14I_Click(object sender, EventArgs e)
        {
            p14I.BackColor = Color.FromName(color);
        }

        private void p15A_Click(object sender, EventArgs e)
        {
            p15A.BackColor = Color.FromName(color);
        }

        private void p15Ab_Click(object sender, EventArgs e)
        {
            p15Ab.BackColor = Color.FromName(color);
        }

        private void p15C_Click(object sender, EventArgs e)
        {
            p15C.BackColor = Color.FromName(color);
        }

        private void p15D_Click(object sender, EventArgs e)
        {
            p15D.BackColor = Color.FromName(color);
        }

        private void p15I_Click(object sender, EventArgs e)
        {
            p15I.BackColor = Color.FromName(color);
        }

        private void p16A_Click(object sender, EventArgs e)
        {
            p16A.BackColor = Color.FromName(color);
        }

        private void p16Ab_Click(object sender, EventArgs e)
        {
            p16Ab.BackColor = Color.FromName(color);
        }

        private void p16C_Click(object sender, EventArgs e)
        {
            p16C.BackColor = Color.FromName(color);
        }

        private void p16D_Click(object sender, EventArgs e)
        {
            p16D.BackColor = Color.FromName(color);
        }

        private void p16I_Click(object sender, EventArgs e)
        {
            p16I.BackColor = Color.FromName(color);
        }

        private void p17A_Click(object sender, EventArgs e)
        {
            p17A.BackColor = Color.FromName(color);
        }

        private void p17Ab_Click(object sender, EventArgs e)
        {
            p17Ab.BackColor = Color.FromName(color);
        }

        private void p17C_Click(object sender, EventArgs e)
        {
            p17C.BackColor = Color.FromName(color);
        }

        private void p17D_Click(object sender, EventArgs e)
        {
            p17D.BackColor = Color.FromName(color);
        }

        private void p17I_Click(object sender, EventArgs e)
        {
            p17I.BackColor = Color.FromName(color);
        }

        private void p18A_Click(object sender, EventArgs e)
        {
            p18A.BackColor = Color.FromName(color);
        }

        private void p18Ab_Click(object sender, EventArgs e)
        {
            p18Ab.BackColor = Color.FromName(color);
        }

        private void p18C_Click(object sender, EventArgs e)
        {
            p18C.BackColor = Color.FromName(color);
        }

        private void p18D_Click(object sender, EventArgs e)
        {
            p18D.BackColor = Color.FromName(color);
        }

        private void p18I_Click(object sender, EventArgs e)
        {
            p18I.BackColor = Color.FromName(color);
        }
        private void p28A_Click(object sender, EventArgs e)
        {
            p28A.BackColor = Color.FromName(color);
        }

        private void p28Ab_Click(object sender, EventArgs e)
        {
            p28Ab.BackColor = Color.FromName(color);
        }

        private void p28C_Click(object sender, EventArgs e)
        {
            p28C.BackColor = Color.FromName(color);
        }

        private void p28D_Click(object sender, EventArgs e)
        {
            p28D.BackColor = Color.FromName(color);
        }

        private void p28I_Click(object sender, EventArgs e)
        {
            p28I.BackColor = Color.FromName(color);
        }

        private void p27A_Click(object sender, EventArgs e)
        {
            p27A.BackColor = Color.FromName(color);
        }

        private void p27Ab_Click(object sender, EventArgs e)
        {
            p27Ab.BackColor = Color.FromName(color);
        }

        private void p27C_Click(object sender, EventArgs e)
        {
            p27C.BackColor = Color.FromName(color);
        }

        private void p27D_Click(object sender, EventArgs e)
        {
            p27D.BackColor = Color.FromName(color);
        }

        private void p27I_Click(object sender, EventArgs e)
        {
            p27I.BackColor = Color.FromName(color);
        }

        private void p26A_Click(object sender, EventArgs e)
        {
            p26A.BackColor = Color.FromName(color);
        }

        private void p26Ab_Click(object sender, EventArgs e)
        {
            p26Ab.BackColor = Color.FromName(color);
        }

        private void p26C_Click(object sender, EventArgs e)
        {
            p26C.BackColor = Color.FromName(color);
        }

        private void p26D_Click(object sender, EventArgs e)
        {
            p26D.BackColor = Color.FromName(color);
        }

        private void p26I_Click(object sender, EventArgs e)
        {
            p26I.BackColor = Color.FromName(color);
        }

        private void p25A_Click(object sender, EventArgs e)
        {
            p25A.BackColor = Color.FromName(color);
        }

        private void p25Ab_Click(object sender, EventArgs e)
        {
            p25Ab.BackColor = Color.FromName(color);
        }

        private void p25C_Click(object sender, EventArgs e)
        {
            p25C.BackColor = Color.FromName(color);
        }

        private void p25D_Click(object sender, EventArgs e)
        {
            p25D.BackColor = Color.FromName(color);
        }

        private void p25I_Click(object sender, EventArgs e)
        {
            p25I.BackColor = Color.FromName(color);
        }

        private void p24A_Click(object sender, EventArgs e)
        {
            p24A.BackColor = Color.FromName(color);
        }

        private void p24Ab_Click(object sender, EventArgs e)
        {
            p24Ab.BackColor = Color.FromName(color);
        }

        private void p24D_Click(object sender, EventArgs e)
        {
            p24D.BackColor = Color.FromName(color);
        }

        private void p24I_Click(object sender, EventArgs e)
        {
            p24I.BackColor = Color.FromName(color);
        }

        private void p24C_Click(object sender, EventArgs e)
        {
            p24C.BackColor = Color.FromName(color);
        }

        private void p23A_Click(object sender, EventArgs e)
        {
            p23A.BackColor = Color.FromName(color);
        }

        private void p23Ab_Click(object sender, EventArgs e)
        {
            p23Ab.BackColor = Color.FromName(color);
        }

        private void p23C_Click(object sender, EventArgs e)
        {
            p23C.BackColor = Color.FromName(color);
        }

        private void p23D_Click(object sender, EventArgs e)
        {
            p23D.BackColor = Color.FromName(color);
        }

        private void p23I_Click(object sender, EventArgs e)
        {
            p23I.BackColor = Color.FromName(color);
        }

        private void p22A_Click(object sender, EventArgs e)
        {
            p22A.BackColor = Color.FromName(color);
        }

        private void p22Ab_Click(object sender, EventArgs e)
        {
            p22Ab.BackColor = Color.FromName(color);
        }

        private void p22C_Click(object sender, EventArgs e)
        {
            p22C.BackColor = Color.FromName(color);
        }

        private void p22D_Click(object sender, EventArgs e)
        {
            p22D.BackColor = Color.FromName(color);
        }

        private void p22I_Click(object sender, EventArgs e)
        {
            p22I.BackColor = Color.FromName(color);
        }

        private void p21A_Click(object sender, EventArgs e)
        {
            p21A.BackColor = Color.FromName(color);
        }

        private void p21Ab_Click(object sender, EventArgs e)
        {
            p21Ab.BackColor = Color.FromName(color);
        }

        private void p21C_Click(object sender, EventArgs e)
        {
            p21C.BackColor = Color.FromName(color);
        }

        private void p21D_Click(object sender, EventArgs e)
        {
            p21D.BackColor = Color.FromName(color);
        }

        private void p21I_Click(object sender, EventArgs e)
        {
            p21I.BackColor = Color.FromName(color);
        }

        private void p31A_Click(object sender, EventArgs e)
        {
            p31A.BackColor = Color.FromName(color);
        }

        private void p31Ab_Click(object sender, EventArgs e)
        {
            p31Ab.BackColor = Color.FromName(color);
        }

        private void p31C_Click(object sender, EventArgs e)
        {
            p31C.BackColor = Color.FromName(color);
        }

        private void p31D_Click(object sender, EventArgs e)
        {
            p31D.BackColor = Color.FromName(color);
        }

        private void p31I_Click(object sender, EventArgs e)
        {
            p31I.BackColor = Color.FromName(color);
        }

        private void p32A_Click(object sender, EventArgs e)
        {
            p32A.BackColor = Color.FromName(color);
        }

        private void p32Ab_Click(object sender, EventArgs e)
        {
            p32Ab.BackColor = Color.FromName(color);
        }

        private void p32C_Click(object sender, EventArgs e)
        {
            p32C.BackColor = Color.FromName(color);
        }

        private void p32D_Click(object sender, EventArgs e)
        {
            p32D.BackColor = Color.FromName(color);
        }

        private void p32I_Click(object sender, EventArgs e)
        {
            p32I.BackColor = Color.FromName(color);
        }

        private void p33A_Click(object sender, EventArgs e)
        {
            p33A.BackColor = Color.FromName(color);
        }

        private void p33Ab_Click(object sender, EventArgs e)
        {
            p33Ab.BackColor = Color.FromName(color);
        }

        private void p33C_Click(object sender, EventArgs e)
        {
            p33C.BackColor = Color.FromName(color);
        }

        private void p33D_Click(object sender, EventArgs e)
        {
            p33D.BackColor = Color.FromName(color);
        }

        private void p33I_Click(object sender, EventArgs e)
        {
            p33I.BackColor = Color.FromName(color);
        }

        private void p34A_Click(object sender, EventArgs e)
        {
            p34A.BackColor = Color.FromName(color);
        }

        private void p34Ab_Click(object sender, EventArgs e)
        {
            p34Ab.BackColor = Color.FromName(color);
        }

        private void p34C_Click(object sender, EventArgs e)
        {
            p34C.BackColor = Color.FromName(color);
        }

        private void p34D_Click(object sender, EventArgs e)
        {
            p34D.BackColor = Color.FromName(color);
        }

        private void p34I_Click(object sender, EventArgs e)
        {
            p34I.BackColor = Color.FromName(color);
        }

        private void p35A_Click(object sender, EventArgs e)
        {
            p35A.BackColor = Color.FromName(color);
        }

        private void p35Ab_Click(object sender, EventArgs e)
        {
            p35Ab.BackColor = Color.FromName(color);
        }

        private void p35C_Click(object sender, EventArgs e)
        {
            p35C.BackColor = Color.FromName(color);
        }

        private void p35D_Click(object sender, EventArgs e)
        {
            p35D.BackColor = Color.FromName(color);
        }

        private void p35I_Click(object sender, EventArgs e)
        {
            p35I.BackColor = Color.FromName(color);
        }

        private void p36A_Click(object sender, EventArgs e)
        {
            p36A.BackColor = Color.FromName(color);
        }

        private void p36Ab_Click(object sender, EventArgs e)
        {
            p36Ab.BackColor = Color.FromName(color);
        }

        private void p36C_Click(object sender, EventArgs e)
        {
            p36C.BackColor = Color.FromName(color);
        }

        private void p36D_Click(object sender, EventArgs e)
        {
            p36D.BackColor = Color.FromName(color);
        }

        private void p36I_Click(object sender, EventArgs e)
        {
            p36I.BackColor = Color.FromName(color);
        }

        private void p37A_Click(object sender, EventArgs e)
        {
            p37A.BackColor = Color.FromName(color);
        }

        private void p37Ab_Click(object sender, EventArgs e)
        {
            p37Ab.BackColor = Color.FromName(color);
        }

        private void p37C_Click(object sender, EventArgs e)
        {
            p37C.BackColor = Color.FromName(color);
        }

        private void p37D_Click(object sender, EventArgs e)
        {
            p37D.BackColor = Color.FromName(color);
        }

        private void p37I_Click(object sender, EventArgs e)
        {
            p37I.BackColor = Color.FromName(color);
        }

        private void p38A_Click(object sender, EventArgs e)
        {
            p38A.BackColor = Color.FromName(color);
        }

        private void p38Ab_Click(object sender, EventArgs e)
        {
            p38Ab.BackColor = Color.FromName(color);
        }

        private void p38C_Click(object sender, EventArgs e)
        {
            p38C.BackColor = Color.FromName(color);
        }

        private void p38D_Click(object sender, EventArgs e)
        {
            p38D.BackColor = Color.FromName(color);
        }

        private void p38I_Click(object sender, EventArgs e)
        {
            p38I.BackColor = Color.FromName(color);
        }

        private void p41A_Click(object sender, EventArgs e)
        {
            p41A.BackColor = Color.FromName(color);
        }

        private void p41Ab_Click(object sender, EventArgs e)
        {
            p41Ab.BackColor = Color.FromName(color);
        }

        private void p41C_Click(object sender, EventArgs e)
        {
            p41C.BackColor = Color.FromName(color);
        }

        private void p41D_Click(object sender, EventArgs e)
        {
            p41D.BackColor = Color.FromName(color);
        }

        private void p41I_Click(object sender, EventArgs e)
        {
            p41I.BackColor = Color.FromName(color);
        }

        private void p42A_Click(object sender, EventArgs e)
        {
            p42A.BackColor = Color.FromName(color);
        }

        private void p42Ab_Click(object sender, EventArgs e)
        {
            p42Ab.BackColor = Color.FromName(color);
        }

        private void p42C_Click(object sender, EventArgs e)
        {
            p42C.BackColor = Color.FromName(color);
        }

        private void p42D_Click(object sender, EventArgs e)
        {
            p42D.BackColor = Color.FromName(color);
        }

        private void p42I_Click(object sender, EventArgs e)
        {
            p42I.BackColor = Color.FromName(color);
        }

        private void p43A_Click(object sender, EventArgs e)
        {
            p43A.BackColor = Color.FromName(color);
        }

        private void p43Ab_Click(object sender, EventArgs e)
        {
            p43Ab.BackColor = Color.FromName(color);
        }

        private void p43C_Click(object sender, EventArgs e)
        {
            p43C.BackColor = Color.FromName(color);
        }

        private void p43D_Click(object sender, EventArgs e)
        {
            p43D.BackColor = Color.FromName(color);
        }

        private void p43I_Click(object sender, EventArgs e)
        {
            p43I.BackColor = Color.FromName(color);
        }

        private void p44A_Click(object sender, EventArgs e)
        {
            p44A.BackColor = Color.FromName(color);
        }

        private void p44Ab_Click(object sender, EventArgs e)
        {
            p44Ab.BackColor = Color.FromName(color);
        }

        private void p44D_Click(object sender, EventArgs e)
        {
            p44D.BackColor = Color.FromName(color);
        }

        private void p44C_Click(object sender, EventArgs e)
        {
            p44C.BackColor = Color.FromName(color);
        }

        private void p44I_Click(object sender, EventArgs e)
        {
            p44I.BackColor = Color.FromName(color);
        }

        private void p45A_Click(object sender, EventArgs e)
        {
            p45A.BackColor = Color.FromName(color);
        }

        private void p45Ab_Click(object sender, EventArgs e)
        {
            p45Ab.BackColor = Color.FromName(color);
        }

        private void p45C_Click(object sender, EventArgs e)
        {
            p45C.BackColor = Color.FromName(color);
        }

        private void p45D_Click(object sender, EventArgs e)
        {
            p45D.BackColor = Color.FromName(color);
        }

        private void p45I_Click(object sender, EventArgs e)
        {
            p45I.BackColor = Color.FromName(color);
        }

        private void p46A_Click(object sender, EventArgs e)
        {
            p46A.BackColor = Color.FromName(color);
        }

        private void p46Ab_Click(object sender, EventArgs e)
        {
            p46Ab.BackColor = Color.FromName(color);
        }

        private void p46C_Click(object sender, EventArgs e)
        {
            p46C.BackColor = Color.FromName(color);
        }

        private void p46D_Click(object sender, EventArgs e)
        {
            p46D.BackColor = Color.FromName(color);
        }

        private void p46I_Click(object sender, EventArgs e)
        {
            p46I.BackColor = Color.FromName(color);
        }

        private void p47A_Click(object sender, EventArgs e)
        {
            p47A.BackColor = Color.FromName(color);
        }

        private void p47Ab_Click(object sender, EventArgs e)
        {
            p47Ab.BackColor = Color.FromName(color);
        }

        private void p47C_Click(object sender, EventArgs e)
        {
            p47C.BackColor = Color.FromName(color);
        }

        private void p47D_Click(object sender, EventArgs e)
        {
            p47D.BackColor = Color.FromName(color);
        }

        private void p47I_Click(object sender, EventArgs e)
        {
            p47I.BackColor = Color.FromName(color);
        }

        private void p48A_Click(object sender, EventArgs e)
        {
            p48A.BackColor = Color.FromName(color);
        }

        private void p48Ab_Click(object sender, EventArgs e)
        {
            p48Ab.BackColor = Color.FromName(color);
        }

        private void p48C_Click(object sender, EventArgs e)
        {
            p48C.BackColor = Color.FromName(color);
        }

        private void p48D_Click(object sender, EventArgs e)
        {
            p48D.BackColor = Color.FromName(color);
        }

        private void p48I_Click(object sender, EventArgs e)
        {
            p48I.BackColor = Color.FromName(color);
        }

        private void p51A_Click(object sender, EventArgs e)
        {
            p51A.BackColor = Color.FromName(color);
        }

        private void p51Ab_Click(object sender, EventArgs e)
        {
            p51Ab.BackColor = Color.FromName(color);
        }

        private void p51C_Click(object sender, EventArgs e)
        {
            p51C.BackColor = Color.FromName(color);
        }

        private void p51D_Click(object sender, EventArgs e)
        {
            p51D.BackColor = Color.FromName(color);
        }

        private void p51I_Click(object sender, EventArgs e)
        {
            p51I.BackColor = Color.FromName(color);
        }

        private void p52A_Click(object sender, EventArgs e)
        {
            p52A.BackColor = Color.FromName(color);
        }

        private void p52Ab_Click(object sender, EventArgs e)
        {
            p52Ab.BackColor = Color.FromName(color);
        }

        private void p52C_Click(object sender, EventArgs e)
        {
            p52C.BackColor = Color.FromName(color);
        }

        private void p52D_Click(object sender, EventArgs e)
        {
            p52D.BackColor = Color.FromName(color);
        }

        private void p52I_Click(object sender, EventArgs e)
        {
            p52I.BackColor = Color.FromName(color);
        }

        private void p53A_Click(object sender, EventArgs e)
        {
            p53A.BackColor = Color.FromName(color);
        }

        private void p53Ab_Click(object sender, EventArgs e)
        {
            p53Ab.BackColor = Color.FromName(color);
        }

        private void p53C_Click(object sender, EventArgs e)
        {
            p53C.BackColor = Color.FromName(color);
        }

        private void p53D_Click(object sender, EventArgs e)
        {
            p53D.BackColor = Color.FromName(color);
        }

        private void p53I_Click(object sender, EventArgs e)
        {
            p53I.BackColor = Color.FromName(color);
        }

        private void p54A_Click(object sender, EventArgs e)
        {
            p54A.BackColor = Color.FromName(color);
        }

        private void p54Ab_Click(object sender, EventArgs e)
        {
            p54Ab.BackColor = Color.FromName(color);
        }

        private void p54C_Click(object sender, EventArgs e)
        {
            p54C.BackColor = Color.FromName(color);
        }

        private void p54D_Click(object sender, EventArgs e)
        {
            p54D.BackColor = Color.FromName(color);
        }

        private void p54I_Click(object sender, EventArgs e)
        {
            p54I.BackColor = Color.FromName(color);
        }

        private void p55A_Click(object sender, EventArgs e)
        {
            p55A.BackColor = Color.FromName(color);
        }

        private void p55Ab_Click(object sender, EventArgs e)
        {
            p55Ab.BackColor = Color.FromName(color);
        }

        private void p55C_Click(object sender, EventArgs e)
        {
            p55C.BackColor = Color.FromName(color);
        }

        private void p55D_Click(object sender, EventArgs e)
        {
            p55D.BackColor = Color.FromName(color);
        }

        private void p55I_Click(object sender, EventArgs e)
        {
            p55I.BackColor = Color.FromName(color);
        }

        private void p61A_Click(object sender, EventArgs e)
        {
            p61A.BackColor = Color.FromName(color);
        }

        private void p61Ab_Click(object sender, EventArgs e)
        {
            p61Ab.BackColor = Color.FromName(color);
        }

        private void p61C_Click(object sender, EventArgs e)
        {
            p61C.BackColor = Color.FromName(color);
        }

        private void p61D_Click(object sender, EventArgs e)
        {
            p61D.BackColor = Color.FromName(color);
        }

        private void p61I_Click(object sender, EventArgs e)
        {
            p61I.BackColor = Color.FromName(color);
        }

        private void p62A_Click(object sender, EventArgs e)
        {
            p62A.BackColor = Color.FromName(color);
        }

        private void p62Ab_Click(object sender, EventArgs e)
        {
            p62Ab.BackColor = Color.FromName(color);
        }

        private void p62C_Click(object sender, EventArgs e)
        {
            p62C.BackColor = Color.FromName(color);
        }

        private void p62D_Click(object sender, EventArgs e)
        {
            p62D.BackColor = Color.FromName(color);
        }

        private void p62I_Click(object sender, EventArgs e)
        {
            p62I.BackColor = Color.FromName(color);
        }

        private void p63A_Click(object sender, EventArgs e)
        {
            p63A.BackColor = Color.FromName(color);
        }

        private void p63Ab_Click(object sender, EventArgs e)
        {
            p63Ab.BackColor = Color.FromName(color);
        }

        private void p63C_Click(object sender, EventArgs e)
        {
            p63C.BackColor = Color.FromName(color);
        }

        private void p63D_Click(object sender, EventArgs e)
        {
            p63D.BackColor = Color.FromName(color);
        }

        private void p63I_Click(object sender, EventArgs e)
        {
            p63I.BackColor = Color.FromName(color);
        }

        private void p64A_Click(object sender, EventArgs e)
        {
            p64A.BackColor = Color.FromName(color);
        }

        private void p64Ab_Click(object sender, EventArgs e)
        {
            p64Ab.BackColor = Color.FromName(color);
        }

        private void p64C_Click(object sender, EventArgs e)
        {
            p64C.BackColor = Color.FromName(color);
        }

        private void p64D_Click(object sender, EventArgs e)
        {
            p64D.BackColor = Color.FromName(color);
        }

        private void p64I_Click(object sender, EventArgs e)
        {
            p64I.BackColor = Color.FromName(color);
        }

        private void p65A_Click(object sender, EventArgs e)
        {
            p65A.BackColor = Color.FromName(color);
        }

        private void p65Ab_Click(object sender, EventArgs e)
        {
            p65Ab.BackColor = Color.FromName(color);
        }

        private void p65C_Click(object sender, EventArgs e)
        {
            p65C.BackColor = Color.FromName(color);
        }

        private void p65D_Click(object sender, EventArgs e)
        {
            p65D.BackColor = Color.FromName(color);
        }

        private void p65I_Click(object sender, EventArgs e)
        {
            p65I.BackColor = Color.FromName(color);
        }

        private void p71A_Click(object sender, EventArgs e)
        {
            p71A.BackColor = Color.FromName(color);
        }

        private void p71Ab_Click(object sender, EventArgs e)
        {
            p71Ab.BackColor = Color.FromName(color);
        }

        private void p71C_Click(object sender, EventArgs e)
        {
            p71C.BackColor = Color.FromName(color);
        }

        private void p71D_Click(object sender, EventArgs e)
        {
            p71D.BackColor = Color.FromName(color);
        }

        private void p71I_Click(object sender, EventArgs e)
        {
            p71I.BackColor = Color.FromName(color);
        }

        private void p72A_Click(object sender, EventArgs e)
        {
            p72A.BackColor = Color.FromName(color);
        }

        private void p72Ab_Click(object sender, EventArgs e)
        {
            p72Ab.BackColor = Color.FromName(color);
        }

        private void p72C_Click(object sender, EventArgs e)
        {
            p72C.BackColor = Color.FromName(color);
        }

        private void p72D_Click(object sender, EventArgs e)
        {
            p72D.BackColor = Color.FromName(color);
        }

        private void p72I_Click(object sender, EventArgs e)
        {
            p72I.BackColor = Color.FromName(color);
        }

        private void p73A_Click(object sender, EventArgs e)
        {
            p73A.BackColor = Color.FromName(color);
        }

        private void p73Ab_Click(object sender, EventArgs e)
        {
            p73Ab.BackColor = Color.FromName(color);
        }

        private void p73C_Click(object sender, EventArgs e)
        {
            p73C.BackColor = Color.FromName(color);
        }

        private void p73D_Click(object sender, EventArgs e)
        {
            p73D.BackColor = Color.FromName(color);
        }

        private void p73I_Click(object sender, EventArgs e)
        {
            p73I.BackColor = Color.FromName(color);
        }

        private void p74A_Click(object sender, EventArgs e)
        {
            p74A.BackColor = Color.FromName(color);
        }

        private void p74Ab_Click(object sender, EventArgs e)
        {
            p74Ab.BackColor = Color.FromName(color);
        }

        private void p74C_Click(object sender, EventArgs e)
        {
            p74C.BackColor = Color.FromName(color);
        }

        private void p74D_Click(object sender, EventArgs e)
        {
            p74D.BackColor = Color.FromName(color);
        }

        private void p74I_Click(object sender, EventArgs e)
        {
            p74I.BackColor = Color.FromName(color);
        }

        private void p75D_Click(object sender, EventArgs e)
        {
            p75D.BackColor = Color.FromName(color);
        }

        private void p75A_Click(object sender, EventArgs e)
        {
            p75A.BackColor = Color.FromName(color);
        }

        private void p75Ab_Click(object sender, EventArgs e)
        {
            p75Ab.BackColor = Color.FromName(color);
        }

        private void p75C_Click(object sender, EventArgs e)
        {
            p75C.BackColor = Color.FromName(color);
        }

        private void p75I_Click(object sender, EventArgs e)
        {
            p75I.BackColor = Color.FromName(color);
        }

        private void p85A_Click(object sender, EventArgs e)
        {
            p85A.BackColor = Color.FromName(color);
        }

        private void p85Ab_Click(object sender, EventArgs e)
        {
            p85Ab.BackColor = Color.FromName(color);
        }

        private void p85C_Click(object sender, EventArgs e)
        {
            p85C.BackColor = Color.FromName(color);
        }

        private void p85D_Click(object sender, EventArgs e)
        {
            p85D.BackColor = Color.FromName(color);
        }

        private void p85I_Click(object sender, EventArgs e)
        {
            p85I.BackColor = Color.FromName(color);
        }

        private void p84A_Click(object sender, EventArgs e)
        {
            p84A.BackColor = Color.FromName(color);
        }

        private void p84Ab_Click(object sender, EventArgs e)
        {
            p84Ab.BackColor = Color.FromName(color);
        }

        private void p84C_Click(object sender, EventArgs e)
        {
            p84C.BackColor = Color.FromName(color);
        }

        private void p84D_Click(object sender, EventArgs e)
        {
            p84D.BackColor = Color.FromName(color);
        }

        private void p84I_Click(object sender, EventArgs e)
        {
            p84I.BackColor = Color.FromName(color);
        }

        private void p83A_Click(object sender, EventArgs e)
        {
            p83A.BackColor = Color.FromName(color);
        }

        private void p83Ab_Click(object sender, EventArgs e)
        {
            p83Ab.BackColor = Color.FromName(color);
        }

        private void p83C_Click(object sender, EventArgs e)
        {
            p83C.BackColor = Color.FromName(color);
        }

        private void p83D_Click(object sender, EventArgs e)
        {
            p83D.BackColor = Color.FromName(color);
        }

        private void p83I_Click(object sender, EventArgs e)
        {
            p83I.BackColor = Color.FromName(color);
        }

        private void p82A_Click(object sender, EventArgs e)
        {
            p82A.BackColor = Color.FromName(color);
        }

        private void p82Ab_Click(object sender, EventArgs e)
        {
            p82Ab.BackColor = Color.FromName(color);
        }

        private void p82C_Click(object sender, EventArgs e)
        {
            p82C.BackColor = Color.FromName(color);
        }

        private void p82D_Click(object sender, EventArgs e)
        {
            p82D.BackColor = Color.FromName(color);
        }

        private void p82I_Click(object sender, EventArgs e)
        {
            p82I.BackColor = Color.FromName(color);
        }

        private void p81A_Click(object sender, EventArgs e)
        {
            p81A.BackColor = Color.FromName(color);
        }

        private void p81Ab_Click(object sender, EventArgs e)
        {
            p81Ab.BackColor = Color.FromName(color);
        }

        private void p81C_Click(object sender, EventArgs e)
        {
            p81C.BackColor = Color.FromName(color);
        }

        private void p81D_Click(object sender, EventArgs e)
        {
            p81D.BackColor = Color.FromName(color);
        }

        private void p81I_Click(object sender, EventArgs e)
        {
            p81I.BackColor = Color.FromName(color);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                historiaClinica.TratamientoMedicoActual = txtMotivo.Text;
                historiaClinica.TomaMedicamentoActual = txtMedicamento.Text;
                historiaClinica.Observaciones = txtHObservaciones.Text;
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
                int lazo        = 1;
                int numeroPieza = 11;
                while (lazo <= 52)
                {
                    piezaDental = new PiezaDental();
                    piezaDental.NumeroPieza = numeroPieza;
                    
                        
                }
            }
            catch(Exception exep)
            {
                MessageBox.Show(exep.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FrmPrincipal frmPrincipal = Owner as FrmPrincipal;
            FrmInicio frmInicio = new FrmInicio();
            frmPrincipal.abrirFormHijo(frmInicio);
        }
    }
}
