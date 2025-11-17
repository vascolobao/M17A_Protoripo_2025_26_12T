using M17A_Protoripo_2025_26_12T;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace M17A_Protoripo_2025_26_12T
{
    /// <summary>
    /// Responsavel por criar a bd, e executar comandos na bd
    /// </summary>
    public class BaseDados
    {
        string NomeBD;
        string StrLigacao;
        string CaminhoBD;
        SqlConnection ligacaoSQL;
        public BaseDados(string NomeBD)
        {
            this.NomeBD = NomeBD;
            //ler a string de ligação
            StrLigacao = ConfigurationManager.ConnectionStrings["sql"].ToString();
            CaminhoBD = Utils.PastaPrograma("M17A_Biblioteca_12T");
            CaminhoBD += @"\" + NomeBD + ".mdf";
            //verificar se bd exist
            if (System.IO.File.Exists(CaminhoBD) == false)
            {
                CriaBD();
            }
            ligacaoSQL = new SqlConnection(StrLigacao);
            ligacaoSQL.Open();
            ligacaoSQL.ChangeDatabase(this.NomeBD);
        }
        /// <summary>
        /// Verifica se a BD existe no catalogo e cria a bd e as tabelas
        /// </summary>
        void CriaBD()
        {
            SqlConnection LigacaoSQL = new SqlConnection(StrLigacao);
            LigacaoSQL.Open();
            string sql = $@"IF EXISTS (SELECT * FROM master.SYS.databases
                            WHERE name = '{this.NomeBD}')
                            BEGIN
                                USE [master];
                                EXEC sp_detach_db {this.NomeBD}
                            END";
            SqlCommand Comando = new SqlCommand(sql, LigacaoSQL);
            Comando.ExecuteNonQuery();
            //criar a base de dados
            sql = $@"CREATE DATABASE {this.NomeBD} ON PRIMARY (NAME={this.NomeBD}, FILENAME='{this.CaminhoBD}')";
            Comando = new SqlCommand(sql, LigacaoSQL);
            Comando.ExecuteNonQuery();
            //Ativar a base de dados
            LigacaoSQL.ChangeDatabase(this.NomeBD);
            //criar as tabelas
            //livros
            sql = @"CREATE TABLE Livros(
                    nlivro INT PRIMARY KEY IDENTITY,
                    Titulo VARCHAR(50) NOT NULL,
                    Autor VARCHAR(100),
                    isbn varchar(8),
                    ano INT check(ano>0),
                    data_aquisicao DATE default getdate(),
                    preco money check(preco>=0),
                    capa varchar(500),
                    estado bit default(1)
                    )";
            Comando = new SqlCommand(sql, LigacaoSQL);
            Comando.ExecuteNonQuery();
            Comando.Dispose();
        }

        public void ExecutarSQL(string sql, List<SqlParameter> parameters = null)
        {
            SqlCommand comando = new SqlCommand(sql, ligacaoSQL);
            if (parameters != null)
                comando.Parameters.AddRange(parameters.ToArray());
            comando.ExecuteNonQuery();
            comando.Dispose();
        }

        public DataTable DevolverSQL(string sql, List<SqlParameter> parameters = null)
        {
            SqlCommand comando = new SqlCommand(sql, ligacaoSQL);
            if (parameters != null)
                comando.Parameters.AddRange (parameters.ToArray());
            SqlDataReader dados = comando.ExecuteReader();
            DataTable registos = new DataTable();
            registos.Load(dados);
            comando.Dispose();
            dados.Close();
            return registos;
        }
    }
}
