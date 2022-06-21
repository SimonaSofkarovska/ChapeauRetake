using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauUI
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
<<<<<<< HEAD
            Application.Run(new Login());
            //Application.Run(new KitchenBar());
=======
            //Application.Run(new Login());
            Application.Run(new WaiterView());
>>>>>>> 34f6ee05e683542b3b480474c62e20a065b88a08
        }
    }
}
