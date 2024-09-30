using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SajaProjectV2.Factory
{
   public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll(string sqlstr);
        IEnumerable<T> GetById(string sqlstr, object param);
        void Execute(string sqlr);
        void ExecuteParam(string sqlr, object param);
    }
}
