using Drawing.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing
{
    public class ColourTable
    {
        public int kMax;
        public int nColour;
        private double scale;
        private Color[] colourTable;
        public ColourTable(int n, int kMax)
        {
            nColour = n;
            this.kMax = kMax;
            scale = ((double)nColour) / kMax;
            colourTable = new Color[nColour];

            for (int i = 0; i < nColour; i++)
            {
                double colourIndex = ((double)i) / nColour;
                double hue = Math.Pow(colourIndex, 0.25);
                colourTable[i] = PictureCreating.colorFromHSLA(hue, 0.9, 0.6);
            }
        }
        public Color GetColour(int k)
        {
            return colourTable[k];
        }
    }
}
