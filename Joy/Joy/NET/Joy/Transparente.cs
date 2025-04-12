using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Joy.frmTransparente;

namespace Joy
{
    public partial class frmTransparente : Form
    {
        [DllImport("user32.dll")]
        private static extern short GetKeyState(int nVirtKey);

        // Códigos de tecla virtual para Ctrl izquierda y derecha
        private const int VK_LCONTROL = 0xA2;
        private const int VK_RCONTROL = 0xA3;
        public const int DESPL_X = 0;
        public const int DESPL_Y = -20;

        const int ANCHO_PUNTO = 5;
        const int ANCHO_CLIC = 10;
        public struct Poligono
        {
            public List<Point> points;
            public Point clic;
        };
        Poligono poligono;
        public List<Poligono> poligonos = new List<Poligono>();

        private bool drawingComplete = false;
        // Declaración para habilitar clics en ventanas transparentes.
        private const int WS_EX_LAYERED = 0x80000;
        private const int WS_EX_TRANSPARENT = 0x20;
        private const int GWL_EXSTYLE = -20;

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        private Point startPoint;
        private bool drawing = false;
        HiddenMouseClickDetector md = new HiddenMouseClickDetector();
        Mouse Raton = new Mouse();
        public frmTransparente()
        {
            InitializeComponent();

            // Configuración del formulario transparente.
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.Lime; // Color clave para la transparencia.
            this.TransparencyKey = Color.Lime;
            this.TopMost = true; // Siempre encima de otras ventanas.        
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            poligono = new Poligono();
            poligono.points = new List<Point>();
            poligono.clic = new Point();

            // Permitir que la ventana sea transparente pero capture clics.
            IntPtr hWnd = this.Handle;
            int exStyle = GetWindowLong(hWnd, GWL_EXSTYLE);
            SetWindowLong(hWnd, GWL_EXSTYLE, exStyle | WS_EX_LAYERED);

            md.Run();
        }
        private void frmTransparente_Click(object sender, EventArgs e)
        {
            // Empezar a dibujar cuando se presiona el botón del ratón.
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                startPoint = ((MouseEventArgs)e).Location;
                drawing = true;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Point p = Cursor.Position;

            Graphics g = e.Graphics;

            // Dibuja los puntos y las líneas entre ellos
            if (poligono.points.Count > 1)
            {
                g.DrawLines(new Pen(Color.Blue, 3), poligono.points.ToArray());
            }

            foreach (Point point in poligono.points)
            {
                g.FillEllipse(Brushes.Red, point.X - ANCHO_PUNTO, point.Y - ANCHO_PUNTO, ANCHO_PUNTO, ANCHO_PUNTO);
            }

            foreach (var poligono in poligonos)
            {
                // Dibuja el polígono final si el dibujo está completo
                if (poligono.points.Count > 2)
                {
                    g.DrawPolygon(new Pen(Color.Red, 3), poligono.points.ToArray());
                }
                g.FillEllipse(Brushes.Red, poligono.clic.X - ANCHO_CLIC, poligono.clic.Y - ANCHO_CLIC, ANCHO_CLIC, ANCHO_CLIC);
            }
        }


        private void frmTransparente_FormClosing(object sender, FormClosingEventArgs e)
        {
            md.Stop();
            drawingComplete = false;
        }

        private void tmrMouse_Tick(object sender, EventArgs e)
        {
            // Leer el estado de ambas teclas Ctrl
            bool ctrlIzquierdaPresionada = (GetKeyState(VK_LCONTROL) & 0x8000) != 0;
            bool ctrlDerechaPresionada = (GetKeyState(VK_RCONTROL) & 0x8000) != 0;

            Point p = Cursor.Position;
            p.X += DESPL_X;
            p.Y += DESPL_Y;

            if (md.clic == 1)
            {
                if (ctrlIzquierdaPresionada)
                {
                    md.clic = 0;
                    HiddenMouseClickDetector.run = false;
                    poligono.clic = new Point(p.X, p.Y);
                    // Finaliza el dibujo al hacer clic derecho
                    poligonos.Add(poligono);
                    poligono = new Poligono();
                    poligono.points = new List<Point>();
                    this.Invalidate(); // Redibuja el formulario para mostrar el polígono completo
                    if (MessageBox.Show("Quiere pintar otra área de selección?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        HiddenMouseClickDetector.run = true;
                        drawingComplete = false;
                    }
                    else
                    {
                        drawingComplete = true;
                        md.Stop();
                        this.Hide();
                    }
                }
                else
                {
                    if (!drawingComplete)
                    {
                        // Añade el punto donde se hizo clic
                        poligono.points.Add(new Point(p.X, p.Y));
                        this.Invalidate(); // Redibuja el formulario
                    }
                }
                md.clic = 0;
            }
        }

        private void frmTransparente_Activated(object sender, EventArgs e)
        {
            // md.Run();
            frmJoy.MaxX = this.Size.Width;
            frmJoy.MaxY = this.Size.Height;

        }
    }
}
