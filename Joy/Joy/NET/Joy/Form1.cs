using static Joy.frmTransparente;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Joy
{
    public partial class frmJoy : Form
    {
        // Importar la función GetKeyState desde la biblioteca user32
        [DllImport("user32.dll")]
        public static extern short GetKeyState(int nVirtKey);

        // Definir códigos de teclas virtuales
        const int VK_LCONTROL = 0xA2; // Control izquierda
        const int VK_LSHIFT = 0xA0;   // Mayúsculas izquierda
        const int VK_Q = 0x51;        // Letra Q

        bool Cerrar = false;
        public NotifyIcon trayIcon;
        private ContextMenuStrip trayMenu;
        public Icon[] Iconos = new Icon[5];
        public enum TipoIcono : int { activa, desactiva };

        int MARGEN = 20;
        bool Activo = false;
        static string MousePos = "";
        bool Click = false;
        public static int MaxX, MaxY;
        public struct Cfg
        {
            public int IniX;
            public int IniY;
            public int FinX;
            public int FinY;
            public int ClicksMs;
            public bool CircularH, CircularV, AreasActivas, ClicNoPreciso, ClickActivo, AreaLimitada;
        };
        HiddenMouseClickDetector md = new HiddenMouseClickDetector();
        frmTransparente frm = new frmTransparente();
        Mouse Raton = new Mouse();
        Cfg cfg = new Cfg() { IniX = 0, FinX = 1920, IniY = 0, FinY = 1080, ClicksMs = 3000, CircularH = false, CircularV = false, AreasActivas = false, ClicNoPreciso = false, ClickActivo = false, AreaLimitada = false };

        public frmJoy()
        {
            InitializeComponent();
        }

        private void tmrMouse_Tick(object sender, EventArgs e)
        {
            bool isCtrlPressed = (GetKeyState(VK_LCONTROL) & 0x8000) != 0;
            bool isShiftPressed = (GetKeyState(VK_LSHIFT) & 0x8000) != 0;
            bool isQPressed = (GetKeyState(VK_Q) & 0x8000) != 0;

            if (isCtrlPressed && isShiftPressed && isQPressed)
            {
                Cerrar = true;
                Application.Exit();
            }

            if (!Activo) return;

            tbClick.Text = md.clic.ToString();

            tbMouse.Text = Cursor.Position.ToString();

            if (frmJoy.MousePos != tbMouse.Text)
            {
                tmrClic.Enabled = false;
                Click = false;
                tbMouse.BackColor = Color.LightGray;
            }
            else if ((tmrClic.Enabled == false) && (!Click))
            {
                if (chkAreas.Checked)
                {
                    foreach (Poligono pol in frm.poligonos)
                    {
                        if (IsPointInPolygon(pol.points, Cursor.Position))
                        {
                            if (chkClickNoPreciso.Checked)
                                Cursor.Position = new Point(pol.clic.X - frmTransparente.DESPL_X, pol.clic.Y - frmTransparente.DESPL_Y);
                            tmrClic.Interval = int.Parse(tbClicMs.Text);
                            tmrClic.Enabled = true;
                            tbMouse.BackColor = Color.LightSalmon;
                            break;
                        }
                    }
                }
            }
            else if (Click)
                tbMouse.BackColor = Color.LightBlue;


            Point p = Cursor.Position;
            frmJoy.MousePos = tbMouse.Text;
            if (chkCircularH.Checked)
            {
                if (p.X >= int.Parse(tbMaxX.Text))
                    Cursor.Position = new Point(int.Parse(tbMinX.Text), Cursor.Position.Y);
                else if (p.X <= int.Parse(tbMinX.Text))
                    Cursor.Position = new Point(int.Parse(tbMaxX.Text), Cursor.Position.Y);
            }

            if (chkCircularV.Checked)
            {
                if (p.Y >= int.Parse(tbMaxY.Text))
                    Cursor.Position = new Point(Cursor.Position.X, int.Parse(tbMinY.Text));
                else if (p.Y <= int.Parse(tbMinY.Text))
                    Cursor.Position = new Point(Cursor.Position.X, int.Parse(tbMaxY.Text));
            }

            p = Cursor.Position;
            if (chkAreaLimitada.Checked)
            {
                if (p.X >= int.Parse(tbMaxX.Text))
                    Cursor.Position = new Point(int.Parse(tbMaxX.Text), Cursor.Position.Y);
                else if (p.X <= int.Parse(tbMinX.Text))
                    Cursor.Position = new Point(int.Parse(tbMinX.Text), Cursor.Position.Y);

                if (p.Y >= int.Parse(tbMaxY.Text))
                    Cursor.Position = new Point(Cursor.Position.X, int.Parse(tbMaxY.Text));
                else if (p.Y <= int.Parse(tbMinY.Text))
                    Cursor.Position = new Point(Cursor.Position.X, int.Parse(tbMinY.Text));
            }
        }

        private void cmdCfg_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pulse el botón izquierdo del ratón para marcar los vértices del área. El último punto será el punto de pulsación y debe marcarlo con el ratón pulsando Control.");

            Console.WriteLine("---------------------------");

            md.Run();

            frm.ShowDialog();

            tbMaxX.Text = (frmJoy.MaxX - MARGEN).ToString();
            tbMaxY.Text = (frmJoy.MaxY - MARGEN).ToString();
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarCfg(cfg);

            Iconos[(int)TipoIcono.activa] = new Icon(Application.StartupPath + @"\Iconos\activa.ico", 40, 40);
            Iconos[(int)TipoIcono.desactiva] = new Icon(Application.StartupPath + @"\Iconos\desactiva.ico", 40, 40);
            // Create a simple tray menu with only one item.
            trayMenu = new ContextMenuStrip();
            trayMenu.Items.Add("Salir", null, OnExit);
            trayMenu.Items.Add("Activar", null, OnActivate);
            trayMenu.Items.Add("Desactivar", null, OnDisable);
            trayMenu.Items.Add("Ocultar", null, OnHide);
            trayMenu.Items.Add("Mostrar", null, OnShow);

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "XULIA";
            trayIcon.Icon = Iconos[(int)TipoIcono.activa];

            // Add menu to tray icon and show it.
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Visible = true;
            trayIcon.MouseDoubleClick += trayIcon_MouseDoubleClick;
        }
        void CargarCfg(Cfg cfg)
        {
            tbMinX.Text = cfg.IniX.ToString();
            tbMinY.Text = cfg.IniY.ToString();
            tbMaxX.Text = cfg.FinX.ToString();
            tbMaxY.Text = cfg.FinY.ToString();
            tbClicMs.Text = cfg.ClicksMs.ToString();

            chkAreas.Checked = cfg.AreasActivas;
            chkCircularH.Checked = cfg.CircularH;
            chkCircularV.Checked = cfg.CircularV;
            chkClickNoPreciso.Checked = cfg.ClicNoPreciso;
        }

        private void cmdGuardarPoligonos_Click(object sender, EventArgs e)
        {
            GuardarPoligonosEnFichero(frm.poligonos, "");
        }

        #region FuncionesAux
        void GuardarPoligonosEnFichero(List<Poligono> poligonos, string filePath)
        {
            // Crear el cuadro de diálogo para guardar archivo
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            // Configuración del cuadro de diálogo
            saveFileDialog.Title = "Guardar polígonos";
            saveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;

            // Mostrar el cuadro de diálogo
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta seleccionada
                string filepath = saveFileDialog.FileName;

                try
                {
                    // Guardar contenido en el archivo
                    try
                    {
                        cfg.IniX = int.Parse(tbMinX.Text);
                        cfg.FinX = int.Parse(tbMaxX.Text);
                        cfg.IniY = int.Parse(tbMinY.Text);
                        cfg.FinY = int.Parse(tbMaxY.Text);
                        cfg.CircularV = chkCircularV.Checked;
                        cfg.CircularH = chkCircularH.Checked;
                        cfg.ClicNoPreciso = chkClickNoPreciso.Checked;
                        cfg.ClickActivo = chkClickActivo.Checked;
                        cfg.AreasActivas = chkAreas.Checked;
                        cfg.AreaLimitada = chkAreaLimitada.Checked;
                        cfg.ClicksMs = int.Parse(tbClicMs.Text);

                        GuardarPoligonos(poligonos, cfg, filepath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al guardar los polígonos: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al guardar el archivo: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("El usuario canceló la operación.");
            }
        }

        List<Poligono> LeerPoligonosDeFichero(string filePath)
        {
            // Crear el cuadro de diálogo para abrir archivo
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Configuración del cuadro de diálogo
            openFileDialog.Title = "Abrir archivo de texto";
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";

            // Mostrar el cuadro de diálogo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Obtener la ruta seleccionada
                string filepath = openFileDialog.FileName;

                try
                {
                    try
                    {
                        return LeerPoligonos(filepath);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error al leer los polígonos: {ex.Message}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al leer el archivo: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine("El usuario canceló la operación.");
            }
            return new List<Poligono>();
        }

        void GuardarPoligonos(List<Poligono> poligonos, Cfg cfg, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (var poligono in poligonos)
                    {
                        // Guardar los puntos
                        writer.WriteLine("Puntos:");
                        foreach (var point in poligono.points)
                        {
                            writer.WriteLine($"{point.X},{point.Y}");
                        }

                        // Guardar el clic
                        writer.WriteLine("Clic:");
                        writer.WriteLine($"{poligono.clic.X},{poligono.clic.Y}");
                        writer.WriteLine($"{tbClick.Text}");

                        // Separador entre polígonos
                        writer.WriteLine("END");
                    }
                    //Guardar Cfg
                    writer.WriteLine("Cfg:");
                    writer.WriteLine(cfg.IniX);
                    writer.WriteLine(cfg.FinX);
                    writer.WriteLine(cfg.IniY);
                    writer.WriteLine(cfg.FinY);
                    writer.WriteLine((cfg.AreasActivas ? "S" : "N"));
                    writer.WriteLine((cfg.ClicNoPreciso ? "S" : "N"));
                    writer.WriteLine((cfg.CircularH ? "S" : "N"));
                    writer.WriteLine((cfg.CircularV ? "S" : "N"));
                    writer.WriteLine((cfg.ClickActivo ? "S" : "N"));
                    writer.WriteLine((cfg.AreaLimitada ? "S" : "N"));
                    writer.WriteLine(cfg.ClicksMs);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al guardar los polígonos: {ex.Message}");
            }
        }

        List<Poligono> LeerPoligonos(string filePath)
        {
            var poligonos = new List<Poligono>();
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    Poligono poligono = new Poligono { points = new List<Point>() };

                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line == "Puntos:")
                        {
                            // Leer los puntos
                            while ((line = reader.ReadLine()) != null && line != "Clic:" && line != "END")
                            {
                                var parts = line.Split(',');
                                int x = int.Parse(parts[0]);
                                int y = int.Parse(parts[1]);
                                poligono.points.Add(new Point(x, y));
                            }
                        }

                        if (line == "Clic:")
                        {
                            // Leer el clic
                            line = reader.ReadLine();
                            var parts = line.Split(',');
                            int x = int.Parse(parts[0]);
                            int y = int.Parse(parts[1]);
                            poligono.clic = new Point(x, y);
                            tbClick.Text = reader.ReadLine();
                        }
                        if (line == "Cfg:")
                        {
                            // Leer el clic
                            cfg.IniX = int.Parse(reader.ReadLine());
                            cfg.FinX = int.Parse(reader.ReadLine());
                            cfg.IniY = int.Parse(reader.ReadLine());
                            cfg.FinY = int.Parse(reader.ReadLine());
                            cfg.AreasActivas = (reader.ReadLine() == "S" ? true : false);
                            cfg.ClicNoPreciso = (reader.ReadLine() == "S" ? true : false);
                            cfg.CircularH = (reader.ReadLine() == "S" ? true : false);
                            cfg.CircularV = (reader.ReadLine() == "S" ? true : false);
                            cfg.ClickActivo = (reader.ReadLine() == "S" ? true : false);
                            cfg.AreaLimitada = (reader.ReadLine() == "S" ? true : false);
                            cfg.ClicksMs = int.Parse(reader.ReadLine());

                            tbMinX.Text = cfg.IniX.ToString();
                            tbMaxX.Text = cfg.FinX.ToString();
                            tbMinY.Text = cfg.IniY.ToString();
                            tbMaxY.Text = cfg.FinY.ToString();
                            tbClicMs.Text = cfg.ClicksMs.ToString();
                            chkAreas.Checked = cfg.AreasActivas;
                            chkClickNoPreciso.Checked = cfg.ClicNoPreciso;
                            chkCircularH.Checked = cfg.CircularH;
                            chkCircularV.Checked = cfg.CircularV;
                            chkClickActivo.Checked = cfg.ClickActivo;
                            chkAreaLimitada.Checked = cfg.AreaLimitada;
                        }

                        if (line == "END")
                        {
                            // Fin de un polígono, añadir a la lista
                            poligonos.Add(poligono);
                            poligono = new Poligono { points = new List<Point>() };
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer los polígonos: {ex.Message}");
            }

            return poligonos;
        }


        #endregion FuncionesAux

        private void cmdCargarPoligonos_Click(object sender, EventArgs e)
        {
            frm.poligonos = LeerPoligonosDeFichero("");
        }

        private void tbMinX_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkAreas_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cmdVerAreas_Click(object sender, EventArgs e)
        {
            frm.poligonos = new List<Poligono> { new Poligono { points = new List<Point>() } };
        }

        private void cmdActivar_Click(object sender, EventArgs e)
        {
            if (cmdActivar.Text == "Activar")
            {
                MessageBox.Show("Puede salir de Joy pulsando Ctrl+Mayúsculas+Q");
                Activar();
            }
            else
                Desactivar();
        }

        void Activar()
        {
            tmrMouse.Enabled = true;
            tmrClic.Enabled = false;
            cmdActivar.Text = "Desactivar";
            Activo = true;
        }
        void Desactivar()
        {
            Activo = false;
            tmrMouse.Enabled = false;
            tmrClic.Enabled = false;
            cmdActivar.Text = "Activar";
        }

        private void tmrClic_Tick(object sender, EventArgs e)
        {
            if (chkClickActivo.Checked)
            {
                if (chkAreas.Checked)
                {
                    foreach (Poligono pol in frm.poligonos)
                    {
                        if (IsPointInPolygon(pol.points, Cursor.Position))
                        {
                            if (chkClickNoPreciso.Checked)
                                Cursor.Position = new Point(pol.clic.X - frmTransparente.DESPL_X, pol.clic.Y - frmTransparente.DESPL_Y);
                            Raton.sendMouseClick(Cursor.Position);
                            break;
                        }
                    }
                }
                else
                {
                    Raton.sendMouseClick(Cursor.Position);
                }
                Click = true;
                tmrClic.Enabled = false;
            }
        }
        static bool IsPointInPolygon(List<Point> polygon, Point testPoint)
        {
            int crossings = 0;

            for (int i = 0; i < polygon.Count; i++)
            {
                Point current = polygon[i];
                Point next = polygon[(i + 1) % polygon.Count];
                current.Y -= frmTransparente.DESPL_Y;
                current.X -= frmTransparente.DESPL_X;
                next.Y -= frmTransparente.DESPL_Y;
                next.X -= frmTransparente.DESPL_X;

                // Comprueba si el segmento cruza la línea horizontal en la coordenada Y del punto de prueba
                if ((current.Y > testPoint.Y) != (next.Y > testPoint.Y))
                {
                    float slope = (float)(next.X - current.X) / (next.Y - current.Y);
                    float intersectionX = current.X + slope * (testPoint.Y - current.Y);

                    if (intersectionX > testPoint.X)
                    {
                        crossings++;
                    }
                }
            }

            // Si el número de cruces es impar, el punto está dentro del polígono
            return (crossings % 2) != 0;
        }

        #region trayIcon
        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
        }

        private void OnExit(object sender, EventArgs e)
        {
            Cerrar = true;
            Application.Exit();
        }
        private void OnActivate(object sender, EventArgs e)
        {
            Activar();
        }
        private void OnDisable(object sender, EventArgs e)
        {
            Desactivar();
        }
        private void OnHide(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void OnShow(object sender, EventArgs e)
        {
            this.Show();
        }
        #endregion trayIcon

        private void frmJoy_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Cerrar) e.Cancel = true;
            this.Hide();
        }
    }
}
