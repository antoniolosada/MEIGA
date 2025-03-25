namespace Joy
{
    partial class frmJoy
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tbMouse = new TextBox();
            tmrMouse = new System.Windows.Forms.Timer(components);
            cmdCfg = new Button();
            tbClick = new TextBox();
            cmdGuardarPoligonos = new Button();
            cmdCargarPoligonos = new Button();
            cmdBorrarAreas = new Button();
            tbMinX = new TextBox();
            tbMaxX = new TextBox();
            tbMinY = new TextBox();
            tbMaxY = new TextBox();
            chkCircularH = new CheckBox();
            chkClickNoPreciso = new CheckBox();
            chkAreas = new CheckBox();
            chkCircularV = new CheckBox();
            cmdActivar = new Button();
            tmrClic = new System.Windows.Forms.Timer(components);
            tbClicMs = new TextBox();
            chkClickActivo = new CheckBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // tbMouse
            // 
            tbMouse.Enabled = false;
            tbMouse.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbMouse.Location = new Point(33, 86);
            tbMouse.Name = "tbMouse";
            tbMouse.Size = new Size(218, 36);
            tbMouse.TabIndex = 0;
            tbMouse.TextAlign = HorizontalAlignment.Center;
            // 
            // tmrMouse
            // 
            tmrMouse.Tick += tmrMouse_Tick;
            // 
            // cmdCfg
            // 
            cmdCfg.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdCfg.Location = new Point(408, 7);
            cmdCfg.Name = "cmdCfg";
            cmdCfg.Size = new Size(131, 38);
            cmdCfg.TabIndex = 1;
            cmdCfg.Text = "Definir áreas";
            cmdCfg.UseVisualStyleBackColor = true;
            cmdCfg.Click += cmdCfg_Click;
            // 
            // tbClick
            // 
            tbClick.Location = new Point(268, 95);
            tbClick.Name = "tbClick";
            tbClick.Size = new Size(45, 23);
            tbClick.TabIndex = 2;
            tbClick.TextAlign = HorizontalAlignment.Center;
            // 
            // cmdGuardarPoligonos
            // 
            cmdGuardarPoligonos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdGuardarPoligonos.Location = new Point(408, 95);
            cmdGuardarPoligonos.Margin = new Padding(2);
            cmdGuardarPoligonos.Name = "cmdGuardarPoligonos";
            cmdGuardarPoligonos.Size = new Size(131, 34);
            cmdGuardarPoligonos.TabIndex = 3;
            cmdGuardarPoligonos.Text = "Guardar";
            cmdGuardarPoligonos.UseVisualStyleBackColor = true;
            cmdGuardarPoligonos.Click += cmdGuardarPoligonos_Click;
            // 
            // cmdCargarPoligonos
            // 
            cmdCargarPoligonos.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdCargarPoligonos.Location = new Point(408, 133);
            cmdCargarPoligonos.Margin = new Padding(2);
            cmdCargarPoligonos.Name = "cmdCargarPoligonos";
            cmdCargarPoligonos.Size = new Size(131, 34);
            cmdCargarPoligonos.TabIndex = 4;
            cmdCargarPoligonos.Text = "Cargar";
            cmdCargarPoligonos.UseVisualStyleBackColor = true;
            cmdCargarPoligonos.Click += cmdCargarPoligonos_Click;
            // 
            // cmdBorrarAreas
            // 
            cmdBorrarAreas.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdBorrarAreas.Location = new Point(408, 49);
            cmdBorrarAreas.Margin = new Padding(2);
            cmdBorrarAreas.Name = "cmdBorrarAreas";
            cmdBorrarAreas.Size = new Size(131, 43);
            cmdBorrarAreas.TabIndex = 5;
            cmdBorrarAreas.Text = "Borrar áreas";
            cmdBorrarAreas.UseVisualStyleBackColor = true;
            cmdBorrarAreas.Click += cmdVerAreas_Click;
            // 
            // tbMinX
            // 
            tbMinX.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbMinX.Location = new Point(158, 7);
            tbMinX.Margin = new Padding(2);
            tbMinX.Name = "tbMinX";
            tbMinX.Size = new Size(105, 29);
            tbMinX.TabIndex = 6;
            tbMinX.TextAlign = HorizontalAlignment.Center;
            tbMinX.TextChanged += tbMinX_TextChanged;
            // 
            // tbMaxX
            // 
            tbMaxX.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbMaxX.Location = new Point(268, 7);
            tbMaxX.Margin = new Padding(2);
            tbMaxX.Name = "tbMaxX";
            tbMaxX.Size = new Size(104, 29);
            tbMaxX.TabIndex = 7;
            tbMaxX.TextAlign = HorizontalAlignment.Center;
            // 
            // tbMinY
            // 
            tbMinY.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbMinY.Location = new Point(158, 44);
            tbMinY.Margin = new Padding(2);
            tbMinY.Name = "tbMinY";
            tbMinY.Size = new Size(106, 29);
            tbMinY.TabIndex = 8;
            tbMinY.TextAlign = HorizontalAlignment.Center;
            // 
            // tbMaxY
            // 
            tbMaxY.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbMaxY.Location = new Point(268, 44);
            tbMaxY.Margin = new Padding(2);
            tbMaxY.Name = "tbMaxY";
            tbMaxY.Size = new Size(104, 29);
            tbMaxY.TabIndex = 9;
            tbMaxY.TextAlign = HorizontalAlignment.Center;
            // 
            // chkCircularH
            // 
            chkCircularH.AutoSize = true;
            chkCircularH.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkCircularH.Location = new Point(33, 128);
            chkCircularH.Margin = new Padding(2);
            chkCircularH.Name = "chkCircularH";
            chkCircularH.Size = new Size(148, 25);
            chkCircularH.TabIndex = 10;
            chkCircularH.Text = "Mov. circular Hor";
            chkCircularH.UseVisualStyleBackColor = true;
            // 
            // chkClickNoPreciso
            // 
            chkClickNoPreciso.AutoSize = true;
            chkClickNoPreciso.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkClickNoPreciso.Location = new Point(200, 153);
            chkClickNoPreciso.Margin = new Padding(2);
            chkClickNoPreciso.Name = "chkClickNoPreciso";
            chkClickNoPreciso.Size = new Size(130, 25);
            chkClickNoPreciso.TabIndex = 11;
            chkClickNoPreciso.Text = "Clic no preciso";
            chkClickNoPreciso.UseVisualStyleBackColor = true;
            // 
            // chkAreas
            // 
            chkAreas.AutoSize = true;
            chkAreas.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkAreas.Location = new Point(33, 153);
            chkAreas.Margin = new Padding(2);
            chkAreas.Name = "chkAreas";
            chkAreas.Size = new Size(119, 25);
            chkAreas.TabIndex = 12;
            chkAreas.Text = "Áreas activas";
            chkAreas.UseVisualStyleBackColor = true;
            chkAreas.CheckedChanged += chkAreas_CheckedChanged;
            // 
            // chkCircularV
            // 
            chkCircularV.AutoSize = true;
            chkCircularV.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkCircularV.Location = new Point(200, 128);
            chkCircularV.Margin = new Padding(2);
            chkCircularV.Name = "chkCircularV";
            chkCircularV.Size = new Size(145, 25);
            chkCircularV.TabIndex = 13;
            chkCircularV.Text = "Mov. circular Ver";
            chkCircularV.UseVisualStyleBackColor = true;
            // 
            // cmdActivar
            // 
            cmdActivar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmdActivar.Location = new Point(408, 170);
            cmdActivar.Margin = new Padding(2);
            cmdActivar.Name = "cmdActivar";
            cmdActivar.Size = new Size(131, 34);
            cmdActivar.TabIndex = 14;
            cmdActivar.Text = "Activar";
            cmdActivar.UseVisualStyleBackColor = true;
            cmdActivar.Click += cmdActivar_Click;
            // 
            // tmrClic
            // 
            tmrClic.Tick += tmrClic_Tick;
            // 
            // tbClicMs
            // 
            tbClicMs.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbClicMs.Location = new Point(87, 202);
            tbClicMs.Margin = new Padding(2);
            tbClicMs.Name = "tbClicMs";
            tbClicMs.Size = new Size(73, 29);
            tbClicMs.TabIndex = 15;
            tbClicMs.TextAlign = HorizontalAlignment.Center;
            // 
            // chkClickActivo
            // 
            chkClickActivo.AutoSize = true;
            chkClickActivo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkClickActivo.Location = new Point(33, 177);
            chkClickActivo.Margin = new Padding(2);
            chkClickActivo.Name = "chkClickActivo";
            chkClickActivo.Size = new Size(99, 25);
            chkClickActivo.TabIndex = 16;
            chkClickActivo.Text = "Clic activo";
            chkClickActivo.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 205);
            label1.Name = "label1";
            label1.Size = new Size(60, 21);
            label1.TabIndex = 17;
            label1.Text = "Ms Clic";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(21, 10);
            label2.Name = "label2";
            label2.Size = new Size(131, 21);
            label2.TabIndex = 18;
            label2.Text = "Rango Horizontal";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(22, 47);
            label3.Name = "label3";
            label3.Size = new Size(110, 21);
            label3.TabIndex = 19;
            label3.Text = "Rango Vertical";
            // 
            // frmJoy
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(561, 239);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(chkClickActivo);
            Controls.Add(tbClicMs);
            Controls.Add(cmdActivar);
            Controls.Add(chkCircularV);
            Controls.Add(chkAreas);
            Controls.Add(chkClickNoPreciso);
            Controls.Add(chkCircularH);
            Controls.Add(tbMaxY);
            Controls.Add(tbMinY);
            Controls.Add(tbMaxX);
            Controls.Add(tbMinX);
            Controls.Add(cmdBorrarAreas);
            Controls.Add(cmdCargarPoligonos);
            Controls.Add(cmdGuardarPoligonos);
            Controls.Add(tbClick);
            Controls.Add(cmdCfg);
            Controls.Add(tbMouse);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "frmJoy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Joy";
            FormClosing += frmJoy_FormClosing;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbMouse;
        private System.Windows.Forms.Timer tmrMouse;
        private Button cmdCfg;
        private TextBox tbClick;
        private Button cmdGuardarPoligonos;
        private Button cmdCargarPoligonos;
        private Button cmdBorrarAreas;
        private TextBox tbMinX;
        private TextBox tbMaxX;
        private TextBox tbMinY;
        private TextBox tbMaxY;
        private CheckBox chkCircularH;
        private CheckBox chkClickNoPreciso;
        private CheckBox chkAreas;
        private CheckBox chkCircularV;
        private Button cmdActivar;
        private System.Windows.Forms.Timer tmrClic;
        private TextBox tbClicMs;
        private CheckBox chkClickActivo;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
