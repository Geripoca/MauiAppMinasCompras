using MauiAppMinasCompras.Models;
using SQLite;

namespace MauiAppMinasCompras.Helpers
{
    public class SQLiteDatabaseHelper
    {
        readonly SQLiteAsyncConnection _conn;
        public SQLiteDatabaseHelper(string path) 
        {
            _conn = new SQLiteAsyncConnection(path);
            _conn.CreateTableAsync<Produtos>().Wait();
        }

        public Task<int> Insert(Produtos p) 
        {
            return _conn.InsertAsync(p);        }

        public Task<List<Produtos>> Update(Produtos p)
        {
            string sql = "UPDATE Produto SET Descricao=?, Quantidade=?, Preco=? WHERE Id=?";

            return _conn.QueryAsync<Produtos>(
                sql, p.Descricao, p.Quantidade, p.Preco, p.Id
            );
        }

        public Task<int> Delete(int id) 
        {
            return _conn.Table<Produtos>().DeleteAsync(i => i.Id == id);
        }

        public Task<List<Produtos>> GetAll() 
        {
            return _conn.Table<Produtos>().ToListAsync();
        }

        public Task<List<Produtos>> Search(String q) 
        {
            string sql = "SELECT * Produto WHERE Descricao LIKE '%%" + q + "%' ";

            return _conn.QueryAsync<Produtos>(sql);
        }

    }
}
