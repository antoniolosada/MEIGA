using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MEIGA_CFG
{
    public partial class Form1 : Form
    {
        static Form1 sFrm;
        const int MIN_MENSAJE = 39;
        const int PARADO = 0;
        const int ARRANCADO = 1;
        const int MAX_MEJILLA = 4096;
        const int MAX_ALABEO =  4096;
        const int MAX_POS_X =   4096;
        const int MAX_POS_Y =   4096;
        const int MULT_MEJILLA =    3;
        const int MULT_ALABEO =     300;
        const int MULT_POS_X =      3;
        const int MULT_POS_Y =      3;
        const bool DECIMAL_COMA = true;
        const int MAX_LOG = 2000;
        const int MAX_MULTIPLICADOR = 10;
        const int MAX_PULSACION = 10000;
        const int MAX_TIEMPO_SCROLL = 2000;

        int giEstado;
        SerialPort PuertoSerie;
        SerialPort PuertoScan;
        static string TextoCom = "";
        static string UltimoComando = "";
        static float UltPosX = 0;
        static float UltPosY = 0;

        public Form1()
        {
            InitializeComponent();
            sFrm = this;
            // Create a new SerialPort object with default settings.
            PuertoSerie = new SerialPort();
            cbCfgModo.SelectedIndex = 0;
        }

        private void btConectar_Click(object sender, EventArgs e)
        {
            ConectarArduino();
            btConectar.Enabled = false;
            btDesconectar.Enabled = true;
            btGrabar.Enabled = true;    
            btLeerCfg.Enabled = true;
            DesactivarCampos(false);
        }
        private void ConectarArduino()
        {
            try
            {
                if (giEstado == PARADO)
                {
                    giEstado = ARRANCADO;
                    cbPuerto.BackColor = Color.LightGreen;

                    // Allow the user to set the appropriate properties.
                    PuertoSerie.PortName = cbPuerto.Text;
                    PuertoSerie.BaudRate = 115200;
                    PuertoSerie.Parity = Parity.None;
                    PuertoSerie.DataBits = 8;
                    PuertoSerie.StopBits = StopBits.One;
                    PuertoSerie.Handshake = Handshake.None;

                    // Set the read/write timeouts
                    PuertoSerie.ReadTimeout = 500;
                    PuertoSerie.WriteTimeout = 500;

                    PuertoSerie.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
                    PuertoSerie.Open();

                    tmrLeerDatosArduino.Enabled = true;

                    cbPuerto.BackColor = Color.Green;
                }
            }
            catch (Exception ex)
            {
                cbPuerto.BackColor = Color.Red;
            }
        }

        private static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string entradaDatos = sp.ReadExisting(); // Almacena los datos recibidos en la variable tipo string.
            TextoCom = TextoCom + entradaDatos;
            string comando = sFrm.RecuperarComando();
            if (comando != "")
            {
                if (UltimoComando.Length > 1)
                    if (UltimoComando.Substring(0, 1) == "@")
                        return;
                UltimoComando = comando;
                TextoCom = "";
            } 
        }

        private void tmrLeerDatosArduino_Tick(object sender, EventArgs e)
        {
            if (UltimoComando != "")
            {
                tbComando.Text = UltimoComando;
                tbComando.Refresh();
                UltimoComando = "";
                ProcesarComando(tbComando.Text);
            }
        }
        private void ProcesarComando(string Comando)
        {
            string Valor = "";
            if (Comando.Length > MIN_MENSAJE)
                if (Comando.Substring(1, 6) == "Pos X:")
                {
                    string s = RecuperarValor(Comando, "X:");
                    if (DECIMAL_COMA) s = s.Replace(".", ",");
                    tbPosX.Text = Math.Round(Math.Abs(UltPosX - float.Parse(s)),3).ToString();
                    barPosX.Value = Math.Abs(AsignarBarra(tbPosX.Text, MAX_POS_X, MULT_POS_X));
                    UltPosX = float.Parse(s);

                    s = RecuperarValor(Comando, "Y:");
                    if (DECIMAL_COMA) s = s.Replace(".", ",");
                    tbPosY.Text = Math.Round(Math.Abs(UltPosY - float.Parse(s)),3).ToString();
                    barPosY.Value = Math.Abs(AsignarBarra(tbPosY.Text, MAX_POS_Y, MULT_POS_Y));
                    UltPosY = float.Parse(s);


                    tbMejilla.Text = RecuperarValor(Comando, "mejilla:");
                    barMejilla.Value = Math.Abs(AsignarBarra(tbMejilla.Text, MAX_MEJILLA, MULT_MEJILLA));
                    if (DECIMAL_COMA) Valor = tbMejilla.Text.Replace(".", ",");
                    if (Math.Abs(double.Parse(Valor)) > int.Parse(tbPulsacionADC.Text))
                        lblMEjilla.BackColor = Color.LightGreen;
                    else
                        lblMEjilla.BackColor = Color.LightYellow;

                    tbFiltroAlabeo.Text = RecuperarValor(Comando, "FiltroAlabeo:");
                    Valor = tbFiltroAlabeo.Text;
                    if (DECIMAL_COMA) Valor = Valor.Replace(".", ",");
                    double valor = double.Parse(Valor);
                    int v = Math.Abs(AsignarBarra(Valor, MAX_ALABEO, MULT_ALABEO));

                    bool Scroll = false;
                    if (((valor < float.Parse(tbAlabeoMaxNeg.Text)) && (valor > float.Parse(tbAlabeoMinNeg.Text))) ||
                         ((valor < float.Parse(tbAlabeoMaxPos.Text)) && (valor > float.Parse(tbAlabeoMinPos.Text)))
                       ) Scroll = true;

                    if (valor > 0)
                    {
                        barAlabeoNeg.Value = v;
                        barAlabeoPos.Value = 0;
                        if (Scroll)
                            lblAlabeoNeg.BackColor = Color.LightGreen;
                        else
                            lblAlabeoNeg.BackColor = Color.LightYellow;
                    }
                    else
                    {
                        barAlabeoPos.Value = v;
                        barAlabeoNeg.Value = 0;
                        if (Scroll)
                            lblAlabeoPos.BackColor = Color.LightGreen;
                        else
                            lblAlabeoPos.BackColor = Color.LightYellow;
                    }
                }
                else if (Comando.Substring(0, 3) == "@#M")
                {
                    MessageBox.Show(Comando.Substring(4));
                }
                else if (Comando.Substring(0, 3) == "@#C")
                {
                    LeerConfiguracion(Comando.Substring(4));
                    MessageBox.Show("Configuración recuperada.");
                }
        }
        int v1 = 0;
        int lmax = 0;
        private int AsignarBarra(string Valor, int Max, int Mult)
        {
            if (DECIMAL_COMA) Valor = Valor.Replace(".", ",");
            double v = Mult * Double.Parse(Valor);
            if (Math.Abs(v) > Max) v = Max;
            return (int)v;
        }
        private string RecuperarValor(string Comando, string valor)
        {
            int pos = Comando.IndexOf(valor);

            if (pos > 0)
            {
                int pos1 = Comando.IndexOf(":", pos+valor.Length+1);
                return Comando.Substring(pos + valor.Length+1, pos1 - (pos + valor.Length+1));
            }
            return "";
        }
        private string RecuperarComando()
        {
            string lectura = TextoCom;
            int pos = lectura.IndexOf((char)10);
            string comando;
            if (pos > 0)
            {
                comando = lectura.Substring(0, pos-1);
                if (lectura.Length > pos + 1)
                    lectura = lectura.Substring(pos + 1);
                else
                    lectura = "";
                TextoCom = lectura;
                return comando;
            }
            return "";
        }
        private void btDesconectar_Click(object sender, EventArgs e)
        {
            PuertoSerie.Close();
            cbPuerto.BackColor = Color.Red;
            //btConectar.Enabled = true;
            btDesconectar.Enabled = false;
            btGrabar.Enabled = false;
            btLeerCfg.Enabled = false;
            DesactivarCampos(true);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        void EnviarCodigo(string sCodigo, int iValor)
        {
            string sCad = "";
            if ((giEstado == ARRANCADO))
            {
                EscribirComCRC((":"+ (sCodigo+ (iValor + ";."))));
                Application.DoEvents();
                if (((sCodigo == "c") && (iValor == 1)))
                {
                    Application.DoEvents();
                }

            }

        }
        void EscribirComCRC(string cad)
        {
            char car;
            long CRC = 0;
            try
            {
                for (int i = 0; (i<= (cad.Length - 2)); i++)
                {
                    car = cad.Substring(i, 1).ToCharArray()[0];
                    CRC = (CRC + (int)car);
                }

                CRC = (CRC % 100);
                PuertoSerie.WriteLine("@" + (CRC + cad));
            }
            catch (Exception ex)
            {
                Console.WriteLine(("EscribirComCRC: " + ex.Message));
            }
        }
        private bool ComprobarCampo(string c)
        {
            string CarValidos = "1234567890-,";

            if (c.Intersect(CarValidos).Count() != c.Length)
                return false;
            else
                return true;
        }
        bool ErrorCampo = false;
        private void btGrabar_Click(object sender, EventArgs e)
        {
            string Error = ComprobarValoresGrabar();

            if (Error != "")
            {
                MessageBox.Show(Error);
                return;
            }

            String v = "";
            v += tbMultiplicadorX.Text + ",";
            v += tbMultiplicadorY.Text + ",";
            v += tbPulsacionCorta.Text + ",";
            v += tbPulsacionMEdia.Text + ",";
            v += tbPulsacionLarga.Text + ",";
            v += Coma2Punto(tbPulsacionADC.Text) + ",";
            v += Coma2Punto(tbAlabeoMinNeg.Text) + ",";
            v += Coma2Punto(tbAlabeoMaxNeg.Text) + ",";
            v += Coma2Punto(tbAlabeoMinPos.Text) + ",";
            v += Coma2Punto(tbAlabeoMaxPos.Text) + ",";
            v += Coma2Punto(tbCorrecionAlabeoDer.Text ) + ",";
            v += tbTiempoMinScroll.Text + ",";
            v += (chkDireccion.Checked ? "1" : "-1") + ",";
            v += (chkPulsacion.Checked ? "1" : "0") + ",";
            v += (chkScroll.Checked ? "1" : "0") + ",";
            v += (chkMovimiento.Checked ? "1" : "0") + ",";
            v += (chkClicDer.Checked ? "1" : "0") + ",";
            v += (chkClicIzq.Checked ? "1" : "0") + ",";
            v += (chkClicCentro.Checked ? "1" : "0") + ",";
            v += (chkAcciones.Checked ? "1" : "0") + ",";
            v += (cbCfgModo.SelectedIndex) + ","; 

            EscribirComCRC(":G"+v.ToString()+"END;#");

            for (int i = 0; i < 300; i++) Thread.Yield();
            Thread.Sleep(1000);
            for (int i = 0; i < 300; i++) Thread.Yield();
            TextoCom = "";
        }

        private void btReiniciar_Click(object sender, EventArgs e)
        {
            EscribirComCRC(":R;#");
        }

        private string ComprobarValoresGrabar()
        {
            string Error = "";
            if ((ValorCampo(tbMultiplicadorX.Text) < 0) || (ValorCampo(tbMultiplicadorX.Text) > MAX_MULTIPLICADOR))
                Error = "Multiplicador X fuera de rango.";
            if ((ValorCampo(tbMultiplicadorY.Text) < 0) || (ValorCampo(tbMultiplicadorY.Text) > MAX_MULTIPLICADOR))
                Error = "Multiplicador Y fuera de rango.";
            if ((ValorCampo(tbPulsacionCorta.Text) < 10) || (ValorCampo(tbPulsacionCorta.Text) > MAX_PULSACION))
                Error = "Pulsacion corta fuera de rango. Se establece en milisegundos.";
            if ((ValorCampo(tbPulsacionMEdia.Text) < 10) || (ValorCampo(tbPulsacionMEdia.Text) > MAX_PULSACION))
                Error = "Pulsacion media fuera de rango. Se establece en milisegundos.";
            if ((ValorCampo(tbPulsacionLarga.Text) < 10) || (ValorCampo(tbPulsacionLarga.Text) > MAX_PULSACION))
                Error = "Pulsacion larga fuera de rango. Se establece en milisegundos.";
            if ((ValorCampo(tbPulsacionLarga.Text) < ValorCampo(tbPulsacionMEdia.Text)) || (ValorCampo(tbPulsacionMEdia.Text) < ValorCampo(tbPulsacionCorta.Text)))
                Error = "Valores incorrectos de tiempo de las pulsaciones: larga > medio > corta.";
            if ((ValorCampo(tbAlabeoMaxNeg.Text) < ValorCampo(tbAlabeoMinNeg.Text)) || (ValorCampo(tbAlabeoMinNeg.Text) > 0) || (ValorCampo(tbAlabeoMaxNeg.Text) > 0))
                Error = "Error en Alabeo negativo: AlabeoMaxNeg > AlabeoMinNeg y ambos deben ser negativos.";
            if ((ValorCampo(tbAlabeoMaxPos.Text) < ValorCampo(tbAlabeoMinPos.Text)) || (ValorCampo(tbAlabeoMinPos.Text) < 0) || (ValorCampo(tbAlabeoMaxPos.Text) < 0))
                Error = "Error en Alabeo positivo: AlabeoMaxPos > AlabeoMinPos y ambos deben ser positivos.";
            if ((ValorCampo(tbTiempoMinScroll.Text) < 0) || (ValorCampo(tbTiempoMinScroll.Text) > MAX_TIEMPO_SCROLL))
                Error = "Tiempo mínimo de scroll debe ser positivo y estar dentro de rango.";

            return Error;
        }
        private float ValorCampo(string c)
        {
            return float.Parse(c);
        }
        private bool itob(string v)
        {
            return (v.Substring(0,1) == "1" ? true : false);
        }

        private void btLeerCfg_Click(object sender, EventArgs e)
        {
            EscribirComCRC(":L;#");
            Thread.Sleep(1000);
            for (int i = 0; i < 300; i++) Thread.Yield();
            TextoCom = "";
        }
        private void LeerConfiguracion(string Comando)
        {
            string[] var = Comando.Split(',');

            tbMultiplicadorX.Text = var[0];
            tbMultiplicadorY.Text = var[1];
            tbPulsacionCorta.Text = var[2];
            tbPulsacionMEdia.Text = var[3];
            tbPulsacionLarga.Text = var[4];
            tbPulsacionADC.Text = var[5];
            tbAlabeoMinNeg.Text = Punto2Coma(var[6]);
            tbAlabeoMaxNeg.Text = Punto2Coma(var[7]);
            tbAlabeoMinPos.Text = Punto2Coma(var[8]);
            tbAlabeoMaxPos.Text = Punto2Coma(var[9]);
            tbCorrecionAlabeoDer.Text = Punto2Coma(var[10]);
            tbTiempoMinScroll.Text = var[11];
            chkDireccion.Checked = itob(var[12]);
            chkPulsacion.Checked = itob(var[13]);
            chkScroll.Checked = itob(var[14]);
            chkMovimiento.Checked = itob(var[15]);
            chkClicDer.Checked = itob(var[16]);
            chkClicIzq.Checked = itob(var[17]);
            chkClicCentro.Checked = itob(var[18]);
            chkAcciones.Checked = itob(var[19]);
            cbCfgModo.SelectedIndex = int.Parse(var[20]);
        }
        private string Coma2Punto(string c)
        {
            return c.Replace(",", ".");
        }
        private string Punto2Coma(string c)
        {
            return c.Replace(".", ",");
        }
        private void DesactivarCampos(bool e)
        {
            tbMultiplicadorX.Enabled = e;
            tbMultiplicadorY.Enabled = e;
            tbPulsacionADC.Enabled = e;
            tbPulsacionCorta.Enabled = e;   
            tbPulsacionLarga.Enabled = e;
            tbPulsacionMEdia.Enabled = e;
            tbMargenAlabeo.Enabled = e;
            tbAlabeoMaxNeg.Enabled = e;
            tbAlabeoMinNeg.Enabled = e;
            tbAlabeoMaxPos.Enabled = e;
            tbAlabeoMinPos.Enabled = e;
            tbCorrecionAlabeoDer.Enabled = e;
            tbTiempoMinScroll.Enabled = e;
        }

        private void tbMultiplicadorX_Leave(object sender, EventArgs e)
        {

        }

        private void tbMultiplicadorX_Validated(object sender, EventArgs e)
        {

        }

        private void tbMultiplicadorX_Validating(object sender, CancelEventArgs e)
        {

        }

        private void tbMultiplicadorX_Validating_1(object sender, CancelEventArgs e)
        {
            if (!ComprobarCampo(((System.Windows.Forms.TextBox)sender).Text))
            {
                MessageBox.Show("Sólo se permiten números, coma y signo negativo. Debe configurarse la como como separador decimal.");
                e.Cancel = true;
            }
        }
        int NumeroPuerto = 0;
        int NumPuertoScan = 0;
        private void btSCAN_Click(object sender, EventArgs e)
        {
            btSCAN.Enabled = false;
            EscanearPuerto(1);
        }
        private void EscanearPuerto(int n_puerto)
        {
            try
            {
                NumeroPuerto = n_puerto;
                cbPuerto.Text = "COM" + n_puerto.ToString();
                PuertoScan = new SerialPort();
                // Allow the user to set the appropriate properties.
                PuertoScan.PortName = cbPuerto.Text;
                PuertoScan.BaudRate = 115200;
                PuertoScan.Parity = Parity.None;
                PuertoScan.DataBits = 8;
                PuertoScan.StopBits = StopBits.One;
                PuertoScan.Handshake = Handshake.None;

                // Set the read/write timeouts
                PuertoScan.ReadTimeout = 500;
                PuertoScan.WriteTimeout = 500;

                PuertoScan.DataReceived += new SerialDataReceivedEventHandler(DataReceivedScan);
                PuertoScan.Open();
            }
            catch (Exception ex) { }

            tmrEsperaCierrePuerto.Enabled = true;
        }
        private static void DataReceivedScan(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            string entradaDatos = sp.ReadExisting(); // Almacena los datos recibidos en la variable tipo string.
            if (entradaDatos.IndexOf("Pos X:") > 0)
                sFrm.NumPuertoScan = sFrm.NumeroPuerto;
        }

        private void tmrEsperaCierrePuerto_Tick(object sender, EventArgs e)
        {
            try
            {
                PuertoScan.Close();
                PuertoScan.Dispose();
            }
            catch (Exception ex) { }

            if ((NumPuertoScan == 0) && (NumPuertoScan <= 30))
                EscanearPuerto(NumeroPuerto + 1);
            else
            {
                tmrEsperaCierrePuerto.Enabled = false;
                MessageBox.Show("MEIGA está en el puerto COM" + NumPuertoScan.ToString());
                btSCAN.Enabled = true;
                NumPuertoScan = 0;
            }
        }

        private void cbPuerto_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
