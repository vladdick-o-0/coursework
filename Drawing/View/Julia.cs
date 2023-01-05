using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using Drawing.Model;

namespace Drawing
{
    public partial class Julia : Form
    {
        public ComplexPoint _param;

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

        ControllerJulia controllerJulia;
        public Julia(ComplexPoint param)
        {
            _param = param;
            controllerJulia = new ControllerJulia(new PictureCreatingJulia());
            InitializeComponent();
        }


        public void Form2_Load(object sender, EventArgs e)
        {
            controllerJulia.FormLoad(this);
        }

        public void generate_Click(object sender, EventArgs e)
        {
            controllerJulia.RenderImage(this);
        }


        public void mouseClickOnForm(object sender, MouseEventArgs e)
        {
            controllerJulia.MouseClickOnForm(this, e);
        }

        public void mouseUpOnForm(object sender, MouseEventArgs e)
        {
            controllerJulia.MouseUpOnForm(this, e);
        }


        public void undo_Click(object sender, EventArgs e)
        {
            controllerJulia.UndoClick(this);
        }
        public void Julia_Paint(object sender, PaintEventArgs e)
        {
            controllerJulia.JuliaPaint(this, e);
        }
    }
}
