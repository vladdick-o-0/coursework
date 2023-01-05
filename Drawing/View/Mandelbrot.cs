using System;
using System.Drawing;
using System.Windows.Forms;
using Drawing.Model;

namespace Drawing
{
    public partial class Mandelbrot : Form
    {
        public ScreenPixelManage myPixelManager;                   // Used for conversions between maths and pixel coordinates.
        public ComplexPoint zoomCoord1 = new ComplexPoint(-1, 1);  // First point (lower-left) of zoom rectangle.
        public ComplexPoint zoomCoord2 = new ComplexPoint(-2, 1);  // Second point (upper-right) of zoom rectangle.
        public double yMin = -2.0;                                 // Default minimum Y for the set to render.
        public double yMax = 0.0;                                  // Default maximum Y for the set to render.
        public double xMin = -2.0;                                 // Default minimum X for the set to render.
        public double xMax = 1.0;                                  // Default maximum X for the set to render.
        public int kMax = 3000;                                    // Default maximum number of iterations for Mandelbrot calculation.
        public int numColours = 85;                                // Default number of colours to use in colour table.
        public int zoomScale = 7;                                  // Default amount to zoom in by.

        public Graphics g;                                         // Graphics object: all graphical rendering is done on this object.
        public Bitmap myBitmap;                                    // Bitmap used to draw images.
        public double xValue;                                      // Save x coordinate on screen click.
        public double yValue;                                      // Save y coordinate on screen click.
        public int undoNum = 0;                                    // Undo count, used when undoing user opertions in the form controls.
        public string userName;                                    // User name.
        public ColourTable colourTable = null;                     // Colour table.

        Controller controller;
        private System.Windows.Forms.Timer tmr;
        public Mandelbrot()
        {
            controller = new Controller(new PictureCreating());
            InitializeComponent();

            tmr = new System.Windows.Forms.Timer();
            tmr.Tick += delegate {
                this.Close();
            };
            tmr.Interval = 1000*60*5;
            tmr.Start();
        }
        

        public void Form1_Load(object sender, EventArgs e)
        {
            controller.FormLoad(this);
        }

        public void generate_Click(object sender, EventArgs e)
        {
            controller.RenderImage(this);
        }

        public void mouseClickOnForm(object sender, MouseEventArgs e)
        {
            controller.MouseClickOnForm(this, e);
        }

        public void mouseUpOnForm(object sender, MouseEventArgs e)
        {
            controller.MouseUpOnForm(this, e);
        }

        public void undo_Click(object sender, EventArgs e)
        {
            controller.UndoClick(this);
        }
        public void Mandelbrot_Paint(object sender, PaintEventArgs e)
        {
            controller.MandelbrotPaint(this, e);
        }
    }
}
