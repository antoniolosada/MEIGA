using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEIGA_CFG
{
    public partial class frmCursor : Form
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private Timer timer;
        private Image cursorImage;

        public frmCursor()
        {
            // Configurar la ventana
            this.Text = "Segundo Cursor";
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;
            this.TopMost = true;
            this.ShowInTaskbar = false;

            // Cargar la imagen del cursor
            cursorImage = Image.FromFile("cursor.png");

            // Ajustar el tamaño de la ventana a la imagen del cursor
            this.ClientSize = cursorImage.Size;

            // Crear y configurar el temporizador para actualizar la posición del cursor
            //timer = new Timer();
            //timer.Interval = 10; // Intervalo de 10 milisegundos
            //timer.Tick += new EventHandler(UpdateCursorPosition);
            //timer.Start();

            // Pintar la imagen del cursor en la ventana
            this.Paint += new PaintEventHandler(PintarCursor);
        }
        public void Posicion(Point p)
        { 
            this.Location = p;
            this.TopMost = true;
        }

        private void PintarCursor(object sender, PaintEventArgs e)
        {
            // Dibujar la imagen del cursor
            e.Graphics.DrawImage(cursorImage, 0, 0, cursorImage.Width, cursorImage.Height);
        }

        private void UpdateCursorPosition(object sender, EventArgs e)
        {
            // Actualizar la posición de la ventana para seguir el cursor del ratón
            //Point cursorPosition = Cursor.Position;
            //this.Location = new Point(cursorPosition.X + 10, cursorPosition.Y + 10); // Ajusta la posición según sea necesario
        }
    }
}
