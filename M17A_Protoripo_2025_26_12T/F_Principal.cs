using M17A_Protoripo_2025_26_12T.Livro;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M17A_Protoripo_2025_26_12T
{
    public partial class F_Principal : Form
    {
        BaseDados bd;
        public F_Principal()
        {
            InitializeComponent();
            bd = new BaseDados("Bibliotece_12T");
        }

        //Opção para terminar o programa
        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Opção Editar -> Livros
        private void livrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            F_Livro f = new F_Livro(bd);
            f.Show();
        }
    }
}
