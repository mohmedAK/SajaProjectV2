using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace SagaProjectV2.Factory
{
   public class Repository<T>:Database,IRepository<T> where T:class
    {
       private IDbConnection connection = new SqlConnection(conVal("sagaDB"));
       

        public void Execute(string sqlr)
        {
            connection.Execute(sqlr);
        }

        public void ExecuteParam(string sqlr, object param)
        {
            connection.Execute(sqlr, param);
        }

        public IEnumerable<T> GetAll(string sqlstr)
        {
           return connection.Query<T>(sqlstr);
        }

        public IEnumerable<T> GetById(string sqlstr, object param)
        {
            return connection.Query<T>(sqlstr, param);
        }
    }
}
