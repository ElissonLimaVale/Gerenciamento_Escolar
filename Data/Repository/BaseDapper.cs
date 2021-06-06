using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SGIEscolar.Data.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace SGIEscolar.Data.Repository
{
    public class BaseDapper : IDapper
    {
        private readonly IConfiguration _config;
        private string Connectionstring = "Default";
        public SqlConnection sqlCon;
        public BaseDapper(IConfiguration config)
        {
            _config = config;
            sqlCon = new SqlConnection(_config.GetConnectionString(Connectionstring));
            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();
        }

        public void Dispose()
        {
            if (this.sqlCon.State != ConnectionState.Closed)
                this.sqlCon.Close();
        }

        public SqlConnection RetornaConexao()
        {
            if (sqlCon == null)
                sqlCon = new SqlConnection(_config.GetConnectionString(Connectionstring));


            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            return sqlCon;
        }

        public async Task ExecutaQueryAsync(string query, DynamicParameters parametros)
        {
            try
            {
                using var tran = sqlCon.BeginTransaction();
                try
                {
                    await sqlCon.ExecuteAsync(query, parametros, transaction: tran);
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open)
                    sqlCon.Close();
            }
        }
        public async Task<List<TEntity>> RetornaListaQueryAsync<TEntity>(string query, DynamicParameters parametros = null)
        {
            try
            {
                return (await sqlCon.QueryAsync<TEntity>(query, parametros)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.sqlCon.State != ConnectionState.Closed)
                    this.sqlCon.Close();
            }
        }

        public async Task<TEntity> RetornaQueryAsync<TEntity>(string query, DynamicParameters parametros)
        {
            try
            {
                return (await sqlCon.QueryAsync<TEntity>(query, parametros)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (this.sqlCon.State != ConnectionState.Closed)
                    this.sqlCon.Close();

            }
        }
    }
}

