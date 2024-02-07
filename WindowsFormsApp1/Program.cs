using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Habilita estilos visuais para o aplicativo
            Application.EnableVisualStyles();
            // Define o comportamento padrão de renderização de texto compatível com versões anteriores do Windows
            Application.SetCompatibleTextRenderingDefault(false);
            // Inicia o aplicativo e mostra o formulário principal (PlugNotas)
            Application.Run(new PlugNotas());
        }
    }
}
