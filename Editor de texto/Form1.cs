using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Editor_de_texto
{
    public partial class Form1 : Form
    {
        StreamReader leitura = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Novo()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void novoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Novo();
        }

        private void Salvar ()
        {
            try
            {
                if(this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter editortexto_streamWriter = new StreamWriter(arquivo);
                    editortexto_streamWriter.Flush();
                    editortexto_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    editortexto_streamWriter.Write(this.richTextBox1.Text);
                    editortexto_streamWriter.Flush();
                    editortexto_streamWriter.Close();

                }
            }catch(Exception ex)
            {
                MessageBox.Show("Erro na gravação do arquivo: " + ex.Message, "Erro ao gravar!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            Salvar();
        }

        private void Abrir()
        {
            this.openFileDialog1.Title = "Abrir Arquivos";
            openFileDialog1.InitialDirectory = @"C:\Users\Nataly\Documents\Editor text-cSharp\";
            openFileDialog1.Filter = "(*.CSHARP)|*.CSHARP";

            DialogResult dr = this.openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader editortexto_streamReader = new StreamReader(arquivo);
                    editortexto_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = editortexto_streamReader.ReadLine();
                    while(linha != null)
                    {
                        this.richTextBox1.Text += linha + "\n";
                        linha = editortexto_streamReader.ReadLine();
                    }
                    editortexto_streamReader.Close();

                }
                catch (Exception ex)
                    {
                        MessageBox.Show("Erro de leitura do arquivo: " + ex.Message, "Erro ao ler!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
            }


        }

        private void btn_abrir_Click(object sender, EventArgs e)
        {
            Abrir();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Abrir();
        }
    }
}
