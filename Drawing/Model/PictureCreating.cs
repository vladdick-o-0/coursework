using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Windows.Forms;
using static Drawing.Mandelbrot;
using System.Security.Cryptography;

namespace Drawing.Model
{
    internal class PictureCreating
    {
        
        public void RenderImage(Mandelbrot Form)
        {
            try
            {
                Form.statusLabel.Text = "Status: Rendering";
                if (
                    Convert.ToBoolean(Form.iterationCountTextBox.Text.Equals("")) ||
                    Convert.ToBoolean(Form.yMinCheckBox.Text.Equals("")) ||
                    Convert.ToBoolean(Form.yMaxCheckBox.Text.Equals("")) ||
                    Convert.ToBoolean(Form.xMinCheckBox.Text.Equals("")) ||
                    Convert.ToBoolean(Form.xMaxCheckBox.Text.Equals("")))
                {
                    // Choose default parameters and warn the user if the settings are all empty.
                    Form.iterationCountTextBox.Text = "85";
                    Form.yMinCheckBox.Text = "-1.2";
                    Form.yMaxCheckBox.Text = "1.2";
                    Form.xMinCheckBox.Text = "-2.2";
                    Form.xMaxCheckBox.Text = "1.2";
                    MessageBox.Show("Invalid fields detected. Using default values.");
                    Form.statusLabel.Text = "Status: Error";
                    return;

                }
                else
                {
                    // Show zoom and undo controls.
                    Form.zoomCheckbox.Show();
                    Form.undoButton.Show();
                    Form.undoNum++;
                }

                // Mandelbrot iteration count.
                Form.kMax = Convert.ToInt32(Form.iterationCountTextBox.Text);
                Form.numColours = Form.kMax;

                // If colourTable is not yet created or kMax has changed, create colourTable.
                if ((Form.colourTable == null) || (Form.kMax != Form.colourTable.kMax) || (Form.numColours != Form.colourTable.nColour))
                {
                    Form.colourTable = new ColourTable(Form.numColours, Form.kMax);
                }

                // Get the x, y range (mathematical coordinates) to plot.
                Form.yMin = Convert.ToDouble(Form.yMinCheckBox.Text);
                Form.yMax = Convert.ToDouble(Form.yMaxCheckBox.Text);
                Form.xMin = Convert.ToDouble(Form.xMinCheckBox.Text);
                Form.xMax = Convert.ToDouble(Form.xMaxCheckBox.Text);

                // Zoom scale.
                //zoomScale = Convert.ToInt16(zoomTextBox.Text);
                Form.zoomScale = 7;

                // Clear any existing graphics content.
                Form.g.Clear(Color.White);

                // Initialise working variables.
                int height = (int)Form.g.VisibleClipBounds.Size.Height;
                int kLast = -1;
                double modulusSquared;
                Color color;
                Color colorLast = Color.Red;

                // Get screen boundary (lower left & upper right). This is
                // used when calculating the pixel scaling factors.
                ComplexPoint screenBottomLeft = new ComplexPoint(Form.xMin, Form.yMin);
                ComplexPoint screenTopRight = new ComplexPoint(Form.xMax, Form.yMax);

                Form.myPixelManager = new ScreenPixelManage(Form.g, screenBottomLeft, screenTopRight);

                int xyPixelStep = 1;
                ComplexPoint pixelStep = new ComplexPoint(xyPixelStep, xyPixelStep);
                ComplexPoint xyStep = Form.myPixelManager.GetDeltaMathsCoord(pixelStep);

                // Main loop, nested over Y (outer) and X (inner) values.
                int lineNumber = 0;
                int yPix = Form.myBitmap.Height - 1;
                for (double y = Form.yMin; y < Form.yMax; y += xyStep.y)
                {
                    int xPix = 0;
                    for (double x = Form.xMin; x < Form.xMax; x += xyStep.x)
                    {
                        // Create complex point C = x + i*y.
                        ComplexPoint c = new ComplexPoint(x, y);

                        // Initialise complex value Zk.
                        ComplexPoint zk = new ComplexPoint(0, 0);

                        // Do the main Mandelbrot calculation. Iterate until the equation
                        // converges or the maximum number of iterations is reached.
                        int k = 0;
                        do
                        {
                            zk = zk.doZSqplusC(c);
                            modulusSquared = zk.doModulusZSq();
                            k++;
                        } while ((modulusSquared <= 4.0) && (k < Form.kMax));

                        if (k < Form.kMax)
                        {
                            // Max number of iterations was not reached. This means that the
                            // equation converged. Now assign a colour to the current pixel that
                            // depends on the number of iterations, k, that were done.

                            if (k == kLast)
                            {
                                // If the iteration count is the same as the last count, re-use the
                                // last pen. This avoids re-calculating colour factors which is
                                // computationally intensive. We benefit from this often because
                                // adjacent pixels are often the same colour, especially in large parts
                                // of the Mandelbrot set that are away from the areas of detail.
                                color = colorLast;
                            }
                            else
                            {
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
                                color = Form.colourTable.GetColour(k);
                                colorLast = color;
                            }

                            // Draw single pixel
                            if (xyPixelStep == 1)
                            {
                                // Pixel step is 1, set a single pixel.
                                if ((xPix < Form.myBitmap.Width) && (yPix >= 0))
                                {
                                    Form.myBitmap.SetPixel(xPix, yPix, color);
                                }

                            }
                        }
                        xPix += xyPixelStep;
                    }
                    yPix -= xyPixelStep;
                    lineNumber++;
                    if (Form.radioButton2.Checked && ((lineNumber % 50) == 0))
                    {
                        Form.Refresh();
                    }

                }


                Form.label1.Visible = false;
                Form.label7.Visible = false;
                Form.label8.Visible = false;
                Form.label9.Visible = false;

                // Coordinate axes
                if (Form.yMinCheckBox.Text == "-1.2" &&
                Form.yMaxCheckBox.Text == "1.2" &&
                Form.xMinCheckBox.Text == "-2.2" &&
                Form.xMaxCheckBox.Text == "1.2")
                {
                    Pen p = new Pen(Color.Black, 2);
                    Form.g.DrawLine(p, 0, 361, Form.myBitmap.Width, 361);
                    Form.g.DrawLine(p, 655, 0, 655, Form.myBitmap.Height);

                    // X
                    Form.g.DrawLine(p, 60, 361 - 10, 60, 361 + 10);
                    Form.g.DrawLine(p, 805, 361 - 10, 805, 361 + 10);
                    // Y
                    Form.g.DrawLine(p, 655 - 10, 58, 655 + 10, 58);
                    Form.g.DrawLine(p, 655 - 10, 664, 655 + 10, 664);

                    Form.label1.Visible = true;
                    Form.label7.Visible = true;
                    Form.label8.Visible = true;
                    Form.label9.Visible = true;
                }

                // Finished rendering
                Form.Refresh();
                Form.statusLabel.Text = "Status: Render complete";

                // Save current settings to undo file.
                StreamWriter writer = new StreamWriter(@"C:\Users\" + Form.userName + "\\mandelbrot_config\\Undo\\undo" + Form.undoNum + ".txt");
                writer.Write(Form.iterationCountTextBox.Text + Environment.NewLine + Form.yMinCheckBox.Text + Environment.NewLine + Form.yMaxCheckBox.Text +
                    Environment.NewLine + Form.xMinCheckBox.Text + Environment.NewLine + Form.xMaxCheckBox.Text);
                writer.Close();
                writer.Dispose();
            }
            catch (Exception e2)
            {
                MessageBox.Show("Exception Trapped: " + e2.Message, "Error");
                Form.statusLabel.Text = "Status: Error";
            }
        }

        public static Color colorFromHSLA(double H, double S, double L)
        {
            double v;
            double r, g, b;

            r = L;   // Set RGB all equal to L, defaulting to grey.
            g = L;
            b = L;

            // Standard HSL to RGB conversion. This is described in
            // detail at:
            // http://www.niwa.nu/2013/05/math-behind-colorspace-conversions-rgb-hsl/
            v = (L <= 0.5) ? (L * (1.0 + S)) : (L + S - L * S);

            if (v > 0)
            {
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

                switch (sextant)
                {
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

        internal void MandelbrotPaint(Mandelbrot Form, PaintEventArgs e)
        {
            Graphics graphicsObj = e.Graphics;
            graphicsObj.DrawImage(Form.myBitmap, 0, 0, Form.myBitmap.Width, Form.myBitmap.Height);
            graphicsObj.Dispose();
        }
    }
}
