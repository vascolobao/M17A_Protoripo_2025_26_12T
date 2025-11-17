using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M17A_Protoripo_2025_26_12T.Livro
{
    internal class Livro : IItem
    {
        public int nlivro {  get; set; }
        public string titulo {get; set; }
        public string autor { get; set; }
        public string isbn {get; set; }
        public int ano { get; set; }
        public DateTime data_aquisicao { get; set; }
        public decimal preco {  get; set; }
        public string capa { get; set; }
        public bool estado { get; set; }

        public void Adicionar()
        {
            throw new NotImplementedException();
        }

        public void Apagar()
        {
            throw new NotImplementedException();
        }

        public void Editar()
        {
            throw new NotImplementedException();
        }

        public List<string> Validar()
        {
            List<string> erros = new List<string>();
            //validar o titulo
            if (titulo.IsNullOrEmpty() || titulo.Length < 3)
            {
                erros.Add("O título deve ter pelo menos 3 caracteres.");
            }

            //validar autor
            if (autor.IsNullOrEmpty() || autor.Length < 3)
            {
                erros.Add("O autor do livro deve ter pelo menos 3 caracteres");
            }

            //validar ano
            if (ano > 0 && ano <= DateTime.Now.Year)
            {
                erros.Add("O ano tem que ser mair que 0");
            }

            //validar isbn
            if (isbn.Length != 13)
            {
                erros.Add("O ISBN do libro deve ter 13 numeros");
            }

            return erros;
        }
    }
}
