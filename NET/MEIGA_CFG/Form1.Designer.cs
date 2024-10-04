namespace MEIGA_CFG
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbPuerto = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPosX = new System.Windows.Forms.TextBox();
            this.tbPosY = new System.Windows.Forms.TextBox();
            this.tbFiltroAlabeo = new System.Windows.Forms.TextBox();
            this.tbMejilla = new System.Windows.Forms.TextBox();
            this.barMejilla = new System.Windows.Forms.ProgressBar();
            this.btConectar = new System.Windows.Forms.Button();
            this.tmrLeerDatosArduino = new System.Windows.Forms.Timer(this.components);
            this.btDesconectar = new System.Windows.Forms.Button();
            this.tbComando = new System.Windows.Forms.TextBox();
            this.tbL = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbMultiplicadorX = new System.Windows.Forms.TextBox();
            this.tbMultiplicadorY = new System.Windows.Forms.TextBox();
            this.cbCfgModo = new System.Windows.Forms.ComboBox();
            this.barAlabeoNeg = new System.Windows.Forms.ProgressBar();
            this.barAlabeoPos = new System.Windows.Forms.ProgressBar();
            this.barPosX = new System.Windows.Forms.ProgressBar();
            this.barPosY = new System.Windows.Forms.ProgressBar();
            this.btGrabar = new System.Windows.Forms.Button();
            this.btReiniciar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbMargenAlabeo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbPulsacionCorta = new System.Windows.Forms.TextBox();
            this.tbPulsacionMEdia = new System.Windows.Forms.TextBox();
            this.tbPulsacionLarga = new System.Windows.Forms.TextBox();
            this.tbPulsacionADC = new System.Windows.Forms.TextBox();
            this.tbAlabeoMinNeg = new System.Windows.Forms.TextBox();
            this.tbAlabeoMaxNeg = new System.Windows.Forms.TextBox();
            this.tbAlabeoMinPos = new System.Windows.Forms.TextBox();
            this.tbAlabeoMaxPos = new System.Windows.Forms.TextBox();
            this.tbCorrecionAlabeoDer = new System.Windows.Forms.TextBox();
            this.tbTiempoMinScroll = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.chkPulsacion = new System.Windows.Forms.CheckBox();
            this.chkScroll = new System.Windows.Forms.CheckBox();
            this.chkDireccion = new System.Windows.Forms.CheckBox();
            this.lblMEjilla = new System.Windows.Forms.Label();
            this.lblAlabeoNeg = new System.Windows.Forms.Label();
            this.lblAlabeoPos = new System.Windows.Forms.Label();
            this.chkMovimiento = new System.Windows.Forms.CheckBox();
            this.chkClicIzq = new System.Windows.Forms.CheckBox();
            this.chkClicDer = new System.Windows.Forms.CheckBox();
            this.chkClicCentro = new System.Windows.Forms.CheckBox();
            this.btLeerCfg = new System.Windows.Forms.Button();
            this.chkAcciones = new System.Windows.Forms.CheckBox();
            this.btSCAN = new System.Windows.Forms.Button();
            this.tmrEsperaCierrePuerto = new System.Windows.Forms.Timer(this.components);
            this.chkInvertirBotones = new System.Windows.Forms.CheckBox();
            this.lblBoton2 = new System.Windows.Forms.Label();
            this.lblBoton1 = new System.Windows.Forms.Label();
            this.chkPulsador = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.cbPuertoPulsador = new System.Windows.Forms.ComboBox();
            this.btConectarPulsador = new System.Windows.Forms.Button();
            this.btDesconectarPulsador = new System.Windows.Forms.Button();
            this.tmrLeerDatosArduinoPulsador = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cbPuerto
            // 
            this.cbPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPuerto.FormattingEnabled = true;
            this.cbPuerto.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20",
            "COM21",
            "COM22",
            "COM23",
            "COM24",
            "COM25",
            "COM26",
            "COM27",
            "COM28",
            "COM29",
            "COM30"});
            this.cbPuerto.Location = new System.Drawing.Point(98, 9);
            this.cbPuerto.Name = "cbPuerto";
            this.cbPuerto.Size = new System.Drawing.Size(100, 28);
            this.cbPuerto.TabIndex = 0;
            this.cbPuerto.Text = "COM1";
            this.cbPuerto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbPuerto_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "MEIGA";
            // 
            // tbPosX
            // 
            this.tbPosX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosX.Location = new System.Drawing.Point(97, 83);
            this.tbPosX.Name = "tbPosX";
            this.tbPosX.Size = new System.Drawing.Size(100, 26);
            this.tbPosX.TabIndex = 2;
            this.tbPosX.Text = "0";
            this.tbPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbPosY
            // 
            this.tbPosY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosY.Location = new System.Drawing.Point(97, 112);
            this.tbPosY.Name = "tbPosY";
            this.tbPosY.Size = new System.Drawing.Size(100, 26);
            this.tbPosY.TabIndex = 3;
            this.tbPosY.Text = "0";
            this.tbPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbFiltroAlabeo
            // 
            this.tbFiltroAlabeo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFiltroAlabeo.Location = new System.Drawing.Point(97, 141);
            this.tbFiltroAlabeo.Name = "tbFiltroAlabeo";
            this.tbFiltroAlabeo.Size = new System.Drawing.Size(100, 26);
            this.tbFiltroAlabeo.TabIndex = 4;
            this.tbFiltroAlabeo.Text = "0";
            this.tbFiltroAlabeo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbMejilla
            // 
            this.tbMejilla.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMejilla.Location = new System.Drawing.Point(97, 169);
            this.tbMejilla.Name = "tbMejilla";
            this.tbMejilla.Size = new System.Drawing.Size(100, 26);
            this.tbMejilla.TabIndex = 5;
            this.tbMejilla.Text = "0";
            this.tbMejilla.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // barMejilla
            // 
            this.barMejilla.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.barMejilla.Location = new System.Drawing.Point(203, 168);
            this.barMejilla.Maximum = 4096;
            this.barMejilla.Name = "barMejilla";
            this.barMejilla.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.barMejilla.Size = new System.Drawing.Size(381, 23);
            this.barMejilla.TabIndex = 6;
            // 
            // btConectar
            // 
            this.btConectar.Location = new System.Drawing.Point(204, 6);
            this.btConectar.Name = "btConectar";
            this.btConectar.Size = new System.Drawing.Size(108, 33);
            this.btConectar.TabIndex = 7;
            this.btConectar.Text = "Conectar MEIGA";
            this.btConectar.UseVisualStyleBackColor = true;
            this.btConectar.Click += new System.EventHandler(this.btConectar_Click);
            // 
            // tmrLeerDatosArduino
            // 
            this.tmrLeerDatosArduino.Interval = 5;
            this.tmrLeerDatosArduino.Tick += new System.EventHandler(this.tmrLeerDatosArduino_Tick);
            // 
            // btDesconectar
            // 
            this.btDesconectar.Enabled = false;
            this.btDesconectar.Location = new System.Drawing.Point(318, 6);
            this.btDesconectar.Name = "btDesconectar";
            this.btDesconectar.Size = new System.Drawing.Size(93, 33);
            this.btDesconectar.TabIndex = 9;
            this.btDesconectar.Text = "Desconectar";
            this.btDesconectar.UseVisualStyleBackColor = true;
            this.btDesconectar.Click += new System.EventHandler(this.btDesconectar_Click);
            // 
            // tbComando
            // 
            this.tbComando.Enabled = false;
            this.tbComando.Location = new System.Drawing.Point(143, 204);
            this.tbComando.Name = "tbComando";
            this.tbComando.Size = new System.Drawing.Size(382, 20);
            this.tbComando.TabIndex = 10;
            // 
            // tbL
            // 
            this.tbL.Location = new System.Drawing.Point(39, 463);
            this.tbL.Name = "tbL";
            this.tbL.Size = new System.Drawing.Size(545, 20);
            this.tbL.TabIndex = 11;
            this.tbL.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "PosX";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "PosY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(35, 172);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Mejilla";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Alabeo";
            // 
            // tbMultiplicadorX
            // 
            this.tbMultiplicadorX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMultiplicadorX.Location = new System.Drawing.Point(786, 67);
            this.tbMultiplicadorX.Name = "tbMultiplicadorX";
            this.tbMultiplicadorX.Size = new System.Drawing.Size(100, 26);
            this.tbMultiplicadorX.TabIndex = 16;
            this.tbMultiplicadorX.Text = "4";
            this.tbMultiplicadorX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMultiplicadorX.Leave += new System.EventHandler(this.tbMultiplicadorX_Leave);
            this.tbMultiplicadorX.Validating += new System.ComponentModel.CancelEventHandler(this.tbMultiplicadorX_Validating_1);
            this.tbMultiplicadorX.Validated += new System.EventHandler(this.tbMultiplicadorX_Validated);
            // 
            // tbMultiplicadorY
            // 
            this.tbMultiplicadorY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMultiplicadorY.Location = new System.Drawing.Point(786, 99);
            this.tbMultiplicadorY.Name = "tbMultiplicadorY";
            this.tbMultiplicadorY.Size = new System.Drawing.Size(100, 26);
            this.tbMultiplicadorY.TabIndex = 17;
            this.tbMultiplicadorY.Text = "5";
            this.tbMultiplicadorY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMultiplicadorY.Validating += new System.ComponentModel.CancelEventHandler(this.tbMultiplicadorX_Validating_1);
            // 
            // cbCfgModo
            // 
            this.cbCfgModo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCfgModo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCfgModo.FormattingEnabled = true;
            this.cbCfgModo.Items.AddRange(new object[] {
            "Cabeceo (Y) - Guiñada (X)",
            "Cabeceo (Y) - Alabeo (X)"});
            this.cbCfgModo.Location = new System.Drawing.Point(660, 25);
            this.cbCfgModo.Name = "cbCfgModo";
            this.cbCfgModo.Size = new System.Drawing.Size(226, 28);
            this.cbCfgModo.TabIndex = 18;
            // 
            // barAlabeoNeg
            // 
            this.barAlabeoNeg.Location = new System.Drawing.Point(231, 141);
            this.barAlabeoNeg.Maximum = 4096;
            this.barAlabeoNeg.Name = "barAlabeoNeg";
            this.barAlabeoNeg.Size = new System.Drawing.Size(169, 23);
            this.barAlabeoNeg.Step = 1;
            this.barAlabeoNeg.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.barAlabeoNeg.TabIndex = 19;
            // 
            // barAlabeoPos
            // 
            this.barAlabeoPos.Location = new System.Drawing.Point(407, 141);
            this.barAlabeoPos.Maximum = 4096;
            this.barAlabeoPos.Name = "barAlabeoPos";
            this.barAlabeoPos.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.barAlabeoPos.Size = new System.Drawing.Size(177, 23);
            this.barAlabeoPos.TabIndex = 20;
            // 
            // barPosX
            // 
            this.barPosX.Location = new System.Drawing.Point(203, 83);
            this.barPosX.Maximum = 4096;
            this.barPosX.Name = "barPosX";
            this.barPosX.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.barPosX.Size = new System.Drawing.Size(405, 23);
            this.barPosX.TabIndex = 21;
            // 
            // barPosY
            // 
            this.barPosY.Location = new System.Drawing.Point(203, 115);
            this.barPosY.Maximum = 4096;
            this.barPosY.Name = "barPosY";
            this.barPosY.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.barPosY.Size = new System.Drawing.Size(405, 23);
            this.barPosY.TabIndex = 22;
            // 
            // btGrabar
            // 
            this.btGrabar.Enabled = false;
            this.btGrabar.Location = new System.Drawing.Point(417, 6);
            this.btGrabar.Name = "btGrabar";
            this.btGrabar.Size = new System.Drawing.Size(61, 32);
            this.btGrabar.TabIndex = 23;
            this.btGrabar.Text = "GRABAR";
            this.btGrabar.UseVisualStyleBackColor = true;
            this.btGrabar.Click += new System.EventHandler(this.btGrabar_Click);
            // 
            // btReiniciar
            // 
            this.btReiniciar.Location = new System.Drawing.Point(550, 6);
            this.btReiniciar.Name = "btReiniciar";
            this.btReiniciar.Size = new System.Drawing.Size(59, 32);
            this.btReiniciar.TabIndex = 24;
            this.btReiniciar.Text = "Reiniciar";
            this.btReiniciar.UseVisualStyleBackColor = true;
            this.btReiniciar.Click += new System.EventHandler(this.btReiniciar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(145, 256);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(333, 191);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(672, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 20);
            this.label6.TabIndex = 26;
            this.label6.Text = "MultiplicadorX";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(672, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 20);
            this.label7.TabIndex = 27;
            this.label7.Text = "MultiplicadorY";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(662, 138);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Márgen Alabeo";
            // 
            // tbMargenAlabeo
            // 
            this.tbMargenAlabeo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMargenAlabeo.Location = new System.Drawing.Point(785, 135);
            this.tbMargenAlabeo.Name = "tbMargenAlabeo";
            this.tbMargenAlabeo.Size = new System.Drawing.Size(100, 26);
            this.tbMargenAlabeo.TabIndex = 28;
            this.tbMargenAlabeo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbMargenAlabeo.Validating += new System.ComponentModel.CancelEventHandler(this.tbMultiplicadorX_Validating_1);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(616, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 20);
            this.label9.TabIndex = 30;
            this.label9.Text = "Cfg.";
            // 
            // tbPulsacionCorta
            // 
            this.tbPulsacionCorta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPulsacionCorta.Location = new System.Drawing.Point(786, 169);
            this.tbPulsacionCorta.Name = "tbPulsacionCorta";
            this.tbPulsacionCorta.Size = new System.Drawing.Size(100, 26);
            this.tbPulsacionCorta.TabIndex = 31;
            this.tbPulsacionCorta.Text = "300";
            this.tbPulsacionCorta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPulsacionCorta.Validating += new System.ComponentModel.CancelEventHandler(this.tbMultiplicadorX_Validating_1);
            // 
            // tbPulsacionMEdia
            // 
            this.tbPulsacionMEdia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPulsacionMEdia.Location = new System.Drawing.Point(786, 201);
            this.tbPulsacionMEdia.Name = "tbPulsacionMEdia";
            this.tbPulsacionMEdia.Size = new System.Drawing.Size(100, 26);
            this.tbPulsacionMEdia.TabIndex = 32;
            this.tbPulsacionMEdia.Text = "1000";
            this.tbPulsacionMEdia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPulsacionMEdia.Validating += new System.ComponentModel.CancelEventHandler(this.tbMultiplicadorX_Validating_1);
            // 
            // tbPulsacionLarga
            // 
            this.tbPulsacionLarga.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPulsacionLarga.Location = new System.Drawing.Point(785, 233);
            this.tbPulsacionLarga.Name = "tbPulsacionLarga";
            this.tbPulsacionLarga.Size = new System.Drawing.Size(100, 26);
            this.tbPulsacionLarga.TabIndex = 33;
            this.tbPulsacionLarga.Text = "5000";
            this.tbPulsacionLarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPulsacionLarga.Validating += new System.ComponentModel.CancelEventHandler(this.tbMultiplicadorX_Validating_1);
            // 
            // tbPulsacionADC
            // 
            this.tbPulsacionADC.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPulsacionADC.Location = new System.Drawing.Point(785, 265);
            this.tbPulsacionADC.Name = "tbPulsacionADC";
            this.tbPulsacionADC.Size = new System.Drawing.Size(100, 26);
            this.tbPulsacionADC.TabIndex = 34;
            this.tbPulsacionADC.Text = "350";
            this.tbPulsacionADC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPulsacionADC.Validating += new System.ComponentModel.CancelEventHandler(this.tbMultiplicadorX_Validating_1);
            // 
            // tbAlabeoMinNeg
            // 
            this.tbAlabeoMinNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAlabeoMinNeg.Location = new System.Drawing.Point(785, 297);
            this.tbAlabeoMinNeg.Name = "tbAlabeoMinNeg";
            this.tbAlabeoMinNeg.Size = new System.Drawing.Size(100, 26);
            this.tbAlabeoMinNeg.TabIndex = 35;
            this.tbAlabeoMinNeg.Text = "-2,5";
            this.tbAlabeoMinNeg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbAlabeoMinNeg.Validating += new System.ComponentModel.CancelEventHandler(this.tbMultiplicadorX_Validating_1);
            // 
            // tbAlabeoMaxNeg
            // 
            this.tbAlabeoMaxNeg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAlabeoMaxNeg.Location = new System.Drawing.Point(786, 329);
            this.tbAlabeoMaxNeg.Name = "tbAlabeoMaxNeg";
            this.tbAlabeoMaxNeg.Size = new System.Drawing.Size(100, 26);
            this.tbAlabeoMaxNeg.TabIndex = 36;
            this.tbAlabeoMaxNeg.Text = "-1,5";
            this.tbAlabeoMaxNeg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbAlabeoMaxNeg.Validating += new System.ComponentModel.CancelEventHandler(this.tbMultiplicadorX_Validating_1);
            // 
            // tbAlabeoMinPos
            // 
            this.tbAlabeoMinPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAlabeoMinPos.Location = new System.Drawing.Point(785, 361);
            this.tbAlabeoMinPos.Name = "tbAlabeoMinPos";
            this.tbAlabeoMinPos.Size = new System.Drawing.Size(100, 26);
            this.tbAlabeoMinPos.TabIndex = 37;
            this.tbAlabeoMinPos.Text = "1";
            this.tbAlabeoMinPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbAlabeoMinPos.Validating += new System.ComponentModel.CancelEventHandler(this.tbMultiplicadorX_Validating_1);
            // 
            // tbAlabeoMaxPos
            // 
            this.tbAlabeoMaxPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAlabeoMaxPos.Location = new System.Drawing.Point(785, 393);
            this.tbAlabeoMaxPos.Name = "tbAlabeoMaxPos";
            this.tbAlabeoMaxPos.Size = new System.Drawing.Size(100, 26);
            this.tbAlabeoMaxPos.TabIndex = 38;
            this.tbAlabeoMaxPos.Text = "2,5";
            this.tbAlabeoMaxPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbAlabeoMaxPos.Validating += new System.ComponentModel.CancelEventHandler(this.tbMultiplicadorX_Validating_1);
            // 
            // tbCorrecionAlabeoDer
            // 
            this.tbCorrecionAlabeoDer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCorrecionAlabeoDer.Location = new System.Drawing.Point(786, 425);
            this.tbCorrecionAlabeoDer.Name = "tbCorrecionAlabeoDer";
            this.tbCorrecionAlabeoDer.Size = new System.Drawing.Size(100, 26);
            this.tbCorrecionAlabeoDer.TabIndex = 39;
            this.tbCorrecionAlabeoDer.Text = "1,2";
            this.tbCorrecionAlabeoDer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbCorrecionAlabeoDer.Validating += new System.ComponentModel.CancelEventHandler(this.tbMultiplicadorX_Validating_1);
            // 
            // tbTiempoMinScroll
            // 
            this.tbTiempoMinScroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTiempoMinScroll.Location = new System.Drawing.Point(786, 457);
            this.tbTiempoMinScroll.Name = "tbTiempoMinScroll";
            this.tbTiempoMinScroll.Size = new System.Drawing.Size(100, 26);
            this.tbTiempoMinScroll.TabIndex = 40;
            this.tbTiempoMinScroll.Text = "200";
            this.tbTiempoMinScroll.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTiempoMinScroll.Validating += new System.ComponentModel.CancelEventHandler(this.tbMultiplicadorX_Validating_1);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(659, 172);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 20);
            this.label10.TabIndex = 41;
            this.label10.Text = "Pulsación Corta";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(655, 204);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 20);
            this.label11.TabIndex = 42;
            this.label11.Text = "Pulsación Media";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(657, 236);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 20);
            this.label12.TabIndex = 43;
            this.label12.Text = "Pulsación Larga";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(658, 268);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 20);
            this.label13.TabIndex = 44;
            this.label13.Text = "Pulsación ADC";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(659, 300);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(113, 20);
            this.label14.TabIndex = 45;
            this.label14.Text = "AlabeoMinNeg";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(655, 332);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 20);
            this.label15.TabIndex = 46;
            this.label15.Text = "AlabeoMaxNeg";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(658, 364);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 20);
            this.label16.TabIndex = 47;
            this.label16.Text = "AlabeoMinPos";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(655, 396);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(115, 20);
            this.label17.TabIndex = 48;
            this.label17.Text = "AlabeoMaxPos";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(610, 427);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(169, 20);
            this.label18.TabIndex = 49;
            this.label18.Text = "Corrección Alabeo Der";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(642, 460);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(137, 20);
            this.label19.TabIndex = 50;
            this.label19.Text = "Tiempo Min. Scroll";
            // 
            // chkPulsacion
            // 
            this.chkPulsacion.AutoSize = true;
            this.chkPulsacion.Checked = true;
            this.chkPulsacion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPulsacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPulsacion.Location = new System.Drawing.Point(511, 410);
            this.chkPulsacion.Margin = new System.Windows.Forms.Padding(2);
            this.chkPulsacion.Name = "chkPulsacion";
            this.chkPulsacion.Size = new System.Drawing.Size(96, 24);
            this.chkPulsacion.TabIndex = 51;
            this.chkPulsacion.Text = "Pulsación";
            this.chkPulsacion.UseVisualStyleBackColor = true;
            // 
            // chkScroll
            // 
            this.chkScroll.AutoSize = true;
            this.chkScroll.Checked = true;
            this.chkScroll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkScroll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkScroll.Location = new System.Drawing.Point(511, 291);
            this.chkScroll.Margin = new System.Windows.Forms.Padding(2);
            this.chkScroll.Name = "chkScroll";
            this.chkScroll.Size = new System.Drawing.Size(67, 24);
            this.chkScroll.TabIndex = 52;
            this.chkScroll.Text = "Scroll";
            this.chkScroll.UseVisualStyleBackColor = true;
            // 
            // chkDireccion
            // 
            this.chkDireccion.AutoSize = true;
            this.chkDireccion.Checked = true;
            this.chkDireccion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDireccion.Location = new System.Drawing.Point(511, 316);
            this.chkDireccion.Margin = new System.Windows.Forms.Padding(2);
            this.chkDireccion.Name = "chkDireccion";
            this.chkDireccion.Size = new System.Drawing.Size(94, 24);
            this.chkDireccion.TabIndex = 53;
            this.chkDireccion.Text = "Dirección";
            this.chkDireccion.UseVisualStyleBackColor = true;
            // 
            // lblMEjilla
            // 
            this.lblMEjilla.BackColor = System.Drawing.Color.Yellow;
            this.lblMEjilla.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMEjilla.Location = new System.Drawing.Point(588, 168);
            this.lblMEjilla.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMEjilla.Name = "lblMEjilla";
            this.lblMEjilla.Size = new System.Drawing.Size(25, 24);
            this.lblMEjilla.TabIndex = 54;
            // 
            // lblAlabeoNeg
            // 
            this.lblAlabeoNeg.BackColor = System.Drawing.Color.Yellow;
            this.lblAlabeoNeg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlabeoNeg.Location = new System.Drawing.Point(202, 141);
            this.lblAlabeoNeg.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAlabeoNeg.Name = "lblAlabeoNeg";
            this.lblAlabeoNeg.Size = new System.Drawing.Size(24, 22);
            this.lblAlabeoNeg.TabIndex = 55;
            // 
            // lblAlabeoPos
            // 
            this.lblAlabeoPos.BackColor = System.Drawing.Color.Yellow;
            this.lblAlabeoPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAlabeoPos.Location = new System.Drawing.Point(588, 141);
            this.lblAlabeoPos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAlabeoPos.Name = "lblAlabeoPos";
            this.lblAlabeoPos.Size = new System.Drawing.Size(25, 22);
            this.lblAlabeoPos.TabIndex = 56;
            // 
            // chkMovimiento
            // 
            this.chkMovimiento.AutoSize = true;
            this.chkMovimiento.Checked = true;
            this.chkMovimiento.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMovimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMovimiento.Location = new System.Drawing.Point(511, 268);
            this.chkMovimiento.Margin = new System.Windows.Forms.Padding(2);
            this.chkMovimiento.Name = "chkMovimiento";
            this.chkMovimiento.Size = new System.Drawing.Size(108, 24);
            this.chkMovimiento.TabIndex = 57;
            this.chkMovimiento.Text = "Movimiento";
            this.chkMovimiento.UseVisualStyleBackColor = true;
            // 
            // chkClicIzq
            // 
            this.chkClicIzq.AutoSize = true;
            this.chkClicIzq.Checked = true;
            this.chkClicIzq.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClicIzq.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClicIzq.Location = new System.Drawing.Point(511, 341);
            this.chkClicIzq.Margin = new System.Windows.Forms.Padding(2);
            this.chkClicIzq.Name = "chkClicIzq";
            this.chkClicIzq.Size = new System.Drawing.Size(74, 24);
            this.chkClicIzq.TabIndex = 58;
            this.chkClicIzq.Text = "clic izq";
            this.chkClicIzq.UseVisualStyleBackColor = true;
            // 
            // chkClicDer
            // 
            this.chkClicDer.AutoSize = true;
            this.chkClicDer.Checked = true;
            this.chkClicDer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClicDer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClicDer.Location = new System.Drawing.Point(511, 364);
            this.chkClicDer.Margin = new System.Windows.Forms.Padding(2);
            this.chkClicDer.Name = "chkClicDer";
            this.chkClicDer.Size = new System.Drawing.Size(77, 24);
            this.chkClicDer.TabIndex = 59;
            this.chkClicDer.Text = "clic der";
            this.chkClicDer.UseVisualStyleBackColor = true;
            // 
            // chkClicCentro
            // 
            this.chkClicCentro.AutoSize = true;
            this.chkClicCentro.Checked = true;
            this.chkClicCentro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClicCentro.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkClicCentro.Location = new System.Drawing.Point(511, 385);
            this.chkClicCentro.Margin = new System.Windows.Forms.Padding(2);
            this.chkClicCentro.Name = "chkClicCentro";
            this.chkClicCentro.Size = new System.Drawing.Size(99, 24);
            this.chkClicCentro.TabIndex = 60;
            this.chkClicCentro.Text = "clic centro";
            this.chkClicCentro.UseVisualStyleBackColor = true;
            // 
            // btLeerCfg
            // 
            this.btLeerCfg.Enabled = false;
            this.btLeerCfg.Location = new System.Drawing.Point(483, 6);
            this.btLeerCfg.Name = "btLeerCfg";
            this.btLeerCfg.Size = new System.Drawing.Size(61, 32);
            this.btLeerCfg.TabIndex = 61;
            this.btLeerCfg.Text = "LeerCfg";
            this.btLeerCfg.UseVisualStyleBackColor = true;
            this.btLeerCfg.Click += new System.EventHandler(this.btLeerCfg_Click);
            // 
            // chkAcciones
            // 
            this.chkAcciones.AutoSize = true;
            this.chkAcciones.Checked = true;
            this.chkAcciones.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAcciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAcciones.Location = new System.Drawing.Point(511, 435);
            this.chkAcciones.Margin = new System.Windows.Forms.Padding(2);
            this.chkAcciones.Name = "chkAcciones";
            this.chkAcciones.Size = new System.Drawing.Size(93, 24);
            this.chkAcciones.TabIndex = 62;
            this.chkAcciones.Text = "Acciones";
            this.chkAcciones.UseVisualStyleBackColor = true;
            // 
            // btSCAN
            // 
            this.btSCAN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSCAN.Location = new System.Drawing.Point(39, 201);
            this.btSCAN.Name = "btSCAN";
            this.btSCAN.Size = new System.Drawing.Size(98, 38);
            this.btSCAN.TabIndex = 63;
            this.btSCAN.Text = "SCAN";
            this.btSCAN.UseVisualStyleBackColor = true;
            this.btSCAN.Click += new System.EventHandler(this.btSCAN_Click);
            // 
            // tmrEsperaCierrePuerto
            // 
            this.tmrEsperaCierrePuerto.Interval = 2000;
            this.tmrEsperaCierrePuerto.Tick += new System.EventHandler(this.tmrEsperaCierrePuerto_Tick);
            // 
            // chkInvertirBotones
            // 
            this.chkInvertirBotones.AutoSize = true;
            this.chkInvertirBotones.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkInvertirBotones.Location = new System.Drawing.Point(511, 246);
            this.chkInvertirBotones.Name = "chkInvertirBotones";
            this.chkInvertirBotones.Size = new System.Drawing.Size(140, 24);
            this.chkInvertirBotones.TabIndex = 64;
            this.chkInvertirBotones.Text = "Invertir Botones";
            this.chkInvertirBotones.UseVisualStyleBackColor = true;
            // 
            // lblBoton2
            // 
            this.lblBoton2.BackColor = System.Drawing.Color.Yellow;
            this.lblBoton2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBoton2.Location = new System.Drawing.Point(559, 201);
            this.lblBoton2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBoton2.Name = "lblBoton2";
            this.lblBoton2.Size = new System.Drawing.Size(25, 25);
            this.lblBoton2.TabIndex = 65;
            // 
            // lblBoton1
            // 
            this.lblBoton1.BackColor = System.Drawing.Color.Yellow;
            this.lblBoton1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblBoton1.Location = new System.Drawing.Point(530, 201);
            this.lblBoton1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBoton1.Name = "lblBoton1";
            this.lblBoton1.Size = new System.Drawing.Size(25, 25);
            this.lblBoton1.TabIndex = 66;
            // 
            // chkPulsador
            // 
            this.chkPulsador.AutoSize = true;
            this.chkPulsador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPulsador.Location = new System.Drawing.Point(40, 264);
            this.chkPulsador.Name = "chkPulsador";
            this.chkPulsador.Size = new System.Drawing.Size(98, 24);
            this.chkPulsador.TabIndex = 67;
            this.chkPulsador.Text = "Pulsar/clic";
            this.chkPulsador.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(24, 43);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 20);
            this.label20.TabIndex = 68;
            this.label20.Text = "Pulsador";
            // 
            // cbPuertoPulsador
            // 
            this.cbPuertoPulsador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPuertoPulsador.FormattingEnabled = true;
            this.cbPuertoPulsador.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15",
            "COM16",
            "COM17",
            "COM18",
            "COM19",
            "COM20",
            "COM21",
            "COM22",
            "COM23",
            "COM24",
            "COM25",
            "COM26",
            "COM27",
            "COM28",
            "COM29",
            "COM30"});
            this.cbPuertoPulsador.Location = new System.Drawing.Point(98, 43);
            this.cbPuertoPulsador.Name = "cbPuertoPulsador";
            this.cbPuertoPulsador.Size = new System.Drawing.Size(100, 28);
            this.cbPuertoPulsador.TabIndex = 69;
            this.cbPuertoPulsador.Text = "COM1";
            // 
            // btConectarPulsador
            // 
            this.btConectarPulsador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConectarPulsador.Location = new System.Drawing.Point(204, 43);
            this.btConectarPulsador.Name = "btConectarPulsador";
            this.btConectarPulsador.Size = new System.Drawing.Size(108, 28);
            this.btConectarPulsador.TabIndex = 70;
            this.btConectarPulsador.Text = "Conect.Pulsador";
            this.btConectarPulsador.UseVisualStyleBackColor = true;
            this.btConectarPulsador.Click += new System.EventHandler(this.btConectarPulsador_Click);
            // 
            // btDesconectarPulsador
            // 
            this.btDesconectarPulsador.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDesconectarPulsador.Location = new System.Drawing.Point(319, 43);
            this.btDesconectarPulsador.Name = "btDesconectarPulsador";
            this.btDesconectarPulsador.Size = new System.Drawing.Size(92, 28);
            this.btDesconectarPulsador.TabIndex = 71;
            this.btDesconectarPulsador.Text = "Desconectar";
            this.btDesconectarPulsador.UseVisualStyleBackColor = true;
            this.btDesconectarPulsador.Click += new System.EventHandler(this.btDesconectarPulsador_Click);
            // 
            // tmrLeerDatosArduinoPulsador
            // 
            this.tmrLeerDatosArduinoPulsador.Interval = 50;
            this.tmrLeerDatosArduinoPulsador.Tick += new System.EventHandler(this.tmrLeerDatosArduinoPulsador_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(26, 300);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 72;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 497);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btDesconectarPulsador);
            this.Controls.Add(this.btConectarPulsador);
            this.Controls.Add(this.cbPuertoPulsador);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.chkPulsador);
            this.Controls.Add(this.lblBoton1);
            this.Controls.Add(this.lblBoton2);
            this.Controls.Add(this.chkInvertirBotones);
            this.Controls.Add(this.btSCAN);
            this.Controls.Add(this.chkAcciones);
            this.Controls.Add(this.btLeerCfg);
            this.Controls.Add(this.chkClicCentro);
            this.Controls.Add(this.chkClicDer);
            this.Controls.Add(this.chkClicIzq);
            this.Controls.Add(this.chkMovimiento);
            this.Controls.Add(this.lblAlabeoPos);
            this.Controls.Add(this.lblAlabeoNeg);
            this.Controls.Add(this.lblMEjilla);
            this.Controls.Add(this.chkDireccion);
            this.Controls.Add(this.chkScroll);
            this.Controls.Add(this.chkPulsacion);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbTiempoMinScroll);
            this.Controls.Add(this.tbCorrecionAlabeoDer);
            this.Controls.Add(this.tbAlabeoMaxPos);
            this.Controls.Add(this.tbAlabeoMinPos);
            this.Controls.Add(this.tbAlabeoMaxNeg);
            this.Controls.Add(this.tbAlabeoMinNeg);
            this.Controls.Add(this.tbPulsacionADC);
            this.Controls.Add(this.tbPulsacionLarga);
            this.Controls.Add(this.tbPulsacionMEdia);
            this.Controls.Add(this.tbPulsacionCorta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbMargenAlabeo);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btReiniciar);
            this.Controls.Add(this.btGrabar);
            this.Controls.Add(this.barPosY);
            this.Controls.Add(this.barPosX);
            this.Controls.Add(this.barAlabeoPos);
            this.Controls.Add(this.barAlabeoNeg);
            this.Controls.Add(this.cbCfgModo);
            this.Controls.Add(this.tbMultiplicadorY);
            this.Controls.Add(this.tbMultiplicadorX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbL);
            this.Controls.Add(this.tbComando);
            this.Controls.Add(this.btDesconectar);
            this.Controls.Add(this.btConectar);
            this.Controls.Add(this.barMejilla);
            this.Controls.Add(this.tbMejilla);
            this.Controls.Add(this.tbFiltroAlabeo);
            this.Controls.Add(this.tbPosY);
            this.Controls.Add(this.tbPosX);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbPuerto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "MEIGA Config - Módulo Espacial de Integración de Giróscopo y Acelerómetro";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPuerto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPosX;
        private System.Windows.Forms.TextBox tbPosY;
        private System.Windows.Forms.TextBox tbFiltroAlabeo;
        private System.Windows.Forms.TextBox tbMejilla;
        private System.Windows.Forms.ProgressBar barMejilla;
        private System.Windows.Forms.Button btConectar;
        private System.Windows.Forms.Timer tmrLeerDatosArduino;
        private System.Windows.Forms.Button btDesconectar;
        private System.Windows.Forms.TextBox tbComando;
        private System.Windows.Forms.TextBox tbL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbMultiplicadorX;
        private System.Windows.Forms.TextBox tbMultiplicadorY;
        private System.Windows.Forms.ComboBox cbCfgModo;
        private System.Windows.Forms.ProgressBar barAlabeoNeg;
        private System.Windows.Forms.ProgressBar barAlabeoPos;
        private System.Windows.Forms.ProgressBar barPosX;
        private System.Windows.Forms.ProgressBar barPosY;
        private System.Windows.Forms.Button btGrabar;
        private System.Windows.Forms.Button btReiniciar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbMargenAlabeo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbPulsacionCorta;
        private System.Windows.Forms.TextBox tbPulsacionMEdia;
        private System.Windows.Forms.TextBox tbPulsacionLarga;
        private System.Windows.Forms.TextBox tbPulsacionADC;
        private System.Windows.Forms.TextBox tbAlabeoMinNeg;
        private System.Windows.Forms.TextBox tbAlabeoMaxNeg;
        private System.Windows.Forms.TextBox tbAlabeoMinPos;
        private System.Windows.Forms.TextBox tbAlabeoMaxPos;
        private System.Windows.Forms.TextBox tbCorrecionAlabeoDer;
        private System.Windows.Forms.TextBox tbTiempoMinScroll;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox chkPulsacion;
        private System.Windows.Forms.CheckBox chkScroll;
        private System.Windows.Forms.CheckBox chkDireccion;
        private System.Windows.Forms.Label lblMEjilla;
        private System.Windows.Forms.Label lblAlabeoNeg;
        private System.Windows.Forms.Label lblAlabeoPos;
        private System.Windows.Forms.CheckBox chkMovimiento;
        private System.Windows.Forms.CheckBox chkClicIzq;
        private System.Windows.Forms.CheckBox chkClicDer;
        private System.Windows.Forms.CheckBox chkClicCentro;
        private System.Windows.Forms.Button btLeerCfg;
        private System.Windows.Forms.CheckBox chkAcciones;
        private System.Windows.Forms.Button btSCAN;
        private System.Windows.Forms.Timer tmrEsperaCierrePuerto;
        private System.Windows.Forms.CheckBox chkInvertirBotones;
        private System.Windows.Forms.Label lblBoton2;
        private System.Windows.Forms.Label lblBoton1;
        private System.Windows.Forms.CheckBox chkPulsador;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbPuertoPulsador;
        private System.Windows.Forms.Button btConectarPulsador;
        private System.Windows.Forms.Button btDesconectarPulsador;
        private System.Windows.Forms.Timer tmrLeerDatosArduinoPulsador;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

