using Dapper;
using MySql.Data.MySqlClient;
using Toycom.Models;
namespace Toycom.Repositorio
{
    public class ProdutoRep
    {
        private readonly string _connectionString;


        public ProdutoRep(string connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<IEnumerable<Produtos>>TodosProdutos()
        {
            using var connection = new MySqlConnection(_connectionString);
            var sql = "Select Id, Nome, Descricao, Preco, ImageUrl, Estoque from tbProduto";
            return await connection.QueryAsync<Produtos>(sql);
        }
    }
}
