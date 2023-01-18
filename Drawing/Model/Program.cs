using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Mandelbrot());
        }
    }
}

/*
 For each point c in the complex plane do:
    let z:=0.
    do
        let z=z^2+c
    while (|z|^2 > 4) then Color point k color i
Break;
        end if
    end for
        Color
point c black.
    end if
*/