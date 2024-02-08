
namespace WindowsFormsApp1
{
    partial class PlugNotas
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.radioButtonSandbox = new System.Windows.Forms.RadioButton();
            this.radioButtonProd = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textboxkey = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(49, 63);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 74);
            this.button1.TabIndex = 0;
            this.button1.Text = "Notas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(251, 63);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 74);
            this.button2.TabIndex = 1;
            this.button2.Text = "Empresa";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(49, 167);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(167, 74);
            this.button3.TabIndex = 2;
            this.button3.Text = "Certificado";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // radioButtonSandbox
            // 
            this.radioButtonSandbox.AutoSize = true;
            this.radioButtonSandbox.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonSandbox.Location = new System.Drawing.Point(12, 12);
            this.radioButtonSandbox.Name = "radioButtonSandbox";
            this.radioButtonSandbox.Size = new System.Drawing.Size(67, 17);
            this.radioButtonSandbox.TabIndex = 4;
            this.radioButtonSandbox.TabStop = true;
            this.radioButtonSandbox.Text = "Sandbox";
            this.radioButtonSandbox.UseVisualStyleBackColor = false;
            this.radioButtonSandbox.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButtonProd
            // 
            this.radioButtonProd.AutoSize = true;
            this.radioButtonProd.BackColor = System.Drawing.Color.Transparent;
            this.radioButtonProd.Location = new System.Drawing.Point(85, 12);
            this.radioButtonProd.Name = "radioButtonProd";
            this.radioButtonProd.Size = new System.Drawing.Size(71, 17);
            this.radioButtonProd.TabIndex = 5;
            this.radioButtonProd.TabStop = true;
            this.radioButtonProd.Text = "Produção";
            this.radioButtonProd.UseVisualStyleBackColor = false;
            this.radioButtonProd.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "x-api-key";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textboxkey
            // 
            this.textboxkey.Location = new System.Drawing.Point(66, 37);
            this.textboxkey.Name = "textboxkey";
            this.textboxkey.Size = new System.Drawing.Size(208, 20);
            this.textboxkey.TabIndex = 7;
            this.textboxkey.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(280, 37);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(44, 20);
            this.button4.TabIndex = 8;
            this.button4.Text = "definir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // PlugNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp1.Properties.Resources.Frame_8;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(464, 261);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.textboxkey);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.radioButtonProd);
            this.Controls.Add(this.radioButtonSandbox);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "PlugNotas";
            this.Text = "PlugNotas";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton radioButtonSandbox;
        private System.Windows.Forms.RadioButton radioButtonProd;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textboxkey;
        private System.Windows.Forms.Button button4;
    }
}

