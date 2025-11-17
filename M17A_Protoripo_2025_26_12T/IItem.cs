using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M17A_Protoripo_2025_26_12T
{
    internal interface IItem
    {
        //Validar Dados
        List<string> Validar();
        //Adicionar
        void Adicionar(); //TODO: base de dados
        //Editar
        void Editar(); //TODO: base de dados
        //Apagar
        void Apagar(); //TODO: base de dados
    }
}
