using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SGIEscolar.Data.Interface
{
    public interface IDapper : IDisposable
    {
        SqlConnection RetornaConexao();
        Task ExecutaQueryAsync(string query, DynamicParameters parametros);
        Task<TEntity> RetornaQueryAsync<TEntity>(string query, DynamicParameters parametros);
        Task<List<TEntity>> RetornaListaQueryAsync<TEntity>(string query, DynamicParameters parametros = null);
    }
}
