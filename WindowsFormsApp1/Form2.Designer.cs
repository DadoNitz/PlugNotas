
using System;

namespace WindowsFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNota = new System.Windows.Forms.TextBox();
            this.buttonConsulta = new System.Windows.Forms.Button();
            this.cancelarbutton = new System.Windows.Forms.Button();
            this.emitirbutton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uploadbutton = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.consultarcancelamentobutton = new System.Windows.Forms.Button();
            this.solicitarcorrecaobutton = new System.Windows.Forms.Button();
            this.consultarPorPeriodoButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "id Nota fiscal";
            // 
            // textBoxNota
            // 
            this.textBoxNota.AcceptsTab = true;
            this.textBoxNota.Location = new System.Drawing.Point(123, 19);
            this.textBoxNota.Name = "textBoxNota";
            this.textBoxNota.Size = new System.Drawing.Size(305, 20);
            this.textBoxNota.TabIndex = 1;
            this.textBoxNota.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // buttonConsulta
            // 
            this.buttonConsulta.Location = new System.Drawing.Point(123, 45);
            this.buttonConsulta.Name = "buttonConsulta";
            this.buttonConsulta.Size = new System.Drawing.Size(79, 23);
            this.buttonConsulta.TabIndex = 2;
            this.buttonConsulta.Text = "Consultar";
            this.buttonConsulta.UseVisualStyleBackColor = true;
            this.buttonConsulta.Click += new System.EventHandler(this.ButtonConsultar_Click);
            // 
            // cancelarbutton
            // 
            this.cancelarbutton.Location = new System.Drawing.Point(208, 45);
            this.cancelarbutton.Name = "cancelarbutton";
            this.cancelarbutton.Size = new System.Drawing.Size(75, 23);
            this.cancelarbutton.TabIndex = 3;
            this.cancelarbutton.Text = "Cancelar";
            this.cancelarbutton.UseVisualStyleBackColor = true;
            this.cancelarbutton.Click += new System.EventHandler(this.cancelarbutton_Click);
            // 
            // emitirbutton
            // 
            this.emitirbutton.Location = new System.Drawing.Point(244, 408);
            this.emitirbutton.Name = "emitirbutton";
            this.emitirbutton.Size = new System.Drawing.Size(71, 23);
            this.emitirbutton.TabIndex = 4;
            this.emitirbutton.Text = "Emitir";
            this.emitirbutton.UseVisualStyleBackColor = true;
            this.emitirbutton.Click += new System.EventHandler(this.emitirbutton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Insira os dados em formato JSON";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(15, 135);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(300, 267);
            this.textBox2.TabIndex = 6;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(335, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Digite o cpf ou cnpj";
            // 
            // uploadbutton
            // 
            this.uploadbutton.Location = new System.Drawing.Point(15, 408);
            this.uploadbutton.Name = "uploadbutton";
            this.uploadbutton.Size = new System.Drawing.Size(69, 23);
            this.uploadbutton.TabIndex = 8;
            this.uploadbutton.Text = "upload json";
            this.uploadbutton.UseVisualStyleBackColor = true;
            this.uploadbutton.Click += new System.EventHandler(this.uploadbutton_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(338, 174);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(338, 213);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker2.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(432, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "até";
            // 
            // consultarcancelamentobutton
            // 
            this.consultarcancelamentobutton.Location = new System.Drawing.Point(289, 45);
            this.consultarcancelamentobutton.Name = "consultarcancelamentobutton";
            this.consultarcancelamentobutton.Size = new System.Drawing.Size(139, 23);
            this.consultarcancelamentobutton.TabIndex = 12;
            this.consultarcancelamentobutton.Text = "consultar cancelamento";
            this.consultarcancelamentobutton.UseVisualStyleBackColor = true;
            this.consultarcancelamentobutton.Click += new System.EventHandler(this.consultarcancelamentobutton_Click);
            // 
            // solicitarcorrecaobutton
            // 
            this.solicitarcorrecaobutton.Location = new System.Drawing.Point(123, 74);
            this.solicitarcorrecaobutton.Name = "solicitarcorrecaobutton";
            this.solicitarcorrecaobutton.Size = new System.Drawing.Size(305, 23);
            this.solicitarcorrecaobutton.TabIndex = 13;
            this.solicitarcorrecaobutton.Text = "Solicitar correção";
            this.solicitarcorrecaobutton.UseVisualStyleBackColor = true;
            this.solicitarcorrecaobutton.Click += new System.EventHandler(this.solicitarcorrecaobutton_Click);
            // 
            // consultarPorPeriodoButton
            // 
            this.consultarPorPeriodoButton.Location = new System.Drawing.Point(338, 240);
            this.consultarPorPeriodoButton.Name = "consultarPorPeriodoButton";
            this.consultarPorPeriodoButton.Size = new System.Drawing.Size(75, 23);
            this.consultarPorPeriodoButton.TabIndex = 14;
            this.consultarPorPeriodoButton.Text = "Consultar";
            this.consultarPorPeriodoButton.UseVisualStyleBackColor = true;
            this.consultarPorPeriodoButton.Click += new System.EventHandler(this.consultarPorPeriodoButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(338, 135);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Selecione o período";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.consultarPorPeriodoButton);
            this.Controls.Add(this.solicitarcorrecaobutton);
            this.Controls.Add(this.consultarcancelamentobutton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.uploadbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.emitirbutton);
            this.Controls.Add(this.cancelarbutton);
            this.Controls.Add(this.buttonConsulta);
            this.Controls.Add(this.textBoxNota);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form2";
            this.Text = "Notas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNota;
        private System.Windows.Forms.Button buttonConsulta;
        private System.Windows.Forms.Button cancelarbutton;
        private System.Windows.Forms.Button emitirbutton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button uploadbutton;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button consultarcancelamentobutton;
        private System.Windows.Forms.Button solicitarcorrecaobutton;
        private System.Windows.Forms.Button consultarPorPeriodoButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
    }
}