using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stones
{
    
    static class Program
    {
        public const int NeuronSize = 200;
        public static DoubleLayerPerceptron dlp = null; //new DoubleLayerPerceptron(200, 200);
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            dlp = new DoubleLayerPerceptron(NeuronSize, NeuronSize);
            Application.Run(new MainForm());
        }
    }
}
