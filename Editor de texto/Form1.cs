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
        StringReader leitura = null;

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

        private void Salvar()
        {
            try
            {
                if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter editortexto_streamWriter = new StreamWriter(arquivo);
                    editortexto_streamWriter.Flush();
                    editortexto_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    editortexto_streamWriter.Write(this.richTextBox1.Text);
                    editortexto_streamWriter.Flush();
                    editortexto_streamWriter.Close();

                }
            } catch (Exception ex)
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
                    while (linha != null)
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

        private void Copiar()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }

        private void Colar()
        {
            richTextBox1.Paste();
        }

        private void btn_copiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btn_colar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void Negrito()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool n, i, s = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);


            if (n == false)
            {
                if (i == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);

                }
                else if (i == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (i == false & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }

            }
            else
            {
                if (i == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);

                }
                else if (i == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (i == true & s == false)
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
            }

        }

        private void Italico()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool n, i, s = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);


            if (i == false)
            {
                if (n == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (n == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);

                }
                else if (n == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (n == false & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);
                }

            }
            else
            {
                if (n == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (n == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);

                }
                else if (n == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }

            }
        }

        private void Sublinhado()
        {
            string nome_da_fonte = null;
            float tamanho_da_fonte = 0;
            bool n, i, s = false;

            nome_da_fonte = richTextBox1.Font.Name;
            tamanho_da_fonte = richTextBox1.Font.Size;
            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Regular);


            if (s == false)
            {
                if (n == true & i == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
                else if (n == false & i == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic | FontStyle.Underline);

                }
                else if (n == true & i == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (n == false & i == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Underline);
                }

            }
            else
            {
                if (n == true & i == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (n == false & i == true)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Italic);

                }
                else if (n == true & i == false)
                {
                    richTextBox1.SelectionFont = new Font(nome_da_fonte, tamanho_da_fonte, FontStyle.Bold);
                }
            }

        }

        private void imprimir()
        {
            printDialog1.Document = printDocument1;
            string texto = this.richTextBox1.Text;
            leitura = new StringReader(texto);
            if(printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void alinharEsquerda()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void alinharDireita()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void alinharCentro()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void btn_negrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void btn_italico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void btn_sublinhado_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void italicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void sublinhadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void btn_esquerda_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void btn_direita_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void btn_centro_Click(object sender, EventArgs e)
        {
            alinharCentro();
        }

        private void imprimirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhasPagina = 0;
            float PosY = 0;
            int cont = 0;
            float margemEsquerda = e.MarginBounds.Left - 50;
            float margemSuperior = e.MarginBounds.Top - 50;
            if(margemEsquerda < 5)
            {
                margemEsquerda = 20;
            }
            if (margemSuperior < 5)
            {
                margemSuperior = 20;
            }
            string linha = null;
            Font Fonte = this.richTextBox1.Font;
            SolidBrush pincel = new SolidBrush(Color.Black);
            linhasPagina = e.MarginBounds.Height / Fonte.GetHeight(e.Graphics);
            linha = leitura.ReadLine();
            while(cont < linhasPagina)
            {
                PosY = (margemSuperior + (cont * Fonte.GetHeight(e.Graphics)));
                e.Graphics.DrawString(linha, Fonte, pincel, margemEsquerda, PosY, new StringFormat());
                cont += 1;
                linha = leitura.ReadLine();
            }
            if(linha !=null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
            pincel.Dispose();
        }
    }

}
