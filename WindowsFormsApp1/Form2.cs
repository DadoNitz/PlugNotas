using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

        }

        private async void ButtonConsultar_Click(object sender, EventArgs e)
        {
            // Obtém o ID da nota da TextBox
            string idNota = textBoxNota.Text;

            // Verifica se o ID da nota não está vazio
            if (!string.IsNullOrEmpty(idNota))
            {
                // Chama o método para consultar a nota fiscal
                await ConsultarNota(idNota);
            }
            else
            {
                MessageBox.Show("Por favor, informe o ID da nota fiscal.", "Aviso");
            }
        }

        // Método para consultar a nota fiscal
        private async Task ConsultarNota(string idNota)
        {
            // URL da API e chave de autenticação
            string apiUrl = $"https://api.sandbox.plugnotas.com.br/nfe/{idNota}/resumo";
            string authToken = "2da392a6-79d2-4304-a8b7-959572c7e44d";

            // Instância de HttpClient
            using (HttpClient httpClient = new HttpClient())
            {
                // Adiciona a chave de autenticação no header da requisição
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                try
                {
                    // Faz a requisição GET para a API
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        // Se a requisição for bem-sucedida, lê o corpo da resposta
                        string responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(JsonBeautify(responseBody), "Resposta da API");
                    }
                    else
                    {
                        // Se a requisição não for bem-sucedida, exibe uma mensagem de erro
                        MessageBox.Show($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase}", "Erro");
                    }
                }
                catch (Exception ex)
                {
                    // Se ocorrer um erro durante a requisição, exibe uma mensagem de erro
                    MessageBox.Show($"Erro na requisição: {ex.Message}", "Erro");
                }
            }
        }

        // Método para formatar o JSON de maneira legível
        private string JsonBeautify(string inputJson)
        {
            dynamic parsedJson = Newtonsoft.Json.JsonConvert.DeserializeObject(inputJson);
            return Newtonsoft.Json.JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
        }

        private void button4_Click(object sender, EventArgs e)
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void cancelarbutton_Click(object sender, EventArgs e)
        {
            // Obtém o ID da nota da TextBox
            string idNota = textBoxNota.Text;

            // Verifica se o ID da nota não está vazio
            if (!string.IsNullOrEmpty(idNota))
            {
                // Solicita a justificativa ao usuário
                string justificativa = PedirJustificativa();

                // Verifica se o usuário forneceu uma justificativa
                if (!string.IsNullOrEmpty(justificativa))
                {
                    // Chama o método para cancelar a nota fiscal
                    await CancelarNota(idNota, justificativa);
                }
                else
                {
                    MessageBox.Show("Por favor, forneça uma justificativa para o cancelamento da nota fiscal.", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Por favor, informe o ID da nota fiscal.", "Aviso");
            }
        }

        // Método para solicitar a justificativa ao usuário
        private string PedirJustificativa()
        {
            using (var form = new Form())
            {
                form.Text = "Informe a Justificativa";
                var label = new Label() { Left = 50, Top = 20, Text = "Justificativa:" };
                var textBox = new TextBox() { Left = 50, Top = 50, Width = 400 };
                var button = new Button() { Text = "Confirmar", Left = 350, Width = 100, Top = 100, DialogResult = DialogResult.OK };
                button.Click += (sender, e) => { form.Close(); };
                form.Controls.Add(textBox);
                form.Controls.Add(label);
                form.Controls.Add(button);
                form.AcceptButton = button;

                return form.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        // Método para cancelar a nota fiscal com a justificativa
        private async Task CancelarNota(string idNota, string justificativa)
        {
            // URL da API e chave de autenticação
            string apiUrl = $"https://api.sandbox.plugnotas.com.br/nfe/{idNota}/cancelamento";
            string authToken = "2da392a6-79d2-4304-a8b7-959572c7e44d";

            // Instância de HttpClient
            using (HttpClient httpClient = new HttpClient())
            {
                // Adiciona a chave de autenticação no header da requisição
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                try
                {
                    // Monta o payload de cancelamento com a justificativa
                    var cancelamentoPayload = new { justificativa = justificativa };
                    var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(cancelamentoPayload);
                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    // Envia a requisição POST para a API para cancelar a nota fiscal
                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Nota fiscal cancelada com sucesso: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao cancelar a nota fiscal: {response.StatusCode} - {response.ReasonPhrase}", "Erro");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cancelar a nota fiscal: {ex.Message}", "Erro");
                }
            }
        }
        private async void consultarcancelamentobutton_Click(object sender, EventArgs e)
        {
            // Obtém o ID da nota da TextBox
            string idNota = textBoxNota.Text;

            // Verifica se o ID da nota não está vazio
            if (!string.IsNullOrEmpty(idNota))
            {
                // Chama o método para consultar o cancelamento da nota fiscal
                await ConsultarCancelamentoNota(idNota);
            }
            else
            {
                MessageBox.Show("Por favor, informe o ID da nota fiscal.", "Aviso");
            }
        }

        // Método para consultar o cancelamento da nota fiscal
        private async Task ConsultarCancelamentoNota(string idNota)
        {
            // URL da API e chave de autenticação
            string apiUrl = $"https://api.sandbox.plugnotas.com.br/nfe/{idNota}/cancelamento/status";
            string authToken = "2da392a6-79d2-4304-a8b7-959572c7e44d";

            // Instância de HttpClient
            using (HttpClient httpClient = new HttpClient())
            {
                // Adiciona a chave de autenticação no header da requisição
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                try
                {
                    // Faz a requisição GET para a API para consultar o cancelamento da nota fiscal
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(JsonBeautify(responseBody), "Resposta da API");
                    }
                    else
                    {
                        MessageBox.Show($"Erro ao consultar o cancelamento da nota fiscal: {response.StatusCode} - {response.ReasonPhrase}", "Erro");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao consultar o cancelamento da nota fiscal: {ex.Message}", "Erro");
                }
            }
        }
        private async void solicitarcorrecaobutton_Click(object sender, EventArgs e)
        {
            // Obtém o ID da nota da TextBox
            string idNota = textBoxNota.Text;

            // Verifica se o ID da nota não está vazio
            if (!string.IsNullOrEmpty(idNota))
            {
                // Chama o método para solicitar correção na nota fiscal
                await SolicitarCorrecaoNota(idNota);
            }
            else
            {
                MessageBox.Show("Por favor, informe o ID da nota fiscal.", "Aviso");
            }
        }

        // Método para solicitar correção na nota fiscal
        private async Task SolicitarCorrecaoNota(string idNota)
        {
            // Implemente a lógica para solicitar correção na nota fiscal aqui
            MessageBox.Show("Método para solicitar correção na nota fiscal ainda não implementado.", "Aviso");
        }

    }
}
