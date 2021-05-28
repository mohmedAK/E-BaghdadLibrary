using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace ELibrary.Factory
{
    class Repository<T> : IRepository<T> where T : class
    {
        private IDbConnection connection = new SqlConnection(database.conVal());
        public void ExcParam(string sqlstr, object param)
        {
            connection.Execute(sqlstr, param);
        }

        public void ExecQuery(string sqlstr)
        {
            connection.Execute(sqlstr);
        }

        public IEnumerable<T> GetAll(string sqlstr)
        {
            return connection.Query<T>(sqlstr);
        }

        public IEnumerable<T> GetByParam(string sqlstr, object param)
        {
            return connection.Query<T>(sqlstr, param);
        }

        public T GetSingle(string sqlstr, object param)
        {
            return connection.Query<T>(sqlstr, param).SingleOrDefault();
        }

        public T GetSingle(string sqlstr)
        {
            return connection.Query<T>(sqlstr).SingleOrDefault();
        }
    }
}
