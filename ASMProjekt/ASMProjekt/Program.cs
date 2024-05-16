using System;

using System.Windows.Forms;


namespace ASMProjekt
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Utworzenie instancji klasy Window
            Window mainWindow = new Window();

            // Wyświetlenie okna głównego
            Application.Run(mainWindow);
        }
    }
}
