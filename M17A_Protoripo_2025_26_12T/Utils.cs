using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M17A_Protoripo_2025_26_12T
{
    internal class Utils
    {
        /// <summary>
        /// Verifica se a pasta existe, se nao existir cria a pasta
        /// </summary>
        /// <param name="nome"> Nome da pasta do programa</param>
        /// <returns>Caminho completo para a pasta(sem \ no final)</returns>
        static public string PastaPrograma(string Nome) 
        {
            string pastainicial = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            pastainicial += @"\"+ Nome;
            if (System.IO.Directory.Exists(pastainicial) == false)
                System.IO.Directory.CreateDirectory(pastainicial);
            return pastainicial;

        }
    }
}
