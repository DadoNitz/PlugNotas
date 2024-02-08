using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        private readonly string authToken;

        public Form4(string authToken)
        {
            InitializeComponent();
            this.authToken = authToken;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Define as propriedades do OpenFileDialog
            openFileDialog1.InitialDirectory = "c:\\"; // Diretório inicial
            openFileDialog1.Filter = "Certificados (*.pfx, *.p12)|*.pfx;*.p12"; // Filtro de arquivos
            openFileDialog1.FilterIndex = 1; // Índice do filtro selecionado

            // Exibe o OpenFileDialog
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Obtém o caminho completo do arquivo selecionado
                    string caminhoArquivo = openFileDialog1.FileName;

                    // Lê o arquivo do certificado
                    byte[] certificadoBytes = File.ReadAllBytes(caminhoArquivo);

                    // Envia o certificado para a API
                    using (HttpClient httpClient = new HttpClient())
                    {
                        // Configura o cabeçalho x-api-key
                        httpClient.DefaultRequestHeaders.Add("x-api-key", authToken);

                        MultipartFormDataContent form = new MultipartFormDataContent();
                        ByteArrayContent fileContent = new ByteArrayContent(certificadoBytes);
                        form.Add(fileContent, "file", Path.GetFileName(caminhoArquivo));

                        HttpResponseMessage response = await httpClient.PostAsync("https://api.sandbox.plugnotas.com.br/certificado", form);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Certificado enviado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Erro ao enviar o certificado: {response.ReasonPhrase}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao enviar o certificado: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
