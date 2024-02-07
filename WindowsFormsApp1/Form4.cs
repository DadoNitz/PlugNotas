using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Define as propriedades do OpenFileDialog
            openFileDialog1.InitialDirectory = "c:\\"; // Diretório inicial
            openFileDialog1.Filter = "Todos os arquivos (*.*)|*.*"; // Filtro de arquivos
            openFileDialog1.FilterIndex = 1; // Índice do filtro selecionado

            // Exibe o OpenFileDialog
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Obtém o nome do arquivo selecionado
                string arquivoSelecionado = openFileDialog1.FileName;

                // Aqui você pode fazer o que quiser com o arquivo selecionado,
                // como exibir o caminho em um MessageBox ou em outro lugar do seu aplicativo
                MessageBox.Show("Arquivo selecionado: " + arquivoSelecionado);
            }
        }
    }
}
