using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using ATV_2.Models;

namespace ATV_2
{
    public class UsuarioRepository
    {
        private const string DadosConexao = "Database=atv_2; Data Source=localhost; User Id=root;AllowZeroDateTime=True";

            public void TestarConexao()
        {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
       
            Conexao.Open();

            Console.WriteLine("O sistema está conectando com o banco de dados. Parabéns!!!");
            
            Conexao.Close();   

        }

        public void Excluir(Usuario usuario)
        {
    using (MySqlConnection conexao = new MySqlConnection(DadosConexao))
    {
        conexao.Open();

        string selectQuery = "SELECT IdPacotes FROM PacotesTuristicos WHERE Usuario = @UsuarioId";

        using (MySqlCommand comandoSelect = new MySqlCommand(selectQuery, conexao))
        {
            comandoSelect.Parameters.AddWithValue("@UsuarioId", usuario.Id);

            using (MySqlDataReader reader = comandoSelect.ExecuteReader())
            {
                List<int> pacoteIds = new List<int>();
                while (reader.Read())
                {
                    int pacoteId = reader.GetInt32("IdPacotes");
                    pacoteIds.Add(pacoteId);
                }

                foreach (int pacoteId in pacoteIds)          {                                      
            }
          }
        }

        string deleteQuery = "DELETE FROM Usuario WHERE Id = @Id";

        using (MySqlCommand comandoDelete = new MySqlCommand(deleteQuery, conexao))
        {
            comandoDelete.Parameters.AddWithValue("@Id", usuario.Id);
            comandoDelete.ExecuteNonQuery();
        }
    }
}
        public void Alterar(Usuario usuario)
        {
            MySqlConnection conexao = new MySqlConnection(DadosConexao);

            conexao.Open();

            String Query = "Update Usuario set Nome=@Nome, Login=@Login, Senha=@Senha, DataNascimento=@DataNascimento Where Id=@Id";

            MySqlCommand Comando = new MySqlCommand(Query, conexao);
            Comando.Parameters.AddWithValue("@Id", usuario.Id);
            Comando.Parameters.AddWithValue("@Nome", usuario.Nome);
            Comando.Parameters.AddWithValue("@Login", usuario.Login);
            Comando.Parameters.AddWithValue("@Senha", usuario.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);

            Comando.ExecuteNonQuery();

            conexao.Close();
        }

        public void Inserir(Usuario usuario)
        {
            MySqlConnection conexao = new MySqlConnection(DadosConexao);

            conexao.Open();

            String Query = "Insert into Usuario(Nome, Login, Senha, DataNascimento) values (@Nome, @Login, @Senha, @DataNascimento)";

            MySqlCommand Comando = new MySqlCommand(Query, conexao);

            Comando.Parameters.AddWithValue("@Nome", usuario.Nome);
            Comando.Parameters.AddWithValue("@Login", usuario.Login);
            Comando.Parameters.AddWithValue("@Senha", usuario.Senha);
            Comando.Parameters.AddWithValue("@DataNascimento", usuario.DataNascimento);

            Comando.ExecuteNonQuery();

            conexao.Close();
        }

        public List<Usuario> Listar()
        {
            MySqlConnection conexao = new MySqlConnection(DadosConexao);

            conexao.Open();

            String Query = "Select * from Usuario";

            MySqlCommand Comando = new MySqlCommand(Query, conexao);

            MySqlDataReader Reader = Comando.ExecuteReader();

            List<Usuario> Lista = new List<Usuario>();

    while (Reader.Read())
    {
        Usuario usuarioEncontrado = new Usuario();
        usuarioEncontrado.Id = Reader.GetInt32("Id");

        if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
            usuarioEncontrado.Nome = Reader.GetString("Nome");

        if (!Reader.IsDBNull(Reader.GetOrdinal("Login")))
            usuarioEncontrado.Login = Reader.GetString("Login");

        if (!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
            usuarioEncontrado.Senha = Reader.GetString("Senha");

        usuarioEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");

        Lista.Add(usuarioEncontrado);
    }

            conexao.Close();
            return Lista;
}

       public Usuario BuscarPorId(int id)
{
    using (MySqlConnection conexao = new MySqlConnection(DadosConexao))
    {
        conexao.Open();

        string selectQuery = "SELECT * FROM Usuario WHERE Id = @Id";

        using (MySqlCommand comando = new MySqlCommand(selectQuery, conexao))
        {
            comando.Parameters.AddWithValue("@Id", id);

            using (MySqlDataReader reader = comando.ExecuteReader())
            {
                if (reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        Id = reader.GetInt32("Id"),
                        Nome = reader.GetString("Nome"),
                        Login = reader.GetString("Login"),
                        Senha = reader.GetString("Senha"),
                        DataNascimento = reader.GetDateTime("DataNascimento")
                    };
                    return usuario;
                }
            }
        }
    }

    return null; 
}

        public Usuario ValidarLogin(Usuario usuario)
{
            MySqlConnection conexao = new MySqlConnection(DadosConexao);

            conexao.Open();

            string query = "SELECT * FROM Usuario WHERE Login = @Login AND Senha = @Senha";

            MySqlCommand comando = new MySqlCommand(query, conexao);

            comando.Parameters.AddWithValue("@Login", usuario.Login);
            comando.Parameters.AddWithValue("@Senha", usuario.Senha);

            MySqlDataReader reader = comando.ExecuteReader();

            Usuario usuarioEncontrado = null;

    if (reader.Read())
    {
        usuarioEncontrado = new Usuario();
        usuarioEncontrado.Id = reader.GetInt32("Id");

        if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
            usuarioEncontrado.Nome = reader.GetString("Nome");

        if (!reader.IsDBNull(reader.GetOrdinal("Login")))
            usuarioEncontrado.Login = reader.GetString("Login");

        if (!reader.IsDBNull(reader.GetOrdinal("Senha")))
            usuarioEncontrado.Senha = reader.GetString("Senha");

        usuarioEncontrado.DataNascimento = reader.GetDateTime("DataNascimento");
    }

           conexao.Close();
           return usuarioEncontrado;
}
    }
}