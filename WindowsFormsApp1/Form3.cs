using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {

        private readonly string authToken;

        public Form3(string authToken)
        {
            InitializeComponent();
            this.authToken = authToken;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Arquivos JSON (*.json)|*.json|Todos os arquivos (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog.FileName;
                    string fileContent = System.IO.File.ReadAllText(filePath);
                    textBox2.Text = fileContent; // Exibe o conteúdo do arquivo no textBox2
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao abrir o arquivo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            // Verifica se há texto no textBox2
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                try
                {
                    // Serializa o texto do textBox2 para JSON
                    string jsonData = textBox2.Text;

                    // Configura a URL da API de destino
                    string apiUrl = "https://api.sandbox.plugnotas.com.br/empresa";
                    string authToken = this.authToken;

                    using (HttpClient httpClient = new HttpClient())
                    {
                        httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                        // Converte o JSON em conteúdo de StringContent
                        StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                        // Envia a solicitação POST para a API
                        HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                        // Verifica se a resposta é bem-sucedida
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("JSON enviado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show($"Erro ao enviar o JSON: {response.ReasonPhrase}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao enviar o JSON: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("O TextBox2 está vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string cnpj = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(cnpj))
            {
                string apiUrl = $"https://api.sandbox.plugnotas.com.br/empresa/{cnpj}";
                string authToken = this.authToken;

                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                    try
                    {
                        HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                        if (response.IsSuccessStatusCode)
                        {
                            string responseBody = await response.Content.ReadAsStringAsync();
                            ShowResponseMessageBox(responseBody);
                        }
                        else
                        {
                            MessageBox.Show($"Erro ao consultar a API: {response.ReasonPhrase}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao consultar a API: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira um CNPJ válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowResponseMessageBox(string response)
        {
            // Crie um novo formulário para exibir a resposta da API
            Form responseForm = new Form();
            responseForm.Text = "Resposta da API";
            responseForm.Size = new System.Drawing.Size(400, 300);

            // Adicione um controle TextBox para exibir a resposta
            TextBox textBox = new TextBox();
            textBox.Multiline = true;
            textBox.ScrollBars = ScrollBars.Vertical;
            textBox.Dock = DockStyle.Fill;
            textBox.Text = response;

            // Adicione o TextBox ao formulário
            responseForm.Controls.Add(textBox);

            // Mostre o formulário
            responseForm.ShowDialog();
        }

        private string JsonBeautify(string inputJson)
        {
            dynamic parsedJson = Newtonsoft.Json.JsonConvert.DeserializeObject(inputJson);
            return Newtonsoft.Json.JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
        }

    }
}
