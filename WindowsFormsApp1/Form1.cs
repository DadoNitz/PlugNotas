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
    public partial class PlugNotas : Form
    {
        public PlugNotas()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }    

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            // Verifica se o token de autenticação foi definido
            if (!string.IsNullOrEmpty(this.ApiKey))
            {
                // Cria uma instância do Form2 passando o token de autenticação
                Form2 form2 = new Form2(this.ApiKey);

                // Exibe o Form2
                form2.Show();
            }
            else
            {
                MessageBox.Show("Por favor, defina o token de autenticação antes de prosseguir.", "Aviso");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            // Verifica se o token de autenticação foi definido
            if (!string.IsNullOrEmpty(this.ApiKey))
            {
                // Cria uma instância do Form2 passando o token de autenticação
                Form3 form3 = new Form3(this.ApiKey);

                // Exibe o Form2
                form3.Show();
            }
            else
            {
                MessageBox.Show("Por favor, defina o token de autenticação antes de prosseguir.", "Aviso");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.ApiKey))
            {
                // Cria uma instância do Form2 passando o token de autenticação
                Form4 form4 = new Form4(this.ApiKey);

                // Exibe o Form2
                form4.Show();
            }
            else
            {
                MessageBox.Show("Por favor, defina o token de autenticação antes de prosseguir.", "Aviso");
            }
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Obtém o token de autenticação do textBox2
            string authToken = textboxkey.Text;

            // Armazena o token de autenticação em uma propriedade de Form1
            this.ApiKey = authToken;

            // Exibe uma mensagem de confirmação
            MessageBox.Show("Token de autenticação definido com sucesso.", "Sucesso");
        }

        public string ApiKey { get; private set; }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonSandbox.Checked) // Se o RadioButton de sandbox estiver marcado
            {
                textboxkey.Enabled = false; // Desabilita a TextBox para entrada de texto
                textboxkey.Text = "2da392a6-79d2-4304-a8b7-959572c7e44d"; // Preenche a TextBox com o valor padrão
            }
            else
            {
                textboxkey.Enabled = true; // Habilita a TextBox para entrada de texto
                textboxkey.Text = ""; // Limpa o texto da TextBox
            }
        }
    }
}
