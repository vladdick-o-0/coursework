using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Drawing {
    public partial class Mandelbrot : Form {
        public Mandelbrot() {
            InitializeComponent();
        }

        private ScreenPixelManage myPixelManager;                   // Used for conversions between maths and pixel coordinates.
        private ComplexPoint zoomCoord1 = new ComplexPoint(-1, 1);  // First point (lower-left) of zoom rectangle.
        private ComplexPoint zoomCoord2 = new ComplexPoint(-2, 1);  // Second point (upper-right) of zoom rectangle.
        private double yMin = -2.0;                                 // Default minimum Y for the set to render.
        private double yMax = 0.0;                                  // Default maximum Y for the set to render.
        private double xMin = -2.0;                                 // Default minimum X for the set to render.
        private double xMax = 1.0;                                  // Default maximum X for the set to render.
        private int kMax = 3000;                                    // Default maximum number of iterations for Mandelbrot calculation.
        private int numColours = 85;                                // Default number of colours to use in colour table.
        private int zoomScale = 7;                                  // Default amount to zoom in by.

        private Graphics g;                                         // Graphics object: all graphical rendering is done on this object.
        private Bitmap myBitmap;                                    // Bitmap used to draw images.
        private double xValue;                                      // Save x coordinate on screen click.
        private double yValue;                                      // Save y coordinate on screen click.
        private int undoNum = 0;                                    // Undo count, used when undoing user opertions in the form controls.
        private string userName;                                    // User name.
        private ColourTable colourTable = null;                     // Colour table.

        private void Form1_Load(object sender, EventArgs e) {

            userName = Environment.UserName;
            // Create graphics object for Mandelbrot rendering.
            myBitmap = new Bitmap(ClientRectangle.Width,
                                  ClientRectangle.Height,
                                  System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            g = Graphics.FromImage(myBitmap);
            // Set the background of the form to white.
            g.Clear(Color.White);

            // Hide controls that are not relevant until the first rendering has completed.
            zoomCheckbox.Hide();
            undoButton.Hide();

            // Initialise the user's undo storage.
            Directory.CreateDirectory(@"C:\Users\" + userName + "\\mandelbrot_config\\Undo\\");
            Array.ForEach(Directory.GetFiles(@"c:\Users\" + userName + "\\mandelbrot_config\\Undo\\"), File.Delete);

            // Initialize undo.
            StreamWriter writer = new StreamWriter(@"C:\Users\" + userName + "\\mandelbrot_config\\Undo\\undo" + (undoNum -= 1) + ".txt");
            writer.Write(
                iterationCountTextBox.Text +
                Environment.NewLine +
                yMinCheckBox.Text +
                Environment.NewLine +
                yMaxCheckBox.Text +
                Environment.NewLine +
                xMinCheckBox.Text +
                Environment.NewLine +
                xMaxCheckBox.Text);
            writer.Close();
            writer.Dispose();
        }

        /// <summary>
        /// On-click handler for generate button. Triggers rendering of the Mandelbrot
        /// set using current configuration settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void generate_Click(object sender, EventArgs e) {
            RenderImage();
        }

        private void RenderImage() {
            try {
                statusLabel.Text = "Status: Rendering";
                if (
                    Convert.ToBoolean(iterationCountTextBox.Text.Equals("")) ||
                    Convert.ToBoolean(yMinCheckBox.Text.Equals("")) ||
                    Convert.ToBoolean(yMaxCheckBox.Text.Equals("")) ||
                    Convert.ToBoolean(xMinCheckBox.Text.Equals("")) ||
                    Convert.ToBoolean(xMaxCheckBox.Text.Equals(""))) {
                    // Choose default parameters and warn the user if the settings are all empty.
                    iterationCountTextBox.Text = "85";
                    yMinCheckBox.Text = "-1.2";
                    yMaxCheckBox.Text = "1.2";
                    xMinCheckBox.Text = "-2.2";
                    xMaxCheckBox.Text = "1.2";
                    MessageBox.Show("Invalid fields detected. Using default values.");
                    statusLabel.Text = "Status: Error";
                    return;

                } else {
                    // Show zoom and undo controls.
                    zoomCheckbox.Show();
                    undoButton.Show();
                    undoNum++;
                }

                // Mandelbrot iteration count.
                kMax = Convert.ToInt32(iterationCountTextBox.Text);
                numColours = kMax;

                // If colourTable is not yet created or kMax has changed, create colourTable.
                if ((colourTable == null) || (kMax != colourTable.kMax) || (numColours != colourTable.nColour)) {
                    colourTable = new ColourTable(numColours, kMax);
                }

                // Get the x, y range (mathematical coordinates) to plot.
                yMin = Convert.ToDouble(yMinCheckBox.Text);
                yMax = Convert.ToDouble(yMaxCheckBox.Text);
                xMin = Convert.ToDouble(xMinCheckBox.Text);
                xMax = Convert.ToDouble(xMaxCheckBox.Text);

                // Zoom scale.
                //zoomScale = Convert.ToInt16(zoomTextBox.Text);
                zoomScale = 7;

                // Clear any existing graphics content.
                g.Clear(Color.White);

                // Initialise working variables.
                int height = (int)g.VisibleClipBounds.Size.Height;
                int kLast = -1;
                double modulusSquared;
                Color color;
                Color colorLast = Color.Red;

                // Get screen boundary (lower left & upper right). This is
                // used when calculating the pixel scaling factors.
                ComplexPoint screenBottomLeft = new ComplexPoint(xMin, yMin);
                ComplexPoint screenTopRight = new ComplexPoint(xMax, yMax);

                myPixelManager = new ScreenPixelManage(g, screenBottomLeft, screenTopRight);

                int xyPixelStep = 1;
                ComplexPoint pixelStep = new ComplexPoint(xyPixelStep, xyPixelStep);
                ComplexPoint xyStep = myPixelManager.GetDeltaMathsCoord(pixelStep);

                // Start stopwatch - used to measure performance improvements
                // (from improving the efficiency of the maths implementation).
                Stopwatch sw = new Stopwatch();
                sw.Start();

                // Main loop, nested over Y (outer) and X (inner) values.
                int lineNumber = 0;
                int yPix = myBitmap.Height - 1;
                for (double y = yMin; y < yMax; y += xyStep.y) {
                    int xPix = 0;
                    for (double x = xMin; x < xMax; x += xyStep.x) {
                        // Create complex point C = x + i*y.
                        ComplexPoint c = new ComplexPoint(x, y);

                        // Initialise complex value Zk.
                        ComplexPoint zk = new ComplexPoint(0, 0);

                        // Do the main Mandelbrot calculation. Iterate until the equation
                        // converges or the maximum number of iterations is reached.
                        int k = 0;
                        do {
                            zk = zk.doZSqplusC(c);
                            modulusSquared = zk.doModulusZSq();
                            k++;
                        } while ((modulusSquared <= 4.0) && (k < kMax));

                        if (k < kMax) {
                            // Max number of iterations was not reached. This means that the
                            // equation converged. Now assign a colour to the current pixel that
                            // depends on the number of iterations, k, that were done.

                            if (k == kLast) {
                                // If the iteration count is the same as the last count, re-use the
                                // last pen. This avoids re-calculating colour factors which is
                                // computationally intensive. We benefit from this often because
                                // adjacent pixels are often the same colour, especially in large parts
                                // of the Mandelbrot set that are away from the areas of detail.
                                color = colorLast;
                            } else {
                                // Calculate coluor scaling, from k. We don't use complicated/fancy colour
                                // lookup tables. Instead, the following simple conversion works well:
                                //
                                // hue = (k/kMax)**0.25 where the constant 0.25 can be changed if wanted.
                                // This formula stretches colours allowing more to be assigned at higher values
                                // of k, which brings out detail in the Mandelbrot images.

                                // The following is a full colour calculation, replaced now with colour table.
                                // Uncomment and disable the colour table if wanted. The colour table works
                                // well but supports fewer colours than full calculation of hue and colour
                                // using double-precision arithmetic.
                                //double colourIndex = ((double)k) / kMax;
                                //double hue = Math.Pow(colourIndex, 0.25);

                                // Colour table lookup.
                                // Convert the hue value to a useable colour and assign to current pen.
                                // The saturation and lightness are hard-coded at 0.9 and 0.6 respectively,
                                // which work well.
                                color = colourTable.GetColour(k);
                                colorLast = color;
                            }

                            // Draw single pixel
                            if (xyPixelStep == 1) {
                                // Pixel step is 1, set a single pixel.
                                if ((xPix < myBitmap.Width) && (yPix >= 0)) {
                                    myBitmap.SetPixel(xPix, yPix, color);
                                }
                            
                            }
                        }
                        xPix += xyPixelStep;
                    }
                    yPix -= xyPixelStep;
                    lineNumber++;
                    if ((lineNumber % 200) == 0) { // how fast the screen is refreshing
                        Refresh();
                    }
                }
                // Finished rendering. Stop the stopwatch and show the elapsed time.
                sw.Stop();
                Refresh();
                statusLabel.Text = "Status: Render complete";

                // Save current settings to undo file.
                StreamWriter writer = new StreamWriter(@"C:\Users\" + userName + "\\mandelbrot_config\\Undo\\undo" + undoNum + ".txt");
                writer.Write(iterationCountTextBox.Text + Environment.NewLine + yMinCheckBox.Text + Environment.NewLine + yMaxCheckBox.Text + Environment.NewLine + xMinCheckBox.Text + Environment.NewLine + xMaxCheckBox.Text);
                writer.Close();
                writer.Dispose();
            } catch (Exception e2) {
                MessageBox.Show("Exception Trapped: " + e2.Message, "Error");
                statusLabel.Text = "Status: Error";
            }
        }

        /// <summary>
        /// Convert HSL colour value to Color object.
        /// </summary>
        /// <param name="H">Hue</param>
        /// <param name="S">Saturation</param>
        /// <param name="L">Lightness</param>
        /// <returns>Color object</returns>
        private static Color colorFromHSLA(double H, double S, double L) {
            double v;
            double r, g, b;

            r = L;   // Set RGB all equal to L, defaulting to grey.
            g = L;
            b = L;

            // Standard HSL to RGB conversion. This is described in
            // detail at:
            // http://www.niwa.nu/2013/05/math-behind-colorspace-conversions-rgb-hsl/
            v = (L <= 0.5) ? (L * (1.0 + S)) : (L + S - L * S);

            if (v > 0) {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = L + L - v;
                sv = (v - m) / v;
                H *= 6.0;
                sextant = (int)H;
                fract = H - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;

                switch (sextant) {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;

                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;

                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;

                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;

                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;

                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }

            // Create Color object from RGB values.
            Color color = Color.FromArgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
            return color;
        }

        /// <summary>
        /// On-click handler for main form. Defines the points (lower-left and upper-right)
        /// of a zoom rectangle.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mouseClickOnForm(object sender, MouseEventArgs e) {
            if (zoomCheckbox.Checked) {
                Pen box = new Pen(Color.Black);
                double x = Convert.ToDouble(e.X);
                xValue = x; // pixel coordinates
                double y = Convert.ToDouble(e.Y);
                yValue = y;

                // c = x + yi coordinates
                ComplexPoint pointer = new ComplexPoint(xValue, yValue);
                ComplexPoint pointerCoord = myPixelManager.GetAbsoluteMathsCoord(pointer);
                Console.WriteLine(pointerCoord.x);
                Console.WriteLine(pointerCoord.y);

                zoomScale = 7;

                //try {
                //    zoomScale = Convert.ToInt16(zoomTextBox.Text);
                //} catch(Exception c) {
                //    MessageBox.Show("Error: " + c.Message, "Error");
                //}
                // Zoom scale has to be above 0, or their is no point in zooming.
                //if (zoomScale < 1) {
                //    MessageBox.Show("Zoom scale must be above 0");
                //    zoomScale = 7;
                //    zoomTextBox.Text = "7";
                //    return;
                //}

                ComplexPoint pixelCoord = new ComplexPoint((int)(xValue - (1005 / (zoomScale)) / 4), (int)(yValue - (691 / (zoomScale)) / 4));
                zoomCoord1 = myPixelManager.GetAbsoluteMathsCoord(pixelCoord);
            } 
            else
            {
                Pen box = new Pen(Color.Black);
                double x = Convert.ToDouble(e.X);
                xValue = x; // pixel coordinates
                double y = Convert.ToDouble(e.Y);
                yValue = y;

                // c = x + yi coordinates
                ComplexPoint pointer = new ComplexPoint(xValue, yValue);
                ComplexPoint pointerCoord = myPixelManager.GetAbsoluteMathsCoord(pointer);
                //Console.WriteLine(pointerCoord.x);
                //Console.WriteLine(pointerCoord.y);

                zoomScale = 7;
                // Create a new instance of the Form2 class
                Julia secondForm = new Julia(pointerCoord);

                // Show the settings form
                secondForm.Show();

                //using (Julia secondForm = new Julia())
                //{
                //    secondForm.ShowDialog(this);
                //}
            }
        }

        /// <summary>
        /// Mouse-up handler for main form. The coordinates of the rectangle are
        /// saved so the new drawing can be rendered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mouseUpOnForm(object sender, MouseEventArgs e) {
            if (zoomCheckbox.Checked) {
                double x = Convert.ToDouble(e.X);
                double y = Convert.ToDouble(e.Y);

                ComplexPoint pixelCoord = new ComplexPoint((int)(xValue + (1005 / (zoomScale)) / 4), (int)(yValue + (691 / (zoomScale)) / 4));//
                zoomCoord2 = myPixelManager.GetAbsoluteMathsCoord(pixelCoord);

                // Swap to ensure that zoomCoord1 stores the lower-left
                // coordinate for the zoom region, and zoomCoord2 stores the
                // upper right coordinate.
                if (zoomCoord2.x < zoomCoord1.x) {
                    double temp = zoomCoord1.x;
                    zoomCoord1.x = zoomCoord2.x;
                    zoomCoord2.x = temp;
                }
                if (zoomCoord2.y < zoomCoord1.y) {
                    double temp = zoomCoord1.y;
                    zoomCoord1.y = zoomCoord2.y;
                    zoomCoord2.y = temp;
                }
                yMinCheckBox.Text = Convert.ToString(zoomCoord1.y);
                yMaxCheckBox.Text = Convert.ToString(zoomCoord2.y);
                xMinCheckBox.Text = Convert.ToString(zoomCoord1.x);
                xMaxCheckBox.Text = Convert.ToString(zoomCoord2.x);
                RenderImage();
            }
        }

        /// <summary>
        /// This will apply the zoom rectangle coordinates to the
        /// yMin yMax, xMin xMax text boxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e) {
            yMinCheckBox.Text = Convert.ToString(zoomCoord1.y);
            yMaxCheckBox.Text = Convert.ToString(zoomCoord2.y);
            xMinCheckBox.Text = Convert.ToString(zoomCoord1.x);
            xMaxCheckBox.Text = Convert.ToString(zoomCoord2.x);
        }

        /// <summary>
        /// When the undo button is clicked, the last settings are read from
        /// the last undo text file, and the text boxes are set to these settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void undo_Click(object sender, EventArgs e) {
            try {
                var fileContent = File.ReadAllText(@"C:\Users\" + userName + "\\mandelbrot_config\\Undo\\undo" + (undoNum -= 1) + ".txt");
                var array1 = fileContent.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);

                //pixelStepTextBox.Text = array1[0];
                iterationCountTextBox.Text = array1[0];
                yMinCheckBox.Text = array1[1];
                yMaxCheckBox.Text = array1[2];
                xMinCheckBox.Text = array1[3];
                xMaxCheckBox.Text = array1[4];
            } catch (Exception e3) {
                MessageBox.Show("Unable to Undo: " + e3.Message, "Error");
            }
        }

        /// <summary>
        /// Class used for colour lookup table.
        /// </summary>
        private class ColourTable {
            public int kMax;
            public int nColour;
            private double scale;
            private Color[] colourTable;

            /// <summary>
            /// Constructor. Creates lookup table.
            /// </summary>
            /// <param name="n"></param>
            /// <param name="kMax"></param>
            public ColourTable(int n, int kMax) {
                nColour = n;
                this.kMax = kMax;
                scale = ((double)nColour) / kMax;
                colourTable = new Color[nColour];

                for (int i = 0; i < nColour; i++) {
                    double colourIndex = ((double) i) / nColour;
                    double hue = Math.Pow(colourIndex, 0.25);
                    colourTable[i] = colorFromHSLA(hue, 0.9, 0.6);
                }
            }

            /// <summary>
            /// Retrieve the colour from iteration count k.
            /// </summary>
            /// <param name="k"></param>
            /// <returns></returns>
            public Color GetColour(int k) {
                return colourTable[k];
            } 
        }

        // Mandelbrot_Paint handler to draw the image.
        private void Mandelbrot_Paint(object sender, PaintEventArgs e) {
            Graphics graphicsObj = e.Graphics;
            graphicsObj.DrawImage(myBitmap, 0, 0, myBitmap.Width, myBitmap.Height);
            graphicsObj.Dispose();
        }
    }
}
