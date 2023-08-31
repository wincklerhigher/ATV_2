using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using ATV_2.Models;

namespace ATV_2.Models
{
    public class PacotesTuristicosRepository
    {
        private const string DadosConexao = "Database=atv_2; Data Source=localhost; User Id=root;AllowZeroDateTime=True";


        public bool UsuarioValido(int usuarioId)
        {
            MySqlConnection conexao = new MySqlConnection(DadosConexao);
            conexao.Open();

            string query = "SELECT Id FROM Usuario WHERE Id = @UsuarioId";

            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@UsuarioId", usuarioId);

            object result = comando.ExecuteScalar();
            conexao.Close();

            return result != null;
        }
    
        public void Inserir(PacotesTuristicos pacote)
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);

            Conexao.Open();

            String Query = "INSERT INTO PacotesTuristicos(Nome, Origem, Destino, Atrativos, Saida, Retorno, Usuario) VALUES (@Nome, @Origem, @Destino, @Atrativos, @Saida, @Retorno, @Usuario)";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            Comando.Parameters.AddWithValue("@Nome", pacote.Nome);
            Comando.Parameters.AddWithValue("@Origem", pacote.Origem);
            Comando.Parameters.AddWithValue("@Destino", pacote.Destino);
            Comando.Parameters.AddWithValue("@Atrativos", pacote.Atrativos);
            Comando.Parameters.AddWithValue("@Saida", pacote.Saida);
            Comando.Parameters.AddWithValue("@Retorno", pacote.Retorno);
            Comando.Parameters.AddWithValue("@Usuario", pacote.Usuario);

            Comando.ExecuteNonQuery();
            Conexao.Close();
        }

        public List<PacotesTuristicos> Listar()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();

            String Query = "SELECT * FROM PacotesTuristicos";

            MySqlCommand Comando = new MySqlCommand(Query, Conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<PacotesTuristicos> Lista = new List<PacotesTuristicos>();

          while (Reader.Read())    {

        PacotesTuristicos pacoteEncontrado = new PacotesTuristicos();
        pacoteEncontrado.IdPacotes = Reader.GetInt32(Reader.GetOrdinal("IdPacotes"));
        pacoteEncontrado.Nome = Reader.GetString(Reader.GetOrdinal("Nome"));
        pacoteEncontrado.Origem = Reader.GetString(Reader.GetOrdinal("Origem"));
        pacoteEncontrado.Destino = Reader.GetString(Reader.GetOrdinal("Destino"));
        pacoteEncontrado.Atrativos = Reader.GetString(Reader.GetOrdinal("Atrativos"));
        pacoteEncontrado.Saida = Reader.GetDateTime(Reader.GetOrdinal("Saida"));
        pacoteEncontrado.Retorno = Reader.GetDateTime(Reader.GetOrdinal("Retorno"));

    if (!Reader.IsDBNull(Reader.GetOrdinal("Usuario")))
    {
        pacoteEncontrado.Usuario = Reader.GetInt32(Reader.GetOrdinal("Usuario"));
    }

    Lista.Add(pacoteEncontrado);}

            Conexao.Close();

            return Lista;
        }

        public void Excluir(PacotesTuristicos pacote)
        {
            MySqlConnection conexao = new MySqlConnection(DadosConexao);
            conexao.Open();

            string query = "Delete from PacotesTuristicos where IdPacotes = @IdPacotes";

            MySqlCommand comando = new MySqlCommand(query, conexao);
            comando.Parameters.AddWithValue("@IdPacotes", pacote.IdPacotes);

            comando.ExecuteNonQuery();

            conexao.Close();
        }

        public void Alterar(PacotesTuristicos pacote)
        {
            MySqlConnection conexao = new MySqlConnection(DadosConexao);
            conexao.Open();

            string query = "Update PacotesTuristicos set Nome=@Nome, Origem=@Origem, Destino=@Destino, " +
                           "Atrativos=@Atrativos, Saida=@Saida, Retorno=@Retorno, Usuario=@Usuario " +
                           "Where IdPacotes=@IdPacotes";

            MySqlCommand comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@IdPacotes", pacote.IdPacotes);
            comando.Parameters.AddWithValue("@Nome", pacote.Nome);
            comando.Parameters.AddWithValue("@Origem", pacote.Origem);
            comando.Parameters.AddWithValue("@Destino", pacote.Destino);
            comando.Parameters.AddWithValue("@Atrativos", pacote.Atrativos);
            comando.Parameters.AddWithValue("@Saida", pacote.Saida);
            comando.Parameters.AddWithValue("@Retorno", pacote.Retorno);
            comando.Parameters.AddWithValue("@Usuario", pacote.Usuario);

            comando.ExecuteNonQuery();

            conexao.Close();
        }

       public PacotesTuristicos BuscarPorId(int idPacote)
{
    MySqlConnection conexao = new MySqlConnection(DadosConexao);
    conexao.Open();

    string query = "SELECT * FROM PacotesTuristicos WHERE IdPacotes = @IdPacotes";

    MySqlCommand comando = new MySqlCommand(query, conexao);
    comando.Parameters.AddWithValue("@IdPacotes", idPacote);

    MySqlDataReader reader = comando.ExecuteReader();

    PacotesTuristicos pacoteEncontrado = null;

    if (reader.Read())
    {
        pacoteEncontrado = new PacotesTuristicos();
        int idPacotesIndex = reader.GetOrdinal("IdPacotes");
        int nomeIndex = reader.GetOrdinal("Nome");
        int origemIndex = reader.GetOrdinal("Origem");
        int destinoIndex = reader.GetOrdinal("Destino");
        int atrativosIndex = reader.GetOrdinal("Atrativos");
        int saidaIndex = reader.GetOrdinal("Saida");
        int retornoIndex = reader.GetOrdinal("Retorno");
        int usuarioIndex = reader.GetOrdinal("Usuario");

        pacoteEncontrado.IdPacotes = reader.GetInt32(idPacotesIndex);
        pacoteEncontrado.Nome = reader.GetString(nomeIndex);
        pacoteEncontrado.Origem = reader.GetString(origemIndex);
        pacoteEncontrado.Destino = reader.GetString(destinoIndex);
        pacoteEncontrado.Atrativos = reader.GetString(atrativosIndex);
        pacoteEncontrado.Saida = reader.GetDateTime(saidaIndex);
        pacoteEncontrado.Retorno = reader.GetDateTime(retornoIndex);

        if (!reader.IsDBNull(usuarioIndex))
        {
            pacoteEncontrado.Usuario = reader.GetInt32(usuarioIndex);
        }
    }
         conexao.Close();

         return pacoteEncontrado;}
    }
}    