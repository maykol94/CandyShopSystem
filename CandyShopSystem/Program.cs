using System;
using System.Windows.Forms;

namespace CandyShopSystem
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Iniciar la aplicación desde la pantalla de Login
            Application.Run(new FormLogin());
        }
    }
}
