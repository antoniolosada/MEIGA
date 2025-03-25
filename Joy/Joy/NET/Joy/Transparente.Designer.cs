namespace Joy
{
    partial class frmTransparente
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tmrMouse = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // tmrMouse
            // 
            tmrMouse.Enabled = true;
            tmrMouse.Tick += tmrMouse_Tick;
            // 
            // frmTransparente
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1143, 750);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmTransparente";
            Text = "Form2";
            Activated += frmTransparente_Activated;
            FormClosing += frmTransparente_FormClosing;
            Click += frmTransparente_Click;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer tmrMouse;
    }
}