using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M17A_Protoripo_2025_26_12T.Livro
{
    public partial class F_Livro : Form
    {
        string ficheiro_capa = "";
        BaseDados bd;
        public F_Livro(BaseDados bd)
        {
            InitializeComponent();
            this.bd = bd;
        }
        /// <summary>
        /// Botão para procurar a imagem que vai ser a capa do livro
        /// </summary>
        private void btnProcurar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ficheiro = new OpenFileDialog();
            ficheiro.Filter = "Imagens |*.jpg; *.png | Todos os ficheiros | *.*";
            ficheiro.InitialDirectory = "c:\\";
            ficheiro.Multiselect = false;
            if (ficheiro.ShowDialog() == DialogResult.OK)
            {
                string temp = ficheiro.FileName;
                if (System.IO.File.Exists(temp))
                {
                    pbCapa.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbCapa.Image = Image.FromFile(temp);
                    ficheiro_capa = temp;
                }
            }
        }

        /// <summary>
        /// Botão para criar um objeto do tipo livro, validar e guardar os dados
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //criar um objeto do tipo livro
            Livro novo = new Livro();
            //preencher o objeto com os dados do form
            novo.titulo = txtTitulo.Text;
            novo.isbn =  txtISBN.Text;
            novo.ano = int.Parse(txtAno.Text);
            novo.autor = txtAutor.Text;
            novo.data_aquisicao = dtpAquisicao.Value;
            novo.preco = decimal.Parse(txtPreco.Text);
            novo.estado = true;
            novo.capa = Utils.PastaPrograma("M17A_Biblioteca_12T") +@"\"+ novo.isbn;
            //validar os dados
            List<string> erros = novo.Validar();
            if (erros.Count > 0)
            {
                //mostrar os erros 
                string mensagem = "";
                foreach (string erro in erros)
                    mensagem += erro + "; ";
                lb_feedback.Text = mensagem;
                lb_feedback.ForeColor = Color.Red;
                return;
            }

            //se não existirem erros guardar na bd
            novo.Adicionar();

        }
    }
}
