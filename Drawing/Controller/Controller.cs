using Drawing.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace Drawing
{
    internal class Controller
    {
        PictureCreating pictureCreating;
        public PictureCreating pic
        {
            get
            {
                return pictureCreating;
            }
            set
            {
                pictureCreating = value;
            }
        }

        public Controller(PictureCreating pic)
        {
            pictureCreating = pic;
        }
        public void FormLoad(Mandelbrot Form)
        {
            Form.userName = Environment.UserName;
            // Create graphics object for Mandelbrot rendering.
            Form.myBitmap = new Bitmap(Form.ClientRectangle.Width,
            Form.ClientRectangle.Height,
                                  System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Form.g = Graphics.FromImage(Form.myBitmap);
            // Set the background of the form to white.
            Form.g.Clear(Color.White);

            // Hide controls that are not relevant until the first rendering has completed.
            Form.zoomCheckbox.Hide();
            Form.undoButton.Hide();

            // Initialise the user's undo storage.
            Directory.CreateDirectory(@"C:\Users\" + Form.userName + "\\mandelbrot_config\\Undo\\");
            Array.ForEach(Directory.GetFiles(@"c:\Users\" + Form.userName + "\\mandelbrot_config\\Undo\\"), File.Delete);

            // Initialize undo.
            StreamWriter writer = new StreamWriter(@"C:\Users\" + Form.userName + "\\mandelbrot_config\\Undo\\undo" + (Form.undoNum -= 1) + ".txt");
            writer.Write(
                Form.iterationCountTextBox.Text +
                Environment.NewLine +
                Form.yMinCheckBox.Text +
                Environment.NewLine +
                Form.yMaxCheckBox.Text +
                Environment.NewLine +
                Form.xMinCheckBox.Text +
                Environment.NewLine +
                Form.xMaxCheckBox.Text);
            writer.Close();
            writer.Dispose();
        }

        public void MouseClickOnForm(Mandelbrot Form, MouseEventArgs e)
        {
            if (Form.zoomCheckbox.Checked)
            {
                Pen box = new Pen(Color.Black);
                double x = Convert.ToDouble(e.X);
                Form.xValue = x; // pixel coordinates
                double y = Convert.ToDouble(e.Y);
                Form.yValue = y;

                // c = x + yi coordinates
                ComplexPoint pointer = new ComplexPoint(Form.xValue, Form.yValue);
                ComplexPoint pointerCoord = Form.myPixelManager.GetAbsoluteMathsCoord(pointer);
                Console.WriteLine(pointerCoord.x);
                Console.WriteLine(pointerCoord.y);

                Form.zoomScale = 7;

                ComplexPoint pixelCoord = new ComplexPoint((int)(Form.xValue - (1005 / (Form.zoomScale)) / 4),
                                        (int)(Form.yValue - (691 / (Form.zoomScale)) / 4));
                Form.zoomCoord1 = Form.myPixelManager.GetAbsoluteMathsCoord(pixelCoord);
            }
            else
            {
                Pen box = new Pen(Color.Black);
                double x = Convert.ToDouble(e.X);
                Form.xValue = x; // pixel coordinates
                double y = Convert.ToDouble(e.Y);
                Form.yValue = y;

                // c = x + yi coordinates
                ComplexPoint pointer = new ComplexPoint(Form.xValue, Form.yValue);
                ComplexPoint pointerCoord = Form.myPixelManager.GetAbsoluteMathsCoord(pointer);
                //Console.WriteLine(pointerCoord.x);
                //Console.WriteLine(pointerCoord.y);

                Form.zoomScale = 7;
                // Create a new instance of the Form2 class
                Julia secondForm = new Julia(pointerCoord);

                // Show the settings form
                secondForm.Show();

                //using (Julia secondForm = new Julia())
                //{
                //    secondpictureCreating.ShowDialog(this);
                //}
            }
        }
        public void MouseUpOnForm(Mandelbrot Form, MouseEventArgs e)
        {
            if (Form.zoomCheckbox.Checked)
            {
                double x = Convert.ToDouble(e.X);
                double y = Convert.ToDouble(e.Y);

                ComplexPoint pixelCoord = new ComplexPoint((int)(Form.xValue + (1005 / (Form.zoomScale)) / 4), 
                    (int)(Form.yValue + (691 / (Form.zoomScale)) / 4));//
                Form.zoomCoord2 = Form.myPixelManager.GetAbsoluteMathsCoord(pixelCoord);

                // Swap to ensure that zoomCoord1 stores the lower-left
                // coordinate for the zoom region, and zoomCoord2 stores the
                // upper right coordinate.
                if (Form.zoomCoord2.x < Form.zoomCoord1.x)
                {
                    double temp = Form.zoomCoord1.x;
                    Form.zoomCoord1.x = Form.zoomCoord2.x;
                    Form.zoomCoord2.x = temp;
                }
                if (Form.zoomCoord2.y < Form.zoomCoord1.y)
                {
                    double temp = Form.zoomCoord1.y;
                    Form.zoomCoord1.y = Form.zoomCoord2.y;
                    Form.zoomCoord2.y = temp;
                }
                Form.yMinCheckBox.Text = Convert.ToString(Form.zoomCoord1.y);
                Form.yMaxCheckBox.Text = Convert.ToString(Form.zoomCoord2.y);
                Form.xMinCheckBox.Text = Convert.ToString(Form.zoomCoord1.x);
                Form.xMaxCheckBox.Text = Convert.ToString(Form.zoomCoord2.x);
                pictureCreating.RenderImage(Form);
            }
        }
        public void UndoClick(Mandelbrot Form)
        {
            try
            {
                var fileContent = File.ReadAllText(@"C:\Users\" + Form.userName + "\\mandelbrot_config\\Undo\\undo" + (Form.undoNum -= 1) + ".txt");
                var array1 = fileContent.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);

                //pixelStepTextBox.Text = array1[0];
                Form.iterationCountTextBox.Text = array1[0];
                Form.yMinCheckBox.Text = array1[1];
                Form.yMaxCheckBox.Text = array1[2];
                Form.xMinCheckBox.Text = array1[3];
                Form.xMaxCheckBox.Text = array1[4];
            }
            catch (Exception e3)
            {
                MessageBox.Show("Unable to Undo: " + e3.Message, "Error");
            }
        }

        internal void RenderImage(Mandelbrot Form)
        {
            pictureCreating.RenderImage(Form);
        }

        internal void MandelbrotPaint(Mandelbrot Form, PaintEventArgs e)
        {
            pictureCreating.MandelbrotPaint(Form, e);
        }
    }
}
