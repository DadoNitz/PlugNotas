using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        private readonly string authToken;

        public Form2(string authToken)
        {
            InitializeComponent();
            this.authToken = authToken;
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
            string authToken = this.authToken; 

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
                form.Width = 500;
                form.Height = 200; 
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
            string authToken = this.authToken;

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
            string authToken = this.authToken;

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
            // Solicita a correção da nota fiscal ao usuário
            string correcao = PedirCorrecao();

            // Verifica se o usuário forneceu uma correção
            if (!string.IsNullOrEmpty(correcao))
            {
                try
                {
                    // URL da API para solicitar correção na nota fiscal
                    string apiUrl = $"https://api.sandbox.plugnotas.com.br/nfe/{idNota}/cce";
                    string authToken = this.authToken;

                    // Instância de HttpClient
                    using (HttpClient httpClient = new HttpClient())
                    {
                        // Adiciona a chave de autenticação no header da requisição
                        httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                        // Monta o payload de correção
                        var correcaoPayload = new { correcao = correcao };
                        var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(correcaoPayload);
                        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                        // Envia a requisição POST para a API para solicitar correção na nota fiscal
                        HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Correção da nota fiscal solicitada com sucesso.", "Sucesso");
                        }
                        else
                        {
                            MessageBox.Show($"Erro ao solicitar correção da nota fiscal: {response.StatusCode} - {response.ReasonPhrase}", "Erro");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao solicitar correção da nota fiscal: {ex.Message}", "Erro");
                }
            }
            else
            {
                MessageBox.Show("Por favor, forneça a correção para a nota fiscal.", "Aviso");
            }
        }


        // Método para solicitar a correção ao usuário
        private string PedirCorrecao()
        {
            using (var form = new Form())
            {
                form.Text = "Informe a Correção";
                form.Width = 500;
                form.Height = 200;
                var label = new Label() { Left = 50, Top = 20, Text = "Correção:" };
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
        private async void uploadbutton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Arquivos JSON (*.json)|*.json";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string apiUrl = "https://api.sandbox.plugnotas.com.br/nfe";

                        // Leitura do conteúdo do arquivo selecionado
                        string jsonContent = File.ReadAllText(openFileDialog.FileName);

                        // Exibe mensagem de confirmação
                        DialogResult result = MessageBox.Show("Deseja enviar o arquivo JSON para a API?", "Confirmação", MessageBoxButtons.YesNo);
                        if (result == DialogResult.Yes)
                        {
                            // Envio do conteúdo para a API
                            using (HttpClient httpClient = new HttpClient())
                            {
                                string authToken = this.authToken;
                                httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                                if (response.IsSuccessStatusCode)
                                {
                                    string responseBody = await response.Content.ReadAsStringAsync();
                                    MessageBox.Show($"Resposta da API:\n{responseBody}", "Sucesso");
                                }
                                else
                                {
                                    MessageBox.Show($"Erro ao enviar arquivo JSON para a API: {response.StatusCode} - {response.ReasonPhrase}", "Erro");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao enviar arquivo JSON para a API: {ex.Message}", "Erro");
                    }
                }
            }
        }
        private async void emitirbutton_Click(object sender, EventArgs e)
        {
            try
            {
                string apiUrl = "https://api.sandbox.plugnotas.com.br/nfe";

                // Obtém o conteúdo da textBox2
                string jsonContent = textBox2.Text;

                // Exibe mensagem de confirmação
                DialogResult result = MessageBox.Show("Deseja enviar o conteúdo para a API?", "Confirmação", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    await EnviarConteudoParaAPI(apiUrl, jsonContent);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao enviar conteúdo para a API: {ex.Message}", "Erro");
            }
        }

        private async Task EnviarConteudoParaAPI(string apiUrl, string jsonContent)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string authToken = this.authToken;
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"Resposta da API:\n{responseBody}", "Sucesso");
                }
                else
                {
                    MessageBox.Show($"Erro ao enviar conteúdo para a API: {response.StatusCode} - {response.ReasonPhrase}", "Erro");
                }
            }
        }

        private async void consultarPorPeriodoButton_Click(object sender, EventArgs e)
        {
            try
            {
                string cpfCnpj = textBox1.Text; // Obtém o CPF/CNPJ digitado na textBox1
                string dataInicial = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string dataFinal = dateTimePicker2.Value.ToString("yyyy-MM-dd");

                string apiUrl = $"https://api.sandbox.plugnotas.com.br/nfe/consulta/periodo?cpfCnpj={cpfCnpj}&dataInicial={dataInicial}&dataFinal={dataFinal}";

                string authToken = this.authToken;

                await ConsultarNotasPorPeriodo(apiUrl, authToken);

                MessageBox.Show("Consulta de notas por período concluída com sucesso.", "Sucesso");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao consultar notas por período: {ex.Message}", "Erro");
            }
        }

        private async Task ConsultarNotasPorPeriodo(string apiUrl, string authToken)
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                    try
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            MessageBox.Show(JsonBeautify(responseBody), "Resposta da API");
                        }
                        else
                        {
                            MessageBox.Show($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase}", "Erro");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro na requisição: {ex.Message}", "Erro");
                    }
                }
            }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
